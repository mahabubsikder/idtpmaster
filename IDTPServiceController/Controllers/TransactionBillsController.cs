using IDTP.Utility;
using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;

namespace IDTPServiceController.Controllers
{
    /**
    * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
    * Invocation:          No need of invocation. Auto triggered when FCM message is received.
    * Implementation Flow:
    *                      a. Get All Transactions.
    *                      b. Get Transaction by Id.
    *                      c. Create Transaction.
    *                      d. Delete Transaction.
    */


    [Route("[controller]")]
    [ApiController]
    public class TransactionBillsController : Controller
    {
        //private readonly ITransactionRepository _cosmosDbService;
        private readonly IBusinessLayer _businessLayer;
        public TransactionBillsController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;

        }
        
        [HttpPost("/TransactionBill", Name = "TransactionBill")]
        [Authorize(Roles = IDTPRoleNames.FinancialInstitute)]
        public string TransactionBill([FromBody] string xmlData)
        {
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);

                #region data fetched from xml
                string txnId, amount, senderBIC, receiverBIC, senderAccNo, receiverAccNo, sendingBankRoutingNo, receivingBankRoutingNo, purpose = string.Empty;
                txnId = doc.GetElementsByTagName("TxId").Item(0).InnerText;
                amount = doc.GetElementsByTagName("IntrBkSttlmAmt").Item(0).InnerText;
                senderBIC = doc.GetElementsByTagName("BICFI").Item(0).InnerText;
                receiverBIC = doc.GetElementsByTagName("BICFI").Item(3).InnerText;
                senderAccNo = doc.GetElementsByTagName("Id").Item(0).InnerText;
                receiverAccNo = doc.GetElementsByTagName("Id").Item(8).InnerText;
                sendingBankRoutingNo = doc.GetElementsByTagName("Id").Item(2).InnerText;
                receivingBankRoutingNo = doc.GetElementsByTagName("Id").Item(5).InnerText;
                purpose = doc.GetElementsByTagName("Ustrd").Item(0).InnerText;
                DateTime txnDt = DateTime.Now;
                DateTime stlmntDt = DateTime.Now;
                #endregion

                #region data fetched from db for further operation
                var sender = _businessLayer.GetAllBankUsers().SingleOrDefault(m => m.AccountNumber == senderAccNo);

                var senderBank = _businessLayer.GetAllBanks().SingleOrDefault(m => m.SwiftBic == senderBIC);
                #endregion


                //DBManager db = new DBManager(transactionRepository, sendingBankUserRepository, receivingBankUserRepository, bankNetDebitCapRepository, suspenseTransactionRepository, bankRepository);


                //update Sending Bank Net Debit Cap
                var senderInstitutionDebitCap = _businessLayer.GetParticipantDebitCapById(senderBank.Id);
                senderInstitutionDebitCap.CurrentNetDebitCap -= System.Convert.ToDecimal(amount, cultures);
                senderInstitutionDebitCap.EntityState = EntityState.Modified;
                _businessLayer.UpdateParticipantDebitCap(senderInstitutionDebitCap);

                //create suspense transaction
                var suspenseTransaction = new SuspenseTransaction
                {
                    SuspenseTransactionId = Guid.NewGuid(),
                    SenderAccountNo = senderAccNo,
                    SendingBankId = senderBank.Id,
                    SendingBankSuspanseAccount = senderBank.SuspenseAccount,
                    Amount = Convert.ToDecimal(amount, cultures),
                    TransactionInitiatedOn = txnDt,
                    SuspenseClearingTime = DateTime.Now,
                    TransactionId = txnId,
                    SuspenseStatus = false,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddSuspenseTransaction(suspenseTransaction);

                TransactionRequestLog transactionRequestLog = new TransactionRequestLog();
                List<TransactionRequestLog> logs = new List<TransactionRequestLog>();

                var responseResult = string.Empty;
                var responseResultFromBB = string.Empty;
                var responseDesco = string.Empty;
                using (var client = new HttpClient())
                {
                    transactionRequestLog.TransactionId = txnId;
                    transactionRequestLog.RequestFrom = "IDTP";
                    transactionRequestLog.RequestTo = "Desco";
                    transactionRequestLog.RequestMessage = xmlData;
                    transactionRequestLog.RequestTime = DateTime.Now;
                    transactionRequestLog.CreatedBy = "IDTP";
                    transactionRequestLog.CreatedOn = DateTime.Now;
                    transactionRequestLog.ModifiedBy = "IDTP";
                    transactionRequestLog.ModifiedOn = DateTime.Now;
                    transactionRequestLog.EntityState = EntityState.Added;
                    //_businessLayer.AddTransactionRequestLog(transactionRequestLog);
                    logs.Add(transactionRequestLog);

                    TransactionBillDTO tbd = new TransactionBillDTO
                    {
                        TransactionId = txnId,
                        SenderAccNo = senderAccNo,
                        SenderBankId = senderBank.Id,
                        Amount = decimal.Parse(amount, cultures)
                    };


                    //receiver bank call
                    //responseResult = HttpClientHelper.Post("https://localhost:44326/BillPayment/BillPayment", tbd.ToString());
                    //var uri = "https://localhost:44326/BillPayment/BillPayment";
                    var uri = "https://idtp-desco-api.azurewebsites.net/BillPayment/BillPayment";
                    var task = client.PostAsJsonAsync<TransactionBillDTO>(uri, tbd);
                    task.Wait();
                    responseDesco = task.Result.Content.ReadAsStringAsync().Result;

                }

                //create transactionbill
                var newTransactionBill = new TransactionBill
                {
                    SenderId = sender.Id,
                    ReceiverName = "DESCO",
                    Amount = System.Convert.ToDecimal(amount, cultures),
                    //newTransactionBill.Narration = purpose;
                    SenderBankId = senderBank.Id,
                    BillReferenceId = responseDesco,
                    SendingBankRoutingNo = sendingBankRoutingNo,

                    TransactionId = txnId,
                    TransactionDate = txnDt,
                    CreatedBy = senderBank.FinancialInstitution.InstitutionName,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddTransactionBill(newTransactionBill);

                //create a transactionfund entity
                var newTransactionFund = new TransactionFund
                {
                    SenderId = sender.Id,
                    ReceiverId = 4,
                    Amount = System.Convert.ToDecimal(amount, cultures),
                    Narration = purpose,
                    SenderBankId = senderBank.Id,
                    ReceiverBankId = senderBank.Id,
                    SendingBankRoutingNo = sendingBankRoutingNo,
                    ReceivingBankRoutingNo = sendingBankRoutingNo,
                    TransactionId = txnId,
                    TransactionDate = txnDt,
                    CreatedBy = senderBank.FinancialInstitution.InstitutionName,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddTransaction(newTransactionFund);


                //update suspense transaction record            
                suspenseTransaction.SuspenseStatus = true;
                //suspenseTransaction.Amount = 0;
                suspenseTransaction.EntityState = EntityState.Modified;
                _businessLayer.UpdateSuspenseTransaction(suspenseTransaction);

                //ISOComposer composer = new ISOComposer();

                //var pacs002xml = composer.GetDataForPacs002Single(senderBIC, receiverBIC, sender.AccountName, senderBank.FinancialInstitution.InstitutionName , txnId, amount);
                var pacs002xml = ISOComposer.GetDataForPacs002Single(senderBIC, txnId, amount, "pacs.008.001.04");
                XDocument doc02 = new XDocument(pacs002xml);
                string xmlReturn = pacs002xml.OuterXml.Replace(@"\", "", StringComparison.CurrentCulture);
                TransactionRequestLog transactionRequestLogReceive = new TransactionRequestLog
                {
                    TransactionId = txnId,
                    RequestFrom = "Desco",
                    RequestTo = "IDTP",
                    RequestMessage = xmlReturn,
                    RequestTime = DateTime.Now,
                    CreatedBy = "IDTP",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedBy = "IDTP",
                    EntityState = EntityState.Added
                };
                //_businessLayer.AddTransactionRequestLog(transactionRequestLogReceive);
                logs.Add(transactionRequestLogReceive);
                _businessLayer.AddTransactionRequestLog(logs.ToArray());
                return xmlReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }


}

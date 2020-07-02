using IDTP.Utility;
using IDTPApiService.Helper;
using IDTPBusinessLayer;
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

namespace IDTPApiService.Controllers
{
    /**
    * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
    * Invocation:          No need of invocation. Auto triggered when FCM message is received.
    * Implementation Flow:
    *                      a. Do a fund transfer transaction as per the provided PACS.008 XML.
    */

    [Route("[controller]")]
    [ApiController]
    public class TransferFundController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public TransferFundController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Do a fund transfer transaction as per the provided PACS.008 XML
        /// </summary>
        /// <returns>Returns a PACS.002 XML</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns a defined XML error message on Internal Server Error </returns>
        [HttpPost("/TransferFund", Name = "TransferFund")]
        [Authorize(Roles = IDTPRoleNames.FinancialInstitute)]
        public string TransferFund([FromBody] string xmlData)
        {
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");

            var responseResult = string.Empty;
            try
            {
                var isSameBank = false;
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
                var receiver = _businessLayer.GetAllBankUsers().SingleOrDefault(m => m.AccountNumber == receiverAccNo);
                var senderBank = _businessLayer.GetAllBanks().SingleOrDefault(m => m.SwiftBic == senderBIC);
                var receiverBank = _businessLayer.GetAllBanks().SingleOrDefault(m => m.SwiftBic == receiverBIC);
                #endregion
                if (senderBank.Id == receiverBank.Id)
                {
                    isSameBank = true;
                }

                //DBManager db = new DBManager(transactionRepository, sendingBankUserRepository, receivingBankUserRepository, bankNetDebitCapRepository, suspenseTransactionRepository, bankRepository);


                //update Sending Bank Net Debit Cap
                var senderInstitutionDebitCap = _businessLayer.GetParticipantDebitCapById(senderBank.Id);
                senderInstitutionDebitCap.CurrentNetDebitCap -= System.Convert.ToDecimal(amount, cultures);
                senderInstitutionDebitCap.EntityState = EntityState.Modified;
                _businessLayer.UpdateParticipantDebitCap(senderInstitutionDebitCap);

                //create suspense transaction
                var suspenseTransaction = new SuspenseTransaction
                {
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
                TransactionRequestLog transactionRequestLogReceive = new TransactionRequestLog();
                List<TransactionRequestLog> logs = new List<TransactionRequestLog>();
                var responseResultFromBB = string.Empty;
                using (var client = new HttpClient())
                {
                    transactionRequestLog.RequestFrom = "IDTP";
                    transactionRequestLog.RequestTo = receiverBank.FinancialInstitution.InstitutionName;
                    transactionRequestLog.RequestMessage = xmlData;
                    transactionRequestLog.RequestTime = DateTime.Now;
                    transactionRequestLog.CreatedBy = receiverBank.FinancialInstitution.InstitutionName;
                    transactionRequestLog.CreatedOn = DateTime.Now;
                    transactionRequestLog.ModifiedBy = receiverBank.FinancialInstitution.InstitutionName;
                    transactionRequestLog.ModifiedOn = DateTime.Now;
                    transactionRequestLog.EntityState = EntityState.Added;
                    logs.Add(transactionRequestLog);

                    //receiver bank call
                    //responseResult = HttpClientHelper.Post(new Uri("https://localhost:44372/api/Receiver"), xmlData);
                    responseResult = HttpClientHelper.Post(new Uri("https://idtp-external-receiver.azurewebsites.net/api/Receiver"), xmlData);

                    transactionRequestLogReceive.RequestFrom = receiverBank.FinancialInstitution.InstitutionName;
                    transactionRequestLogReceive.RequestTo = "IDTP";
                    transactionRequestLogReceive.RequestMessage = responseResult;
                    transactionRequestLogReceive.RequestTime = DateTime.Now;
                    transactionRequestLogReceive.CreatedBy = "IDTP";
                    transactionRequestLogReceive.CreatedOn = DateTime.Now;
                    transactionRequestLogReceive.ModifiedBy = "IDTP";
                    transactionRequestLogReceive.ModifiedOn = DateTime.Now;
                    transactionRequestLogReceive.EntityState = EntityState.Added;
                    logs.Add(transactionRequestLogReceive);
                    _businessLayer.AddTransactionRequestLog(logs.ToArray());
                }

                //create transaction
                var newTransactionFund = new TransactionFund
                {
                    SenderId = sender.Id,
                    ReceiverId = receiver.Id,
                    Amount = System.Convert.ToDecimal(amount, cultures),
                    Narration = purpose,
                    SenderBankId = senderBank.Id,
                    ReceiverBankId = receiverBank.Id,
                    SendingBankRoutingNo = sendingBankRoutingNo,
                    ReceivingBankRoutingNo = receivingBankRoutingNo,
                    TransactionId = txnId,
                    TransactionDate = txnDt,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddTransaction(newTransactionFund);

                //update receiver bank net debit cap
                if (isSameBank)
                {
                    senderInstitutionDebitCap.CurrentNetDebitCap += System.Convert.ToDecimal(amount, cultures);
                    senderInstitutionDebitCap.EntityState = EntityState.Modified;
                    _businessLayer.UpdateParticipantDebitCap(senderInstitutionDebitCap);
                }
                else
                {
                    var receiverInstitutionDebitCap = _businessLayer.GetParticipantDebitCapById(receiverBank.Id);
                    receiverInstitutionDebitCap.CurrentNetDebitCap += System.Convert.ToDecimal(amount, cultures);
                    receiverInstitutionDebitCap.EntityState = EntityState.Modified;
                    _businessLayer.UpdateParticipantDebitCap(receiverInstitutionDebitCap);

                }

                //update suspense transaction record            
                suspenseTransaction.SuspenseStatus = true;
                suspenseTransaction.Amount = 0;
                suspenseTransaction.EntityState = EntityState.Modified;
                _businessLayer.UpdateSuspenseTransaction(suspenseTransaction);

                return responseResult;
            }
            catch (Exception)
            {
                responseResult = IDTPXmlParser.PrepareFailResponse("TransferFund");
                return responseResult;
            }
        }


    }
}

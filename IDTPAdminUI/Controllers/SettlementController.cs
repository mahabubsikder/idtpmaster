using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IDTPDataTransferObjects;
using System.Net;
using IDTPDomainModel.Models;
using IDTPBusinessLayer;
using IDTPDomainModel;
using System.Xml;
using System.Globalization;
using Microsoft.Data.SqlClient;
using IDTPAdminUI.Models;
using IDTP.Utility;
using Microsoft.AspNetCore.Authorization;
/**
 * Description:         This controller class is responsible for handling the settlement view and functions
 * 
 */
namespace IDTPDemoUI.Controllers
{
    public class SettlementController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public SettlementController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Shows the dashboard for settlement
        /// </summary>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// Shows the list of settlement balance of participants
        /// </summary>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult List()
        {
            var list = new List<SettlementDTO>();

            try
            {

              list =
              (from n in _businessLayer.GetAllBBSettlements()
               select new SettlementDTO
               {
                   Id = n.Id,
                   SwiftBic = n.Bank.SwiftBic,
                   BankName = n.Bank.FinancialInstitution.InstitutionName,
                   Balance = n.Balance,
                   ModifiedOn = n.ModifiedOn.Value

               }).ToList();
                /*var client = new HttpClient();
                client = HttpClientAuthorization.AuthorizeClient(client);

                Uri uri = new Uri(Constants.apiGatewayurlSendMoney + "GetAllSettlements");
                var response = client.GetAsync(uri);
               
                if (response.Result.IsSuccessStatusCode) {
                    list = response.Result.Content.ReadAsAsync<List<SettlementDTO>>().Result;
                }
                client.Dispose();*/
            }
            catch (WebException)
            {

            }
            return View(list);

        }
        /// <summary>
        /// Shows the list of all transactions of current date
        /// </summary>

        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult TransactionList()
        {
            var today = DateTime.Today;
            List<TransactionFund> transactions = _businessLayer.GetAllTransactions()
                .Where(x => x.TransactionDate >= DateTime.Today).OrderByDescending(m => m.TransactionDate).ToList();
            List<TransactionViewModel> trans = new List<TransactionViewModel>();
            foreach (TransactionFund tfd in transactions)
            {
                TransactionViewModel tvm = new TransactionViewModel
                {
                    TransactionId = tfd.TransactionId,
                    SenderName = _businessLayer.GetAllBankUsers().Where(x => x.Id == tfd.SenderId).FirstOrDefault().AccountName,
                    ReceiverName = _businessLayer.GetAllBankUsers().Where(x => x.Id == tfd.ReceiverId).FirstOrDefault().AccountName,
                    SenderAccountNo = _businessLayer.GetAllBankUsers().Where(x => x.Id == tfd.SenderId).FirstOrDefault().AccountNumber,
                    ReceiverAccountNo = _businessLayer.GetAllBankUsers().Where(x => x.Id == tfd.ReceiverId).FirstOrDefault().AccountNumber,
                    SenderBankName = _businessLayer.GetAllBanks().Where(x => x.Id == tfd.SenderBankId).FirstOrDefault().FinancialInstitution.InstitutionName,
                    ReceiverBankName = _businessLayer.GetAllBanks().Where(x => x.Id == tfd.ReceiverBankId).FirstOrDefault().FinancialInstitution.InstitutionName
                };

                tvm.SettlementStatus = tfd.SettlementStatus ? "Yes" : "No";
                tvm.Amount = (decimal)tfd.Amount;
                tvm.TransactionDate = tfd.TransactionDate.GetValueOrDefault();
                trans.Add(tvm);

            }
            trans.Reverse();
            return View(trans);
        }
        #region transaction-based-settlement
        //public IActionResult Settlement() {
        //    var transaction = new TransactionFund();
        //    //transaction = _businessLayer.GetAllTransactions().FirstOrDefault();
        //    transaction = _businessLayer.GetAllTransactions().OrderByDescending(p => p.TransactionDate).FirstOrDefault();
        //    var senderBank = _businessLayer.GetAllBanks().Where(x => x.Id == transaction.SenderBankId).FirstOrDefault();
        //    var receiverBank = _businessLayer.GetAllBanks().Where(x => x.Id == transaction.ReceiverBankId).FirstOrDefault();
        //    var sendingBankCbaAcc = senderBank.CbaccountNo;
        //    var receivingBankCbaAcc = receiverBank.CbaccountNo;
        //    var sendingBankSwiftBic = senderBank.SwiftBic;
        //    var receiverBankSwiftBic = receiverBank.SwiftBic;
        //    var senderFin = _businessLayer.GetAllParticipantDebitCaps().Where(x => x.Id == transaction.SenderBankId).FirstOrDefault();
        //    var receiverFin = _businessLayer.GetAllParticipantDebitCaps().Where(x => x.Id == transaction.ReceiverBankId).FirstOrDefault();
        //    var amountBankFirst = senderFin.NetDebitCap;
        //    var amountBankSecond = receiverFin.NetDebitCap;
        //    //var sendingBankCbaAcc = transaction.SenderBank.CbaccountNo;
        //    //var receivingBankCbaAcc = transaction.ReceiverBank.CbaccountNo;
        //    TransactionRequestLog transactionRequestLog = new TransactionRequestLog();
        //    TransactionRequestLog transactionRequestLogReceive = new TransactionRequestLog();
        //    TransactionRequestLog transactionRequestLog2 = new TransactionRequestLog();
        //    TransactionRequestLog transactionRequestLogReceive2 = new TransactionRequestLog();

        //    var responseResultFromBB = string.Empty;
        //    var composer = new ISOComposer();
        //    //get PACS009 xml 
        //    var pacs009xml = composer.GetDataForPacs009Single(sendingBankSwiftBic, receiverBankSwiftBic, transaction.TransactionId.ToString(),
        //         amountBankFirst.ToString(), transaction.SendingBankRoutingNo, sendingBankCbaAcc, transaction.ReceivingBankRoutingNo, receivingBankCbaAcc, transaction.Narration);

        //    using (var client = new HttpClient())
        //    {
        //        transactionRequestLog.RequestFrom = "IDTP";
        //        transactionRequestLog.RequestTo = "Bangladesh Bank";
        //        transactionRequestLog.RequestMessage = pacs009xml.InnerXml;
        //        transactionRequestLog.RequestTime = DateTime.Now;
        //        transactionRequestLog.EntityState = EntityState.Added;
        //        _businessLayer.AddTransactionRequestLog(transactionRequestLog);

        //        responseResultFromBB = HttpClientHelper.Post("https://localhost:44305/api/Settlement", pacs009xml.InnerXml);

        //        transactionRequestLogReceive.RequestFrom = "Bangladesh Bank";
        //        transactionRequestLogReceive.RequestTo = "IDTP";
        //        transactionRequestLogReceive.RequestMessage = responseResultFromBB;
        //        transactionRequestLogReceive.RequestTime = DateTime.Now;
        //        transactionRequestLogReceive.EntityState = EntityState.Added;
        //        _businessLayer.AddTransactionRequestLog(transactionRequestLogReceive);

        //        responseResultFromBB = responseResultFromBB.Replace("\\", "");
        //        responseResultFromBB = responseResultFromBB.Substring(1, responseResultFromBB.Length - 2);
        //    }
        //    pacs009xml = composer.GetDataForPacs009Single(receiverBankSwiftBic, sendingBankSwiftBic, transaction.TransactionId.ToString(),
        //     amountBankSecond.ToString(), transaction.SendingBankRoutingNo, sendingBankCbaAcc, transaction.ReceivingBankRoutingNo, receivingBankCbaAcc, transaction.Narration);

        //    using (var client = new HttpClient())
        //    {
        //        transactionRequestLog2.RequestFrom = "IDTP";
        //        transactionRequestLog2.RequestTo = "Bangladesh Bank";
        //        transactionRequestLog2.RequestMessage = pacs009xml.InnerXml;
        //        transactionRequestLog2.RequestTime = DateTime.Now;
        //        transactionRequestLog2.EntityState = EntityState.Added;
        //        _businessLayer.AddTransactionRequestLog(transactionRequestLog2);

        //        responseResultFromBB = HttpClientHelper.Post("https://localhost:44305/api/Settlement", pacs009xml.InnerXml);

        //        transactionRequestLogReceive2.RequestFrom = "Bangladesh Bank";
        //        transactionRequestLogReceive2.RequestTo = "IDTP";
        //        transactionRequestLogReceive2.RequestMessage = responseResultFromBB;
        //        transactionRequestLogReceive2.RequestTime = DateTime.Now;
        //        transactionRequestLogReceive2.EntityState = EntityState.Added;
        //        _businessLayer.AddTransactionRequestLog(transactionRequestLogReceive2);

        //        responseResultFromBB = responseResultFromBB.Replace("\\", "");
        //        responseResultFromBB = responseResultFromBB.Substring(1, responseResultFromBB.Length - 2);
        //    }
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(responseResultFromBB);
        //    TempData["TxSts"] = doc.GetElementsByTagName("TxSts").Item(0).InnerText;
        //    return View(nameof(Index));
        //}
        #endregion
        /// <summary>
        /// Metchod to initialize settlement with Bangladesh Bank, sending PACS009 Msg and Getting PACS002 Msg in return
        /// </summary>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult Settlement()
        {
            //Uri bbUri = new Uri("https://localhost:44305/api/Settlement");
            Uri bbUri = new Uri("http://idtp-bangladeshbank-api.azurewebsites.net/api/Settlement");
            List<TransactionRequestLog> logs = new List<TransactionRequestLog>();
            List<ParticipantDebitCap> participants = new List<ParticipantDebitCap>();
            var participantList = _businessLayer.GetAllParticipantDebitCaps().Where(x => x.SettlementStatus == false).ToList();
            if (participantList.Count == 0)
            {
                TempData["TxSts"] = "Null";
                return RedirectToAction("Index", "Settlement");
            }
            else
            {
                var responseResultFromBB = string.Empty;
                foreach (ParticipantDebitCap p in participantList)
                {
                    TransactionRequestLog transactionRequestLog = new TransactionRequestLog();
                    TransactionRequestLog transactionRequestLogReceive = new TransactionRequestLog();
                    var bank = _businessLayer.GetBankById(p.Id);
                    var sendingBankSwiftBic = bank.SwiftBic;
                    var sendingBankCbaAcc = bank.CbaccountNo;
                    var receiverBankSwiftBic = "";
                    var transactionId = "";
                    var receivingBankCbaAcc = "";
                    var SendingBankRoutingNo = "";
                    var ReceivingBankRoutingNo = "";
                    var narration = "Settlement";
                    string amount = Convert.ToString(p.CurrentNetDebitCap, new CultureInfo("en-US"));
                    //var composer = new ISOComposer();
                    var pacs009xml = ISOComposer.GetDataForPacs009Single(sendingBankSwiftBic, receiverBankSwiftBic, transactionId,
                         amount, SendingBankRoutingNo, sendingBankCbaAcc, ReceivingBankRoutingNo, receivingBankCbaAcc, narration);

                    transactionRequestLog.RequestFrom = "IDTP";
                    transactionRequestLog.RequestTo = "Bangladesh Bank";
                    transactionRequestLog.RequestMessage = pacs009xml.InnerXml;
                    transactionRequestLog.RequestTime = DateTime.Now;
                    transactionRequestLog.EntityState = IDTPDomainModel.EntityState.Added;
                    logs.Add(transactionRequestLog);
                    responseResultFromBB = HttpClientHelper.Post(bbUri , pacs009xml.InnerXml);
                    p.SettlementStatus = true;
                    p.EntityState = IDTPDomainModel.EntityState.Modified;
                    _businessLayer.UpdateParticipantDebitCap(p);
                    transactionRequestLogReceive.RequestFrom = "Bangladesh Bank";
                    transactionRequestLogReceive.RequestTo = "IDTP";
                    transactionRequestLogReceive.RequestMessage = responseResultFromBB;
                    transactionRequestLogReceive.RequestTime = DateTime.Now;
                    transactionRequestLogReceive.EntityState = IDTPDomainModel.EntityState.Added;
                    logs.Add(transactionRequestLogReceive);

                }
                _businessLayer.AddTransactionRequestLog(logs.ToArray());
                XmlDocument doc = new XmlDocument();
                DayEndTasks();
                responseResultFromBB = responseResultFromBB.Replace("\\", "", StringComparison.CurrentCulture);
                responseResultFromBB = responseResultFromBB[1..^1];
                doc.LoadXml(responseResultFromBB);

                TempData["TxSts"] = doc.GetElementsByTagName("TxSts").Item(0).InnerText;
                //return View(nameof(Index));
                return RedirectToAction("Index", "Settlement");
            }

        }
        /// <summary>
        /// Method to execute day-end methods like TruncateSuspenseTransaction,UpdateTransactions
        /// </summary>

        public void DayEndTasks()
        {

            string joinCommand = @"INSERT INTO [dbo].[SuspenseTransactionHistories]
                                (SuspenseTransactionId, SuspenseStatus, Amount, SenderAccountNo, SendingBankId, SendingBankSuspanseAccount, TransactionId, TransactionInitiatedOn, SuspenseClearingTime, EntityState)
                                SELECT
                                SuspenseTransactionId, SuspenseStatus, Amount, SenderAccountNo, SendingBankId, SendingBankSuspanseAccount, TransactionId, TransactionInitiatedOn, SuspenseClearingTime,1
                                FROM[dbo].[SuspenseTransaction]";
            string truncateCommand = "Truncate table [dbo].[SuspenseTransaction]";
            string settledTime = DateTime.Now.ToString();
            string transactionStatusUpdateQuery = @"Update [dbo].[TransactionFund] Set SettlementStatus = 1, SettledOn = '" + settledTime + "' Where cast(TransactionDate as date) = '" + DateTime.Today.ToString("MM/dd/yyyy", new CultureInfo("bn-BD")) + "'";
            try
            {
                UpdateSuspenseTransactionHistory(joinCommand);
                TruncateSuspenseTransactions(truncateCommand);
                UpdateTransactionStatus(transactionStatusUpdateQuery);
            }
            catch (SqlException)
            {
                throw;
            }

        }
        /// <summary>
        /// Truncates the suspenseTransaction table from db
        /// </summary>
        public void TruncateSuspenseTransactions(string command)
        {
            _businessLayer.RunRawSqlCommand(command);
        }
        /// <summary>
        /// Copies current date's suspenseTransaction data to suspenseTransactionHistory table
        /// </summary>
        public void UpdateSuspenseTransactionHistory(string command)
        {
            _businessLayer.RunRawSqlCommand(command);
        }
        /// <summary>
        /// Update transactions' settlement status and settlement dates
        /// </summary>
        public void UpdateTransactionStatus(string command)
        {
            _businessLayer.RunRawSqlCommand(command);
        }

    }
}
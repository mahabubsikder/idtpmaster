using IDTP.Utility;
using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenderUI.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Constants = SenderUI.Helper.Constants;

namespace SenderUI.Controllers
{
    public class TransferFundController : Controller
    {
        //private readonly ISendingBankUserRepository sendingBankUserRepository;
        //private readonly IReceivingBankUserRepository receivingBankUserRepository;
        //private readonly IBankRepository bankRepository;
        //private readonly IBranchRepository branchRepository;
        private readonly IBusinessLayer _businessLayer;
        //public TransferFundController(ISendingBankUserRepository sendingBankUserRepository, IBankRepository bankRepository, IReceivingBankUserRepository receivingBankUserRepository, IBranchRepository branchRepository)
        //{
        //    this.sendingBankUserRepository = sendingBankUserRepository;
        //    this.receivingBankUserRepository = receivingBankUserRepository;
        //    this.bankRepository = bankRepository;
        //    this.branchRepository = branchRepository;
        //}
        public TransferFundController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        // GET: TransferFund
        public ActionResult Index()
        {
            return View();
        }


        // GET: TransferFund/Create
        //public ActionResult Create()
        //{
        //    ViewBag.listBank = bankRepository.GetAllBanks().ToList();
        //    ViewBag.listSenderBranch = branchRepository.GetAllBranch().Where(m=>m.BankId == 1).ToList();
        //    ViewBag.listReceiverBranch = branchRepository.GetAllBranch().Where(m => m.BankId == 2).ToList();
        //    return View();
        //}

        /// <summary>
        /// Returns the view of fund transfer
        /// </summary>
        /// <returns></returns>

        public ActionResult Create()
        {
            List<Bank> listBank = _businessLayer.GetAllBanks().ToList();
            List<BankDTO> list = new List<BankDTO>();

            foreach (Bank b in listBank)
            {
                BankDTO bankDTO = new BankDTO
                {
                    Id = b.Id,
                    Name = b.FinancialInstitution.InstitutionName,
                    SwiftBic = b.SwiftBic,
                    SuspenseAccount = b.SuspenseAccount,
                    CbaccountNo = b.CbaccountNo
                };
                list.Add(bankDTO);
            }
            ViewBag.banklist = list;
            return View();
        }

        // POST: TransferFund/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(TransferFund transferFund)
        //{
        //    try
        //    {
        //        #region Data Fetched from DB
        //        var listBank = bankRepository.GetAllBanks();
        //        var sender = sendingBankUserRepository.GetAllSendingBankUser().Where(m => m.AccountNumber == transferFund.SenderAccNo).FirstOrDefault();
        //        var receiver = receivingBankUserRepository.GetAllReceivingBankUser().Where(m => m.AccountNumber == transferFund.ReceiverAccNo).FirstOrDefault();
        //        var SenderBank = listBank.Where(m => m.Id == transferFund.SenderBankId).FirstOrDefault();
        //        var ReceiverBank = listBank.Where(m => m.Id == transferFund.ReceiverBankId).FirstOrDefault();
        //        var senderBankRoutingNo = SenderBank.Branch.SingleOrDefault(m=>m.Id == transferFund.SenderBranchId).RoutingNumber;
        //        var receiverBankRoutingNo = ReceiverBank.Branch.SingleOrDefault(m => m.Id == transferFund.ReceiverBranchId).RoutingNumber;
        //        #endregion

        //        var transactionId = SenderBank.SwiftBic.Substring(0, 4) + DateTime.Now.ToString("yyyyMMddHHmmss");

        //        ISOComposer composer = new ISOComposer();
        //        var pacs008xml = composer.GetPacs008Data(SenderBank.SwiftBic, ReceiverBank.SwiftBic, sender.AccountName, receiver.AccountName, transactionId, transferFund.SenderAccNo,
        //             senderBankRoutingNo, SenderBank.CbaccountNo, receiverBankRoutingNo, ReceiverBank.CbaccountNo, transferFund.ReceiverAccNo, transferFund.Amount.ToString(), transferFund.Purpose);

        //        #region DB Operation for Sending Bank User
        //        sender.Balance = sender.Balance - transferFund.Amount;
        //        sendingBankUserRepository.UpdateSendingBankUser(sender);
        //        sendingBankUserRepository.Save();
        //        #endregion

        //        var responseResult = string.Empty;
        //        using (var client = new HttpClient())
        //        {
        //           //calling to IDTP API
        //            responseResult = HttpClientHelper.Post("https://localhost:44358/api/Transfer", pacs008xml.InnerXml);
        //        }
        //        responseResult = responseResult.Replace("\\", "");
        //        responseResult = responseResult.Substring(2, responseResult.Length - 4);
        //        XmlDocument doc = new XmlDocument();
        //        doc.LoadXml(responseResult);
        //        TempData["txnId"] = doc.GetElementsByTagName("OrgnlTxId").Item(0).InnerText;
        //        return RedirectToAction(nameof(Create));
        //    }
        //    catch(Exception ex)
        //    {
        //        return RedirectToAction(nameof(Create));
        //    }
        //}
        /// <summary>
        /// Method to execute a fund transfer
        /// Sends PACS008 to IDTP, IDTP forwards request to Receiving Bank
        /// Receiving Bank Returns PACS002, IDTP forwards to Sending Bank
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]TransactionFundDTO tfd)
        {
            try
            {
                if (tfd != null)
                {

                    #region fetch data db
                    var sender = _businessLayer.GetAllBankUsers().Where(u => u.AccountNumber == tfd.SenderAccNo).FirstOrDefault();
                    var receiver = _businessLayer.GetAllBankUsers().Where(u => u.AccountNumber == tfd.ReceiverAccNo).FirstOrDefault();
                    if (sender == null || receiver == null)
                    {
                        TempData["errormsg"] = "Please provide correct Account Number";
                        return RedirectToAction(nameof(Create));
                    }
                    var SenderBank = _businessLayer.GetAllBanks().Where(b => b.Id == tfd.SenderBankId).FirstOrDefault();
                    var ReceiverBank = _businessLayer.GetAllBanks().Where(b => b.Id == tfd.ReceiverBankId).FirstOrDefault();
                    var senderBranch = _businessLayer.GetAllBranchs().Where(br => br.Id == tfd.SenderBranchId).FirstOrDefault();
                    var receiverBranch = _businessLayer.GetAllBranchs().Where(br => br.Id == tfd.ReceiverBranchId).FirstOrDefault();
                    #endregion
                    var senderBankRoutingNo = senderBranch.RoutingNumber;
                    var receiverBankRoutingNo = receiverBranch.RoutingNumber;
                    var transactionId = SenderBank.SwiftBic.Substring(0, 4) + DateTime.Now.ToString("yyyyMMddHHmmss", new CultureInfo("bn-BD"));

                    #region create pacs008 xml
                    //ISOComposer composer = new ISOComposer();
                    var pacs008xml = ISOComposer.GetPacs008Data(SenderBank.SwiftBic, ReceiverBank.SwiftBic, sender.AccountName, receiver.AccountName, transactionId, tfd.SenderAccNo,
                         senderBankRoutingNo, SenderBank.CbaccountNo, receiverBankRoutingNo, ReceiverBank.CbaccountNo, tfd.ReceiverAccNo, tfd.Amount.ToString(), tfd.Purpose);
                    #endregion                    

                    #region fetch data db
                    sender.Balance -= tfd.Amount;
                    sender.EntityState = EntityState.Modified;
                    _businessLayer.UpdateBankUser(sender);
                    #endregion
                    TransactionRequestLog transactionRequestLog = new TransactionRequestLog();
                    TransactionRequestLog transactionRequestLogReceive = new TransactionRequestLog();
                    List<TransactionRequestLog> logs = new List<TransactionRequestLog>();
                    var responseResult = string.Empty;
                    //var api = "https://idtp-api-service."
                    #region get token for session
                    //login as user
                    LoginDTO loginDTO = new LoginDTO
                    {
                        UserName = Helper.Constants.UserName,
                        MasterToken = Helper.Constants.UserSecret
                    };
                    //get token
                    string token = await HttpClientAuthorization.GetAuthorizationToken(loginDTO);
                    HttpContext.Session.SetString("token", token);
                    #endregion
                    //var uri = new Uri("https://localhost:44321/TransferFund");
                    var uri = new Uri(Constants.IDTPApiGatewayUrl + "ft/TransferFund");
                    using (var client = new HttpClient())
                    {
                        transactionRequestLog.TransactionId = transactionId;
                        transactionRequestLog.RequestFrom = SenderBank.FinancialInstitution.InstitutionName;
                        transactionRequestLog.RequestTo = "IDTP";
                        transactionRequestLog.RequestMessage = pacs008xml.InnerXml;
                        transactionRequestLog.RequestTime = DateTime.Now;
                        transactionRequestLog.EntityState = EntityState.Added;
                        transactionRequestLog.CreatedBy = SenderBank.FinancialInstitution.InstitutionName;
                        transactionRequestLog.CreatedOn = DateTime.Now;
                        transactionRequestLog.ModifiedBy = SenderBank.FinancialInstitution.InstitutionName;
                        transactionRequestLog.ModifiedOn = DateTime.Now;
                        logs.Add(transactionRequestLog);

                        //calling to IDTP API

                        responseResult = HttpClientHelper.Post(uri, pacs008xml.InnerXml, token);
                        responseResult = responseResult.Replace("\\", "", StringComparison.CurrentCulture);
                        responseResult = responseResult[1..^1];
                        transactionRequestLogReceive.TransactionId = transactionId;
                        transactionRequestLogReceive.RequestFrom = "IDTP";
                        transactionRequestLogReceive.RequestTo = SenderBank.FinancialInstitution.InstitutionName;
                        transactionRequestLogReceive.RequestMessage = responseResult;
                        transactionRequestLogReceive.RequestTime = DateTime.Now;
                        transactionRequestLogReceive.EntityState = EntityState.Added;
                        transactionRequestLogReceive.CreatedBy = "IDTP";
                        transactionRequestLogReceive.CreatedOn = DateTime.Now;
                        transactionRequestLogReceive.ModifiedBy = "IDTP";
                        transactionRequestLogReceive.ModifiedOn = DateTime.Now;
                        logs.Add(transactionRequestLogReceive);
                    }

                    _businessLayer.AddTransactionRequestLog(logs.ToArray());
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseResult);
                    TempData["txnId"] = doc.GetElementsByTagName("OrgnlTxId").Item(0).InnerText;

                    return RedirectToAction(nameof(Create));
                }
                else
                {
                    return RedirectToAction(nameof(Create));
                }
            }
            catch(Exception ex)
            {
                TempData["errormsgAPI"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }
        public List<Branch> GetBranches(string id)
        {
            //int Id = Int32.Parse(id, new CultureInfo("en-US"));
            List<Branch> branches = _businessLayer.GetAllBranchs().Where(x => x.BankId == id).ToList();
            return branches;
        }

    }
}
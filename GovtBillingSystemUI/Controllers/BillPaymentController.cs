using GovtBillingSystemUI.Helper;
using IDTP.Utility;
using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace GovtBillingSystemUI.Controllers
{
    public class BillPaymentController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public BillPaymentController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        /// <summary>
        /// Returns View For Bill Payment 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index()
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

        /// <summary>
        /// Post method for initiating a bill payment to Desco
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] TransactionBillDTO tbd)
        {
            // creating object of CultureInfo 
            try
            {
                CultureInfo cultures = new CultureInfo("en-US");

                if (tbd != null)
                {
                    #region fetch data db
                    var sender = _businessLayer.GetAllBankUsers().Where(u => u.AccountNumber == tbd.SenderAccNo).FirstOrDefault();
                    if (sender ==null)
                    {
                        TempData["error"] = "User Not Found";
                        return RedirectToAction(nameof(Index));
                    }
                    var SenderBank = _businessLayer.GetAllBanks().Where(b => b.Id == tbd.SenderBankId).FirstOrDefault();
                    var senderBranch = _businessLayer.GetAllBranchs().Where(br => br.Id == tbd.SenderBranchId).FirstOrDefault();
                    #endregion
                    var senderBankRoutingNo = senderBranch.RoutingNumber;
                    //var receiverBankRoutingNo = receiverBranch.RoutingNumber;
                    var transactionId = SenderBank.SwiftBic.Substring(0, 4) + DateTime.Now.ToString("yyyyMMddHHmmss", cultures);

                    #region create pacs008 xml
                    //ISOComposer composer = new ISOComposer();
                    var pacs008xml = ISOComposer.GetPacs008Data(SenderBank.SwiftBic, "", sender.AccountName, tbd.ReceiverName, transactionId, tbd.SenderAccNo,
                         senderBankRoutingNo, SenderBank.CbaccountNo, "", "", "", tbd.Amount.ToString(), "Bill Payment");
                    #endregion

                    #region fetch data db
                    sender.Balance -= tbd.Amount;
                    sender.EntityState = EntityState.Modified;
                    _businessLayer.UpdateBankUser(sender);
                    #endregion

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

                    TransactionRequestLog transactionRequestLog = new TransactionRequestLog();
                    TransactionRequestLog transactionRequestLogReceive = new TransactionRequestLog();
                    List<TransactionRequestLog> logs = new List<TransactionRequestLog>();
                    var responseResult = string.Empty;
                    //Uri uri = new Uri("https://localhost:44321/TransactionBill");
                    //var uri = "https://idtp-fundtransfer.azurewebsites.net/TransactionBill";
                    var uri = new Uri(Helper.Constants.IDTPApiGatewayUrl + "ft/TransactionBill");
                    using (var client = new HttpClient())
                    {
                        transactionRequestLog.TransactionId = transactionId;
                        transactionRequestLog.RequestFrom = SenderBank.FinancialInstitution.InstitutionName;
                        transactionRequestLog.RequestTo = "IDTP";
                        transactionRequestLog.RequestMessage = pacs008xml.InnerXml;
                        transactionRequestLog.RequestTime = DateTime.Now;
                        transactionRequestLog.CreatedBy = SenderBank.FinancialInstitution.InstitutionName;
                        transactionRequestLog.CreatedOn = DateTime.Now;
                        transactionRequestLog.ModifiedBy = SenderBank.FinancialInstitution.InstitutionName;
                        transactionRequestLog.ModifiedOn = DateTime.Now;
                        transactionRequestLog.EntityState = EntityState.Added;
                        logs.Add(transactionRequestLog);
                        //_businessLayer.AddTransactionRequestLog(transactionRequestLog);
                        //calling to IDTP API
                        responseResult = HttpClientHelper.Post(uri, pacs008xml.InnerXml, token);


                    }
                    responseResult = responseResult.Replace("\\", "", StringComparison.CurrentCulture);

                    responseResult = responseResult.Substring(1, responseResult.Length - 2);

                    transactionRequestLogReceive.TransactionId = transactionId;
                    transactionRequestLogReceive.RequestFrom = "IDTP";
                    transactionRequestLogReceive.RequestTo = SenderBank.FinancialInstitution.InstitutionName;
                    transactionRequestLogReceive.RequestMessage = responseResult;
                    transactionRequestLogReceive.RequestTime = DateTime.Now;
                    transactionRequestLogReceive.CreatedBy = "IDTP";
                    transactionRequestLogReceive.CreatedOn = DateTime.Now;
                    transactionRequestLogReceive.ModifiedBy = "IDTP";
                    transactionRequestLogReceive.ModifiedOn = DateTime.Now;
                    transactionRequestLogReceive.EntityState = EntityState.Added;
                    logs.Add(transactionRequestLogReceive);
                    _businessLayer.AddTransactionRequestLog(logs.ToArray());
                    //responseResult = "<" + responseResult + ">";
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseResult);
                    TempData["txnId"] = doc.GetElementsByTagName("OrgnlTxId").Item(0).InnerText;
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
        [AllowAnonymous]
        public List<Branch> GetBranches(string id)
        {
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");
            int Id = Int32.Parse(id, cultures);
            List<Branch> branches = _businessLayer.GetAllBranchs().Where(x => x.BankId == id).ToList();
            return branches;
        }
    }

}
using FundTransferUI.Models;
using IDTPBusinessLayer;
using IDTPDomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
/**
 * Description:This controller class is responsible for showing the list of transactions from fund transfer
 * 
 */
namespace SenderUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusinessLayer _businessLayer;
        public HomeController(ILogger<HomeController> logger, IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<TransactionFund> transactions = _businessLayer.GetAllTransactions()
                .Where(x => x.TransactionDate >= DateTime.Today)
                .OrderByDescending(m => m.TransactionDate).ToList();
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
                    ReceiverBankName = _businessLayer.GetAllBanks().Where(x => x.Id == tfd.ReceiverBankId).FirstOrDefault().FinancialInstitution.InstitutionName,
                    Amount = (decimal)tfd.Amount,
                    TransactionDate = tfd.TransactionDate.GetValueOrDefault()
                };

                tvm.SettlementStatus = tfd.SettlementStatus ? "Yes" : "No";
                trans.Add(tvm);

            }

            return View(trans);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

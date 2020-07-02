using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IDTPBusinessLayer;
using IDTPDomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReceiverUI.Models;

namespace ReceiverUI.Controllers
{
    public class ReceiverController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public ReceiverController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        //public IActionResult TransactionList()
        //{
        //    var today = DateTime.Today;
        //    List<TransactionFund> transactions = _businessLayer.GetAllTransactions()
        //        .Where(x => x.TransactionDate >= DateTime.Today).Where(x=>x.ReceiverBankId==5).OrderByDescending(m => m.TransactionDate).ToList();
                
        //    List<TransactionListView> trans = new List<TransactionListView>();

        //    foreach (TransactionFund tfd in transactions)
        //    {
        //        TransactionListView tvm = new TransactionListView
        //        {
        //            SenderName = _businessLayer.GetAllBankUsers().Where(x => x.Id == tfd.SenderId).FirstOrDefault().AccountName,
        //            ReceiverName = _businessLayer.GetAllBankUsers().Where(x => x.Id == tfd.ReceiverId).FirstOrDefault().AccountName,
        //            SenderAccountNo = _businessLayer.GetAllBankUsers().Where(x => x.Id == tfd.SenderId).FirstOrDefault().AccountNumber,
        //            ReceiverAccountNo = _businessLayer.GetAllBankUsers().Where(x => x.Id == tfd.ReceiverId).FirstOrDefault().AccountNumber,
        //            SenderBankName = _businessLayer.GetAllBanks().Where(x => x.Id == tfd.SenderBankId).FirstOrDefault().FinancialInstitution.InstitutionName,
        //            ReceiverBankName = _businessLayer.GetAllBanks().Where(x => x.Id == tfd.ReceiverBankId).FirstOrDefault().FinancialInstitution.InstitutionName,
        //            Amount = (decimal )tfd.Amount
        //        };

        //        tvm.TransactionDate = tfd.TransactionDate.GetValueOrDefault();
        //        trans.Add(tvm);

        //    }
        //    trans.Reverse();
        //    return View(trans);
        //}


        
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDTPAdminUI.Models;
using IDTPBusinessLayer;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IDTPAdminUI.Controllers
{
    
    public class TransactionMonitoringController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IBusinessLayer _businessLayer;
        public TransactionMonitoringController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IBusinessLayer businessLayer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _businessLayer = businessLayer;
        }
        /// <summary>
        /// Gets the current logged in user
        /// </summary>
        /// <returns>ApplicationUser</returns>
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        /// <summary>
        /// Returns the view for TransactionMonitoring
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles ="FinancialInstitute")]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUser();
            var currentBank = _businessLayer.GetAllFinInstitutionInfos()
                .Where(x => x.LoginId == user.UserName)
                .FirstOrDefault();

            var list = _businessLayer.GetAllTransactions()
                .Where(x => x.SenderBankId == currentBank.Id || x.ReceiverBankId == currentBank.Id)
                .Where(x => x.TransactionDate >= DateTime.Today)
                .ToList();

            List<TransactionRequestLog> transRequestLogs = new List<TransactionRequestLog>();
            List<TransactionMonitorViewModel> monitorList = new List<TransactionMonitorViewModel>();
            foreach (var transaction in list)
            {
                var logsPerTrans = _businessLayer.GetAllTransactionRequestLogs()
                    .Where(x => x.TransactionId == transaction.TransactionId)
                    .OrderBy(x => x.RequestTime)
                    .ToList();
                foreach(var singleLog in logsPerTrans)
                {
                    TransactionMonitorViewModel singleMonitorInfo = new TransactionMonitorViewModel
                    {
                        transactionRequestLog = singleLog,
                        Amount = (decimal) transaction.Amount
                    };
                    monitorList.Add(singleMonitorInfo);
                }
            }
            return View(monitorList);
        }
    }
}
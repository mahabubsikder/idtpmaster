
using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace IDTPReportTool.Controllers
{
    /// <summary>
    /// Controls the reports visualization flow
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        private string FilePath;
        private readonly ILogger<HomeController> _logger;
        /*private readonly Dictionary<string, string> reports = new Dictionary<string, string>()
                            {
                                {"Transaction Summary Report", "TransactionSummary"},
                                {"Transaction Details Report", "TransactionDetails"},
                                {"Bill Payment Summary Report", "BillPaymentSummary"},
                                {"Bill Payment Details Report", "BillPaymentDetails" },
                                {"Net Debit Cap Management Report", "NetDebitCap" },
                                {"Dispute Management Details Report", "DisputeDetails"},
                                {"Dispute Management Summary Report", "DisputeSummary"},
                                {"Govt Fund Disbursement Summary Report", "GovtSummary"},
                                {"Govt Fund Disbursement Details Report", "GovtDetails"},
                                {"Salary Disbursement Summary Report", "SalarySummary"},
                                {"Salary Disbursement Details Report", "SalaryDetails"},
                                {"Settlement Status Report (Settled Transactions)", "SettledTransaction"},
                                {"Settlement Status Report (Unsettled Transactions)", "UnsettledTransaction"}
                            };*/
        
        private readonly Dictionary<string, string> reportFiles = new Dictionary<string, string>()
                            {
                                {"Transaction Summary Report", "transactionSummary.frx"},
                                {"Transaction Details Report", "transactionDetails.frx"},
                                {"Bill Payment Summary Report", "billPaymentSummary.frx"},
                                {"Bill Payment Details Report", "billPaymentDetails.frx" },
                                {"Net Debit Cap Management Report", "netDebitCap.frx" },
                                {"Dispute Management Details Report", "disputeDetails.frx"},
                                {"Dispute Management Summary Report", "disputeSummary.frx"},
                                {"Govt Fund Disbursement Summary Report", "govtSummary.frx"},
                                {"Govt Fund Disbursement Details Report", "govtDetails.frx"},
                                {"Salary Disbursement Summary Report", "salarySummary.frx"},
                                {"Salary Disbursement Details Report", "salaryDetails.frx"},
                                {"Settlement Status Report (Settled Transactions)", "settledTransaction.frx"},
                                {"Settlement Status Report (Unsettled Transactions)", "unsettledTransaction.frx"},
                                {"Transaction Report(Sent)", "SentReport.frx"},
                                {"Transaction Report(Received)", "ReceivedReport.frx"},
                                {"Settlement Report", "SettlementReport.frx"},

                            };
        public HomeController(ILogger<HomeController> logger, IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
            _logger = logger;
        }

        /// <summary>
        /// Links the frx file with the report name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            List<string> reportList = new List<string> {
                "Transaction Summary Report",
                "Transaction Details Report",
                "Bill Payment Summary Report",
                "Bill Payment Details Report",
                "Govt Fund Disbursement Summary Report",
                "Govt Fund Disbursement Details Report",
                "Salary Disbursement Summary Report",
                "Salary Disbursement Details Report",
                "Net Debit Cap Management Report",
                "Settlement Status Report (Settled Transactions)",
                "Settlement Status Report (Unsettled Transactions)",
                "Dispute Management Summary Report",
                "Dispute Management Details Report",
                "Transaction Report(Sent)",
                "Transaction Report(Received)",
                "Settlement Report"
            };


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
            ViewBag.reportList = reportList;

            return View();
        }

        /*
        [HttpGet]
        public IActionResult Generate(string id, string FinId=null)
        {
            if (id == "Settlement Position Clearing Report") {
                TempData["FinID"] = "2";
            }
            TempData["FilePath"] = @"Reports\" + reportFiles[id];
            FilePath = @"Reports\" + reportFiles[id];
            return RedirectToAction("Index", "Report");
        }*/
        [HttpPost]
        public IActionResult Generate(string id, string FinId = null)
        {
            if (FinId!=null)
            {
                TempData["ReportTitle"] = id;
                TempData["FinID"] = FinId;
                TempData["FilePath"] = @"Reports\" + reportFiles[id];
                return RedirectToAction("ParameterBasedReport", "Report");
            }
            else
            {
                TempData["FilePath"] = @"Reports\" + reportFiles[id];

                return RedirectToAction("Index", "Report");
            }
        }
    }
}

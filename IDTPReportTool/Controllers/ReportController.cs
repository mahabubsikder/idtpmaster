using ClosedXML.Excel;
using FastReport;
using FastReport.Data;
using FastReport.Export.Image;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using FastReport.Web;
using IDTPBusinessLayer;
using IDTPDataAccessLayer.Helper;
using IDTPDataTransferObjects;
using IDTPDomainModel.Models;
using IDTPReportTool.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace IDTPReportTool.Controllers
{
    /// <summary>
    /// Generate Reports
    /// </summary>
    public class ReportController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        private string path = "";
        private static string currentReportPath;
        private readonly ReportComponents reportComponents = new ReportComponents();
        private readonly Dictionary<string, string> procNames = new Dictionary<string, string>()
                            {
                                {"transactionSummary.frx","IDTP_RPT_TransactionSummary"},
                                {"transactionDetails.frx","IDTP_RPT_TransactionDetails"},
                                {"billPaymentSummary.frx","IDTP_RPT_BillPaymentsummary"},
                                {"billPaymentDetails.frx" ,"IDTP_RPT_BillPaymentDetails"},
                                {"netDebitCap.frx" ,"IDTP_RPT_NetDebitCap"},
                                {"disputeDetails.frx","IDTP_RPT_DisputeDetails"},
                                {"disputeSummary.frx","IDTP_RPT_DisputeSummary"},
                                {"govtSummary.frx","IDTP_RPT_GovtSummary"},
                                {"govtDetails.frx","IDTP_RPT_GovtDetails"},
                                {"salarySummary.frx","IDTP_RPT_SalarySummary"},
                                {"salaryDetails.frx","IDTP_RPT_SalaryDetails"},
                                {"settledTransaction.frx","IDTP_RPT_SettledTransaction"},
                                {"unsettledTransaction.frx","IDTP_RPT_UnsettledTransaction"},
                                {"SentReport.frx","IDTP_RPT_TransactionSent"},
                                {"ReceivedReport.frx","IDTP_RPT_TransactionReceived" },
                                {"SettlementReport.frx","IDTP_RPT_GetSettlementReport" },

                            };
        public ReportController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string filepath = TempData["FilePath"] as string;
            
            currentReportPath = filepath;
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            WebReport webReport = new WebReport();
            webReport.Report.Load(filepath);
            ViewBag.WebReport = webReport;
            ViewBag.ReportName = currentReportPath;
            
            return View();
        }

        /// <summary>
        /// Loads the view with selectable parameter for report
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ParameterBasedReport()
        {
            string filepath = TempData["FilePath"] as string;
            string reportTitle = TempData["ReportTitle"] as string;
           
            ViewBag.banklist = GetBankList();
            ViewBag.reportTitle = reportTitle;
            ViewBag.ReportName = filepath;
            return View();
        }

        /// <summary>
        /// Loads the report based on the selected Parameter
        /// </summary>
        /// <param name="parameterBasedReport"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ParameterBasedReport([FromForm] ParameterBasedReport parameterBasedReport)
        {
            string reportTitle = parameterBasedReport.ReportTitle;
            string filepath = parameterBasedReport.ReportPath;
            string finId = parameterBasedReport.ParameterValue;
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            WebReport webReport = new WebReport();
            webReport.Report.Load(filepath);
            //TableDataSource ds = webReport.Report.GetDataSource("Settlement") as TableDataSource;
            //string command = ds.SelectCommand;
            //var command = x.SelectCommand;
            ViewBag.WebReport = webReport;
            ViewBag.banklist = GetBankList();
            ViewBag.ReportName = filepath;
            ViewBag.ReportTitle = reportTitle;
            
            if (finId != null)
            {
                var bank = _businessLayer.GetFinInstitutionInfoById(finId);
                webReport.Report.SetParameterValue("BankName", bank.InstitutionName);
                webReport.Report.SetParameterValue("FinancialInstitutionId", Int32.Parse(finId));
                ViewBag.FinancialId = finId;
            }
            TempData["ReportLoaded"] = "true";
            return View();
        }


        /// <summary>
        /// Export Reprts as PDF
        /// </summary>
        /// <param name="Reportpath"></param>
        /// <returns></returns>
        public IActionResult ExportToPDF(string Reportpath, string Parameter=null)
        {
            var path = Reportpath;
            var webReport = new WebReport();
            webReport.Report.Load(path);
            
            if(Parameter != null)
            {
                var bank = _businessLayer.GetFinInstitutionInfoById(Parameter);
                webReport.Report.SetParameterValue("BankName", bank.InstitutionName);
                webReport.Report.SetParameterValue("FinancialInstitutionId", Parameter);
            }
            webReport.Report.Prepare();
            using (MemoryStream ms = new MemoryStream())
            {
                PDFSimpleExport pdfExport = new PDFSimpleExport();
                pdfExport.Export(webReport.Report, ms);
                ms.Flush();
                var filenamewithoutreports = path.Remove(0, 8);
                var filename = filenamewithoutreports.Remove(filenamewithoutreports.Length - 4);

                return File(ms.ToArray(), "application /pdf", filename+DateTime.Now.ToString() +".pdf");
            }
        }
        /// <summary>
        /// Exports reports as Image
        /// </summary>
        /// <param name="ReportPath"></param>
        /// <returns></returns>
        public IActionResult ExportToImage(string ReportPath, string Parameter = null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Report report = new Report();
                path = ReportPath;
                report.Load(path);
                if(Parameter != null)
                {
                    var bank = _businessLayer.GetFinInstitutionInfoById(Parameter);
                    report.SetParameterValue("BankName", bank.InstitutionName);
                    report.SetParameterValue("FinancialInstituionId", int.Parse(Parameter));
                }
                report.Prepare();
                ImageExport image = new ImageExport();
                image.ImageFormat = ImageExportFormat.Jpeg;
                image.JpegQuality = 90;
                image.Resolution = 72;
                image.SeparateFiles = false;
                report.Export(image, ms);
                ms.Flush();

                var filenamewithoutreports = path.Remove(0, 8);
                var filename = filenamewithoutreports.Remove(filenamewithoutreports.Length - 4);


                return File(ms.ToArray(), "application/jpeg", filename + DateTime.Now.ToString()+".jpeg");
            }
        }

        /// <summary>
        /// Exports Reports as CSV
        /// </summary>
        /// <param name="Reportpath"></param>
        /// <returns></returns>
        public IActionResult ExportToCSV(string Reportpath, string Parameter = null)
        {
            var reportName = Reportpath.Remove(0, 8);
            var procName = procNames[reportName];
            var filename = reportName.Remove(reportName.Length - 4);

            string csvFileName = filename+"_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            DataTable csvDataToExport = new DataTable();
            StringWriter stringWriter = new StringWriter();
            //csvDataToExport = reportComponents.GetDynamicDataFromDb("IDTP_RPT_TransactionSummary");
            if (Parameter != null)
            {
                csvDataToExport = reportComponents.
                    GetDataUsingSprocWithParam(procName, "@FinancialInstitutionId", Parameter, SqlDbType.Int);
            }
            else
            {
                csvDataToExport = reportComponents.GetDataWithSProc(procName);
            }
            
            if (csvDataToExport.Rows.Count > 0)
            {
                stringWriter = reportComponents.GetCSVString(csvDataToExport);
            }
            return File(Encoding.UTF8.GetBytes(stringWriter.ToString()), "text/csv", csvFileName);
        }
        /// <summary>
        /// Exports Reports as EXCEL
        /// </summary>
        /// <param name="Reportpath"></param>
        /// <returns></returns>
        public IActionResult ExportToEXCEL(string Reportpath, string Parameter = null)
        {
            var reportName = Reportpath.Remove(0, 8);
            var procName = procNames[reportName];
            var filename = reportName.Remove(reportName.Length - 4);

            XLWorkbook xLWorkbook = new XLWorkbook();
            string excelFileName = filename + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            DataTable excelDataToExport = new DataTable();
            //excelDataToExport = reportComponents.GetDynamicDataFromDb("IDTP_RPT_TransactionSummary");
            //parameterized report list
            if (Parameter != null)
            {
                excelDataToExport = reportComponents.
                    GetDataUsingSprocWithParam(procName, "@FinancialInstitutionId", Parameter, SqlDbType.Int);
            }
            else
            {
                excelDataToExport = reportComponents.GetDataWithSProc(procName);
            }
            xLWorkbook.Worksheets.Add(excelDataToExport, filename);
            using (var stream = new MemoryStream())
            {
                xLWorkbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelFileName);
            }
        }
        /// <summary>
        /// Get the list of banks from db
        /// </summary>
        /// <returns></returns>
        public List<BankDTO> GetBankList()
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
            return list;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}

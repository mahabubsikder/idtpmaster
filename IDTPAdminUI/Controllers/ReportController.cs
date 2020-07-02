using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using FastReport;
using FastReport.Data;
using FastReport.Export.Image;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using FastReport.Web;
using IDTPAdminUI.Models;
using IDTPBusinessLayer;
using IDTPDataAccessLayer.Helper;
using IDTPDataTransferObjects;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDTPAdminUI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IBusinessLayer _businessLayer;


        private readonly ILogger<ReportController> _logger;
        private readonly ReportComponents reportComponents = new ReportComponents();
        public ReportController(ILogger<ReportController> logger, IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
            _logger = logger;
        }

        /// <summary>
        /// Links the frx file with the report name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult Index()
        {
            var reportList = _businessLayer.GetAllReportInfos();
            ViewBag.reportList = reportList;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult Generate(string id, string FinId = null)
        {
            var report = _businessLayer.GetAllReportInfos().Where(x => x.ReportName == id).FirstOrDefault();
            if (report.HasFilter)
            {
                return RedirectToAction("ParameterBasedReport", new { ReportName = report.ReportName });
            }
            else
            {
                return RedirectToAction("BasicReport", new { ReportName = report.ReportName });
            }

        }
        [HttpGet]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult BasicReport(string ReportName)
        {
            var report = _businessLayer.GetAllReportInfos().Where(x => x.ReportName == ReportName).FirstOrDefault();

            string filepath = @"Reports\" + report.ReportPath;
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            WebReport webReport = new WebReport();
            webReport.Report.Load(filepath);
            ViewBag.ReportTitle = report.ReportName;
            ViewBag.WebReport = webReport;
            ViewBag.ReportName = filepath;
            return View(report);
        }


        /// <summary>
        /// Loads the view with selectable parameter for report
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult ParameterBasedReport(string ReportName)
        {
            
            var report = _businessLayer.GetAllReportInfos().Where(x => x.ReportName == ReportName).FirstOrDefault();
            string filepath = @"Reports\" + report.ReportPath;
            ViewBag.banklist = GetBankList();
            ViewBag.reportTitle = report.ReportName;
            ViewBag.ReportName = filepath;
            return View(report);
        }

        /// <summary>
        /// Loads the report based on the selected Parameter
        /// </summary>
        /// <param name="parameterBasedReport"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult ParameterBasedReport([FromForm] ParameterBasedReport parameterBasedReport)
        {
            string reportTitle = parameterBasedReport.ReportTitle;
            var report = _businessLayer.GetAllReportInfos().Where(x => x.ReportName == reportTitle).FirstOrDefault();

            string filepath = parameterBasedReport.ReportPath;
            string finId = parameterBasedReport.ParameterValue;

            //string fromDate = parameterBasedReport.FromDate;
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            WebReport webReport = new WebReport();
            webReport.Report.Load(filepath);
            /*TableDataSource ds = webReport.Report.GetDataSource("Settlement") as TableDataSource;
            string command = ds.SelectCommand;*/
            ViewBag.WebReport = webReport;
            ViewBag.banklist = GetBankList();
            ViewBag.ReportName = filepath;
            ViewBag.ReportTitle = reportTitle;
            if (finId != null)
            {
                var bank = _businessLayer.GetFinInstitutionInfoById(finId);
                webReport.Report.SetParameterValue("BankName", bank.InstitutionName);
                webReport.Report.SetParameterValue("FinancialInstitutionId", finId);
                ViewBag.FinancialId = finId;
            }
            TempData["ReportLoaded"] = "true";
            return View(report);
        }


        /// <summary>
        /// Export Reprts as PDF
        /// </summary>
        /// <param name="Reportpath"></param>
        /// <returns></returns>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult ExportToPDF(string Reportpath, string Parameter = null)
        {
            var path = Reportpath;
            var webReport = new WebReport();
            webReport.Report.Load(path);

            if (Parameter != null)
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

                return File(ms.ToArray(), "application /pdf", filename + DateTime.Now.ToString() + ".pdf");
            }
        }

        /// <summary>
        /// Exports reports as Image
        /// </summary>
        /// <param name="ReportPath"></param>
        /// <returns></returns>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult ExportToImage(string ReportPath, string Parameter = null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Report report = new Report();
                string path = ReportPath;
                report.Load(path);
                if (Parameter != null)
                {
                    var bank = _businessLayer.GetFinInstitutionInfoById(Parameter);
                    report.SetParameterValue("BankName", bank.InstitutionName);
                    report.SetParameterValue("FinancialInstitutionId", int.Parse(Parameter));
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
                return File(ms.ToArray(), "application/jpeg", filename + DateTime.Now.ToString() + ".jpeg");
            }
        }

        /// <summary>
        /// Exports Reports as CSV
        /// </summary>
        /// <param name="Reportpath"></param>
        /// <returns></returns>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult ExportToCSV(string Reportpath, string Parameter = null, string SProc = null)
        {
            var reportName = Reportpath.Remove(0, 8);
            var procName = SProc;
            var filename = reportName.Remove(reportName.Length - 4);

            string csvFileName = filename + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            DataTable csvDataToExport = new DataTable();
            StringWriter stringWriter = new StringWriter();
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
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult ExportToEXCEL(string Reportpath, string Parameter = null, string SProc = null)
        {
            var reportName = Reportpath.Remove(0, 8);
            var procName = SProc;
            var filename = reportName.Remove(reportName.Length - 4);

            XLWorkbook xLWorkbook = new XLWorkbook();
            string excelFileName = filename + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            DataTable excelDataToExport = new DataTable();
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
    }
}
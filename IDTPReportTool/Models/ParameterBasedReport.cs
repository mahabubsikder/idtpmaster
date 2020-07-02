using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDTPReportTool.Models
{
    public class ParameterBasedReport
    {
        public string ReportTitle { get; set; }
        public string ReportPath { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
    }
}

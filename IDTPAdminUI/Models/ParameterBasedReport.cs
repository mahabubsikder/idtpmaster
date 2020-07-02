using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDTPAdminUI.Models
{
    public class ParameterBasedReport
    {
        public string ReportTitle { get; set; }
        public string ReportPath { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}

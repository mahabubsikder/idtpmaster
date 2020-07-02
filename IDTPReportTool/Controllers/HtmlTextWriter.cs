using System.IO;

namespace IDTPReportTool.Controllers
{
    internal class HtmlTextWriter
    {
        private StringWriter sw;

        public HtmlTextWriter(StringWriter sw)
        {
            this.sw = sw;
        }
    }
}
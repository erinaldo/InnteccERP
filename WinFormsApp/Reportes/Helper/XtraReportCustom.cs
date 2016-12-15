using System;
using DevExpress.XtraReports.UI;

namespace WinFormsApp
{
    public class XtraReportCustom : XtraReport
    {
        public string NameDocument { get; set; }

        public XtraReportCustom()
        {
            PrintingSystem.AfterBuildPages += PrintingSystem_AfterBuildPages;
        }

        void PrintingSystem_AfterBuildPages(object sender, EventArgs e)
        {
            PrintingSystem.Document.Name = string.IsNullOrEmpty(NameDocument) ? Name : NameDocument;
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace WinFormsApp
{
    public partial class XtraReportDesignerFrm : Form
    {
        public XtraReport Reporte { get; set; }
        public string FileName { get; set; }
        public DataTable DataSetRp { get; set; }

        public XtraReportDesignerFrm(XtraReport reporte, string fileName, DataTable dataSetRp)
        {
            InitializeComponent();
            Reporte = reporte;
            FileName = fileName;
            DataSetRp = dataSetRp;
            
        }

        private void XtraReportDesignerFrm_Load(object sender, System.EventArgs e)
        {
            reportDesigner1.OpenReport(FileName);
            reportDesigner1.ActiveDesignPanel.FileName = FileName;



        }
    }
}

using System.Windows.Forms;
using FastReport;

namespace WinFormsApp
{
    public partial class ReportDesignerFrm : Form
    {
        public ReportDesignerFrm(Report report)
        {
            InitializeComponent();
            report1 = report;
            designerControlFrm.Report = report1;
        }

        private void ReportDesignerFrm_Load(object sender, System.EventArgs e)
        {            
            designerControlFrm.RefreshLayout();
        }
    }
}

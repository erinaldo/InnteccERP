using System.Windows.Forms;
using FastReport;

namespace WinFormsApp
{
    public partial class PreviewFrm : Form
    {
        //public Report Reporte { get; set; }
        public PreviewFrm(Report report)
        {
            InitializeComponent();           
            report1 = report;
        }

        private void PreviewFrm_Load(object sender, System.EventArgs e)
        {
            report1.Preview = previewControlFrm;
            report1.Prepare();
            report1.ShowPrepared();
        }
    }
}

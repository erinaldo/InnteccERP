using System.Windows.Forms;
using ActionService;
using DevExpress.XtraEditors.Controls;

namespace WinFormsApp
{
    public partial class SuSaludTablasFrm : Form
    {
        static readonly IService Service = new Service();

        public SuSaludTablasFrm()
        {
            InitializeComponent();
        }

        public void CargarReferencias()
        {
            iidcie.Properties.DataSource = Service.GetAllCie("codigocie");
            iidcie.Properties.DisplayMember = "Descripcionciebusqueda";
            iidcie.Properties.ValueMember = "Idcie";

            iIdcpt.Properties.DataSource = Service.GetAllCpt("cptcode");
            iIdcpt.Properties.DisplayMember = "Denominacionprocedimientobusqueda";
            iIdcpt.Properties.ValueMember = "Idcpt";
            //iIdcpt.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

        }

        private void SuSaludTablasFrm_Load(object sender, System.EventArgs e)
        {
            CargarReferencias();
        }
    }
}

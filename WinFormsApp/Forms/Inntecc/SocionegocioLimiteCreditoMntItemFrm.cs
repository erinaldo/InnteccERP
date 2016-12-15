using System;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class SocionegocioLimiteCreditoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwSocionegociolimitecredito VwSocionegociolimitecreditoMnt { get; set; }

        public SocionegocioLimiteCreditoMntItemFrm(TipoMantenimiento tipoMnt, VwSocionegociolimitecredito vwSocionegociolimitecredito)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwSocionegociolimitecreditoMnt = vwSocionegociolimitecredito;

         
        }

        private void SocionegocioLimiteCreditoMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
        }

        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();                    

                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }

        private void ValoresPorDefecto()
        {
            iTipolimitecredito.SelectedIndex = 0;
        }

        private void TraerDatos()
        {
            iIdtipomoneda.EditValue = VwSocionegociolimitecreditoMnt.Idtipomoneda;
            iLimitecredito.EditValue = VwSocionegociolimitecreditoMnt.Limitecredito;
            iTipolimitecredito.SelectedIndex = VwSocionegociolimitecreditoMnt.Tipolimitecredito;
            eCantidadtransacciones.EditValue = VwSocionegociolimitecreditoMnt.Cantidadtransacciones;

        }

        private void CargarReferencias()
        {
            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwSocionegociolimitecreditoMnt.Idtipomoneda  = (int)iIdtipomoneda.EditValue;
                    VwSocionegociolimitecreditoMnt.Nombretipomoneda = iIdtipomoneda.Text.Trim();
                    VwSocionegociolimitecreditoMnt.Limitecredito = (decimal)iLimitecredito.EditValue;
                    VwSocionegociolimitecreditoMnt.Tipolimitecredito = iTipolimitecredito.SelectedIndex;
                    VwSocionegociolimitecreditoMnt.Nombretipolimitecredito = iTipolimitecredito.SelectedIndex == 0 ? "SALDO" : "N° TRANSACCIONES";
                    VwSocionegociolimitecreditoMnt.Cantidadtransacciones = (int)eCantidadtransacciones.EditValue;


                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SocionegocioLimiteCreditoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void iTipolimitecredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            iIdtipomoneda.Enabled = false;
            iLimitecredito.Enabled = false;
            eCantidadtransacciones.Enabled = false;

            switch (iTipolimitecredito.SelectedIndex)
            {
                case 0: //Saldo
                    iIdtipomoneda.Enabled = true;
                    iLimitecredito.Enabled = true;
                    eCantidadtransacciones.EditValue = 0;
                    break;
                case 1: //Cantidad de transacciones
                    eCantidadtransacciones.Enabled = true;
                    iIdtipomoneda.EditValue = 3; //Otros
                    iLimitecredito.EditValue = 0m;
                    break;
            }
        }
    }
}
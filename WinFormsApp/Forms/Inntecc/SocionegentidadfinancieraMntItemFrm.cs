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
    public partial class SocionegentidadfinancieraMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwSocionegentidadfinanciera VwSocionegentidadfinancieraMnt { get; set; }

        public SocionegentidadfinancieraMntItemFrm(TipoMantenimiento tipoMnt, VwSocionegentidadfinanciera vwSocionegentidadfinanciera)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwSocionegentidadfinancieraMnt = vwSocionegentidadfinanciera;

         
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


        }

        private void TraerDatos()
        {
            iIdentfinaciera.EditValue = VwSocionegentidadfinancieraMnt.Identfinaciera;
            iIdtipomoneda.EditValue = VwSocionegentidadfinancieraMnt.Idtipomoneda;
            iNrocuenta.EditValue = VwSocionegentidadfinancieraMnt.Nrocuenta;
            iNrocuentainterbancario.EditValue = VwSocionegentidadfinancieraMnt.Nrocuentainterbancario;
            iEscuentadetraccion.EditValue = VwSocionegentidadfinancieraMnt.Escuentadetraccion;

        }

        private void CargarReferencias()
        {
            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

            iIdentfinaciera.Properties.DataSource = CacheObjects.EntidadfinancieraList;
            iIdentfinaciera.Properties.DisplayMember = "Nombreentidadfinanciera";
            iIdentfinaciera.Properties.ValueMember = "Identfinaciera";
            iIdentfinaciera.Properties.BestFitMode = BestFitMode.BestFit;

        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwSocionegentidadfinancieraMnt.Identfinaciera = (int)iIdentfinaciera.EditValue;
                    VwSocionegentidadfinancieraMnt.Nombreentidadfinanciera = iIdentfinaciera.Text.Trim();
                    VwSocionegentidadfinancieraMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
                    VwSocionegentidadfinancieraMnt.Nombretipomoneda = iIdtipomoneda.Text.Trim();
                    VwSocionegentidadfinancieraMnt.Nrocuenta = iNrocuenta.Text.Trim();
                    VwSocionegentidadfinancieraMnt.Nrocuentainterbancario = iNrocuentainterbancario.Text.Trim();
                    VwSocionegentidadfinancieraMnt.Escuentadetraccion = (bool)iEscuentadetraccion.EditValue;

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
    }
}
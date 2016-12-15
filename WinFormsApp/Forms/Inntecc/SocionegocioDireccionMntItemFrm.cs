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
    public partial class SocionegocioDireccionMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwSocionegociodireccion VwSocionegociodireccionMnt { get; set; }

        public SocionegocioDireccionMntItemFrm(TipoMantenimiento tipoMnt, VwSocionegociodireccion vwSocionegociodireccion)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwSocionegociodireccionMnt = vwSocionegociodireccion;

         
        }

        private void SocionegocioDireccionMntItemFrm_Load(object sender, EventArgs e)
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
                    TraerDatos();
                    break;
            }
        }

        private void ValoresPorDefecto()
        {
            iIdpais.EditValue = 604; //Perú
        }

        private void TraerDatos()
        {
            iIddistrito.EditValue = VwSocionegociodireccionMnt.Iddistrito;
            iDireccionsocionegocio.EditValue = VwSocionegociodireccionMnt.Direccionsocionegocio;
            iReferencia.EditValue = VwSocionegociodireccionMnt.Referencia;
            iPrincipal.EditValue = VwSocionegociodireccionMnt.Principal;
            iIdpais.EditValue = VwSocionegociodireccionMnt.Idpais;
            iTipolocal.EditValue = VwSocionegociodireccionMnt.Tipolocal;
        }

        private void CargarReferencias()
        {
            iIddistrito.Properties.DataSource = CacheObjects.UbigeoList;
            iIddistrito.Properties.DisplayMember = "Nombreubigeo";
            iIddistrito.Properties.ValueMember = "Iddistrito";
            iIddistrito.Properties.BestFitMode = BestFitMode.BestFit;

            iIdpais.Properties.DataSource = CacheObjects.PaisList;
            iIdpais.Properties.DisplayMember = "Nombrepais";
            iIdpais.Properties.ValueMember = "Idpais";
            iIdpais.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwSocionegociodireccionMnt.Iddistrito = (int)iIddistrito.EditValue;
                    VwSocionegociodireccionMnt.Direccionsocionegocio = iDireccionsocionegocio.Text.Trim();
                    VwSocionegociodireccionMnt.Nombreubigeo = iIddistrito.Text.Trim();
                    VwSocionegociodireccionMnt.Referencia = iReferencia.Text.Trim();
                    VwSocionegociodireccionMnt.Principal = (bool)iPrincipal.EditValue;
                    VwSocionegociodireccionMnt.Idpais = (int?) iIdpais.EditValue;
                    VwSocionegociodireccionMnt.Nombrepais = iIdpais.Text.Trim();
                    VwSocionegociodireccionMnt.Tipolocal = iTipolocal.Text.Trim();


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


            if (iPrincipal.Checked && TipoMnt == TipoMantenimiento.Nuevo)
            {
                Socionegociodireccion socionegociodireccion =
                Service.GetSocionegociodireccion(x => x.Idsocionegocio == VwSocionegociodireccionMnt.Idsocionegocio
                && x.Principal);

                if (socionegociodireccion != null)
                {
                    XtraMessageBox.Show("El socio de negocio ya tiene una dirección principal", Resources.titAtencion, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

            }

            return true;
        }

        private void SocionegocioDireccionMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
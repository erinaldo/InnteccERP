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
    public partial class CuadrocomparativoItemMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwCuadrocomparativoprv VwCuadrocomparativoprvMnt { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public CuadrocomparativoItemMntFrm(TipoMantenimiento tipoMnt, VwCuadrocomparativoprv vwCuadrocomparativoprv)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwCuadrocomparativoprvMnt = vwCuadrocomparativoprv;

         
        }
        private void CuadrocomparativoItemMntFrm_Load(object sender, EventArgs e)
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
            iFechacotizacionrecepcion.EditValue = DateTime.Now;
        }
        private void TraerDatos()
        {
            iIdsocionegocio.EditValue = VwCuadrocomparativoprvMnt.Idsocionegocio;
            beSocioNegocio.EditValue = VwCuadrocomparativoprvMnt.Nombresocionegocio;
            rNroDocPersona.EditValue = VwCuadrocomparativoprvMnt.Nrodocentidad;
            iFormadepago.EditValue = VwCuadrocomparativoprvMnt.Formadepago;
            eDiasvalidez.EditValue = VwCuadrocomparativoprvMnt.Diasvalidez;
            iFechacotizacionrecepcion.EditValue = VwCuadrocomparativoprvMnt.Fechacotizacionrecepcion;

        }
        private void CargarReferencias()
        {

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwCuadrocomparativoprvMnt.Idsocionegocio = (int) iIdsocionegocio.EditValue;
                    VwCuadrocomparativoprvMnt.Nombresocionegocio = beSocioNegocio.Text.Trim();
                    VwCuadrocomparativoprvMnt.Nrodocentidad = rNroDocPersona.Text.Trim();
                    VwCuadrocomparativoprvMnt.Formadepago = iFormadepago.Text.Trim();
                    VwCuadrocomparativoprvMnt.Diasvalidez = (int) eDiasvalidez.EditValue;
                    VwCuadrocomparativoprvMnt.Fechacotizacionrecepcion = (DateTime)iFechacotizacionrecepcion.EditValue;

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

            VwCuadrocomparativoprv cuadrocomparativoprv =
                Service.GetVwCuadrocomparativoprv(
                x => x.Idcuadrocomparativo == VwCuadrocomparativoprvMnt.Idcuadrocomparativo
                && x.Idsocionegocio == (int)iIdsocionegocio.EditValue);

            if (cuadrocomparativoprv != null)
            {
                XtraMessageBox.Show("Proveedor ya fué agregado verifique.", Resources.titAtencion, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }
        private void CuadrocomparativoItemMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void CargarDatosSocioNegocio(int idSocioNegocio)
        {

            VwSocionegocioSel = Service.GetVwSocionegocio(idSocioNegocio);

            if (VwSocionegocioSel != null)
            {
                beSocioNegocio.Text = VwSocionegocioSel.Razonsocial.Trim();
                iIdsocionegocio.EditValue = VwSocionegocioSel.Idsocionegocio;
                iIncluyeimpuestoitems.EditValue = VwSocionegocioSel.Incluyeigvitems;
                rNroDocPersona.EditValue = VwSocionegocioSel.Nrodocentidadprincipal;
            }

        }
        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SocionegocioMntFrm socionegocioMntFrm;
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        CargarDatosSocioNegocio(buscarSocioNegocioFrm.VwSocionegocioSel.Idsocionegocio);
                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        CargarDatosSocioNegocio(socionegocioMntFrm.IdEntidadMnt);
                    }
                    break;
                case 2: //Modificar registro
                    var idSocioNegocioMnt = iIdsocionegocio.EditValue;
                    if (idSocioNegocioMnt != null && (int)idSocioNegocioMnt > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idSocioNegocioMnt, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            CargarDatosSocioNegocio(socionegocioMntFrm.IdEntidadMnt);
                        }
                    }
                    break;
            }
        }
    }
}
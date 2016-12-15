using System;
using System.Windows.Forms;
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
    public partial class SocionegociogarantiaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        public VwSocionegociogarantia VwSocionegociogarantiaMnt { get; set; }

        public SocionegociogarantiaMntItemFrm(TipoMantenimiento tipoMnt, VwSocionegociogarantia vwSocionegociolimitecredito)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwSocionegociogarantiaMnt = vwSocionegociolimitecredito;

         
        }

        private void SocionegociogarantiaMntItemFrm_Load(object sender, EventArgs e)
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

            iIdtipogarantia.EditValue = VwSocionegociogarantiaMnt.Idtipogarantia;
            iIdtipomoneda.EditValue = VwSocionegociogarantiaMnt.Idtipomoneda;
            iImporte.EditValue = VwSocionegociogarantiaMnt.Importe;
            iIdentfinaciera.EditValue = VwSocionegociogarantiaMnt.Identfinaciera;
            iVencimiento.EditValue = VwSocionegociogarantiaMnt.Vencimiento;
            iDescripicion.EditValue = VwSocionegociogarantiaMnt.Descripicion;

        }

        private void CargarReferencias()
        {
            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipogarantia.Properties.DataSource = CacheObjects.TipogarantiaList;
            iIdtipogarantia.Properties.DisplayMember = "Nombretipogarantia";
            iIdtipogarantia.Properties.ValueMember = "Idtipogarantia";
            iIdtipogarantia.Properties.BestFitMode = BestFitMode.BestFit;

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

                    VwSocionegociogarantiaMnt.Idtipogarantia = (int)iIdtipogarantia.EditValue;
                    VwSocionegociogarantiaMnt.Nombretipogarantia = iIdtipogarantia.Text.Trim();
                    VwSocionegociogarantiaMnt.Idtipomoneda = (int)iIdtipomoneda.EditValue;
                    VwSocionegociogarantiaMnt.Nombretipomoneda = iIdtipomoneda.Text.Trim();
                    VwSocionegociogarantiaMnt.Importe = (decimal)iImporte.EditValue;
                    VwSocionegociogarantiaMnt.Identfinaciera = (int)iIdentfinaciera.EditValue;
                    VwSocionegociogarantiaMnt.Nombreentidadfinanciera = iIdentfinaciera.Text.Trim();
                    VwSocionegociogarantiaMnt.Vencimiento = (DateTime)iVencimiento.EditValue;
                    VwSocionegociogarantiaMnt.Descripicion = iDescripicion.Text.Trim();

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

        private void SocionegociogarantiaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
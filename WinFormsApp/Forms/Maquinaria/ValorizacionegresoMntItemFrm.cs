using System;
using System.Collections.Generic;
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
    public partial class ValorizacionegresoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwValorizacionegreso VwValorizacionegresoMnt { get; set; }
        public List<VwValorizacionegreso> VwValorizacionegresoList { get; set; }

        public ValorizacionegresoMntItemFrm(TipoMantenimiento tipoMnt,  VwValorizacionegreso vwValorizacionegreso)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwValorizacionegresoMnt = vwValorizacionegreso;

         
        }

        private void ValorizacionegresoMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
        }

        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarDatosForaneos();
                    ValoresPorDefecto();                    

                    break;
                case TipoMantenimiento.Modificar:
                    CargarDatosForaneos();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }

        private void ValoresPorDefecto()
        {
            rNumeroValorizacion.EditValue = string.Format("{0}-{1}", VwValorizacionegresoMnt.Serievalorizacion, VwValorizacionegresoMnt.Numerovalorizacion);
        }

        private void TraerDatos()
        {


            iIdtipoegresovalorizacion.EditValue = VwValorizacionegresoMnt.Idtipoegresovalorizacion;
            iCantidad.EditValue = VwValorizacionegresoMnt.Cantidad;
            iPreciounitario.EditValue = VwValorizacionegresoMnt.Preciounitario;
            iImportetotal.EditValue = VwValorizacionegresoMnt.Importetotal;

        }

        private void CargarDatosForaneos()
        {
            iIdtipoegresovalorizacion.Properties.DataSource = Service.GetAllTipoegresovalorizacion("nombretipoegresovaloriza");
            iIdtipoegresovalorizacion.Properties.DisplayMember = "Nombretipoegresovaloriza";
            iIdtipoegresovalorizacion.Properties.ValueMember = "Idtipoegresovalorizacion";
            iIdtipoegresovalorizacion.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void CalcularTotal(object sender, EventArgs e)
        {
            var cantidad = (decimal) iCantidad.EditValue;
            var preunit = (decimal) iPreciounitario.EditValue;
            var total = Decimal.Round(cantidad * preunit, 2);
            iImportetotal.EditValue = total;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwValorizacionegresoMnt.Idtipoegresovalorizacion = (int)iIdtipoegresovalorizacion.EditValue;
                    VwValorizacionegresoMnt.Cantidad = (decimal)iCantidad.EditValue;
                    VwValorizacionegresoMnt.Preciounitario = (decimal)iPreciounitario.EditValue;
                    VwValorizacionegresoMnt.Importetotal = (decimal)iImportetotal.EditValue;


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

        private void ValorizacionegresoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
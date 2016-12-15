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
    public partial class ArticulounidadMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwArticulodetalleunidad VwArticulodetalleunidadMnt { get; set; }
        public List<VwArticulodetalleunidad> VwArticulodetalleunidadList { get; set; }

        public ArticulounidadMntItemFrm(TipoMantenimiento tipoMnt,  VwArticulodetalleunidad vwArticulodetalleunidad)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwArticulodetalleunidadMnt = vwArticulodetalleunidad;

         
        }

        private void ArticulounidadMntItemFrm_Load(object sender, EventArgs e)
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
            rNombreArticulo.EditValue = VwArticulodetalleunidadMnt.Nombrearticulo;
        }

        private void TraerDatos()
        {
            rNombreArticulo.EditValue = VwArticulodetalleunidadMnt.Nombrearticulo;
            iIdunidadmedida.EditValue = VwArticulodetalleunidadMnt.Idunidadmedida;
          
        }

        private void CargarDatosForaneos()
        {
            iIdunidadmedida.Properties.DataSource = Service.GetAllUnidadmedida("codigounidadmedida");
            iIdunidadmedida.Properties.DisplayMember = "Nombreunidadmedida";
            iIdunidadmedida.Properties.ValueMember = "Idunidadmedida";
            iIdunidadmedida.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwArticulodetalleunidadMnt.Idunidadmedida = (int)iIdunidadmedida.EditValue;
                   

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

        private void ArticulounidadMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
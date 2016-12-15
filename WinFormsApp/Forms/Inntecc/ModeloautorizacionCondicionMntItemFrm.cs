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
    public partial class ModeloautorizacionCondicionMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwModeloautorizacioncondicion VwModeloautorizacioncondicionMnt { get; set; }
        public List<VwPersonacontacto> VwPersonacontactoList { get; set; }

        public ModeloautorizacionCondicionMntItemFrm(TipoMantenimiento tipoMnt,  VwModeloautorizacioncondicion vwModeloautorizacionetapaMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwModeloautorizacioncondicionMnt = vwModeloautorizacionetapaMnt;         
        }

        private void ModeloautorizacionCondicionMntItemFrm_Load(object sender, EventArgs e)
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

        }

        private void TraerDatos()
        {
            iIdautorizaciontipocondicion.EditValue = VwModeloautorizacioncondicionMnt.Idautorizaciontipocondicion;
            iIdtiporatio.EditValue = VwModeloautorizacioncondicionMnt.Idtiporatio;
            nValor1.EditValue = VwModeloautorizacioncondicionMnt.Valor1;
            nValor2.EditValue = VwModeloautorizacioncondicionMnt.Valor2;
        }

        private void CargarDatosForaneos()
        {
            iIdautorizaciontipocondicion.Properties.DataSource = Service.GetAllAutorizaciontipocondicion("nombreautorizaciontipocondicion");
            iIdautorizaciontipocondicion.Properties.DisplayMember = "Nombreautorizaciontipocondicion";
            iIdautorizaciontipocondicion.Properties.ValueMember = "Idautorizaciontipocondicion";
            iIdautorizaciontipocondicion.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtiporatio.Properties.DataSource = Service.GetAllTiporatio("Nombretiporatio");
            iIdtiporatio.Properties.DisplayMember = "Nombretiporatio";
            iIdtiporatio.Properties.ValueMember = "Idtiporatio";
            iIdtiporatio.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwModeloautorizacioncondicionMnt.Idautorizaciontipocondicion = (int)iIdautorizaciontipocondicion.EditValue;
                    VwModeloautorizacioncondicionMnt.Idtiporatio = (int) iIdtiporatio.EditValue;
                    VwModeloautorizacioncondicionMnt.Valor1 = (decimal)nValor1.EditValue;
                    VwModeloautorizacioncondicionMnt.Valor2 = (decimal)nValor2.EditValue;

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

        private void ModeloautorizacionCondicionMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
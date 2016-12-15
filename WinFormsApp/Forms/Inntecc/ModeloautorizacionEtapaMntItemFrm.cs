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
    public partial class ModeloautorizacionEtapaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwModeloautorizacionetapa VwModeloautorizacionetapaMnt { get; set; }
        public List<VwPersonacontacto> VwPersonacontactoList { get; set; }

        public ModeloautorizacionEtapaMntItemFrm(TipoMantenimiento tipoMnt,  VwModeloautorizacionetapa vwModeloautorizacionetapaMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwModeloautorizacionetapaMnt = vwModeloautorizacionetapaMnt;         
        }

        private void ModeloautorizacionEtapaMntItemFrm_Load(object sender, EventArgs e)
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
            iIdetapaautorizacion.EditValue = VwModeloautorizacionetapaMnt.Idetapaautorizacion;
        }

        private void CargarDatosForaneos()
        {
            string whereEtapa = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            iIdetapaautorizacion.Properties.DataSource = Service.GetAllEtapaautorizacion(whereEtapa,"nombreetapaautorizacion");
            iIdetapaautorizacion.Properties.DisplayMember = "Nombreetapaautorizacion";
            iIdetapaautorizacion.Properties.ValueMember = "Idetapaautorizacion";
            iIdetapaautorizacion.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwModeloautorizacionetapaMnt.Idetapaautorizacion = (int)iIdetapaautorizacion.EditValue;
                    VwModeloautorizacionetapaMnt.Nombreetapaautorizacion = iIdetapaautorizacion.Text.Trim();

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

        private void ModeloautorizacionEtapaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
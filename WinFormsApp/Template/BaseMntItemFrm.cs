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
    public partial class BaseMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwPersonacontacto VwPersonacontactoMnt { get; set; }
        public List<VwPersonacontacto> VwPersonacontactoList { get; set; }

        public BaseMntItemFrm(TipoMantenimiento tipoMnt,  VwPersonacontacto vWpersonacontacto)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwPersonacontactoMnt = vWpersonacontacto;

         
        }

        private void BaseMntItemFrm_Load(object sender, EventArgs e)
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
            rNombrePersona.EditValue = VwPersonacontactoMnt.Nombrepersona;
        }

        private void TraerDatos()
        {
            rNombrePersona.EditValue = VwPersonacontactoMnt.Nombrepersona;
            iIdtipocontacto.EditValue = VwPersonacontactoMnt.Idtipocontacto;
            iDatocontacto.EditValue = VwPersonacontactoMnt.Datocontacto;
        }

        private void CargarDatosForaneos()
        {
            iIdtipocontacto.Properties.DataSource = Service.GetAllTiposcontacto("nombretipocontacto");
            iIdtipocontacto.Properties.DisplayMember = "Nombretipocontacto";
            iIdtipocontacto.Properties.ValueMember = "Idtipocontacto";
            iIdtipocontacto.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwPersonacontactoMnt.Idtipocontacto = (int)iIdtipocontacto.EditValue;
                    VwPersonacontactoMnt.Datocontacto = iDatocontacto.Text.Trim();

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

        private void BaseMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
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
    public partial class SocionegociomarcaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public VwSocionegociomarca VwSocionegociomarcaMnt { get; set; }
        private List<Marca> MarcaList { get; set; }
        public SocionegociomarcaMntItemFrm(TipoMantenimiento tipoMnt, VwSocionegociomarca vwSocionegociomarcaMnt)
        {
            InitializeComponent();
            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipoMnt = tipoMnt;
            VwSocionegociomarcaMnt = vwSocionegociomarcaMnt;        
        }

        private void SocionegociomarcaMntItemFrm_Load(object sender, EventArgs e)
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
            iIdmarca.EditValue = VwSocionegociomarcaMnt.Idmarca;
        }

        private void CargarReferencias()
        {
            MarcaList = CacheObjects.MarcaList; //Service.GetAllMarca("nombremarca");
            iIdmarca.Properties.DataSource = MarcaList;
            iIdmarca.Properties.DisplayMember = "Nombremarca";
            iIdmarca.Properties.ValueMember = "Idmarca";
            iIdmarca.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwSocionegociomarcaMnt.Idmarca = (int)iIdmarca.EditValue;
                    VwSocionegociomarcaMnt.Nombremarca = iIdmarca.Text.Trim();

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

        private void SocionegociomarcaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
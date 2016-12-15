using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class ComisioncobroMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Comisioncobrodet ComisioncobrodetMnt { get; set; }
        public List<Comisioncobrodet> ComisioncobrodetList { get; set; }

        public ComisioncobroMntItemFrm(TipoMantenimiento tipoMnt,  Comisioncobrodet comisioncobrodetMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            ComisioncobrodetMnt = comisioncobrodetMnt;         
        }

        private void ComisioncobroMntItemFrm_Load(object sender, EventArgs e)
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
            iRangoinicial.EditValue = ComisioncobrodetMnt.Rangoinicial;
            iRangofinal.EditValue = ComisioncobrodetMnt.Rangofinal;
            iPorcentajecomision.EditValue = ComisioncobrodetMnt.Porcentajecomision;
        }

        private void CargarDatosForaneos()
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

                    ComisioncobrodetMnt.Rangoinicial = (int)iRangoinicial.EditValue;
                    ComisioncobrodetMnt.Rangofinal = (int)iRangofinal.EditValue;
                    ComisioncobrodetMnt.Porcentajecomision = (decimal)iPorcentajecomision.EditValue;

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            ComisioncobrodetMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            ComisioncobrodetMnt.DataEntityState = DataEntityState.Modified;
                            break;
                    }

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

        private void ComisioncobroMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
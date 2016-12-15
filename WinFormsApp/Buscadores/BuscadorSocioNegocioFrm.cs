using System;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;

namespace WinFormsApp
{
    public partial class BuscadorSocioNegocioFrm : XtraForm
    {
        public VwSocionegocio VwSocionegocioSel { get; set; }

        static readonly IService Service = new Service();
        public BuscadorSocioNegocioFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            VwSocionegocioSel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void BuscarSocioNegocio()
        {
            Cursor = Cursors.WaitCursor;
            gcSocioNegocio.BeginUpdate();
            string condicionEmpresa = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);

            string condicion = string.Empty;

            switch (cboTipoBusqueda.SelectedIndex)
            {
                case 0: //Razon 
                    string condicionDinamicaNombre = string.Format("{0}", WinFormUtils.ConvertirCriterioDinamico(txtDatoABuscar.Text.Trim(), "Razonsocial"));
                    condicion = string.Format("{0} and {1}", condicionDinamicaNombre,  condicionEmpresa);
                    break;
                case 1: //Nombre comercial
                    string condicionDinamicaNombreComecial = WinFormUtils.ConvertirCriterioDinamico(txtDatoABuscar.Text.Trim(), "Nombrecomercial");
                    condicion = string.Format("{0} and {1}", condicionDinamicaNombreComecial, condicionEmpresa);
                    break;
                case 2: //Numero documento
                    condicion = string.Format("nrodocentidadprincipal = '{0}' and {1}",txtDatoABuscar.Text.Trim(), condicionEmpresa);
                    break;
            }

            gcSocioNegocio.DataSource = Service.GetAllVwSocionegocio(condicion, "Razonsocial");
            gcSocioNegocio.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void txtDatoABuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            BuscarSocioNegocio();
            gvSocioNegocio.Focus();
        }

        private void gvSocioNegocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            RetornarSocioNegocioSeleccionado();
        }

        private void gvSocioNegocio_DoubleClick(object sender, EventArgs e)
        {
            RetornarSocioNegocioSeleccionado();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            RetornarSocioNegocioSeleccionado();
        }

        private void RetornarSocioNegocioSeleccionado()
        {
            if (gvSocioNegocio.RowCount == 0)
            {
                XtraMessageBox.Show("No ha seleccionado un registro.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            VwSocionegocioSel = (VwSocionegocio)gvSocioNegocio.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }

        private void gvSocioNegocio_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null) view.ActiveEditor.DoubleClick += gvSocioNegocio_CellDoubleClick;
        }

        private void gvSocioNegocio_CellDoubleClick(object sender, EventArgs e)
        {
            RetornarSocioNegocioSeleccionado();
        }

        private void BuscadorSocioNegocioFrm_Load(object sender, EventArgs e)
        {
            cboTipoBusqueda.SelectedIndex = 0;


        }

        private void cboTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDatoABuscar.SelectAll();
            txtDatoABuscar.Select();
        }
    }
}
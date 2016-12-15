using System;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;

namespace WinFormsApp
{
    public partial class BuscadorPersonaFrm : XtraForm
    {
        public VwPersona PersonaSel { get; set; }

        static readonly IService Service = new Service();
        public BuscadorPersonaFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PersonaSel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void BuscarPersona()
        {
            //Cursor = Cursors.WaitCursor;
            //gcPersona.BeginUpdate();

            //string condicionNroDocumento = string.Format("nrodocentidad = '{0}' OR ", txtDatoABuscar.Text.Trim());
            //string condicionDinamicaNombre = string.Format("{0} OR ", WinFormUtils.ConvertirCriterioDinamico(txtDatoABuscar.Text.Trim(), "Razonsocial"));
            //string condicionDinamicaNombreComecial = WinFormUtils.ConvertirCriterioDinamico(txtDatoABuscar.Text.Trim(), "Nombrecomercial");
            //gcPersona.DataSource = Service.GetAllVwPersona(condicionNroDocumento + condicionDinamicaNombre + condicionDinamicaNombreComecial);
            ////gcPersona.DataSource = Service.GetAllVwPersona(x => x.Razonsocial.Contains(txtDatoABuscar.Text.Trim() )
            ////    || x.Nrodocentidad.Contains(txtDatoABuscar.Text.Trim())
            ////    || x.Nombrecomercial.Contains(txtDatoABuscar.Text.Trim()));

            //gcPersona.EndUpdate();
            //Cursor = Cursors.Default;

            ////gvPersona.BestFitColumns();

            Cursor = Cursors.WaitCursor;
            gcPersona.BeginUpdate();

            string condicion = string.Empty;

            switch (cboTipoBusqueda.SelectedIndex)
            {
                case 0: //Razon 
                    string condicionDinamicaNombre = string.Format("{0}", WinFormUtils.ConvertirCriterioDinamico(txtDatoABuscar.Text.Trim(), "Razonsocial"));
                    condicion = string.Format("{0}", condicionDinamicaNombre);
                    break;
                case 1: //Nombre comercial
                    string condicionDinamicaNombreComecial = WinFormUtils.ConvertirCriterioDinamico(txtDatoABuscar.Text.Trim(), "Nombrecomercial");
                    condicion = string.Format("{0}", condicionDinamicaNombreComecial);
                    break;
                case 2: //Numero documento
                    condicion = string.Format("nrodocentidadprincipal = '{0}'", txtDatoABuscar.Text.Trim());
                    break;
            }

            gcPersona.DataSource = Service.GetAllVwPersona(condicion, "Razonsocial");
            gcPersona.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void txtDatoABuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) (Keys.Enter)) return;
            e.Handled = true;
            BuscarPersona();
            gvPersona.Focus();
        }

        private void gvSocioNegocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            RetornarPersonaSeleccionada();
        }

        private void gvSocioNegocio_DoubleClick(object sender, EventArgs e)
        {
            RetornarPersonaSeleccionada();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            RetornarPersonaSeleccionada();
        }

        private void RetornarPersonaSeleccionada()
        {
            if (gvPersona.RowCount == 0)
            {
                XtraMessageBox.Show("No ha seleccionado un registro.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            PersonaSel = (VwPersona) gvPersona.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            BaseMntFrm personaMntFrm = new BaseMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            personaMntFrm.ShowDialog();

            if (personaMntFrm.DialogResult != DialogResult.OK || personaMntFrm.IdEntidadMnt <= 0) return;

            PersonaSel = Service.GetVwPersona(personaMntFrm.IdEntidadMnt);
            DialogResult = DialogResult.OK;
        }

        private void gvPersona_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null) view.ActiveEditor.DoubleClick += gvPersona_CellDoubleClick;
        }

        private void gvPersona_CellDoubleClick(object sender, EventArgs e)
        {
            RetornarPersonaSeleccionada();
        }

        private void BuscadorPersonaFrm_Load(object sender, EventArgs e)
        {
            cboTipoBusqueda.SelectedIndex = 0;
            txtDatoABuscar.Select();
        }
    }
}
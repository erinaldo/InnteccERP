using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using Utilities;

namespace WinFormsApp
{
    public partial class BuscadorArticuloEnInventarioFrm : XtraForm
    {
        public VwInventariostock VwInventariostock { get; set; }

        static readonly IService Service = new Service();
        public BuscadorArticuloEnInventarioFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            VwInventariostock = null;
            DialogResult = DialogResult.Cancel;
        }

        private void BuscarArticuloPorCodigo()
        {
            gcArticulo.BeginUpdate();
            string wherecodigo = string.Format("codigoarticulo LIKE '%{0}%'", txtCodigo.Text.Trim());
            gcArticulo.DataSource = Service.GetAllVwInventariostock(wherecodigo, "nombrearticulo");
            gcArticulo.EndUpdate();
            //gvArticulo.BestFitColumns();
        }

        private void BuscarArticuloPorNombre()
        {
            gcArticulo.BeginUpdate();
            string nombreArticuloUnSoloEspacio =  Regex.Replace(txtDatoABuscar.Text.Trim(), @"\s+", " ").Trim();
            string[] palabrasArticulo = nombreArticuloUnSoloEspacio.Split(' ');
            string whereDinamico = palabrasArticulo.Aggregate(string.Empty, (current, palabra) => current + " nombrearticulo||codigoproveedor LIKE '%" + palabra + "%' AND ");
            //foreach (string palabra in palabrasArticulo)
            //{
            //    whereDinamico = whereDinamico + " nombrearticulo LIKE '%" + palabra + "%' AND ";
            //}  
            whereDinamico = whereDinamico.Substring(0, whereDinamico.Length-5);
            gcArticulo.DataSource = Service.GetAllVwInventariostock(whereDinamico, "nombrearticulo");
            gcArticulo.EndUpdate();
            //gvArticulo.BestFitColumns();
        }

        private void txtDatoABuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) (Keys.Enter)) return;
            e.Handled = true;
            BuscarArticuloPorNombre();
            gvArticulo.Focus();
        }

        private void gvSocioNegocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            VwInventariostock = (VwInventariostock)gvArticulo.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }

        private void gvSocioNegocio_DoubleClick(object sender, EventArgs e)
        {
            VwInventariostock = (VwInventariostock)gvArticulo.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (gvArticulo.RowCount == 0)
            {
                XtraMessageBox.Show("No ha seleccionado un registro.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            VwInventariostock = (VwInventariostock)gvArticulo.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            BuscarArticuloPorCodigo();
            gvArticulo.Focus();
        }

        private void gvArticulo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            VwInventariostock vwInventariostock = (VwInventariostock)gvArticulo.GetFocusedRow();
            if (vwInventariostock != null)
            {
                reCaracteristicas.Text = vwInventariostock.Caracteristicas;
            }
            else
            {
                reCaracteristicas.Text = string.Empty;
            }
        }
    }
}
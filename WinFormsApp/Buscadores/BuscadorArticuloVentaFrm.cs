using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using Utilities;

namespace WinFormsApp
{
    public partial class BuscadorArticuloVentaFrm : XtraForm
    {
        public VwStock ArticuloSel { get; set; }
        public VwAlmacen AlmacenSel { get; set; }
        static readonly IService Service = new Service();
        public List<VwAlmacen> AlmacenList { get; set; }
        public BuscadorArticuloVentaFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            AlmacenSel = Service.GetVwAlmacen(x => x.Idalmacen == ParametrosAlmacen.Idalmacen);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ArticuloSel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void BuscarArticuloPorCodigo()
        {
            
            if (AlmacenSel != null)
            {
                gcArticulo.BeginUpdate();
                string wherecodigo = string.Format(@"codigoarticulo LIKE '%{0}%' and idalmacen = {1}  
                                     and codigoperiodo = '{2}' and idsucursal = {3} "
                    , txtCodigo.Text.Trim()
                    , AlmacenSel.Idalmacen
                    ,SessionApp.EjercicioActual
                    ,SessionApp.SucursalSel.Idsucursal);
                gcArticulo.DataSource = Service.GetAllVwStock(wherecodigo, "nombrearticulo");
                gcArticulo.EndUpdate();
                gvArticulo.BestFitColumns();
            }
        }

        private void BuscarArticuloPorNombre()
        {
            if (AlmacenSel != null)
            {

                gcArticulo.BeginUpdate();
                string nombreArticuloUnSoloEspacio = Regex.Replace(txtDatoABuscar.Text.Trim(), @"\s+", " ").Trim();
                string[] palabrasArticulo = nombreArticuloUnSoloEspacio.Split(' ');
                string whereDinamico = palabrasArticulo.Aggregate(string.Empty, (current, palabra) => current + " nombrearticulo LIKE '%" + palabra + "%' AND ");
                //foreach (string palabra in palabrasArticulo)
                //{
                //    whereDinamico = whereDinamico + " nombrearticulo LIKE '%" + palabra + "%' AND ";
                //}  
                whereDinamico = whereDinamico.Substring(0, whereDinamico.Length - 5);
                string wherefiltro = string.Format(@" and idalmacen = {0} and codigoperiodo = '{1}' and idsucursal = {2}"
                    , AlmacenSel.Idalmacen
                    , SessionApp.EjercicioActual
                    , SessionApp.SucursalSel.Idsucursal);
                gcArticulo.DataSource = Service.GetAllVwStock(whereDinamico + wherefiltro, "nombrearticulo");
                gcArticulo.EndUpdate();
                gvArticulo.BestFitColumns();
            }
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
            ArticuloSel = (VwStock)gvArticulo.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }

        private void gvSocioNegocio_DoubleClick(object sender, EventArgs e)
        {
            ArticuloSel = (VwStock)gvArticulo.GetFocusedRow();
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

            ArticuloSel = (VwStock)gvArticulo.GetFocusedRow();
            DialogResult = DialogResult.OK;
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            ArticuloMntFrm articuloMntFrm = new ArticuloMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            articuloMntFrm.ShowDialog();

            if (articuloMntFrm.DialogResult != DialogResult.OK || articuloMntFrm.IdEntidadMnt <= 0) return;

            ArticuloSel = Service.GetVwStock(articuloMntFrm.IdEntidadMnt);
            DialogResult = DialogResult.OK;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            BuscarArticuloPorCodigo();
            gvArticulo.Focus();
        }
    }
}
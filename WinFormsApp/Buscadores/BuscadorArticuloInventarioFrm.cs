using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;

namespace WinFormsApp
{
    public partial class BuscadorArticuloInventarioFrm : XtraForm
    {
        public VwArticulo VwArticuloSel { get; set; }
        public VwArticuloinventario VwArticuloinventarioSel { get; set; }

        static readonly IService Service = new Service();
        public BuscadorArticuloInventarioFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            VwArticuloSel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void BuscarArticuloPorCodigo()
        {
            //gvArticulo.BeginUpdate();
            string wherecodigo = string.Format("codigoarticulo LIKE '%{0}%'", txtCodigo.Text.Trim());
            gcArticulo.DataSource = Service.GetAllVwArticuloinventario(wherecodigo, "nombrearticulo");
            //gvArticulo.EndUpdate();
            //gvArticulo.BestFitColumns();
        }

        private void BuscarArticuloPorNombre()
        {
            string datoBusqueda = txtDatoABuscar.Text.Trim().Replace("'", "''");
            //gvArticulo.BeginUpdate();
            string nombreArticuloUnSoloEspacio = Regex.Replace(datoBusqueda, @"\s+", " ").Trim();
            string[] palabrasArticulo = nombreArticuloUnSoloEspacio.Split(' ');
            string whereDinamico = palabrasArticulo.Aggregate(string.Empty, (current, palabra) => current + " nombrearticulo||codigoproveedor LIKE '%" + palabra + "%' AND ");
            //foreach (string palabra in palabrasArticulo)
            //{
            //    whereDinamico = whereDinamico + " nombrearticulo LIKE '%" + palabra + "%' AND ";
            //}  
            whereDinamico = whereDinamico.Substring(0, whereDinamico.Length-5);
            gcArticulo.DataSource = Service.GetAllVwArticuloinventario(whereDinamico, "nombrearticulo");
            //gvArticulo.EndUpdate();
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
            RetornarArticuloSeleccionado();
        }

        private void gvSocioNegocio_DoubleClick(object sender, EventArgs e)
        {
            RetornarArticuloSeleccionado();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            RetornarArticuloSeleccionado();
        }

        private void RetornarArticuloSeleccionado()
        {
            if (gvArticulo.RowCount == 0)
            {
                XtraMessageBox.Show("No ha seleccionado un registro.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            VwArticuloinventarioSel = (VwArticuloinventario)gvArticulo.GetFocusedRow();
            
            VwArticulo vwArticuloSel = new VwArticulo();

            vwArticuloSel.Idarticulo = VwArticuloinventarioSel.Idarticulo;
            vwArticuloSel.Codigoarticulo = VwArticuloinventarioSel.Codigoarticulo;
            vwArticuloSel.Codigoproveedor = VwArticuloinventarioSel.Codigoproveedor;
            vwArticuloSel.Codigodebarra = VwArticuloinventarioSel.Codigodebarra;
            vwArticuloSel.Idunidadinventario = VwArticuloinventarioSel.Idunidadinventario;
            vwArticuloSel.Codigounidadmedida = VwArticuloinventarioSel.Codigounidadmedida;
            vwArticuloSel.Nombreunidadmedida = VwArticuloinventarioSel.Nombreunidadmedida;
            vwArticuloSel.Abrunidadmedida = VwArticuloinventarioSel.Abrunidadmedida;
            vwArticuloSel.Factorconversion = VwArticuloinventarioSel.Factorconversion;
            vwArticuloSel.Idarticuloclasificacion = VwArticuloinventarioSel.Idarticuloclasificacion;
            vwArticuloSel.Codigoclasificacion = VwArticuloinventarioSel.Codigoclasificacion;
            vwArticuloSel.Nombreclasificacion = VwArticuloinventarioSel.Nombreclasificacion;
            vwArticuloSel.Idmarca = VwArticuloinventarioSel.Idmarca;
            vwArticuloSel.Nombremarca = VwArticuloinventarioSel.Nombremarca;
            vwArticuloSel.Nombrearticulo = VwArticuloinventarioSel.Nombrearticulo;
            vwArticuloSel.Idimpuesto = VwArticuloinventarioSel.Idimpuesto;
            vwArticuloSel.Abreviaturaigv = VwArticuloinventarioSel.Abreviaturaigv;
            vwArticuloSel.Nombreimpuesto = VwArticuloinventarioSel.Nombreimpuesto;
            vwArticuloSel.Porcentajeimpuesto = VwArticuloinventarioSel.Porcentajeimpuesto;
            vwArticuloSel.Idimpuestoisc = VwArticuloinventarioSel.Idimpuestoisc;
            vwArticuloSel.Abreviaturaisc = VwArticuloinventarioSel.Abreviaturaisc;
            vwArticuloSel.Nombreimpuestoisc = VwArticuloinventarioSel.Nombreimpuestoisc;
            vwArticuloSel.Porcentajeimpuestoisc = VwArticuloinventarioSel.Porcentajeimpuestoisc;
            vwArticuloSel.Activo = VwArticuloinventarioSel.Activo;
            vwArticuloSel.Muevekardex = VwArticuloinventarioSel.Muevekardex;
            vwArticuloSel.Pesoarticulo = VwArticuloinventarioSel.Pesoarticulo;
            vwArticuloSel.Stockminarticulo = VwArticuloinventarioSel.Stockminarticulo;
            vwArticuloSel.Stockmaximo = VwArticuloinventarioSel.Stockmaximo;
            vwArticuloSel.Aplicapercepcion = VwArticuloinventarioSel.Aplicapercepcion;
            vwArticuloSel.Comentario = VwArticuloinventarioSel.Comentario;
            vwArticuloSel.Esarticuloinventario = VwArticuloinventarioSel.Esarticuloinventario;
            vwArticuloSel.Esarticulodeventa = VwArticuloinventarioSel.Esarticulodeventa;
            vwArticuloSel.Esarticulodecompra = VwArticuloinventarioSel.Esarticulodecompra;
            vwArticuloSel.Esactivofijo = VwArticuloinventarioSel.Esactivofijo;
            vwArticuloSel.Idcuentacontable = VwArticuloinventarioSel.Idcuentacontable;
            vwArticuloSel.Codigocuenta = VwArticuloinventarioSel.Codigocuenta;
            vwArticuloSel.Nombrecuenta = VwArticuloinventarioSel.Nombrecuenta;
            vwArticuloSel.Idtipoafectacionigv = VwArticuloinventarioSel.Idtipoafectacionigv;
            vwArticuloSel.Codigotipoafectacionigv = VwArticuloinventarioSel.Codigotipoafectacionigv;
            vwArticuloSel.Nombretipoafectacionigv = VwArticuloinventarioSel.Nombretipoafectacionigv;
            vwArticuloSel.Gravado = VwArticuloinventarioSel.Gravado;
            vwArticuloSel.Exonerado = VwArticuloinventarioSel.Exonerado;
            vwArticuloSel.Inafecto = VwArticuloinventarioSel.Inafecto;
            vwArticuloSel.Exportacion = VwArticuloinventarioSel.Exportacion;
            vwArticuloSel.Caracteristicas = VwArticuloinventarioSel.Caracteristicas;
            vwArticuloSel.Numerodeserie = VwArticuloinventarioSel.Numerodeserie;
            vwArticuloSel.Idcentrodecosto = VwArticuloinventarioSel.Idcentrodecosto;
            vwArticuloSel.Descripcioncentrodecosto = VwArticuloinventarioSel.Descripcioncentrodecosto;
            vwArticuloSel.Esarticulocompuesto = VwArticuloinventarioSel.Esarticulocompuesto;

            VwArticuloSel = vwArticuloSel;

            DialogResult = DialogResult.OK;
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            ArticuloMntFrm articuloMntFrm = new ArticuloMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            articuloMntFrm.ShowDialog();

            if (articuloMntFrm.DialogResult != DialogResult.OK || articuloMntFrm.IdEntidadMnt <= 0) return;

            VwArticuloSel = Service.GetVwArticulo(articuloMntFrm.IdEntidadMnt);
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
            VwArticuloinventario vwArticuloinventarioSel = (VwArticuloinventario)gvArticulo.GetFocusedRow();
            if (vwArticuloinventarioSel != null)
            {
                reCaracteristicas.Text = vwArticuloinventarioSel.Caracteristicas;
            }
            else
            {
                reCaracteristicas.Text = string.Empty;
            }
        }

        private void gvArticulo_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null) view.ActiveEditor.DoubleClick += gvArticulo_CellDoubleClick;
        }

        private void gvArticulo_CellDoubleClick(object sender, EventArgs e)
        {
            RetornarArticuloSeleccionado();
        }


    }
}
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;

namespace WinFormsApp
{
    public partial class BuscadorArticuloFrm : XtraForm
    {
        public VwArticulounidad VwArticulounidadSel { get; set; }
        static readonly IService Service = new Service();
        public int IdSucursalConsulta { get; set; }
        public int IdAlmacenConsulta { get; set; }
        public int IdTipoListaConsulta { get; set; }
        public BuscadorArticuloFrm(int idSucursalConsulta, int idAlmacenConsulta, int idTipoListaConsulta)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            IdSucursalConsulta = idSucursalConsulta;
            IdAlmacenConsulta = idAlmacenConsulta;
            IdTipoListaConsulta = idTipoListaConsulta;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            VwArticulounidadSel = null;
            DialogResult = DialogResult.Cancel;
        }
        private void BuscarArticuloPorCodigo()
        {
            
            string wherecodigo = string.Format("codigoarticulo LIKE '%{0}%'", txtCodigoInterno.Text.Trim());

            int idSucursal = IdSucursalConsulta;
            int idAlmacen = IdAlmacenConsulta;
            int idTipoLista = IdTipoListaConsulta;

            DateTime fechaConsulta = DateTime.Now;
            string condicion = wherecodigo;
            gcArticulo.DataSource = Service.ConsultaArticuloStockLista(idSucursal, idAlmacen, idTipoLista, fechaConsulta, condicion);            
        }
        private void BuscarArticuloPorNombre()
        {
            string nombreArticuloUnSoloEspacio =  Regex.Replace(txtNombreArticulo.Text.Trim(), @"\s+", " ").Trim();
            string[] palabrasArticulo = nombreArticuloUnSoloEspacio.Split(' ');
            string whereDinamico = palabrasArticulo.Aggregate(string.Empty, (current, palabra) => current + " upper(nombrearticulo)||codigoproveedor LIKE '%" + palabra + "%' AND ");
            //foreach (string palabra in palabrasArticulo)
            //{
            //    whereDinamico = whereDinamico + " nombrearticulo LIKE '%" + palabra + "%' AND ";
            //}  
            whereDinamico = whereDinamico.Substring(0, whereDinamico.Length-5);
            int idSucursal = IdSucursalConsulta;
            int idAlmacen = IdAlmacenConsulta;
            int idTipoLista = IdTipoListaConsulta;

            DateTime fechaConsulta = DateTime.Now;
            string condicion = whereDinamico;

            gcArticulo.DataSource = Service.ConsultaArticuloStockLista(idSucursal, idAlmacen, idTipoLista, fechaConsulta, condicion);
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

            //VwArticulostocklista vwArticulostocklista = (VwArticulostocklista)gvArticulo.GetFocusedRow();
            //VwArticuloSel = AsignarVwArticulo(vwArticulostocklista);
            //DialogResult = DialogResult.OK;
            RetornarArticuloSeleccionado();
        }
        private void gvSocioNegocio_DoubleClick(object sender, EventArgs e)
        {
            //VwArticulostocklista vwArticulostocklista = (VwArticulostocklista)gvArticulo.GetFocusedRow();
            //VwArticuloSel = AsignarVwArticulo(vwArticulostocklista);
            //DialogResult = DialogResult.OK;
            RetornarArticuloSeleccionado();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (gvArticulo.RowCount == 0)
            {
                XtraMessageBox.Show("No ha seleccionado un registro.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            RetornarArticuloSeleccionado();
        }

        private void RetornarArticuloSeleccionado()
        {
            VwArticulostocklista vwArticulostocklista = (VwArticulostocklista) gvArticulo.GetFocusedRow();
            VwArticulounidadSel = AsignarVwArticulo(vwArticulostocklista);
            DialogResult = DialogResult.OK;
        }

        private VwArticulounidad AsignarVwArticulo(VwArticulostocklista vwArticulostocklista)
        {
            VwArticulounidad vwArticulounidad = new VwArticulounidad();
            vwArticulounidad.Idarticulo = vwArticulostocklista.Idarticulo;
            vwArticulounidad.Codigoarticulo = vwArticulostocklista.Codigoarticulo;
            vwArticulounidad.Codigoproveedor = vwArticulostocklista.Codigoproveedor;
            vwArticulounidad.Codigodebarra = vwArticulostocklista.Codigodebarra;
            vwArticulounidad.Idunidadinventario = vwArticulostocklista.Idunidadmedida;
            vwArticulounidad.Codigounidadmedida = vwArticulostocklista.Codigounidadmedida;
            vwArticulounidad.Nombreunidadmedida = vwArticulostocklista.Nombreunidadmedida;
            vwArticulounidad.Abrunidadmedida = vwArticulostocklista.Abrunidadmedida;
            vwArticulounidad.Factorconversion = vwArticulostocklista.Factorconversion;
            vwArticulounidad.Idarticuloclasificacion = vwArticulostocklista.Idarticuloclasificacion;
            vwArticulounidad.Codigoclasificacion = vwArticulostocklista.Codigoclasificacion;
            vwArticulounidad.Nombreclasificacion = vwArticulostocklista.Nombreclasificacion;
            vwArticulounidad.Idmarca = vwArticulostocklista.Idmarca;
            vwArticulounidad.Nombremarca = vwArticulostocklista.Nombremarca;
            vwArticulounidad.Nombrearticulo = vwArticulostocklista.Nombrearticulo;
            vwArticulounidad.Idimpuesto = vwArticulostocklista.Idimpuesto;
            vwArticulounidad.Abreviaturaigv = vwArticulostocklista.Abreviaturaigv;
            vwArticulounidad.Nombreimpuesto = vwArticulostocklista.Nombreimpuesto;
            vwArticulounidad.Porcentajeimpuesto = vwArticulostocklista.Porcentajeimpuesto;
            vwArticulounidad.Idimpuestoisc = vwArticulostocklista.Idimpuestoisc;
            vwArticulounidad.Abreviaturaisc = vwArticulostocklista.Abreviaturaisc;
            vwArticulounidad.Nombreimpuestoisc = vwArticulostocklista.Nombreimpuestoisc;
            vwArticulounidad.Porcentajeimpuestoisc = vwArticulostocklista.Porcentajeimpuestoisc;
            vwArticulounidad.Activo = vwArticulostocklista.Activo;
            vwArticulounidad.Muevekardex = vwArticulostocklista.Muevekardex;
            vwArticulounidad.Pesoarticulo = vwArticulostocklista.Pesoarticulo;
            vwArticulounidad.Stockminarticulo = vwArticulostocklista.Stockminarticulo;
            vwArticulounidad.Stockmaximo = vwArticulostocklista.Stockmaximo;
            vwArticulounidad.Aplicapercepcion = vwArticulostocklista.Aplicapercepcion;
            vwArticulounidad.Comentario = vwArticulostocklista.Comentario;
            vwArticulounidad.Esarticuloinventario = vwArticulostocklista.Esarticuloinventario;
            vwArticulounidad.Esarticulodeventa = vwArticulostocklista.Esarticulodeventa;
            vwArticulounidad.Esarticulodecompra = vwArticulostocklista.Esarticulodecompra;
            vwArticulounidad.Esactivofijo = vwArticulostocklista.Esactivofijo;
            vwArticulounidad.Idcuentacontable = vwArticulostocklista.Idcuentacontable;
            vwArticulounidad.Codigocuenta = vwArticulostocklista.Codigocuenta;
            vwArticulounidad.Nombrecuenta = vwArticulostocklista.Nombrecuenta;
            vwArticulounidad.Idtipoafectacionigv = vwArticulostocklista.Idtipoafectacionigv;
            vwArticulounidad.Codigotipoafectacionigv = vwArticulostocklista.Codigotipoafectacionigv;
            vwArticulounidad.Nombretipoafectacionigv = vwArticulostocklista.Nombretipoafectacionigv;
            vwArticulounidad.Gravado = vwArticulostocklista.Gravado;
            vwArticulounidad.Exonerado = vwArticulostocklista.Exonerado;
            vwArticulounidad.Inafecto = vwArticulostocklista.Inafecto;
            vwArticulounidad.Exportacion = vwArticulostocklista.Exportacion;
            vwArticulounidad.Caracteristicas = vwArticulostocklista.Caracteristicas;
            vwArticulounidad.Stock = vwArticulostocklista.Stock;
            vwArticulounidad.Preciolista = vwArticulostocklista.Preciosugerido;
            vwArticulounidad.Esarticulocompuesto = vwArticulostocklista.Esarticulocompuesto;
            return vwArticulounidad;
        }
        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            //ArticuloMntFrm articuloMntFrm = new ArticuloMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            //articuloMntFrm.ShowDialog();

            //if (articuloMntFrm.DialogResult != DialogResult.OK || articuloMntFrm.IdEntidadMnt <= 0) return;
            //VwArticulounidadSel = Service.GetVwArticulo(articuloMntFrm.IdEntidadMnt);
            //DialogResult = DialogResult.OK;
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)(Keys.Enter)) return;
            e.Handled = true;
            BuscarArticuloPorCodigo();
            gvArticulo.Focus();
        }
        private void txtCodigoBarra_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodigoBarra.Text.Trim().Length == 0)
            {
                //XtraMessageBox.Show("Ingrese un código de barra valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtCodigoBarra.SelectAll();
                return;
            }

            Articulo articulo = Service.GetArticulo(x => x.Codigodebarra == txtCodigoBarra.Text.Trim());
            if (articulo != null)
            {
                int idSucursal = IdSucursalConsulta;
                int idAlmacen = IdAlmacenConsulta;
                int idTipoLista = IdTipoListaConsulta;

                DateTime fechaConsulta = DateTime.Now;
                gcArticulo.DataSource = Service.ConsultaArticuloStockLista(articulo.Idarticulo, idSucursal, idAlmacen, idTipoLista, fechaConsulta);
                gvArticulo.Focus();
            }
            else
            {
                XtraMessageBox.Show("Código de barra no existe", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtCodigoBarra.SelectAll();
                gcArticulo.DataSource = null;
            }
        }
        private void txtCodigoBarra_Enter(object sender, EventArgs e)
        {
            txtCodigoBarra.SelectAll();
        }
        private void txtCodigoInterno_Enter(object sender, EventArgs e)
        {
            txtCodigoInterno.SelectAll();
        }
        private void txtDatoABuscar_Enter(object sender, EventArgs e)
        {
            txtNombreArticulo.SelectAll();
        }

        private void BuscadorArticuloFrm_Load(object sender, EventArgs e)
        {
            txtNombreArticulo.Select();
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
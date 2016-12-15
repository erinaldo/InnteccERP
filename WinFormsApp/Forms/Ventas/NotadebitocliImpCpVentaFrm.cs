using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Utilities;

namespace WinFormsApp
{
    public partial class NotadebitocliImpCpVentaFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwCpventa> _vwCpventaList;

        private List<VwCpventaimpnd> _vwCpventaimpndList;
        public List<VwNotadebitoclidet> VwNotadebitoclidetList { get; set; }
        public VwCpventa VwCpventaSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public int IdTipoMoneda { get; set; }
        public NotadebitocliImpCpVentaFrm(List<VwNotadebitoclidet> vwNotadebitoclidetList, VwSocionegocio vwSocionegocioSel, int idTipoMoneda)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwNotadebitoclidetList = vwNotadebitoclidetList;
            VwSocionegocioSel = vwSocionegocioSel;
            IdTipoMoneda = idTipoMoneda;
        }
        private void NotadebitocliImpCpVentaFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            CargarCpVenta();
        }
        private void CargarReferencias()
        {
            rProveedor.EditValue = VwSocionegocioSel.Razonsocial;
            rRuc.EditValue = VwSocionegocioSel.Nrodocentidadprincipal;
        }
        private void CargarCpVenta()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;

            const string whereNoPendientes = @" and idcpventa 
                                               in (select a.idcpventa
                                               from ventas.vwcpventaimpnd a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";

            string whereProveedor = string.Format("idcliente = {0} and idtipomoneda = {1} {2}", VwSocionegocioSel.Idsocionegocio, IdTipoMoneda, whereNoPendientes);
            _vwCpventaList = Service.GetAllVwCpventa(whereProveedor, "abreviaturatipoformato,seriecpventa desc,numerocpventa desc");
            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwCpventaList;
            gcConsulta.EndUpdate();
            gvConsulta.BestFitColumns();

            Cursor = Cursors.Default;
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            

            switch (e.Item.Name)
            {
                case "btnImportar":

                    if (!Validaciones()) return;

                    var maxItem = VwNotadebitoclidetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in _vwCpventaimpndList.Where(x => x.Itemseleccionado))
                    {
                        VwNotadebitoclidet vwNotadebitooclidet = new VwNotadebitoclidet();
                        vwNotadebitooclidet.Numeroitem = sgtItem;
                        vwNotadebitooclidet.Idarticulo = item.Idarticulo;
                        vwNotadebitooclidet.Codigoarticulo = item.Codigoarticulo;
                        vwNotadebitooclidet.Codigoproveedor = item.Codigoproveedor;
                        vwNotadebitooclidet.Idunidadmedida = item.Idunidadmedida;
                        vwNotadebitooclidet.Idalmacen = item.Idalmacen;
                        vwNotadebitooclidet.Nombremarca = item.Nombremarca;
                        vwNotadebitooclidet.Nombrearticulo = item.Nombrearticulo;
                        vwNotadebitooclidet.Cantidad = item.Cantidadaimportar;
                        vwNotadebitooclidet.Idunidadmedida = item.Idunidadmedida;
                        vwNotadebitooclidet.Abrunidadmedida = item.Abrunidadmedida;
                        vwNotadebitooclidet.Preciounitario = item.Preciounitarioneto;
                        vwNotadebitooclidet.Especificacion = item.Especificacion;
                        vwNotadebitooclidet.Descuento1 = 0;
                        vwNotadebitooclidet.Descuento2 = 0;
                        vwNotadebitooclidet.Descuento3 = 0;
                        vwNotadebitooclidet.Descuento4 = 0;
                        vwNotadebitooclidet.Preciounitarioneto = 0;
                        vwNotadebitooclidet.Importetotal = 0;
                        vwNotadebitooclidet.Idimpuesto = item.Idimpuesto;
                        vwNotadebitooclidet.Idcentrodecosto = item.Idcentrodecosto;
                        vwNotadebitooclidet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwNotadebitooclidet.Porcentajepercepcion = 0;
                        vwNotadebitooclidet.Idarea = item.Idarea;
                        vwNotadebitooclidet.Nombrearea = item.Nombrearea;                        
                        vwNotadebitooclidet.Idproyecto = item.Idproyecto;
                        vwNotadebitooclidet.Nombreproyecto = item.Nombreproyecto;
                        vwNotadebitooclidet.Idcpventadet  = item.Idcpventadet ;

                        vwNotadebitooclidet.Seriecpventa = item.Seriecpventa;
                        vwNotadebitooclidet.Numerocpventa = item.Numerocpventa;
                        vwNotadebitooclidet.Serienumerocpventa = item.Serienumerocp;

                        vwNotadebitooclidet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                        vwNotadebitooclidet.Gravado = item.Gravado;
                        vwNotadebitooclidet.Exonerado = item.Exonerado;
                        vwNotadebitooclidet.Inafecto = item.Inafecto;
                        vwNotadebitooclidet.Exportacion = item.Exportacion;

                        vwNotadebitooclidet.DataEntityState = DataEntityState.Added;

                        //vwNotacreditoclidet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //vwNotacreditoclidet.Creationdate = DateTime.Now;
                        //vwNotacreditoclidet.Modifiedby = null;
                        //vwNotacreditoclidet.Lastmodified = null;
                        
                        sgtItem++;
                        VwNotadebitoclidetList.Add(vwNotadebitooclidet);
                    }

                    VwCpventaSel = (VwCpventa)gvConsulta.GetFocusedRow();
                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarCpVenta();


                    break;
                case "btnCerrar":
                    DialogResult = DialogResult.OK;
                    break;

            }
        }
        private bool ValidacionDatosConsulta()
        {

            return true;
        }
        private bool Validaciones()
        {
            if (gvConsulta.RowCount == 0 || gvDetalleImp.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información Comprobante de Venta, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }



            return true;
        }
        private void NotadebitocliImpCpVentaFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpventaimpnd itemSel = (VwCpventaimpnd)gvDetalleImp.GetFocusedRow();

            string nameColumn = e.Column.FieldName;
            switch (nameColumn)
            {
                case "Cantidadaimportar":
                    if (itemSel.Cantidadaimportar > itemSel.Saldoaimportar)
                    {
                        XtraMessageBox.Show("Cantidad a importar no es valida", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        itemSel.Cantidadaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Itemseleccionado = itemSel.Cantidadaimportar > 0;
                    }
                    gvDetalleImp.RefreshData();
                    break;
                case "Itemseleccionado":

                    if (itemSel.Saldoaimportar == 0)
                    {
                        itemSel.Cantidadaimportar = 0m;
                        itemSel.Itemseleccionado = false;
                    }
                    else
                    {
                        itemSel.Cantidadaimportar = itemSel.Itemseleccionado ? itemSel.Saldoaimportar : 0;
                    }
                    gvDetalleImp.RefreshData();
                    break;
            }
        }
        private void riItemseleccionado_EditValueChanged(object sender, EventArgs e)
        {
            //Para que actualize datos cuando se hace check en checkedit de la columan
            gvDetalleImp.PostEditor();

        }
        private void gvConsulta_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CargarDetalleCpventa();
        }
        private void CargarDetalleCpventa()
        {
            VwCpventa vwCpventaSel = (VwCpventa)gvConsulta.GetFocusedRow();

            if (vwCpventaSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idcpventa = {0} and saldoaimportar >0", vwCpventaSel.Idcpventa);
                _vwCpventaimpndList = Service.GetAllVwCpventaimpnd(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = _vwCpventaimpndList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwCpventaimpndList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}
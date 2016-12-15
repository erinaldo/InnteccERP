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
    public partial class NotacreditocliImpCpVentaFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwCpventa> _vwCpventaList;

        private List<VwCpventaimpnc> _vwCpventaimpncList;
        public List<VwNotacreditoclidet> VwNotacreditoclidetList { get; set; }
        public VwCpventa VwCpventaSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public int IdTipoMoneda { get; set; }
        public NotacreditocliImpCpVentaFrm(List<VwNotacreditoclidet> vwNotacreditoclidetList, VwSocionegocio vwSocionegocioSel, int idTipoMoneda)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwNotacreditoclidetList = vwNotacreditoclidetList;
            VwSocionegocioSel = vwSocionegocioSel;
            IdTipoMoneda = idTipoMoneda;
        }
        private void NotacreditocliImpCpVentaFrm_Load(object sender, EventArgs e)
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
                                               from ventas.vwcpventaimpnc a 
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

                    var maxItem = VwNotacreditoclidetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in _vwCpventaimpncList.Where(x => x.Itemseleccionado))
                    {
                        VwNotacreditoclidet vwNotacreditoclidet = new VwNotacreditoclidet();
                        vwNotacreditoclidet.Numeroitem = sgtItem;
                        vwNotacreditoclidet.Idarticulo = item.Idarticulo;
                        vwNotacreditoclidet.Codigoarticulo = item.Codigoarticulo;
                        vwNotacreditoclidet.Codigoproveedor = item.Codigoproveedor;
                        vwNotacreditoclidet.Idunidadmedida = item.Idunidadmedida;
                        vwNotacreditoclidet.Idalmacen = item.Idalmacen;
                        vwNotacreditoclidet.Nombremarca = item.Nombremarca;
                        vwNotacreditoclidet.Nombrearticulo = item.Nombrearticulo;
                        vwNotacreditoclidet.Cantidad = item.Cantidadaimportar;
                        vwNotacreditoclidet.Idunidadmedida = item.Idunidadmedida;
                        vwNotacreditoclidet.Abrunidadmedida = item.Abrunidadmedida;
                        vwNotacreditoclidet.Preciounitario = item.Preciounitarioneto;
                        vwNotacreditoclidet.Especificacion = item.Especificacion;
                        vwNotacreditoclidet.Descuento1 = 0;
                        vwNotacreditoclidet.Descuento2 = 0;
                        vwNotacreditoclidet.Descuento3 = 0;
                        vwNotacreditoclidet.Descuento4 = 0;
                        vwNotacreditoclidet.Preciounitarioneto = 0;
                        vwNotacreditoclidet.Importetotal = 0;
                        vwNotacreditoclidet.Idimpuesto = item.Idimpuesto;
                        vwNotacreditoclidet.Idcentrodecosto = item.Idcentrodecosto;
                        vwNotacreditoclidet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwNotacreditoclidet.Porcentajepercepcion = 0;
                        vwNotacreditoclidet.Idarea = item.Idarea;
                        vwNotacreditoclidet.Nombrearea = item.Nombrearea;                        
                        vwNotacreditoclidet.Idproyecto = item.Idproyecto;
                        vwNotacreditoclidet.Nombreproyecto = item.Nombreproyecto;
                        vwNotacreditoclidet.Idcpventadet  = item.Idcpventadet ;

                        vwNotacreditoclidet.Seriecpventa = item.Seriecpventa;
                        vwNotacreditoclidet.Numerocpventa = item.Numerocpventa;
                        vwNotacreditoclidet.Serienumerocpventa = item.Serienumerocp;

                        vwNotacreditoclidet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                        vwNotacreditoclidet.Gravado = item.Gravado;
                        vwNotacreditoclidet.Exonerado = item.Exonerado;
                        vwNotacreditoclidet.Inafecto = item.Inafecto;
                        vwNotacreditoclidet.Exportacion = item.Exportacion;

                        vwNotacreditoclidet.DataEntityState = DataEntityState.Added;

                        //vwNotacreditoclidet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                        //vwNotacreditoclidet.Creationdate = DateTime.Now;
                        //vwNotacreditoclidet.Modifiedby = null;
                        //vwNotacreditoclidet.Lastmodified = null;
                        
                        sgtItem++;
                        VwNotacreditoclidetList.Add(vwNotacreditoclidet);
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
        private void NotacreditocliImpCpVentaFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpventaimpnc itemSel = (VwCpventaimpnc)gvDetalleImp.GetFocusedRow();

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
                _vwCpventaimpncList = Service.GetAllVwCpventaimpnc(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = _vwCpventaimpncList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwCpventaimpncList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}
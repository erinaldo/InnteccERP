using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using Utilities;

namespace WinFormsApp
{
    public partial class OrdendeventaImpCotizaFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwCotizacioncliente> _vwCotizacionclienteList;

        private List<VwTipocp> _vwTipocpsList;

        private List<VwCotizacionclientedetovimp> _vwCotizacionclientedetovimpList;
        public List<VwOrdendeventadet> VwOrdendeventadetList { get; set; }
        public VwCotizacioncliente VwCotizacionclienteSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public DateTime FechaInicialInventario { get; set; }
        public OrdendeventaImpCotizaFrm(List<VwOrdendeventadet> vwOrdendeventadetList, VwSocionegocio vwSocionegocioSel)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwOrdendeventadetList = vwOrdendeventadetList;
            VwSocionegocioSel = vwSocionegocioSel;
        }
        private void OrdendeventaImpCotizaFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            AsignarFechaInventario();

            //Valores por defectto
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            cboBuscarPor.SelectedIndex = 0; //Todos

            if (!ValidacionDatosConsulta()) return;            

            CargarCotizaconesDeVenta();
           
        }

        private void AsignarFechaInventario()
        {
            string condicion = string.Format("idsucursal = '{0}' and anulado = '0' ", SessionApp.SucursalSel.Idsucursal);
            string orden = "idinventario desc limit 1";
            var inventarioList = Service.GetAllInventario(condicion, orden);
            if (inventarioList != null)
            {
                Inventario inventario = inventarioList.FirstOrDefault();
                if (inventario != null)
                {
                    FechaInicialInventario = inventario.Fechainventario;
                }
            }
        }

        private void CargarReferencias()
        {
            iIdsucursal.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDENCOMPRA", (int)iIdsucursal.EditValue);
            _vwTipocpsList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp,seriecp");
            iIdtipocp.Properties.DataSource = _vwTipocpsList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarCotizaconesDeVenta()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;
            string whereCot = string.Empty;

            const string whereNoPendientes = @" idcotizacioncliente 
                                               in (select a.idcotizacioncliente
                                               from ventas.vwcotizacionclientedetovimp a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereCot = string.Format("anulado = '0' and idsucursal = {0} and {1} and idcliente = {2}", 
                        (int)iIdsucursal.EditValue,
                        whereNoPendientes,
                        VwSocionegocioSel.Idsocionegocio);
                    break;
                case 1: //Cotizaciones
                    whereCot = string.Format(@"idtipocp = {0} and seriecotizacion = '{1}'
                        and numerocotizacion = '{2}' and anulado = '0' and idsucursal = {3} and {4} and idcliente = {5}",
                        (int)iIdtipocp.EditValue,
                        rSerie.Text.Trim(),
                        iNumero.Text.Trim(),
                        (int)iIdsucursal.EditValue,
                        whereNoPendientes,
                        VwSocionegocioSel.Idsocionegocio);
                    break;
            }

            _vwCotizacionclienteList = Service.GetAllVwCotizacioncliente(whereCot, "abreviaturatipoformato,seriecotizacion,numerocotizacion");
            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwCotizacionclienteList;
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


                    var maxItem = VwOrdendeventadetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in _vwCotizacionclientedetovimpList.Where(x => x.Itemseleccionado))
                    {
                        VwOrdendeventadet vwOrdendeventadet = new VwOrdendeventadet();
                        vwOrdendeventadet.Numeroitem = sgtItem;
                        vwOrdendeventadet.Idarticulo = item.Idarticulo;
                        vwOrdendeventadet.Codigoarticulo = item.Codigoarticulo;
                        vwOrdendeventadet.Codigoproveedor = item.Codigoproveedor;
                        vwOrdendeventadet.Idunidadinventario = item.Idunidadmedida;
                        vwOrdendeventadet.Nombremarca = item.Nombremarca;
                        vwOrdendeventadet.Nombrearticulo = item.Nombrearticulo;
                        vwOrdendeventadet.Cantidad = item.Cantidadaimportar;
                        vwOrdendeventadet.Idunidadmedida = item.Idunidadmedida;
                        vwOrdendeventadet.Abrunidadmedida = item.Abrunidadmedida;
                        vwOrdendeventadet.Preciounitario = item.Preciounitario;
                        vwOrdendeventadet.Especificacion = item.Especificacion;
                        vwOrdendeventadet.Idcentrodecosto = item.Idcentrodecosto;
                        vwOrdendeventadet.Descuento1 = item.Descuento1;
                        vwOrdendeventadet.Descuento2 = item.Descuento2;
                        vwOrdendeventadet.Descuento3 = item.Descuento3;
                        vwOrdendeventadet.Descuento4 = item.Descuento4;
                        vwOrdendeventadet.Preciounitarioneto = item.Preciounitarioneto;
                        vwOrdendeventadet.Importetotal = item.Importetotal;
                        vwOrdendeventadet.Idimpuesto = item.Idimpuesto;
                        vwOrdendeventadet.Idcentrodecosto = item.Idcentrodecosto;
                        vwOrdendeventadet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwOrdendeventadet.Porcentajepercepcion = item.Porcentajepercepcion;
                        vwOrdendeventadet.Idarea = item.Idarea;
                        vwOrdendeventadet.Nombrearea = item.Nombrearea;
                        vwOrdendeventadet.Idproyecto = item.Idproyecto;
                        vwOrdendeventadet.Nombreproyecto = item.Nombreproyecto;
                        vwOrdendeventadet.Idcotizacionclientedet = item.Idcotizacionclientedet;
                        vwOrdendeventadet.Serienumerocotizacion = item.Serienumerocotizacion;
                        vwOrdendeventadet.Diasdeentrega = 0;
                        vwOrdendeventadet.Idalmacen = item.Idalmacen;
                        vwOrdendeventadet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                        vwOrdendeventadet.Gravado = item.Gravado;
                        vwOrdendeventadet.Exonerado = item.Exonerado;
                        vwOrdendeventadet.Inafecto = item.Inafecto;
                        vwOrdendeventadet.Numeromeses = 0;
                        vwOrdendeventadet.DataEntityState = DataEntityState.Added;

                        TipoMnt = vwOrdendeventadet.Idordendeventadet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
                        switch (TipoMnt)
                        {
                            case TipoMantenimiento.Nuevo:
                                //vwOrdendeventadet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                                //vwOrdendeventadet.Creationdate = DateTime.Now;
                                break;
                            case TipoMantenimiento.Modificar:
                                //vwOrdendeventadet.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                                //vwOrdendeventadet.Lastmodified = DateTime.Now;
                                break;
                        }

                        vwOrdendeventadet.Calcularitem = item.Calcularitem;

                        sgtItem++;
                        VwOrdendeventadetList.Add(vwOrdendeventadet);
                    }

                    VwCotizacionclienteSel = (VwCotizacioncliente) gvConsulta.GetFocusedRow();
                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarCotizaconesDeVenta();


                    break;
                case "btnCerrar":
                    DialogResult = DialogResult.OK;
                    break;

            }
        }
        private bool ValidacionDatosConsulta()
        {
            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    return true;
                case 1: //Requerimiento
                    var idTipoCel = iIdtipocp.EditValue;

                    if (idTipoCel == null)
                    {
                        XtraMessageBox.Show("Seleccion el tipo de documento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iIdtipocp.Focus();
                        return false;
                    }

                    if (string.IsNullOrEmpty(iNumero.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumero.Focus();
                        return false;
                    }
                    break;
            }

            return true;
        }
        private bool Validaciones()
        {
            if (gvConsulta.RowCount == 0 || gvDetalleImp.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información requerimientos, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    return true;
                case 1: //Requerimiento
                    if (string.IsNullOrEmpty(iNumero.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumero.Focus();
                        return false;                        
                    }      
                    break;
            }

            gvDetalleImp.PostEditor();

            return true;
        }
        private void OrdendeventaImpCotizaFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCotizacionclientedetovimp itemSel = (VwCotizacionclientedetovimp)gvDetalleImp.GetFocusedRow();

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
            CargarDetalleCotizacionDeVenta();
        }
        private void CargarDetalleCotizacionDeVenta()
        {
            VwCotizacioncliente vwCotizacionclienteSel = (VwCotizacioncliente)gvConsulta.GetFocusedRow();

            if (vwCotizacionclienteSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idcotizacioncliente = {0} and saldoaimportar >0", vwCotizacionclienteSel.Idcotizacioncliente);
                _vwCotizacionclientedetovimpList = Service.GetAllVwCotizacionclientedetovimp(where, "numeroitem");


                
                //Actualizar Stock
                foreach (var item in _vwCotizacionclientedetovimpList)
                {
                    item.Stock = Service.ObtenerStockAlmacen(item.Idarticulo, FechaInicialInventario, SessionApp.DateServer, SessionApp.SucursalSel.Idalmacendefecto);
                }

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = _vwCotizacionclientedetovimpList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                rSerie.EditValue = vwTipocp.Seriecp;
                rSerie.Properties.ReadOnly = true;
                iNumero.Focus();
            }
            else
            {
                rSerie.EditValue = @"0000";
                iNumero.EditValue = 0;
            }
        }
        private void iIdsucursal_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            iIdtipocp.Enabled = false;
            rSerie.Enabled = false;
            iNumero.Enabled = false;

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0: //Todos
                    break;
                case 1: //N° Requerimiento de compra
                    iIdtipocp.Enabled = true;
                    rSerie.Enabled = true;
                    iNumero.Enabled = true;
                    iIdtipocp.Focus();
                    break;
            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwCotizacionclientedetovimpList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}
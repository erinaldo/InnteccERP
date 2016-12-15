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
    public partial class CpventaImpOrdenventaFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwOrdendeventa> _vwOrdendeventaList;

        private List<VwTipocp> _vwTipocpsList;

        private List<VwOrdendeventadetcpventaimp> _vwOrdendeventadetcpventaimpList;
        public List<VwCpventadet> VwCpventadetList { get; set; }
        public VwOrdendeventa VwOrdendeventaSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public CpventaImpOrdenventaFrm(List<VwCpventadet> vwCpventadetList, VwSocionegocio vwSocionegocioSel)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwCpventadetList = vwCpventadetList;
            VwSocionegocioSel = vwSocionegocioSel;
        }
        private void CpventaImpOrdenventaFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();

            //Valores por defectto
            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            cboBuscarPor.SelectedIndex = 0; //Todos
        }
        private void CargarReferencias()
        {
            iIdsucursal.Properties.DataSource = Service.GetAllVwSucursal("Nombresucursal");
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDEN-VENTA", (int)iIdsucursal.EditValue);
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

            const string whereNoPendientes = @" idordendeventa 
                                               in (select a.idordendeventa
                                               from ventas.vwordendeventadetcpventaimp a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereCot = string.Format("anulado = '0' and idsucursal = {0} and {1} and idcliente = {2}", (int)iIdsucursal.EditValue, whereNoPendientes, VwSocionegocioSel.Idsocionegocio);
                    break;
                case 1: //Cotizaciones

                    //idestadoreq: 3 (Requerimiento aprobado)

                    whereCot = string.Format(@"idtipocp = {0} and serieordenventa = '{1}'
                        and numeroordenventa = '{2}' and anulado = '0' and idsucursal = {3} and {4} and idcliente = {5}",
                        (int)iIdtipocp.EditValue,
                        rSerie.Text.Trim(),
                        iNumero.Text.Trim(),
                        (int)iIdsucursal.EditValue,
                        whereNoPendientes,
                        VwSocionegocioSel.Idsocionegocio);
                    break;
            }


            _vwOrdendeventaList = Service.GetAllVwOrdendeventa(whereCot, "abreviaturatipoformato,serieordenventa,numeroordenventa");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwOrdendeventaList;
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

                    var maxItem = VwCpventadetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in _vwOrdendeventadetcpventaimpList.Where(x => x.Itemseleccionado))
                    {
                        VwCpventadet vwCpventadet = new VwCpventadet();
                        vwCpventadet.Numeroitem = sgtItem;
                        vwCpventadet.Idarticulo = item.Idarticulo;
                        vwCpventadet.Codigoarticulo = item.Codigoarticulo;
                        vwCpventadet.Codigoproveedor = item.Codigoproveedor;
                        vwCpventadet.Idunidadmedida = item.Idunidadmedida;
                        vwCpventadet.Nombremarca = item.Nombremarca;
                        vwCpventadet.Nombrearticulo = item.Nombrearticulo;
                        vwCpventadet.Cantidad = item.Cantidadaimportar;
                        vwCpventadet.Idunidadmedida = item.Idunidadmedida;
                        vwCpventadet.Abrunidadmedida = item.Abrunidadmedida;
                        vwCpventadet.Preciounitario = item.Preciounitario;
                        vwCpventadet.Especificacion = item.Especificacion;
                        vwCpventadet.Descuento1 = item.Descuento1;
                        vwCpventadet.Descuento2 = item.Descuento2;
                        vwCpventadet.Descuento3 = item.Descuento3;
                        vwCpventadet.Descuento4 = item.Descuento4;
                        vwCpventadet.Preciounitarioneto = item.Preciounitarioneto;
                        vwCpventadet.Importetotal = item.Importetotal;
                        vwCpventadet.Idimpuesto = item.Idimpuesto;
                        vwCpventadet.Idcentrodecosto = item.Idcentrodecosto;
                        vwCpventadet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwCpventadet.Porcentajepercepcion = item.Porcentajepercepcion;
                        vwCpventadet.Idarea = item.Idarea;
                        vwCpventadet.Nombrearea = item.Nombrearea;
                        vwCpventadet.Idproyecto = item.Idproyecto;
                        vwCpventadet.Nombreproyecto = item.Nombreproyecto;
                        vwCpventadet.Idordendeventadet = item.Idordendeventadet;
                        vwCpventadet.Serienumeroordenventa = item.Serienumeroordenventa;
                        vwCpventadet.Idalmacen = item.Idalmacen;
                        vwCpventadet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                        vwCpventadet.Gravado = item.Gravado;
                        vwCpventadet.Exonerado = item.Exonerado;
                        vwCpventadet.Inafecto = item.Inafecto;
                        vwCpventadet.Calcularitem = item.Calcularitem;

                        vwCpventadet.DataEntityState = DataEntityState.Added;

                        TipoMnt = vwCpventadet.Idordendeventadet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
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

                        sgtItem++;
                        VwCpventadetList.Add(vwCpventadet);
                    }

                    VwOrdendeventaSel = (VwOrdendeventa) gvConsulta.GetFocusedRow();
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

            return true;
        }
        private void CpventaImpOrdenventaFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwOrdendeventadetcpventaimp itemSel = (VwOrdendeventadetcpventaimp)gvDetalleImp.GetFocusedRow();

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
            CargarDetalleOrdenDeVenta();
        }
        private void CargarDetalleOrdenDeVenta()
        {
            VwOrdendeventa vwOrdendeventaSel = (VwOrdendeventa)gvConsulta.GetFocusedRow();

            if (vwOrdendeventaSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idordendeventa = {0} and saldoaimportar >0", vwOrdendeventaSel.Idordendeventa);
                _vwOrdendeventadetcpventaimpList = Service.GetAllVwOrdendeventadetcpventaimp(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = _vwOrdendeventadetcpventaimpList;
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
            foreach (var item in _vwOrdendeventadetcpventaimpList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}
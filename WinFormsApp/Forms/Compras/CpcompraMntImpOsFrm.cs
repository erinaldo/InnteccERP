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
    public partial class CpcompraMntImpOsFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwOrdenservicio> _vwOrdencompraList;

        private List<VwTipocp> _vwTipocpsList;

        private List<VwOrdenserviciodetcpcompraimp> _vwOrdenserviciodetcpcompraimpList;
        public List<VwCpcompradet> VwCpcompradetList { get; set; }
        public VwOrdenservicio VwOrdenservicioSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public CpcompraMntImpOsFrm(List<VwCpcompradet> vwCpcompradetList, VwSocionegocio vwSocionegocioSel)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwCpcompradetList = vwCpcompradetList;
            VwSocionegocioSel = vwSocionegocioSel;
        }
        private void CpcompraMntImpOsFrm_Load(object sender, EventArgs e)
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

            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "ORDENCOMPRA", (int)iIdsucursal.EditValue);
            _vwTipocpsList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp,seriecp");
            iIdtipocp.Properties.DataSource = _vwTipocpsList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarOrdenesDeServicio()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;
            string whereReq = string.Empty;

            const string whereNoPendientes = @" idordenservicio
                                               in (select a.idordenservicio
                                               from compras.vwordenserviciodetcpcompraimp a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereReq = string.Format("anulado = '0' and idsucursal = {0} and {1} and idproveedor = {2}", (int)iIdsucursal.EditValue, whereNoPendientes,VwSocionegocioSel.Idsocionegocio);
                    break;
                case 1: //Requerimiento

                    //idestadoreq: 3 (Requerimiento aprobado)

                    whereReq = string.Format(@"idtipocp = {0} and serieorden = '{1}'
                        and numeroorden = '{2}' and anulado = '0' and idsucursal = {3} and {4} and idproveedor = {5}",
                        (int)iIdtipocp.EditValue,
                        rSeriereq.Text.Trim(),
                        iNumeroreq.Text.Trim(),
                        (int)iIdsucursal.EditValue,
                        whereNoPendientes,
                        VwSocionegocioSel.Idsocionegocio);
                    break;
            }


            _vwOrdencompraList = Service.GetAllVwOrdenservicio(whereReq, "abreviaturatipoformato,serieorden,numeroorden");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwOrdencompraList;
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

                    var maxItem = VwCpcompradetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in _vwOrdenserviciodetcpcompraimpList.Where(x => x.Itemseleccionado))
                    {
                        VwCpcompradet vwCpcompradet = new VwCpcompradet();
                        vwCpcompradet.Numeroitem = sgtItem;
                        vwCpcompradet.Idarticulo = item.Idarticulo;
                        vwCpcompradet.Codigoarticulo = item.Codigoarticulo;
                        vwCpcompradet.Codigoproveedor = item.Codigoproveedor;
                        vwCpcompradet.Idunidadinventario = item.Idunidadmedida;
                        vwCpcompradet.Nombremarca = item.Nombremarca;
                        vwCpcompradet.Nombrearticulo = item.Nombrearticulo;
                        vwCpcompradet.Cantidad = item.Cantidadaimportar;
                        vwCpcompradet.Idunidadmedida = item.Idunidadmedida;
                        vwCpcompradet.Abrunidadmedida = item.Abrunidadmedida;
                        vwCpcompradet.Preciounitario = item.Preciounitario;
                        vwCpcompradet.Especificacion = item.Especificacion;
                        vwCpcompradet.Descuento1 = 0;
                        vwCpcompradet.Descuento2 = 0;
                        vwCpcompradet.Descuento3 = 0;
                        vwCpcompradet.Descuento4 = 0;
                        vwCpcompradet.Preciounitarioneto = 0;
                        vwCpcompradet.Importetotal = 0;
                        vwCpcompradet.Pesounitario = item.Pesoarticulo;
                        vwCpcompradet.Pesototal = item.Cantidadaimportar * item.Pesoarticulo;
                        vwCpcompradet.Idimpuesto = item.Idimpuesto;

                        vwCpcompradet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                        vwCpcompradet.Gravado = item.Gravado;
                        vwCpcompradet.Exonerado = item.Exonerado;
                        vwCpcompradet.Inafecto = item.Inafecto;
                        vwCpcompradet.Exportacion = item.Exportacion;

                        vwCpcompradet.Idcentrodecosto = item.Idcentrodecosto;
                        vwCpcompradet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwCpcompradet.Porcentajepercepcion = 0;
                        vwCpcompradet.Idarea = item.Idarea;
                        vwCpcompradet.Nombrearea = item.Nombrearea;
                        vwCpcompradet.Idproyecto = item.Idproyecto;
                        vwCpcompradet.Nombreproyecto = item.Nombreproyecto;
                        vwCpcompradet.Idordenserviciodet = item.Idordenserviciodet;
                        vwCpcompradet.Serienumeroordenservicio = item.Serienumeroorden;

                        vwCpcompradet.Calcularitem = true;

                        vwCpcompradet.DataEntityState = DataEntityState.Added;

                        TipoMnt = vwCpcompradet.Idordencompradet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
                        switch (TipoMnt)
                        {
                            case TipoMantenimiento.Nuevo:
                                vwCpcompradet.Createdby = SessionApp.UsuarioSel.Idusuario;
                                vwCpcompradet.Creationdate = DateTime.Now;
                                break;
                            case TipoMantenimiento.Modificar:
                                vwCpcompradet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                                vwCpcompradet.Lastmodified = DateTime.Now;
                                break;
                        }

                        sgtItem++;
                        VwCpcompradetList.Add(vwCpcompradet);
                    }

                    VwOrdenservicioSel = (VwOrdenservicio) gvConsulta.GetFocusedRow();
                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarOrdenesDeServicio();


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

                    if (string.IsNullOrEmpty(iNumeroreq.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumeroreq.Focus();
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
                    if (string.IsNullOrEmpty(iNumeroreq.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumeroreq.Focus();
                        return false;                        
                    }      
                    break;
            }

            return true;
        }
        private void CpcompraMntImpOsFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwOrdenserviciodetcpcompraimp itemSel = (VwOrdenserviciodetcpcompraimp)gvDetalleImp.GetFocusedRow();

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
            CargarDetalleOrdenDeCompra();
        }
        private void CargarDetalleOrdenDeCompra()
        {
            VwOrdenservicio vwOrdenservicioSel = (VwOrdenservicio)gvConsulta.GetFocusedRow();

            if (vwOrdenservicioSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idordenservicio = {0} and saldoaimportar >0", vwOrdenservicioSel.Idordenservicio);
                _vwOrdenserviciodetcpcompraimpList = Service.GetAllVwOrdenserviciodetcpcompraimp(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = _vwOrdenserviciodetcpcompraimpList;
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
                rSeriereq.EditValue = vwTipocp.Seriecp;
                rSeriereq.Properties.ReadOnly = true;
                iNumeroreq.Focus();
            }
            else
            {
                rSeriereq.EditValue = @"0000";
                iNumeroreq.EditValue = 0;
            }
        }
        private void iIdsucursal_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void cboBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            iIdtipocp.Enabled = false;
            rSeriereq.Enabled = false;
            iNumeroreq.Enabled = false;

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0: //Todos
                    break;
                case 1: //N° Requerimiento de compra
                    iIdtipocp.Enabled = true;
                    rSeriereq.Enabled = true;
                    iNumeroreq.Enabled = true;
                    iIdtipocp.Focus();
                    break;
            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwOrdenserviciodetcpcompraimpList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}
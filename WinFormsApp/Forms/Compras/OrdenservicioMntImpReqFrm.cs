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
    public partial class OrdenservicioMntImpReqFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwRequerimiento> _vwRequerimientoList;
        public VwRequerimiento VwRequerimientoSel { get; set; }

        private List<VwTipocp> _vwTipocpsList;
        private List<VwRequerimientodetordservicioimp> VwRequerimientodetordservicioimpList { get; set; }
        public List<VwOrdenserviciodet> VwOrdenserviciodetList { get; set; }
        private List<VwSucursal> VwSucursalList { get; set; }
        public OrdenservicioMntImpReqFrm(List<VwOrdenserviciodet> vwOrdenserviciodetList)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwOrdenserviciodetList = vwOrdenserviciodetList;
        }
        private void OrdenservicioMntImpReqFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();

            //Valores por defectto
            //iIdsucursal.EditValue = UsuarioAutenticado.SucursalSel.Idsucursal;
            iIdsucursal.EditValue = 0;

            cboBuscarPor.SelectedIndex = 0; //Todos
        }
        private void CargarReferencias()
        {
            VwSucursalList = Service.GetAllVwSucursal("Nombresucursal");
            VwSucursal vwSucursal = new VwSucursal {
                Idsucursal = 0
                ,Codigosucursal  = "000"
                ,Nombresucursal = "(TODAS LAS SUCURSALES)"};

            VwSucursalList.Add(vwSucursal);

            iIdsucursal.Properties.DataSource = VwSucursalList;
            iIdsucursal.Properties.DisplayMember = "Nombresucursal";
            iIdsucursal.Properties.ValueMember = "Idsucursal";
            iIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            //iIdsucursal.EditValue = UsuarioAutenticado.SucursalSel.Idsucursal;
            //iIdsucursal.EditValue = 0;


        }
        private void CargarRequerimientos()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;
            string whereReq = string.Empty;

            const string whereNoPendientes = @" idrequerimiento 
                                               IN (SELECT a.idrequerimiento
                                               FROM compras.vwrequerimientodetordservicioimp a 
                                               WHERE a.anulado = '0' AND a.saldoaimportar > 0
                                               AND idrequerimiento NOT IN 
                                               (SELECT DISTINCT b.idrequerimiento 
                                               FROM compras.vwcotizacionprvdet b
                                               WHERE anulado = '0'))";

            var idSucursalSel = iIdsucursal.EditValue;

            var whereSucursal = idSucursalSel == null || (int) idSucursalSel == 0
                ? string.Empty
                : string.Format(" and idsucursal = {0}", (int) idSucursalSel);

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereReq = string.Format("idestadoreq = 3 and generasalida = '0' and tieneordenservicio = '1' and anulado = '0' {0} and {1}", whereSucursal, whereNoPendientes);
                    break;
                case 1: //Requerimiento

                    //idestadoreq: 3 (Requerimiento aprobado)

                    whereReq = string.Format(@"idtipocp = {0} and seriereq = '{1}'
                        and numeroreq = '{2}' and idestadoreq = 3 and generasalida = '0' and tieneordenservicio = '1' and anulado = '0' {3} and {4}",
                        (int)iIdtipocp.EditValue,                        
                        rSeriereq.Text.Trim(),
                        iNumeroreq.Text.Trim(),
                        whereSucursal,
                        whereNoPendientes);
                    break;
            }


            _vwRequerimientoList = Service.GetAllVwRequerimiento(whereReq, "nombretipoformato,seriereq,numeroreq");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwRequerimientoList;
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

                    var maxItem = VwOrdenserviciodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;
                    
                    foreach (var item in VwRequerimientodetordservicioimpList.Where(x => x.Itemseleccionado))
                    {
                        VwOrdenserviciodet vwOrdenserviciodet = new VwOrdenserviciodet();
                        vwOrdenserviciodet.Numeroitem = sgtItem;
                        vwOrdenserviciodet.Idarticulo = item.Idarticulo;
                        vwOrdenserviciodet.Codigoarticulo = item.Codigoarticulo;
                        vwOrdenserviciodet.Codigoproveedor = item.Codigoproveedor;
                        vwOrdenserviciodet.Idunidadinventario = item.Idunidadmedida;
                        vwOrdenserviciodet.Nombremarca = item.Nombremarca;
                        vwOrdenserviciodet.Nombrearticulo = item.Nombrearticulo;
                        vwOrdenserviciodet.Cantidad = item.Cantidadaimportar;
                        vwOrdenserviciodet.Idunidadmedida = item.Idunidadmedida;
                        vwOrdenserviciodet.Abrunidadmedida = item.Abrunidadmedida;
                        vwOrdenserviciodet.Preciounitario = item.Preciounitario;
                        vwOrdenserviciodet.Especificacion = item.Especificacion;
                        vwOrdenserviciodet.Descuento1 = 0m;
                        vwOrdenserviciodet.Descuento2 = 0m;
                        vwOrdenserviciodet.Descuento3 = 0m;
                        vwOrdenserviciodet.Descuento4 = 0m;
                        vwOrdenserviciodet.Preciounitarioneto = 0m;
                        vwOrdenserviciodet.Importetotal = 0m;
                        vwOrdenserviciodet.Pesoarticulo = item.Pesoarticulo;
                        vwOrdenserviciodet.Pesototalkg = Math.Round(vwOrdenserviciodet.Cantidad*vwOrdenserviciodet.Pesoarticulo, 2);
                        vwOrdenserviciodet.Idimpuesto = item.Idimpuesto;

                        vwOrdenserviciodet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                        vwOrdenserviciodet.Gravado = item.Gravado;
                        vwOrdenserviciodet.Exonerado = item.Exonerado;
                        vwOrdenserviciodet.Inafecto = item.Inafecto;
                        vwOrdenserviciodet.Exportacion = item.Exportacion;

                        vwOrdenserviciodet.Idcentrodecosto = item.Idcentrodecosto;
                        vwOrdenserviciodet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwOrdenserviciodet.Porcentajepercepcion = 0m;
                        vwOrdenserviciodet.Idarea = item.Idarea;
                        vwOrdenserviciodet.Nombrearea = item.Nombrearea;
                        vwOrdenserviciodet.Idproyecto = item.Idproyecto;
                        vwOrdenserviciodet.Nombreproyecto = item.Nombreproyecto;
                        vwOrdenserviciodet.Idrequerimientodet = item.Idrequerimientodet;
                        vwOrdenserviciodet.Serienumeroreq = item.Serienumeroreq;
                        vwOrdenserviciodet.Codigocptooperacion = item.Codigocptooperacion;
                        vwOrdenserviciodet.Nombrecptooperacion = item.Nombrecptooperacion;
                        vwOrdenserviciodet.DataEntityState = DataEntityState.Added;

                        TipoMnt = vwOrdenserviciodet.Idordenserviciodet <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
                        switch (TipoMnt)
                        {
                            case TipoMantenimiento.Nuevo:
                                vwOrdenserviciodet.Createdby = SessionApp.UsuarioSel.Idusuario;
                                vwOrdenserviciodet.Creationdate = DateTime.Now;
                                break;
                            case TipoMantenimiento.Modificar:
                                vwOrdenserviciodet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                                vwOrdenserviciodet.Lastmodified = DateTime.Now;
                                break;
                        }


                        sgtItem++;
                        VwOrdenserviciodetList.Add(vwOrdenserviciodet);

                        VwRequerimientoSel = (VwRequerimiento) gvConsulta.GetFocusedRow();
                    }


                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarRequerimientos();
                    break;
                case "btnCerrar":
                    DialogResult = DialogResult.Cancel;
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

            int cantidadItemsSeleccionados = VwRequerimientodetordservicioimpList.Count(x => x.Itemseleccionado);
            if (cantidadItemsSeleccionados == 0)
            {
                XtraMessageBox.Show("Debe seleccionar los items a importar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void OrdenservicioMntImpReqFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwRequerimientodetordservicioimp itemSel = (VwRequerimientodetordservicioimp)gvDetalleImp.GetFocusedRow();

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
            CargarDetalleRequerimiento();
        }
        private void CargarDetalleRequerimiento()
        {
            VwRequerimiento vwRequerimientoSel = (VwRequerimiento)gvConsulta.GetFocusedRow();

            if (vwRequerimientoSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idrequerimiento = {0} and saldoaimportar > 0 and aprobado = '1'", vwRequerimientoSel.Idrequerimiento);
                VwRequerimientodetordservicioimpList = Service.GetAllVwRequerimientodetordservicioimp(where, "numeroitem");

                foreach (var itemReq in VwRequerimientodetordservicioimpList)
                {
                    var totalCantidadImporta = VwOrdenserviciodetList.Where(x =>
                        x.Idarticulo == itemReq.Idarticulo 
                        && x.Idrequerimientodet == itemReq.Idrequerimientodet
                        && x.DataEntityState != DataEntityState.Deleted).Sum(x => x.Cantidad);
                    if (totalCantidadImporta > 0)
                    {
                        itemReq.Cantidadimportada = totalCantidadImporta;
                        itemReq.Saldoaimportar = itemReq.Cantidad - itemReq.Cantidadimportada;
                    }

                }

                var itemsARemover = VwRequerimientodetordservicioimpList.Where(x => x.Saldoaimportar <= 0).ToList();
                foreach (var itemToRemove in itemsARemover)
                {
                    VwRequerimientodetordservicioimpList.Remove(itemToRemove);
                }

                //Borrar 

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = VwRequerimientodetordservicioimpList;
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
            foreach (var item in VwRequerimientodetordservicioimpList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
        private void iIdsucursal_EditValueChanged(object sender, EventArgs e)
        {
            var idSucursal = iIdsucursal.EditValue;
            if (idSucursal != null && (int) idSucursal > 0)
            {
                cboBuscarPor.Enabled = true;
                iIdtipocp.Enabled = true;
                iNumeroreq.Enabled = true;

                string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "REQUERIMIENTO", (int)idSucursal);
                _vwTipocpsList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp,seriecp");
                iIdtipocp.Properties.DataSource = _vwTipocpsList;
                iIdtipocp.Properties.DisplayMember = "Nombretipocp";
                iIdtipocp.Properties.ValueMember = "Idtipocp";
                iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
            }
            else
            {

                cboBuscarPor.Enabled = false;
                iIdtipocp.Enabled = false;                
                iNumeroreq.Enabled = false;

            }
        }
    }
}
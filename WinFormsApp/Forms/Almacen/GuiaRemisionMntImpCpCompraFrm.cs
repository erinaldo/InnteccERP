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
    public partial class GuiaRemisionMntImpCpCompraFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwCpcompra> _vwCpcompraList;
        public VwCpcompra VwCpcompraSel { get; set; }
        private List<VwCpcompradetguiaremisionimp> VwCpcompradetguiaremisionimpList { get; set; }
        public List<VwGuiaremisiondet> VwGuiaremisiondetList { get; set; }
        private List<VwSucursal> VwSucursalList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public int IdTipoMoneda { get; set; }
        public GuiaRemisionMntImpCpCompraFrm(List<VwGuiaremisiondet> vwGuiaremisiondetList, VwSocionegocio vwSocionegocioSel, int idTipoMoneda)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwGuiaremisiondetList = vwGuiaremisiondetList;
            VwSocionegocioSel = vwSocionegocioSel;
            IdTipoMoneda = idTipoMoneda;
        }
        private void GuiaRemisionMntImpCpCompraFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            iIdsucursal.EditValue = 0;
            beSocioNegocio.Text = VwSocionegocioSel.Razonsocial;

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

        }
        private void CargarCpCompra()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;

            const string whereNoPendientes = @" idcpcompra
                                               in (select a.idcpcompra
                                               from compras.vwcpcompradetguiaremisionimp a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";

            var idSucursalSel = iIdsucursal.EditValue;

            var whereSucursal = idSucursalSel == null || (int) idSucursalSel == 0
                ? string.Empty
                : string.Format(" and idsucursal = {0}", (int) idSucursalSel);

            var whereCpCompra = string.Format("anulado = '0' {0} and {1} and idproveedor = {2} and idtipomoneda = {3}"
                , whereSucursal
                , whereNoPendientes
                , VwSocionegocioSel.Idsocionegocio
                , IdTipoMoneda);

            _vwCpcompraList = Service.GetAllVwCpcompra(whereCpCompra, "nombretipoformato,seriecpcompra,numerocpcompra");



            gcConsulta.DataSource = _vwCpcompraList;


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

                    var maxItem = VwGuiaremisiondetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in VwCpcompradetguiaremisionimpList.Where(x => x.Itemseleccionado))
                    {
                        VwGuiaremisiondet vwGuiaremisiondet = new VwGuiaremisiondet();

                        vwGuiaremisiondet.Numeroitem = sgtItem;
                        vwGuiaremisiondet.Idarticulo = item.Idarticulo;
                        vwGuiaremisiondet.Codigoarticulo = item.Codigoarticulo;
                        vwGuiaremisiondet.Codigoproveedor = item.Codigoproveedor;
                        vwGuiaremisiondet.Idunidadinventario = item.Idunidadmedida;
                        vwGuiaremisiondet.Nombremarca = item.Nombremarca;
                        vwGuiaremisiondet.Nombrearticulo = item.Nombrearticulo;
                        vwGuiaremisiondet.Cantidad = item.Cantidadaimportar;
                        vwGuiaremisiondet.Idunidadmedida = item.Idunidadmedida;
                        vwGuiaremisiondet.Abrunidadmedida = item.Abrunidadmedida;
                        vwGuiaremisiondet.Preciounitario = item.Preciounitario;
                        vwGuiaremisiondet.Especificacion = item.Especificacion;
                        vwGuiaremisiondet.Importetotal = Math.Round(item.Preciounitario * item.Cantidadaimportar,2);
                        vwGuiaremisiondet.Pesounitario = 0m;
                        vwGuiaremisiondet.Pesototal = Math.Round(vwGuiaremisiondet.Cantidad * vwGuiaremisiondet.Pesounitario, 2);
                        vwGuiaremisiondet.Idimpuesto = item.Idimpuesto;
                        vwGuiaremisiondet.Idcentrodecosto = item.Idcentrodecosto;
                        vwGuiaremisiondet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwGuiaremisiondet.Porcentajepercepcion = 0;
                        vwGuiaremisiondet.Idarea = item.Idarea;
                        vwGuiaremisiondet.Nombrearea = item.Nombrearea;
                        vwGuiaremisiondet.Idproyecto = item.Idproyecto;
                        vwGuiaremisiondet.Nombreproyecto = item.Nombreproyecto;
                        vwGuiaremisiondet.Idrequerimientodet = null;
                        vwGuiaremisiondet.Serienumeroreq = string.Empty;
                        vwGuiaremisiondet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                        vwGuiaremisiondet.Gravado = item.Gravado;
                        vwGuiaremisiondet.Exonerado = item.Exonerado;
                        vwGuiaremisiondet.Inafecto = item.Inafecto;
                        vwGuiaremisiondet.Exportacion = item.Exportacion;
                        vwGuiaremisiondet.Idordendeventadet = null;
                        vwGuiaremisiondet.Serienumeroordenventa = null;
                        vwGuiaremisiondet.Calcularitem = item.Calcularitem;

                        vwGuiaremisiondet.Idcpcompradet = item.Idcpcompradet;
                        vwGuiaremisiondet.Serienumerocpcompra = item.Formatoserienumerocpcompra; //item.Serienumerocp;

                        vwGuiaremisiondet.DataEntityState = DataEntityState.Added;

                        TipoMnt = vwGuiaremisiondet.Idrequerimientodet  <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;

                        //switch (TipoMnt)
                        //{
                            //case TipoMantenimiento.Nuevo:
                            //    vwGuiaremisiondet.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //    vwGuiaremisiondet.Creationdate = DateTime.Now;
                            //    break;
                            //case TipoMantenimiento.Modificar:
                            //    vwGuiaremisiondet.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //    vwGuiaremisiondet.Lastmodified = DateTime.Now;
                            //    break;
                        //}


                        sgtItem++;
                        VwGuiaremisiondetList.Add(vwGuiaremisiondet);

                        VwCpcompraSel = (VwCpcompra)gvConsulta.GetFocusedRow();
                    }


                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    CargarCpCompra();
                    break;
                case "btnCerrar":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }       
        private bool Validaciones()
        {
            if (gvConsulta.RowCount == 0 || gvDetalleImp.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información de comprobante de compra, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }        
            return true;
        }
        private void GuiaRemisionMntImpCpCompraFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpcompradetguiaremisionimp itemSel = (VwCpcompradetguiaremisionimp)gvDetalleImp.GetFocusedRow();

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
            CargarDetalleCpCompra();
        }
        private void CargarDetalleCpCompra()
        {
            VwCpcompra vwCpcompra = (VwCpcompra)gvConsulta.GetFocusedRow();

            if (vwCpcompra != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idcpcompra = {0} and saldoaimportar > 0 ", vwCpcompra.Idcpcompra);
                VwCpcompradetguiaremisionimpList = Service.GetAllVwCpcompradetguiaremisionimp(where, "numeroitem");


                //foreach (var itemReq in VwRequerimientodetordcompraimpList)
                //{
                //    var totalCantidadImporta = VwGuiaremisiondetList.Where(x =>
                //        x.Idarticulo == itemReq.Idarticulo 
                //        && x.Idrequerimientodet == itemReq.Idrequerimientodet
                //        && x.DataEntityState != DataEntityState.Deleted).Sum(x => x.Cantidad);
                //    if (totalCantidadImporta > 0)
                //    {
                //        itemReq.Cantidadimportada = totalCantidadImporta;
                //        itemReq.Saldoaimportar = itemReq.Cantidad - itemReq.Cantidadimportada;
                //    }

                //}

                var itemsARemover = VwCpcompradetguiaremisionimpList.Where(x => x.Saldoaimportar <= 0).ToList();
                foreach (var itemToRemove in itemsARemover)
                {
                    VwCpcompradetguiaremisionimpList.Remove(itemToRemove);
                }

                //Borrar 

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = VwCpcompradetguiaremisionimpList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in VwCpcompradetguiaremisionimpList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}
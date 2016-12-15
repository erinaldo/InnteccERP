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
    public partial class NotacreditoImpCpCompraFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwCpcompra> _vwCpcompraList;

        private List<VwCpcompraimpnc> _vwCpcompraimpncList;
        public List<VwNotacreditodet> VwNotacreditodetList { get; set; }
        public VwCpcompra VwCpcompraSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public NotacreditoImpCpCompraFrm(List<VwNotacreditodet> vwNotacreditodetList, VwSocionegocio vwSocionegocioSel)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwNotacreditodetList = vwNotacreditodetList;
            VwSocionegocioSel = vwSocionegocioSel;
        }
        private void NotacreditoImpCpCompraFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            CargarCpCompra();
        }
        private void CargarReferencias()
        {
            rProveedor.EditValue = VwSocionegocioSel.Razonsocial;
            rRuc.EditValue = VwSocionegocioSel.Nrodocentidadprincipal;
        }
        private void CargarCpCompra()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;

            const string whereNoPendientes = @" and idcpcompra 
                                               in (select a.idcpcompra
                                               from compras.vwcpcompraimpnc a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";

            string whereProveedor = string.Format("idproveedor = {0} {1}", VwSocionegocioSel.Idsocionegocio, whereNoPendientes);




            _vwCpcompraList = Service.GetAllVwCpcompra(whereProveedor, "abreviaturatipoformato,seriecpcompra desc,numerocpcompra desc");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwCpcompraList;
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

                    var maxItem = VwNotacreditodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in _vwCpcompraimpncList.Where(x => x.Itemseleccionado))
                    {
                        VwNotacreditodet vwNotacreditodet = new VwNotacreditodet();
                        vwNotacreditodet.Numeroitem = sgtItem;
                        vwNotacreditodet.Idarticulo = item.Idarticulo;
                        vwNotacreditodet.Codigoarticulo = item.Codigoarticulo;
                        vwNotacreditodet.Codigoproveedor = item.Codigoproveedor;
                        vwNotacreditodet.Idunidadinventario = item.Idunidadmedida;
                        vwNotacreditodet.Nombremarca = item.Nombremarca;
                        vwNotacreditodet.Nombrearticulo = item.Nombrearticulo;
                        vwNotacreditodet.Cantidad = item.Cantidadaimportar;
                        vwNotacreditodet.Idunidadmedida = item.Idunidadmedida;
                        vwNotacreditodet.Abrunidadmedida = item.Abrunidadmedida;
                        vwNotacreditodet.Preciounitario = item.Preciounitarioneto;
                        vwNotacreditodet.Especificacion = item.Especificacion;
                        vwNotacreditodet.Descuento1 = 0;
                        vwNotacreditodet.Descuento2 = 0;
                        vwNotacreditodet.Descuento3 = 0;
                        vwNotacreditodet.Descuento4 = 0;
                        vwNotacreditodet.Preciounitarioneto = 0;
                        vwNotacreditodet.Importetotal = 0;
                        vwNotacreditodet.Idimpuesto = item.Idimpuesto;
                        vwNotacreditodet.Idcentrodecosto = item.Idcentrodecosto;
                        vwNotacreditodet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwNotacreditodet.Porcentajepercepcion = 0;
                        vwNotacreditodet.Idarea = item.Idarea;
                        vwNotacreditodet.Nombrearea = item.Nombrearea;
                        vwNotacreditodet.Idproyecto = item.Idproyecto;
                        vwNotacreditodet.Nombreproyecto = item.Nombreproyecto;
                        vwNotacreditodet.Idcpcompradet  = item.Idcpcompradet ;
                        vwNotacreditodet.Serienumerocpcompra = item.Serienumerocp;

                        vwNotacreditodet.DataEntityState = DataEntityState.Added;

                        vwNotacreditodet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwNotacreditodet.Creationdate = DateTime.Now;
                        vwNotacreditodet.Modifiedby = null;
                        vwNotacreditodet.Lastmodified = null;
                        
                        sgtItem++;
                        VwNotacreditodetList.Add(vwNotacreditodet);
                    }

                    VwCpcompraSel = (VwCpcompra)gvConsulta.GetFocusedRow();
                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarCpCompra();


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
                XtraMessageBox.Show("No hay información requerimientos, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }



            return true;
        }
        private void NotacreditoImpCpCompraFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpcompraimpnc itemSel = (VwCpcompraimpnc)gvDetalleImp.GetFocusedRow();

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
            VwCpcompra vwCpcompraSel = (VwCpcompra)gvConsulta.GetFocusedRow();

            if (vwCpcompraSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idcpcompra = {0} and saldoaimportar >0", vwCpcompraSel.Idcpcompra);
                _vwCpcompraimpncList = Service.GetAllVwCpcompraimpnc(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = _vwCpcompraimpncList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwCpcompraimpncList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}
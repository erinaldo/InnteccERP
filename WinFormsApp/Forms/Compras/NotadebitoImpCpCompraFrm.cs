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
    public partial class NotadebitoImpCpCompraFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwCpcompra> _vwCpcompraList;

        private List<VwCpcompraimpnd> _vwCpcompraimpndList;
        public List<VwNotadebitodet> VwNotadebitodetList { get; set; }
        public VwCpcompra VwCpcompraSel { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public NotadebitoImpCpCompraFrm(List<VwNotadebitodet> vwNotadebitodetList, VwSocionegocio vwSocionegocioSel)
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwNotadebitodetList = vwNotadebitodetList;
            VwSocionegocioSel = vwSocionegocioSel;
        }
        private void NotadebitoImpCpCompraFrm_Load(object sender, EventArgs e)
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
                                               from compras.vwcpcompraimpnd a 
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

                    var maxItem = VwNotadebitodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                    .OrderByDescending(t => t.Numeroitem)
                    .FirstOrDefault();

                    var sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    foreach (var item in _vwCpcompraimpndList.Where(x => x.Itemseleccionado))
                    {
                        VwNotadebitodet vwNotadebitodet = new VwNotadebitodet();
                        vwNotadebitodet.Numeroitem = sgtItem;
                        vwNotadebitodet.Idarticulo = item.Idarticulo;
                        vwNotadebitodet.Codigoarticulo = item.Codigoarticulo;
                        vwNotadebitodet.Codigoproveedor = item.Codigoproveedor;
                        vwNotadebitodet.Idunidadinventario = item.Idunidadmedida;
                        vwNotadebitodet.Nombremarca = item.Nombremarca;
                        vwNotadebitodet.Nombrearticulo = item.Nombrearticulo;
                        vwNotadebitodet.Cantidad = item.Cantidadaimportar;
                        vwNotadebitodet.Idunidadmedida = item.Idunidadmedida;
                        vwNotadebitodet.Abrunidadmedida = item.Abrunidadmedida;
                        vwNotadebitodet.Preciounitario = item.Preciounitarioneto;
                        vwNotadebitodet.Especificacion = item.Especificacion;
                        vwNotadebitodet.Descuento1 = 0;
                        vwNotadebitodet.Descuento2 = 0;
                        vwNotadebitodet.Descuento3 = 0;
                        vwNotadebitodet.Descuento4 = 0;
                        vwNotadebitodet.Preciounitarioneto = 0;
                        vwNotadebitodet.Importetotal = 0;
                        vwNotadebitodet.Idimpuesto = item.Idimpuesto;
                        vwNotadebitodet.Idcentrodecosto = item.Idcentrodecosto;
                        vwNotadebitodet.Descripcioncentrodecosto = item.Descripcioncentrodecosto;
                        vwNotadebitodet.Porcentajepercepcion = 0;
                        vwNotadebitodet.Idarea = item.Idarea;
                        vwNotadebitodet.Nombrearea = item.Nombrearea;
                        vwNotadebitodet.Idproyecto = item.Idproyecto;
                        vwNotadebitodet.Nombreproyecto = item.Nombreproyecto;
                        vwNotadebitodet.Idcpcompradet  = item.Idcpcompradet ;
                        vwNotadebitodet.Serienumerocpcompra = item.Serienumerocp;

                        vwNotadebitodet.DataEntityState = DataEntityState.Added;

                        vwNotadebitodet.Createdby = SessionApp.UsuarioSel.Idusuario;
                        vwNotadebitodet.Creationdate = DateTime.Now;
                        vwNotadebitodet.Modifiedby = null;
                        vwNotadebitodet.Lastmodified = null;

                        sgtItem++;
                        VwNotadebitodetList.Add(vwNotadebitodet);
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
        private void NotadebitoImpCpCompraFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpcompraimpnd itemSel = (VwCpcompraimpnd)gvDetalleImp.GetFocusedRow();

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
                _vwCpcompraimpndList = Service.GetAllVwCpcompraimpnd(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = _vwCpcompraimpndList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in _vwCpcompraimpndList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
    }
}
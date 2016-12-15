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
    public partial class EntradaalmacenImpFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();
        public List<VwOrdencompra> VwOrdencompraList { get; set; }
        public List<VwOrdencompradetingresoimp> VwOrdencompradetingresoimpList { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public EntradaalmacenImpFrm(int idEntidadMnt, VwSocionegocio vwSocionegocioSel)
        {

            InitializeComponent();
            IdEntidadMnt = idEntidadMnt;
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwSocionegocioSel = vwSocionegocioSel;
        }
        private void EntradaalmacenImpFrm_Load(object sender, EventArgs e)
        {
            iPersona.Text = VwSocionegocioSel.Razonsocial.Trim();
            iTipoDocNro.Text = string.Format("{0} {1}", VwSocionegocioSel.Abreviaturadocentidad, VwSocionegocioSel.Nrodocentidadprincipal);

            ConsultarDocumentosPendientes();
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnImportar":

                    if (!Validaciones()) return;

                    int sgtItem = 1;

                    //var maxItem = VwOrdencompradetingresoimpList.OrderByDescending(t => t.Numeroitem).FirstOrDefault();

                    //sgtItem = maxItem == null ? 1 : maxItem.Numeroitem + 1;

                    //if (maxItem != null) sgtItem = maxItem.Numeroitem;

                    foreach (var item in VwOrdencompradetingresoimpList.Where(x=>x.Itemseleccionado))
                    {

                        Entradaalmacendet entradaalmacendet = new Entradaalmacendet();
                        entradaalmacendet.Identradaalmacen = IdEntidadMnt;
                        entradaalmacendet.Numeroitem = sgtItem;
                        entradaalmacendet.Idarticulo = item.Idarticulo;
                        entradaalmacendet.Idimpuesto = item.Idimpuesto;
                        entradaalmacendet.Idunidadmedida = item.Idunidadmedida;
                        entradaalmacendet.Especificacion = item.Especificacion;
                        entradaalmacendet.Cantidad = item.Cantidadaimportar;
                        entradaalmacendet.Preciounitario = item.Preciounitarioneto;
                        entradaalmacendet.Importetotal = item.Cantidadaimportar * item.Preciounitario;
                        entradaalmacendet.Idordencompradet = item.Idordencompradet;

                        TipoMnt = entradaalmacendet.Identradaalmacendet  <= 0 ? TipoMantenimiento.Nuevo : TipoMantenimiento.Modificar;
                        switch (TipoMnt)
                        {
                            case TipoMantenimiento.Nuevo:
                                entradaalmacendet.Createdby = SessionApp.UsuarioSel.Idusuario;
                                entradaalmacendet.Creationdate = DateTime.Now;
                                break;
                            case TipoMantenimiento.Modificar:
                                entradaalmacendet.Modifiedby = SessionApp.UsuarioSel.Idusuario;
                                entradaalmacendet.Lastmodified = DateTime.Now;
                                break;
                        }

                        sgtItem++;

                        Service.SaveEntradaalmacendet(entradaalmacendet);

                    }


                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    ConsultarDocumentosPendientes();
                    break;
                case "btnCerrar":
                    DialogResult = DialogResult.OK;
                    break;

            }
        }
        private void ConsultarDocumentosPendientes()
        {
            Cursor = Cursors.WaitCursor;            

            const string whereNoPendientes = @" idordencompra 
                                               in (select a.idordencompra 
                                               from compras.vwordencompradetingresoimp a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";

            var condiciones = string.Format("idproveedor = {0} and {1}", VwSocionegocioSel.Idsocionegocio, whereNoPendientes);          

            VwOrdencompraList = Service.GetAllVwOrdencompra(condiciones, "nombretipoformato,serieorden,numeroorden");

            gcListDoc.BeginUpdate();
            gcListDoc.DataSource = VwOrdencompraList;
            gcListDoc.EndUpdate();

            gvListDoc.BestFitColumns(true);

            Cursor = Cursors.Default;
        }
        private void ConsultarDetalle()
        {
            VwOrdencompra vwOrdencompraSel = (VwOrdencompra)gvListDoc.GetFocusedRow();
            string condicionesDetalle = string.Format("idordencompra = {0} and saldoaimportar > 0", vwOrdencompraSel.Idordencompra);

            VwOrdencompradetingresoimpList = Service.GetAllVwOrdencompradetingresoimp(condicionesDetalle, "numeroitem");

            gcDetalleImp.BeginUpdate();
            gcDetalleImp.DataSource = VwOrdencompradetingresoimpList;
            gcDetalleImp.EndUpdate();
            gvDetalleImp.BestFitColumns(true);
        }
        private bool Validaciones()
        {
            if (gvDetalleImp.RowCount == 0)
            {
                XtraMessageBox.Show("No ha seleccionado items para importar", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return false;
            }

            var cntItemsSelec = VwOrdencompradetingresoimpList.Count(x => x.Itemseleccionado);

            if (VwOrdencompradetingresoimpList == null && cntItemsSelec == 0)
            {
                XtraMessageBox.Show("No ha seleccionado items para importar", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return false;
            }           

            return true;
        }
        private void EntradaalmacenImpFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwOrdencompradetingresoimp itemSel = (VwOrdencompradetingresoimp)gvDetalleImp.GetFocusedRow();

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
        private void gvListDoc_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ConsultarDetalle();
        }
        private void chkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in VwOrdencompradetingresoimpList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }

        
    }
}
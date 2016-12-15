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
    public partial class EntradaalmacenImpCpCompraFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwCpcompra> _vwCpcompraList;
        private List<VwCpcompradetimpentradaalmacen> VwCpcompradetimpentradaalmacenList { get; set; }        
        private List<VwAlmacen> VwAlmacenList { get; set; }
        public Tipodocmov TipodocmovSel { get; set; }
        public Almacen AlmacenSel { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public EntradaalmacenMntFrm EntradaalmacenMntFrm { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public EntradaalmacenImpCpCompraFrm(Tipodocmov tipodocmov, VwSocionegocio vwSocionegocioSel, Almacen almacenSel, EntradaalmacenMntFrm entradaalmacenMntFrm)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipodocmovSel = tipodocmov;
            VwSocionegocioSel = vwSocionegocioSel;
            AlmacenSel = almacenSel;
            EntradaalmacenMntFrm = entradaalmacenMntFrm;
        }
        private void EntradaalmacenImpCpCompraFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            iIdalmacen.EditValue = AlmacenSel.Idalmacen;
            cboBuscarPor.SelectedIndex = 0; //Todos
            iNroDocumento.EditValue = VwSocionegocioSel.Nrodocentidadprincipal;
            iRazonSocial.EditValue = VwSocionegocioSel.Razonsocial;

        }
        private void CargarReferencias()
        {
            VwAlmacenList = Service.GetAllVwAlmacen("Nombrealmacen");
            iIdalmacen.Properties.DataSource = VwAlmacenList;
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;


            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "CPCOMPRA", SessionApp.SucursalSel.Idsucursal);
            VwTipocpList = Service.GetAllVwTipocp(whereTipoCp, "nombretipocp");
            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void CargarDocumentosPendientes()
        {
            gcConsulta.DataSource = null;
            gcDetalleImp.DataSource = null;

            Cursor = Cursors.WaitCursor;
            string whereNumeroOtdenCompra = string.Empty;

            const string whereNoPendientes = @" and idcpcompra 
                                               in (select a.idcpcompra
                                               from almacen.vwcpcompradetimpentradaalmacen a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";          

            string whereSocioNegocio = string.Format(" and idproveedor = {0}", VwSocionegocioSel.Idsocionegocio);

            //string whereAlmacen =  string.Format(" and almacenorigen = {0}",AlmacenSel.Idalmacen);
            string whereAlmacen = string.Empty;

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereNumeroOtdenCompra = string.Format("anulado = '0' and generaentrada = '1' {0} {1} {2}", whereAlmacen, whereSocioNegocio, whereNoPendientes);
                    break;
                case 1: //Orden de compra

                    whereNumeroOtdenCompra = string.Format(@"idtipocp = {0} and seriecpcompra = '{1}'
                        and numerocpcompra = '{2}' and anulado = '0' and generaentrada = '1' {3} {4} {5}",
                        (int)iIdtipocp.EditValue,
                        rSerieDoc.Text.Trim(),
                        iNumeroDoc.Text.Trim(),
                        whereAlmacen,
                        whereSocioNegocio,
                        whereNoPendientes);

                    break;
            }


            _vwCpcompraList = Service.GetAllVwCpcompra(whereNumeroOtdenCompra, "nombretipoformato,seriecpcompra,numerocpcompra");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwCpcompraList;
            gcConsulta.EndUpdate();
            gvConsulta.BestFitColumns();

            Cursor = Cursors.Default;
        }
        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                rSerieDoc.EditValue = vwTipocp.Seriecp;
                rSerieDoc.Properties.ReadOnly = true;
                iNumeroDoc.Focus();
            }
            else
            {
                rSerieDoc.EditValue = @"0000";
                iNumeroDoc.EditValue = 0;
            }
        }
        public void CargarDetalle()
        {
            VwCpcompra vwCpcompraSel = (VwCpcompra)gvConsulta.GetFocusedRow();

            if (vwCpcompraSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idcpcompra = {0} and saldoaimportar > 0", vwCpcompraSel.Idcpcompra);
                VwCpcompradetimpentradaalmacenList = Service.GetAllVwCpcompradetimpentradaalmacen(where, "numeroitem");

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = VwCpcompradetimpentradaalmacenList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private Entradaalmacendet AsignarEntradaAlmacenDetalle(VwCpcompradetimpentradaalmacen vwCpcompradetimpentradaalmacen)
        {
            Entradaalmacendet entradaalmacendetMnt = new Entradaalmacendet
            {
                Identradaalmacen = EntradaalmacenMntFrm.IdEntidadMnt,
                Numeroitem = vwCpcompradetimpentradaalmacen.Numeroitem,
                Idarticulo = vwCpcompradetimpentradaalmacen.Idarticulo,
                Idimpuesto = vwCpcompradetimpentradaalmacen.Idimpuesto,
                Idunidadmedida = vwCpcompradetimpentradaalmacen.Idunidadmedida,
                Especificacion = vwCpcompradetimpentradaalmacen.Especificacion,
                Cantidad = vwCpcompradetimpentradaalmacen.Cantidadaimportar,
                Preciounitario = vwCpcompradetimpentradaalmacen.Preciounitario,
                Importetotal = Math.Round(vwCpcompradetimpentradaalmacen.Cantidadaimportar * vwCpcompradetimpentradaalmacen.Preciounitarioneto,2),
                Idproyecto = vwCpcompradetimpentradaalmacen.Idproyecto,
                Idarea = vwCpcompradetimpentradaalmacen.Idarea,
                Idcentrodecosto = vwCpcompradetimpentradaalmacen.Idcentrodecosto,
                Porcentajepercepcion = vwCpcompradetimpentradaalmacen.Porcentajepercepcion,
                Idtipoafectacionigv = vwCpcompradetimpentradaalmacen.Idtipoafectacionigv,
                Idcpcompradet = vwCpcompradetimpentradaalmacen.Idcpcompradet,
                Calcularitem = vwCpcompradetimpentradaalmacen.Calcularitem
            };
            return entradaalmacendetMnt;
        }      
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            
            switch (e.Item.Name)
            {
                case "btnImportar":

                    if (!Validaciones()) return;

                    if (EntradaalmacenMntFrm.IdEntidadMnt == 0)
                    {
                        if (!EntradaalmacenMntFrm.Validaciones()) return;

                        string numeroDoc = string.Format("{0} {1}-{2}", EntradaalmacenMntFrm.iIdtipocp.Text.Trim(), EntradaalmacenMntFrm.rSerieentradaalmacen.Text.Trim(), EntradaalmacenMntFrm.rNumeroentradaalmacen.Text.Trim());
                        if (DialogResult.No == XtraMessageBox.Show(string.Format("¿Desea guardar el documento {0}?", numeroDoc),
                            "Atención", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            return;
                        }
                        VwCpcompra vwCpcompraSel = (VwCpcompra)gvConsulta.GetFocusedRow();

                        //Asignar los controles de entrada a almacen desde la orden de compra seleccionada
                        EntradaalmacenMntFrm.iIdtipomoneda.EditValue = vwCpcompraSel.Idtipomoneda;
                        EntradaalmacenMntFrm.iIdtipomoneda.ReadOnly = true;
                        EntradaalmacenMntFrm.iIncluyeimpuestoitems.EditValue = vwCpcompraSel.Incluyeimpuestoitems;
                        EntradaalmacenMntFrm.iTipocambio.EditValue = vwCpcompraSel.Tipocambio;

                        //Asignar la propiedad del documento de referencia

                        EntradaalmacenMntFrm.EntradaalmacenMnt.Idcpcompra = vwCpcompraSel.Idcpcompra;
                        if (EntradaalmacenMntFrm.Guardar())
                        {
                            EntradaalmacenMntFrm.DeshabilitarModificacion();
                        }

                    }

                    if (EntradaalmacenMntFrm.IdEntidadMnt > 0)
                    {
                        foreach (var item in VwCpcompradetimpentradaalmacenList.Where(x => x.Itemseleccionado))
                        {
                            Entradaalmacendet entradaalmacendetMnt = AsignarEntradaAlmacenDetalle(item);

                            int identradaalmacendet = Service.SaveEntradaalmacendet(entradaalmacendetMnt);
                            if (identradaalmacendet > 0)
                            {
                                //Verificar las ubicacion registradas por articulo
                                long cantidadRefUbicaciones = Service.CountVwArticuloubicacion(
                                    x => x.Idarticulo == entradaalmacendetMnt.Idarticulo
                                    && x.Idalmacen == (int)iIdalmacen.EditValue);

                                if (cantidadRefUbicaciones == 0)
                                {
                                    //Insertar ubicacion por defecto
                                    Entradaalmacenubicacion entradaalmacenubicacion = new Entradaalmacenubicacion
                                    {
                                        Identradaalmacendet = identradaalmacendet,
                                        Idubicacion = AlmacenSel.Idubicaciondefecto,
                                        Cantidadarticulo = entradaalmacendetMnt.Cantidad
                                    };
                                    Service.SaveEntradaalmacenubicacion(entradaalmacenubicacion);
                                }
                                else
                                {
                                    //Insertar la ubicaciones del articulo del almacen seleccionado
                                    List<VwArticuloubicacion> vwArticuloubicacionList = Service.GetAllVwArticuloubicacion(
                                        x => x.Idarticulo == entradaalmacendetMnt.Idarticulo
                                        && x.Idalmacen == (int)iIdalmacen.EditValue);

                                    foreach (var vwArticuloubicacion in vwArticuloubicacionList)
                                    {
                                        Entradaalmacenubicacion entradaalmacenubicacion = new Entradaalmacenubicacion
                                        {
                                            Identradaalmacendet = identradaalmacendet,
                                            Idubicacion = vwArticuloubicacion.Idubicacion,
                                            Cantidadarticulo = 0m
                                        };
                                        Service.SaveEntradaalmacenubicacion(entradaalmacenubicacion);
                                    }
                                }
                            }
                        }

                        EntradaalmacenMntFrm.CargarDetalle();
                        EntradaalmacenMntFrm.CargarDocumentoReferencia();
                    }

                    DialogResult = DialogResult.OK;

                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;
                case "btnConsultar":
                    if (!ValidacionDatosConsulta()) return;
                    CargarDocumentosPendientes();


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

                    if (string.IsNullOrEmpty(iNumeroDoc.Text))
                    {
                        XtraMessageBox.Show("Ingrese el numero de requerimiento.", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        iNumeroDoc.Focus();
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
                XtraMessageBox.Show("No hay información de ordenes de compra, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            int cantidadItemsSeleccionados = VwCpcompradetimpentradaalmacenList.Count(x => x.Itemseleccionado);
            if (cantidadItemsSeleccionados == 0)
            {
                XtraMessageBox.Show("Debe seleccionar los items a importar", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void EntradaalmacenImpCpCompraFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwCpcompradetimpentradaalmacen itemSel = (VwCpcompradetimpentradaalmacen)gvDetalleImp.GetFocusedRow();

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
            CargarDetalle();
        }        
        private void cboBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            iIdtipocp.Enabled = false;
            rSerieDoc.Enabled = false;
            iNumeroDoc.Enabled = false;

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0: //Todos
                    break;
                case 1: //N° Requerimiento de compra
                    iIdtipocp.Enabled = true;
                    rSerieDoc.Enabled = true;
                    iNumeroDoc.Enabled = true;
                    iIdtipocp.Focus();
                    break;
            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in VwCpcompradetimpentradaalmacenList)
            {
                item.Itemseleccionado = (item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked);
                item.Cantidadaimportar = item.Saldoaimportar > 0 && chkSeleccionarTodo.Checked ? item.Saldoaimportar : 0;

            }
            gvDetalleImp.RefreshData();
        }
        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
    }
}
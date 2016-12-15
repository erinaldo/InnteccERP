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
    public partial class SalidaalmacenImpGuiaRemisionFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        static readonly IService Service = new Service();

        private List<VwGuiaremision> _vwGuiaremisionList;        
        private List<VwGuiaremisionimpsalidaalmacen> VwGuiaremisionimpsalidaalmacenList { get; set; }        
        private List<VwAlmacen> VwAlmacenList { get; set; }
        public Tipodocmov TipodocmovSel { get; set; }
        public Almacen AlmacenSel { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public SalidaalmacenMntFrm SalidaalmacenMntFrm { get; set; }
        public VwSocionegocio VwSocionegocioSel { get; set; }
        public SalidaalmacenImpGuiaRemisionFrm(Tipodocmov tipodocmov, VwSocionegocio vwSocionegocioSel, Almacen almacenSel, SalidaalmacenMntFrm salidaalmacenMntFrm)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipodocmovSel = tipodocmov;
            VwSocionegocioSel = vwSocionegocioSel;
            AlmacenSel = almacenSel;
            SalidaalmacenMntFrm = salidaalmacenMntFrm;
        }
        private void SalidaalmacenImpGuiaRemisionFrm_Load(object sender, EventArgs e)
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


            string whereTipoCp = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'", "GUIAREMISION", SessionApp.SucursalSel.Idsucursal);
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
            string whereNumeroGuiaRemision = string.Empty;

            const string whereNoPendientes = @" and idguiaremision 
                                               in (select a.idguiaremision
                                               from almacen.vwguiaremisionimpsalidaalmacen a 
                                               where a.anulado = '0' and a.saldoaimportar > 0)";          

            string whereSocioNegocio = string.Format(" and idsocionegocio = {0}", VwSocionegocioSel.Idsocionegocio);

            string whereAlmacen =  string.Format(" and almacenorigen = {0}",AlmacenSel.Idalmacen);

            switch (cboBuscarPor.SelectedIndex)
            {
                case 0://Todos
                    whereNumeroGuiaRemision = string.Format("anulado = '0' {0} {1} {2}", whereAlmacen, whereSocioNegocio, whereNoPendientes);
                    break;
                case 1: //Guia de remision

                    whereNumeroGuiaRemision = string.Format(@"idtipocp = {0} and serieguiaremision = '{1}'
                        and numeroguiaremision = '{2}' and anulado = '0' {3} {4} {5}",
                        (int)iIdtipocp.EditValue,
                        rSerieDoc.Text.Trim(),
                        iNumeroDoc.Text.Trim(),
                        whereAlmacen,
                        whereSocioNegocio,
                        whereNoPendientes);

                    break;
            }


            _vwGuiaremisionList = Service.GetAllVwGuiaremision(whereNumeroGuiaRemision, "nombretipoformato,serieguiaremision,numeroguiaremision");


            gcConsulta.BeginUpdate();
            gcConsulta.DataSource = _vwGuiaremisionList;
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
        private void CargarDetalle()
        {
            VwGuiaremision vwGuiaremisionSel = (VwGuiaremision)gvConsulta.GetFocusedRow();

            if (vwGuiaremisionSel != null)
            {
                Cursor = Cursors.WaitCursor;
                string where = string.Format("idguiaremision = {0} and saldoaimportar > 0", vwGuiaremisionSel.Idguiaremision);
                VwGuiaremisionimpsalidaalmacenList = Service.GetAllVwGuiaremisionimpsalidaalmacen(where, "numeroitem");

                //foreach (var itemReq in VwGuiaremisionimpsalidaalmacenList)
                //{
                //    var totalCantidadImporta = VwOrdencompradetList.Where(x =>
                //        x.Idarticulo == itemReq.Idarticulo
                //        && x.Idrequerimientodet == itemReq.Idrequerimientodet
                //        && x.DataEntityState != DataEntityState.Deleted).Sum(x => x.Cantidad);
                //    if (totalCantidadImporta > 0)
                //    {
                //        itemReq.Cantidadimportada = totalCantidadImporta;
                //        itemReq.Saldoaimportar = itemReq.Cantidad - itemReq.Cantidadimportada;
                //    }

                //}

                //var itemsARemover = VwGuiaremisionimpsalidaalmacenList.Where(x => x.Saldoaimportar <= 0).ToList();
                //foreach (var itemToRemove in itemsARemover)
                //{
                //    VwGuiaremisionimpsalidaalmacenList.Remove(itemToRemove);
                //}

                //Borrar 

                gcDetalleImp.BeginUpdate();
                gcDetalleImp.DataSource = VwGuiaremisionimpsalidaalmacenList;
                gcDetalleImp.EndUpdate();

                gvDetalleImp.BestFitColumns();
                Cursor = Cursors.Default;

            }
        }
        private Salidaalmacendet AsignarSalidaAlmacenDetalle(VwGuiaremisionimpsalidaalmacen vwGuiaremisionimpsalidaalmacen)
        {
            Salidaalmacendet salidaalmacendetMnt = new Salidaalmacendet
            {
                Idsalidaalmacen = SalidaalmacenMntFrm.IdEntidadMnt,
                Numeroitem = vwGuiaremisionimpsalidaalmacen.Numeroitem,
                Idarticulo = vwGuiaremisionimpsalidaalmacen.Idarticulo,
                Idimpuesto = vwGuiaremisionimpsalidaalmacen.Idimpuesto,
                Idunidadmedida = vwGuiaremisionimpsalidaalmacen.Idunidadmedida,
                Especificacion = vwGuiaremisionimpsalidaalmacen.Especificacion,
                Cantidad = vwGuiaremisionimpsalidaalmacen.Cantidadaimportar,
                Preciounitario = vwGuiaremisionimpsalidaalmacen.Preciounitario,
                Importetotal = Math.Round(vwGuiaremisionimpsalidaalmacen.Cantidadaimportar * vwGuiaremisionimpsalidaalmacen.Preciounitario,2),
                Idproyecto = vwGuiaremisionimpsalidaalmacen.Idproyecto,
                Idarea = vwGuiaremisionimpsalidaalmacen.Idarea,
                Idcentrodecosto = vwGuiaremisionimpsalidaalmacen.Idcentrodecosto,
                Porcentajepercepcion = vwGuiaremisionimpsalidaalmacen.Porcentajepercepcion,
                Idtipoafectacionigv = vwGuiaremisionimpsalidaalmacen.Idtipoafectacionigv,
                Idguiaremisiondet = vwGuiaremisionimpsalidaalmacen.Idguiaremisiondet,
                Calcularitem = vwGuiaremisionimpsalidaalmacen.Calcularitem
            };
            return salidaalmacendetMnt;
        }      
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            
            switch (e.Item.Name)
            {
                case "btnImportar":

                    if (!Validaciones()) return;

                    if (SalidaalmacenMntFrm.IdEntidadMnt == 0)
                    {
                        if (!SalidaalmacenMntFrm.Validaciones()) return;

                        string numeroDoc = string.Format("{0} {1}-{2}", SalidaalmacenMntFrm.iIdtipocp.Text.Trim(), SalidaalmacenMntFrm.rSeriesalidaalmacen.Text.Trim(), SalidaalmacenMntFrm.rNumerosalidaalmacen.Text.Trim());
                        if (DialogResult.No == XtraMessageBox.Show(string.Format("¿Desea guardar el documento {0}?", numeroDoc),
                            "Atención", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            return;
                        }
                        VwGuiaremision vwGuiaremisionSel = (VwGuiaremision)gvConsulta.GetFocusedRow();
                        SalidaalmacenMntFrm.SalidaalmacenMnt.Idguiaremision = vwGuiaremisionSel.Idguiaremision;
                        SalidaalmacenMntFrm.SalidaalmacenMnt.Incluyeimpuestoitems = vwGuiaremisionSel.Incluyeimpuestoitems;
                        SalidaalmacenMntFrm.iIncluyeimpuestoitems.EditValue = vwGuiaremisionSel.Incluyeimpuestoitems;
                        SalidaalmacenMntFrm.iIdtipomoneda.EditValue = vwGuiaremisionSel.Idtipomoneda;
                        SalidaalmacenMntFrm.iIdtipomoneda.ReadOnly = true;
                        SalidaalmacenMntFrm.iTipocambio.EditValue = vwGuiaremisionSel.Tipocambio;

                        if (SalidaalmacenMntFrm.Guardar())
                        {
                            SalidaalmacenMntFrm.DeshabilitarModificacion();
                        }

                    }

                    if (SalidaalmacenMntFrm.IdEntidadMnt > 0)
                    {
                        foreach (var item in VwGuiaremisionimpsalidaalmacenList.Where(x=>x.Itemseleccionado))
                        {
                            Salidaalmacendet salidaalmacendetMnt = AsignarSalidaAlmacenDetalle(item);

                            int idsalidaalmacendet = Service.SaveSalidaalmacendet(salidaalmacendetMnt);
                            if (idsalidaalmacendet > 0)
                            {
                                //Verificar las ubicacion registradas por articulo
                                long cantidadRefUbicaciones = Service.CountVwArticuloubicacion(
                                    x => x.Idarticulo == salidaalmacendetMnt.Idarticulo
                                    && x.Idalmacen == (int)iIdalmacen.EditValue);

                                if (cantidadRefUbicaciones == 0)
                                {
                                    //Insertar ubicacion por defecto
                                    Salidaalmacenubicacion salidaalmacenubicacion = new Salidaalmacenubicacion
                                    {
                                        Idsalidaalmacendet = idsalidaalmacendet,
                                        Idubicacion = Convert.ToInt32(AlmacenSel.Idubicaciondefecto),
                                        Cantidadarticulo = salidaalmacendetMnt.Cantidad
                                    };
                                    Service.SaveSalidaalmacenubicacion(salidaalmacenubicacion);
                                }
                                else
                                {
                                    //Insertar la ubicaciones del articulo del almacen seleccionado
                                    List<VwArticuloubicacion> vwArticuloubicacionList = Service.GetAllVwArticuloubicacion(
                                        x => x.Idarticulo == salidaalmacendetMnt.Idarticulo
                                        && x.Idalmacen == (int)iIdalmacen.EditValue);

                                    foreach (var vwArticuloubicacion in vwArticuloubicacionList)
                                    {
                                        Salidaalmacenubicacion salidaalmacenubicacion = new Salidaalmacenubicacion
                                        {
                                            Idsalidaalmacendet = idsalidaalmacendet,
                                            Idubicacion = vwArticuloubicacion.Idubicacion,
                                            Cantidadarticulo = 0m
                                        };
                                        Service.SaveSalidaalmacenubicacion(salidaalmacenubicacion);
                                    }
                                }
                            }
                        }

                        SalidaalmacenMntFrm.CargarDetalle();
                        SalidaalmacenMntFrm.CargarDocumentoReferencia();
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
                XtraMessageBox.Show("No hay información de guias de remisión, verifique", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            int cantidadItemsSeleccionados = VwGuiaremisionimpsalidaalmacenList.Count(x => x.Itemseleccionado);
            if (cantidadItemsSeleccionados == 0)
            {
                XtraMessageBox.Show("Debe seleccionar los items a importar", "Atención", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void SalidaalmacenImpGuiaRemisionFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void gvDetalleImp_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            VwGuiaremisionimpsalidaalmacen itemSel = (VwGuiaremisionimpsalidaalmacen)gvDetalleImp.GetFocusedRow();

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
            foreach (var item in VwGuiaremisionimpsalidaalmacenList)
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
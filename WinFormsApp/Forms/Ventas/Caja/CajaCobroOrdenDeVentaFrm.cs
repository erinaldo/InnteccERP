using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.Win32;
using Utilities;

namespace WinFormsApp
{
    public partial class CajaCobroOrdenDeVentaFrm : XtraForm
    {
        public VwOrdendeventa VwOrdendeventaSel { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }

        static readonly IService Service = new Service();
        public VwTipocp VwTipoCpVentaSel { get; set; }
        public List<VwRecibocajaingresodet> VwRecibocajaingresodetList { get; set; }
        public VwEmpleado VwEmpleadoSel { get; set; }
        private ImpresionFormato ImpresionFormato { get; set; }
        public CajaCobroOrdenDeVentaFrm(int idOrdenVentSel, int idEmpleadoCajero)
        {
            InitializeComponent();
            VwOrdendeventaSel = Service.GetVwOrdendeventa(idOrdenVentSel);

            //
            gvMedioPago.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            VwRecibocajaingresodetList = new List<VwRecibocajaingresodet>();
            gcMedioPago.DataSource = VwRecibocajaingresodetList;
            VwEmpleadoSel = Service.GetVwEmpleado(idEmpleadoCajero);
            //

            if (ImpresionFormato == null)
            {
                ImpresionFormato = new ImpresionFormato();
            }

        }
        private void CajaCobroOrdenDeVentaFrm_Load(object sender, EventArgs e)
        {
            CargarOrdenDeVenta();
            CargarReferenciasCpVenta();            
            CargarTipoCpVentaCajero();
            ValoresPorDefecto();
            Text = string.Format("{0} Cajero: {1}", Text, VwEmpleadoSel.Razonsocial.Trim());
            ObtenerDatosTipoDeImpresion();
        }
        private void ValoresPorDefecto()
        {
            iFechaemision.EditValue = DateTime.Now;
            AgregarItemMedioPagoEfectivo();
        }
        private void AgregarItemMedioPagoEfectivo()
        {
            VwRecibocajaingresodet vwRecibocajaingresodet = new VwRecibocajaingresodet();
            vwRecibocajaingresodet.Numeroitem = 1;
            vwRecibocajaingresodet.Idtipodocmov = 1; //CpVenta
            vwRecibocajaingresodet.Idtipocp = (int) iIdtipoCpVenta.EditValue;
            vwRecibocajaingresodet.Serietipocp = rSeriecpventa.Text.Trim();
            vwRecibocajaingresodet.Numerotipocp = rNumerocpventa.Text.Trim();
            vwRecibocajaingresodet.Importepago = (decimal) nTotaldocumento.EditValue;
            vwRecibocajaingresodet.Idmediopago = 9; // MedioPago: Efectivo
            vwRecibocajaingresodet.Nombremediopago = "EFECTIVO, EN LOS DEMAS CASOS";
            vwRecibocajaingresodet.Numeromediopago = string.Empty;
            vwRecibocajaingresodet.Comentario = string.Empty;
            VwRecibocajaingresodetList.Add(vwRecibocajaingresodet);
            SumarMedioPago();
        }
        private void CargarTipoCpVentaCajero()
        {
            //iIdtipoCpVenta.EditValue = VwEmpleadoSel.Idtipocpventa;
            iIdtipoCpVenta.EditValue = VwOrdendeventaSel.Idtipocpventa;
            iIdcptooperacionCpventa.EditValue = VwEmpleadoSel.Idcptooperacionventa;
        }
        private void CargarOrdenDeVenta()
        {
            iIdtipocporden.Text = VwOrdendeventaSel.Nombretipoformato;
            iIdcptooperacionOrden.Text = VwOrdendeventaSel.Nombrecptooperacion;
            rNumeroordenventa.Text = VwOrdendeventaSel.Serienumeroordenventa;
            iFechaordenventa.DateTime = VwOrdendeventaSel.Fechaordenventa;
            beSocioNegocio.Text = VwOrdendeventaSel.Razonsocial;
            iNrodocentidad.Text = string.Format("{0} {1}", VwOrdendeventaSel.Abreviaturadocentidad.Trim(), VwOrdendeventaSel.Nrodocentidadprincipal.Trim());
            iIddireccionfacturacion.Text = VwOrdendeventaSel.Direccionsocionegocio;
            lblTotal.Text = string.Format("Total {0}", VwOrdendeventaSel.Simbolomoneda);
            nTotaldocumento.EditValue = VwOrdendeventaSel.Totaldocumento;
            nTotalArticulos.EditValue = VwOrdendeventaSel.Cantidadorden;
        }
        private void CargarReferenciasCpVenta()
        {

            VwTipocpList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "CPVENTA"
            && x.Idsucursal == VwOrdendeventaSel.Idsucursal).ToList();

            iIdtipoCpVenta.Properties.DataSource = VwTipocpList;
            iIdtipoCpVenta.Properties.DisplayMember = "Nombretipocp";
            iIdtipoCpVenta.Properties.ValueMember = "Idtipocp";
            iIdtipoCpVenta.Properties.BestFitMode = BestFitMode.BestFit;

            VwCptooperacionList = CacheObjects.VwCptooperacionList.Where(x => x.Nombretipodocmov == "CPVENTA"
            && x.Idsucursal == VwOrdendeventaSel.Idsucursal).ToList();

            iIdcptooperacionCpventa.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacionCpventa.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacionCpventa.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacionCpventa.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipoCpVenta.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                VwTipoCpVentaSel = vwTipocp;
                rSeriecpventa.EditValue = vwTipocp.Seriecp;
                rNumerocpventa.EditValue = vwTipocp.Numerocorrelativocp;
            }
            else
            {
                rSeriecpventa.EditValue = @"0000";
                rNumerocpventa.EditValue = 0;
            }
        }
        private void iIdtipoCpVenta_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (!Validaciones())
            {
                return;
            }

            decimal totalMedioDePago = (decimal)nTotalMedioPago.EditValue;
            decimal totalNotaDeCredito = (decimal)nTotalNotaCredito.EditValue;
            decimal totalOrdenVenta = (decimal) nTotaldocumento.EditValue;
            if (totalMedioDePago + totalNotaDeCredito != totalOrdenVenta)
            {
                WinFormUtils.MessageWarning("El importe de pago es invalido, verifique.");
                return;
            }

            string numeroCpVentaAgenerar = string.Format("{0} {1}-{2}", iIdtipoCpVenta.Text.Trim(), rSeriecpventa.Text.Trim(), rNumerocpventa.Text.Trim());
            
            if (WinFormUtils.MessageQuestion(string.Format("¿Cobrar e imprimir comprobante: {0}?", numeroCpVentaAgenerar)) == DialogResult.Yes)
            {                
                int idCpVentaGenerado = GenerarCpVenta();                
                if (idCpVentaGenerado > 0)
                {
                    if (iImprimirComprobante.Checked)
                    {
                        ImpresionFormato.FormatoCpVentaImpresora(idCpVentaGenerado);
                    }
                }
                DialogResult = DialogResult.OK;
            }
            GuardarDatosTipoDeImpresion();
        }
        private bool Validaciones()
        {
            VwPeriodo vwPeriodo = Service.GetVwPeriodo(x => x.Mes == SessionApp.DateServer.Month.ToString("D2") && x.Anioejercicio == SessionApp.DateServer.Year);
            if (vwPeriodo == null)
            {
                WinFormUtils.MessageWarning("Periodo no registrado, verifique","Validación");
                return false;
            }
            return true;
        }
        private int GenerarCpVenta()
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                DateTime fechaEmisionCpVenta = (DateTime)iFechaemision.EditValue;
                VwPeriodo vwPeriodo = Service.GetVwPeriodo(x => x.Anioejercicio == fechaEmisionCpVenta.Year && x.Mes == fechaEmisionCpVenta.Month.ToString("d2"));
                Cpventa cpventa = new Cpventa();

                cpventa.Idcpventa = 0;
                cpventa.Idsucursal = VwOrdendeventaSel.Idsucursal;
                cpventa.Idtipocp = (int)iIdtipoCpVenta.EditValue;
                cpventa.Idcptooperacion = (int)iIdcptooperacionCpventa.EditValue;
                cpventa.Seriecpventa = rSeriecpventa.Text.Trim();
                cpventa.Numerocpventa = rNumerocpventa.Text.Trim();
                cpventa.Idcliente = VwOrdendeventaSel.Idcliente;

                cpventa.Fechaemision = fechaEmisionCpVenta;
                cpventa.Idperiodo = vwPeriodo.Idperiodo;
                cpventa.Fechavencimiento = fechaEmisionCpVenta;
                cpventa.Anulado = false;
                cpventa.Fechaanulado = null;
                cpventa.Idvendedor = VwOrdendeventaSel.Idempleado;
                cpventa.Idtipocondicion = VwOrdendeventaSel.Idtipocondicion;
                cpventa.Tipocambio = VwOrdendeventaSel.Tipocambio;
                cpventa.Idtipomoneda = VwOrdendeventaSel.Idtipomoneda;

                cpventa.Totalbruto = VwOrdendeventaSel.Totalbruto;
                cpventa.Totalgravado = VwOrdendeventaSel.Totalgravado;
                cpventa.Totalinafecto = VwOrdendeventaSel.Totalinafecto;
                cpventa.Totalexonerado = VwOrdendeventaSel.Totalexonerado;
                cpventa.Totalimpuesto = VwOrdendeventaSel.Totalimpuesto;
                cpventa.Importetotal = VwOrdendeventaSel.Importetotal;
                cpventa.Porcentajepercepcion = VwOrdendeventaSel.Porcentajepercepcion;
                cpventa.Importetotalpercepcion = VwOrdendeventaSel.Importetotalpercepcion;
                cpventa.Totaldocumento = VwOrdendeventaSel.Totaldocumento;

                cpventa.Glosacpventa = VwOrdendeventaSel.Glosaordenventa;
                cpventa.Idimpuesto = VwOrdendeventaSel.Idimpuesto;
                cpventa.Incluyeimpuestoitems = VwOrdendeventaSel.Incluyeimpuestoitems;
                cpventa.Idtipolista = VwOrdendeventaSel.Idtipolista;
                cpventa.Iddireccionfacturacion = VwOrdendeventaSel.Iddireccionfacturacion;

                // TODO: Agregar referencia de orden de venta

                cpventa.Listadoordenventaref = string.Empty; //Falta
                cpventa.Listadoguiaremref = string.Empty;

                List<VwCpventadet> vwCpventadetList = new List<VwCpventadet>();

                List<VwOrdendeventadet> vwOrdendeventadetList = Service.GetAllVwOrdendeventadetalle(x => x.Idordendeventa == VwOrdendeventaSel.Idordendeventa);

                foreach (var vwOrdendeventadet in vwOrdendeventadetList)
                {
                    VwCpventadet vwCpventadetMnt = new VwCpventadet();
                    vwCpventadetMnt.Idcpventadet = 0;
                    vwCpventadetMnt.Numeroitem = vwOrdendeventadet.Numeroitem;
                    vwCpventadetMnt.Idarticulo = vwOrdendeventadet.Idarticulo;
                    vwCpventadetMnt.Codigoarticulo = vwOrdendeventadet.Codigoarticulo;
                    vwCpventadetMnt.Codigoproveedor = vwOrdendeventadet.Codigoproveedor;
                    vwCpventadetMnt.Idunidadmedida = vwOrdendeventadet.Idunidadmedida;
                    vwCpventadetMnt.Abrunidadmedida = vwOrdendeventadet.Abrunidadmedida;
                    vwCpventadetMnt.Nombremarca = vwOrdendeventadet.Nombremarca;
                    vwCpventadetMnt.Nombrearticulo = vwOrdendeventadet.Nombrearticulo;
                    vwCpventadetMnt.Cantidad = vwOrdendeventadet.Cantidad;
                    vwCpventadetMnt.Preciounitario = vwOrdendeventadet.Preciounitario;
                    vwCpventadetMnt.Especificacion = vwOrdendeventadet.Especificacion;
                    vwCpventadetMnt.Descuento1 = vwOrdendeventadet.Descuento1;
                    vwCpventadetMnt.Descuento2 = vwOrdendeventadet.Descuento2;
                    vwCpventadetMnt.Descuento3 = vwOrdendeventadet.Descuento3;
                    vwCpventadetMnt.Descuento4 = vwOrdendeventadet.Descuento4;
                    vwCpventadetMnt.Preciounitarioneto = vwOrdendeventadet.Preciounitarioneto;
                    vwCpventadetMnt.Importetotal = vwOrdendeventadet.Importetotal;
                    vwCpventadetMnt.Idimpuesto = vwOrdendeventadet.Idimpuesto;
                    vwCpventadetMnt.Idalmacen = vwOrdendeventadet.Idalmacen;
                    vwCpventadetMnt.Idtipoafectacionigv = vwOrdendeventadet.Idtipoafectacionigv;
                    vwCpventadetMnt.Gravado = vwOrdendeventadet.Gravado;
                    vwCpventadetMnt.Exonerado = vwOrdendeventadet.Exonerado;
                    vwCpventadetMnt.Inafecto = vwOrdendeventadet.Inafecto;
                    vwCpventadetMnt.Exportacion = vwOrdendeventadet.Exportacion;
                    vwCpventadetMnt.Idarea = vwOrdendeventadet.Idarea;
                    vwCpventadetMnt.Nombrearea = vwOrdendeventadet.Nombrearea;
                    vwCpventadetMnt.Idproyecto = vwOrdendeventadet.Idproyecto;
                    vwCpventadetMnt.Nombreproyecto = vwOrdendeventadet.Nombreproyecto;
                    vwCpventadetMnt.Idcentrodecosto = vwOrdendeventadet.Idcentrodecosto;
                    vwCpventadetMnt.Descripcioncentrodecosto = vwOrdendeventadet.Descripcioncentrodecosto;
                    vwCpventadetMnt.Porcentajepercepcion = vwOrdendeventadet.Porcentajepercepcion;
                    vwCpventadetMnt.Idordendeventadet = vwOrdendeventadet.Idordendeventadet;
                    vwCpventadetMnt.Serienumeroordenventa = vwOrdendeventadet.Serienumeroordenventa;

                    vwCpventadetMnt.Calcularitem = vwOrdendeventadet.Calcularitem;
                    vwCpventadetMnt.DataEntityState = DataEntityState.Added;
                    vwCpventadetList.Add(vwCpventadetMnt);
                }

                Recibocajaingreso recibocajaingreso = null;
                //Crear recibo
                Tipocp tipocpReciboIngreso = Service.GetTipocp(x => x.Idtipocp == VwEmpleadoSel.Idtipocpreciboingreso);
                if (tipocpReciboIngreso != null)
                {
                    recibocajaingreso = new Recibocajaingreso();

                    recibocajaingreso.Idsucursal = VwOrdendeventaSel.Idsucursal;
                    recibocajaingreso.Idtipocp = Convert.ToInt32(VwEmpleadoSel.Idtipocpreciboingreso);
                    recibocajaingreso.Idcptooperacion = Convert.ToInt32(VwEmpleadoSel.Idcptooperacionreciboingreso);
                    recibocajaingreso.Serierecibo = tipocpReciboIngreso.Seriecp;
                    recibocajaingreso.Numerorecibo = tipocpReciboIngreso.Numerocorrelativocp.ToString("d8");
                    recibocajaingreso.Idempleado = VwEmpleadoSel.Idempleado;
                    recibocajaingreso.Idsocionegocio = VwOrdendeventaSel.Idcliente;
                    recibocajaingreso.Fecharecibo = DateTime.Now;
                    recibocajaingreso.Fechapago = DateTime.Now;
                    recibocajaingreso.Anulado = false;
                    recibocajaingreso.Fechaanulado = null;
                    recibocajaingreso.Tipocambio = VwOrdendeventaSel.Tipocambio;
                    recibocajaingreso.Idtipomoneda = VwOrdendeventaSel.Idtipomoneda;
                    recibocajaingreso.Comentario = "GENERADO DESDE CAJA";
                    recibocajaingreso.Idtiporecibo = 1; // Ingreso
                    recibocajaingreso.Totaldocumento = VwOrdendeventaSel.Totaldocumento;
                }

                Cursor = Cursors.Default;
                return Service.GuardarCpVentaReciboIngreso(TipoMantenimiento.Nuevo, cpventa, vwCpventadetList, recibocajaingreso, VwRecibocajaingresodetList);
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
        }
        private void bmMedioDePago_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            var idTipoCpSel = iIdtipoCpVenta.EditValue;

            if (idTipoCpSel == null)
            {
                return;
            }

            VwTipocp vwTipocpSel = VwTipocpList.FirstOrDefault(x => x.Idtipocp == (int)idTipoCpSel);

            if (vwTipocpSel != null)
            {
                CajaCobroMedioPagoOrdenVentaMntItemFrm cajaCobroMedioPagoOrdenVentaMntItemFrm;
                VwRecibocajaingresodet vwRecibocajaingresodetMnt;

                switch (e.Item.Name)
                {
                    case "btnAddMedioPago":


                        vwRecibocajaingresodetMnt = new VwRecibocajaingresodet();

                        //Asignar el siguiente item
                        var sgtItem = VwRecibocajaingresodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                            .OrderByDescending(t => t.Numeroitem)
                            .FirstOrDefault();

                        vwRecibocajaingresodetMnt.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;
                        vwRecibocajaingresodetMnt.ImportePendiente = (decimal) nPendiente.EditValue;

                        cajaCobroMedioPagoOrdenVentaMntItemFrm = new CajaCobroMedioPagoOrdenVentaMntItemFrm(TipoMantenimiento.Nuevo, vwRecibocajaingresodetMnt, vwTipocpSel, VwRecibocajaingresodetList);
                        if (cajaCobroMedioPagoOrdenVentaMntItemFrm.ShowDialog() == DialogResult.OK)
                        {
                            VwRecibocajaingresodetList.Add(vwRecibocajaingresodetMnt);
                        }

                        SumarMedioPago();

                        if (!gvMedioPago.IsLastRow)
                        {
                            gvMedioPago.MoveLastVisible();
                            gvMedioPago.Focus();
                            gvMedioPago.FocusedColumn = gvMedioPago.Columns["Importepago"];
                        }
                        break;
                    case "btnEditMedioPago":

                        if (gvMedioPago.RowCount == 0)
                        {
                            break;
                        }

                        vwRecibocajaingresodetMnt = (VwRecibocajaingresodet)gvMedioPago.GetFocusedRow();
                        cajaCobroMedioPagoOrdenVentaMntItemFrm = new CajaCobroMedioPagoOrdenVentaMntItemFrm(TipoMantenimiento.Modificar, vwRecibocajaingresodetMnt, vwTipocpSel, VwRecibocajaingresodetList);
                        cajaCobroMedioPagoOrdenVentaMntItemFrm.ShowDialog();

                        if (cajaCobroMedioPagoOrdenVentaMntItemFrm.DialogResult == DialogResult.OK)
                        {
                            SumarMedioPago();
                        }
                        break;
                    case "btnDelMedioPago":
                        if (gvMedioPago.RowCount == 0)
                        {
                            break;
                        }
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?","Eliminar item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            vwRecibocajaingresodetMnt = (VwRecibocajaingresodet)gvMedioPago.GetFocusedRow();
                            vwRecibocajaingresodetMnt.DataEntityState = DataEntityState.Deleted;
                            if (!gvMedioPago.IsFirstRow)
                            {
                                gvMedioPago.MovePrev();
                            }
                            SumarMedioPago();
                        }
                        break;
                }
            }
        }
        private void SumarMedioPago()
        {
            gcMedioPago.RefreshDataSource();
            decimal totalMedioPago = VwRecibocajaingresodetList.Where(x => x.DataEntityState != DataEntityState.Deleted).Sum(x => x.Importepago);
            nTotalMedioPago.EditValue = totalMedioPago;
            nPendiente.EditValue = (decimal) nTotaldocumento.EditValue - totalMedioPago;

        }
        private void nPendiente_EditValueChanged(object sender, EventArgs e)
        {
            nPendiente.ForeColor = (decimal) nPendiente.EditValue > 0 ? Color.Red : Color.Black;
        }

        private void GuardarDatosTipoDeImpresion()
        {
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"Software\Inntecc\ValoresPorDefecto"))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue("ImprimirCpVentaEnCajaCobro", iImprimirComprobante.Checked, RegistryValueKind.String);
                }
            }
        }

        private void ObtenerDatosTipoDeImpresion()
        {
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"Software\Inntecc\ValoresPorDefecto"))
            {
                if (registryKey != null)
                {
                    string imprimirCpVenta =(string) registryKey.GetValue("ImprimirCpVentaEnCajaCobro");
                    if (imprimirCpVenta != null)
                    {
                        iImprimirComprobante.Checked = bool.Parse(imprimirCpVenta);                    
                    }
                }
            }
        }

    }
}
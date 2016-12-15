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
    public partial class CajaCobroCpVentaFrm : XtraForm
    {
        public VwCpventa VwCpventa { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public List<VwCptooperacion> VwCptooperacionList { get; set; }

        static readonly IService Service = new Service();
        public VwTipocp VwTipoCpVentaSel { get; set; }
        public List<VwRecibocajaingresodet> VwRecibocajaingresodetList { get; set; }
        public VwEmpleado VwEmpleadoSel { get; set; }
        private ImpresionFormato ImpresionFormato { get; set; }
        public int IdCpVentaSel { get; set; }
        public CajaCobroCpVentaFrm(int idCpVentaSel, int idEmpleadoCajero)
        {
            InitializeComponent();
            IdCpVentaSel = idCpVentaSel;
            VwCpventa = Service.GetVwCpventa(idCpVentaSel);

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
        private void CajaCobroCpVentaFrm_Load(object sender, EventArgs e)
        {
            CargarOrdenDeVenta();
            CargarReferenciasCpVenta();
            CargarDatosReciboDeIngreso();
            ValoresPorDefecto();
            Text = string.Format("{0} Cajero: {1}", Text, VwEmpleadoSel.Razonsocial.Trim());
            ObtenerDatosTipoDeImpresion();
        }
        private void ValoresPorDefecto()
        {
            AgregarItemMedioPagoEfectivo();
        }
        private void AgregarItemMedioPagoEfectivo()
        {
            VwRecibocajaingresodet vwRecibocajaingresodet = new VwRecibocajaingresodet();
            vwRecibocajaingresodet.Numeroitem = 1;
            vwRecibocajaingresodet.Idtipodocmov = 1; //CpVenta
            vwRecibocajaingresodet.Idtipocp = VwCpventa.Idtipocp;
            vwRecibocajaingresodet.Serietipocp = VwCpventa.Seriecpventa;
            vwRecibocajaingresodet.Numerotipocp = VwCpventa.Numerocpventa;
            vwRecibocajaingresodet.Importepago = (decimal)nTotaldocumento.EditValue;
            vwRecibocajaingresodet.Idmediopago = 9; // MedioPago: Efectivo
            vwRecibocajaingresodet.Nombremediopago = "EFECTIVO, EN LOS DEMAS CASOS";
            vwRecibocajaingresodet.Numeromediopago = string.Empty;
            vwRecibocajaingresodet.Comentario = string.Empty;
            VwRecibocajaingresodetList.Add(vwRecibocajaingresodet);
            SumarMedioPago();
        }
        private void CargarDatosReciboDeIngreso()
        {

            VwTipocpList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "RECIBO-INGRESO" && x.Idsucursal == VwCpventa.Idsucursal).ToList();

            iIdtipoCpReciboIngreso.Properties.DataSource = VwTipocpList;
            iIdtipoCpReciboIngreso.Properties.DisplayMember = "Nombretipocp";
            iIdtipoCpReciboIngreso.Properties.ValueMember = "Idtipocp";
            iIdtipoCpReciboIngreso.Properties.BestFitMode = BestFitMode.BestFit;

            VwCptooperacionList = CacheObjects.VwCptooperacionList.Where(x => x.Nombretipodocmov == "RECIBO-INGRESO" && x.Idsucursal == VwCpventa.Idsucursal).ToList();

            iIdcptooperacionReciboIngreso.Properties.DataSource = VwCptooperacionList;
            iIdcptooperacionReciboIngreso.Properties.DisplayMember = "Nombrecptooperacion";
            iIdcptooperacionReciboIngreso.Properties.ValueMember = "Idcptooperacion";
            iIdcptooperacionReciboIngreso.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipoCpReciboIngreso.EditValue = SessionApp.EmpleadoSel.Idtipocpreciboingreso;
            iIdcptooperacionReciboIngreso.EditValue = SessionApp.EmpleadoSel.Idcptooperacionreciboingreso;
        }
        private void CargarOrdenDeVenta()
        {
            iIdtipocporden.Text = VwCpventa.Nombretipoformato;
            iIdcptooperacionOrden.Text = VwCpventa.Nombrecptooperacion;
            rNumeroordenventa.Text = VwCpventa.Seriecpventa;
            iFechaordenventa.DateTime = VwCpventa.Fechaemision;
            beSocioNegocio.Text = VwCpventa.Razonsocialcliente;
            iNrodocentidad.Text = string.Format("{0} {1}", VwCpventa.Abreviaturadocentidadcliente.Trim(), VwCpventa.Nrodocprincipalcliente.Trim());
            iIddireccionfacturacion.Text = VwCpventa.Direccionsocionegocio;
            lblTotal.Text = string.Format("Total {0}", VwCpventa.Simbolomoneda);
            nTotaldocumento.EditValue = VwCpventa.Totaldocumento;
            nTotalArticulos.EditValue = VwCpventa.Cantidadventa;
        }
        private void CargarReferenciasCpVenta()
        {



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
            decimal totalOrdenVenta = (decimal)nTotaldocumento.EditValue;
            if (totalMedioDePago + totalNotaDeCredito != totalOrdenVenta)
            {
                WinFormUtils.MessageWarning("El importe de pago es invalido, verifique.");
                return;
            }

            //string numeroCpVentaAgenerar = string.Format("{0} {1}-{2}", iIdtipoCpVenta.Text.Trim(), rSeriecpventa.Text.Trim(), rNumerocpventa.Text.Trim());


            if (WinFormUtils.MessageQuestion("¿Grabar recibo de ingreso?") == DialogResult.Yes)
            {
                int idCpVentaGenerado = GenerarReciboCajaIngreso();
                if (idCpVentaGenerado > 0)
                {
                    if (iImprimirComprobante.Checked)
                    {
                        //ImpresionFormato.FormatoCpVentaImpresora(idCpVentaGenerado);
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
                WinFormUtils.MessageWarning("Periodo no registrado, verifique", "Validación");
                return false;
            }
            return true;
        }
        private int GenerarReciboCajaIngreso()
        {

            try
            {
                Cursor = Cursors.WaitCursor;


                Recibocajaingreso recibocajaingreso = null;
                //Crear recibo
                Tipocp tipocpReciboIngreso = Service.GetTipocp(x => x.Idtipocp == VwEmpleadoSel.Idtipocpreciboingreso);
                if (tipocpReciboIngreso != null)
                {
                    recibocajaingreso = new Recibocajaingreso();

                    recibocajaingreso.Idsucursal = VwCpventa.Idsucursal;
                    recibocajaingreso.Idtipocp = Convert.ToInt32(VwEmpleadoSel.Idtipocpreciboingreso);
                    recibocajaingreso.Idcptooperacion = Convert.ToInt32(VwEmpleadoSel.Idcptooperacionreciboingreso);
                    recibocajaingreso.Serierecibo = tipocpReciboIngreso.Seriecp;
                    recibocajaingreso.Numerorecibo = tipocpReciboIngreso.Numerocorrelativocp.ToString("d8");
                    recibocajaingreso.Idempleado = VwEmpleadoSel.Idempleado;
                    recibocajaingreso.Idsocionegocio = VwCpventa.Idcliente;
                    recibocajaingreso.Fecharecibo = DateTime.Now;
                    recibocajaingreso.Fechapago = DateTime.Now;
                    recibocajaingreso.Anulado = false;
                    recibocajaingreso.Fechaanulado = null;
                    recibocajaingreso.Tipocambio = VwCpventa.Tipocambio;
                    recibocajaingreso.Idtipomoneda = VwCpventa.Idtipomoneda;
                    recibocajaingreso.Comentario = "GENERADO DESDE CAJA";
                    recibocajaingreso.Idtiporecibo = 1; // Ingreso
                    recibocajaingreso.Totaldocumento = VwCpventa.Totaldocumento;
                }

                Cursor = Cursors.Default;
                return Service.GuardarReciboCajaIngreso(TipoMantenimiento.Nuevo, VwCpventa.Idcpventa, recibocajaingreso, VwRecibocajaingresodetList);
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

            var idTipoCpSel = VwCpventa.Idtipocp;

            if (idTipoCpSel == null)
            {
                return;
            }

            

            if (VwCpventa != null)
            {
                CajaCobroMedioPagoCpVentaMntItemFrm cajaCobroMedioPagoMntItemFrm;
                VwRecibocajaingresodet vwRecibocajaingresodetMnt;

                switch (e.Item.Name)
                {
                    case "btnAddMedioPago":


                        vwRecibocajaingresodetMnt = new VwRecibocajaingresodet();

                        //Asignar el siguiente item
                        var sgtItem =
                            VwRecibocajaingresodetList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                                .OrderByDescending(t => t.Numeroitem)
                                .FirstOrDefault();

                        vwRecibocajaingresodetMnt.Numeroitem = sgtItem == null ? 1 : sgtItem.Numeroitem + 1;
                        vwRecibocajaingresodetMnt.ImportePendiente = (decimal)nPendiente.EditValue;

                        cajaCobroMedioPagoMntItemFrm = new CajaCobroMedioPagoCpVentaMntItemFrm(TipoMantenimiento.Nuevo, vwRecibocajaingresodetMnt, VwCpventa, VwRecibocajaingresodetList);
                        if (cajaCobroMedioPagoMntItemFrm.ShowDialog() == DialogResult.OK)
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
                        cajaCobroMedioPagoMntItemFrm = new CajaCobroMedioPagoCpVentaMntItemFrm(TipoMantenimiento.Modificar, vwRecibocajaingresodetMnt, VwCpventa, VwRecibocajaingresodetList);
                        cajaCobroMedioPagoMntItemFrm.ShowDialog();

                        if (cajaCobroMedioPagoMntItemFrm.DialogResult == DialogResult.OK)
                        {
                            SumarMedioPago();
                        }
                        break;
                    case "btnDelMedioPago":
                        if (gvMedioPago.RowCount == 0)
                        {
                            break;
                        }
                        if (DialogResult.Yes ==
                            XtraMessageBox.Show("¿Desea eliminar el item seleccionado?", "Eliminar item",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
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
            nPendiente.EditValue = (decimal)nTotaldocumento.EditValue - totalMedioPago;

        }
        private void nPendiente_EditValueChanged(object sender, EventArgs e)
        {
            nPendiente.ForeColor = (decimal)nPendiente.EditValue > 0 ? Color.Red : Color.Black;
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
                    string imprimirCpVenta = (string)registryKey.GetValue("ImprimirCpVentaEnCajaCobro");
                    if (imprimirCpVenta != null)
                    {
                        iImprimirComprobante.Checked = bool.Parse(imprimirCpVenta);
                    }
                }
            }
        }

        private void iIdtipoCpReciboIngreso_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }

        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipoCpReciboIngreso.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                VwTipoCpVentaSel = vwTipocp;
                rSerieReciboIngreso.EditValue = vwTipocp.Seriecp;
                rNumeroReciboIngreso.EditValue = vwTipocp.Numerocorrelativocp;
            }
            else
            {
                rSerieReciboIngreso.EditValue = @"0000";
                rNumeroReciboIngreso.EditValue = 0;
            }
        }
    }
}
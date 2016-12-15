using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Utilities;

namespace WinFormsApp
{
    public partial class CajaMostradorFrm : XtraForm
    {
        private static readonly object SyncLock = new Object();
        private static CajaMostradorFrm _uniqueInstance;
        static readonly IService Service = new Service();
        public List<VwOrdendeventa> VwOrdendeventaList { get; set; }

        public CajaMostradorFrm()
        {
            InitializeComponent();
        }

        public static CajaMostradorFrm GetInstance()
        {
            // Lock entire body of method
            lock (SyncLock)
            {
                if (_uniqueInstance == null || _uniqueInstance.IsDisposed)
                {
                    _uniqueInstance = new CajaMostradorFrm();
                }
                _uniqueInstance.BringToFront();
                return _uniqueInstance;
            }
        }

        private void CajaMostradorFrm_Load(object sender, EventArgs e)
        {
            CargarOrdenesDeVenta();
            Text = string.Format("{0} Cajero: {1}", Text, SessionApp.VwEmpleadoSel.Razonsocial.Trim());
        }

        private void CargarOrdenesDeVenta()
        {
            Cursor = Cursors.WaitCursor;
            gcConsulta.BeginUpdate();
            string whereOrden = string.Format("idsucursal = {0} and cantidadimportada = 0 and anulado = '0' and diascondicion = 0 and totaldocumento > 0", SessionApp.SucursalSel.Idsucursal);
            VwOrdendeventaList = Service.GetAllVwOrdendeventa(whereOrden, "nombretipoformato,serieordenventa,numeroordenventa");
            gcConsulta.DataSource = VwOrdendeventaList;
            gvConsulta.BestFitColumns();
            gcConsulta.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void bmCaja_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            switch (e.Item.Name)
            {
                case "btnCobro":
                    if (!DatosValidos())
                    {
                        return;
                    }
                    VwOrdendeventa vwOrdendeventa = (VwOrdendeventa)gvConsulta.GetFocusedRow();
                    if (vwOrdendeventa != null)
                    {
                        CajaCobroOrdenDeVentaFrm cajaCobroOrdenDeVentaFrm = new CajaCobroOrdenDeVentaFrm(vwOrdendeventa.Idordendeventa, SessionApp.EmpleadoSel.Idempleado);
                        if (cajaCobroOrdenDeVentaFrm.ShowDialog() == DialogResult.OK)
                        {
                            CargarOrdenesDeVenta();
                        }
                    }                    
                    break;
                case "btnAnular":
                    if (!DatosValidos())
                    {
                        return;
                    }
                    VwOrdendeventa vwOrdendeventaSel = (VwOrdendeventa)gvConsulta.GetFocusedRow();
                    if (vwOrdendeventaSel != null)
                    {
                        string numeroCpVentaAgenerar = string.Format("{0} {1}-{2}", vwOrdendeventaSel.Nombretipoformato.Trim(), vwOrdendeventaSel.Serieordenventa.Trim(), vwOrdendeventaSel.Numeroordenventa.Trim());

                        if (WinFormUtils.MessageQuestion(string.Format("¿Desea anular el documento: {0}?", numeroCpVentaAgenerar)) != DialogResult.Yes)
                        {
                            return;
                        }

                        Ordendeventa ordendeventa = Service.GetOrdendeventa(vwOrdendeventaSel.Idordendeventa);
                        if (ordendeventa != null)
                        {
                            ordendeventa.Anulado = true;
                            ordendeventa.Fechaanulado = DateTime.Now;
                            Service.UpdateOrdendeventa(ordendeventa);
                            CargarOrdenesDeVenta();
                        }
                    }
                    
                    break;
                case "btnActualizar":
                    CargarOrdenesDeVenta();
                    break;
            }
        }

        private bool DatosValidos()
        {
            if (gvConsulta.RowCount == 0)
            {
                XtraMessageBox.Show("No hay información de orden de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

    }
}
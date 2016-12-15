using System;
using System.Data;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FastReport;
using Utilities;

namespace WinFormsApp
{
    public partial class EntradaAlmacenRpFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public EntradaAlmacenRpFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ArticuloSel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Reporte();
        }

        private void Reporte()
        {
            DateTime fechaInicio = (DateTime)iFechaInicio.EditValue;
            DateTime fechaFinal = (DateTime)iFechaFinal.EditValue;

            var idProveedor = iIdsocionegocio.EditValue;
            var whereProveedor = idProveedor != null ? string.Format(" and idproveedor = {0}", (int)idProveedor) : string.Empty;

            string nameRelation;
            string whereList;
            string ordersList;
            string fieldsList;
            string nameFileReport = string.Empty;
            string nameAlias = null;
            DataTable dt = null;

            switch (lbOptions.SelectedIndex)
            {
                case 0://Ordenes de compra pendiente de ingresos
                    nameRelation = "compras.vwrpordenespendientesingreso";
                    whereList = string.Format("saldoaimportar > 0 and fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = {2} {3}"
                    ,fechaInicio.ToString("yyyyMMdd")
                    ,fechaFinal.ToString("yyyyMMdd")
                    ,SessionApp.SucursalSel.Idsucursal
                    , whereProveedor);
                    ordersList = "nombretipoformato,serieorden,numeroorden,numeroitem";
                    fieldsList = "*";
                    dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
                    nameFileReport = "ocpendienteingreso.frx";
                    nameAlias = "oc";
                    break;
                case 1: //Ordenes de compra pendiente de comprobante de compra
                    nameRelation = "compras.vwrpordenespendientescpcompra";
                    whereList = string.Format("saldoaimportar > 0 and fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = {2} {3}"
                    ,fechaInicio.ToString("yyyyMMdd")
                    ,fechaFinal.ToString("yyyyMMdd")
                    ,SessionApp.SucursalSel.Idsucursal
                    , whereProveedor);
                    ordersList = "nombretipoformato,serieorden,numeroorden,numeroitem";
                    fieldsList = "*";
                    dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
                    nameFileReport = "ocpendientecpcompra.frx";
                    nameAlias = "oc";
                    break;
            }
            
            var report = new Report();
            string reporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", nameFileReport));
            report.Load(reporte);
            report.RegisterData(dt, nameAlias);

            report.SetParameterValue("FechaInicio", fechaInicio.ToString("yyyyMMdd"));
            report.SetParameterValue("FechaFinal", fechaFinal.ToString("yyyyMMdd"));

            int opcionReporte = (int)rgOpcionReporte.EditValue;
            switch (opcionReporte)
            {
                case 0: //Vistaprevia
                    report.Show();
                    break;
                case 1: //Diseño
                    report.Design();                    
                    break;
            }            
            report.Dispose();
        }

        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        var vwSocionegocioSel = buscarSocioNegocioFrm.VwSocionegocioSel;
                        beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 1: //Borrar
                    beSocioNegocio.Text = @"Todos los proveedores";
                    iIdsocionegocio.EditValue = null;
                    break;
            }
        }

        private void EntradaAlmacenRpFrm_Load(object sender, EventArgs e)
        {
            iFechaInicio.EditValue = SessionApp.DateServer;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;
        }
    }
}
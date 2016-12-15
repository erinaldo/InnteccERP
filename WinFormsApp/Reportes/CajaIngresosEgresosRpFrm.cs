using System;
using System.Data;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using Utilities;

namespace WinFormsApp
{
    public partial class CajaIngresosEgresosRpFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public CajaIngresosEgresosRpFrm()
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
            int idTipoMoneda = (int) iIdtipomoneda.EditValue;

           string sqlQuery;
            string nameFileReport = string.Empty;
            DataTable dt = null;

            object[] parametros = {
                       fechaInicio,
                       fechaFinal,
                       iIdcptooperacion.EditValue,
                       iIdSocionegocio.EditValue,
                       null,
                       SessionApp.SucursalSel.Idsucursal,
                       idTipoMoneda
                    };

            switch (lbOptions.SelectedIndex)
            {
                case 0://Ordenes de compra pendiente de ingresos

                    sqlQuery = "reportes.fn_cajaingresoegreso";
                    
                    dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametros);

                    nameFileReport = "cajaingresoegresoresumen.repx";
                   
                    
                    break;
                case 1: //Ordenes de compra pendiente de comprobante de compra
                      sqlQuery = "reportes.fn_cajaegreso";
                    
                    dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametros);

                    nameFileReport = "cajaingresoegresoresumen.repx";
                    break;
                case 2: //Ordenes de compra pendiente de comprobante de compra
                    sqlQuery = "reportes.fn_cajaingreso";

                    dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametros);

                    nameFileReport = "cajaingresoegresoresumen.repx";
                    break;
            }

            //Parametros
            object[] parametrosReporte = {                
                iIdtipomoneda.Text.Trim()
            };

            string rutaArchivoReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Gerencia\\{0}", nameFileReport));
            XtraReport xtraReport = new XtraReport { DataSource = dt };
            xtraReport.LoadLayout(rutaArchivoReporte);
            ReportHelper2 reportHelper2 = new ReportHelper2(rutaArchivoReporte, dt, parametrosReporte, null);
           
            int opcionReporte = (int)rgOpcionReporte.EditValue;
            switch (opcionReporte)
            {
                case 0: //Vistaprevia
                    reportHelper2.ShowDialog();

                    break;
                case 1: //Diseño
                    reportHelper2.ShowDialog();
  
                    break;
            }
            reportHelper2.Dispose();
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
                        iIdSocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 1: //Borrar
                    beSocioNegocio.Text = @"Todos los proveedores";
                    iIdSocionegocio.EditValue = null;
                    break;
            }
        }

        private void CajaIngresosEgresosRpFrm_Load(object sender, EventArgs e)
        {
            iFechaInicio.EditValue = SessionApp.DateServer;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;
            CargarReferencias();
            ValoresPorDefecto();
        }

        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (lbOptions.SelectedIndex)
            {
                case 1: 
                    string whereTipoOpeIng = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'",
                        "RECIBO-EGRESO", SessionApp.SucursalSel.Idsucursal);
                    iIdcptooperacion.Properties.DataSource = Service.GetAllVwCptooperacion(whereTipoOpeIng,
                        "nombrecptooperacion");
                    
                    iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
                    iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
                    iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;
                    break;
                case 2:
                    string whereTipoOpeEgr = string.Format("nombretipodocmov = '{0}' and idsucursal = '{1}'",
                        "RECIBO-INGRESO", SessionApp.SucursalSel.Idsucursal);
                    iIdcptooperacion.Properties.DataSource = Service.GetAllVwCptooperacion(whereTipoOpeEgr,
                        "nombrecptooperacion");
                    
                    iIdcptooperacion.Properties.DisplayMember = "Nombrecptooperacion";
                    iIdcptooperacion.Properties.ValueMember = "Idcptooperacion";
                    iIdcptooperacion.Properties.BestFitMode = BestFitMode.BestFit;
                    break;

            }
        }

        private void CargarReferencias()
        {
            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void ValoresPorDefecto()
        {
            iIdtipomoneda.EditValue = 1; //Soles
        }
    }
}
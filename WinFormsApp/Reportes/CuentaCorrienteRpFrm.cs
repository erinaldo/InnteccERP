using System;
using System.Data;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using FastReport;
using Utilities;

namespace WinFormsApp
{
    public partial class CuentaCorrienteRpFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public CuentaCorrienteRpFrm()
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
                       iIdsocionegocio.EditValue,
                       SessionApp.SucursalSel.Idsucursal,
                        rgTipoReporte.SelectedIndex,
                        idTipoMoneda
                    };

            switch (lbOptions.SelectedIndex)
            {
                case 0://Ordenes de compra pendiente de ingresos
                    sqlQuery = "reportes.fn_ctactecliente";
                    dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametros);
                    nameFileReport = "ctactecliente.repx";
                   
                    break;
                case 1: //Ordenes de compra pendiente de comprobante de compra

                    sqlQuery = "reportes.fn_ctacteproveedor";
                    dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametros);
                    nameFileReport = "ctacteproveedor.repx";
                    break;
            }
            
            
            string rutaArchivoReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Gerencia\\{0}", nameFileReport));
            XtraReport xtraReport = new XtraReport { DataSource = dt };
            xtraReport.LoadLayout(rutaArchivoReporte);

            object[] parametrosReporte = {
                    iIdtipomoneda.Text.Trim()
                    };

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
                        beSocionegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 1: //Borrar
                    beSocionegocio.Text = @"Todos los proveedores";
                    iIdsocionegocio.EditValue = null;
                    break;
            }
        }

        private void CuentaCorrienteRpFrm_Load(object sender, EventArgs e)
        {
            iFechaInicio.EditValue = SessionApp.DateServer;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;

            rgOpcionReporte.SelectedIndex = 0;
            rgTipoReporte.SelectedIndex = 2;
            CargarReferencias();
            ValoresPorDefecto();
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
            iIdtipomoneda.EditValue = 1; //Nuevos Soles
        }
    }
}
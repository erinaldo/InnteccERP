using System;
using System.Collections.Generic;
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
    public partial class GastoPorCentroCostoRpFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public List<VwCentrodecosto> VwCentrodecostoList { get; set; }
        public GastoPorCentroCostoRpFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            
        }

        private void CargarReferencias()
        {
            string whereCentroCosto = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwCentrodecostoList = Service.GetAllVwCentrodecosto(whereCentroCosto, "descripcioncentrodecosto");
            iIdCentroCosto.Properties.DataSource = VwCentrodecostoList;
            iIdCentroCosto.Properties.DisplayMember = "Descripcioncentrodecosto";
            iIdCentroCosto.Properties.ValueMember = "Idcentrodecosto";
            iIdCentroCosto.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
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
                       iIdCentroCosto.EditValue,
                       SessionApp.SucursalSel.Idsucursal,
                       idTipoMoneda
                    };

            switch (lbOptions.SelectedIndex)
            {
                case 0://Ordenes de compra pendiente de ingresos

                    sqlQuery = "reportes.fn_gastos_cc_resumen_articulo";
                    
                    dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametros);

                    nameFileReport = "centrocostoxarticulo.repx";
                   
                    
                    break;
                case 1: //Ordenes de compra pendiente de comprobante de compra
                    sqlQuery = "reportes.fn_gastos_cc_x_cp";
                    
                    dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametros);

                    nameFileReport = "centrocostoxcomprobante.repx";
                    break;
            }

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

        private void GastoPorCentroCostoRpFrm_Load(object sender, EventArgs e)
        {
            CargarReferencias();
            iFechaInicio.EditValue = SessionApp.DateServer;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;
            ValoresPorDefecto();
        }

        private void btnLimpiarCentroDeCosto_Click(object sender, EventArgs e)
        {
            iIdCentroCosto.EditValue = null;
        }
        private void ValoresPorDefecto()
        {
            iIdtipomoneda.EditValue = 1; //Soles
        }
    }
}
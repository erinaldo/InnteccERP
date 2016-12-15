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
    public partial class GastoPorCentroCostoRpFrmCopy : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public GastoPorCentroCostoRpFrmCopy()
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

           string sqlQuery;
            string nameFileReport = string.Empty;
            DataTable dt = null;

            object[] parametros = {
                        fechaInicio,
                        fechaFinal,
                       iIdCentroCosto.EditValue,
                       SessionApp.SucursalSel.Idsucursal
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
            
            
            string rutaArchivoReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Gerencia\\{0}", nameFileReport));
            XtraReport xtraReport = new XtraReport { DataSource = dt };
            xtraReport.LoadLayout(rutaArchivoReporte);
            ReportHelper2 reportHelper2 = new ReportHelper2(rutaArchivoReporte, dt, null, null);
           

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

        private void beCentroCosto_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        beCentroCosto.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdCentroCosto.EditValue = vwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 1: //Borrar
                    beCentroCosto.Text = @"Todos los centros de costo";
                    iIdCentroCosto.EditValue = null;
                    break;
            }
        }

        private void GastoPorCentroCostoRpFrmCopy_Load(object sender, EventArgs e)
        {
            iFechaInicio.EditValue = SessionApp.DateServer;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;
        }
    }
}
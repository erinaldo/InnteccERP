using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Utilities;

namespace WinFormsApp
{
    public partial class ReportHelper2 : XtraForm
    {
        public string FileName { get; set; }
        public DataTable DataSource { get; set; }
        ReportPrintTool ReportPrintToolCustom { get; set; }
        public object[] Parameters { get; set; }
        public string NameReport { get; set; }
        public ReportHelper2(string fileName, DataTable dataSource, object[] parameters, string nameReport)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            DataSource = dataSource;
            FileName = fileName;
            Parameters = parameters;
            NameReport = nameReport;
        }

        private void ReportHelper2_Load(object sender, EventArgs e)
        {
            lbcOpciones.SelectedIndex = 0;
            //if (UsuarioAutenticado.UsuarioSel.Idusuario != 1)
            //{
            //    btnDiseño.Visible = false;
            //}
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int opcionSeleccionada = lbcOpciones.SelectedIndex;
            XtraReport report;
            switch (opcionSeleccionada)
            {
                case 0: //Vista preliminar
                    report = PrepareReport();
                    report.DisplayName = string.IsNullOrEmpty(NameReport) ? "Reporte" : NameReport;  
                    ReportPrintToolCustom = new ReportPrintTool(report) { AutoShowParametersPanel = false };
                    ReportPrintToolCustom.ShowPreviewDialog();
                    break;
                case 1: //Impresora
                    report = PrepareReport();
                    report.PrintDialog();
                    break;
                case 2: //Archivo PDF
                    report = PrepareReport();
                    report.DisplayName = string.IsNullOrEmpty(NameReport) ? "Reporte" : NameReport;  

                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        RestoreDirectory = true,
                        Filter = @"Archivos PDF | *.pdf",
                        Title = @"Guardar como..."
                    };
                    saveFileDialog.Filter = @"(*.pdf)|*.pdf";
                    saveFileDialog.FileName = report.DisplayName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;

                        report.ExportToPdf(saveFileDialog.FileName);

                        Cursor = Cursors.Default;

                        if (File.Exists(saveFileDialog.FileName))
                        {
                            if (XtraMessageBox.Show("¿Desea abrir el archivo pdf?", "Guardar como PDF", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                System.Diagnostics.Process.Start(saveFileDialog.FileName);
                            }                            
                        }
                    }
                    
                    break;

            }

        }

        private XtraReport PrepareReport()
        {
            XtraReport report = new XtraReport();
            report.DataSource = DataSource;
            report.DisplayName = string.IsNullOrEmpty(NameReport) ? "Reporte" : NameReport;            
            report.LoadLayout(FileName);

            //Asignar parametros
            if (report.Parameters != null && Parameters != null)
            {
                for (var i = 0; i < report.Parameters.Count; i++)
                {
                    report.Parameters[i].Value = Parameters[i];
                }
            }
            report.RequestParameters = false;
            report.ShowPrintMarginsWarning = false; 
            return report;
        }

        private void ReportHelper2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnDiseño_Click(object sender, EventArgs e)
        {
            XtraReport report = new XtraReport { DataSource = DataSource };
            report.LoadLayout(FileName);

            XRDesignFormEx xrDfe = new XRDesignFormEx();
            xrDfe.OpenReport(report);
            xrDfe.DesignPanel.FileName = FileName;
            xrDfe.WindowState = FormWindowState.Maximized;
            xrDfe.ShowDialog();
        }
    }
}
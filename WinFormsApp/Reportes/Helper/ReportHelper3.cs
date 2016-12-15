using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Utilities;

namespace WinFormsApp
{
    public partial class ReportHelper3 : XtraForm
    {
        public string FileName { get; set; }
        public DataSet DataSource { get; set; }
        ReportPrintTool ReportPrintToolCustom { get; set; }
        public object[] Parameters { get; set; }
        public string NameReport { get; set; }


        public ReportHelper3(string fileName, DataSet dataSource, object[] parameters, string nameReport)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            DataSource = dataSource;
            FileName = fileName;
            Parameters = parameters;
            NameReport = nameReport;
        }

        private void ReportHelper3_Load(object sender, EventArgs e)
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
                    report = new XtraReport { DataSource = DataSource };
                    if (!string.IsNullOrEmpty(NameReport))
                    {
                        report.Name = NameReport;
                    }

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
                    ReportPrintToolCustom = new ReportPrintTool(report) { AutoShowParametersPanel = false };
                    ReportPrintToolCustom.ShowPreviewDialog();
                    break;
                case 1: //Impresora

                    report = new XtraReport { DataSource = DataSource };
                    if (!string.IsNullOrEmpty(NameReport))
                    {
                        report.Name = NameReport;
                    }

                    //Asignar parametros
                    if (report.Parameters != null && Parameters != null)                   
                    {
                        for (var i = 0; i < report.Parameters.Count; i++)
                        {
                            report.Parameters[i].Value = Parameters[i];
                        }
                    }


                    report.LoadLayout(FileName);
                    report.ShowPrintMarginsWarning = false;
                    report.PrintDialog();
                    break;
                case 2: //Archivo PDF
                    break;

            }

        }

        private void ReportHelper3_FormClosed(object sender, FormClosedEventArgs e)
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
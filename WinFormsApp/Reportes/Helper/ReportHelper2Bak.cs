using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Utilities;

namespace WinFormsApp
{
    public partial class ReportHelper2Bak : XtraForm
    {
        public XtraReport Reporte { get; set; }
        public string FileName { get; set; }
        public DataTable DataSetRp { get; set; }
        private static XRDesignFormEx XrDesignFormExHelper { get; set; }
        private XtraReport XtraReportCustom { get; set; }
        ReportPrintTool ReportPrintToolCustom { get; set; }
        private string ImporteDocumentoLetras { get; set; }

        public ReportHelper2Bak(XtraReport reporte, string fileName, DataTable dataSetRp, string importeDocumentoLetras)
        {
            InitializeComponent();
            Reporte = reporte;
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            DataSetRp = dataSetRp;
            FileName = fileName;
            if (XrDesignFormExHelper == null)
            {
                XrDesignFormExHelper = new XRDesignFormEx();
            }
            ImporteDocumentoLetras = importeDocumentoLetras;
        }

        private void ReportHelper2Bak_Load(object sender, EventArgs e)
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
            switch (opcionSeleccionada)
            {
                case 0: //Vista preliminar
                    //using (ReportPrintTool printTool = new ReportPrintTool(Reporte))
                    //{
                    //    // Invoke the Print Preview form modally,  
                    //    // and load the report document into it. 
                    //    printTool.ShowPreviewDialog();
                    //}
                    XtraReportCustom = new XtraReport { DataSource = DataSetRp };                    
                    XtraReportCustom.LoadLayout(FileName);

                    if ((XtraReportCustom.Parameters["TotalDocumentoLetra"]) != null)
                    {
                        XtraReportCustom.Parameters["TotalDocumentoLetra"].Value = ImporteDocumentoLetras;
                    }

                    XtraReportCustom.RequestParameters = false;

                    //XtraReportCustom.ShowPreviewDialog();

                    ReportPrintToolCustom = new ReportPrintTool(XtraReportCustom) {AutoShowParametersPanel = false};
                    ReportPrintToolCustom.ShowPreviewDialog();

                    //Reporte.CreateDocument();
                    //Reporte.ShowPreviewDialog();
                    break;
                case 1: //Impresora
                    XtraReportCustom = new XtraReport { DataSource = DataSetRp };
                    XtraReportCustom.LoadLayout(FileName);
                    XtraReportCustom.ShowPrintMarginsWarning = false;
                    XtraReportCustom.PrintDialog();
                    break;
                case 2: //Archivo PDF
                    //saveFileDialogPdf.Filter = @"Archivo Pdf (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
                    //saveFileDialogPdf.FilterIndex = 1;
                    //saveFileDialogPdf.RestoreDirectory = true;
                    //saveFileDialogPdf.FileName = "reporte.pdf";
                    //if (saveFileDialogPdf.ShowDialog() == DialogResult.OK)
                    //{
                    //    Reporte.Prepare();
                    //    // create export instance
                    //    PDFExport export = new PDFExport();
                    //    // export the report
                    //    Reporte.Export(export, saveFileDialogPdf.FileName);
                    //    // free resources used by report
                    //    Reporte.Dispose();
                    //}
                    break;

            }

        }

        private void ReportHelper2Bak_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnDiseño_Click(object sender, EventArgs e)
        {


            XrDesignFormExHelper.OpenReport(Reporte);
            XrDesignFormExHelper.DesignPanel.FileName = FileName;
            XrDesignFormExHelper.WindowState = FormWindowState.Maximized;
            XrDesignFormExHelper.ShowDialog();

            //XtraReportDesignerFrm xtraReportDesignerFrm = new XtraReportDesignerFrm(Reporte, FileName, null);
            //xtraReportDesignerFrm.ShowDialog();
        }
    }
}
using System.Drawing.Printing;
using System.Windows.Forms;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using FastReport;
using FastReport.Export.Pdf;
using Utilities;

namespace WinFormsApp
{
    public partial class ReportHelper1 : XtraForm
    {
        public Report Reporte { get; set; }

        public ReportHelper1(Report reporte)
        {
            InitializeComponent();
            Reporte = reporte;            
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void ReportHelper1_Load(object sender, System.EventArgs e)
        {
            lbcOpciones.SelectedIndex = 0;
            //if (UsuarioAutenticado.UsuarioSel.Idusuario != 1)
            //{
            //    btnDiseño.Visible = false;
            //}
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            int opcionSeleccionada = lbcOpciones.SelectedIndex;
            switch (opcionSeleccionada)
            {
                case 0: //Vista preliminar
                    PreviewFrm previewFrm = new PreviewFrm(Reporte);
                    previewFrm.ShowDialog();
                    break;
                case 1: //Impresora
                    if (Reporte.Prepare())
                    {
                        PrinterSettings printerSettings;
                        if (Reporte.ShowPrintDialog(out printerSettings))
                        {
                            Reporte.PrintPrepared(printerSettings);
                        }
                    }
                    break;
                case 2: //Archivo PDF
                    saveFileDialogPdf.Filter = @"Archivo Pdf (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
                    saveFileDialogPdf.FilterIndex = 1;
                    saveFileDialogPdf.RestoreDirectory = true;
                    saveFileDialogPdf.FileName = "reporte.pdf";
                    if (saveFileDialogPdf.ShowDialog() == DialogResult.OK)
                    {
                        Reporte.Prepare();
                        // create export instance
                        PDFExport export = new PDFExport();
                        // export the report
                        Reporte.Export(export, saveFileDialogPdf.FileName);
                        // free resources used by report
                        Reporte.Dispose();
                    }
                    break;

            }
            
        }

        private void ReportHelper1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Reporte != null)
            {
                Reporte.Dispose();
            }            
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnDiseño_Click(object sender, System.EventArgs e)
        {
            ReportDesignerFrm reportDesignerFrm = new ReportDesignerFrm(Reporte);
            reportDesignerFrm.ShowDialog();
        }
    }
}
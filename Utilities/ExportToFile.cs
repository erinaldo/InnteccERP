using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;

namespace Utilities
{
    public class ExportUtil
    {
        public static void ExportToFile (GridControl gridControl, string typeExport)
        {
            var dlg = new SaveFileDialog {InitialDirectory = Application.StartupPath };

            switch (typeExport)
            {
                case "btnExportCsv":
                    dlg.Filter = @"Archivo Csv (*.csv) | *.csv | Todos los archivo (*.*) | *.*";
                    break;
                case "btnExportHtml":
                    dlg.Filter = @"Archivo Html (*.html) | *.html | Todos los archivo (*.*) | *.*";
                    break;
                case "btnExportImg":
                    dlg.Filter = @"Archivo Png (*.png) | *.png | Todos los archivo (*.*) | *.*";
                    break;
                case "btnExportMht":
                    dlg.Filter = @"Archivo Mht (*.Mht) | *.mht | Todos los archivo (*.*) | *.*";
                    break;
                case "btnExportPdf":
                    dlg.Filter = @"Archivo Pdf (*.Pdf) | *.pdf | Todos los archivo (*.*) | *.*";
                    break;
                case "btnExportRtf":
                    dlg.Filter = @"Archivo Rtf (*.Rtf) | *.rtf | Todos los archivo (*.*) | *.*";
                    break;
                case "btnExportTxt":
                    dlg.Filter = @"Archivo Txt (*.txt) | *.txt | Todos los archivo (*.*) | *.*";
                    break;
                case "btnExportXls":
                    dlg.Filter = @"Archivo Xls (*.xls) | *.xls | Todos los archivo (*.*) | *.*";
                    break;
                case "btnExportXlsx":
                    dlg.Filter = @"Archivo Xlsx (*.xlsx) | *.xlsx | Todos los archivo (*.*) | *.*";
                    break;
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                switch (typeExport)
                {
                    case "btnExportCsv":
                        gridControl.ExportToCsv(dlg.FileName);
                        break;
                    case "btnExportHtml":
                        gridControl.ExportToHtml(dlg.FileName);
                        break;
                    case "btnExportImg":
                        var ps = new PrintingSystem();
                        var link = new PrintableComponentLink(ps) {Component = gridControl};
                        link.CreateDocument();
                        link.PrintingSystem.ExportToImage(dlg.FileName);
                        break;
                    case "btnExportMht":
                        gridControl.ExportToMht(dlg.FileName);
                        break;
                    case "btnExportPdf":
                        gridControl.ExportToPdf(dlg.FileName);
                        break;
                    case "btnExportRtf":
                        gridControl.ExportToRtf(dlg.FileName);
                        break;
                    case "btnExportTxt":
                        gridControl.ExportToText(dlg.FileName);
                        break;
                    case "btnExportXls":
                        gridControl.ExportToXls(dlg.FileName);
                        break;
                    case "btnExportXlsx":
                        gridControl.ExportToXlsx(dlg.FileName);
                        break;
                }                

                if (DialogResult.Yes == XtraMessageBox.Show("¿Desea abrir el archivo?",
                                                        "Exportar archivo",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button1))
                {
                    var process = new Process {StartInfo = {FileName = dlg.FileName}};
                    process.Start();
                }
            }

    
        }
    }
}
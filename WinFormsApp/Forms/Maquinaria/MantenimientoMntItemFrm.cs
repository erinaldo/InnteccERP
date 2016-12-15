using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class MantenimientoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Mantenimientoimagen MantenimientoimagenMnt { get; set; }
        public string RutaArchivoServidor { get; set; }
        public MantenimientoMntItemFrm(TipoMantenimiento tipoMnt, Mantenimientoimagen mantenimientoimagenMnt, string rutaArchivoServidor)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            MantenimientoimagenMnt = mantenimientoimagenMnt;
            RutaArchivoServidor = rutaArchivoServidor;
        }
        private void MantenimientoMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    TraerDatos();
                    break;
            }
        }
        private void ValoresPorDefecto()
        {
            iNumeroitem.EditValue = MantenimientoimagenMnt.Numeroitem;
        
        }
        private void TraerDatos()
        {            
            iNombrearchivo.EditValue = MantenimientoimagenMnt.Nombrearchivo;
            iComentario.EditValue = MantenimientoimagenMnt.Comentario;
            iNumeroitem.EditValue = MantenimientoimagenMnt.Numeroitem;
        }
        private void CargarReferencias()
        {


        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            MantenimientoimagenMnt.Nombrearchivo = Path.GetFileName(iNombrearchivo.Text.Trim());
                            break;
                        case TipoMantenimiento.Modificar:
                            MantenimientoimagenMnt.Nombrearchivo = Path.GetFileName(iNombrearchivo.Text.Trim());
                            break;
                    }
			        
			        MantenimientoimagenMnt.Comentario = iComentario.Text.Trim();
			        MantenimientoimagenMnt.Numeroitem = (int)iNumeroitem.EditValue;

                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            //VwOrdendeventadetalleMnt.Createdby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwOrdendeventadetalleMnt.Creationdate = DateTime.Now;
                            break;
                        case TipoMantenimiento.Modificar:
                            //VwOrdendeventadetalleMnt.Modifiedby = UsuarioAutenticado.UsuarioSel.Idusuario;
                            //VwOrdendeventadetalleMnt.Lastmodified = DateTime.Now;
                            break;
                    }

                    switch (TipoMnt)
                    {
                        case  TipoMantenimiento.Nuevo:
                            MantenimientoimagenMnt.DataEntityState = DataEntityState.Added;
                            break;
                        case TipoMantenimiento.Modificar:
                            MantenimientoimagenMnt.DataEntityState = DataEntityState.Modified;                            
                            break;
                    }
                                        
                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpProducto, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
        private void MantenimientoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void iNombrearchivo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Seleccionar
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = @"Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.tif|Microsoft Office|*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx|PDF|*.pdf"
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        switch (TipoMnt)
                        {
                            case TipoMantenimiento.Nuevo:                                
                                iNombrearchivo.EditValue = openFileDialog.FileName;
                                MantenimientoimagenMnt.RutaArchivo = openFileDialog.FileName;
                                break;
                            case TipoMantenimiento.Modificar:
                                iNombrearchivo.EditValue = openFileDialog.FileName;
                                MantenimientoimagenMnt.RutaArchivo = openFileDialog.FileName;
                                break;
                        }


                    }
                    break;
                case 1: //Abrir
                    switch (TipoMnt)
                    {
                        case TipoMantenimiento.Nuevo:
                            Process.Start(MantenimientoimagenMnt.RutaArchivo);
                            break;
                        case TipoMantenimiento.Modificar:
                            if (File.Exists((string) iNombrearchivo.EditValue))
                            {
                                Process.Start((string) iNombrearchivo.EditValue);
                            }
                            else
                            {
                                string fileNameSource = MantenimientoimagenMnt.Idmantenimientoimagen + Path.GetExtension(MantenimientoimagenMnt.Nombrearchivo);
                                string sourcePath = Path.Combine(RutaArchivoServidor, ConstantesGlobales.RutaArchivoEquipoMaquinaria, MantenimientoimagenMnt.Idmantenimiento.ToString());
                                string fileServer = Path.Combine(sourcePath, fileNameSource);

                                string fileNameDest = string.Format("#{0}", MantenimientoimagenMnt.Nombrearchivo);

                                if (!string.IsNullOrEmpty(fileNameDest))
                                {
                                    string sourceFile = fileServer;
                                    string destFile = Path.Combine(Path.GetTempPath(), fileNameDest);

                                    if (Directory.Exists(sourcePath))
                                    {
                                        File.Copy(sourceFile, destFile, true);
                                        File.SetAttributes(destFile, FileAttributes.Archive | FileAttributes.Temporary);

                                        File.SetLastWriteTime(destFile, DateTime.Now);
                                        Process.Start(destFile);
                                    }
                                }                                
                            }
                            break;
                    }
                    break;

            }

        }


        private void MantenimientoMntItemFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
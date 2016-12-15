using System;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class PeriodoFrm : XtraForm
    {        
        public bool SaveLayoutGridControl { get; set; }
        public bool SaveLayoutBarManager { get; set; }
        private readonly string _regKeyGridControl;        
        private readonly string _regKeyBarManager;

        public int IdEntidadMnt { get; set; }
        public string NombreColumnaPk { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public Accesoform Permisos { get; set; }       
        public int IdUsuario { get; set; }

        private static PeriodoFrm _uniqueInstance;
        private static readonly object SyncLock = new Object();

        static readonly IService Service = new Service();

        private PeriodoFrm()
        {

            InitializeComponent();

            _regKeyGridControl = string.Format("WinFormsApp\\Layouts\\{0}_MainLayout", Name);
            _regKeyBarManager = string.Format("WinFormsApp\\DockStates\\{0}_Bamanager_MainState", Name);
            SaveLayoutGridControl = false;
            SaveLayoutBarManager = false;

            IdUsuario = SessionApp.UsuarioSel.Idusuario;

            IdEntidadMnt = 0;
            NombreColumnaPk = "Idperiodo";
        }

        public static PeriodoFrm GetInstance()
        {
            // Lock entire body of method
            lock (SyncLock)
            {
                if (_uniqueInstance == null || _uniqueInstance.IsDisposed)
                {
                    _uniqueInstance = new PeriodoFrm();
                }
                _uniqueInstance.BringToFront();
                return _uniqueInstance;
            }
        }

        private void PeriodoFrm_Load(object sender, EventArgs e)
        {
            RestoreLayoutFromRegistry();
            EstablecerPermisos();
            CargarDatosConsulta();
        }

        public void CargarDatosConsulta()
        {
            Cursor = Cursors.WaitCursor;
            gcConsulta.BeginUpdate();
            string condicionEmpresa = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            gcConsulta.DataSource = Service.GetAllVwPeriodo(condicionEmpresa, "anioejercicio,mes");

            gvConsulta.BestFitColumns(); 
            gcConsulta.EndUpdate();

            int rowCount = gvConsulta.RowCount;

            btnNuevo.Enabled = Permisos.Nuevo; 
            btnModificar.Enabled = rowCount != 0 && Permisos.Editar ;
            btnEliminar.Enabled = rowCount != 0 && Permisos.Eliminar; 
            bsiExportar.Enabled = rowCount != 0 && Permisos.Imprimir;               
                
            Cursor = Cursors.Default;           
        }

        private void ShowFormMnt()
        {
            if (TipoMnt == TipoMantenimiento.SinEspecificar)
            {
                throw new ArgumentException("No se especifico el tipo de mantenimiento.");
            }

            AsignarIdEntidadMnt();
            var formMnt = new PeriodoMntFrm(IdEntidadMnt, TipoMnt, gcConsulta, this);
            formMnt.ShowDialog();
        }
        private void EliminaRegistro()
        {
            if (DialogResult.Yes == XtraMessageBox.Show(Resources.msgEliminarRegistro,
                                                    Resources.titPregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button1))
            {
                TipoMnt = TipoMantenimiento.Eliminar;
                try
                {
                    Cursor = Cursors.WaitCursor;
                    AsignarIdEntidadMnt();
                    Service.DeletePeriodo(IdEntidadMnt);
                    CargarDatosConsulta();
                }
                catch
                {
                    Cursor = Cursors.Default;
                    throw;
                } 
            }
        }

        private void bmConsulta_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            switch (e.Item.Name)
            {
                case "btnNuevo":
                    TipoMnt = TipoMantenimiento.Nuevo;
                    ShowFormMnt();
                    break;
                case "btnModificar":
                    TipoMnt = TipoMantenimiento.Modificar;
                    ShowFormMnt();
                    break;
                case "btnEliminar":
                    EliminaRegistro();
                    break;
                case "btnActualizar":
                    CargarDatosConsulta();
                    break;
                case "btnCerrar":
                    Close();
                    break;
                case "btnExportCsv":
                case "btnExportHtml":
                case "btnExportMht":
                case "btnExportImg":
                case "btnExportPdf":
                case "btnExportRtf":
                case "btnExportTxt":
                case "btnExportXls":
                case "btnExportXlsx":
                    ExportUtil.ExportToFile(gcConsulta, e.Item.Name);
                    break;
            }
        }        

        public void EstablecerPermisos()
        {
            Permisos = Service.GetPermisosForm(IdUsuario, Name);
            btnNuevo.Enabled = Permisos.Nuevo;
            btnModificar.Enabled = Permisos.Editar;
            btnEliminar.Enabled = Permisos.Eliminar;
            bsiExportar.Enabled = Permisos.Imprimir;
        }

        private void PeriodoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayoutToRegistry();
        }

        public void RestoreLayoutFromRegistry()
        {
            if (SaveLayoutGridControl)
                gcConsulta.MainView.RestoreLayoutFromRegistry(_regKeyGridControl);
            if (SaveLayoutBarManager)
                bmConsulta.RestoreFromRegistry(_regKeyBarManager);            
        }

        public void SaveLayoutToRegistry()
        {
            if (SaveLayoutGridControl)
                gcConsulta.MainView.SaveLayoutToRegistry(_regKeyGridControl);
            if (SaveLayoutBarManager)
                bmConsulta.SaveLayoutToRegistry(_regKeyBarManager);
        }

        private void AsignarIdEntidadMnt()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    IdEntidadMnt = 0;
                    break;
                case TipoMantenimiento.Eliminar:                    
                    IdEntidadMnt = Convert.ToInt32(gvConsulta.GetRowCellValue(gvConsulta.FocusedRowHandle, NombreColumnaPk));
                    break;
                case TipoMantenimiento.Modificar:
                    IdEntidadMnt = Convert.ToInt32(gvConsulta.GetRowCellValue(gvConsulta.FocusedRowHandle, NombreColumnaPk));
                    break;
            }            
        }

        private void gcConsulta_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                gvConsulta.ShowFindPanel();
            }

        }

        private void gvConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            gvConsulta.ShowEditor();
            if (e.KeyCode == Keys.Enter)
            {
                TipoMnt = TipoMantenimiento.Modificar;
                ShowFormMnt();
            }
        }

        private void gvConsulta_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null) view.ActiveEditor.DoubleClick += gvConsulta_CellDoubleClick;
        }

        private void gvConsulta_CellDoubleClick(object sender, EventArgs e)
        {
            TipoMnt = TipoMantenimiento.Modificar;
            ShowFormMnt();
        }

        public void SetFocusIdEntity()
        {
            if (IdEntidadMnt > 0)
            {
                if (gvConsulta.RowCount > 0)
                {
                    gcConsulta.BeginUpdate();
                    var rowHandle = gvConsulta.LocateByValue(NombreColumnaPk, IdEntidadMnt);
                    if (rowHandle == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        gcConsulta.EndUpdate();
                        return;
                    }
                    gcConsulta.EndUpdate();
                    gvConsulta.FocusedRowHandle = rowHandle;
                }

            }
        }

        private void gvConsulta_MouseWheel(object sender, MouseEventArgs e)
        {
            if (gvConsulta.IsEditing)
            {
                gvConsulta.CloseEditor();
            }
        }


      
    }
}
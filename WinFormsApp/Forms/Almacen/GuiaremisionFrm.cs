using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class GuiaremisionFrm : XtraForm
    {
        public string FechaInicialConsulta { get; set; }
        public string FechaFinalConsulta { get; set; }
        public string DescripcionFiltroFecha { get; set; }
        public bool SaveLayoutGridControl { get; set; }
        public bool SaveLayoutBarManager { get; set; }

        private readonly string _regKeyGridControl;    
    
        private readonly string _regKeyBarManager;

        public int IdEntidadMnt { get; set; }
        public string NombreIdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public Accesoform Permisos { get; set; }
        public int IdUsuario { get; set; }

        private static GuiaremisionFrm _uniqueInstance;
        private static readonly object SyncLock = new Object();

        static readonly IService Service = new Service();
        public List<VwGuiaremision> VwGuiaremisionList { get; set; }
        private GuiaremisionFrm()
        {

            InitializeComponent();

            _regKeyGridControl = string.Format("WinFormsApp\\Layouts\\{0}_MainLayout", Name);
            _regKeyBarManager = string.Format("WinFormsApp\\DockStates\\{0}_Bamanager_MainState", Name);
            SaveLayoutGridControl = false;
            SaveLayoutBarManager = false;

            IdUsuario = SessionApp.UsuarioSel.Idusuario;

            IdEntidadMnt = 0;
            NombreIdEntidadMnt = "Idguiaremision";            
        }
        public static GuiaremisionFrm GetInstance()
        {
            // Lock entire body of method
            lock (SyncLock)
            {
                if (_uniqueInstance == null || _uniqueInstance.IsDisposed)
                {
                    _uniqueInstance = new GuiaremisionFrm();
                }
                _uniqueInstance.BringToFront();
                return _uniqueInstance;
            }
        }
        private void GuiaremisionFrm_Load(object sender, EventArgs e)
        {
            DescripcionFiltroFecha = string.Format("HOY {0}", SessionApp.DateServer.ToString("dd/MM/yyyy"));
            FechaInicialConsulta = SessionApp.DateServer.ToString("yyyy-MM-dd");
            FechaFinalConsulta = SessionApp.DateServer.ToString("yyyy-MM-dd");

            RestoreLayoutFromRegistry();
            EstablecerPermisos();
            CargarDatosConsulta(DescripcionFiltroFecha, FechaInicialConsulta, FechaFinalConsulta);
        }
        public void CargarDatosConsulta(string descripcionFiltroFecha, string fechaInicialConsulta, string fechaFinalConsulta)
        {
            Cursor = Cursors.WaitCursor;
            gcConsulta.BeginUpdate();

            sbiFiltro.Caption = descripcionFiltroFecha;

            string filtro = string.Format("idsucursal = {0} and fechaguiaremision between '{1}' and '{2}'"
                    , SessionApp.SucursalSel.Idsucursal
                    , fechaInicialConsulta
                    , fechaFinalConsulta);

            VwGuiaremisionList = Service.GetAllVwGuiaremision(filtro, "nombretipoformato,serieguiaremision,numeroguiaremision");
            gcConsulta.DataSource = VwGuiaremisionList;

            gvConsulta.BestFitColumns(); 
            gcConsulta.EndUpdate();

            EstadoBotonesMantenimiento();              
                
            Cursor = Cursors.Default;           
        }
        private void ShowFormMnt()
        {
            if (TipoMnt == TipoMantenimiento.SinEspecificar)
            {
                throw new ArgumentException("No se especifico el tipo de mantenimiento.");
            }

            AsignarIdEntidadMnt();
            var formMnt = new GuiaremisionMntFrm(IdEntidadMnt, TipoMnt, gcConsulta, this);
            formMnt.ShowDialog();

            switch (formMnt.DataEntityState)
            {
                case DataEntityState.Added:
                    VwGuiaremision vwGuiaremisionAdded = Service.GetVwGuiaremision(x => x.Idguiaremision == formMnt.IdEntidadMnt);
                    VwGuiaremisionList.Add(vwGuiaremisionAdded);
                    IdEntidadMnt = formMnt.IdEntidadMnt;
                    SetFocusIdEntity();
                    EstadoBotonesMantenimiento();
                    break;
                case DataEntityState.Modified:
                    VwGuiaremision vwGuiaremisionUnchanged = VwGuiaremisionList.FirstOrDefault(x => x.Idguiaremision == formMnt.IdEntidadMnt);
                    int index = VwGuiaremisionList.IndexOf(vwGuiaremisionUnchanged);
                    VwGuiaremisionList.Remove(vwGuiaremisionUnchanged);
                    if (vwGuiaremisionUnchanged != null)
                    {
                        VwGuiaremisionList.Insert(index, Service.GetVwGuiaremision(x => x.Idguiaremision == formMnt.IdEntidadMnt));
                    }
                    break;
                case DataEntityState.Deleted:
                    VwGuiaremisionList.Remove(VwGuiaremisionList.SingleOrDefault(x => x.Idguiaremision == formMnt.IdEntidadMnt));
                    break;
            }

            gcConsulta.RefreshDataSource();
            gvConsulta.BestFitColumns(true);
        }

        private void EstadoBotonesMantenimiento()
        {
            int rowCount = gvConsulta.RowCount;
            btnNuevo.Enabled = Permisos.Nuevo;
            btnModificar.Enabled = rowCount != 0 && Permisos.Editar;
            btnEliminar.Enabled = rowCount != 0 && Permisos.Eliminar;
            bsiExportar.Enabled = rowCount != 0 && Permisos.Imprimir;
            gvConsulta.BestFitColumns(); 
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
                    Service.DeleteGuiaremision(IdEntidadMnt);
                    CargarDatosConsulta(DescripcionFiltroFecha, FechaInicialConsulta, FechaFinalConsulta);
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
                    CargarDatosConsulta(DescripcionFiltroFecha, FechaInicialConsulta, FechaFinalConsulta);
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
                case "btnFiltro":
                    FiltroFormConsultaFrm filtroFormConsulta = new FiltroFormConsultaFrm();
                    if (filtroFormConsulta.ShowDialog() == DialogResult.OK)
                    {
                        DescripcionFiltroFecha = filtroFormConsulta.DescripcionFiltroFecha;
                        FechaInicialConsulta = filtroFormConsulta.FechaInicialConsulta;
                        FechaFinalConsulta = filtroFormConsulta.FechaFinalConsulta;
                        CargarDatosConsulta(DescripcionFiltroFecha, FechaInicialConsulta, FechaFinalConsulta);
                    }
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
        private void GuiaremisionFrm_FormClosing(object sender, FormClosingEventArgs e)
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
                    IdEntidadMnt = Convert.ToInt32(gvConsulta.GetRowCellValue(gvConsulta.FocusedRowHandle, NombreIdEntidadMnt));
                    break;
                case TipoMantenimiento.Modificar:
                    IdEntidadMnt = Convert.ToInt32(gvConsulta.GetRowCellValue(gvConsulta.FocusedRowHandle, NombreIdEntidadMnt));                    
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
                    var rowHandle = gvConsulta.LocateByValue(NombreIdEntidadMnt, IdEntidadMnt);
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
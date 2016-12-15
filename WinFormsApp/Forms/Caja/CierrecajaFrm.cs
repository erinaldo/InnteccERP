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
    public partial class CierrecajaFrm : XtraForm
    {
        public FiltroConsulta FiltroConsulta { get; set; }
        public bool SaveLayoutGridControl { get; set; }
        public bool SaveLayoutBarManager { get; set; }
        public List<VwCierrecaja> VwCierrecajaList { get; set; }

        private readonly string _regKeyGridControl;        
        private readonly string _regKeyBarManager;

        public int IdEntidadMnt { get; set; }
        public string NombreIdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public Accesoform Permisos { get; set; }       
        public int IdUsuario { get; set; }

        private static CierrecajaFrm _uniqueInstance;
        private static readonly object SyncLock = new Object();

        private static readonly IService Service = new Service();
        private CierrecajaFrm()
        {

            InitializeComponent();

            _regKeyGridControl = string.Format("WinFormsApp\\Layouts\\{0}_MainLayout", Name);
            _regKeyBarManager = string.Format("WinFormsApp\\DockStates\\{0}_Bamanager_MainState", Name);
            SaveLayoutGridControl = false;
            SaveLayoutBarManager = false;

            IdUsuario = SessionApp.UsuarioSel.Idusuario;

            IdEntidadMnt = 0;
            NombreIdEntidadMnt = "Idcierrecaja";            
        }
        public static CierrecajaFrm GetInstance()
        {
            // Lock entire body of method
            lock (SyncLock)
            {
                if (_uniqueInstance == null || _uniqueInstance.IsDisposed)
                {
                    _uniqueInstance = new CierrecajaFrm();
                }
                _uniqueInstance.BringToFront();
                return _uniqueInstance;
            }
        }
        private void CierrecajaFrm_Load(object sender, EventArgs e)
        {
            FiltroConsulta = EstablecerFiltroConsulta();
            RestoreLayoutFromRegistry();
            EstablecerPermisos();
            CargarDatosConsulta(EstablecerFiltroConsulta());
        }
        private static FiltroConsulta EstablecerFiltroConsulta()
        {
            FiltroConsulta filtroConsultaDefecto = new FiltroConsulta();
            filtroConsultaDefecto.Tipo = TipoFiltro.Rango;
            filtroConsultaDefecto.Ejercicio = SessionApp.EjercicioActual;
            filtroConsultaDefecto.Mes = SessionApp.DateServer.Month.ToString("D2");
            filtroConsultaDefecto.DescripcionFiltro = string.Format("HOY {0}",SessionApp.DateServer.ToString("dd/MM/yyyy"));
            filtroConsultaDefecto.FechaInicial = SessionApp.DateServer;
            filtroConsultaDefecto.FechaFinal = SessionApp.DateServer;
            return filtroConsultaDefecto;
        }
        public void CargarDatosConsulta(FiltroConsulta filtroConsultaDefecto)
        {
            Cursor = Cursors.WaitCursor;
            gcConsulta.BeginUpdate();

            sbiFiltro.Caption = filtroConsultaDefecto.DescripcionFiltro;

            string whereReq;
            if (SessionApp.EmpleadoSel == null)
            {
                whereReq = string.Format("idsucursal = {0} and fechacierre between '{1}' and '{2}'"
                    , SessionApp.SucursalSel.Idsucursal
                    , filtroConsultaDefecto.FechaInicial.ToString("yyyy-MM-dd")
                    , filtroConsultaDefecto.FechaFinal.ToString("yyyy-MM-dd"));
            }
            else
            {
                whereReq = string.Format("idsucursal = {0} and idempleado = {1} and fechacierre between '{2}' and '{3}'"
                    , SessionApp.SucursalSel.Idsucursal
                    , (SessionApp.EmpleadoSel == null ? 0 : SessionApp.EmpleadoSel.Idempleado)
                    , filtroConsultaDefecto.FechaInicial.ToString("yyyy-MM-dd"), filtroConsultaDefecto.FechaFinal.ToString("yyyy-MM-dd"));
            }

            //whereReq = string.Format("idsucursal = {0} and idempleado = {1}", UsuarioAutenticado.SucursalSel.Idsucursal,(UsuarioAutenticado.EmpleadoSel == null ? 0:UsuarioAutenticado.EmpleadoSel.Idempleado) );
            VwCierrecajaList = Service.GetAllVwCierrecaja(whereReq, "fecharegistro,fechacierre,anioejercicio");

            gcConsulta.DataSource = VwCierrecajaList;

            gvConsulta.BestFitColumns(); 
            gcConsulta.EndUpdate();

            EstadoBotonesMantenimiento();
            Cursor = Cursors.Default;           
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
        private void ShowFormMnt()
        {
            if (TipoMnt == TipoMantenimiento.SinEspecificar)
            {
                throw new ArgumentException("No se especifico el tipo de mantenimiento.");
            }

            AsignarIdEntidadMnt();
            var formMnt = new CierrecajaMntFrm(IdEntidadMnt, TipoMnt, gcConsulta, this);
            formMnt.ShowDialog();

            switch (formMnt.DataEntityState)
            {
                case DataEntityState.Added:
                    VwCierrecaja vwCierrecajaAdded = Service.GetVwCierrecaja(x => x.Idcierrecaja == formMnt.IdEntidadMnt);
                    VwCierrecajaList.Add(vwCierrecajaAdded);
                    IdEntidadMnt = formMnt.IdEntidadMnt;
                    SetFocusIdEntity();
                    EstadoBotonesMantenimiento();
                    break;
                case DataEntityState.Modified:
                    VwCierrecaja vwCierrecajaUnchanged = VwCierrecajaList.FirstOrDefault(x => x.Idcierrecaja == formMnt.IdEntidadMnt);
                    int index = VwCierrecajaList.IndexOf(vwCierrecajaUnchanged);
                    VwCierrecajaList.Remove(vwCierrecajaUnchanged);
                    if (vwCierrecajaUnchanged != null)
                    {
                        VwCierrecajaList.Insert(index,Service.GetVwCierrecaja(x => x.Idcierrecaja == formMnt.IdEntidadMnt));
                    }                        
                    break;
                case DataEntityState.Deleted:
                    VwCierrecajaList.Remove(VwCierrecajaList.SingleOrDefault(x => x.Idcierrecaja == formMnt.IdEntidadMnt));
                    break;
            }

            gcConsulta.RefreshDataSource();
            gvConsulta.BestFitColumns(true);
            
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
                    Service.DeleteCierrecaja(IdEntidadMnt);
                    CargarDatosConsulta(FiltroConsulta);
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
                    CargarDatosConsulta(FiltroConsulta);
                    break;
                case "btnEstado":
                   
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
                    FiltroFormConsulta2Frm filtroFormConsulta2Frm = new FiltroFormConsulta2Frm(FiltroConsulta);
                    if (filtroFormConsulta2Frm.ShowDialog() == DialogResult.OK)
                    {
                        FiltroConsulta = filtroFormConsulta2Frm.FiltroConsulta;
                        CargarDatosConsulta(FiltroConsulta);
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
        private void CierrecajaFrm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gvConsulta_CellDoubleClick(object sender, EventArgs e)
        {
            TipoMnt = TipoMantenimiento.Modificar;
            ShowFormMnt();
        }

        private void gvConsulta_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null) view.ActiveEditor.DoubleClick += gvConsulta_CellDoubleClick;
        }
    }
}
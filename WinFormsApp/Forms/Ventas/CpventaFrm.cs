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
    public partial class CpventaFrm : XtraForm
    {        
        public bool SaveLayoutGridControl { get; set; }
        public bool SaveLayoutBarManager { get; set; }
        private readonly string _regKeyGridControl;        
        private readonly string _regKeyBarManager;

        public int IdEntidadMnt { get; set; }
        public string NombreIdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public Accesoform Permisos { get; set; }       
        public int IdUsuario { get; set; }

        private static CpventaFrm _uniqueInstance;
        private static readonly object SyncLock = new Object();

        static readonly IService Service = new Service();
        public ImpresionFormato ImpresionFormato { get; set; }
        private CpventaFrm()
        {

            InitializeComponent();

            _regKeyGridControl = string.Format("WinFormsApp\\Layouts\\{0}_MainLayout", Name);
            _regKeyBarManager = string.Format("WinFormsApp\\DockStates\\{0}_Bamanager_MainState", Name);
            SaveLayoutGridControl = false;
            SaveLayoutBarManager = false;

            IdUsuario = SessionApp.UsuarioSel.Idusuario;

            IdEntidadMnt = 0;
            NombreIdEntidadMnt = "Idcpventa";            
        }
        public static CpventaFrm GetInstance()
        {
            // Lock entire body of method
            lock (SyncLock)
            {
                if (_uniqueInstance == null || _uniqueInstance.IsDisposed)
                {
                    _uniqueInstance = new CpventaFrm();
                }
                _uniqueInstance.BringToFront();
                return _uniqueInstance;
            }
        }
        private void CpventaFrm_Load(object sender, EventArgs e)
        {
            RestoreLayoutFromRegistry();
            EstablecerPermisos();
            CargarDatosConsulta();
        }
        public void CargarDatosConsulta()
        {
            Cursor = Cursors.WaitCursor;

            gcConsulta.BeginUpdate();
            string where = string.Format("idsucursal = {0} ", SessionApp.SucursalSel.Idsucursal);
            gcConsulta.DataSource = Service.GetAllVwCpventa(where, "nombretipoformato,seriecpventa,numerocpventa");
            gcConsulta.EndUpdate();

            gvConsulta.BestFitColumns(true); 
            
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

            //Cursor = Cursors.WaitCursor;
            AsignarIdEntidadMnt();

            switch (SessionApp.VersionApp)
            {
                case "PRINCIPAL":
                    var formMntPrincipal = new CpventaMntFrmClaro(IdEntidadMnt, TipoMnt, gcConsulta, this);
                    formMntPrincipal.ShowDialog();
                    break;
                case "CLINICA":
                    var formMntClaro = new CpventaMntFrm(IdEntidadMnt, TipoMnt, gcConsulta, this);
                    formMntClaro.ShowDialog();
                    break;

            }

             
           


            //XtraMessageBox.Show(formMnt.IdEntidadMnt.ToString());
            //formMnt.Show();
            //formMnt.BringToFront();
            //formMnt.TopMost = false;
            //Cursor = Cursors.Default;
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
                    Service.DeleteCpventa(IdEntidadMnt);
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
                case "btnReciboIngreso":
                    if (SessionApp.EmpleadoSel != null)
                    {
                        if (EstadoReferenciaCaja())
                        {
                            break;
                        }
                        if (SessionApp.EmpleadoSel != null)
                        {
                            CajaCobroCpVentaFrmResumen cajaCobroCpVentaFrm = new CajaCobroCpVentaFrmResumen(Convert.ToInt32(IdEntidadMnt), SessionApp.EmpleadoSel.Idempleado);
                            cajaCobroCpVentaFrm.ShowDialog();
                            if (cajaCobroCpVentaFrm.DialogResult == DialogResult.OK)
                            {
                               
                            }
                        }
                    }
                    else
                    {
                        WinFormUtils.MessageWarning("Ingrese con usuario valido.");
                    }
                    break;
                case "btnImprimirMovCajaDet":
                    if (ImpresionFormato == null)
                    {
                        ImpresionFormato = new ImpresionFormato();
                    }
                    if (IdEntidadMnt > 0)
                    {
                        
                    }
                    break;
            }
        }

        private bool EstadoReferenciaCaja()
        {
            VwCpventa vwCpventa = (VwCpventa)gvConsulta.GetFocusedRow();
            var idTipoCp = vwCpventa.Idtipocp;
            var serieTipoCp = vwCpventa.Seriecpventa;
            var numeroTipoCp = vwCpventa.Numerocpventa;

            if (Service.CpVentaTieneReferenciaCaja(idTipoCp, serieTipoCp, numeroTipoCp))
            {
                XtraMessageBox.Show("El Comprobante de venta tiene Recibo de Caja", "Atención",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;

        }

        public void EstablecerPermisos()
        {
            Permisos = Service.GetPermisosForm(IdUsuario, Name);
            btnNuevo.Enabled = Permisos.Nuevo;
            btnModificar.Enabled = Permisos.Editar;
            btnEliminar.Enabled = Permisos.Eliminar;
            bsiExportar.Enabled = Permisos.Imprimir;
        }
        private void CpventaFrm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gvConsulta_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view != null && (e.Column.VisibleIndex == 0 && view.IsMasterRowEmpty(e.RowHandle)))
            //{
            //    GridCellInfo gridCellInfo = e.Cell as GridCellInfo;
            //    if (gridCellInfo != null) gridCellInfo.CellButtonRect = Rectangle.Empty;
            //}
        }

        private void btnReciboIngreso_ItemClick(object sender, ItemClickEventArgs e)
        {

        }      
    }
}
using System;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;

namespace WinFormsApp
{
    public partial class ReporteUsuarioFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        private static ReporteUsuarioFrm _uniqueInstance;

        private static readonly object SyncLock = new Object();

        static readonly IService Service = new Service();
        public VwReporteusuario VwReporteusuariosel { get; set; }
        public ReporteUsuarioFrm()
        {

            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
           

        }
        public static ReporteUsuarioFrm GetInstance()
        {
            // Lock entire body of method
            lock (SyncLock)
            {
                if (_uniqueInstance == null || _uniqueInstance.IsDisposed)
                {
                    _uniqueInstance = new ReporteUsuarioFrm();
                }
                _uniqueInstance.BringToFront();
                return _uniqueInstance;
            }
        }
        private void ReporteUsuarioFrm_Load(object sender, EventArgs e)
        {
            CargarReporteUsuario();
            CargarReferencias();

           
        }
        private void CargarReporteUsuario()
        {
            

            Cursor = Cursors.WaitCursor;
            gcConsulta.DataSource = null;
            gcConsulta.BeginUpdate();

            //idestadoreq = 2 (pendientes de aprobacion)



            var resul = Service.GetAllVwReporteusuario("titulopagina,nombrereporte");
            gcConsulta.DataSource = resul;

            gvConsulta.BestFitColumns();
            gcConsulta.EndUpdate();

            Cursor = Cursors.Default; 
        }
        private void CargarReferencias()
        {
           
        }

        private void ReporteUsuarioFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void gvConsulta_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null) view.ActiveEditor.DoubleClick += gvConsulta_CellDoubleClick;
        }
        private void gvConsulta_CellDoubleClick(object sender, EventArgs e)
        {
            var vwReporteusuario = (VwReporteusuario) gvConsulta.GetFocusedRow();
            if (vwReporteusuario != null)
            {
                var nombreFomulario = vwReporteusuario.Nombreformulario;

                var type = Type.GetType("WinFormsApp." + nombreFomulario);
                if (type != null)
                {
                    var form = Activator.CreateInstance(type) as Form;

                    if (form != null)
                        form.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("No Existe Reportes para esta Opcion", "Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

           
        }
    }
}
using System;
using System.Data;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using FastReport;
using Utilities;

namespace WinFormsApp
{
    public partial class SalidaAlmacenRpFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public SalidaAlmacenRpFrm()
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ArticuloSel = null;
            DialogResult = DialogResult.Cancel;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Reporte();
        }

        private void Reporte()
        {
            DateTime fechaInicio = (DateTime)iFechaInicio.EditValue;
            DateTime fechaFinal = (DateTime)iFechaFinal.EditValue;
            int idTipoMoneda = (int) iIdtipomoneda.EditValue;

            var idProveedor = iIdsocionegocio.EditValue;

            string whereProveedor;
            string nameRelation;
            string whereList;
            string ordersList;
            string fieldsList;
            string nameFileReport = string.Empty;
            string nameAlias = null;
            DataTable dt = null;
            string rutaReporte = null;

            switch (lbOptions.SelectedIndex)
            {
               
                case 0: //Resumen de entradas a almacen
                    nameRelation = "almacen.vwresumensalidaalmacen";
                    whereProveedor = idProveedor != null ? string.Format(" and idsocionegocio = {0}", (int)idProveedor) : string.Empty;
                    whereList = string.Format("fechasalida BETWEEN '{0}' and '{1}' and idsucursal = {2} {3} and idtipomoneda = {4} and anulado = '0'"
                    , fechaInicio.ToString("yyyy-MM-dd")
                    , fechaFinal.ToString("yyyy-MM-dd")
                    , SessionApp.SucursalSel.Idsucursal
                    , whereProveedor
                    , idTipoMoneda);
                    ordersList = "razonsocial,seriesalidaalmacen,numerosalidaalmacen";
                    fieldsList = "*";
                    dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
                    nameFileReport = "salidaalmacenres.frx";
                    nameAlias = "en";
                    rutaReporte = "Reportes\\Almacen\\";
                    break;
                case 1: //Entradas de almacen detallado
                    nameRelation = "almacen.vwsalidaalmacendetallado";
                    whereProveedor = idProveedor != null ? string.Format(" and idsocionegocio = {0}", (int)idProveedor) : string.Empty;
                    whereList = string.Format("fechasalida BETWEEN '{0}' and '{1}' and idsucursal = {2} {3} and idtipomoneda = {4} and anulado = '0'"
                    , fechaInicio.ToString("yyyy-MM-dd")
                    , fechaFinal.ToString("yyyy-MM-dd")
                    , SessionApp.SucursalSel.Idsucursal
                    , whereProveedor
                    , idTipoMoneda);
                    ordersList = "razonsocial,serienumerosalida,numeroitem";
                    fieldsList = "*";
                    dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
                    nameFileReport = "salidaalmacendet.frx";
                    nameAlias = "en";
                    rutaReporte = "Reportes\\Almacen\\";
                    break;
            }
            
            var report = new Report();
            string reporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("{0}{1}", rutaReporte,nameFileReport));
            report.Load(reporte);
            report.RegisterData(dt, nameAlias);

            report.SetParameterValue("FechaInicio", fechaInicio);
            report.SetParameterValue("FechaFinal", fechaFinal);

            int opcionReporte = (int)rgOpcionReporte.EditValue;
            switch (opcionReporte)
            {
                case 0: //Vistaprevia
                    report.Show();
                    break;
                case 1: //Diseño
                    report.Design();                    
                    break;
            }            
            report.Dispose();
        }

        private void beSocioNegocio_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        var vwSocionegocioSel = buscarSocioNegocioFrm.VwSocionegocioSel;
                        beSocioNegocio.Text = vwSocionegocioSel.Razonsocial.Trim();
                        iIdsocionegocio.EditValue = vwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 1: //Borrar
                    beSocioNegocio.Text = @"Todos los proveedores";
                    iIdsocionegocio.EditValue = null;
                    break;
            }
        }

        private void SalidaAlmacenRpFrm_Load(object sender, EventArgs e)
        {
            iFechaInicio.EditValue = SessionApp.DateServer;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;
            CargarReferencias();
            ValoresPorDefecto();
        }

        private void ValoresPorDefecto()
        {
            iIdtipomoneda.EditValue = 1; //Soles
        }

        private void CargarReferencias()
        {
            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
        }
    }
}
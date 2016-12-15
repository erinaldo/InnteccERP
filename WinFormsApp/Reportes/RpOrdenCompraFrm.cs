using System;
using System.Collections.Generic;
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
    public partial class RpOrdenCompraFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public RpOrdenCompraFrm()
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
        private void CargarReferencias()
        {
            //string conditionSucursal = string.Format(" idsucursal = '{0}'", UsuarioAutenticado.SucursalSel.Idsucursal);

            iIdarea.Properties.DataSource = CacheObjects.VwAreaList;
            iIdarea.Properties.DisplayMember = "Nombrearea";
            iIdarea.Properties.ValueMember = "Idarea";
            iIdarea.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipomoneda.Properties.DataSource = CacheObjects.TipomonedaList;
            iIdtipomoneda.Properties.DisplayMember = "Nombretipomoneda";
            iIdtipomoneda.Properties.ValueMember = "Idtipomoneda";
            iIdtipomoneda.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void Reporte()
        {
            DateTime fechaInicio = (DateTime)iFechaInicio.EditValue;
            DateTime fechaFinal = (DateTime)iFechaFinal.EditValue;
            string nameRelation = null;
            string whereList = null;
            string ordersList = null;
            string fieldsList = null;
            string nameFileReport = null;
            int idTipoMoneda = (int)iIdtipomoneda.EditValue;

            List<VwSucursal> vwSucursalList =
                       Service.GetAllVwSucursal(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa);

            switch (lbOptions.SelectedIndex)
            {

                case 0:
                    nameRelation = "compras.vwordencompraresumido";

                    if (iIdsocionegocio.EditValue == null)
                    {
                        whereList = string.Format("fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idtipomoneda = {3}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , idTipoMoneda);
                    }
                    else
                    {
                        whereList = string.Format("fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idproveedor = '{3}' and idtipomoneda = {4}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdsocionegocio.EditValue
                       , idTipoMoneda);
                    }
                    ordersList = "serieorden,numeroorden,fechaordencompra";
                    fieldsList = "*";
                    nameFileReport = "ocresumido.frx";
                    break;

                case 1:

                    nameRelation = "compras.vwordencompradetallado";

                    if (iIdsocionegocio.EditValue == null && iIdarea.EditValue == null)
                    {
                        whereList = string.Format("fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idtipomoneda = {3}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , idTipoMoneda);
                        nameFileReport = "ocdetallado.frx";
                    }

                    if (iIdsocionegocio.EditValue == null && iIdarea.EditValue != null)
                    {
                        whereList = string.Format("fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idarea = '{3}' and idtipomoneda = {4}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdarea.EditValue
                       , idTipoMoneda);
                        nameFileReport = "ocdetalladoxarea.frx";
                    }

                    if (iIdsocionegocio.EditValue != null && iIdarea.EditValue == null)
                    {
                        whereList = string.Format("fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idproveedor = '{3}' and idtipomoneda = {4}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdsocionegocio.EditValue
                       , idTipoMoneda);
                        nameFileReport = "ocdetallado.frx";
                    }


                    if (iIdsocionegocio.EditValue != null && iIdarea.EditValue != null)
                    {
                        whereList = string.Format("fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idproveedor = '{3}' and idarea = '{4}' and idtipomoneda = {5}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdsocionegocio.EditValue
                       , iIdarea.EditValue
                       , idTipoMoneda);
                        nameFileReport = "ocdetalladoxarea.frx";
                    }

                    ordersList = "serieorden,numeroorden,fechaordencompra";
                    fieldsList = "*";
                    //    nameFileReport = "ocdetallado.frx";

                    break;
                case 2:
                    nameRelation = "compras.vwordencompradetallado";

                    if (iIdarea.EditValue == null)
                    {
                        whereList = string.Format("fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idtipomoneda = {3}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , idTipoMoneda);
                    }
                    else
                    {
                        whereList = string.Format("fechaordencompra BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idarea = '{3}' and idtipomoneda = {4}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdarea.EditValue
                       , idTipoMoneda);
                    }
                    ordersList = "idarea,serieorden,numeroorden,fechaordencompra";
                    fieldsList = "*";
                    nameFileReport = "ocdetalladoxarea.frx";
                    break;

            }

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            Report report = new Report();

            string reporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", nameFileReport));

            report.Load(reporte);
            report.RegisterData(dt, "oc");
            report.RegisterData(vwSucursalList, "emp");
            report.SetParameterValue("FechaInicio", fechaInicio.ToString("yyyyMMdd"));
            report.SetParameterValue("FechaFinal", fechaFinal.ToString("yyyyMMdd"));
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
        private void RpOrdenCompraFrm_Load(object sender, EventArgs e)
        {
            iFechaInicio.EditValue = SessionApp.DateServer;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;
            CargarReferencias();
            ValoresPorDefecto();
        }
        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lbOptions.SelectedIndex)
            {

                case 0:
                    iIdarea.Visible = false;
                    lcArea.Visible = false;
                    beSocioNegocio.Visible = true;
                    lcProveedor.Visible = true;
                    break;
                case 1:
                    iIdarea.Visible = true;
                    lcArea.Visible = true;
                    beSocioNegocio.Visible = true;
                    lcProveedor.Visible = true;
                    break;
                case 2:
                    beSocioNegocio.Visible = false;
                    lcProveedor.Visible = false;
                    iIdarea.Visible = true;
                    lcArea.Visible = true;
                    break;
            }
        }
        private void ValoresPorDefecto()
        {
            iIdtipomoneda.EditValue = 1; //Soles
        }
    }
}
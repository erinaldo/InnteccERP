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
    public partial class RpCpCompraFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public RpCpCompraFrm()
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
            iIdarticuloclasificacion.Properties.DataSource = Service.GetAllArticuloclasificacion("Nombreclasificacion");
            iIdarticuloclasificacion.Properties.DisplayMember = "Nombreclasificacion";
            iIdarticuloclasificacion.Properties.ValueMember = "Idarticuloclasificacion";
            iIdarticuloclasificacion.Properties.BestFitMode = BestFitMode.BestFit;

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
            string reporte = null;
            List<VwSucursal> vwSucursalList = Service.GetAllVwSucursal(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa);
            int idTipoMoneda = (int)iIdtipomoneda.EditValue;
            string sqlQuery = null;
            object[] parametrosConsulta = { };            

            switch (lbOptions.SelectedIndex)
            {

                case 0:
                    nameRelation = string.Empty;
                    nameFileReport = "registrocompras.frx";
                    sqlQuery = "reportes.fnregistrocompra";
                    parametrosConsulta = new object[] 
                    { 
                        fechaInicio,
                        fechaFinal 
                    };
                    break;

                case 1:
                    // Comprobantes de compra resumido
                    nameRelation = "compras.vwcpcompraresumido";

                    if (iIdsocionegocio.EditValue == null)
                    {
                        whereList = string.Format("fechaemision BETWEEN '{0}' and '{1}' and idsucursal = '{2}'"
                        , fechaInicio.ToString("yyyyMMdd")
                        , fechaFinal.ToString("yyyyMMdd")
                        , SessionApp.SucursalSel.Idsucursal);
                    }
                    else
                    {
                        whereList = string.Format("fechaemision BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idproveedor = '{3}'"
                        , fechaInicio.ToString("yyyyMMdd")
                        , fechaFinal.ToString("yyyyMMdd")
                        , SessionApp.SucursalSel.Idsucursal
                        , iIdsocionegocio.EditValue);
                    }
                    ordersList = "seriecpcompra,numerocpcompra,fechaemision";
                    fieldsList = "*";
                    nameFileReport = "cpcresumido.frx";

                    break;
                case 2:
                    nameRelation = "compras.vwcpcompradetallado";

                    if (iIdsocionegocio.EditValue == null)
                    {
                        whereList = string.Format("fechaemision BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and anulado = '0' and idtipomoneda = {3}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , idTipoMoneda);
                    }
                    else
                    {
                        whereList = string.Format("fechaemision BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idproveedor = '{3}' and anulado = '0' and idtipomoneda = {4} "
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdsocionegocio.EditValue
                       , idTipoMoneda);
                    }
                    ordersList = "idproveedor,seriecpcompra,numerocpcompra,fechaemision";
                    fieldsList = "*";
                    nameFileReport = "cpcdetalladoxproveedor.frx";

                    break;
                case 3:
                    nameRelation = "compras.vwcpcompradetallado";

                    if (iIdarticuloclasificacion.EditValue == null && iIdsocionegocio.EditValue == null)
                    {
                        whereList = string.Format("fechaemision BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and anulado = '0' and idtipomoneda = {3}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , idTipoMoneda);
                    }
                    if (iIdarticuloclasificacion.EditValue == null && iIdsocionegocio.EditValue != null)
                    {
                        whereList = string.Format("fechaemision BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idproveedor = '{3}' and anulado = '0' and idtipomoneda = {4}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdsocionegocio.EditValue
                       , idTipoMoneda);
                    }
                    if (iIdarticuloclasificacion.EditValue != null && iIdsocionegocio.EditValue == null)
                    {
                        whereList = string.Format("fechaemision BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idarticuloclasificacion = '{3}' and anulado = '0' and idtipomoneda = {4}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdarticuloclasificacion.EditValue
                       , idTipoMoneda);
                    }
                    if (iIdarticuloclasificacion.EditValue != null && iIdsocionegocio.EditValue != null)
                    {
                        whereList = string.Format("fechaemision BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idproveedor = '{3}' and idarticuloclasificacion = '{4}' and anulado = '0' and idtipomoneda = {5}"
                       , fechaInicio.ToString("yyyyMMdd")
                       , fechaFinal.ToString("yyyyMMdd")
                       , SessionApp.SucursalSel.Idsucursal
                       , iIdsocionegocio.EditValue
                       , iIdarticuloclasificacion.EditValue
                       , idTipoMoneda);
                    }

                    ordersList = "idproveedor,idarticuloclasificacion,seriecpcompra,numerocpcompra,fechaemision";
                    fieldsList = "*";
                    nameFileReport = "cpcdetalladoxclasificacion.frx";

                    break;
            }

            DataTable dt;

            if (lbOptions.SelectedIndex == 0)
            {
                dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametrosConsulta);
            }
            else
            {
                dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            }

            var report = new Report();

            reporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", nameFileReport));
            report.Load(reporte);
            report.RegisterData(dt, "rc");
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

        private void RpCpCompraFrm_Load(object sender, EventArgs e)
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
            iIdtipomoneda.EditValue = 1; //Nuevos Soles
        }

        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            iIdtipomoneda.Enabled = false;

            switch (lbOptions.SelectedIndex)
            {
                case 0:
                    iIdarticuloclasificacion.Visible = false;
                    lcArea.Visible = false;
                    beSocioNegocio.Visible = false;
                    lcProveedor.Visible = false;
                    break;
                case 1:
                    iIdarticuloclasificacion.Visible = false;
                    lcArea.Visible = false;
                    beSocioNegocio.Visible = true;
                    lcProveedor.Visible = true;
                    //iIdtipomoneda.Enabled = true;
                    break;
                case 2:
                    beSocioNegocio.Visible = true;
                    lcProveedor.Visible = true;
                    iIdarticuloclasificacion.Visible = false;
                    lcArea.Visible = false;
                    iIdtipomoneda.Enabled = true;
                    break;
                case 3:
                    beSocioNegocio.Visible = true;
                    lcProveedor.Visible = true;
                    iIdarticuloclasificacion.Visible = true;
                    lcArea.Visible = true;
                    //iIdtipomoneda.Enabled = true;
                    break;
            }
        }
    }
}
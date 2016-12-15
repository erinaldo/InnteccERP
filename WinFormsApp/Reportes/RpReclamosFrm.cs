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
    public partial class RpReclamosFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();
        public VwAlmacen AlmacenSel { get; set; }
        static readonly HelperDb HelperDb = new HelperDb();
        public RpReclamosFrm()
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
            string whereAlmacen = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
            iIdalmacen.Properties.DataSource = Service.GetAllAlmacen(whereAlmacen, "codigoalmacen");
            iIdalmacen.Properties.DisplayMember = "Nombrealmacen";
            iIdalmacen.Properties.ValueMember = "Idalmacen";
            iIdalmacen.Properties.BestFitMode = BestFitMode.BestFit;

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
            List<VwSucursal> vwSucursalList =
                       Service.GetAllVwSucursal(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa);
            AlmacenSel = Service.GetVwAlmacen(x => x.Idalmacen == (int)iIdalmacen.EditValue);

            switch (lbOptions.SelectedIndex)
            {
                     
                case 0:
                    nameRelation = "almacen.vwentradaalmacenverifica";
                    if (iIdalmacen.EditValue == null)
                    {
                        MessageBox.Show("Seleccione Almacen","Verifique",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        iIdalmacen.Select();
                        return;

                    }
                    if (iIdsocionegocio.EditValue == null)
                    {

                        whereList = string.Format(@"fechaverificacion BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idalmacendestino = '{3}' and idestadoarticulo <> 6
                                                  and idarticulo in(select idarticulo from almacen.vwstock
                                                  where vwentradaalmacenverifica.idarticulo = vwstock.idarticulo 
                                                  and idalmacen = {3}  
                                                  and codigoperiodo = '{5}' and idsucursal = {2} and cantidadstock >0)"
                        , fechaInicio.ToString("yyyyMMdd")
                        , fechaFinal.ToString("yyyyMMdd")
                        , SessionApp.SucursalSel.Idsucursal
                        , iIdalmacen.EditValue
                        
                         , SessionApp.EjercicioActual);

                    }
                    else
                    {
                        whereList = string.Format(@"fechaverificacion BETWEEN '{0}' and '{1}' and idsucursal = '{2}' and idalmacendestino = '{3}' and idsocionegocio = '{4}' and idestadoarticulo <> 6 
                                                  and idarticulo in(select idarticulo from almacen.vwstock
                                                  where vwentradaalmacenverifica.idarticulo = vwstock.idarticulo 
                                                  and idalmacen = {3} 
                                                  and codigoperiodo = '{6}' and idsucursal = {2} and cantidadstock >0)"

                         , fechaInicio.ToString("yyyyMMdd")
                         , fechaFinal.ToString("yyyyMMdd")
                         , SessionApp.SucursalSel.Idsucursal
                         , iIdalmacen.EditValue
                         ,iIdsocionegocio.EditValue
                         
                         ,SessionApp.EjercicioActual);  

                    }
                    ordersList = "idsocionegocio,fechaverificacion,serieentradaalmacen,numeroentradaalmacen";
                        fieldsList = "*";
                        nameFileReport = "almacenreclamos.frx";
                    break;

                case 1:

                    break;
                case 2:
                    break;

            }

                DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

                var report = new Report();

                reporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Almacen\\{0}", nameFileReport));
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

        private void RpReclamosFrm_Load(object sender, EventArgs e)
        {
            iFechaInicio.EditValue = SessionApp.DateServer;
            iFechaFinal.EditValue = SessionApp.DateServer;
            iFechaInicio.Select();
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;
            CargarReferencias();
        }

        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lbOptions.SelectedIndex)
            {

                case 0:
                  
                    break;
                
            }
        }
    }
}
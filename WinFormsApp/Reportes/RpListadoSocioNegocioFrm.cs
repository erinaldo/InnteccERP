using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using FastReport;
using Utilities;

namespace WinFormsApp
{
    public partial class RpListadoSocioNegocioFrm : XtraForm
    {
        public VwArticulo ArticuloSel { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public RpListadoSocioNegocioFrm()
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
         
        }

        private void Reporte()
        {

            string nameRelation = null;
            string whereList = null;
            string ordersList = null;
            string fieldsList = null;
            string nameFileReport = null;
            List<VwSucursal> vwSucursalList = Service.GetAllVwSucursal(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa);

            switch (lbOptions.SelectedIndex)
            {
                   
                case 0:
                    nameRelation = "reportes.vwlistadosocionegocio";
                    whereList = "idsocionegocio IN (select a.idcliente from ventas.cpventa a)";
                    ordersList = "razonsocial";
                    fieldsList = "*";
                    nameFileReport = "listadoclientes.frx";
                    break;

                case 1:

                    nameRelation = "reportes.vwlistadosocionegocio";
                    whereList = "idsocionegocio IN (select a.idproveedor from compras.cpcompra a)";
                    ordersList = "razonsocial";
                    fieldsList = "*";
                    nameFileReport = "listadoproveedores.frx";      
             
                    break;
            }

                DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

                var report = new Report();

                var reporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Gerencia\\{0}", nameFileReport));
                report.Load(reporte);
                report.RegisterData(dt, "lis");
                report.RegisterData(vwSucursalList, "emp");
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

        private void RpListadoSocioNegocioFrm_Load(object sender, EventArgs e)
        {
            rgOpcionReporte.EditValue = 0;
            lbOptions.SelectedIndex = 0;
            CargarReferencias();
        }

        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
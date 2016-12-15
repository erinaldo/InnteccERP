using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class ArticuloStockPorUbicacionFrm : XtraForm
    {

        static readonly IService Service = new Service();
        public VwArticulo VwArticuloSel { get; set; }

        static readonly HelperDb HelperDb = new HelperDb();
        private DateTime FechaInicial { get; set; }

        public ArticuloStockPorUbicacionFrm(VwArticulo vwArticuloSel)
        {
            InitializeComponent();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            VwArticuloSel = vwArticuloSel;
            EstablecerFechasIniciales();
        }

        private void CargarDatosArticulos()
        {
            iCodigoarticulo.EditValue = VwArticuloSel.Codigoarticulo;
            iCodigoproveedor.EditValue = VwArticuloSel.Codigoproveedor;
            rNombreArticulo.EditValue = VwArticuloSel.Nombrearticulo;
            iIdunidadinventario.EditValue = VwArticuloSel.Nombreunidadmedida;
            iIdmarca.EditValue = VwArticuloSel.Nombremarca;
        }

        private void ArticuloStockPorUbicacionFrm_Load(object sender, EventArgs e)
        {
            CargarDatosArticulos();
            CargarStock();
        }

        private void CargarStock()
        {
            string sqlQuery = "almacen.fnsaldosfisicosubicacion";
            object[] parametrosConsulta = { 
                        VwArticuloSel.Idarticulo,
                        FechaInicial,
                        SessionApp.DateServer,
                        null, //Almacen
                        null //Ubicacion
                    };
            DataTable dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametrosConsulta);
            gcStockUbicacion.DataSource = dt;
            gvStockUbicacion.BestFitColumns(true);
        }

        private void EstablecerFechasIniciales()
        {
            string condicion = string.Format("idsucursal = '{0}' and anulado = '0' ", SessionApp.SucursalSel.Idsucursal);
            string orden = "idinventario desc limit 1";
            var inventarioList = Service.GetAllInventario(condicion, orden);
            if (inventarioList != null)
            {
                Inventario inventario = inventarioList.FirstOrDefault();
                if (inventario != null)
                {
                    FechaInicial = inventario.Fechainventario;
                }
            }
        }
    }

}
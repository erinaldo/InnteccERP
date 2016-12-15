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
    public partial class SalidaalmacenubicacionMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwSalidaalmacendet VwSalidaalmacendetRef { get; set; }
        public VwSalidaalmacenubicacion VwSalidaalmacenubicacionMnt { get; set; }
        public List<VwArticuloubicacion> VwArticuloubicacionList { get; set; }
        public static DateTime? FechaInicialConsultaStock { get; set; }
        public DateTime FechaSalida { get; set; }
        public int IdAlmacenSel { get; set; }

        static readonly HelperDb HelperDb = new HelperDb();
        public SalidaalmacenubicacionMntItemFrm(TipoMantenimiento tipoMnt, VwSalidaalmacendet vwSalidaalmacendetRef, VwSalidaalmacenubicacion vwSalidaalmacenubicacionMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipoMnt = tipoMnt;
            VwSalidaalmacendetRef = vwSalidaalmacendetRef;
            VwSalidaalmacenubicacionMnt = vwSalidaalmacenubicacionMnt;

            if (FechaInicialConsultaStock == null)
            {
                EstablecerFechasIniciales();
            }
            
        }
        private void SalidaalmacenubicacionMntItemFrm_Load(object sender, EventArgs e)
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;
            }

            InicioTipoMantenimiento();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();                    
                    TraerDatos();
                    iCantidad.Select();
                    CargarStock();
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    CargarStock();
                    break;
            }
            beArticulo.Select();
        }
        private void ValoresPorDefecto()
        {
            
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwSalidaalmacendetRef.Numeroitem;
            iIdarticulo.EditValue = VwSalidaalmacendetRef.Idarticulo;
            beArticulo.EditValue = VwSalidaalmacendetRef.Nombrearticulo;
            iCodigoproveedor.EditValue = VwSalidaalmacendetRef.Codigoproveedor;
            iCodigoarticulo.EditValue = VwSalidaalmacendetRef.Codigoarticulo;
            iCodigodebarra.EditValue = VwSalidaalmacendetRef.Codigodebarra;
            beArticulo.Text = VwSalidaalmacendetRef.Nombrearticulo.Trim();
            iMarcaarticulo.EditValue = VwSalidaalmacendetRef.Nombremarca;
            iUnidad.EditValue = VwSalidaalmacendetRef.Abrunidadmedida;
            iIdubicacion.EditValue = VwSalidaalmacenubicacionMnt.Idubicacion;
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    iCantidad.EditValue = 0m;
                    break;
                case TipoMantenimiento.Modificar:
                    iCantidad.EditValue = VwSalidaalmacenubicacionMnt.Cantidadarticulo;
                    break;
            }

        }
        private void CargarReferencias()
        {
            string condicion = string.Format("idarticulo = {0} and idalmacen = {1}", VwSalidaalmacendetRef.Idarticulo,IdAlmacenSel);
            VwArticuloubicacionList = Service.GetAllVwArticuloubicacion(condicion, "idubicacion");
            iIdubicacion.Properties.DataSource = VwArticuloubicacionList;
            iIdubicacion.Properties.DisplayMember = "Nombreubicacion";
            iIdubicacion.Properties.ValueMember = "Idubicacion";
            iIdubicacion.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;


                    VwSalidaalmacenubicacionMnt.Idsalidaalmacendet = VwSalidaalmacendetRef.Idsalidaalmacendet;
                    VwSalidaalmacenubicacionMnt.Idubicacion = (int)iIdubicacion.EditValue;
                    VwSalidaalmacenubicacionMnt.Nombreubicacion = iIdubicacion.Text.Trim();
                    VwSalidaalmacenubicacionMnt.Cantidadarticulo = (decimal) iCantidad.EditValue;                   
                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpProducto, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            if (((decimal)rStock.EditValue - (decimal)iCantidad.EditValue < 0))
            {
                XtraMessageBox.Show("No hay stock", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iCantidad.Select();
                return false;
            }

            return true;
        }
        private void SalidaalmacenubicacionMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void iIdubicacion_EditValueChanged(object sender, EventArgs e)
        {
            var idUbicacionSel = iIdubicacion.EditValue;
            if (idUbicacionSel != null)
            {
                VwArticuloubicacion vwArticuloubicacionSel = VwArticuloubicacionList.FirstOrDefault(x => x.Idubicacion == (int)idUbicacionSel);
                if (vwArticuloubicacionSel != null)
                {
                    iNombresucursal.EditValue = vwArticuloubicacionSel.Nombresucursal;
                    iNombrealmacen.EditValue = vwArticuloubicacionSel.Nombrealmacen;
                }
                else
                {
                    iNombresucursal.EditValue = string.Empty;
                    iNombrealmacen.EditValue = string.Empty;
                }
            }
            else
            {
                iNombresucursal.EditValue = string.Empty;
                iNombrealmacen.EditValue = string.Empty;
            }

        }
        private void iIdubicacion_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            VwSalidaalmacendet vwSalidaalmacendet = new VwSalidaalmacendet
            {
                Nombrearticulo = VwSalidaalmacendetRef.Nombrearticulo.Trim()
            };

            TipoMantenimiento tipoMantenimientoUbicacion = TipoMantenimiento.Nuevo;
            VwArticuloubicacion vwArticuloubicacionNuevo = new VwArticuloubicacion
            {
                Nombrearticulo = vwSalidaalmacendet.Nombrearticulo
            };

            ArticuloubicacionMntItemFrm articuloubicacionMntItemFrm = new ArticuloubicacionMntItemFrm(tipoMantenimientoUbicacion, vwArticuloubicacionNuevo);
            articuloubicacionMntItemFrm.ShowDialog();
            if (articuloubicacionMntItemFrm.DialogResult == DialogResult.OK)
            {
                Articuloubicacion articuloubicacionMnt = new Articuloubicacion
                {
                    Idarticulo = VwSalidaalmacendetRef.Idarticulo,
                    Idubicacion = vwArticuloubicacionNuevo.Idubicacion,
                };

                int idarticuloubicacionNuevo = Service.SaveArticuloubicacion(articuloubicacionMnt);
                if (idarticuloubicacionNuevo > 0)
                {
                    VwArticuloubicacion vwArticuloubicacion = Service.GetVwArticuloubicacion(idarticuloubicacionNuevo);
                    if (vwArticuloubicacion != null)
                    {
                        VwArticuloubicacionList.Add(vwArticuloubicacion);
                        e.Cancel = false;
                        e.NewValue = vwArticuloubicacion.Idubicacion;
                    }
                }
            }
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
                    FechaInicialConsultaStock = inventario.Fechainventario;
                }
            }
        }
        private void CargarStock()
        {
            string sqlQuery = "almacen.fnsaldosfisicosubicacion";
            object[] parametrosConsulta = { 
                        VwSalidaalmacendetRef.Idarticulo,
                        FechaInicialConsultaStock,
                        FechaSalida,
                        IdAlmacenSel, //Almacen
                        (int)iIdubicacion.EditValue //Ubicacion
                    };
            DataTable dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametrosConsulta);
            DataRow dr = dt.Rows[0];
            rStock.EditValue = Convert.ToDecimal(dr["stock"]);
        }
    }
}
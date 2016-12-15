using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class EntradaalmacenubicacionMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwEntradaalmacendet VwEntradaalmacendetRef { get; set; }
        public VwEntradaalmacenubicacion VwEntradaalmacenubicacionMnt { get; set; }
        public List<VwArticuloubicacion> VwArticuloubicacionList { get; set; }
        public int IdAlmacenSel { get; set; }
        public EntradaalmacenubicacionMntItemFrm(TipoMantenimiento tipoMnt, VwEntradaalmacendet vwEntradaalmacendetRef, VwEntradaalmacenubicacion vwEntradaalmacenubicacionMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);
            TipoMnt = tipoMnt;
            VwEntradaalmacendetRef = vwEntradaalmacendetRef;
            VwEntradaalmacenubicacionMnt = vwEntradaalmacenubicacionMnt;


        }
        private void EntradaalmacenubicacionMntItemFrm_Load(object sender, EventArgs e)
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
                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
            beArticulo.Select();
        }
        private void ValoresPorDefecto()
        {
            
        }
        private void TraerDatos()
        {
            iNumeroitem.EditValue = VwEntradaalmacendetRef.Numeroitem;
            iIdarticulo.EditValue = VwEntradaalmacendetRef.Idarticulo;
            beArticulo.EditValue = VwEntradaalmacendetRef.Nombrearticulo;
            iCodigoproveedor.EditValue = VwEntradaalmacendetRef.Codigoproveedor;
            iCodigoarticulo.EditValue = VwEntradaalmacendetRef.Codigoarticulo;
            iCodigodebarra.EditValue = VwEntradaalmacendetRef.Codigodebarra;
            beArticulo.Text = VwEntradaalmacendetRef.Nombrearticulo.Trim();
            iMarcaarticulo.EditValue = VwEntradaalmacendetRef.Nombremarca;
            iUnidad.EditValue = VwEntradaalmacendetRef.Abrunidadmedida;
            iIdubicacion.EditValue = VwEntradaalmacenubicacionMnt.Idubicacion;
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    iCantidad.EditValue = 0m;
                    break;
                case TipoMantenimiento.Modificar:
                    iCantidad.EditValue = VwEntradaalmacenubicacionMnt.Cantidadarticulo;
                    break;
            }

        }
        private void CargarReferencias()
        {
            string condicion = string.Format("idarticulo = {0} and idalmacen = {1}", VwEntradaalmacendetRef.Idarticulo,IdAlmacenSel);
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


                    VwEntradaalmacenubicacionMnt.Identradaalmacendet = VwEntradaalmacendetRef.Identradaalmacendet;
                    VwEntradaalmacenubicacionMnt.Idubicacion = (int)iIdubicacion.EditValue;
                    VwEntradaalmacenubicacionMnt.Nombreubicacion = iIdubicacion.Text.Trim();
                    VwEntradaalmacenubicacionMnt.Cantidadarticulo = (decimal) iCantidad.EditValue;

                    VwEntradaalmacendetRef.DataEntityState = DataEntityState.Modified;

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
            return true;
        }
        private void EntradaalmacenubicacionMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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
            VwEntradaalmacendet vwEntradaalmacendet = new VwEntradaalmacendet
            {
                Nombrearticulo = VwEntradaalmacendetRef.Nombrearticulo.Trim()
            };

            TipoMantenimiento tipoMantenimientoUbicacion = TipoMantenimiento.Nuevo;
            VwArticuloubicacion vwArticuloubicacionNuevo = new VwArticuloubicacion
            {
                Nombrearticulo = vwEntradaalmacendet.Nombrearticulo
            };

            ArticuloubicacionMntItemFrm articuloubicacionMntItemFrm = new ArticuloubicacionMntItemFrm(tipoMantenimientoUbicacion, vwArticuloubicacionNuevo,IdAlmacenSel);
            articuloubicacionMntItemFrm.ShowDialog();
            if (articuloubicacionMntItemFrm.DialogResult == DialogResult.OK)
            {
                Articuloubicacion articuloubicacionMnt = new Articuloubicacion
                {
                    Idarticulo = VwEntradaalmacendetRef.Idarticulo,
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
    }
}
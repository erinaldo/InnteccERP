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
    public partial class ArticuloubicacionMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwArticuloubicacion VwArticuloubicacionMnt { get; set; }
        public List<VwUbicacion> VwUbicacionList { get; set; }
        public int? IdAlmacenRegistro { get; set; }
        public ArticuloubicacionMntItemFrm(TipoMantenimiento tipoMnt,  VwArticuloubicacion vwArticuloubicacion)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwArticuloubicacionMnt = vwArticuloubicacion;
         
        }

        public ArticuloubicacionMntItemFrm(TipoMantenimiento tipoMnt, VwArticuloubicacion vwArticuloubicacion, int? idAlmacenRegistro)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwArticuloubicacionMnt = vwArticuloubicacion;
            IdAlmacenRegistro = idAlmacenRegistro;
        }

        private void ArticuloubicacionMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarReferencias();
                    ValoresPorDefecto();                    

                    break;
                case TipoMantenimiento.Modificar:
                    CargarReferencias();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }
        private void ValoresPorDefecto()
        {
            rNombreArticulo.EditValue = VwArticuloubicacionMnt.Nombrearticulo;
        }
        private void TraerDatos()
        {
            rNombreArticulo.EditValue = VwArticuloubicacionMnt.Nombrearticulo;
            iIdubicacion.EditValue = VwArticuloubicacionMnt.Idubicacion;
          
        }
        private void CargarReferencias()
        {
            //Registro desde Articulo
            if (IdAlmacenRegistro == null)
            {
                string where = string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal);
                VwUbicacionList = Service.GetAllVwUbicacion(where, "idubicacion");
                iIdubicacion.Properties.DataSource = VwUbicacionList;
                iIdubicacion.Properties.DisplayMember = "Nombreubicacion";
                iIdubicacion.Properties.ValueMember = "Idubicacion";
                iIdubicacion.Properties.BestFitMode = BestFitMode.BestFit;
            }
            else
            {
                //Registro desde entrada
                string where = string.Format("idalmacen = {0}", IdAlmacenRegistro);
                VwUbicacionList = Service.GetAllVwUbicacion(where, "idubicacion");
                iIdubicacion.Properties.DataSource = VwUbicacionList;
                iIdubicacion.Properties.DisplayMember = "Nombreubicacion";
                iIdubicacion.Properties.ValueMember = "Idubicacion";
                iIdubicacion.Properties.BestFitMode = BestFitMode.BestFit;
            }

        }
        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":
                    if (!Validaciones()) return;
                    VwArticuloubicacionMnt.Idubicacion = (int)iIdubicacion.EditValue;                   
                    DialogResult = DialogResult.OK;                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ArticuloubicacionMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void iIdubicacion_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            UbicacionMntFrm ubicacionMntFrm = new UbicacionMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            ubicacionMntFrm.ShowDialog();
            if (ubicacionMntFrm.IdEntidadMnt > 0)
            {
                VwUbicacion vwUbicacion = Service.GetVwUbicacion(ubicacionMntFrm.IdEntidadMnt);
                if (vwUbicacion != null)
                {
                    VwUbicacionList.Add(vwUbicacion);
                    e.Cancel = false;
                    e.NewValue = vwUbicacion.Idubicacion;
                }
            }
        }
        private void iIdubicacion_EditValueChanged(object sender, EventArgs e)
        {
            var idUbicacionSel = iIdubicacion.EditValue;
            if (idUbicacionSel != null)
            {
                VwUbicacion vwUbicacionSel = VwUbicacionList.FirstOrDefault(x => x.Idubicacion == (int)idUbicacionSel);
                if (vwUbicacionSel != null)
                {
                    iNombresucursal.EditValue = vwUbicacionSel.Nombresucursal;
                    iNombrealmacen.EditValue = vwUbicacionSel.Nombrealmacen;
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
    }
}
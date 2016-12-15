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
    public partial class ArticuloserieMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwArticuloseriedet VwArticuloseriedet { get; set; }
        public List<VwArticulodetalleunidad> VwArticulodetalleunidadList { get; set; }
        public List<Seriearticulo> SeriearticuloList { get; set; }

        public ArticuloserieMntItemFrm(TipoMantenimiento tipoMnt,  VwArticuloseriedet vwArticuloseriedet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwArticuloseriedet = vwArticuloseriedet;

         
        }

        private void ArticuloserieMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
        }

        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    CargarDatosForaneos();
                    ValoresPorDefecto();                    

                    break;
                case TipoMantenimiento.Modificar:
                    CargarDatosForaneos();
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }

        private void ValoresPorDefecto()
        {
            rNombreArticulo.EditValue = VwArticuloseriedet.Nombrearticulo;
            iMarca.EditValue = VwArticuloseriedet.Nombremarca;
            iUnidad.EditValue = VwArticuloseriedet.Nombreunidadmedida;
        }

        private void TraerDatos()
        {
            iIdseriearticulo.EditValue = VwArticuloseriedet.Idseriearticulo;

          
        }

        private void CargarDatosForaneos()
        {
            SeriearticuloList = Service.GetAllSeriearticulo("numeroserieitem");
            iIdseriearticulo.Properties.DataSource = SeriearticuloList;
            iIdseriearticulo.Properties.DisplayMember = "Numeroserieitem";
            iIdseriearticulo.Properties.ValueMember = "Idseriearticulo";
            iIdseriearticulo.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwArticuloseriedet.Idseriearticulo = (int)iIdseriearticulo.EditValue;

                   

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

        private void ArticuloserieMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void iIdseriearticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idSeriearticulo = iIdseriearticulo.EditValue;
            if (idSeriearticulo != null)
            {
                Seriearticulo seriearticulo = SeriearticuloList.FirstOrDefault(x => x.Idseriearticulo == (int)idSeriearticulo);
                if (seriearticulo != null)
                {
                    iCodigointernoitem.EditValue = seriearticulo.Codigointernoitem;
                }
            }
        }
    }
}
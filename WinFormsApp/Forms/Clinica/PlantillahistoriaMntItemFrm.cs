using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class PlantillahistoriaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwPlantillahistoriadet VwPlantillahistoriadetMnt { get; set; }
        public List<VwItemhistoria> VwItemhistoriaLists { get; set; }
        public List<Plantillahistoriadet> VwPlantillahistoriadetListMnt { get; set; }

        public PlantillahistoriaMntItemFrm(TipoMantenimiento tipoMnt, VwPlantillahistoriadet vwPlantillahistoriadet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwPlantillahistoriadetMnt = vwPlantillahistoriadet;


        }

        private void PlantillahistoriaMntItemFrm_Load(object sender, EventArgs e)
        {
            InicioTipoMantenimiento();
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    Text = @"Agregar " + Text;
                    break;
                case TipoMantenimiento.Modificar:
                    Text = @"Modificar " + Text;
                    break;

            }
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
                    TraerDatos();
                    break;
            }
        }

        private void ValoresPorDefecto()
        {
            iOrdenitemplantilla.EditValue = VwPlantillahistoriadetMnt.Ordenitemplantilla;
            iOrdenitemplantilla.Select();
        }

        private void TraerDatos()
        {
            iIditemhistoria.EditValue = VwPlantillahistoriadetMnt.Iditemhistoria;
            iNombrecategoriaitem.EditValue = VwPlantillahistoriadetMnt.Nombrecategoriaitem;
            iOrdenitemplantilla.EditValue = VwPlantillahistoriadetMnt.Ordenitemplantilla;
        }

        private void CargarReferencias()
        {
            VwItemhistoriaLists = Service.GetAllVwItemhistoria("Nombreitemhistoria");
            iIditemhistoria.Properties.DataSource = VwItemhistoriaLists;
            iIditemhistoria.Properties.DisplayMember = "Nombreitemhistoria";
            iIditemhistoria.Properties.ValueMember = "Iditemhistoria";
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwPlantillahistoriadetMnt.Iditemhistoria = (int) iIditemhistoria.EditValue;
                    VwPlantillahistoriadetMnt.Nombreitemhistoria = iIditemhistoria.Text.Trim();
                    VwPlantillahistoriadetMnt.Nombrecategoriaitem = iNombrecategoriaitem.Text.Trim();
                    VwPlantillahistoriadetMnt.Ordenitemplantilla = (int)iOrdenitemplantilla.EditValue;

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

        private void PlantillahistoriaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void iIditemhistoria_EditValueChanged(object sender, EventArgs e)
        {
            var idItemHistoria = iIditemhistoria.EditValue;
            if (idItemHistoria != null)
            {
                VwItemhistoria vwItemhistoria = VwItemhistoriaLists.FirstOrDefault(x => x.Iditemhistoria == (int) idItemHistoria);
                if (vwItemhistoria != null)
                {
                    iNombrecategoriaitem.EditValue = vwItemhistoria.Nombrecategoriaitem;
                }
            }
        }
    }
}
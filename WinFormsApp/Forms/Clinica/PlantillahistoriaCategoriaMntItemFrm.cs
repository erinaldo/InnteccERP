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
    public partial class PlantillahistoriaCategoriaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public List<VwPlantillahistoriadet> VwPlantillahistoriadetList { get; set; }
        PlantillahistoriaMntFrm PlantillahistoriaMntFrm { get; set; }
        public PlantillahistoriaCategoriaMntItemFrm(TipoMantenimiento tipoMnt, List<VwPlantillahistoriadet> vwPlantillahistoriadetList, PlantillahistoriaMntFrm plantillahistoriaMntFrm)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwPlantillahistoriadetList = vwPlantillahistoriadetList;
            PlantillahistoriaMntFrm = plantillahistoriaMntFrm;

        }

        private void PlantillahistoriaCategoriaMntItemFrm_Load(object sender, EventArgs e)
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
    
        }

        private void TraerDatos()
        {

        }

        private void CargarReferencias()
        {

            iIdcategoriaitem.Properties.DataSource = Service.GetAllCategoriaitem("Nombrecategoriaitem");
            iIdcategoriaitem.Properties.DisplayMember = "Nombrecategoriaitem";
            iIdcategoriaitem.Properties.ValueMember = "Idcategoriaitem";
            iIdcategoriaitem.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    List<VwItemhistoria> vwItemhistoriaList =Service.GetAllVwItemhistoria(x => x.Idcategoriaitem == (int) iIdcategoriaitem.EditValue);
                    if (vwItemhistoriaList != null)
                    {
                        VwPlantillahistoriadet sgtItem = VwPlantillahistoriadetList.Where(w => w.DataEntityState != DataEntityState.Deleted).OrderByDescending(t => t.Ordenitemplantilla).FirstOrDefault();
                        int orden = sgtItem == null ? 1 : sgtItem.Ordenitemplantilla + 1;
                        foreach (VwItemhistoria itemhistoriaList in vwItemhistoriaList)
                        {
                            VwPlantillahistoriadet vwPlantillahistoriadet = new VwPlantillahistoriadet();
                            vwPlantillahistoriadet.Idplantillahistoria = PlantillahistoriaMntFrm.IdEntidadMnt;
                            vwPlantillahistoriadet.Iditemhistoria = itemhistoriaList.Iditemhistoria;
                            vwPlantillahistoriadet.Nombreitemhistoria = itemhistoriaList.Nombreitemhistoria;
                            vwPlantillahistoriadet.Nombrecategoriaitem = itemhistoriaList.Nombrecategoriaitem;
                            vwPlantillahistoriadet.Ordenitemplantilla = orden;
                            orden++;
                            Plantillahistoriadet plantillahistoriadet = PlantillahistoriaMntFrm.AsignarPlantillahistoriadet(vwPlantillahistoriadet);
                            int idPlantillahistoriadet = Service.SavePlantillahistoriadet(plantillahistoriadet);
                            if (idPlantillahistoriadet > 0)
                            {
                                vwPlantillahistoriadet.Idplantillahistoriadet = idPlantillahistoriadet;
                                VwPlantillahistoriadetList.Add(vwPlantillahistoriadet);
                            }

                        }
                        PlantillahistoriaMntFrm.ActualizarDetalle();
                    }

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
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            List<VwItemhistoria> vwItemhistoriaList = Service.GetAllVwItemhistoria(x => x.Idcategoriaitem == (int)iIdcategoriaitem.EditValue);
            if (vwItemhistoriaList.Count == 0)
            {
                XtraMessageBox.Show("No hay items para la categoría seleccionada", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void PlantillahistoriaCategoriaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
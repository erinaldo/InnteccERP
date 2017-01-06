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
    public partial class HistoriaItemPlantillaFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public List<VwHistoriadetitem> VwHistoriadetitemList { get; set; }
        public HistoriaMntFrm HistoriaMntFrm { get; set; }
        public VwHistoriadet VwHistoriadet { get; set; }
        public HistoriaItemPlantillaFrm(TipoMantenimiento tipoMnt, List<VwHistoriadetitem> vwHistoriadetitemList, VwHistoriadet vwHistoriadet, HistoriaMntFrm historiaMntFrm)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwHistoriadetitemList = vwHistoriadetitemList;
            VwHistoriadet = vwHistoriadet;
            HistoriaMntFrm = historiaMntFrm;

        }

        private void HistoriaItemPlantillaFrm_Load(object sender, EventArgs e)
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

            iIidplantillahistoria.Properties.DataSource = Service.GetAllVwPlantillahistoria("Nombretipohistoria");
            iIidplantillahistoria.Properties.DisplayMember = "Nombretipohistoria";
            iIidplantillahistoria.Properties.ValueMember = "Idplantillahistoria";
            iIidplantillahistoria.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    List<VwPlantillahistoriadet> vwPlantillahistoriadetList =Service.GetAllVwPlantillahistoriadet(x => x.Idplantillahistoria == (int) iIidplantillahistoria.EditValue);
                    if (vwPlantillahistoriadetList != null)
                    {
                        VwHistoriadetitem sgtItem = VwHistoriadetitemList.Where(w => w.DataEntityState != DataEntityState.Deleted).OrderByDescending(t => t.Ordenhistoriadetitem).FirstOrDefault();
                        int orden = sgtItem == null ? 1 : sgtItem.Ordenhistoriadetitem + 1;

                        foreach (VwPlantillahistoriadet vwPlantillahistoriadet in vwPlantillahistoriadetList)
                        {
                            VwHistoriadetitem vwHistoriadetitem = new VwHistoriadetitem();
                            vwHistoriadetitem.Idhistoriadet = VwHistoriadet.Idhistoriadet;
                            vwHistoriadetitem.Nombreitemhistoria = vwPlantillahistoriadet.Nombreitemhistoria;
                            vwHistoriadetitem.Iditemhistoria = vwPlantillahistoriadet.Iditemhistoria;
                            vwHistoriadetitem.Nombrecategoriaitem = vwPlantillahistoriadet.Nombrecategoriaitem;
                            vwHistoriadetitem.Valoritemhistoria = string.Empty;
                            vwHistoriadetitem.Ordenhistoriadetitem = orden;

                            orden++;

                            Historiadetitem historiadetitem = HistoriaMntFrm.AsignarHistoriadetitem(vwHistoriadetitem);
                            int idhistoriadetitem = Service.SaveHistoriadetitem(historiadetitem);
                            if (idhistoriadetitem > 0)
                            {
                                vwHistoriadetitem.Idhistoriadetitem = idhistoriadetitem;
                                VwHistoriadetitemList.Add(vwHistoriadetitem);
                            }

                        }
                        //Todo: Descomentar para dejarlos como plantilla
                        //HistoriaMntFrm.ActualizarDetalleItemsHistoria();
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

            List<VwPlantillahistoriadet> vwPlantillahistoriadetList = Service.GetAllVwPlantillahistoriadet(x => x.Idplantillahistoria == (int)iIidplantillahistoria.EditValue);
            if (vwPlantillahistoriadetList.Count == 0)
            {
                XtraMessageBox.Show("No hay items para la plantilla seleccionada", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void HistoriaItemPlantillaFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
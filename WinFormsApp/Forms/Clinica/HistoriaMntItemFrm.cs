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
    public partial class HistoriaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwHistoriadetitem VwHistoriadetitem { get; set; }
        public List<VwItemhistoria> VwItemhistoriaLists { get; set; }

        public HistoriaMntItemFrm(TipoMantenimiento tipoMnt, VwHistoriadetitem vwHistoriadetitem)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwHistoriadetitem = vwHistoriadetitem;


        }

        private void HistoriaMntItemFrm_Load(object sender, EventArgs e)
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
            iOrdenhistoriadetitem.EditValue = VwHistoriadetitem.Ordenhistoriadetitem;
            iOrdenhistoriadetitem.Select();
        }

        private void TraerDatos()
        {
            iIditemhistoria.EditValue = VwHistoriadetitem.Iditemhistoria;
            iNombrecategoriaitem.EditValue = VwHistoriadetitem.Nombrecategoriaitem;
            iValoritemhistoria.EditValue = VwHistoriadetitem.Valoritemhistoria;

            //iOrdenitemplantilla.EditValue = VwHistoriadetitem.Ordenitemplantilla;
        }

        private void CargarReferencias()
        {
            VwItemhistoriaLists = Service.GetAllVwItemhistoria("Nombrecategoriaitem,Nombreitemhistoria");
            iIditemhistoria.Properties.DataSource = VwItemhistoriaLists;
            iIditemhistoria.Properties.DisplayMember = "Nombreitemhistoria";
            iIditemhistoria.Properties.ValueMember = "Iditemhistoria";
            iIditemhistoria.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwHistoriadetitem.Iditemhistoria = (int) iIditemhistoria.EditValue;
                    VwHistoriadetitem.Nombreitemhistoria = iIditemhistoria.Text.Trim();
                    VwHistoriadetitem.Nombrecategoriaitem = iNombrecategoriaitem.Text.Trim();
                    VwHistoriadetitem.Valoritemhistoria = iValoritemhistoria.Text.Trim();
                    VwHistoriadetitem.Ordenhistoriadetitem = (int)iOrdenhistoriadetitem.EditValue;

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

        private void HistoriaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
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
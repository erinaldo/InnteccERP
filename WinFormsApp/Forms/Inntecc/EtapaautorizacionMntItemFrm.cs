using System;
using System.Collections.Generic;
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
    public partial class EtapaautorizacionMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwEtapaautorizaciondetalle VwEtapaautorizaciondetalleMnt { get; set; }
        public List<VwEtapaautorizaciondetalle> VwEtapaautorizaciondetalleList { get; set; }

        public EtapaautorizacionMntItemFrm(TipoMantenimiento tipoMnt,  VwEtapaautorizaciondetalle vwEtapaautorizaciondetalle)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwEtapaautorizaciondetalleMnt = vwEtapaautorizaciondetalle;

         
        }

        private void EtapaautorizacionMntItemFrm_Load(object sender, EventArgs e)
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
            
        }

        private void TraerDatos()
        {
            
            iIdempleado.EditValue = VwEtapaautorizaciondetalleMnt.Idempleado;
            iOrdenautorizacion.EditValue = VwEtapaautorizaciondetalleMnt.Ordenautorizacion;
            iRequiereautorizacion.EditValue = VwEtapaautorizaciondetalleMnt.Requiereautorizacion;
        }

        private void CargarDatosForaneos()
        {
            
            iIdempleado.Properties.DataSource = Service.GetAllVwEmpleado("razonsocial");
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwEtapaautorizaciondetalleMnt.Idempleado = (int)iIdempleado.EditValue;
                    VwEtapaautorizaciondetalleMnt.Ordenautorizacion = (int)iOrdenautorizacion.EditValue;
                    VwEtapaautorizaciondetalleMnt.Requiereautorizacion = (bool) iRequiereautorizacion.EditValue;
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

        private void EtapaautorizacionMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
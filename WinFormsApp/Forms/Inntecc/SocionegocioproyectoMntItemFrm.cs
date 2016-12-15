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
    public partial class SocionegocioproyectoMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwSocionegocioproyecto VwSocionegocioproyectoMnt { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<VwSocionegocioproyecto> VwSocionegocioproyectoListMnt { get; set; }

        public SocionegocioproyectoMntItemFrm(TipoMantenimiento tipoMnt, VwSocionegocioproyecto vwSocionegocioproyecto, List<VwSocionegocioproyecto> vwSocionegocioproyectoListMnt)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwSocionegocioproyectoMnt = vwSocionegocioproyecto;
            VwSocionegocioproyectoListMnt = vwSocionegocioproyectoListMnt;

        }

        private void SocionegocioLimiteCreditoMntItemFrm_Load(object sender, EventArgs e)
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
                    ValoresPorDefecto();
                    TraerDatos();
                    break;
            }
        }

        private void ValoresPorDefecto()
        {
            int cntItems = VwSocionegocioproyectoListMnt.Count(x => x.DataEntityState != DataEntityState.Deleted);
            if (cntItems == 0)
            {
                iProyectopordefecto.Checked = true;
                iProyectopordefecto.ReadOnly = true;
            }
        }

        private void TraerDatos()
        {
            iIdproyecto.EditValue = VwSocionegocioproyectoMnt.Idproyecto;
            iProyectopordefecto.EditValue = VwSocionegocioproyectoMnt.Proyectopordefecto;

        }

        private void CargarReferencias()
        {
            //VwProyectoList = Service.GetAllVwProyecto("nombresucursal,nombreproyecto");
            string condicionEmpresa = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwProyectoList = Service.GetAllVwProyecto(condicionEmpresa, "codigoproyecto");
            iIdproyecto.Properties.DataSource = VwProyectoList;
            iIdproyecto.Properties.DisplayMember = "Nombreproyecto";
            iIdproyecto.Properties.ValueMember = "Idproyecto";
            iIdproyecto.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwSocionegocioproyectoMnt.Idproyecto = (int)iIdproyecto.EditValue;
                    VwSocionegocioproyectoMnt.Codigoproyecto = rCodigoproyecto.Text.Trim();
                    VwSocionegocioproyectoMnt.Nombreproyecto = iIdproyecto.Text.Trim();
                    VwSocionegocioproyectoMnt.Nombreempresa = rNombreempresa.Text.Trim();
                    VwSocionegocioproyectoMnt.Proyectopordefecto = (bool)iProyectopordefecto.EditValue;

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

        private void SocionegocioLimiteCreditoMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void iIdproyecto_EditValueChanged(object sender, EventArgs e)
        {
            var idProyectoSel = iIdproyecto.EditValue;
            if (idProyectoSel != null)
            {
                VwProyecto vwProyectoSel = VwProyectoList.FirstOrDefault(x => x.Idproyecto == (int)idProyectoSel);
                if (vwProyectoSel != null)
                {
                    rCodigoproyecto.EditValue = vwProyectoSel.Codigoproyecto;
                    rNombreempresa.EditValue = vwProyectoSel.Nombreempresa;
                }
            }
            else
            {
                rCodigoproyecto.EditValue = string.Empty;
                rNombreempresa.EditValue = string.Empty;
            }
        }

        private void iIdproyecto_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            var proyectoMntFrm = new ProyectoMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            proyectoMntFrm.ShowDialog();
            if (proyectoMntFrm.IdEntidadMnt > 0)
            {                
                VwProyecto vwProyecto = Service.GetVwProyecto(proyectoMntFrm.IdEntidadMnt);
                if (vwProyecto != null && vwProyecto.Idproyecto > 0)
                {
                    VwProyectoList.Add(vwProyecto);
                    e.Cancel = false;
                    e.NewValue = vwProyecto.Idproyecto;
                }
            }
        }
    }
}
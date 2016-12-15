using System;
using System.Collections.Generic;
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
    public partial class HistoriaclinicacitaMntItemFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwProgramacioncitadet VwProgramacioncitadetMnt { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<Programacioncitadet> VwProgramacioncitadetListMnt { get; set; }

        public HistoriaclinicacitaMntItemFrm(TipoMantenimiento tipoMnt, VwProgramacioncitadet vwProgramacioncitadet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwProgramacioncitadetMnt = vwProgramacioncitadet;


        }

        private void HistoriaclinicacitaMntItemFrm_Load(object sender, EventArgs e)
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
            Estadocita estadocitaPorDefectoProgramacion = Service.GetEstadocita(x => x.Estadopordefectoprogramacion);
            if (estadocitaPorDefectoProgramacion != null)
            {
                rIdestadocita.EditValue = estadocitaPorDefectoProgramacion.Idestadocita;
            }

            Motivocita motivocitaPorDefectoProgramacion = Service.GetMotivocita(x => x.Motivopordefectoprogramacion);
            if (motivocitaPorDefectoProgramacion != null)
            {
                rIdmotivocita.EditValue = motivocitaPorDefectoProgramacion.Idmotivocita;
            }

            iHoraprogramacion.Select();
        }

        private void TraerDatos()
        {
            iHoraprogramacion.EditValue = VwProgramacioncitadetMnt.Horaprogramacion;
            rIdestadocita.EditValue = VwProgramacioncitadetMnt.Idestadocita;
            rIdmotivocita.EditValue = VwProgramacioncitadetMnt.Idestadocita;
        }

        private void CargarReferencias()
        {
            rIdestadocita.Properties.DataSource = Service.GetAllEstadocita("nombreestadocita");
            rIdestadocita.Properties.DisplayMember = "Nombreestadocita";
            rIdestadocita.Properties.ValueMember = "Idestadocita";

            rIdmotivocita.Properties.DataSource = Service.GetAllMotivocita("nombremotivocita");
            rIdmotivocita.Properties.DisplayMember = "Nombremotivocita";
            rIdmotivocita.Properties.ValueMember = "Idmotivocita";
        }

        private void bmMntItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            switch (e.Item.Name)
            {
                case "btnGrabarItem":

                    if (!Validaciones()) return;

                    VwProgramacioncitadetMnt.Horaprogramacion = (DateTime)iHoraprogramacion.EditValue;
                    VwProgramacioncitadetMnt.Idestadocita = (int?)rIdestadocita.EditValue;
                    VwProgramacioncitadetMnt.Nombreestadocita = rIdestadocita.Text.Trim();
                    VwProgramacioncitadetMnt.Idmotivocita = (int?) rIdmotivocita.EditValue;
                    VwProgramacioncitadetMnt.Nombremotivocita = rIdmotivocita.Text.Trim();
                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private bool Validaciones()
        {
            iHoraprogramacion.Refresh();
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void HistoriaclinicacitaMntItemFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
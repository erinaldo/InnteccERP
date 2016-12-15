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
    public partial class ProgramacioncitaMntItemFrmBak : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwProgramacioncitadet VwProgramacioncitadetMnt { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<Programacioncitadet> VwProgramacioncitadetListMnt { get; set; }

        public ProgramacioncitaMntItemFrmBak(TipoMantenimiento tipoMnt, VwProgramacioncitadet vwProgramacioncitadet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwProgramacioncitadetMnt = vwProgramacioncitadet;


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

        }

        private void TraerDatos()
        {
            iHoraprogramacion.EditValue = VwProgramacioncitadetMnt.Horaprogramacion;
            iIdpersona.EditValue = VwProgramacioncitadetMnt.Idpaciente;
            iIdestadocita.EditValue = VwProgramacioncitadetMnt.Idestadocita;
        }

        private void CargarReferencias()
        {
            iIdestadocita.Properties.DataSource = Service.GetAllEstadocita("nombreestadocita");
            iIdestadocita.Properties.DisplayMember = "Nombreestadocita";
            iIdestadocita.Properties.ValueMember = "Idestadocita";
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
                    VwProgramacioncitadetMnt.Idpaciente = (int?)iIdpersona.EditValue;
                    VwProgramacioncitadetMnt.Razonsocialpaciente = beSocioNegocio.Text.Trim();
                    VwProgramacioncitadetMnt.Idestadocita = (int?)iIdestadocita.EditValue;
                    VwProgramacioncitadetMnt.Nombreestadocita = iIdestadocita.Text.Trim();

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

        private void beSocioNegocio_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BaseMntFrm personaMntFrm;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorPersonaFrm buscadorPersonaFrm = new BuscadorPersonaFrm();
                    buscadorPersonaFrm.ShowDialog();

                    if (buscadorPersonaFrm.DialogResult == DialogResult.OK &&
                        buscadorPersonaFrm.PersonaSel != null)
                    {
                        iIdpersona.EditValue = buscadorPersonaFrm.PersonaSel.Idpersona;
                    }
                    break;
                case 1: //Nuevo registro
                    personaMntFrm = new BaseMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    personaMntFrm.ShowDialog();

                    if (personaMntFrm.DialogResult == DialogResult.OK && personaMntFrm.IdEntidadMnt > 0)
                    {
                        iIdpersona.EditValue = personaMntFrm.IdEntidadMnt;
                    }
                    break;
                case 2: //Modificar registro
                    var idPersonaMnt = iIdpersona.EditValue;
                    if (idPersonaMnt != null && (int)idPersonaMnt > 0)
                    {
                        personaMntFrm = new BaseMntFrm((int)idPersonaMnt, TipoMantenimiento.Modificar, null, null);
                        personaMntFrm.ShowDialog();
                        if (personaMntFrm.DialogResult == DialogResult.OK && personaMntFrm.IdEntidadMnt > 0)
                        {
                            iIdpersona.EditValue = 0;
                            iIdpersona.EditValue = personaMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
                case 3: //Limpiar
                    iIdpersona.EditValue = null;
                    beSocioNegocio.Text = string.Empty;
                    break;
            }
        }

        private void iIdpersona_EditValueChanged(object sender, EventArgs e)
        {
            var idPersona = iIdpersona.EditValue;
            if (idPersona != null)
            {
                VwPersona vWpersonaSel = Service.GetVwPersona(((int)idPersona));
                if (vWpersonaSel != null)
                {
                    //Cargar datos a controles
                    beSocioNegocio.Text = vWpersonaSel.Razonsocial.Trim();
                }
            }
        }
    }
}
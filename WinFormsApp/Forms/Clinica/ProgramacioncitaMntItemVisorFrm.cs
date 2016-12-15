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
    public partial class ProgramacioncitaMntItemVisorFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }

        private readonly DXErrorProvider _errorProvider;

        static readonly IService Service = new Service();
        public VwProgramacioncitadet VwProgramacioncitadetMnt { get; set; }
        public List<VwProyecto> VwProyectoList { get; set; }
        public List<Programacioncitadet> VwProgramacioncitadetListMnt { get; set; }
        public int IdestadocitaOriginal { get; set; }
        public List<Articulo> ArticuloMotivocitaList { get; set; }

        public ProgramacioncitaMntItemVisorFrm(TipoMantenimiento tipoMnt, VwProgramacioncitadet vwProgramacioncitadet)
        {

            InitializeComponent();

            _errorProvider = new DXErrorProvider();
            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            TipoMnt = tipoMnt;
            VwProgramacioncitadetMnt = vwProgramacioncitadet;


        }

        private void ProgramacioncitaMntItemVisorFrm_Load(object sender, EventArgs e)
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
            IdestadocitaOriginal = Convert.ToInt32(VwProgramacioncitadetMnt.Idestadocita);
            iIdmotivocita.EditValue = VwProgramacioncitadetMnt.Idmotivocita;
            iHoraFin.EditValue = VwProgramacioncitadetMnt.Horatermino;

            CalcularDuracion();
        }

        private void CalcularDuracion()
        {
            DateTime inicio = (DateTime) iHoraprogramacion.EditValue;
            if (iHoraFin.EditValue != null)
            {
                DateTime fin = (DateTime) iHoraFin.EditValue;
                iTiempoduracion.EditValue = fin.Subtract(inicio);
            }
        }

        private void CargarReferencias()
        {
            iIdestadocita.Properties.DataSource = Service.GetAllEstadocita("nombreestadocita");
            iIdestadocita.Properties.DisplayMember = "Nombreestadocita";
            iIdestadocita.Properties.ValueMember = "Idestadocita";

            ArticuloMotivocitaList = Service.GetAllArticulo("esserviciomedico", "Nombrearticulo");
            iIdmotivocita.Properties.DataSource = ArticuloMotivocitaList;
            iIdmotivocita.Properties.DisplayMember = "Nombrearticulo";
            iIdmotivocita.Properties.ValueMember = "Idarticulo";
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
                    VwProgramacioncitadetMnt.Razonsocialpaciente = bePaciente.Text.Trim();
                    VwProgramacioncitadetMnt.Idestadocita = (int?)iIdestadocita.EditValue;
                    VwProgramacioncitadetMnt.Nombreestadocita = iIdestadocita.Text.Trim();
                    VwProgramacioncitadetMnt.Idmotivocita = (int?)iIdmotivocita.EditValue;
                    VwProgramacioncitadetMnt.Nombremotivocita = iIdmotivocita.Text.Trim();
                    VwProgramacioncitadetMnt.Horatermino = (DateTime)iHoraFin.EditValue;

                    GuardarHistorial(VwProgramacioncitadetMnt);

                    DialogResult = DialogResult.OK;
                   
                    break;
                case "btnCancelarItem":
                    DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private void GuardarHistorial(VwProgramacioncitadet vwProgramacioncitadetMnt)
        {
            Programacioncitadethistorial programacioncitadethistorial = new Programacioncitadethistorial();
            programacioncitadethistorial.Idprogramacioncitadethistorial = 0;
            programacioncitadethistorial.Idprogramacioncitadet = vwProgramacioncitadetMnt.Idprogramacioncitadet;
            programacioncitadethistorial.Fechahorahistorial = DateTime.Now;
            programacioncitadethistorial.Idpersona = vwProgramacioncitadetMnt.Idpaciente;
            programacioncitadethistorial.Idestadocita = vwProgramacioncitadetMnt.Idestadocita;
            programacioncitadethistorial.Idmotivocita = vwProgramacioncitadetMnt.Idmotivocita;

            Service.SaveProgramacioncitadethistorial(programacioncitadethistorial);
        }

        private bool Validaciones()
        {
            iHoraprogramacion.Refresh();

            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            //if (IdestadocitaOriginal == (int) iIdestadocita.EditValue)
            //{
            //    XtraMessageBox.Show("No se cambiado el estado de cita, verifique", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    iIdestadocita.Select();
            //    return false;
            //}
            if (iHoraFin.EditValue == null)
            {
                XtraMessageBox.Show("Erro en la hora fin, verifique.", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ProgramacioncitaMntItemVisorFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void bePaciente_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                    bePaciente.Text = string.Empty;
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
                    bePaciente.Text = vWpersonaSel.Razonsocial.Trim();
                }
            }
        }

        private void EstablecerHoraTermino()
        {
            TimeSpan duracion = TimeSpan.Parse(iTiempoduracion.Text);
            DateTime horaInicio = (DateTime)iHoraprogramacion.EditValue;
            DateTime horaFin = horaInicio.Add(duracion);
            iHoraFin.EditValue = horaFin;  
        }

        private void iIdmotivocita_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SearchLookUpEdit edit = sender as SearchLookUpEdit;
            if (edit != null && edit.IsModified)
            {
                //your code here
                var idMotivoCita = iIdmotivocita.EditValue;
                if (idMotivoCita != null)
                {
                    Articulo articuloMotivocita = ArticuloMotivocitaList.FirstOrDefault(x => x.Idarticulo == (int)idMotivoCita);
                    if (articuloMotivocita != null)
                    {
                        iTiempoduracion.EditValue = articuloMotivocita.Tiempoduracion;
                        EstablecerHoraTermino();
                    }

                }
            }

        }

        private void iHoraFin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TimeEdit edit = sender as TimeEdit;
            if (edit != null && edit.IsModified)
            {
                CalcularDuracion();
            }
        }

        private void iHoraprogramacion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TimeEdit edit = sender as TimeEdit;
            if (edit != null && edit.IsModified)
            {
                CalcularDuracion();
            }
        }
    }
}
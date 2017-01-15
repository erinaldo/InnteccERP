using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;

namespace WinFormsApp
{
    public partial class ProgramacioncitaVisorFrm : XtraForm
    {
        private static ProgramacioncitaVisorFrm _uniqueInstance;
        private static readonly object SyncLock = new Object();

        static readonly IService Service = new Service();
        public List<Estadocita> EstadocitaList { get; set; }
        public List<VwProgramacioncitadet> VwProgramacioncitadetList { get; set; }
        public ModuloClinica PrincipalFrm { get; set; }
        public bool SaveLayoutGridControl { get; set; }

        private readonly string _regKeyGridControl;
        private ProgramacioncitaVisorFrm(ModuloClinica principalFrm)
        {
            InitializeComponent();
            _regKeyGridControl = string.Format("WinFormsApp\\Layouts\\{0}_MainLayout", Name);
            EstadocitaList = Service.GetAllEstadocita();
            PrincipalFrm = principalFrm;
            SaveLayoutGridControl = false;
            SetGridFont(gvCitas, new Font(SessionApp.EmpleadoSel.Nombrefuente, (float) SessionApp.EmpleadoSel.Fuentetamanio));
            btnEliminarProgramacion.Enabled = SessionApp.UsuarioSel.Nombreusuario.Equals("NMELO");
        }

        public static ProgramacioncitaVisorFrm GetInstance(ModuloClinica principalFrm)
        {
            // Lock entire body of method
            lock (SyncLock)
            {
                if (_uniqueInstance == null || _uniqueInstance.IsDisposed)
                {
                    _uniqueInstance = new ProgramacioncitaVisorFrm(principalFrm);
                }
                _uniqueInstance.BringToFront();
                return _uniqueInstance;
            }
        }

        private void CargarCitas()
        {
            Cursor = Cursors.WaitCursor;
            DateTime fechaCalendario = iCalendarioCita.DateTime;

            //VwProgramacioncitadet vwProgramacioncitadet = (VwProgramacioncitadet)gvCitas.GetFocusedRow();

            string condicionMedico = iFiltroMedico.EditValue != null
                ? string.Format(" and idmedico = {0}", (int) iFiltroMedico.EditValue)
                : string.Empty;
            string condicionFecha = string.Format("Fechaprogramacion = '{0:yyyy-MM-dd}' {1}", fechaCalendario, condicionMedico);
            VwProgramacioncitadetList = Service.GetAllVwProgramacioncitadet(condicionFecha, "horaprogramacion");
            gcCitas.DataSource = VwProgramacioncitadetList;
            //gcHoraInicio.BestFit();
            //gcHoraTermino.BestFit();
            //gvCitas.BestFitColumns(true);


            //if (gvCitas.RowCount > 0 && vwProgramacioncitadet != null )
            //{
            //    var rowHandle = gvCitas.LocateByValue("Idprogramacioncitadet", vwProgramacioncitadet.Idprogramacioncitadet);
            //    if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            //    {
            //        gvCitas.FocusedRowHandle = rowHandle;
            //    }

            //}

            string mensajeMedico;
            if (!string.IsNullOrEmpty(condicionMedico))
            {
                mensajeMedico = " - Dr." + iFiltroMedico.Text.Trim();
            }
            else
            {
                mensajeMedico = string.Empty;
            }
            Text = string.Empty;
            //Text = string.Format("Citas para el día {0:D} {1}", fechaCalendario, mensajeMedico);
            Text = string.Format("{0:D} {1}", fechaCalendario, mensajeMedico);
            Cursor = Cursors.Default;
        }

        private void ProgramacioncitaVisorFrm_Load(object sender, EventArgs e)
        {
            iCalendarioCita.EditValue = SessionApp.DateServer;            
            CargarReferencias();
            iCalendarioCita.CellStyleProvider = new CustomCellStyleProvider();
            RestoreLayoutFromRegistry();

            
        }


        private void CargarReferencias()
        {
            iFiltroMedico.Properties.DataSource = Service.GetAllVwEmpleado(x => x.Denominacionfuncion == "MEDICO" && x.Idempresa == SessionApp.EmpresaSel.Idempresa);
            iFiltroMedico.Properties.DisplayMember = "Razonsocial";
            iFiltroMedico.Properties.ValueMember = "Idempleado";
            iFiltroMedico.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void bmCitas_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            VwProgramacioncitadet vwProgramacioncitadetSel;
            int idSocioNegocioPacienteRegistrado = 0;
            Socionegocio socionegocioRegistrado;

            switch (e.Item.Name)
            {
                case "btnVerEditarrCita":
                     if (gvCitas.RowCount == 0)
                    {
                        break;
                    }
                    VerEditarCita();
                    break;
                case "btnActualizar":
                    CargarCitas();
                    break;
                case "cmdVerHistorial":
                    vwProgramacioncitadetSel = (VwProgramacioncitadet) gvCitas.GetFocusedRow();
                    if (vwProgramacioncitadetSel != null)
                    {
                        HistorialCitaFrm historialCitaFrm = new HistorialCitaFrm(vwProgramacioncitadetSel);
                        historialCitaFrm.ShowDialog(this);

                    }
                    break;
                case "btnCpVenta":
                    vwProgramacioncitadetSel = (VwProgramacioncitadet) gvCitas.GetFocusedRow();
                    CpventaMntFrm cpventaMntFrm;
                    
                    

                    if (vwProgramacioncitadetSel == null)
                    {
                        break;
                    }
                    if (vwProgramacioncitadetSel.Idpaciente == null)
                    {
                        WinFormUtils.MessageWarning("Registre el paciente para continuar.");
                        break;
                    }

                    //Verificar si existe el socio de negocio
                    socionegocioRegistrado =
                        Service.GetSocionegocio(
                            x =>
                                x.Idpersona == vwProgramacioncitadetSel.Idpaciente &&
                                x.Idempresa == SessionApp.EmpresaSel.Idempresa);

                    if (socionegocioRegistrado == null)
                    {
                        WinFormUtils.MessageWarning("Paciente no está registrado como socio de negocio.");
                        SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(
                            0,
                            TipoMantenimiento.Nuevo,
                            null,
                            null,
                            Convert.ToInt32(vwProgramacioncitadetSel.Idpaciente));
                        if (socionegocioMntFrm.ShowDialog() == DialogResult.OK)
                        {
                            idSocioNegocioPacienteRegistrado = socionegocioMntFrm.IdEntidadMnt;
                        }
                    }
                    else
                    {
                        idSocioNegocioPacienteRegistrado = socionegocioRegistrado.Idsocionegocio;
                    }

                    if (idSocioNegocioPacienteRegistrado > 0 && vwProgramacioncitadetSel.Idcpventa == null)
                    {
                        //TODO: CLINICA
                        cpventaMntFrm = new CpventaMntFrm(
                                0,
                                TipoMantenimiento.Nuevo,
                                null,
                                null,
                                idSocioNegocioPacienteRegistrado,
                                vwProgramacioncitadetSel.Idprogramacioncitadet,
                                vwProgramacioncitadetSel.Idmotivocita);

                        if (cpventaMntFrm.ShowDialog() == DialogResult.OK)
                        {
                            CargarCitas();
                        }
                    }

                    if (vwProgramacioncitadetSel.Idcpventa != null)
                    {
                        cpventaMntFrm = new CpventaMntFrm(
                                Convert.ToInt32(vwProgramacioncitadetSel.Idcpventa),
                                TipoMantenimiento.Modificar,
                                null,
                                null);
                        if (cpventaMntFrm.ShowDialog() == DialogResult.OK)
                        {
                            CargarCitas();
                        }
                    }                    

                    break;
                case "btnVerPagos":
                    vwProgramacioncitadetSel = (VwProgramacioncitadet)gvCitas.GetFocusedRow();
                    if (vwProgramacioncitadetSel.Idcpventa == null)
                    {
                        WinFormUtils.MessageWarning("No ha registrado un comproabane de venta.");
                        break;
                    }

                    //Verificar si existe el socio de negocio
                    socionegocioRegistrado =
                        Service.GetSocionegocio(
                            x =>
                                x.Idpersona == vwProgramacioncitadetSel.Idpaciente &&
                                x.Idempresa == SessionApp.EmpresaSel.Idempresa);

                    if (socionegocioRegistrado == null)
                    {
                        WinFormUtils.MessageWarning("No ha registrado un socio de negocio.");
                        break;
                    }

                    if (vwProgramacioncitadetSel.Idrecibocajaingreso == null)
                    {
                        CajaCobroCpVentaFrm cajaCobroCpVentaFrm = new CajaCobroCpVentaFrm(Convert.ToInt32(vwProgramacioncitadetSel.Idcpventa),SessionApp.EmpleadoSel.Idempleado);
                        cajaCobroCpVentaFrm.ShowDialog();
                        if (cajaCobroCpVentaFrm.DialogResult == DialogResult.OK)
                        {
                            CargarCitas();
                        }

                    }
                    else                    
                    {
                        RecibocajaingresoMntFrm recibocajaingresoMntFrm = new RecibocajaingresoMntFrm(Convert.ToInt32(vwProgramacioncitadetSel.Idrecibocajaingreso), TipoMantenimiento.Modificar, null, null);
                        recibocajaingresoMntFrm.ShowDialog();
                        if (recibocajaingresoMntFrm.DialogResult == DialogResult.OK)
                        {
                            CargarCitas();
                        }
                    }
                    break;
            }

        }

        private void VerEditarCita()
        {
            VwProgramacioncitadet vwProgramacioncitadet;
            ProgramacioncitaMntItemVisorFrm programacioncitaMntItemFrm;
            vwProgramacioncitadet = (VwProgramacioncitadet) gvCitas.GetFocusedRow();

            programacioncitaMntItemFrm = new ProgramacioncitaMntItemVisorFrm(TipoMantenimiento.Modificar, vwProgramacioncitadet);
            programacioncitaMntItemFrm.ShowDialog();

            if (programacioncitaMntItemFrm.DialogResult == DialogResult.OK)
            {
                Programacioncitadet programacioncitadet = AsignarProgramacioncitadet(vwProgramacioncitadet);
                if (programacioncitadet.Idprogramacioncitadet > 0)
                {
                    Service.UpdateProgramacioncitadet(programacioncitadet);
                   
                    //Obtener el siguiente registro
                    VwProgramacioncitadet vwProgramacioncitadetNext = VwProgramacioncitadetList.FirstOrDefault(x => x.Horaprogramacion > vwProgramacioncitadet.Horaprogramacion);
                    if (vwProgramacioncitadetNext != null)
                    {
                        Estadocita estadocita = Service.GetEstadocita(x => x.Idestadocita == vwProgramacioncitadetNext.Idestadocita);
                        if (estadocita != null && estadocita.Estadopordefectoprogramacion)
                        {
                            if (vwProgramacioncitadet.Horatermino != null)
                            {
                                vwProgramacioncitadetNext.Horaprogramacion = (DateTime)vwProgramacioncitadet.Horatermino;
                                Programacioncitadet programacioncitadetNext = AsignarProgramacioncitadet(vwProgramacioncitadetNext);
                                if (programacioncitadetNext.Idprogramacioncitadet > 0)
                                {
                                    Service.UpdateProgramacioncitadet(programacioncitadetNext);
                                }                                
                            }                            
                        }                        
                    }
                    //

                    PrincipalFrm.SendMessage(vwProgramacioncitadet.Idprogramacioncitadet.ToString());
                    ActualizarCitas();
                }
            }
        }

        private void ActualizarCitas()
        {

            gvCitas.BeginUpdate();
            gvCitas.RefreshData();
            gvCitas.EndUpdate();
            gvCitas.BestFitColumns(true);
        }

        private Programacioncitadet AsignarProgramacioncitadet(VwProgramacioncitadet vwProgramacioncitadet)
        {

            Programacioncitadet programacioncitadet = new Programacioncitadet
            {
                Idprogramacioncitadet = vwProgramacioncitadet.Idprogramacioncitadet,
                Idprogramacioncita = vwProgramacioncitadet.Idprogramacioncita,
                Horaprogramacion = vwProgramacioncitadet.Horaprogramacion,
                Idpersona = vwProgramacioncitadet.Idpaciente,
                Idestadocita = vwProgramacioncitadet.Idestadocita,
                Idmotivocita = vwProgramacioncitadet.Idmotivocita,
                Horatermino = vwProgramacioncitadet.Horatermino

            };
            return programacioncitadet;
        }

        private void gvCitas_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0 && view != null)
            {
                string nombreEstadoCita = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Nombreestadocita"]);
                Estadocita estadocita = EstadocitaList.FirstOrDefault(x => x.Nombreestadocita.Equals(nombreEstadoCita.Trim()));
                if (estadocita != null)
                {
                    if (nombreEstadoCita.Trim() == estadocita.Nombreestadocita.Trim())
                    {
                        e.Appearance.BackColor = Color.FromArgb(estadocita.Colorestadocita);
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }

            if (e.Column.FieldName == "Nombrecomercialmedico")
            {
                if (view != null)
                {
                    string horaprogramacion = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Horaprogramacion"]);                    
                    DateTime horaInicio = DateTime.Parse(horaprogramacion);
                    TimeSpan todayTime = horaInicio.TimeOfDay;
                    if (todayTime >= new TimeSpan(14, 00, 00))
                    {
                        e.Appearance.BackColor = Color.Orange;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void gvCitas_DoubleClick(object sender, EventArgs e)
        {
            VerEditarCita();
        }

        private void iCalendarioCita_DateTimeChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        public void BuscarCita(VwProgramacioncitadet vwProgramacioncitadetBusqueda)
        {
            FormWindowState formWindowStateCurrent = PrincipalFrm.WindowState;
            if (PrincipalFrm.WindowState == FormWindowState.Minimized)
            {
                PrincipalFrm.WindowState = formWindowStateCurrent;
            }

            //PrincipalFrm.Activate();
            //PrincipalFrm.BringToFront();

            if (vwProgramacioncitadetBusqueda != null)
            {
                int idProgramacionDet = vwProgramacioncitadetBusqueda.Idprogramacioncitadet;
                if ((DateTime) iCalendarioCita.EditValue == vwProgramacioncitadetBusqueda.Fechaprogramacion)
                {
                    CargarCitas();
                }
                else
                {
                    iCalendarioCita.EditValue = vwProgramacioncitadetBusqueda.Fechaprogramacion;
                }

                int rowHandle = gvCitas.LocateByValue("Idprogramacioncitadet", idProgramacionDet);
                if (rowHandle == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    return;
                }
                gvCitas.FocusedRowHandle = rowHandle;

                
                

                //VwProgramacioncitadet vwRequerimientodetModified = VwProgramacioncitadetList.FirstOrDefault(x => x.Idprogramacioncitadet == idProgramacionDet);
                //int indexItem = VwProgramacioncitadetList.IndexOf(vwRequerimientodetModified);
                //VwProgramacioncitadetList.Remove(vwRequerimientodetModified);
                //if (vwRequerimientodetModified != null)
                //{
                //    VwProgramacioncitadet vwProgramacioncitadetNew = Service.GetVwProgramacioncitadet(x => x.Idprogramacioncitadet == idProgramacionDet);
                //    if (vwProgramacioncitadetNew != null)
                //    {
                //        VwProgramacioncitadetList.Insert(indexItem, vwProgramacioncitadetNew);
                //        //ActualizarCitas();
                //        int rowHandle = gvCitas.LocateByValue("Idprogramacioncitadet", idProgramacionDet);
                //        if (rowHandle == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                //        {
                //            return;
                //        }                       
                //        gvCitas.FocusedRowHandle = rowHandle;

                //    }
                //}
            }
        }

        private void gvCitas_CellDoubleClick(object sender, EventArgs e)
        {
            VerEditarCita();
        }

        private void gvCitas_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view != null) view.ActiveEditor.DoubleClick += gvCitas_CellDoubleClick;
        }

        public void RestoreLayoutFromRegistry()
        {
            if (SaveLayoutGridControl)
                gcCitas.MainView.RestoreLayoutFromRegistry(_regKeyGridControl);

        }

        public void SaveLayoutToRegistry()
        {
            if (SaveLayoutGridControl)
                gcCitas.MainView.SaveLayoutToRegistry(_regKeyGridControl);

        }

        private void ProgramacioncitaVisorFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayoutToRegistry();
        }

        private void iFiltroMedico_EditValueChanged(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void btnVerEditarrCita_Click(object sender, EventArgs e)
        {
            VwProgramacioncitadet vwProgramacioncitadetSel;
            int idSocioNegocioPacienteRegistrado = 0;
            Socionegocio socionegocioRegistrado;
            if (gvCitas.RowCount == 0)
            {
                return;
            }
            VerEditarCita();

        }

        private void cmdVerHistorial_Click(object sender, EventArgs e)
        {
            VwProgramacioncitadet vwProgramacioncitadetSel;
            int idSocioNegocioPacienteRegistrado = 0;
            Socionegocio socionegocioRegistrado;

            vwProgramacioncitadetSel = (VwProgramacioncitadet)gvCitas.GetFocusedRow();
            if (vwProgramacioncitadetSel != null)
            {
                HistorialCitaFrm historialCitaFrm = new HistorialCitaFrm(vwProgramacioncitadetSel);
                historialCitaFrm.ShowDialog(this);

            }

        }

        private void btnCpVenta_Click(object sender, EventArgs e)
        {
            VwProgramacioncitadet vwProgramacioncitadetSel;
            int idSocioNegocioPacienteRegistrado = 0;
            Socionegocio socionegocioRegistrado;


            vwProgramacioncitadetSel = (VwProgramacioncitadet)gvCitas.GetFocusedRow();
            CpventaMntFrm cpventaMntFrm;



            if (vwProgramacioncitadetSel == null)
            {
                return;
            }
            if (vwProgramacioncitadetSel.Idpaciente == null)
            {
                WinFormUtils.MessageWarning("Registre el paciente para continuar.");
                return;
            }   

            //Verificar si existe el socio de negocio
            socionegocioRegistrado =
                Service.GetSocionegocio(
                    x =>
                        x.Idpersona == vwProgramacioncitadetSel.Idpaciente &&
                        x.Idempresa == SessionApp.EmpresaSel.Idempresa);

            if (socionegocioRegistrado == null)
            {
                WinFormUtils.MessageWarning("Paciente no está registrado como socio de negocio.");
                SocionegocioMntFrm socionegocioMntFrm = new SocionegocioMntFrm(
                    0,
                    TipoMantenimiento.Nuevo,
                    null,
                    null,
                    Convert.ToInt32(vwProgramacioncitadetSel.Idpaciente));

                if (socionegocioMntFrm.ShowDialog() == DialogResult.OK)
                {
                    idSocioNegocioPacienteRegistrado = socionegocioMntFrm.IdEntidadMnt;
                }
            }
            else
            {
                idSocioNegocioPacienteRegistrado = socionegocioRegistrado.Idsocionegocio;
            }

            if (idSocioNegocioPacienteRegistrado > 0 && vwProgramacioncitadetSel.Idcpventa == null)
            {
                //TODO: Clinica
                cpventaMntFrm = new CpventaMntFrm(
                        0,
                        TipoMantenimiento.Nuevo,
                        null,
                        null,
                        idSocioNegocioPacienteRegistrado,
                        vwProgramacioncitadetSel.Idprogramacioncitadet,
                        vwProgramacioncitadetSel.Idmotivocita);

                if (cpventaMntFrm.ShowDialog() == DialogResult.OK)
                {
                    CargarCitas();
                }
            }

            if (vwProgramacioncitadetSel.Idcpventa != null)
            {
                cpventaMntFrm = new CpventaMntFrm(
                        Convert.ToInt32(vwProgramacioncitadetSel.Idcpventa),
                        TipoMantenimiento.Modificar,
                        null,
                        null);
                if (cpventaMntFrm.ShowDialog() == DialogResult.OK)
                {
                    CargarCitas();
                }
            }                    

        }

        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            VwProgramacioncitadet vwProgramacioncitadetSel;
            int idSocioNegocioPacienteRegistrado = 0;
            Socionegocio socionegocioRegistrado;


            vwProgramacioncitadetSel = (VwProgramacioncitadet)gvCitas.GetFocusedRow();
            if (vwProgramacioncitadetSel.Idcpventa == null)
            {
                WinFormUtils.MessageWarning("No ha registrado un comproabane de venta.");
                return;
            }

            //Verificar si existe el socio de negocio
            socionegocioRegistrado =
                Service.GetSocionegocio(
                    x =>
                        x.Idpersona == vwProgramacioncitadetSel.Idpaciente &&
                        x.Idempresa == SessionApp.EmpresaSel.Idempresa);

            if (socionegocioRegistrado == null)
            {
                WinFormUtils.MessageWarning("No ha registrado un socio de negocio.");
                return;
            }

            if (vwProgramacioncitadetSel.Idrecibocajaingreso == null)
            {
                CajaCobroCpVentaFrm cajaCobroCpVentaFrm = new CajaCobroCpVentaFrm(Convert.ToInt32(vwProgramacioncitadetSel.Idcpventa), SessionApp.EmpleadoSel.Idempleado);
                cajaCobroCpVentaFrm.ShowDialog();
                if (cajaCobroCpVentaFrm.DialogResult == DialogResult.OK)
                {
                    CargarCitas();
                }

            }
            else
            {
                RecibocajaingresoMntFrm recibocajaingresoMntFrm = new RecibocajaingresoMntFrm(Convert.ToInt32(vwProgramacioncitadetSel.Idrecibocajaingreso), TipoMantenimiento.Modificar, null, null);
                recibocajaingresoMntFrm.ShowDialog();
                if (recibocajaingresoMntFrm.DialogResult == DialogResult.OK)
                {
                    CargarCitas();
                }
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarCitas();
        }

        void SetGridFont(GridView view, Font font)
        {
            foreach (AppearanceObject ap in view.Appearance)
                ap.Font = font;
        }

        private void btnEliminarProgramacion_Click(object sender, EventArgs e)
        {
            if (gvCitas.RowCount == 0)
            {
                return;
            }
            gvCitas.Focus();

            VwProgramacioncitadet vwProgramacioncitadetVerificar = (VwProgramacioncitadet)gvCitas.GetFocusedRow();
            Programacioncitadet programacioncitadetVerificar = Service.GetProgramacioncitadet(x => x.Idprogramacioncitadet == vwProgramacioncitadetVerificar.Idprogramacioncitadet && x.Idpersona != null);

            if (programacioncitadetVerificar != null)
            {
                WinFormUtils.ErrorMessage("No se puede eliminar la programación ya esta registrado un paciente para esa fecha y hora");
                return;
            }

            if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                "Eliminar Item", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {

                VwProgramacioncitadet vwProgramacioncitadet = (VwProgramacioncitadet)gvCitas.GetFocusedRow();
                if (vwProgramacioncitadet != null && vwProgramacioncitadet.Idprogramacioncitadet > 0)
                {
                    Service.DeleteProgramacioncitadet(vwProgramacioncitadet.Idprogramacioncitadet);
                    vwProgramacioncitadet.DataEntityState = DataEntityState.Deleted;

                    //VwProgramacioncitadet vwProgramacioncitadetNext = VwProgramacioncitadetList.FirstOrDefault(x => x.id > vwProgramacioncitadet.Horaprogramacion);

                    CargarCitas();

                    //if (!gvCitas.IsFirstRow)
                    //{
                    //    gvCitas.MovePrev();
                    //}
                }
            }

        }
    }
}
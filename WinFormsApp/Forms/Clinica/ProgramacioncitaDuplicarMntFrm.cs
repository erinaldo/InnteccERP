using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class ProgramacioncitaDuplicarMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public ProgramacioncitaDuplicarFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Programacioncita ProgramacioncitaMnt { get; set; }

        public List<VwArticulo> VwArticuloList { get; set; }
        public List<VwProgramacioncitadet> VwProgramacioncitadetList { get; set; }
        public Estadocita EstadocitaPorDefecto { get; set; }
        public Articulo ArticuloMotivocitaPorDefecto { get; set; }
        public ProgramacioncitaDuplicarMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, ProgramacioncitaDuplicarFrm formParent)
        {
            if (tipoMnt == TipoMantenimiento.SinEspecificar && idEntidadMnt <= 0)
            {
                throw new ArgumentException("El valor primario de la entidad no contiene un valor valido.");
            }
            InitializeComponent();

            IdEntidadMnt = idEntidadMnt;
            TipoMnt = tipoMnt;
            SeEliminoObjeto = false;
            GridParent = gridParent;
            FormParent = formParent;

            var styleController = new StyleController();
            WinFormUtils.SetStyleController(this, styleController);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;
        }

        private void ProgramacioncitaDuplicarMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void InicioTipoMantenimiento()
        {
            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    ValoresPorDefecto();
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    ProgramacioncitaMnt = new Programacioncita();
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    iHasta.EditValue = SessionApp.DateServer;
                    CargarDetalle();
                    EstablecerEstadoMotivoPorDefecto();
                    break;
            }
        }

        private void EstablecerEstadoMotivoPorDefecto()
        {

            Estadocita estadocitaPorDefectoProgramacion = Service.GetEstadocita(x => x.Estadopordefectoprogramacion);
            if (estadocitaPorDefectoProgramacion != null)
            {
                EstadocitaPorDefecto = estadocitaPorDefectoProgramacion;
            }

            Articulo articuloMotivocitaPorDefectoProgramacion = Service.GetArticulo(x => x.Motivopordefectoprogramacion);
            if (articuloMotivocitaPorDefectoProgramacion != null)
            {
                ArticuloMotivocitaPorDefecto = articuloMotivocitaPorDefectoProgramacion;
            }
        }

        private void CargarReferencias()
        {
            iIdmedico.Properties.DataSource = CacheObjects.VwEmpleadoList;
            iIdmedico.Properties.DisplayMember = "Razonsocial";
            iIdmedico.Properties.ValueMember = "Idempleado";
            iIdmedico.Properties.BestFitMode = BestFitMode.BestFit;

            iIdmedico.Properties.DataSource = CacheObjects.VwEmpleadoList;
            iIdmedico.Properties.DisplayMember = "Razonsocial";
            iIdmedico.Properties.ValueMember = "Idempleado";
            iIdmedico.Properties.BestFitMode = BestFitMode.BestFit;

            string whereSucursal = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            rIdsucursal.Properties.DataSource = Service.GetAllVwSucursal(whereSucursal, "Nombresucursal");
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            string whereServicio = "esserviciomedico = '1'";
            VwArticuloList = Service.GetAllVwArticulo(whereServicio, "Nombrearticulo");
            iIdservicio.Properties.DataSource = VwArticuloList;
            iIdservicio.Properties.DisplayMember = "Nombrearticulo";
            iIdservicio.Properties.ValueMember = "Idarticulo";
            iIdservicio.Properties.BestFitMode = BestFitMode.BestFit;

        }

        private void TraerDatos()
        {
            try
            {
                ProgramacioncitaMnt = Service.GetProgramacioncita(IdEntidadMnt);
                iIdservicio.EditValue = ProgramacioncitaMnt.Idservicio;
                iIdmedico.EditValue = ProgramacioncitaMnt.Idmedico;
                iFechaprogramacion.EditValue = ProgramacioncitaMnt.Fechaprogramacion;
                iActivo.EditValue = ProgramacioncitaMnt.Activo;
                rIdsucursal.EditValue = ProgramacioncitaMnt.Idsucursal;
            }
            catch
            {
                DeshabilitarBtnMnt();
                LimpiarCampos();
                throw;
            }
        }

        private void CargarDetalle()
        {
            gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idprogramacioncita = '{0}'", IdEntidadMnt);
            gvDetalle.BeginUpdate();

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    VwProgramacioncitadetList = new List<VwProgramacioncitadet>();
                    break;
                case TipoMantenimiento.Modificar:
                    VwProgramacioncitadetList = Service.GetAllVwProgramacioncitadet(where, "horaprogramacion");
                    break;
            }

            gcDetalle.DataSource = VwProgramacioncitadetList;
            gvDetalle.EndUpdate();
            gvDetalle.BestFitColumns(true);
        }

        private bool Guardar()
        {

            if (!Validaciones()) return false;
            try
            {

                Programacioncita programacioncitaBase = Service.GetProgramacioncita(x => x.Idprogramacioncita == IdEntidadMnt);

                DateTime desde = ((DateTime)iFechaprogramacion.EditValue).AddDays(1);
                DateTime hasta = (DateTime)iHasta.EditValue;

                Cursor = Cursors.WaitCursor;
                

                for (DateTime fechaProceso = desde; fechaProceso <= hasta; fechaProceso = fechaProceso.AddDays(1))
                {
                    if (iDomingo.Checked && fechaProceso.DayOfWeek == DayOfWeek.Sunday)
                    {
                        DuplicarProgramacion(programacioncitaBase, fechaProceso);
                    }

                    if (iLunes.Checked && fechaProceso.DayOfWeek == DayOfWeek.Monday)
                    {
                        DuplicarProgramacion(programacioncitaBase, fechaProceso);
                    }

                    if (iMartes.Checked && fechaProceso.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        DuplicarProgramacion(programacioncitaBase, fechaProceso);
                    }

                    if (iMiercoles.Checked && fechaProceso.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        DuplicarProgramacion(programacioncitaBase, fechaProceso);
                    }

                    if (iJueves.Checked && fechaProceso.DayOfWeek == DayOfWeek.Thursday)
                    {
                        DuplicarProgramacion(programacioncitaBase, fechaProceso);
                    }

                    if (iVierne.Checked && fechaProceso.DayOfWeek == DayOfWeek.Friday)
                    {
                        DuplicarProgramacion(programacioncitaBase, fechaProceso);
                    }

                    if (iSabado.Checked && fechaProceso.DayOfWeek == DayOfWeek.Saturday)
                    {
                        DuplicarProgramacion(programacioncitaBase, fechaProceso);
                    }                    

                }

                Cursor = Cursors.Default;
                DialogResult = DialogResult.OK;
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            return true;
        }

        private void DuplicarProgramacion(Programacioncita programacioncitaBase, DateTime fechaProceso)
        {
            Programacioncita programacioncitaVerificacion =
                Service.GetProgramacioncita(
                    x =>
                        x.Idservicio == programacioncitaBase.Idservicio &&
                        x.Idmedico == programacioncitaBase.Idmedico &&
                        x.Fechaprogramacion == fechaProceso &&
                        x.Idsucursal == programacioncitaBase.Idsucursal);

            if (programacioncitaVerificacion == null)
            {

                Programacioncita programacioncita = new Programacioncita();
                programacioncita.Idprogramacioncita = 0;
                programacioncita.Idservicio = (int)iIdservicio.EditValue;
                programacioncita.Idmedico = (int)iIdmedico.EditValue;
                programacioncita.Fechaprogramacion = fechaProceso;
                programacioncita.Activo = (bool)iActivo.EditValue;
                programacioncita.Idsucursal = (int)rIdsucursal.EditValue;


                int idprogramacioncitaNew = Service.SaveProgramacioncita(programacioncita);
                if (idprogramacioncitaNew > 0)
                {
                    programacioncita.Idprogramacioncita = idprogramacioncitaNew;

                    //List<Programacioncitadet> programacioncitadetList = Service.GetAllProgramacioncitadet(x => x.Idprogramacioncita == idProgramacioncitaBase);
                    foreach (VwProgramacioncitadet vwProgramacioncitadet in VwProgramacioncitadetList)
                    {
                        Programacioncitadet programacioncitadet = AsignarProgramacioncitadet(vwProgramacioncitadet);
                        programacioncitadet.Idprogramacioncitadet = 0;
                        programacioncitadet.Idprogramacioncita = idprogramacioncitaNew;
                        Service.SaveProgramacioncitadet(programacioncitadet);
                    }
                }
                
            }

        }


        private bool Validaciones()
        {
            DateTime desde = ((DateTime)iFechaprogramacion.EditValue).AddDays(1);
            DateTime hasta = (DateTime)iHasta.EditValue;

            if (hasta < desde)
            {
                XtraMessageBox.Show("La fecha final no puede ser menor a la fecha inicial", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                iHasta.Select();
                return false;
            }
            if (!WinFormUtils.ValidateFieldsNotEmpty(this, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (EstadocitaPorDefecto == null)
            {
                XtraMessageBox.Show("No se establecio el estado por defecto.", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ArticuloMotivocitaPorDefecto == null)
            {
                XtraMessageBox.Show("No se establecio el motivo por defecto.", Resources.titAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (WinFormUtils.MessageQuestion(string.Format("¿Desea procesar de la fecha {0} hasta {1}?", desde.ToString("dd-MM-yy"), hasta.ToString("dd-MM-yy"))) == DialogResult.No)
            {
                return false;
            }



            return true;
        }

        private void EliminaRegistro()
        {
            if (Convert.ToInt32(pkIdEntidad.EditValue) > 0)
            {
                if (DialogResult.Yes == XtraMessageBox.Show(Resources.msgEliminarRegistro,
                                                        Resources.titPregunta, MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        Service.DeleteProgramacioncita(IdEntidadMnt);
                        SeEliminoObjeto = true;
                        Close();
                    }
                    catch
                    {
                        Cursor = Cursors.Default;
                        SeEliminoObjeto = false;
                        DeshabilitarBtnMnt();
                        CamposSoloLectura(true);
                        throw;
                    }
                }
            }
        }

        private void EstablecerPermisos()
        {
            if (FormParent == null)
            {
                int index = Name.Trim().LastIndexOf("Mnt", StringComparison.Ordinal);
                string nameFrm = Name.Substring(0, index) + "Frm";
                Permisos = Service.GetPermisosForm(IdUsuario, nameFrm);
            }
            else
            {
                Permisos = FormParent.Permisos;
            }

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Nuevo;
                    btnGrabarCerrar.Enabled = Permisos.Nuevo;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    CamposSoloLectura(!Permisos.Nuevo);
                    break;
                case TipoMantenimiento.Modificar:
                    btnNuevo.Enabled = Permisos.Nuevo;
                    btnGrabar.Enabled = Permisos.Editar;
                    btnGrabarCerrar.Enabled = Permisos.Editar;
                    btnGrabarNuevo.Enabled = Permisos.Nuevo && Permisos.Editar;
                    btnEliminar.Enabled = Permisos.Eliminar;
                    CamposSoloLectura(!Permisos.Editar);
                    break;
            }
        }

        private void bmMantenimiento_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            switch (e.Item.Name)
            {
                case "btnNuevo":
                    LimpiarCampos();
                    TipoMnt = TipoMantenimiento.Nuevo;
                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    ProgramacioncitaMnt = null;
                    ProgramacioncitaMnt = new Programacioncita();

                    btnGrabar.Enabled = true;
                    btnGrabarCerrar.Enabled = true;
                    btnGrabarNuevo.Enabled = true;

                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;

                    if (Permisos.Nuevo)
                        CamposSoloLectura(false);
                    break;

                case "btnGrabar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        btnGrabar.Enabled = true;
                        btnGrabarCerrar.Enabled = true;
                        btnGrabarNuevo.Enabled = true;
                        TipoMnt = TipoMantenimiento.Modificar;

                        if (Permisos.Eliminar)
                        {
                            btnEliminar.Enabled = true;
                            btnActualizar.Enabled = true;
                        }
                    }
                    break;
                case "btnGrabarCerrar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        Close();
                    }
                    break;
                case "btnGrabarNuevo":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        LimpiarCampos();
                        TipoMnt = TipoMantenimiento.Nuevo;
                        pkIdEntidad.EditValue = 0;
                        IdEntidadMnt = 0;

                        btnEliminar.Enabled = false;
                        btnActualizar.Enabled = false;

                        ValoresPorDefecto();

                        ProgramacioncitaMnt = null;
                        ProgramacioncitaMnt = new Programacioncita();
                    }

                    if (Permisos.Nuevo)
                        CamposSoloLectura(false);

                    break;
                case "btnEliminar":
                    EliminaRegistro();
                    break;
                case "btnLimpiarCampos":
                    LimpiarCampos();
                    break;
                case "btnActualizar":
                    if (IdEntidadMnt > 0)
                    {
                        TraerDatos();
                    }
                    break;
                case "btnCerrar":
                    if (SeGuardoObjeto)
                    {
                        Close();
                    }
                    else
                    {
                        ProgramacioncitaMnt = null;
                        Close();
                    }
                    break;
            }
        }

        private void DeshabilitarBtnMnt()
        {
            pkIdEntidad.EditValue = 0;
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = false;
            btnGrabarCerrar.Enabled = false;
            btnGrabarNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void ProgramacioncitaDuplicarMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void LimpiarCampos()
        {
            WinFormUtils.ClearFields(this);
        }

        private void CamposSoloLectura(bool readOnly)
        {
            WinFormUtils.ReadOnlyFields(this, readOnly);
        }

        private void ValoresPorDefecto()
        {
            iFechaprogramacion.EditValue = SessionApp.DateServer;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            iFechaprogramacion.Select();
        }

        private void ProgramacioncitaDuplicarMntFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (FormParent != null)
            //{                
            //    if (SeEliminoObjeto)
            //    {
            //        FormParent.CargarDatosConsulta();
            //    }
            //    if (SeGuardoObjeto)
            //    {                    
            //        FormParent.IdEntidadMnt = IdEntidadMnt;
            //        FormParent.CargarDatosConsulta();
            //        FormParent.SetFocusIdEntity();
            //    }
            //}
            //e.Cancel = false;
        }

        private void iIdservicio_EditValueChanged(object sender, EventArgs e)
        {
            var idServicio = iIdservicio.EditValue;
            if (idServicio != null)
            {
                VwArticulo vwArticuloSel = VwArticuloList.FirstOrDefault(x => x.Idarticulo == (int)idServicio);
                if (vwArticuloSel != null)
                {
                    iCodigoarticulo.EditValue = vwArticuloSel.Codigoarticulo;
                }
            }
        }

        private void bmItemsProgramacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            ProgramacioncitaMntItemFrm programacioncitaMntItemFrm;
            VwProgramacioncitadet vwProgramacioncitadet;

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwProgramacioncitadet = new VwProgramacioncitadet();
                    vwProgramacioncitadet.Idprogramacioncita = IdEntidadMnt;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    programacioncitaMntItemFrm = new ProgramacioncitaMntItemFrm(tipoMantenimientoItem, vwProgramacioncitadet);
                    programacioncitaMntItemFrm.ShowDialog();

                    if (programacioncitaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwProgramacioncitadetList.Add(vwProgramacioncitadet);
                        ActualizarDetalle();
                        if (!gvDetalle.IsLastRow)
                        {
                            gvDetalle.MoveLastVisible();
                            gvDetalle.Focus();
                        }
                        //Programacioncitadet programacioncitadet = AsignarProgramacioncitadet(vwProgramacioncitadet);
                        //int idprogramacioncitadet = Service.SaveProgramacioncitadet(programacioncitadet);
                        //if (idprogramacioncitadet > 0)
                        //{
                        //    vwProgramacioncitadet.Idprogramacioncitadet = idprogramacioncitadet;
                        //    VwProgramacioncitadetList.Add(vwProgramacioncitadet);
                        //    ActualizarDetalle();
                        //    if (!gvDetalle.IsLastRow)
                        //    {
                        //        gvDetalle.MoveLastVisible();
                        //        gvDetalle.Focus();
                        //    }
                        //}

                    }


                    break;

                case "btnEditItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }
                    vwProgramacioncitadet = (VwProgramacioncitadet)gvDetalle.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    programacioncitaMntItemFrm = new ProgramacioncitaMntItemFrm(tipoMantenimientoItem, vwProgramacioncitadet);
                    programacioncitaMntItemFrm.ShowDialog();

                    if (programacioncitaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        ActualizarDetalle();
                        //Programacioncitadet programacioncitadet = AsignarProgramacioncitadet(vwProgramacioncitadet);
                        //if (programacioncitadet.Idprogramacioncitadet > 0)
                        //{
                        //    Service.UpdateProgramacioncitadet(programacioncitadet);
                        //    ActualizarDetalle();
                        //}
                    }


                    break;

                case "btnDelItem":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwProgramacioncitadet = (VwProgramacioncitadet)gvDetalle.GetFocusedRow();
                        if (vwProgramacioncitadet != null && vwProgramacioncitadet.Idprogramacioncitadet > 0)
                        {
                            //Service.DeleteProgramacioncitadet(vwProgramacioncitadet.Idprogramacioncitadet);
                            vwProgramacioncitadet.DataEntityState = DataEntityState.Deleted;
                            if (!gvDetalle.IsFirstRow)
                            {
                                gvDetalle.MovePrev();
                            }
                            ActualizarDetalle();
                        }
                    }
                    break;
            }
        }

        private void ActualizarDetalle()
        {

            gvDetalle.BeginUpdate();
            gvDetalle.RefreshData();
            gvDetalle.EndUpdate();
            gvDetalle.BestFitColumns(true);
        }

        private Programacioncitadet AsignarProgramacioncitadet(VwProgramacioncitadet vwProgramacioncitadet)
        {

            Programacioncitadet programacioncitadet = new Programacioncitadet
            {
                Idprogramacioncitadet = vwProgramacioncitadet.Idprogramacioncitadet,
                Idprogramacioncita = vwProgramacioncitadet.Idprogramacioncita,
                Horaprogramacion = vwProgramacioncitadet.Horaprogramacion,
                Idpersona = null,
                Idestadocita = EstadocitaPorDefecto.Idestadocita,
                Idmotivocita = ArticuloMotivocitaPorDefecto.Idarticulo

            };
            return programacioncitadet;
        }




    }
}
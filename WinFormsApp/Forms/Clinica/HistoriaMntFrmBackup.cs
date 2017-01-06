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
    public partial class HistoriaMntFrmBackup : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public HistoriaFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Historia HistoriaMnt { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public List<VwArticulo> VwArticuloList { get; set; }
        public List<VwHistoriadet> VwHistoriadetList { get; set; }
        public List<VwHistoriadetitem> VwHistoriadetitemList { get; set; }
        public List<VwTipocp> VwTipocpList { get; set; }
        public HistoriaMntFrmBackup(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, HistoriaFrm formParent)
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

        private void HistoriaMntFrmBackup_Load(object sender, EventArgs e)
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
                    HistoriaMnt = new Historia();
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();
                    beClienteTitular.Select();
                    break;
            }
        }

        private void CargarReferencias()
        {
            VwTipocpList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "HISTORIA" && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();

            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            string whereSucursal = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            rIdsucursal.Properties.DataSource = Service.GetAllVwSucursal(whereSucursal, "Nombresucursal");
            rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            rIdsucursal.Properties.ValueMember = "Idsucursal";
            rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            iIdempleado.Properties.DataSource = CacheObjects.VwEmpleadoList.Where(x => x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            iIdempleado.Properties.DisplayMember = "Razonsocial";
            iIdempleado.Properties.ValueMember = "Idempleado";
            iIdempleado.Properties.BestFitMode = BestFitMode.BestFit;

            rSexoTitular.Properties.DataSource = CacheObjects.SexoPersonaList;
            rSexoTitular.Properties.DisplayMember = "DescripcionTipoSexo";
            rSexoTitular.Properties.ValueMember = "TipoSexo";

            rSexoConyugue.Properties.DataSource = CacheObjects.SexoPersonaList;
            rSexoConyugue.Properties.DisplayMember = "DescripcionTipoSexo";
            rSexoConyugue.Properties.ValueMember = "TipoSexo";

            iIdestadocivil.Properties.DataSource = Service.GetAllEstadocivil("idestadocivil");
            iIdestadocivil.Properties.DisplayMember = "Nombreestadocivil";
            iIdestadocivil.Properties.ValueMember = "Idestadocivil";
            iIdestadocivil.Properties.BestFitMode = BestFitMode.BestFit;
        }

        private void TraerDatos()
        {
            try
            {
                HistoriaMnt = Service.GetHistoria(IdEntidadMnt);


                rIdsucursal.EditValue = HistoriaMnt.Idsucursal;
                iIdtipocp.EditValue = HistoriaMnt.Idtipocp;
                rSeriehistoria.EditValue = HistoriaMnt.Seriehistoria;
                rNumerohistoria.EditValue = HistoriaMnt.Numerohistoria;
                iFecharegistro.EditValue = HistoriaMnt.Fecharegistro;
                iIdempleado.EditValue = HistoriaMnt.Idempleado;
                iIdpacientetitular.EditValue = HistoriaMnt.Idpacientetitular;
                iIdestadocivil.EditValue = HistoriaMnt.Idestadocivil;
                iIdpersonaconyugue.EditValue = HistoriaMnt.Idpersonaconyugue;
                iObservacion.EditValue = HistoriaMnt.Observacion;
                iFechanacimiento.EditValue = HistoriaMnt.Fechanacimiento;
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
            gvCitas.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idhistoria = '{0}'", IdEntidadMnt);
            gvCitas.BeginUpdate();

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    VwHistoriadetList = new List<VwHistoriadet>();
                    break;
                case TipoMantenimiento.Modificar:
                    VwHistoriadetList = Service.GetAllVwHistoriadet(where, "fechahistoriadet desc");
                    break;
            }

            gcCitas.DataSource = VwHistoriadetList;
            gvCitas.EndUpdate();
            gvCitas.BestFitColumns(true);
        }

        private bool Guardar()
        {

            if (!Validaciones()) return false;


            HistoriaMnt.Idsucursal = (int?)rIdsucursal.EditValue;
            HistoriaMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            HistoriaMnt.Seriehistoria = rSeriehistoria.Text.Trim();
            HistoriaMnt.Numerohistoria = rNumerohistoria.Text.Trim();
            HistoriaMnt.Fecharegistro = (DateTime)iFecharegistro.EditValue;
            HistoriaMnt.Idempleado = (int)iIdempleado.EditValue;
            HistoriaMnt.Idpacientetitular = (int)iIdpacientetitular.EditValue;
            HistoriaMnt.Idestadocivil = (int)iIdestadocivil.EditValue;
            HistoriaMnt.Idpersonaconyugue = (int?)iIdpersonaconyugue.EditValue;
            HistoriaMnt.Observacion = iObservacion.Text.Trim();
            HistoriaMnt.Fechanacimiento = (DateTime)iFechanacimiento.EditValue;

            switch (TipoMnt)
            {
                case TipoMantenimiento.Nuevo:
                    //PersonaMnt.Createdby = IdUsuario;
                    //PersonaMnt.Creationdate = DateTime.Now;
                    break;
                case TipoMantenimiento.Modificar:
                    //PersonaMnt.Modifiedby = IdUsuario;
                    //PersonaMnt.Lastmodified = DateTime.Now;
                    break;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        IdEntidadMnt = Service.SaveHistoria(HistoriaMnt);
                        HistoriaMnt.Idhistoria = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateHistoria(HistoriaMnt);
                        break;
                }
                Cursor = Cursors.Default;
            }
            catch
            {
                Cursor = Cursors.Default;
                throw;
            }
            return true;
        }

        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpDatos, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

                    HistoriaMnt = null;
                    HistoriaMnt = new Historia();

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

                        HistoriaMnt = null;
                        HistoriaMnt = new Historia();
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
                        HistoriaMnt = null;
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

        private void HistoriaMntFrmBackup_KeyPress(object sender, KeyPressEventArgs e)
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
            iFecharegistro.EditValue = SessionApp.DateServer;
            rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;

            VwTipocp vwTipocpDefecto = VwTipocpList.FirstOrDefault();
            if (vwTipocpDefecto != null)
            {
                iIdtipocp.EditValue = vwTipocpDefecto.Idtipocp;
            }
            beClienteTitular.Select();

            if (SessionApp.EmpleadoSel == null)
            {
                iIdempleado.EditValue = null;
                iIdempleado.Enabled = true;
            }
            else
            {
                iIdempleado.EditValue = SessionApp.EmpleadoSel.Idempleado;
                iIdempleado.Enabled = false;
            }
        }

        private void HistoriaMntFrmBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormParent != null)
            {
                if (SeEliminoObjeto)
                {
                    FormParent.CargarDatosConsulta();
                }
                if (SeGuardoObjeto)
                {
                    FormParent.IdEntidadMnt = IdEntidadMnt;
                    FormParent.CargarDatosConsulta();
                    FormParent.SetFocusIdEntity();
                }
            }
            e.Cancel = false;
        }

        private void bmItemsCita_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            HistoriaCitaMntItemFrm historiaCitaMntItemFrm;
            VwHistoriadet vwHistoriadet;

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwHistoriadet = new VwHistoriadet();
                    vwHistoriadet.Idhistoria = IdEntidadMnt;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    historiaCitaMntItemFrm = new HistoriaCitaMntItemFrm(tipoMantenimientoItem, vwHistoriadet);
                    historiaCitaMntItemFrm.ShowDialog();

                    if (historiaCitaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Historiadet historiadet = AsignarHistoriadet(vwHistoriadet);
                        int idhistoriadet = Service.SaveHistoriadet(historiadet);
                        if (idhistoriadet > 0)
                        {
                            vwHistoriadet.Idhistoriadet = idhistoriadet;
                            VwHistoriadetList.Add(vwHistoriadet);
                            ActualizarDetalleCitas();
                            if (!gvCitas.IsLastRow)
                            {
                                gvCitas.MoveLastVisible();
                                gvCitas.Focus();
                            }
                        }

                    }


                    break;

                case "btnEditItem":
                    if (gvCitas.RowCount == 0)
                    {
                        break;
                    }
                    vwHistoriadet = (VwHistoriadet)gvCitas.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    historiaCitaMntItemFrm = new HistoriaCitaMntItemFrm(tipoMantenimientoItem, vwHistoriadet);
                    historiaCitaMntItemFrm.ShowDialog();

                    if (historiaCitaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Historiadet historiadet = AsignarHistoriadet(vwHistoriadet);
                        if (historiadet.Idhistoriadet > 0)
                        {
                            Service.UpdateHistoriadet(historiadet);
                            ActualizarDetalleCitas();
                        }
                    }


                    break;

                case "btnDelItem":
                    if (gvCitas.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwHistoriadet = (VwHistoriadet)gvCitas.GetFocusedRow();
                        if (vwHistoriadet != null && vwHistoriadet.Idhistoriadet > 0)
                        {
                            Service.DeleteHistoriadet(vwHistoriadet.Idhistoriadet);
                            vwHistoriadet.DataEntityState = DataEntityState.Deleted;
                            if (!gvCitas.IsFirstRow)
                            {
                                gvCitas.MovePrev();
                            }
                            ActualizarDetalleCitas();
                        }
                    }
                    break;
                case "btnAddPlantilla":
                    VwHistoriadet vwHistoriadetCita = (VwHistoriadet)gvCitas.GetFocusedRow();
                    if (vwHistoriadetCita != null)
                    {
                        //HistoriaItemPlantillaFrm historiaItemPlantillaFrm = new HistoriaItemPlantillaFrm(TipoMantenimiento.Nuevo, VwHistoriadetitemList, vwHistoriadetCita, this);
                        //historiaItemPlantillaFrm.ShowDialog();
                    }


                    break;
            }
        }

        private void ActualizarDetalleCitas()
        {

            gvCitas.BeginUpdate();
            gvCitas.RefreshData();
            gvCitas.EndUpdate();
            gvCitas.BestFitColumns(true);
        }

        public void ActualizarDetalleItemsHistoria()
        {

            //gvDetalle.BeginUpdate();
            gvDetalle.RefreshData();
            //gvDetalle.EndUpdate();
            //gvDetalle.BestFitColumns(true);
        }

        private Historiadet AsignarHistoriadet(VwHistoriadet vwHistoriadet)
        {

            Historiadet historiadet = new Historiadet
            {
                Idhistoriadet = vwHistoriadet.Idhistoriadet,
                Idhistoria = vwHistoriadet.Idhistoria,
                Fechahistoriadet = vwHistoriadet.Fechahistoriadet,
                Idprogramacioncitadet = null,
                Idtipohistoria = null
            };
            return historiadet;
        }

        public Historiadetitem AsignarHistoriadetitem(VwHistoriadetitem vwHistoriadetitem)
        {

            Historiadetitem historiadetitem = new Historiadetitem
            {
                Idhistoriadetitem = vwHistoriadetitem.Idhistoriadetitem,
                Idhistoriadet = vwHistoriadetitem.Idhistoriadet,
                Iditemhistoria = vwHistoriadetitem.Iditemhistoria,
                Valoritemhistoria = vwHistoriadetitem.Valoritemhistoria,
                Ordenhistoriadetitem = vwHistoriadetitem.Ordenhistoriadetitem
            };
            return historiadetitem;
        }

        private void bePersonaConyugue_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            BaseMntFrm personaMntFrm;

            switch (e.Button.Index)
            {
                case 0: //Buscar
                    var buscadorPersonaFrm = new BuscadorPersonaFrm();
                    buscadorPersonaFrm.ShowDialog();

                    if (buscadorPersonaFrm.DialogResult == DialogResult.OK &&
                        buscadorPersonaFrm.PersonaSel != null)
                    {
                        iIdpersonaconyugue.EditValue = buscadorPersonaFrm.PersonaSel.Idpersona;
                    }
                    break;
                case 1: //Nuevo registro
                    personaMntFrm = new BaseMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    personaMntFrm.ShowDialog();

                    if (personaMntFrm.DialogResult == DialogResult.OK && personaMntFrm.IdEntidadMnt > 0)
                    {
                        iIdpersonaconyugue.EditValue = personaMntFrm.IdEntidadMnt;
                    }
                    break;
                case 2: //Modificar registro
                    var idPersonaMnt = iIdpersonaconyugue.EditValue;
                    if (idPersonaMnt != null && (int)idPersonaMnt > 0)
                    {
                        personaMntFrm = new BaseMntFrm((int)idPersonaMnt, TipoMantenimiento.Modificar, null, null);
                        personaMntFrm.ShowDialog();
                        if (personaMntFrm.DialogResult == DialogResult.OK && personaMntFrm.IdEntidadMnt > 0)
                        {
                            iIdpersonaconyugue.EditValue = 0;
                            iIdpersonaconyugue.EditValue = personaMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
                case 3: //Limpiar
                    bePersonaConyugue.Text = string.Empty;
                    iIdpersonaconyugue.EditValue = null;
                    break;
            }
        }

        private void iIdtipocp_EditValueChanged(object sender, EventArgs e)
        {
            CargarInfoCorrelativo();
        }

        private void CargarInfoCorrelativo()
        {
            var idTipocp = iIdtipocp.EditValue;
            if (idTipocp != null)
            {
                VwTipocp vwTipocp = Service.GetVwTipocp((int)idTipocp);
                VwTipocpSel = vwTipocp;
                switch (TipoMnt)
                {
                    case TipoMantenimiento.Nuevo:
                        rSeriehistoria.EditValue = vwTipocp.Seriecp;
                        rNumerohistoria.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerohistoria.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerohistoria.TabStop = !vwTipocp.Numeracionauto;
                        break;
                    case TipoMantenimiento.Modificar:
                        rNumerohistoria.EditValue = vwTipocp.Numerocorrelativocp;
                        rNumerohistoria.Properties.ReadOnly = vwTipocp.Numeracionauto;
                        rNumerohistoria.TabStop = !vwTipocp.Numeracionauto;
                        break;
                }
            }
            else
            {
                rSeriehistoria.EditValue = @"0000";
                rNumerohistoria.EditValue = 0;
            }
        }

        private void iIdpacientetitular_EditValueChanged(object sender, EventArgs e)
        {
            var iidClienteTitulaar = iIdpacientetitular.EditValue;
            if (iidClienteTitulaar != null)
            {
                VwSocionegocio vwSocionegocio = Service.GetVwSocionegocio((int)iidClienteTitulaar);
                if (vwSocionegocio != null)
                {
                    beClienteTitular.Text = vwSocionegocio.Razonsocial;
                    rNroDocTitular.EditValue = string.Format("{0} {1}", vwSocionegocio.Abreviaturadocentidad, vwSocionegocio.Nrodocentidadprincipal);
                    rSexoTitular.EditValue = vwSocionegocio.Sexo;
                    rMovil.EditValue = vwSocionegocio.Movil;
                    rTelefono.EditValue = vwSocionegocio.Telefono;
                    rEmailcliente.EditValue = vwSocionegocio.Email;
                    iDireccionfiscal.EditValue = vwSocionegocio.Direccionfiscal;

                }
            }
        }

        private void iIdpersonaconyugue_EditValueChanged(object sender, EventArgs e)
        {
            var idpersonaconyugue = iIdpersonaconyugue.EditValue;
            if (idpersonaconyugue != null)
            {
                VwPersona vwPersona = Service.GetVwPersona((int)idpersonaconyugue);
                if (vwPersona != null)
                {
                    bePersonaConyugue.Text = vwPersona.Razonsocial;
                    rNroDocConyugue.EditValue = string.Format("{0} {1}", vwPersona.Abreviaturadocentidad, vwPersona.Nrodocentidad);
                    rSexoConyugue.EditValue = vwPersona.Sexo;

                }
            }
        }

        private void beClienteTitular_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SocionegocioMntFrm socionegocioMntFrm;
            switch (e.Button.Index)
            {
                case 0: //Buscar
                    BuscadorSocioNegocioFrm buscarSocioNegocioFrm = new BuscadorSocioNegocioFrm();
                    buscarSocioNegocioFrm.ShowDialog();

                    if (buscarSocioNegocioFrm.DialogResult == DialogResult.OK &&
                        buscarSocioNegocioFrm.VwSocionegocioSel != null)
                    {
                        iIdpacientetitular.EditValue = buscarSocioNegocioFrm.VwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        iIdpacientetitular.EditValue = socionegocioMntFrm.IdEntidadMnt;
                    }
                    break;
                case 2: //Modificar registro
                    var idClienteTitular = iIdpacientetitular.EditValue;
                    if (idClienteTitular != null && (int)idClienteTitular > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idClienteTitular, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            iIdpacientetitular.EditValue = socionegocioMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
            }
        }

        private void gvCitas_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            VwHistoriadet vwHistoriadet = (VwHistoriadet)gvCitas.GetFocusedRow();
            if (vwHistoriadet != null)
            {
                VwHistoriadetitemList = null;
                string whereItem = string.Format("idhistoriadet = {0}", vwHistoriadet.Idhistoriadet);
                VwHistoriadetitemList = Service.GetAllVwHistoriadetitem(whereItem, "ordencategoriaitem,ordenhistoriadetitem");
                gvDetalle.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
                gcDetalle.DataSource = VwHistoriadetitemList;
                gvDetalle.BestFitColumns(true);

            }
        }

        private void bmItemHistoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            HistoriaMntItemFrm historiaMntItemFrm;
            VwHistoriadetitem vwHistoriadetitem;

            VwHistoriadet vwHistoriadetSel = (VwHistoriadet)gvCitas.GetFocusedRow();
            if (vwHistoriadetSel == null)
            {
                return;
            }


            switch (e.Item.Name)
            {
                case "btnAddItemHistoria":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show(
                            "Grabe la información",
                            "Atención",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    //Asignar el siguiente item
                    VwHistoriadetitem sgtItem = VwHistoriadetitemList.Where(w => w.DataEntityState != DataEntityState.Deleted)
                        .OrderByDescending(t => t.Ordenhistoriadetitem)
                        .FirstOrDefault();

                    vwHistoriadetitem = new VwHistoriadetitem();
                    vwHistoriadetitem.Idhistoriadet = vwHistoriadetSel.Idhistoriadet;
                    vwHistoriadetitem.Ordenhistoriadetitem = sgtItem == null ? 1 : sgtItem.Ordenhistoriadetitem + 1;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    historiaMntItemFrm = new HistoriaMntItemFrm(tipoMantenimientoItem, vwHistoriadetitem);
                    historiaMntItemFrm.ShowDialog();

                    if (historiaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Historiadetitem historiadet = AsignarHistoriadetitem(vwHistoriadetitem);
                        int idhistoriadetitem = Service.SaveHistoriadetitem(historiadet);
                        if (idhistoriadetitem > 0)
                        {
                            vwHistoriadetitem.Idhistoriadetitem = idhistoriadetitem;
                            VwHistoriadetitemList.Add(vwHistoriadetitem);
                            ActualizarDetalleItemsHistoria();
                            if (!gvDetalle.IsLastRow)
                            {
                                gvDetalle.MoveLastVisible();
                                gvDetalle.Focus();
                            }
                        }

                    }


                    break;

                case "btnEditItemHistoria":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }
                    vwHistoriadetitem = (VwHistoriadetitem)gvDetalle.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    historiaMntItemFrm = new HistoriaMntItemFrm(tipoMantenimientoItem, vwHistoriadetitem);
                    historiaMntItemFrm.ShowDialog();

                    if (historiaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Historiadetitem historiadetitem = AsignarHistoriadetitem(vwHistoriadetitem);
                        if (historiadetitem.Idhistoriadet > 0)
                        {
                            Service.UpdateHistoriadetitem(historiadetitem);
                            ActualizarDetalleItemsHistoria();
                        }
                    }


                    break;

                case "btnDelItemHistoria":
                    if (gvDetalle.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show(
                        "¿Desea eliminar el item seleccionado?",
                        "Eliminar Item",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1))
                    {
                        vwHistoriadetitem = (VwHistoriadetitem)gvDetalle.GetFocusedRow();
                        if (vwHistoriadetitem != null && vwHistoriadetitem.Idhistoriadetitem > 0)
                        {
                            Service.DeleteHistoriadetitem(vwHistoriadetitem.Idhistoriadetitem);
                            vwHistoriadetitem.DataEntityState = DataEntityState.Deleted;
                            if (!gvDetalle.IsFirstRow)
                            {
                                gvDetalle.MovePrev();
                            }
                            ActualizarDetalleItemsHistoria();
                        }
                    }
                    break;
                case "btnAddPlantilla":
                    VwHistoriadet vwHistoriadetCita = (VwHistoriadet)gvCitas.GetFocusedRow();
                    if (vwHistoriadetCita != null)
                    {
                        //HistoriaItemPlantillaFrm historiaItemPlantillaFrm =
                        //    new HistoriaItemPlantillaFrm(
                        //        TipoMantenimiento.Nuevo,
                        //        VwHistoriadetitemList,
                        //        vwHistoriadetCita,
                        //        this);
                        //historiaItemPlantillaFrm.ShowDialog();
                    }


                    break;
            }
        }

        private void gvDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            VwHistoriadetitem vwHistoriadetitemSel = (VwHistoriadetitem) gvDetalle.GetFocusedRow();
            if (vwHistoriadetitemSel == null)
            {
                return;
            }
            gvDetalle.RefreshData();
            switch (e.Column.FieldName)
            {
                case "Valoritemhistoria":
                    Historiadetitem historiadetitem = AsignarHistoriadetitem(vwHistoriadetitemSel);
                    Service.UpdateHistoriadetitem(historiadetitem);
                    ActualizarDetalleItemsHistoria();
                    break;
            }
        }

        private void riMemoValor_EditValueChanged(object sender, EventArgs e)
        {
            //gvDetalle.PostEditor();
            //ActualizarDetalleItemsHistoria();
        }

        private void gcDetalle_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    ColumnView columnView = gcDetalle.FocusedView as ColumnView;
            //    if (columnView != null)
            //        columnView.FocusedRowHandle++;
            //    e.Handled = true;
            //}
        }


    }
}
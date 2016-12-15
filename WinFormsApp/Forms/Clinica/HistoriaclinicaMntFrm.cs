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
    public partial class HistoriaclinicaMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public HistoriaclinicaFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Historiaclinica HistoriaclinicaMnt { get; set; }

        public List<VwArticulo> VwArticuloList { get; set; }
        public List<VwProgramacioncitadet> VwProgramacioncitadetList { get; set; }
        public VwTipocp VwTipocpSel { get; set; }
        public HistoriaclinicaMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, HistoriaclinicaFrm formParent) 
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
            WinFormUtils.SetStyleController(tpDatos, styleController);
            WinFormUtils.SetStyleController(tpAntecedentesNoPatologico, styleController);
            WinFormUtils.SetStyleController(tpAntecedentesPatologicos, styleController);
            WinFormUtils.SetStyleController(tpAntecedentesGinecoobstetricos, styleController);
            WinFormUtils.SetStyleController(tpComentario, styleController);


            WinFormUtils.SetEnterMoveNextControl(tpDatos, true);
            WinFormUtils.SetEnterMoveNextControl(tpAntecedentesNoPatologico, true);
            WinFormUtils.SetEnterMoveNextControl(tpAntecedentesPatologicos, true);
            WinFormUtils.SetEnterMoveNextControl(tpAntecedentesGinecoobstetricos, true);
            WinFormUtils.SetEnterMoveNextControl(tpComentario, true);
            


            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;                       
        }

        private void HistoriaclinicaMntFrm_Load(object sender, EventArgs e)
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
                    HistoriaclinicaMnt = new Historiaclinica();
                    CargarDetalle();
                    break;
                case TipoMantenimiento.Modificar:                    
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();
                    break;
            }           
        }

        private void CargarReferencias()
        {

            VwTipocpList = CacheObjects.VwTipocpList.Where(x => x.Nombretipodocmov == "HISTORIA"
            && x.Idsucursal == SessionApp.SucursalSel.Idsucursal).ToList();

            iIdtipocp.Properties.DataSource = VwTipocpList;
            iIdtipocp.Properties.DisplayMember = "Nombretipocp";
            iIdtipocp.Properties.ValueMember = "Idtipocp";
            iIdtipocp.Properties.BestFitMode = BestFitMode.BestFit;


            iIdestadociviltitular.Properties.DataSource = Service.GetAllEstadocivil("idestadocivil");
            iIdestadociviltitular.Properties.DisplayMember = "Nombreestadocivil";
            iIdestadociviltitular.Properties.ValueMember = "Idestadocivil";
            iIdestadociviltitular.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipociclomenstrual.Properties.DataSource = Service.GetAllTipociclomenstrual("idtipociclomenstrual");
            iIdtipociclomenstrual.Properties.DisplayMember = "Nombretipociclomenstrual";
            iIdtipociclomenstrual.Properties.ValueMember = "Idtipociclomenstrual";
            iIdtipociclomenstrual.Properties.BestFitMode = BestFitMode.BestFit;

            rSexoTitular.Properties.DataSource = CacheObjects.SexoPersonaList;
            rSexoTitular.Properties.DisplayMember = "DescripcionTipoSexo";
            rSexoTitular.Properties.ValueMember = "TipoSexo";

            rSexoConyugue.Properties.DataSource = CacheObjects.SexoPersonaList;
            rSexoConyugue.Properties.DisplayMember = "DescripcionTipoSexo";
            rSexoConyugue.Properties.ValueMember = "TipoSexo";


            iIdregistrador.Properties.DataSource = CacheObjects.VwEmpleadoList;
            iIdregistrador.Properties.DisplayMember = "Razonsocial";
            iIdregistrador.Properties.ValueMember = "Idempleado";
            iIdregistrador.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipociclomenstrual.Properties.DataSource = Service.GetAllTipociclomenstrual();
            iIdtipociclomenstrual.Properties.DisplayMember = "Nombretipociclomenstrual";
            iIdtipociclomenstrual.Properties.ValueMember = "Idtipociclomenstrual";
            iIdtipociclomenstrual.Properties.BestFitMode = BestFitMode.BestFitResizePopup;


            //iIdmedico.Properties.DataSource = CacheObjects.VwEmpleadoList;
            //iIdmedico.Properties.DisplayMember = "Razonsocial";
            //iIdmedico.Properties.ValueMember = "Idempleado";
            //iIdmedico.Properties.BestFitMode = BestFitMode.BestFit;

            //iIdmedico.Properties.DataSource = CacheObjects.VwEmpleadoList;
            //iIdmedico.Properties.DisplayMember = "Razonsocial";
            //iIdmedico.Properties.ValueMember = "Idempleado";
            //iIdmedico.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereSucursal = string.Format("idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            //rIdsucursal.Properties.DataSource = Service.GetAllVwSucursal(whereSucursal, "Nombresucursal"); 
            //rIdsucursal.Properties.DisplayMember = "Nombresucursal";
            //rIdsucursal.Properties.ValueMember = "Idsucursal";
            //rIdsucursal.Properties.BestFitMode = BestFitMode.BestFit;

            //string whereServicio = "esserviciomedico = '1'";
            //VwArticuloList = Service.GetAllVwArticulo(whereServicio, "Nombrearticulo");
            //iIdservicio.Properties.DataSource = VwArticuloList;
            //iIdservicio.Properties.DisplayMember = "Nombrearticulo";
            //iIdservicio.Properties.ValueMember = "Idarticulo";
            //iIdservicio.Properties.BestFitMode = BestFitMode.BestFit;

        }

        public List<VwTipocp> VwTipocpList { get; set; }

        private void TraerDatos()
        {
            try
            {
                HistoriaclinicaMnt = Service.GetHistoriaclinica(IdEntidadMnt);


                iIdtipocp.EditValue = HistoriaclinicaMnt.Idtipocp;
                rSeriehistoria.EditValue = HistoriaclinicaMnt.Seriehistoria;
                rNumerohistoria.EditValue = HistoriaclinicaMnt.Numerohistoria;
                iFecharegistro.EditValue = HistoriaclinicaMnt.Fecharegistro;
                iIdregistrador.EditValue = HistoriaclinicaMnt.Idregistrador;
                iIdclientetitular.EditValue = HistoriaclinicaMnt.Idclientetitular;
                iIdestadociviltitular.EditValue = HistoriaclinicaMnt.Idestadociviltitular;
                iFechanacimientotitular.EditValue = HistoriaclinicaMnt.Fechanacimientotitular;
                iOcupaciontitular.EditValue = HistoriaclinicaMnt.Ocupaciontitular;
                iIdclienteconyugue.EditValue = HistoriaclinicaMnt.Idclienteconyugue;
                iComentario.EditValue = HistoriaclinicaMnt.Comentario;
                iAntecedentesheredofamiliares.EditValue = HistoriaclinicaMnt.Antecedentesheredofamiliares;
                iHabitacion.EditValue = HistoriaclinicaMnt.Habitacion;
                iAlimentacion.EditValue = HistoriaclinicaMnt.Alimentacion;
                iTabaquismo.EditValue = HistoriaclinicaMnt.Tabaquismo;
                iAlcoholismo.EditValue = HistoriaclinicaMnt.Alcoholismo;
                iToxicomanias.EditValue = HistoriaclinicaMnt.Toxicomanias;
                iActividadsedentarismo.EditValue = HistoriaclinicaMnt.Actividadsedentarismo;
                iAlergias.EditValue = HistoriaclinicaMnt.Alergias;
                iPatologias.EditValue = HistoriaclinicaMnt.Patologias;
                iQuirurgicos.EditValue = HistoriaclinicaMnt.Quirurgicos;
                iTraumaticos.EditValue = HistoriaclinicaMnt.Traumaticos;
                iTransfusionales.EditValue = HistoriaclinicaMnt.Transfusionales;
                iFarmacologicos.EditValue = HistoriaclinicaMnt.Farmacologicos;
                iGeneticos.EditValue = HistoriaclinicaMnt.Geneticos;
                iMenarquia.EditValue = HistoriaclinicaMnt.Menarquia;
                iIdtipociclomenstrual.EditValue = HistoriaclinicaMnt.Idtipociclomenstrual;
                iEdadiniciorelacionsexual.EditValue = HistoriaclinicaMnt.Edadiniciorelacionsexual;
                iMetodoanticonceptivo.EditValue = HistoriaclinicaMnt.Metodoanticonceptivo;
                iTiempousometodo.EditValue = HistoriaclinicaMnt.Tiempousometodo;
                iFechaultimaregla.EditValue = HistoriaclinicaMnt.Fechaultimaregla;
                iFechaprobabledeparto.EditValue = HistoriaclinicaMnt.Fechaprobabledeparto;
                iNumerodegestaciones.EditValue = HistoriaclinicaMnt.Numerodegestaciones;
                iNumerodepartos.EditValue = HistoriaclinicaMnt.Numerodepartos;
                iNumerodecesareas.EditValue = HistoriaclinicaMnt.Numerodecesareas;
                iNumerodeabortos.EditValue = HistoriaclinicaMnt.Numerodeabortos;
                iNumerodeparejassexuales.EditValue = HistoriaclinicaMnt.Numerodeparejassexuales;
                iTiempointentoembarazo.EditValue = HistoriaclinicaMnt.Tiempointentoembarazo;
                iTiempodetratamiento.EditValue = HistoriaclinicaMnt.Tiempodetratamiento;

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

            HistoriaclinicaMnt.Idtipocp = (int?)iIdtipocp.EditValue;
            HistoriaclinicaMnt.Seriehistoria = rSeriehistoria.Text.Trim();
            HistoriaclinicaMnt.Numerohistoria = rNumerohistoria.Text.Trim();
            HistoriaclinicaMnt.Fecharegistro = (DateTime)iFecharegistro.EditValue;
            HistoriaclinicaMnt.Idregistrador = (int)iIdregistrador.EditValue;
            HistoriaclinicaMnt.Idclientetitular = (int)iIdclientetitular.EditValue;
            HistoriaclinicaMnt.Idestadociviltitular = (int)iIdestadociviltitular.EditValue;
            HistoriaclinicaMnt.Fechanacimientotitular = (DateTime)iFechanacimientotitular.EditValue;
            HistoriaclinicaMnt.Ocupaciontitular = iOcupaciontitular.Text.Trim();
            HistoriaclinicaMnt.Idclienteconyugue = (int?)iIdclienteconyugue.EditValue;
            HistoriaclinicaMnt.Comentario = iComentario.Text.Trim();
            HistoriaclinicaMnt.Antecedentesheredofamiliares = iAntecedentesheredofamiliares.Text.Trim();
            HistoriaclinicaMnt.Habitacion = iHabitacion.Text.Trim();
            HistoriaclinicaMnt.Alimentacion = iAlimentacion.Text.Trim();
            HistoriaclinicaMnt.Tabaquismo = (bool)iTabaquismo.EditValue;
            HistoriaclinicaMnt.Alcoholismo = (bool)iAlcoholismo.EditValue;
            HistoriaclinicaMnt.Toxicomanias = (bool)iToxicomanias.EditValue;
            HistoriaclinicaMnt.Actividadsedentarismo = iActividadsedentarismo.Text.Trim();
            HistoriaclinicaMnt.Alergias = iAlergias.Text.Trim();
            HistoriaclinicaMnt.Patologias = iPatologias.Text.Trim();
            HistoriaclinicaMnt.Quirurgicos = iQuirurgicos.Text.Trim();
            HistoriaclinicaMnt.Traumaticos = iTraumaticos.Text.Trim();
            HistoriaclinicaMnt.Transfusionales = iTransfusionales.Text.Trim();
            HistoriaclinicaMnt.Farmacologicos = iFarmacologicos.Text.Trim();
            HistoriaclinicaMnt.Geneticos = iGeneticos.Text.Trim();
            HistoriaclinicaMnt.Menarquia = (int)iMenarquia.EditValue;
            HistoriaclinicaMnt.Idtipociclomenstrual = (int?)iIdtipociclomenstrual.EditValue;
            HistoriaclinicaMnt.Edadiniciorelacionsexual = (int)iEdadiniciorelacionsexual.EditValue;
            //HistoriaclinicaMnt.Metodoanticonceptivo = iMetodoanticonceptivo.Text.Trim();
            //HistoriaclinicaMnt.Tiempousometodo = iTiempousometodo.Text.Trim();
            //HistoriaclinicaMnt.Fechaultimaregla = (DateTime?)iFechaultimaregla.EditValue;
            //HistoriaclinicaMnt.Fechaprobabledeparto = (DateTime?)iFechaprobabledeparto.EditValue;
            HistoriaclinicaMnt.Numerodegestaciones = (int)iNumerodegestaciones.EditValue;
            HistoriaclinicaMnt.Numerodepartos = (int)iNumerodepartos.EditValue;
            HistoriaclinicaMnt.Numerodecesareas = (int)iNumerodecesareas.EditValue;
            HistoriaclinicaMnt.Numerodeabortos = (int)iNumerodeabortos.EditValue;
            HistoriaclinicaMnt.Numerodeparejassexuales = (int)iNumerodeparejassexuales.EditValue;
            HistoriaclinicaMnt.Tiempointentoembarazo = iTiempointentoembarazo.Text.Trim();
            HistoriaclinicaMnt.Tiempodetratamiento = iTiempodetratamiento.Text.Trim();

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
                        IdEntidadMnt = Service.SaveHistoriaclinica(HistoriaclinicaMnt);
                        HistoriaclinicaMnt.Idhistoriaclinica = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateHistoriaclinica(HistoriaclinicaMnt);
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
                    TipoMnt =TipoMantenimiento.Nuevo;
                    IdEntidadMnt = 0;
                    pkIdEntidad.EditValue = 0;

                    HistoriaclinicaMnt = null;
                    HistoriaclinicaMnt = new Historiaclinica(); 

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

                        HistoriaclinicaMnt = null;
                        HistoriaclinicaMnt = new Historiaclinica();
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
                        HistoriaclinicaMnt = null;
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
            //iFechaprogramacion.EditValue = SessionApp.DateServer;
            //rIdsucursal.EditValue = SessionApp.SucursalSel.Idsucursal;
            //iFechaprogramacion.Select();

            VwTipocp vwTipocpDefecto = VwTipocpList.FirstOrDefault();
            if (vwTipocpDefecto != null)
            {
                iIdtipocp.EditValue = vwTipocpDefecto.Idtipocp;
            }

            iFecharegistro.EditValue = SessionApp.DateServer;

            beClienteTitular.Select();

            if (SessionApp.EmpleadoSel == null)
            {
                iIdregistrador.EditValue = null;
                iIdregistrador.Enabled = true;
            }
            else
            {
                iIdregistrador.EditValue = SessionApp.EmpleadoSel.Idempleado;
                iIdregistrador.Enabled = false;
            }
        }

        private void HistoriaclinicaMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
                        Programacioncitadet programacioncitadet = AsignarProgramacioncitadet(vwProgramacioncitadet);
                        int idprogramacioncitadet = Service.SaveProgramacioncitadet(programacioncitadet);
                        if (idprogramacioncitadet > 0)
                        {
                            vwProgramacioncitadet.Idprogramacioncitadet = idprogramacioncitadet;
                            VwProgramacioncitadetList.Add(vwProgramacioncitadet);
                            ActualizarDetalle();
                            if (!gvDetalle.IsLastRow)
                            {
                                gvDetalle.MoveLastVisible();
                                gvDetalle.Focus();
                            }
                        }

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
                        Programacioncitadet programacioncitadet = AsignarProgramacioncitadet(vwProgramacioncitadet);
                        if (programacioncitadet.Idprogramacioncitadet > 0)
                        {
                            Service.UpdateProgramacioncitadet(programacioncitadet);
                            ActualizarDetalle();
                        }
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
                            Service.DeleteProgramacioncitadet(vwProgramacioncitadet.Idprogramacioncitadet);
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
                Idpersona = vwProgramacioncitadet.Idpaciente,
                Idestadocita = vwProgramacioncitadet.Idestadocita,
                Idmotivocita = vwProgramacioncitadet.Idmotivocita

            };
            return programacioncitadet;
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
                        iIdclientetitular.EditValue = buscarSocioNegocioFrm.VwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        iIdclientetitular.EditValue = socionegocioMntFrm.IdEntidadMnt;
                    }
                    break;
                case 2: //Modificar registro
                    var idClienteTitular = iIdclientetitular.EditValue;
                    if (idClienteTitular != null && (int)idClienteTitular > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idClienteTitular, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            iIdclientetitular.EditValue = socionegocioMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
            }
        }

        private void iIdclientetitular_EditValueChanged(object sender, EventArgs e)
        {
            var iidClienteTitulaar = iIdclientetitular.EditValue;
            if (iidClienteTitulaar != null)
            {
                VwSocionegocio vwSocionegocio = Service.GetVwSocionegocio((int) iidClienteTitulaar);
                if (vwSocionegocio != null)
                {
                    beClienteTitular.Text = vwSocionegocio.Razonsocial;
                    rNroDocTitular.EditValue = string.Format("{0} {1}", vwSocionegocio.Abreviaturadocentidad, vwSocionegocio.Nrodocentidadprincipal);
                    rSexoTitular.EditValue = vwSocionegocio.Sexo;
                }
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

        private void beConyugue_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        iIdclienteconyugue.EditValue = buscarSocioNegocioFrm.VwSocionegocioSel.Idsocionegocio;
                    }
                    break;
                case 1: //Nuevo registro
                    socionegocioMntFrm = new SocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
                    socionegocioMntFrm.ShowDialog();

                    if (socionegocioMntFrm.DialogResult == DialogResult.OK && socionegocioMntFrm.IdEntidadMnt > 0)
                    {
                        iIdclienteconyugue.EditValue = socionegocioMntFrm.IdEntidadMnt;
                    }
                    break;
                case 2: //Modificar registro
                    var idClienteTitular = iIdclienteconyugue.EditValue;
                    if (idClienteTitular != null && (int)idClienteTitular > 0)
                    {
                        socionegocioMntFrm = new SocionegocioMntFrm((int)idClienteTitular, TipoMantenimiento.Modificar, null, null);
                        socionegocioMntFrm.ShowDialog();
                        if (socionegocioMntFrm.IdEntidadMnt > 0)
                        {
                            iIdclienteconyugue.EditValue = socionegocioMntFrm.IdEntidadMnt;
                        }
                    }
                    break;
                case 3: //Limpiar
                    beConyugue.Text= string.Empty;
                    iIdclienteconyugue.EditValue = null;
                    break;
            }
        }

        private void iIdclienteconyugue_EditValueChanged(object sender, EventArgs e)
        {
            var iidClienteConyugue = iIdclienteconyugue.EditValue;
            if (iidClienteConyugue != null)
            {
                VwSocionegocio vwSocionegocio = Service.GetVwSocionegocio((int)iidClienteConyugue);
                if (vwSocionegocio != null)
                {
                    beConyugue.Text = vwSocionegocio.Razonsocial;
                    rNroDocConyugue.EditValue = string.Format("{0} {1}", vwSocionegocio.Abreviaturadocentidad, vwSocionegocio.Nrodocentidadprincipal);
                    rSexoConyugue.EditValue = vwSocionegocio.Sexo;
                }
            }
        }


    }
}
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
using DevExpress.XtraTab;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class SocionegocioMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public SocionegocioFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();
        public Socionegocio SocionegocioMnt { get; set; }
        public VwSocionegocio VwSocionegocio { get; set; }
        public List<VwPersona> VwPersonaList { get; set; }
        public List<Socionegociocontacto> SocionegociocontactoList { get; set; }
        public List<Tiposocio> TiposocioList { get; set; }
        public List<Tipolista> TipolistaList { get; set; }
        public List<VwSocionegociodireccion> VwSocionegociodireccionList { get; set; }
        public List<VwSocionegociolimitecredito> VwSocionegociolimitecreditoList { get; set; }
        public List<VwSocionegentidadfinanciera> VwSocionegentidadfinancieraList { get; set; }
        public List<VwSocionegocioproyecto> VwSocionegocioproyectoList { get; set; }
        public List<VwSocionegociogarantia> VwSocionegociogarantiaList { get; set; }
        public List<VwSocionegociomarca> VwSocionegociomarcaList { get; set; }
        public List<Estadosocionegocio> EstadosocionegocioList { get; set; }
        public List<Zona> ZonaList { get; set; }
        public List<Rubronegocio> RubronegocioList { get; set; }
        public List<Grupoeconomico> GrupoeconomicoList { get; set; }
        public List<Categoriasocionegocio> CategoriasocionegocioList { get; set; }
        public int IdPaisPersona { get; set; }
        public string TabPageNameMnt { get; set; }
        public int? IdsocionegociocontactoNuevo { get; set; }
        public int? IdsocionegociodireccionNuevo { get; set; }
        public int? IdProyectoSocioNegocioNuevo { get; set; }
        public int? Idempresa { get; set; }
        public int IdPacienteaRegistrar  { get; set; }
        public SocionegocioMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, SocionegocioFrm formParent)
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
            WinFormUtils.SetEnterMoveNextControl(tpDatosGenerales, true);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;
          
        }

        public SocionegocioMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, SocionegocioFrm formParent, int idpacientearegistrar)
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
            WinFormUtils.SetEnterMoveNextControl(tpDatosGenerales, true);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;

            IdPacienteaRegistrar = idpacientearegistrar;

        }


        public SocionegocioMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, SocionegocioFrm formParent, string tabPageNameMnt)
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
            WinFormUtils.SetEnterMoveNextControl(tpDatosGenerales, true);

            _errorProvider = new DXErrorProvider();

            IdUsuario = SessionApp.UsuarioSel.Idusuario;

            //Habilitar y desahabilitar un tab control

            TabPageNameMnt = tabPageNameMnt;
            if (tabPageNameMnt != null)
            {
                XtraTabPage tabPageSelectMnt = null;
                foreach (var control in TcSocioNegocio.Controls)
                {
                    var tabPage = control as XtraTabPage;
                    if (tabPage != null)
                    {
                        if (tabPage.Name != tabPageNameMnt)
                        {
                            tabPage.PageEnabled = false;
                        }
                        else
                        {
                            if (tabPageSelectMnt == null)
                            {
                                tabPageSelectMnt = tabPage;
                            }                            
                        }
                    }
                    TcSocioNegocio.SelectedTabPage = tabPageSelectMnt;
                }
            }
        }



        private void SocionegocioMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            rFecharegistro.EditValue = DateTime.Now;
            iCodigosocio.EditValue = Service.GetSiguienteCodigoSocioNegocio();
            iIdestadosocionegocio.EditValue = 1; //Activo
            iEsactivo.Checked = true;
            iNrodocentidad.EditValue = @"00000000";
            Idempresa = SessionApp.EmpresaSel.Idempresa;

            Zona zona = ZonaList.FirstOrDefault();
            if (zona != null)
            {
                iIdzona.EditValue = zona.Idzona;
            }

            iIdtiposocio.EditValue = 1; //Cliente

            Tipolista tipolista = TipolistaList.FirstOrDefault();
            if (tipolista != null)
            {
                iIdtipolista.EditValue = tipolista.Idtipolista;
            }


            Rubronegocio rubronegocio = RubronegocioList.FirstOrDefault();
            if (rubronegocio != null)
            {
                iIdrubronegocio.EditValue = rubronegocio.Idrubronegocio;
            }

            Categoriasocionegocio categoriasocionegocio = CategoriasocionegocioList.FirstOrDefault();
            if (categoriasocionegocio != null)
            {
                iIdcategoriaproveedor.EditValue = categoriasocionegocio.Idcategoriasocionegocio;
            }

            eDiavisitasemana.EditValue = 0;//ninguno

            iIncluyeigvitems.Checked = true;
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
                    SocionegocioMnt = new Socionegocio();
                    CargarDetalle();
                    rFecharegistro.Select();
                    CargarPacienteARegistrar();

                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();

                    break;
            }
            iIdtiposocio.Focus();
        }

        private void CargarPacienteARegistrar()
        {
            //Cargar el paciente a registrar
            if (IdPacienteaRegistrar > 0)
            {
                iIdpersona.EditValue = IdPacienteaRegistrar;
            }

        }

        private void CargarReferencias()
        {
            VwPersonaList = Service.GetAllVwPersona("razonsocial");

            rIdtipodocent.Properties.DataSource = CacheObjects.TipodocentidadList;
            rIdtipodocent.Properties.DisplayMember = "Nombretipodocentidad";
            rIdtipodocent.Properties.ValueMember = "Idtipodocent";
            rIdtipodocent.Properties.BestFitMode = BestFitMode.BestFit;

            TiposocioList = Service.GetAllTiposocio("nombretiposocio");
            iIdtiposocio.Properties.DataSource = TiposocioList;
            iIdtiposocio.Properties.DisplayMember = "Nombretiposocio";
            iIdtiposocio.Properties.ValueMember = "Idtiposocio";
            iIdtiposocio.Properties.BestFitMode = BestFitMode.BestFit;

            TipolistaList = Service.GetAllTipolista("nombretipolista");
            iIdtipolista.Properties.DataSource = TipolistaList;
            iIdtipolista.Properties.DisplayMember = "Nombretipolista";
            iIdtipolista.Properties.ValueMember = "Idtipolista";
            iIdtipolista.Properties.BestFitMode = BestFitMode.BestFit;

            RubronegocioList = Service.GetAllRubronegocio("Nombrerubronegocio");
            iIdrubronegocio.Properties.DataSource = RubronegocioList;
            iIdrubronegocio.Properties.DisplayMember = "Nombrerubronegocio";
            iIdrubronegocio.Properties.ValueMember = "Idrubronegocio";
            iIdrubronegocio.Properties.BestFitMode = BestFitMode.BestFit;

            GrupoeconomicoList = Service.GetAllGrupoeconomico("Nombregrupoeconomico");
            iIdgrupoeconomico.Properties.DataSource = GrupoeconomicoList;
            iIdgrupoeconomico.Properties.DisplayMember = "Nombregrupoeconomico";
            iIdgrupoeconomico.Properties.ValueMember = "Idgrupoeconomico";
            iIdgrupoeconomico.Properties.BestFitMode = BestFitMode.BestFit;

            CategoriasocionegocioList = Service.GetAllCategoriasocionegocio("Nombrecategoriasocionegoio");
            iIdcategoriaproveedor.Properties.DataSource = CategoriasocionegocioList;
            iIdcategoriaproveedor.Properties.DisplayMember = "Nombrecategoriasocionegoio";
            iIdcategoriaproveedor.Properties.ValueMember = "Idcategoriasocionegocio";
            iIdcategoriaproveedor.Properties.BestFitMode = BestFitMode.BestFit;

            ZonaList = Service.GetAllZona("Nombrezona");
            iIdzona.Properties.DataSource = ZonaList;
            iIdzona.Properties.DisplayMember = "Nombrezona";
            iIdzona.Properties.ValueMember = "Idzona";
            iIdzona.Properties.BestFitMode = BestFitMode.BestFit;

            //EstadosocionegocioList = CacheObjects.EstadosocionegocioList;
            EstadosocionegocioList = Service.GetAllEstadosocionegocio("Nombreestadosocionegocio");
            iIdestadosocionegocio.Properties.DataSource = EstadosocionegocioList;
            iIdestadosocionegocio.Properties.DisplayMember = "Nombreestadosocionegocio";
            iIdestadosocionegocio.Properties.ValueMember = "Idestadosocionegocio";
            iIdestadosocionegocio.Properties.BestFitMode = BestFitMode.BestFit;


            eDiavisitasemana.Properties.DataSource = CacheObjects.DiaSemanaList;
            eDiavisitasemana.Properties.DisplayMember = "NombreDiaSemana";
            eDiavisitasemana.Properties.ValueMember = "IdDiaSemana";

            iIdvendedor.Properties.DataSource = CacheObjects.VwEmpleadoList.Where(x=>x.Idempresa == SessionApp.EmpresaSel.Idempresa).ToList();
            iIdvendedor.Properties.DisplayMember = "Razonsocial";
            iIdvendedor.Properties.ValueMember = "Idempleado";
            iIdvendedor.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {
                SocionegocioMnt = Service.GetSocionegocio(IdEntidadMnt);

                iIdpersona.EditValue = SocionegocioMnt.Idpersona;
                iIdtiposocio.EditValue = SocionegocioMnt.Idtiposocio;
                iCodigosocio.EditValue = SocionegocioMnt.Codigosocio;
                rFecharegistro.EditValue = SocionegocioMnt.Fecharegistro;
                iNrodocentidad.EditValue = SocionegocioMnt.Nrodocentidad;
                iIdtipocondicion.EditValue = SocionegocioMnt.Idtipocondicion;
                iIdtipolista.EditValue = SocionegocioMnt.Idtipolista;
                iEsagenteretenedor.EditValue = SocionegocioMnt.Esagenteretenedor;
                iEsactivo.EditValue = SocionegocioMnt.Esactivo;
                nPordescuentototal.EditValue = SocionegocioMnt.Pordescuentototal;
                iComentario.EditValue = SocionegocioMnt.Comentario;
                iIncluyeigvitems.EditValue = SocionegocioMnt.Incluyeimpuestoitems;
                iSujetoadetraccion.EditValue = SocionegocioMnt.Sujetoadetraccion;

                iFechafundacion.EditValue = SocionegocioMnt.Fechafundacion;
                iPaginaweb.EditValue = SocionegocioMnt.Paginaweb;
                iFechaaniversario.EditValue = SocionegocioMnt.Fechaaniversario;
                iIdrubronegocio.EditValue = SocionegocioMnt.Idrubronegocio;
                iIdgrupoeconomico.EditValue = SocionegocioMnt.Idgrupoeconomico;
                iIdcategoriaproveedor.EditValue = SocionegocioMnt.Idcategoriaproveedor;
                iEsagentepercepcion.EditValue = SocionegocioMnt.Esagentepercepcion;
                iIdzona.EditValue = SocionegocioMnt.Idzona;
                eSecuenciareparto.EditValue = SocionegocioMnt.Secuenciareparto;
                eDiavisitasemana.EditValue = SocionegocioMnt.Diavisitasemana;
                eFrecuenciavisita.EditValue = SocionegocioMnt.Frecuenciavisita;
                iIdestadosocionegocio.EditValue = SocionegocioMnt.Idestadosocionegocio;

                iIniciosuspension.EditValue = SocionegocioMnt.Iniciosuspension;
                iFinsuspension.EditValue = SocionegocioMnt.Finsuspension;
                iMotivosuspension.EditValue = SocionegocioMnt.Motivosuspension;
                iIdvendedor.EditValue = SocionegocioMnt.Idvendedor;
                Idempresa = SocionegocioMnt.Idempresa;
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
            CargarContactos();
            CargarDirecciones();
            CargarLimitesCredito();
            CargarInfobancaria();
            CargarProyectos();
            CargarGarantias();
            CargarMarcas();
        }
        private void CargarContactos()
        {
            gvContactos.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idsocionegocio = '{0}'", IdEntidadMnt);
            gcContactos.BeginUpdate();
            SocionegociocontactoList = Service.GetAllSocionegociocontacto(where, "idsocionegociocontacto");
            gcContactos.DataSource = SocionegociocontactoList;
            gcContactos.EndUpdate();
            gvContactos.BestFitColumns(true);
        }
        private void CargarDirecciones()
        {
            gvDireccion.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idsocionegocio = '{0}'", IdEntidadMnt);
            gcDireccion.BeginUpdate();
            VwSocionegociodireccionList = Service.GetAllVwSocionegociodireccion(where, "idsocionegociodireccion");
            gcDireccion.DataSource = VwSocionegociodireccionList;
            gcDireccion.EndUpdate();
            gvDireccion.BestFitColumns(true);
        }
        private void CargarLimitesCredito()
        {
            gvLimite.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idsocionegocio = '{0}'", IdEntidadMnt);
            gcLimite.BeginUpdate();
            VwSocionegociolimitecreditoList = Service.GetAllVwSocionegociolimitecredito(where, "idsocionegociolimitecredito");
            gcLimite.DataSource = VwSocionegociolimitecreditoList;
            gcLimite.EndUpdate();
            gvLimite.BestFitColumns(true);
        }
        private void CargarInfobancaria()
        {
            gvInfoBancaria.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idsocionegocio = '{0}'", IdEntidadMnt);
            gvInfoBancaria.BeginUpdate();
            VwSocionegentidadfinancieraList = Service.GetAllVwSocionegentidadfinanciera(where, "idsocionegentidadfinanciera");
            gcInfoBancaria.DataSource = VwSocionegentidadfinancieraList;
            gvInfoBancaria.EndUpdate();
            gvInfoBancaria.BestFitColumns(true);
        }
        private void CargarProyectos()
        {
            gvProyectos.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idsocionegocio = '{0}' and idempresa = {1} ", IdEntidadMnt, SessionApp.EmpresaSel.Idempresa);
            gvProyectos.BeginUpdate();
            VwSocionegocioproyectoList = Service.GetAllVwSocionegocioproyecto(where, "idsocionegocioproyecto");
            gcProyectos.DataSource = VwSocionegocioproyectoList;
            gvProyectos.EndUpdate();
            gvProyectos.BestFitColumns(true);
        }
        private void CargarGarantias()
        {
            gvGarantia.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idsocionegocio = '{0}'", IdEntidadMnt);
            gvGarantia.BeginUpdate();
            VwSocionegociogarantiaList = Service.GetAllVwSocionegociogarantia(where, "idsocionegociogarantia");
            gcGarantia.DataSource = VwSocionegociogarantiaList;
            gvGarantia.EndUpdate();
            gvGarantia.BestFitColumns(true);
        }
        private void CargarMarcas()
        {
            gvMarca.ActiveFilterCriteria = new BinaryOperator("DataEntityState", DataEntityState.Deleted, BinaryOperatorType.NotEqual);
            string where = string.Format("idsocionegocio = '{0}'", IdEntidadMnt);
            gvMarca.BeginUpdate();
            VwSocionegociomarcaList = Service.GetAllVwSocionegociomarca(where, "idsocionegociomarca");
            gcMarca.DataSource = VwSocionegociomarcaList;
            gvMarca.EndUpdate();
            gvMarca.BestFitColumns(true);
        }
        public bool Guardar()
        {

            if (!Validaciones()) return false;

            SocionegocioMnt.Idpersona = (int)iIdpersona.EditValue;
            SocionegocioMnt.Idtiposocio = (int?)iIdtiposocio.EditValue;
            SocionegocioMnt.Codigosocio = iCodigosocio.Text.Trim();
            SocionegocioMnt.Fecharegistro = (DateTime)rFecharegistro.EditValue;
            SocionegocioMnt.Nrodocentidad = iNrodocentidad.Text.Trim();
            SocionegocioMnt.Idtipocondicion = (int)iIdtipocondicion.EditValue;
            SocionegocioMnt.Idtipolista = (int?)iIdtipolista.EditValue;
            SocionegocioMnt.Esagenteretenedor = (bool)iEsagenteretenedor.EditValue;
            SocionegocioMnt.Esactivo = (bool)iEsactivo.EditValue;
            SocionegocioMnt.Pordescuentototal = (decimal)nPordescuentototal.EditValue;
            SocionegocioMnt.Comentario = iComentario.Text.Trim();
            SocionegocioMnt.Incluyeimpuestoitems = (bool)iIncluyeigvitems.EditValue;
            SocionegocioMnt.Sujetoadetraccion = (bool)iSujetoadetraccion.EditValue;

            SocionegocioMnt.Fechafundacion = (DateTime?)iFechafundacion.EditValue;
            SocionegocioMnt.Paginaweb = iPaginaweb.Text.Trim();
            SocionegocioMnt.Fechaaniversario = (DateTime?)iFechaaniversario.EditValue;
            SocionegocioMnt.Idrubronegocio = (int?)iIdrubronegocio.EditValue;
            SocionegocioMnt.Idgrupoeconomico = (int?)iIdgrupoeconomico.EditValue;
            SocionegocioMnt.Idcategoriaproveedor = (int?)iIdcategoriaproveedor.EditValue;
            SocionegocioMnt.Esagentepercepcion = (bool)iEsagentepercepcion.EditValue;
            SocionegocioMnt.Idzona = (int?)iIdzona.EditValue;
            SocionegocioMnt.Secuenciareparto = (int)eSecuenciareparto.EditValue;
            SocionegocioMnt.Diavisitasemana = (int)eDiavisitasemana.EditValue;
            SocionegocioMnt.Frecuenciavisita = (int)eFrecuenciavisita.EditValue;
            SocionegocioMnt.Idestadosocionegocio = (int?)iIdestadosocionegocio.EditValue;

            SocionegocioMnt.Iniciosuspension = (DateTime?)iIniciosuspension.EditValue;
            SocionegocioMnt.Finsuspension = (DateTime?)iFinsuspension.EditValue;
            SocionegocioMnt.Motivosuspension = iMotivosuspension.Text.Trim();
            SocionegocioMnt.Idvendedor = (int?)iIdvendedor.EditValue;
            SocionegocioMnt.Idempresa = Idempresa;

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
                        IdEntidadMnt = Service.SaveSocionegocio(SocionegocioMnt);
                        SocionegocioMnt.Idsocionegocio = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        VwSocionegocio = Service.GetVwSocionegocio(IdEntidadMnt);
                        if (IdEntidadMnt > 0)
                        {
                            GuardarProyectoPorDefecto(IdEntidadMnt);

                            //Guardar Direccion de persona, guardar y cargar
                            if (gvDireccion.RowCount == 1)
                            {
                                VwSocionegociodireccion vwSocionegociodireccionPersoma = (VwSocionegociodireccion)gvDireccion.GetFocusedRow();
                                Socionegociodireccion socionegociodireccionPersona = AsignarSocioNegocioDireccionMnt(vwSocionegociodireccionPersoma);
                                int idsocionegociodireccion = Service.SaveSocionegociodireccion(socionegociodireccionPersona);
                                if (idsocionegociodireccion > 0)
                                {
                                    vwSocionegociodireccionPersoma.Idsocionegociodireccion = idsocionegociodireccion;
                                    gvDireccion.RefreshData();
                                    gvDireccion.BestFitColumns(true);
                                }
                            }
                        }
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateSocionegocio(SocionegocioMnt);
                        VwSocionegocio = Service.GetVwSocionegocio(IdEntidadMnt);
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
        private void GuardarProyectoPorDefecto(int idSocioNegocio)
        {
            long cantidadDeProyecto = Service.CountSocionegocioproyecto(x => x.Idsocionegocio == idSocioNegocio);
            if (cantidadDeProyecto == 0)
            {
                if (SessionApp.EmpresaSel.Idproyectopordefecto != null)
                {
                    Socionegocioproyecto socionegocioproyectoPorDefecto = new Socionegocioproyecto();
                    socionegocioproyectoPorDefecto.Idsocionegocio = idSocioNegocio;
                    socionegocioproyectoPorDefecto.Idproyecto = (int)SessionApp.EmpresaSel.Idproyectopordefecto;
                    socionegocioproyectoPorDefecto.Proyectopordefecto = true;

                    int idsocionegocioproyecto = Service.SaveSocionegocioproyecto(socionegocioproyectoPorDefecto);
                    if (idsocionegocioproyecto > 0)
                    {
                        CargarProyectos();
                    }
                }
            }
        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpDatosGenerales, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (Service.CodigoSocioNegocioExiste(iCodigosocio.Text.Trim()) && TipoMnt == TipoMantenimiento.Nuevo)
            {
                iCodigosocio.EditValue = Service.GetSiguienteCodigoSocioNegocio();
            }

            //int idPersona = TipoMnt == TipoMantenimiento.Nuevo ? 0 : IdEntidadMnt;

            //if (Service.NroDocumentoPersonaExiste(iNrodocentidad.Text.Trim(), idPersona))
            //{
            //    XtraMessageBox.Show("Número de documento ya existe.", "Documento de identidad", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    iNrodocentidad.Focus();
            //    return false;
            //}

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
                        Service.DeleteSocionegocio(IdEntidadMnt);
                        SeEliminoObjeto = true;
                        DialogResult = DialogResult.OK;
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

                    SocionegocioMnt = null;
                    SocionegocioMnt = new Socionegocio();

                    btnGrabar.Enabled = true;
                    btnGrabarCerrar.Enabled = true;
                    btnGrabarNuevo.Enabled = true;

                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;

                    ValoresPorDefecto();

                    if (Permisos.Nuevo)
                        CamposSoloLectura(false);
                    break;

                case "btnGrabar":
                    if (Guardar())
                    {
                        SeGuardoObjeto = true;
                        //btnGrabar.Enabled = false;
                        //btnGrabarCerrar.Enabled = false;
                        btnGrabarNuevo.Enabled = false;

                        if (IdEntidadMnt > 0)
                        {
                            TipoMnt = TipoMantenimiento.Modificar;
                        }

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
                        DialogResult = DialogResult.OK;
                    }
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
                        CargarDetalle();
                    }
                    break;
                case "btnCerrar":
                    if (SeGuardoObjeto)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        SocionegocioMnt = null;
                        DialogResult = DialogResult.OK;
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
        private void SocionegocioMntFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)(Keys.Enter))
            //{
            //    e.Handled = true;
            //    SendKeys.Send("{TAB}");
            //}
        }
        private void LimpiarCampos()
        {
            WinFormUtils.ClearFields(this);
        }
        private void CamposSoloLectura(bool readOnly)
        {
            WinFormUtils.ReadOnlyFields(this, readOnly);
        }
        private void SocionegocioMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void bmItemsDatoContacto_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            TipoMantenimiento tipoMantenimientoItem;
            SocionegocioContactoMntItemFrm socionegocioContactoMntItemFrm;
            Socionegociocontacto socionegociocontactoItemMnt;

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    socionegociocontactoItemMnt = new Socionegociocontacto();
                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    socionegocioContactoMntItemFrm = new SocionegocioContactoMntItemFrm(tipoMantenimientoItem, socionegociocontactoItemMnt);
                    socionegocioContactoMntItemFrm.ShowDialog();

                    if (socionegocioContactoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        var socionegociocontacto = AsignarSocioNegocioContactoMnt(socionegociocontactoItemMnt);
                        int idSocioNegocioContacto = Service.SaveSocionegociocontacto(socionegociocontacto);
                        if (idSocioNegocioContacto > 0)
                        {
                            socionegociocontactoItemMnt.Idsocionegociocontacto = idSocioNegocioContacto;
                            SocionegociocontactoList.Add(socionegociocontactoItemMnt);
                            ActualizarDetalleContactos();
                            if (!gvContactos.IsLastRow)
                            {
                                gvContactos.MoveLastVisible();
                                gvContactos.Focus();
                            }

                            //Asignar el contacto nuevo
                            if (TabPageNameMnt != null && IdsocionegociocontactoNuevo == null)
                            {
                                IdsocionegociocontactoNuevo = idSocioNegocioContacto;
                            }
                            else
                            {
                                IdsocionegociocontactoNuevo = null;
                            }
                        }

                    }


                    break;

                case "btnEditDato":
                    if (gvContactos.RowCount == 0)
                    {
                        break;
                    }
                    socionegociocontactoItemMnt = (Socionegociocontacto)gvContactos.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    socionegocioContactoMntItemFrm = new SocionegocioContactoMntItemFrm(tipoMantenimientoItem, socionegociocontactoItemMnt);
                    socionegocioContactoMntItemFrm.ShowDialog();

                    if (socionegocioContactoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        var socionegociocontacto = AsignarSocioNegocioContactoMnt(socionegociocontactoItemMnt);
                        if (socionegociocontacto.Idsocionegociocontacto > 0)
                        {
                            Service.UpdateSocionegociocontacto(socionegociocontacto);
                            ActualizarDetalleContactos();
                        }
                    }


                    break;

                case "btnDelItem":
                    if (gvContactos.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        socionegociocontactoItemMnt = (Socionegociocontacto)gvContactos.GetFocusedRow();
                        if (socionegociocontactoItemMnt.Idsocionegociocontacto > 0)
                        {
                            Service.DeleteSocionegociocontacto(socionegociocontactoItemMnt.Idsocionegociocontacto);
                            socionegociocontactoItemMnt.DataEntityState = DataEntityState.Deleted;
                            if (!gvContactos.IsFirstRow)
                            {
                                gvContactos.MovePrev();
                            }
                            ActualizarDetalleContactos();
                        }
                    }
                    break;
            }
        }
        private Socionegociocontacto AsignarSocioNegocioContactoMnt(Socionegociocontacto socionegociocontactoItemMnt)
        {
            Socionegociocontacto socionegociocontacto = new Socionegociocontacto();
            socionegociocontacto.Idsocionegociocontacto = socionegociocontactoItemMnt.Idsocionegociocontacto;
            socionegociocontacto.Idsocionegocio = IdEntidadMnt;
            socionegociocontacto.Nombrecontacto = socionegociocontactoItemMnt.Nombrecontacto;
            socionegociocontacto.Area = socionegociocontactoItemMnt.Area;
            socionegociocontacto.Direccion = socionegociocontactoItemMnt.Direccion;
            socionegociocontacto.Telefono = socionegociocontactoItemMnt.Telefono;
            socionegociocontacto.Movil = socionegociocontactoItemMnt.Movil;
            socionegociocontacto.Email = socionegociocontactoItemMnt.Email;
            socionegociocontacto.Observaciones = socionegociocontactoItemMnt.Observaciones;
            socionegociocontacto.Cargo = socionegociocontactoItemMnt.Cargo;
            socionegociocontacto.Fechanacimiento = socionegociocontactoItemMnt.Fechanacimiento;
            socionegociocontacto.Fechaaniversario = socionegociocontactoItemMnt.Fechaaniversario;
            socionegociocontacto.Nombreconyugue = socionegociocontactoItemMnt.Nombreconyugue;
            socionegociocontacto.Foto = socionegociocontactoItemMnt.Foto;
            socionegociocontacto.Numeroanexo = socionegociocontactoItemMnt.Numeroanexo;
            return socionegociocontacto;
        }
        private void ActualizarDetalleContactos()
        {
            gcContactos.BeginUpdate();
            gvContactos.RefreshData();
            gcContactos.EndUpdate();
            gvContactos.BestFitColumns(true);
        }
        private void ActualizarDetalleDireccion()
        {
            gcDireccion.BeginUpdate();
            gvDireccion.RefreshData();
            gcDireccion.EndUpdate();
            gvDireccion.BestFitColumns(true);
        }
        private void ActualizarLimitesCredito()
        {
            gcLimite.BeginUpdate();
            gvLimite.RefreshData();
            gcLimite.EndUpdate();
            gvLimite.BestFitColumns(true);
        }
        private void ActualizarGarantias()
        {
            gcGarantia.BeginUpdate();
            gvGarantia.RefreshData();
            gcGarantia.EndUpdate();
            gvGarantia.BestFitColumns(true);
        }
        private void ActualizarMarcas()
        {
            gcMarca.BeginUpdate();
            gvMarca.RefreshData();
            gcMarca.EndUpdate();
            gvGarantia.BestFitColumns(true);
        }
        private void iIdpersona_EditValueChanged(object sender, EventArgs e)
        {
            var idPersona = iIdpersona.EditValue;
            if (idPersona == null || (int)idPersona <= 0) return;

            VwPersona vWpersonaSel = Service.GetVwPersona(((int)idPersona));
            if (vWpersonaSel != null)
            {
                //Cargar datos a controles
                bePersona.Text = vWpersonaSel.Razonsocial.Trim();
                iIdpersona.EditValue = vWpersonaSel.Idpersona;
                rIdtipodocent.EditValue = vWpersonaSel.Idtipodocent;
                rNroDocPersona.EditValue = vWpersonaSel.Nrodocentidad;
                iNrodocentidad.EditValue = vWpersonaSel.Nrodocentidad2;

                IdPaisPersona = vWpersonaSel.Idpais;

                if (TipoMnt == TipoMantenimiento.Nuevo)
                {
                    VwSocionegociodireccion vwSocionegociodireccion = new VwSocionegociodireccion();
                    vwSocionegociodireccion.Idsocionegociodireccion = 0;
                    vwSocionegociodireccion.Idsocionegocio = IdEntidadMnt;
                    vwSocionegociodireccion.Iddistrito = vWpersonaSel.Iddistrito;
                    vwSocionegociodireccion.Nombreubigeo = vWpersonaSel.Nombreubigeo;
                    vwSocionegociodireccion.Direccionsocionegocio = vWpersonaSel.Direccionfiscal;
                    vwSocionegociodireccion.Referencia = vWpersonaSel.Referencia;
                    vwSocionegociodireccion.Principal = true;
                    vwSocionegociodireccion.Idpais = vWpersonaSel.Idpais;
                    vwSocionegociodireccion.Nombrepais = vWpersonaSel.Nombrepais;
                    vwSocionegociodireccion.Tipolocal = string.Empty;
                    vwSocionegociodireccion.DataEntityState = DataEntityState.Added;
                    
                    VwSocionegociodireccionList.Add(vwSocionegociodireccion);

                    gvDireccion.RefreshData();
                    gvDireccion.BestFitColumns(true);
                }
            }
        }
        private void bePersona_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        //Asignar al edit value del campo id foraneo
                        if (TipoMnt == TipoMantenimiento.Nuevo)
                        {
                            VwSocionegociodireccionList.Clear();
                        }

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
            }
        }
        private void bmDirecciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            TipoMantenimiento tipoMantenimientoItem;
            SocionegocioDireccionMntItemFrm socionegocioDireccionMntItemFrm;
            VwSocionegociodireccion vwSocionegociodireccion;

            switch (e.Item.Name)
            {
                case "btnAddDireccion":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwSocionegociodireccion = new VwSocionegociodireccion();
                    vwSocionegociodireccion.Idsocionegocio = IdEntidadMnt;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    socionegocioDireccionMntItemFrm = new SocionegocioDireccionMntItemFrm(tipoMantenimientoItem, vwSocionegociodireccion);
                    socionegocioDireccionMntItemFrm.ShowDialog();

                    if (socionegocioDireccionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegociodireccion socionegociodireccion = AsignarSocioNegocioDireccionMnt(vwSocionegociodireccion);
                        int idsocionegociodireccion = Service.SaveSocionegociodireccion(socionegociodireccion);
                        if (idsocionegociodireccion > 0)
                        {
                            vwSocionegociodireccion.Idsocionegociodireccion = idsocionegociodireccion;
                            VwSocionegociodireccionList.Add(vwSocionegociodireccion);
                            ActualizarDetalleDireccion();
                            if (!gvDireccion.IsLastRow)
                            {
                                gvDireccion.MoveLastVisible();
                                gvDireccion.Focus();
                            }

                            //Asignar la nueva dirección
                            if (TabPageNameMnt != null && IdsocionegociodireccionNuevo == null)
                            {
                                IdsocionegociodireccionNuevo = idsocionegociodireccion;
                            }
                            else
                            {
                                IdsocionegociodireccionNuevo = null;
                            }


                        }

                    }


                    break;

                case "btnEditDireccion":
                    if (gvDireccion.RowCount == 0)
                    {
                        break;
                    }
                    vwSocionegociodireccion = (VwSocionegociodireccion)gvDireccion.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    socionegocioDireccionMntItemFrm = new SocionegocioDireccionMntItemFrm(tipoMantenimientoItem, vwSocionegociodireccion);
                    socionegocioDireccionMntItemFrm.ShowDialog();

                    if (socionegocioDireccionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegociodireccion socionegociodireccion = AsignarSocioNegocioDireccionMnt(vwSocionegociodireccion);
                        if (socionegociodireccion.Idsocionegociodireccion > 0)
                        {
                            Service.UpdateSocionegociodireccion(socionegociodireccion);
                            ActualizarDetalleDireccion();
                        }
                    }


                    break;

                case "btnDelDireccion":
                    if (gvDireccion.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwSocionegociodireccion = (VwSocionegociodireccion)gvDireccion.GetFocusedRow();
                        if (vwSocionegociodireccion.Idsocionegociodireccion > 0)
                        {
                            Service.DeleteSocionegociodireccion(vwSocionegociodireccion.Idsocionegociodireccion);
                            vwSocionegociodireccion.DataEntityState = DataEntityState.Deleted;
                            if (!gvDireccion.IsFirstRow)
                            {
                                gvDireccion.MovePrev();
                            }
                            ActualizarDetalleDireccion();
                        }
                    }
                    break;
            }
        }
        private Socionegociodireccion AsignarSocioNegocioDireccionMnt(VwSocionegociodireccion vwSocionegociodireccion)
        {
            Socionegociodireccion socionegociodireccion = new Socionegociodireccion();
            socionegociodireccion.Idsocionegociodireccion = vwSocionegociodireccion.Idsocionegociodireccion;
            socionegociodireccion.Idsocionegocio = IdEntidadMnt;
            socionegociodireccion.Iddistrito = vwSocionegociodireccion.Iddistrito;
            socionegociodireccion.Direccionsocionegocio = vwSocionegociodireccion.Direccionsocionegocio;
            socionegociodireccion.Referencia = vwSocionegociodireccion.Referencia;
            socionegociodireccion.Principal = vwSocionegociodireccion.Principal;
            socionegociodireccion.Idpais = vwSocionegociodireccion.Idpais;
            socionegociodireccion.Tipolocal = vwSocionegociodireccion.Tipolocal;
            return socionegociodireccion;
        }
        private void bmLimiteCredito_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            TipoMantenimiento tipoMantenimientoItem;
            SocionegocioLimiteCreditoMntItemFrm socionegocioLimiteCreditoMntItemFrm;
            VwSocionegociolimitecredito vwSocionegociolimitecredito;

            switch (e.Item.Name)
            {
                case "btnAddLimite":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwSocionegociolimitecredito = new VwSocionegociolimitecredito();
                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    socionegocioLimiteCreditoMntItemFrm = new SocionegocioLimiteCreditoMntItemFrm(tipoMantenimientoItem, vwSocionegociolimitecredito);
                    socionegocioLimiteCreditoMntItemFrm.ShowDialog();

                    if (socionegocioLimiteCreditoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegociolimitecredito socionegociolimitecredito = AsignarSocioNegocioLimiteMnt(vwSocionegociolimitecredito);
                        int idsocionegociolimitecredito = Service.SaveSocionegociolimitecredito(socionegociolimitecredito);
                        if (idsocionegociolimitecredito > 0)
                        {
                            vwSocionegociolimitecredito.Idsocionegociolimitecredito = idsocionegociolimitecredito;
                            VwSocionegociolimitecreditoList.Add(vwSocionegociolimitecredito);
                            ActualizarLimitesCredito();
                            if (!gvLimite.IsLastRow)
                            {
                                gvLimite.MoveLastVisible();
                                gvLimite.Focus();
                            }
                        }

                    }


                    break;

                case "btnEditLimite":
                    if (gvLimite.RowCount == 0)
                    {
                        break;
                    }
                    vwSocionegociolimitecredito = (VwSocionegociolimitecredito)gvLimite.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    socionegocioLimiteCreditoMntItemFrm = new SocionegocioLimiteCreditoMntItemFrm(tipoMantenimientoItem, vwSocionegociolimitecredito);
                    socionegocioLimiteCreditoMntItemFrm.ShowDialog();

                    if (socionegocioLimiteCreditoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegociolimitecredito socionegociolimitecredito = AsignarSocioNegocioLimiteMnt(vwSocionegociolimitecredito);
                        if (socionegociolimitecredito.Idsocionegociolimitecredito > 0)
                        {
                            Service.UpdateSocionegociolimitecredito(socionegociolimitecredito);
                            ActualizarLimitesCredito();
                        }
                    }


                    break;

                case "btnDelLimite":
                    if (gvLimite.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwSocionegociolimitecredito = (VwSocionegociolimitecredito)gvLimite.GetFocusedRow();
                        if (vwSocionegociolimitecredito.Idsocionegociolimitecredito > 0)
                        {
                            Service.DeleteSocionegociolimitecredito(vwSocionegociolimitecredito.Idsocionegociolimitecredito);
                            vwSocionegociolimitecredito.DataEntityState = DataEntityState.Deleted;
                            if (!gvLimite.IsFirstRow)
                            {
                                gvLimite.MovePrev();
                            }
                            ActualizarLimitesCredito();
                        }
                    }
                    break;
            }
        }
        private Socionegociolimitecredito AsignarSocioNegocioLimiteMnt(VwSocionegociolimitecredito vwSocionegociolimitecredito)
        {
            Socionegociolimitecredito socionegociolimitecredito = new Socionegociolimitecredito();
            socionegociolimitecredito.Idsocionegociolimitecredito = vwSocionegociolimitecredito.Idsocionegociolimitecredito;
            socionegociolimitecredito.Idsocionegocio = IdEntidadMnt;
            socionegociolimitecredito.Idtipomoneda = vwSocionegociolimitecredito.Idtipomoneda;
            socionegociolimitecredito.Limitecredito = vwSocionegociolimitecredito.Limitecredito;
            socionegociolimitecredito.Tipolimitecredito = vwSocionegociolimitecredito.Tipolimitecredito;
            socionegociolimitecredito.Cantidadtransacciones = vwSocionegociolimitecredito.Cantidadtransacciones;
            return socionegociolimitecredito;
        }
        private void bmInfoBancaria_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            TipoMantenimiento tipoMantenimientoItem;
            SocionegentidadfinancieraMntItemFrm socionegentidadfinancieraMntItem;
            VwSocionegentidadfinanciera vwSocionegentidadfinanciera;

            switch (e.Item.Name)
            {
                case "btnAddInfoBan":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwSocionegentidadfinanciera = new VwSocionegentidadfinanciera();
                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    socionegentidadfinancieraMntItem = new SocionegentidadfinancieraMntItemFrm(tipoMantenimientoItem, vwSocionegentidadfinanciera);
                    socionegentidadfinancieraMntItem.ShowDialog();

                    if (socionegentidadfinancieraMntItem.DialogResult == DialogResult.OK)
                    {
                        Socionegentidadfinanciera socionegentidadfinanciera = AsignarSocioNegocioEntidadFinancieraMnt(vwSocionegentidadfinanciera);
                        int idsocionegociolimitecredito = Service.SaveSocionegentidadfinanciera(socionegentidadfinanciera);
                        if (idsocionegociolimitecredito > 0)
                        {
                            vwSocionegentidadfinanciera.Idsocionegentidadfinanciera = idsocionegociolimitecredito;
                            VwSocionegentidadfinancieraList.Add(vwSocionegentidadfinanciera);
                            ActualizarEntidadesFinancieras();
                            if (!gvInfoBancaria.IsLastRow)
                            {
                                gvInfoBancaria.MoveLastVisible();
                                gvInfoBancaria.Focus();
                            }
                        }

                    }


                    break;

                case "btnEditarInfoBan":
                    if (gvLimite.RowCount == 0)
                    {
                        break;
                    }
                    vwSocionegentidadfinanciera = (VwSocionegentidadfinanciera)gvInfoBancaria.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    socionegentidadfinancieraMntItem = new SocionegentidadfinancieraMntItemFrm(tipoMantenimientoItem, vwSocionegentidadfinanciera);
                    socionegentidadfinancieraMntItem.ShowDialog();

                    if (socionegentidadfinancieraMntItem.DialogResult == DialogResult.OK)
                    {
                        Socionegentidadfinanciera socionegentidadfinanciera = AsignarSocioNegocioEntidadFinancieraMnt(vwSocionegentidadfinanciera);
                        if (socionegentidadfinanciera.Idsocionegentidadfinanciera > 0)
                        {
                            Service.UpdateSocionegentidadfinanciera(socionegentidadfinanciera);
                            ActualizarEntidadesFinancieras();
                        }
                    }


                    break;

                case "btnDelInfo":
                    if (gvInfoBancaria.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwSocionegentidadfinanciera = (VwSocionegentidadfinanciera)gvInfoBancaria.GetFocusedRow();
                        if (vwSocionegentidadfinanciera.Idsocionegentidadfinanciera > 0)
                        {
                            Service.DeleteSocionegentidadfinanciera(vwSocionegentidadfinanciera.Idsocionegentidadfinanciera);
                            vwSocionegentidadfinanciera.DataEntityState = DataEntityState.Deleted;
                            if (!gvInfoBancaria.IsFirstRow)
                            {
                                gvInfoBancaria.MovePrev();
                            }
                            ActualizarEntidadesFinancieras();
                        }
                    }
                    break;
            }
        }
        private void ActualizarEntidadesFinancieras()
        {
            gvInfoBancaria.BeginUpdate();
            gvInfoBancaria.RefreshData();
            gvInfoBancaria.EndUpdate();
            gvInfoBancaria.BestFitColumns(true);
        }
        private Socionegentidadfinanciera AsignarSocioNegocioEntidadFinancieraMnt(VwSocionegentidadfinanciera vwSocionegentidadfinanciera)
        {
            Socionegentidadfinanciera socionegentidadfinanciera = new Socionegentidadfinanciera
            {
                Idsocionegentidadfinanciera = vwSocionegentidadfinanciera.Idsocionegentidadfinanciera,
                Idsocionegocio = IdEntidadMnt,
                Identfinaciera = vwSocionegentidadfinanciera.Identfinaciera,
                Idtipomoneda = vwSocionegentidadfinanciera.Idtipomoneda,
                Nrocuenta = vwSocionegentidadfinanciera.Nrocuenta,
                Nrocuentainterbancario = vwSocionegentidadfinanciera.Nrocuentainterbancario,
                Escuentadetraccion = vwSocionegentidadfinanciera.Escuentadetraccion
            };

            return socionegentidadfinanciera;

        }
        private void bmProyectos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            TipoMantenimiento tipoMantenimientoItem;
            SocionegocioproyectoMntItemFrm socionegocioproyectoMntItemFrm;
            VwSocionegocioproyecto vwSocionegocioproyecto;

            switch (e.Item.Name)
            {
                case "btnAddProyecto":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwSocionegocioproyecto = new VwSocionegocioproyecto();
                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    socionegocioproyectoMntItemFrm = new SocionegocioproyectoMntItemFrm(tipoMantenimientoItem, vwSocionegocioproyecto, VwSocionegocioproyectoList);
                    socionegocioproyectoMntItemFrm.ShowDialog();

                    if (socionegocioproyectoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegocioproyecto socionegocioproyecto = AsignarSocioNegocioProyectoMnt(vwSocionegocioproyecto);

                        int idsocionegociolimitecredito = Service.SaveSocionegocioproyecto(socionegocioproyecto);
                        if (idsocionegociolimitecredito > 0)
                        {
                            vwSocionegocioproyecto.Idsocionegocioproyecto = idsocionegociolimitecredito;
                            VwSocionegocioproyectoList.Add(vwSocionegocioproyecto);
                            ActualizarProyectos();
                            if (!gvProyectos.IsLastRow)
                            {
                                gvProyectos.MoveLastVisible();
                                gvProyectos.Focus();
                            }

                            //Asignar el nuevo proyecto creado
                            if (TabPageNameMnt != null && IdProyectoSocioNegocioNuevo == null)
                            {
                                IdProyectoSocioNegocioNuevo = socionegocioproyecto.Idproyecto;
                            }
                            else
                            {
                                IdProyectoSocioNegocioNuevo = null;
                            }
                        }

                    }


                    break;

                case "btnEditProyecto":
                    if (gvProyectos.RowCount == 0)
                    {
                        break;
                    }
                    vwSocionegocioproyecto = (VwSocionegocioproyecto)gvProyectos.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    socionegocioproyectoMntItemFrm = new SocionegocioproyectoMntItemFrm(tipoMantenimientoItem, vwSocionegocioproyecto, VwSocionegocioproyectoList);
                    socionegocioproyectoMntItemFrm.ShowDialog();

                    if (socionegocioproyectoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegocioproyecto socionegocioproyecto = AsignarSocioNegocioProyectoMnt(vwSocionegocioproyecto);
                        if (socionegocioproyecto.Idsocionegocioproyecto > 0)
                        {
                            Service.UpdateSocionegocioproyecto(socionegocioproyecto);
                            ActualizarProyectos();
                        }
                    }


                    break;

                case "btnDelProyecto":
                    if (gvProyectos.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar producto", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwSocionegocioproyecto = (VwSocionegocioproyecto)gvProyectos.GetFocusedRow();
                        if (vwSocionegocioproyecto.Idsocionegocioproyecto > 0)
                        {
                            Service.DeleteSocionegocioproyecto(vwSocionegocioproyecto.Idsocionegocioproyecto);
                            vwSocionegocioproyecto.DataEntityState = DataEntityState.Deleted;
                            if (!gvProyectos.IsFirstRow)
                            {
                                gvProyectos.MovePrev();
                            }
                            ActualizarProyectos();
                        }
                    }
                    break;
            }
        }
        private void ActualizarProyectos()
        {
            gvProyectos.BeginUpdate();
            gvProyectos.RefreshData();
            gvProyectos.EndUpdate();
            gvProyectos.BestFitColumns(true);
        }
        private Socionegocioproyecto AsignarSocioNegocioProyectoMnt(VwSocionegocioproyecto vwSocionegocioproyecto)
        {
            Socionegocioproyecto socionegocioproyecto = new Socionegocioproyecto
            {
                Idsocionegocioproyecto = vwSocionegocioproyecto.Idsocionegocioproyecto,
                Idsocionegocio = IdEntidadMnt,
                Idproyecto = vwSocionegocioproyecto.Idproyecto,
                Proyectopordefecto = vwSocionegocioproyecto.Proyectopordefecto
            };
            return socionegocioproyecto;
        }
        private void iIdtiposocio_EditValueChanged(object sender, EventArgs e)
        {
            //Tipolista tipolista = TipolistaList.FirstOrDefault();
            //if (tipolista != null)
            //    iIdtipolista.EditValue = tipolista.Idtipolista;

            Tiposocio tiposocioSel = TiposocioList.FirstOrDefault(x => x.Idtiposocio == (int)iIdtiposocio.EditValue);

            if (tiposocioSel != null)
            {
                switch (tiposocioSel.Idtiposocio)
                {
                    case 1: //Cliente
                        iIdzona.Enabled = true;
                        iIdzona.Tag = "Seleccione la zona";

                        iIdtipolista.Enabled = true;
                        iIdtipolista.Tag = "Seleccione el tipo de lista";


                        eSecuenciareparto.Enabled = true;

                        iIdtipocondicion.EditValue = null;

                        iIdvendedor.Enabled = true;

                        break;
                    case 2: //Proveedor
                        iIdzona.Enabled = false;
                        iIdzona.Tag = null;
                        iIdzona.EditValue = null;

                        iIdtipolista.Enabled = false;
                        iIdtipolista.Tag = null;
                        iIdtipolista.EditValue = null;

                        eSecuenciareparto.Enabled = false;


                        CargarTipoCondicion();
                        iIdvendedor.Enabled = false;
                        break;
                    case 3: //Cliente proveedor
                        iIdzona.Enabled = true;
                        iIdzona.Tag = "Seleccione la zona";

                        iIdtipolista.Enabled = true;
                        iIdtipolista.Tag = "Seleccione el tipo de lista";

                        eSecuenciareparto.Enabled = true;

                        iIdtipocondicion.EditValue = null;

                        iIdvendedor.Enabled = true;
                        break;

                }

            }
        }
        private void CargarTipoCondicion()
        {
            iIdtipocondicion.Properties.DataSource = CacheObjects.TipocondicionList;
            iIdtipocondicion.Properties.DisplayMember = "Nombrecondicion";
            iIdtipocondicion.Properties.ValueMember = "Idtipocondicion";
            iIdtipocondicion.Properties.BestFitMode = BestFitMode.BestFit;
        }
        private void bmGarantias_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;


            TipoMantenimiento tipoMantenimientoItem;
            SocionegociogarantiaMntItemFrm socionegociogarantiaMntItemFrm;
            VwSocionegociogarantia vwSocionegociogarantiaMnt;

            switch (e.Item.Name)
            {
                case "btnAddGarantia":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwSocionegociogarantiaMnt = new VwSocionegociogarantia();
                    vwSocionegociogarantiaMnt.Idsocionegocio = IdEntidadMnt;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    socionegociogarantiaMntItemFrm = new SocionegociogarantiaMntItemFrm(tipoMantenimientoItem, vwSocionegociogarantiaMnt);
                    socionegociogarantiaMntItemFrm.ShowDialog();

                    if (socionegociogarantiaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegociogarantia socionegociogarantia = AsignarSocioNegocioGarantiaMnt(vwSocionegociogarantiaMnt);
                        int idsocionegociogarantia = Service.SaveSocionegociogarantia(socionegociogarantia);
                        if (idsocionegociogarantia > 0)
                        {
                            vwSocionegociogarantiaMnt.Idsocionegociogarantia = idsocionegociogarantia;
                            VwSocionegociogarantiaList.Add(vwSocionegociogarantiaMnt);
                            ActualizarGarantias();
                            if (!gvGarantia.IsLastRow)
                            {
                                gvGarantia.MoveLastVisible();
                                gvGarantia.Focus();
                            }
                        }

                    }


                    break;

                case "btnEditGarantia":
                    if (gvDireccion.RowCount == 0)
                    {
                        break;
                    }
                    vwSocionegociogarantiaMnt = (VwSocionegociogarantia)gvGarantia.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    socionegociogarantiaMntItemFrm = new SocionegociogarantiaMntItemFrm(tipoMantenimientoItem, vwSocionegociogarantiaMnt);
                    socionegociogarantiaMntItemFrm.ShowDialog();

                    if (socionegociogarantiaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegociogarantia socionegociogarantia = AsignarSocioNegocioGarantiaMnt(vwSocionegociogarantiaMnt);
                        if (socionegociogarantia.Idsocionegociogarantia > 0)
                        {
                            Service.UpdateSocionegociogarantia(socionegociogarantia);
                            ActualizarGarantias();
                        }
                    }


                    break;

                case "btnDelGarantia":
                    if (gvDireccion.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwSocionegociogarantiaMnt = (VwSocionegociogarantia)gvGarantia.GetFocusedRow();
                        if (vwSocionegociogarantiaMnt.Idsocionegociogarantia > 0)
                        {
                            Service.DeleteSocionegociogarantia(vwSocionegociogarantiaMnt.Idsocionegociogarantia);
                            vwSocionegociogarantiaMnt.DataEntityState = DataEntityState.Deleted;
                            if (!gvGarantia.IsFirstRow)
                            {
                                gvGarantia.MovePrev();
                            }
                            ActualizarGarantias();
                        }
                    }
                    break;
            }
        }
        private Socionegociogarantia AsignarSocioNegocioGarantiaMnt(VwSocionegociogarantia vwSocionegociogarantiaMnt)
        {

            Socionegociogarantia socionegociogarantia = new Socionegociogarantia
            {
                Idsocionegociogarantia = vwSocionegociogarantiaMnt.Idsocionegociogarantia,
                Idsocionegocio = IdEntidadMnt,
                Idtipogarantia = vwSocionegociogarantiaMnt.Idtipogarantia,
                Idtipomoneda = vwSocionegociogarantiaMnt.Idtipomoneda,
                Importe = vwSocionegociogarantiaMnt.Importe,
                Identfinaciera = vwSocionegociogarantiaMnt.Identfinaciera,
                Vencimiento = vwSocionegociogarantiaMnt.Vencimiento,
                Descripicion = vwSocionegociogarantiaMnt.Descripicion
            };
            return socionegociogarantia;
        }
        private void bmMarca_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;

            TipoMantenimiento tipoMantenimientoItem;
            SocionegociomarcaMntItemFrm socionegociomarcaMntItemFrm;
            VwSocionegociomarca vwSocionegociomarcaMnt;

            switch (e.Item.Name)
            {
                case "btnAddMarca":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    vwSocionegociomarcaMnt = new VwSocionegociomarca();
                    vwSocionegociomarcaMnt.Idsocionegocio = IdEntidadMnt;

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    socionegociomarcaMntItemFrm = new SocionegociomarcaMntItemFrm(tipoMantenimientoItem, vwSocionegociomarcaMnt);
                    socionegociomarcaMntItemFrm.ShowDialog();

                    if (socionegociomarcaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegociomarca socionegociomarca = AsignarSocioNegocioMarcaMnt(vwSocionegociomarcaMnt);
                        int idsocionegociomarca = Service.SaveSocionegociomarca(socionegociomarca);
                        if (idsocionegociomarca > 0)
                        {
                            vwSocionegociomarcaMnt.Idsocionegociomarca = idsocionegociomarca;
                            VwSocionegociomarcaList.Add(vwSocionegociomarcaMnt);
                            ActualizarMarcas();
                            if (!gvMarca.IsLastRow)
                            {
                                gvMarca.MoveLastVisible();
                                gvMarca.Focus();
                            }
                        }

                    }


                    break;

                case "btnEditMarca":
                    if (gvDireccion.RowCount == 0)
                    {
                        break;
                    }
                    vwSocionegociomarcaMnt = (VwSocionegociomarca)gvMarca.GetFocusedRow();

                    tipoMantenimientoItem = TipoMantenimiento.Modificar;
                    socionegociomarcaMntItemFrm = new SocionegociomarcaMntItemFrm(tipoMantenimientoItem, vwSocionegociomarcaMnt);
                    socionegociomarcaMntItemFrm.ShowDialog();

                    if (socionegociomarcaMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Socionegociomarca socionegociomarca = AsignarSocioNegocioMarcaMnt(vwSocionegociomarcaMnt);
                        if (socionegociomarca.Idsocionegociomarca > 0)
                        {
                            Service.UpdateSocionegociomarca(socionegociomarca);
                            ActualizarMarcas();
                        }
                    }


                    break;

                case "btnDelMarca":
                    if (gvDireccion.RowCount == 0)
                    {
                        break;
                    }

                    if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                        "Eliminar Item", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        vwSocionegociomarcaMnt = (VwSocionegociomarca)gvMarca.GetFocusedRow();
                        if (vwSocionegociomarcaMnt != null && vwSocionegociomarcaMnt.Idsocionegociomarca > 0)
                        {
                            Service.DeleteSocionegociomarca(vwSocionegociomarcaMnt.Idsocionegociomarca);
                            vwSocionegociomarcaMnt.DataEntityState = DataEntityState.Deleted;
                            if (!gvMarca.IsFirstRow)
                            {
                                gvMarca.MovePrev();
                            }
                            ActualizarMarcas();
                        }
                    }
                    break;
            }
        }
        private Socionegociomarca AsignarSocioNegocioMarcaMnt(VwSocionegociomarca vwSocionegociomarcaMnt)
        {
            Socionegociomarca socionegociomarca = new Socionegociomarca
            {
                Idsocionegociomarca = vwSocionegociomarcaMnt.Idsocionegociomarca,
                Idsocionegocio = vwSocionegociomarcaMnt.Idsocionegocio,
                Idmarca = vwSocionegociomarcaMnt.Idmarca
            };
            return socionegociomarca;
        }
        private void iIdtipolista_EditValueChanged(object sender, EventArgs e)
        {
            var idTipoListaSel = iIdtipolista.EditValue;
            if (idTipoListaSel != null)
            {
                string condicionTipoLista = string.Format("idtipolista = {0} and idempresa = {1}", (int) idTipoListaSel,SessionApp.EmpresaSel.Idempresa);
                List<VwTipolistatipocondicion> vwTipolistatipocondicionList = Service.GetAllVwTipolistatipocondicion(condicionTipoLista, "nombrecondicion");
                iIdtipocondicion.Properties.DataSource = vwTipolistatipocondicionList;
                iIdtipocondicion.Properties.DisplayMember = "Nombrecondicion";
                iIdtipocondicion.Properties.ValueMember = "Idtipocondicion";
                iIdtipocondicion.Properties.BestFitMode = BestFitMode.BestFit;

                if (TipoMnt == TipoMantenimiento.Nuevo)
                {
                    VwTipolistatipocondicion vwTipolistatipocondicion = vwTipolistatipocondicionList.FirstOrDefault(x => x.Nombrecondicion.Equals("CONTADO"));
                    if (vwTipolistatipocondicion != null)
                    {
                        iIdtipocondicion.EditValue = vwTipolistatipocondicion.Idtipocondicion;
                    }
                }
            }

        }
        private void iIdestadosocionegocio_EditValueChanged(object sender, EventArgs e)
        {
            var idEstadoSocioNegocioSel = iIdestadosocionegocio.EditValue;
            if (idEstadoSocioNegocioSel != null)
            {
                Estadosocionegocio estadosocionegocioSel =
                    EstadosocionegocioList.FirstOrDefault(x => x.Idestadosocionegocio == (int) idEstadoSocioNegocioSel);
                if (estadosocionegocioSel != null)
                {
                    iIniciosuspension.Enabled = estadosocionegocioSel.Requiereperiodo;
                    iFinsuspension.Enabled = estadosocionegocioSel.Requiereperiodo;
                    iMotivosuspension.Enabled = estadosocionegocioSel.Requieremotivo;
                }
            }
            
        }
        private void btnConsultaReniec_Click(object sender, EventArgs e)
        {
            ConsultaReniecFrm consultaReniecFrm = new ConsultaReniecFrm();
            consultaReniecFrm.ShowDialog();
            if (consultaReniecFrm.DialogResult == DialogResult.OK && consultaReniecFrm.PersonaReniec != null)
            {
                iNrodocentidad.EditValue = consultaReniecFrm.Dni;
            }
        }

        private void iIdzona_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            ZonaMntFrm zonaMntFrm = new ZonaMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            zonaMntFrm.ShowDialog();
            if (zonaMntFrm.IdEntidadMnt > 0)
            {
                Zona zona = zonaMntFrm.ZonaMnt;
                if (zona.Idzona > 0)
                {
                    ZonaList.Add(zona);
                    e.Cancel = false;
                    e.NewValue = zona.Idzona;
                }
            }
        }

        private void iIdrubronegocio_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            RubronegocioMntFrm rubronegocioMntFrm = new RubronegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            rubronegocioMntFrm.ShowDialog();
            if (rubronegocioMntFrm.IdEntidadMnt > 0)
            {
                Rubronegocio rubronegocio = rubronegocioMntFrm.RubronegocioaMnt;
                if (rubronegocio.Idrubronegocio > 0)
                {
                    RubronegocioList.Add(rubronegocio);
                    e.Cancel = false;
                    e.NewValue = rubronegocio.Idrubronegocio;
                }
            }
        }

        private void iIdgrupoeconomico_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            GrupoeconomicoMntFrm grupoeconomicoMntFrm = new GrupoeconomicoMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            grupoeconomicoMntFrm.ShowDialog();
            if (grupoeconomicoMntFrm.IdEntidadMnt > 0)
            {
                Grupoeconomico grupoeconomico = grupoeconomicoMntFrm.GrupoeconomicoMnt;
                if (grupoeconomico.Idgrupoeconomico > 0)
                {
                    GrupoeconomicoList.Add(grupoeconomico);
                    e.Cancel = false;
                    e.NewValue = grupoeconomico.Idgrupoeconomico;
                }
            }
        }

        private void iIdcategoriaproveedor_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            CategoriasocionegocioMntFrm categoriasocionegocioMntFrm = new CategoriasocionegocioMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            categoriasocionegocioMntFrm.ShowDialog();
            if (categoriasocionegocioMntFrm.IdEntidadMnt > 0)
            {
                Categoriasocionegocio categoriasocionegocio = categoriasocionegocioMntFrm.CategoriasocionegocioMnt;
                if (categoriasocionegocio.Idcategoriasocionegocio > 0)
                {
                    CategoriasocionegocioList.Add(categoriasocionegocio);
                    e.Cancel = false;
                    e.NewValue = categoriasocionegocio.Idcategoriasocionegocio;
                }
            }
        }
    }
}
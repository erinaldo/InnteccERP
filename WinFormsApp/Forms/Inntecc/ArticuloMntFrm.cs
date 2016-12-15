using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActionService;
using BusinessObjects;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using Utilities;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class ArticuloMntFrm : XtraForm
    {
        public int IdEntidadMnt { get; set; }
        public TipoMantenimiento TipoMnt { get; set; }
        public int IdUsuario { get; set; }
        public bool SeEliminoObjeto { get; set; }
        public bool SeGuardoObjeto { get; set; }
        public GridControl GridParent { get; set; }
        public ArticuloFrm FormParent { get; set; }

        private readonly DXErrorProvider _errorProvider;
        public Accesoform Permisos { get; set; }

        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public Articulo ArticuloMnt { get; set; }
        public int IdEmpresaSel { get; set; }
        public List<VwArticuloubicacion> VwArticuloubicacionList { get; set; }
        public List<VwArticulodetalleunidad> VwArticulodetalleunidadList { get; set; }
        public List<VwArticuloseriedet> VwArticuloseriedetList { get; set; }
        public List<VwArticulocompuesto> VwArticulocompuestoList { get; set; }
        private List<Unidadmedida> UnidadmedidaList { get; set; }
        private List<VwArticuloclasificacion> VwArticuloclasificacionList { get; set; }
        public List<VwListaprecio> VwListaprecioList { get; set; }
        public List<Clasificacionequipo> ClasificacionequipoList { get; set; }
        public List<Estadoarticulo> EstadoarticuloList { get; set; }
        public List<Tipogestionarticulo> TipogestionarticuloList { get; set; }
        public List<VwArticulolistaprecio> VwArticulolistaprecioList { get; set; }
        private List<Marca> MarcaList { get; set; }
        private List<Elementogasto> ElementogastoList { get; set; }

        List<Inventario> _inventarioList;
        public ArticuloMntFrm(int idEntidadMnt, TipoMantenimiento tipoMnt, GridControl gridParent, ArticuloFrm formParent)
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

            //EstablecerPermisos();
            //InicioTipoMantenimiento();       
        }
        private void ArticuloMntFrm_Load(object sender, EventArgs e)
        {
            EstablecerPermisos();
            InicioTipoMantenimiento();
        }
        private void ValoresPorDefecto()
        {
            iCodigoarticulo.EditValue = Service.GetSiguienteCodigoArticulo();
            rActivo.Checked = true;
            iMuevekardex.Checked = true;
            iEsarticuloinventario.Checked = true;
            iEsarticulodeventa.Checked = true;
            iEsarticulodecompra.Checked = true;
            iIdtipoafectacionigv.EditValue = 1; //GRAVADO - OPERACION ONEROSA;
            iIdimpuesto.EditValue = SessionApp.EmpresaSel.Idimpuestopordefecto;
            iIdunidadinventario.EditValue = 7; //Unidad
            iIdtipoarticulo.EditValue = 1; //Articulo
            rIdtipomonedacosto.EditValue = 1; //Soles
            iIdestadoarticulo.EditValue = 1; //Activo
            iPagacomision.Checked = true;
            IdEmpresaSel = SessionApp.EmpresaSel.Idempresa;

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
                    ArticuloMnt = new Articulo();
                    CargarDetalle();
                    iIdestadoarticulo.Select();
                    break;
                case TipoMantenimiento.Modificar:
                    pkIdEntidad.EditValue = IdEntidadMnt;
                    CargarReferencias();
                    TraerDatos();
                    CargarDetalle();
                    CargarCostoArticulo();
                    break;
            }
        }
        private void CargarCostoArticulo()
        {

            DateTime fechaInicio = FechaInicialInventario();
            DateTime fechaFinal = SessionApp.DateServer;
            rCostounitario.EditValue = CostoPromedio(
                (int)pkIdEntidad.EditValue,
                fechaInicio,
                fechaFinal,
                SessionApp.EmpresaSel.Idempresa);

        }
        private DateTime FechaInicialInventario()
        {
            DateTime fechaInicio = new DateTime();
            string condicion = string.Format("idsucursal = '{0}' and anulado = '0' ", SessionApp.SucursalSel.Idsucursal);
            string orden = "idinventario desc limit 1";
            if (_inventarioList == null)
            {
                _inventarioList = Service.GetAllInventario(condicion, orden);
            }
            if (_inventarioList != null)
            {
                Inventario inventario = _inventarioList.FirstOrDefault();
                if (inventario != null)
                {
                    fechaInicio = inventario.Fechainventario;
                }
            }
            return fechaInicio;
        }
        private void CargarReferencias()
        {
            UnidadmedidaList = CacheObjects.UnidadmedidaList;
            iIdunidadinventario.Properties.DataSource = UnidadmedidaList;
            iIdunidadinventario.Properties.DisplayMember = "Nombreunidadmedida";
            iIdunidadinventario.Properties.ValueMember = "Idunidadmedida";
            iIdunidadinventario.Properties.BestFitMode = BestFitMode.BestFit;


            //ArticuloclasificacionList = CacheObjects.ArticuloclasificacionList; //Service.GetAllArticuloclasificacion("Nombreclasificacion");
            VwArticuloclasificacionList = Service.GetAllVwArticuloclasificacion("Nombreclasificacion");
            iIdarticuloclasificacion.Properties.DataSource = VwArticuloclasificacionList;
            iIdarticuloclasificacion.Properties.DisplayMember = "Nombreclasificaciondetalle";
            iIdarticuloclasificacion.Properties.ValueMember = "Idarticuloclasificacion";
            iIdarticuloclasificacion.Properties.BestFitMode = BestFitMode.BestFit;

            MarcaList = CacheObjects.MarcaList; //Service.GetAllMarca("nombremarca");
            iIdmarca.Properties.DataSource = MarcaList;
            iIdmarca.Properties.DisplayMember = "Nombremarca";
            iIdmarca.Properties.ValueMember = "Idmarca";
            iIdmarca.Properties.BestFitMode = BestFitMode.BestFit;

            iIdimpuesto.Properties.DataSource = CacheObjects.ImpuestoList;
            iIdimpuesto.Properties.DisplayMember = "Nombreimpuesto";
            iIdimpuesto.Properties.ValueMember = "Idimpuesto";
            iIdimpuesto.Properties.BestFitMode = BestFitMode.BestFit;

            iIdimpuestoisc.Properties.DataSource = CacheObjects.ArticuloclasificacionList;//Service.GetAllImpuestoisc("Nombreimpuestoisc");
            iIdimpuestoisc.Properties.DisplayMember = "Nombreimpuestoisc";
            iIdimpuestoisc.Properties.ValueMember = "Idimpuestoisc";
            iIdimpuestoisc.Properties.BestFitMode = BestFitMode.BestFit;

            iIdcuentacontable.Properties.DataSource = CacheObjects.CuentacontableList; //Service.GetAllCuentacontable("codigocuenta");
            iIdcuentacontable.Properties.DisplayMember = "Nombrecuenta";
            iIdcuentacontable.Properties.ValueMember = "Idcuentacontable";
            iIdcuentacontable.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipoafectacionigv.Properties.DataSource = CacheObjects.TipoafectacionigvList;
            iIdtipoafectacionigv.Properties.DisplayMember = "Nombretipoafectacionigv";
            iIdtipoafectacionigv.Properties.ValueMember = "Idtipoafectacionigv";
            iIdtipoafectacionigv.Properties.BestFitMode = BestFitMode.BestFit;

            iIdtipoarticulo.Properties.DataSource = CacheObjects.TipoarticuloList;
            iIdtipoarticulo.Properties.DisplayMember = "Nombretipoarticulo";
            iIdtipoarticulo.Properties.ValueMember = "Idtipoarticulo";
            iIdtipoarticulo.Properties.BestFitMode = BestFitMode.BestFit;

            ElementogastoList = CacheObjects.ElementogastoList;//Service.GetAllElementogasto("codigoelementogasto");

            iIdelementogasto.Properties.DataSource = ElementogastoList;
            iIdelementogasto.Properties.DisplayMember = "Nombreelementogasto";
            iIdelementogasto.Properties.ValueMember = "Idelementogasto";
            iIdelementogasto.Properties.BestFitMode = BestFitMode.BestFit;

            rIdtipomonedacosto.Properties.DataSource = CacheObjects.TipomonedaList;
            rIdtipomonedacosto.Properties.DisplayMember = "Nombretipomoneda";
            rIdtipomonedacosto.Properties.ValueMember = "Idtipomoneda";
            rIdtipomonedacosto.Properties.BestFitMode = BestFitMode.BestFit;

            ClasificacionequipoList = CacheObjects.ClasificacionequipoList;//Service.GetAllClasificacionequipo("Nombreclasificacionequipo");
            iIdclasificacionequipo.Properties.DataSource = ClasificacionequipoList;
            iIdclasificacionequipo.Properties.DisplayMember = "Nombreclasificacionequipo";
            iIdclasificacionequipo.Properties.ValueMember = "Idclasificacionequipo";
            iIdclasificacionequipo.Properties.BestFitMode = BestFitMode.BestFit;


            EstadoarticuloList = CacheObjects.EstadoarticuloList;
            iIdestadoarticulo.Properties.DataSource = EstadoarticuloList;
            iIdestadoarticulo.Properties.DisplayMember = "Nombreestadoarticulo";
            iIdestadoarticulo.Properties.ValueMember = "Idestadoarticulo";
            iIdestadoarticulo.Properties.BestFitMode = BestFitMode.BestFit;

            TipogestionarticuloList = CacheObjects.TipogestionarticuloList;
            iIdtipogestionarticulo.Properties.DataSource = TipogestionarticuloList;
            iIdtipogestionarticulo.Properties.DisplayMember = "Codigotipogestionarticulo";
            iIdtipogestionarticulo.Properties.ValueMember = "Idtipogestionarticulo";
            iIdtipogestionarticulo.Properties.BestFitMode = BestFitMode.BestFit;

        }
        private void TraerDatos()
        {
            try
            {
                ArticuloMnt = Service.GetArticulo(IdEntidadMnt);

                iCodigoarticulo.EditValue = ArticuloMnt.Codigoarticulo;
                iCodigoproveedor.EditValue = ArticuloMnt.Codigoproveedor;
                iCodigodebarra.EditValue = ArticuloMnt.Codigodebarra;
                iIdunidadinventario.EditValue = ArticuloMnt.Idunidadinventario;
                iIdarticuloclasificacion.EditValue = ArticuloMnt.Idarticuloclasificacion;
                iIdmarca.EditValue = ArticuloMnt.Idmarca;
                iNombrearticulo.EditValue = ArticuloMnt.Nombrearticulo;
                iIdimpuesto.EditValue = ArticuloMnt.Idimpuesto;
                iIdimpuestoisc.EditValue = ArticuloMnt.Idimpuestoisc;
                rActivo.EditValue = ArticuloMnt.Activo;
                iMuevekardex.EditValue = ArticuloMnt.Muevekardex;
                nPesoarticulo.EditValue = ArticuloMnt.Pesoarticulo;
                nStockminarticulo.EditValue = ArticuloMnt.Stockminarticulo;
                nStockmaximo.EditValue = ArticuloMnt.Stockmaximo;
                iAplicapercepcion.EditValue = ArticuloMnt.Aplicapercepcion;
                iComentario.EditValue = ArticuloMnt.Comentario;
                iEsarticuloinventario.EditValue = ArticuloMnt.Esarticuloinventario;
                iEsarticulodeventa.EditValue = ArticuloMnt.Esarticulodeventa;
                iEsarticulodecompra.EditValue = ArticuloMnt.Esarticulodecompra;
                iEsactivofijo.EditValue = ArticuloMnt.Esactivofijo;
                iIdcuentacontable.EditValue = ArticuloMnt.Idcuentacontable;
                iIdtipoafectacionigv.EditValue = ArticuloMnt.Idtipoafectacionigv;
                reCaracteristicas.Text = ArticuloMnt.Caracteristicas;
                iIdtipoarticulo.EditValue = ArticuloMnt.Idtipoarticulo;

                iNumerodeserie.EditValue = ArticuloMnt.Numerodeserie;
                iIdelementogasto.EditValue = ArticuloMnt.Idelementogasto;
                iEsarticulocompuesto.EditValue = ArticuloMnt.Esarticulocompuesto;
                rIdtipomonedacosto.EditValue = ArticuloMnt.Idtipomonedacosto;
                rCostounitario.EditValue = ArticuloMnt.Costounitario;
                rTipocambio.EditValue = ArticuloMnt.Tipocambio;
                iIdclasificacionequipo.EditValue = ArticuloMnt.Idclasificacionequipo;

                iNombrearticulocorto.EditValue = ArticuloMnt.Nombrearticulocorto;
                iNombrearticuloalterno.EditValue = ArticuloMnt.Nombrearticuloalterno;
                iStockcritico.EditValue = ArticuloMnt.Stockcritico;
                iStockreposicion.EditValue = ArticuloMnt.Stockreposicion;
                iReposicionautomatica.EditValue = ArticuloMnt.Reposicionautomatica;
                iPagacomision.EditValue = ArticuloMnt.Pagacomision;
                iControldeserie.EditValue = ArticuloMnt.Controldeserie;
                iVariacioncantidadentregada.EditValue = ArticuloMnt.Variacioncantidadentregada;
                iIdtipogestionarticulo.EditValue = ArticuloMnt.Idtipogestionarticulo;
                iIdestadoarticulo.EditValue = ArticuloMnt.Idestadoarticulo;
                iImagenarticulo.EditValue = ArticuloMnt.Imagenarticulo;
                iAplicacuarentena.EditValue = ArticuloMnt.Aplicacuarentena;
                IdEmpresaSel = ArticuloMnt.Idempresa;
                iEsserviciomedico.EditValue = ArticuloMnt.Esserviciomedico;
                iMotivopordefectoprogramacion.EditValue = ArticuloMnt.Motivopordefectoprogramacion;
                iTiempoduracion.EditValue = ArticuloMnt.Tiempoduracion;
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
            string whereArticulo = string.Format("idarticulo = '{0}'", IdEntidadMnt);

            gcDetDato.BeginUpdate();
            string condicionEmpresa = string.Format(" and idempresa = {0}", SessionApp.EmpresaSel.Idempresa);
            VwArticuloubicacionList = Service.GetAllVwArticuloubicacion(whereArticulo + condicionEmpresa, "idarticuloubicacion");
            gcDetDato.DataSource = VwArticuloubicacionList;
            gvDetDato.BestFitColumns();
            gcDetDato.EndUpdate();

            gcDetUnidad.BeginUpdate();
            VwArticulodetalleunidadList = Service.GetAllVwArticulodetalleunidad(whereArticulo, "idarticulodetalleunidad");
            gcDetUnidad.DataSource = VwArticulodetalleunidadList;
            gvDetUnidad.BestFitColumns();
            gcDetUnidad.EndUpdate();

            gcDetCompuesto.BeginUpdate();
            VwArticulocompuestoList = Service.GetAllVwArticulocompuesto(whereArticulo, "idarticulocompuesto");
            gcDetCompuesto.DataSource = VwArticulocompuestoList;
            gvDetCompuesto.BestFitColumns();
            gcDetCompuesto.EndUpdate();

            gcSeries.BeginUpdate();
            VwArticuloseriedetList = Service.GetAllVwArticuloseriedet(whereArticulo, "idarticuloseriedet");
            gcSeries.DataSource = VwArticuloseriedetList;
            gvSeries.BestFitColumns();
            gcSeries.EndUpdate();
        }
        private bool Guardar()
        {

            if (!Validaciones()) return false;

            ArticuloMnt.Codigoarticulo = iCodigoarticulo.Text.Trim();
            ArticuloMnt.Codigoproveedor = iCodigoproveedor.Text.Trim();
            ArticuloMnt.Codigodebarra = iCodigodebarra.Text.Trim();
            ArticuloMnt.Idunidadinventario = (int)iIdunidadinventario.EditValue;
            ArticuloMnt.Idarticuloclasificacion = (int?)iIdarticuloclasificacion.EditValue;
            ArticuloMnt.Idmarca = (int?)iIdmarca.EditValue;
            ArticuloMnt.Nombrearticulo = iNombrearticulo.Text.Trim();
            ArticuloMnt.Idimpuesto = (int)iIdimpuesto.EditValue;
            ArticuloMnt.Idimpuestoisc = (int?)iIdimpuestoisc.EditValue;
            ArticuloMnt.Activo = (bool)rActivo.EditValue;
            ArticuloMnt.Muevekardex = (bool)iMuevekardex.EditValue;
            ArticuloMnt.Pesoarticulo = (decimal)nPesoarticulo.EditValue;
            ArticuloMnt.Stockminarticulo = (decimal)nStockminarticulo.EditValue;
            ArticuloMnt.Stockmaximo = (decimal)nStockmaximo.EditValue;
            ArticuloMnt.Aplicapercepcion = (bool)iAplicapercepcion.EditValue;
            ArticuloMnt.Comentario = iComentario.Text.Trim();
            ArticuloMnt.Esarticuloinventario = (bool)iEsarticuloinventario.EditValue;
            ArticuloMnt.Esarticulodeventa = (bool)iEsarticulodeventa.EditValue;
            ArticuloMnt.Esarticulodecompra = (bool)iEsarticulodecompra.EditValue;
            ArticuloMnt.Esactivofijo = (bool)iEsactivofijo.EditValue;
            ArticuloMnt.Idcuentacontable = (int?)iIdcuentacontable.EditValue;
            ArticuloMnt.Idtipoafectacionigv = (int)iIdtipoafectacionigv.EditValue;
            ArticuloMnt.Caracteristicas = reCaracteristicas.Text.Trim();
            ArticuloMnt.Idtipoarticulo = (int)iIdtipoarticulo.EditValue;

            ArticuloMnt.Numerodeserie = iNumerodeserie.Text.Trim();
            ArticuloMnt.Idelementogasto = (int?)iIdelementogasto.EditValue;
            ArticuloMnt.Esarticulocompuesto = (bool)iEsarticulocompuesto.EditValue;
            ArticuloMnt.Idtipomonedacosto = (int?)rIdtipomonedacosto.EditValue;
            ArticuloMnt.Costounitario = (decimal)rCostounitario.EditValue;
            ArticuloMnt.Tipocambio = (decimal)rTipocambio.EditValue;
            ArticuloMnt.Idclasificacionequipo = (int?)iIdclasificacionequipo.EditValue;

            ArticuloMnt.Nombrearticulocorto = iNombrearticulocorto.Text.Trim();
            ArticuloMnt.Nombrearticuloalterno = iNombrearticuloalterno.Text.Trim();
            ArticuloMnt.Stockcritico = (decimal)iStockcritico.EditValue;
            ArticuloMnt.Stockreposicion = (decimal)iStockreposicion.EditValue;
            ArticuloMnt.Reposicionautomatica = (bool)iReposicionautomatica.EditValue;
            ArticuloMnt.Pagacomision = (bool)iPagacomision.EditValue;
            ArticuloMnt.Controldeserie = (bool)iControldeserie.EditValue;
            ArticuloMnt.Variacioncantidadentregada = (decimal)iVariacioncantidadentregada.EditValue;
            ArticuloMnt.Idtipogestionarticulo = (int?)iIdtipogestionarticulo.EditValue;
            ArticuloMnt.Idestadoarticulo = (int?)iIdestadoarticulo.EditValue;
            ArticuloMnt.Imagenarticulo = (byte[])iImagenarticulo.EditValue;
            ArticuloMnt.Aplicacuarentena = (bool)iAplicacuarentena.EditValue;
            ArticuloMnt.Idempresa = IdEmpresaSel;
            ArticuloMnt.Esserviciomedico = (bool) iEsserviciomedico.EditValue;
            ArticuloMnt.Motivopordefectoprogramacion = (bool)iMotivopordefectoprogramacion.EditValue;
            ArticuloMnt.Tiempoduracion = iTiempoduracion.Text.Trim();
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
                        IdEntidadMnt = Service.SaveArticulo(ArticuloMnt);
                        ArticuloMnt.Idarticulo = IdEntidadMnt;
                        pkIdEntidad.EditValue = IdEntidadMnt;
                        AgregaListaPrecios(IdEntidadMnt, ArticuloMnt.Idunidadinventario);
                        AgregarArticulosAInventario();
                        break;
                    case TipoMantenimiento.Modificar:
                        Service.UpdateArticulo(ArticuloMnt);
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
        private void AgregarArticulosAInventario()
        {
            if (SessionApp.VwInventarioInicial == null)
            {
                SessionApp.RecargarInventarioInicial();
            }

            if (SessionApp.VwInventarioInicial != null)
            {
                Service.RegistrarUbicacionPorDefectoInventario(SessionApp.EmpresaSel.Idempresa, IdEntidadMnt, SessionApp.VwInventarioInicial.Idinventarioinicial);
            }

        }
        private void AgregaListaPrecios(int idartiulo, int idunidadmedida)
        {

            VwListaprecioList = Service.GetAllVwListaprecio("Agregararticuloauto = '1'", "Tipolistaprecio");

            foreach (var item in VwListaprecioList)
            {
                var articulolistaprecioMnt = new Articulolistaprecio
                {
                    Idarticulo = idartiulo,
                    Idlistaprecio = item.Idlistaprecio,
                    Idunidadmedida = idunidadmedida,
                    Costolista = 0m,
                    Porcentajemargencontado = 0m,
                    Lastmodified = null
                };

                Service.SaveArticulolistaprecio(articulolistaprecioMnt);
            }

        }
        private bool Validaciones()
        {
            if (!WinFormUtils.ValidateFieldsNotEmpty(tpArticulo, _errorProvider))
            {
                XtraMessageBox.Show(Resources.msgIngresarValoresValidos, Resources.titAtencion, MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return false;
            }

            if (Service.CodigoArticuloExiste(iCodigoarticulo.Text.Trim()) && TipoMnt == TipoMantenimiento.Nuevo)
            {
                iCodigoarticulo.EditValue = Service.GetSiguienteCodigoArticulo();
            }

            if (Service.CodigoBarraArticuloExiste(iCodigoarticulo.Text.Trim(), IdEmpresaSel) && TipoMnt == TipoMantenimiento.Nuevo)
            {
                XtraMessageBox.Show("Código de barras ya existe verifique.", Resources.titAtencion, MessageBoxButtons.OK,
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
                        Service.DeletePersona(IdEntidadMnt);
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

                    ArticuloMnt = null;
                    ArticuloMnt = new Articulo();

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
                        ArticuloMnt = null;
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
        private void ArticuloMntFrm_KeyPress(object sender, KeyPressEventArgs e)
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
        private void ArticuloMntFrm_FormClosing(object sender, FormClosingEventArgs e)
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
            var vwArticuloubicacionMnt = new VwArticuloubicacion();

            switch (e.Item.Name)
            {
                case "btnAddItem":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwArticuloubicacionMnt.Nombrearticulo = iNombrearticulo.Text;

                    ArticuloubicacionMntItemFrm articuloubicacionMntItemFrm = new ArticuloubicacionMntItemFrm(tipoMantenimientoItem, vwArticuloubicacionMnt);
                    articuloubicacionMntItemFrm.ShowDialog();

                    if (articuloubicacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwArticuloubicacionList.Add(vwArticuloubicacionMnt);

                        var articuloubicacionMnt = new Articuloubicacion
                        {
                            Idarticulo = IdEntidadMnt,
                            Idubicacion = vwArticuloubicacionMnt.Idubicacion,

                        };

                        Service.SaveArticuloubicacion(articuloubicacionMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnEditDato":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwArticuloubicacionMnt = (VwArticuloubicacion)gvDetDato.GetFocusedRow();

                    if (vwArticuloubicacionMnt == null)
                    {
                        break;
                    }
                    vwArticuloubicacionMnt.Nombrearticulo = iNombrearticulo.Text;
                    articuloubicacionMntItemFrm = new ArticuloubicacionMntItemFrm(tipoMantenimientoItem, vwArticuloubicacionMnt);
                    articuloubicacionMntItemFrm.ShowDialog();

                    if (articuloubicacionMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        gcDetDato.RefreshDataSource();
                        var articuloubicacionMnt = new Articuloubicacion
                        {
                            Idarticuloubicacion = vwArticuloubicacionMnt.Idarticuloubicacion,
                            Idarticulo = IdEntidadMnt,
                            Idubicacion = vwArticuloubicacionMnt.Idubicacion,

                        };

                        Service.UpdateArticuloubicacion(articuloubicacionMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnDelItem":
                    int idarticuloubicacion = Convert.ToInt32(gvDetDato.GetRowCellValue(gvDetDato.FocusedRowHandle, "Idarticuloubicacion"));

                    if (idarticuloubicacion > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            Service.DeleteArticuloubicacion(idarticuloubicacion);

                            CargarDetalle();
                        }
                    }
                    break;
            }
        }
        private void bmItemsUnidad_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            var vwArticulodetalleunidadMnt = new VwArticulodetalleunidad();

            switch (e.Item.Name)
            {
                case "btnAddUnidad":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwArticulodetalleunidadMnt.Nombrearticulo = iNombrearticulo.Text;

                    var articulounidadMntItemFrm = new ArticulounidadMntItemFrm(tipoMantenimientoItem, vwArticulodetalleunidadMnt);
                    articulounidadMntItemFrm.ShowDialog();

                    if (articulounidadMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwArticulodetalleunidadList.Add(vwArticulodetalleunidadMnt);

                        var articulodetalleunidadMnt = new Articulodetalleunidad
                        {
                            Idarticulo = IdEntidadMnt,
                            Idunidadmedida = vwArticulodetalleunidadMnt.Idunidadmedida,

                        };

                        Service.SaveArticulodetalleunidad(articulodetalleunidadMnt);
                        AgregaListaPrecios(IdEntidadMnt, articulodetalleunidadMnt.Idunidadmedida);
                        CargarDetalle();

                    }

                    break;

                case "btnEditUnidad":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwArticulodetalleunidadMnt = (VwArticulodetalleunidad)gvDetUnidad.GetFocusedRow();

                    if (vwArticulodetalleunidadMnt == null)
                    {
                        break;
                    }
                    vwArticulodetalleunidadMnt.Nombrearticulo = iNombrearticulo.Text;
                    articulounidadMntItemFrm = new ArticulounidadMntItemFrm(tipoMantenimientoItem, vwArticulodetalleunidadMnt);
                    articulounidadMntItemFrm.ShowDialog();

                    if (articulounidadMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        gcDetDato.RefreshDataSource();
                        var articulodetalleunidadMnt = new Articulodetalleunidad
                        {
                            Idarticulodetalleunidad = vwArticulodetalleunidadMnt.Idarticulodetalleunidad,
                            Idarticulo = IdEntidadMnt,
                            Idunidadmedida = vwArticulodetalleunidadMnt.Idunidadmedida,

                        };

                        Service.UpdateArticulodetalleunidad(articulodetalleunidadMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnDelUnidad":
                    var idarticulodetalleunidad = Convert.ToInt32(gvDetUnidad.GetRowCellValue(gvDetUnidad.FocusedRowHandle, "Idunidadmedida"));

                    if (idarticulodetalleunidad > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            Service.DeleteArticulodetalleunidad(idarticulodetalleunidad);

                            CargarDetalle();
                        }
                    }
                    break;
            }
        }
        private void iIdunidadinventario_AddNewValue(object sender, AddNewValueEventArgs e)
        {

            UnidadmedidaMntFrm unidadmedidaMntFrm = new UnidadmedidaMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            unidadmedidaMntFrm.ShowDialog();
            if (unidadmedidaMntFrm.IdEntidadMnt > 0)
            {
                //Tipoformato tipoFormato = Service.GetTipoformato(tipoFormatoMntFrm.IdEntidadMnt);
                Unidadmedida unidadmedida = unidadmedidaMntFrm.UnidadmedidaMnt;
                if (unidadmedida.Idunidadmedida > 0)
                {
                    UnidadmedidaList.Add(unidadmedida);
                    e.Cancel = false;
                    e.NewValue = unidadmedida.Idunidadmedida;
                }
            }
        }
        private void iIdarticuloclasificacion_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            ArticuloclasificacionMntFrm articuloclasificacionMntFrm = new ArticuloclasificacionMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            articuloclasificacionMntFrm.ShowDialog();
            if (articuloclasificacionMntFrm.IdEntidadMnt > 0)
            {
                //Tipoformato tipoFormato = Service.GetTipoformato(tipoFormatoMntFrm.IdEntidadMnt);
                Articuloclasificacion articuloclasificacion = articuloclasificacionMntFrm.ArticuloclasificacionMnt;
                if (articuloclasificacion.Idarticuloclasificacion > 0)
                {
                    VwArticuloclasificacion vwArticuloclasificacion =
                        Service.GetVwArticuloclasificacion(articuloclasificacion.Idarticuloclasificacion);
                    VwArticuloclasificacionList.Add(vwArticuloclasificacion);
                    e.Cancel = false;
                    e.NewValue = articuloclasificacion.Idarticuloclasificacion;
                }
            }
        }
        private void iIdmarca_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            MarcaMntFrm marcaMntFrm = new MarcaMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            marcaMntFrm.ShowDialog();
            if (marcaMntFrm.IdEntidadMnt > 0)
            {
                //Tipoformato tipoFormato = Service.GetTipoformato(tipoFormatoMntFrm.IdEntidadMnt);
                Marca marca = marcaMntFrm.MarcaMnt;
                if (marca.Idmarca > 0)
                {
                    MarcaList.Add(marca);
                    e.Cancel = false;
                    e.NewValue = marca.Idmarca;
                }
            }
        }
        private void cmdGenEan13_Click(object sender, EventArgs e)
        {
            if (Service.CodigoArticuloExiste(iCodigoarticulo.Text.Trim()))
            {
                iCodigoarticulo.EditValue = Service.GetSiguienteCodigoArticulo();
            }
            iCodigodebarra.EditValue = GenerarEan13();
        }
        private string GenerarEan13()
        {
            string nroRucEmpresaSel = SessionApp.EmpresaSel.Ruc.Trim();
            string codigoBarra12 = "775" + nroRucEmpresaSel.Substring(nroRucEmpresaSel.Length - 4) + iCodigoarticulo.Text.Trim();
            //string codigoBarra12 = "775" + "0885" + "43460";
            int iSum = 0;
            int iSumInpar = 0;
            int iDigit;
            string ean = codigoBarra12; // 12 digitos unicamente
            ean = ean.PadLeft(13, '0');
            for (int i = ean.Length; i >= 1; i--)
            {
                iDigit = Convert.ToInt32(ean.Substring(i - 1, 1));
                if (i % 2 != 0)
                {
                    iSumInpar += iDigit;
                }
                else
                {
                    iSum += iDigit;
                }
            }
            iDigit = (iSumInpar * 3) + iSum;
            int iCheckSum = (10 - (iDigit % 10)) % 10;
            return codigoBarra12 + iCheckSum;
        }
        private void iIdelementogasto_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            ElementogastoMntFrm elementogastoMntFrm = new ElementogastoMntFrm(0, TipoMantenimiento.Nuevo, null, null);
            elementogastoMntFrm.ShowDialog();
            if (elementogastoMntFrm.IdEntidadMnt > 0)
            {
                //Tipoformato tipoFormato = Service.GetTipoformato(tipoFormatoMntFrm.IdEntidadMnt);
                Elementogasto elementogasto = elementogastoMntFrm.ElementogastoMnt;
                if (elementogasto.Idelementogasto > 0)
                {
                    ElementogastoList.Add(elementogasto);
                    e.Cancel = false;
                    e.NewValue = elementogasto.Idelementogasto;
                }
            }
        }
        private void bmArticuloCompuesto_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            VwArticulocompuesto vwArticulocompuestoMnt = new VwArticulocompuesto();

            switch (e.Item.Name)
            {
                case "btnAgregarDetalle":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwArticulocompuestoMnt.Nombrearticulo = iNombrearticulo.Text;

                    ArticulocompuestoMntItemFrm articulocompuestoMntItemFrm = new ArticulocompuestoMntItemFrm(IdEntidadMnt, tipoMantenimientoItem, vwArticulocompuestoMnt);
                    articulocompuestoMntItemFrm.ShowDialog();

                    if (articulocompuestoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Articulocompuesto articulodetalleunidadMnt = new Articulocompuesto
                        {
                            Idarticulo = IdEntidadMnt,
                            Idunidadinventario = vwArticulocompuestoMnt.Idunidadinventario,
                            Cantidaddetalle = vwArticulocompuestoMnt.Cantidaddetalle,
                            Valorunitario = vwArticulocompuestoMnt.Valorunitario,
                            Idtipomoneda = vwArticulocompuestoMnt.Idtipomoneda,
                            Idarticulodetalle = vwArticulocompuestoMnt.Idarticulodetalle
                        };

                        Service.SaveArticulocompuesto(articulodetalleunidadMnt);
                        CargarDetalle();

                    }

                    break;

                case "btnEditDetalle":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwArticulocompuestoMnt = (VwArticulocompuesto)gvDetCompuesto.GetFocusedRow();

                    if (vwArticulocompuestoMnt == null)
                    {
                        break;
                    }
                    vwArticulocompuestoMnt.Nombrearticulo = iNombrearticulo.Text;
                    articulocompuestoMntItemFrm = new ArticulocompuestoMntItemFrm(IdEntidadMnt, tipoMantenimientoItem, vwArticulocompuestoMnt);
                    articulocompuestoMntItemFrm.ShowDialog();

                    if (articulocompuestoMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        Articulocompuesto articulodetalleunidadMnt = new Articulocompuesto
                        {
                            Idarticulocompuesto = vwArticulocompuestoMnt.Idarticulocompuesto,
                            Idarticulo = IdEntidadMnt,
                            Idunidadinventario = vwArticulocompuestoMnt.Idunidadinventario,
                            Cantidaddetalle = vwArticulocompuestoMnt.Cantidaddetalle,
                            Valorunitario = vwArticulocompuestoMnt.Valorunitario,
                            Idtipomoneda = vwArticulocompuestoMnt.Idtipomoneda,
                            Idarticulodetalle = vwArticulocompuestoMnt.Idarticulodetalle
                        };

                        Service.UpdateArticulocompuesto(articulodetalleunidadMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnDelDetalle":
                    var idarticulocompuesto = Convert.ToInt32(gvDetCompuesto.GetRowCellValue(gvDetCompuesto.FocusedRowHandle, "Idarticulocompuesto"));

                    if (idarticulocompuesto > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar Item", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            Service.DeleteArticulocompuesto(idarticulocompuesto);

                            CargarDetalle();
                        }
                    }
                    break;
            }
        }
        private void iIdtipoarticulo_EditValueChanged(object sender, EventArgs e)
        {
            EstadoPestaniaArticuloCompuesto();
            EstablecerControlSeries();
            EstablecerServicio();
        }

        private void EstablecerServicio()
        {
            var idTipoArticulo = iIdtipoarticulo.EditValue;
            if (idTipoArticulo != null && (int)idTipoArticulo == 4)
            {
                iIdmarca.Tag = null;
                iIdmarca.EditValue = null;
                iIdmarca.Enabled = false;

                iIdtipogestionarticulo.Tag = null;
                nPesoarticulo.Enabled = false;
                nPesoarticulo.EditValue = 0m;

                iVariacioncantidadentregada.Enabled = false;
                iVariacioncantidadentregada.EditValue = 0m;

                nStockminarticulo.Enabled = false;
                nStockminarticulo.EditValue = 0m;

                nStockmaximo.Enabled = false;
                nStockmaximo.EditValue = 0m;

                iStockcritico.Enabled = false;
                iStockcritico.EditValue = 0m;

                iStockreposicion.Enabled = false;
                iStockreposicion.EditValue = 0m;

                iMuevekardex.Enabled = false;
                iMuevekardex.Checked = false;

                iEsarticuloinventario.Enabled = false;
                iEsarticuloinventario.Checked = false;

                iEsarticulodecompra.Enabled = false;
                iEsarticulodecompra.Checked = false;

            }
            else
            {
                iIdmarca.Tag = "Seleccione la marca";

                iIdmarca.Enabled = true;
                nPesoarticulo.Enabled = true;

                iVariacioncantidadentregada.Enabled = true;

                nStockminarticulo.Enabled = true;

                nStockmaximo.Enabled = true;

                iStockcritico.Enabled = true;

                iStockreposicion.Enabled = true;

                iMuevekardex.Enabled = true;
                //iMuevekardex.Checked = true;

                iEsarticuloinventario.Enabled = true;
                //iEsarticuloinventario.Checked = true;

                iEsarticulodecompra.Enabled = true;
                //iEsarticulodecompra.Checked = true;

            }
        }

        private void EstablecerControlSeries()
        {
            iControldeserie.Enabled = false;
            iNumerodeserie.Enabled = false;

            var idTipoArticulo = iIdtipoarticulo.EditValue;
            if (idTipoArticulo != null)
            {
                switch ((int)idTipoArticulo)
                {
                    case 1: // ARTICULO
                        break;
                    case 2: // HERRAMIENTA
                    case 3: // EQUIPO
                    case 6: // ACTIVO FIJO
                        //iControldeserie.Enabled = true;
                        iNumerodeserie.Enabled = true;
                        break;
                    case 4: // SERVICIO
                        break;
                    case 5: // EPP
                        break;


                }
            }

        }

        private void EstadoPestaniaArticuloCompuesto()
        {
            var idTipoArticulo = iIdtipoarticulo.EditValue;
            if (idTipoArticulo != null && (int)idTipoArticulo == 1 && iEsarticulocompuesto.Checked) //Articulo
            {
                tpDetalleCompuesto.PageEnabled = true;
            }
            else
            {
                tpDetalleCompuesto.PageEnabled = false;
            }
        }
        private void iEsarticulocompuesto_CheckedChanged(object sender, EventArgs e)
        {
            EstadoPestaniaArticuloCompuesto();
        }
        private void iIdestadoarticulo_EditValueChanged(object sender, EventArgs e)
        {
            var idestadoarticulo = iIdestadoarticulo.EditValue;
            if (idestadoarticulo != null)
            {
                if ((int)idestadoarticulo == 1) //Activo
                {
                    rActivo.EditValue = true;
                    rActivo.Checked = true;
                }
                else
                {
                    rActivo.EditValue = false;
                    rActivo.Checked = false;
                }
            }
        }

        private void cmdAbriImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = @"Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.tif;"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                byte[] data = ByteImageConverter.ToByteArray(img, img.RawFormat);
                iImagenarticulo.EditValue = data;
            }
        }

        private decimal CostoPromedio(int idArticulo, DateTime fechaInicio, DateTime fechaFinal, int idEmpresa)
        {
            string sqlQuery = "inntecc.fnultimocostopromedioarticulo";
            object[] parametrosConsulta = { 
                        idArticulo,
                        fechaInicio,
                        fechaFinal,
                        idEmpresa
                    };
            DataTable dt = HelperDb.ExecuteStoreProcedure(sqlQuery, parametrosConsulta);
            DataRow dr = dt.Rows[0];
            return Convert.ToDecimal(dr["fnultimocostopromedioarticulo"]);
        }

        private void bmSeries_ItemClick(object sender, ItemClickEventArgs e)
        {
            var subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            TipoMantenimiento tipoMantenimientoItem;
            VwArticuloseriedet vwArticuloseriedet = new VwArticuloseriedet();

            switch (e.Item.Name)
            {
                case "btnAgregarSerie":

                    if (IdEntidadMnt == 0)
                    {
                        XtraMessageBox.Show("Grabe la información", "Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        break;
                    }

                    tipoMantenimientoItem = TipoMantenimiento.Nuevo;
                    vwArticuloseriedet.Nombrearticulo = iNombrearticulo.Text;
                    vwArticuloseriedet.Nombremarca = iIdmarca.Text;
                    vwArticuloseriedet.Nombreunidadmedida = iIdunidadinventario.Text;

                    var articuloserieMntItemFrm = new ArticuloserieMntItemFrm(tipoMantenimientoItem, vwArticuloseriedet);
                    articuloserieMntItemFrm.ShowDialog();

                    if (articuloserieMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        VwArticuloseriedetList.Add(vwArticuloseriedet);

                        Articuloseriedet articulodetalleunidadMnt = new Articuloseriedet()
                        {
                            Idarticulo = IdEntidadMnt,
                            Idseriearticulo = vwArticuloseriedet.Idseriearticulo
                        };

                        Service.SaveArticuloseriedet(articulodetalleunidadMnt);
                        CargarDetalle();

                    }

                    break;

                case "btnModificarSerie":
                    tipoMantenimientoItem = TipoMantenimiento.Modificar;

                    vwArticuloseriedet = (VwArticuloseriedet)gvSeries.GetFocusedRow();

                    if (vwArticuloseriedet == null)
                    {
                        break;
                    }
                    vwArticuloseriedet.Nombrearticulo = iNombrearticulo.Text;
                    vwArticuloseriedet.Nombremarca = iIdmarca.Text;
                    vwArticuloseriedet.Nombreunidadmedida = iIdunidadinventario.Text;

                    articuloserieMntItemFrm = new ArticuloserieMntItemFrm(tipoMantenimientoItem, vwArticuloseriedet);
                    articuloserieMntItemFrm.ShowDialog();

                    if (articuloserieMntItemFrm.DialogResult == DialogResult.OK)
                    {
                        gcDetDato.RefreshDataSource();
                        var articulodetalleunidadMnt = new Articuloseriedet
                        {
                            Idarticuloseriedet = vwArticuloseriedet.Idarticuloseriedet,
                            Idarticulo = IdEntidadMnt,
                            Idseriearticulo = vwArticuloseriedet.Idseriearticulo

                        };

                        Service.UpdateArticuloseriedet(articulodetalleunidadMnt);

                        CargarDetalle();

                    }

                    break;

                case "btnEliminarSerie":
                    var idarticuloseriedet = Convert.ToInt32(gvSeries.GetRowCellValue(gvSeries.FocusedRowHandle, "Idarticuloseriedet"));

                    if (idarticuloseriedet > 0)
                    {
                        if (DialogResult.Yes == XtraMessageBox.Show("¿Desea eliminar el item seleccionado?",
                            "Eliminar producto", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            Service.DeleteArticuloseriedet(idarticuloseriedet);
                            CargarDetalle();
                        }
                    }
                    break;
            }
        }
    }
}
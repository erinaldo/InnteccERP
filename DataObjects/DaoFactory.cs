namespace DataObjects
{
    public class DaoFactory : IDaoFactory
    {
        #region Almacen

        public IAlmacenDao AlmacenDao { get { return new AlmacenDao(); } }
        public IEntradaalmacenDao EntradaalmacenDao { get { return new EntradaalmacenDao(); } }
        public IEntradaalmacendetDao EntradaalmacendetDao { get { return new EntradaalmacendetDao(); } }
        public IEntradaalmacenubicacionDao EntradaalmacenubicacionDao { get { return new EntradaalmacenubicacionDao(); } }
        public IGuiaremisionDao GuiaremisionDao { get { return new GuiaremisionDao(); } }
        public IGuiaremisiondetDao GuiaremisiondetDao { get { return new GuiaremisiondetDao(); } }
        public ISalidaalmacenDao SalidaalmacenDao { get { return new SalidaalmacenDao(); } }
        public ISalidaalmacendetDao SalidaalmacendetDao { get { return new SalidaalmacendetDao(); } }
        public ISalidaalmacenubicacionDao SalidaalmacenubicacionDao { get { return new SalidaalmacenubicacionDao(); } }
        public IVwAlmacenDao VwAlmacenDao { get { return new VwAlmacenDao(); } }
        public IVwEntradaalmacenDao VwEntradaalmacenDao { get { return new VwEntradaalmacenDao(); } }
        public IVwEntradaalmacendetDao VwEntradaalmacendetDao { get { return new VwEntradaalmacendetDao(); } }
        public IVwGuiaremisionDao VwGuiaremisionDao { get { return new VwGuiaremisionDao(); } }
        public IVwGuiaremisiondetDao VwGuiaremisiondetDao { get { return new VwGuiaremisiondetDao(); } }
        public IVwSalidaalmacenDao VwSalidaalmacenDao { get { return new VwSalidaalmacenDao(); } }
        public IVwSalidaalmacendetDao VwSalidaalmacendetDao { get { return new VwSalidaalmacendetDao(); } }
        public IEntradaalmacenobsDao EntradaalmacenobsDao { get { return new EntradaalmacenobsDao(); } }
        public IEstadoarticuloingresoDao EstadoarticuloingresoDao { get { return new EstadoarticuloingresoDao(); } }
        public IVwEntradaalmacenobsDao VwEntradaalmacenobsDao { get { return new VwEntradaalmacenobsDao(); } }
        public IVwStockDao VwStockDao { get { return new VwStockDao(); } }
        public IEstadoreclamoDao EstadoreclamoDao { get { return new EstadoreclamoDao(); } }
        public IInventarioDao InventarioDao { get { return new InventarioDao(); } }
        public IInventariostockDao InventariostockDao { get { return new InventariostockDao(); } }
        public IInventarioubicacionDao InventarioubicacionDao { get { return new InventarioubicacionDao(); } }
        public IUbicacionDao UbicacionDao { get { return new UbicacionDao(); } }
        public IVwInventarioDao VwInventarioDao { get { return new VwInventarioDao(); } }
        public IVwInventariostockDao VwInventariostockDao { get { return new VwInventariostockDao(); } }
        public IVwInventarioubicacionDao VwInventarioubicacionDao { get { return new VwInventarioubicacionDao(); } }
        public IVwUbicacionDao VwUbicacionDao { get { return new VwUbicacionDao(); } }
        public IVwEntradaalmacenubicacionDao VwEntradaalmacenubicacionDao { get { return new VwEntradaalmacenubicacionDao(); } }
        public IVwSalidaalmacenubicacionDao VwSalidaalmacenubicacionDao { get { return new VwSalidaalmacenubicacionDao(); } }
        public IVwGuiaremisionimpsalidaalmacenDao VwGuiaremisionimpsalidaalmacenDao { get { return new VwGuiaremisionimpsalidaalmacenDao(); } }
        public IVwOrdencompraimpentradaalmacenDao VwOrdencompraimpentradaalmacenDao { get { return new VwOrdencompraimpentradaalmacenDao(); } }
        public IVwGuiaremisiondetimpcpventadetDao VwGuiaremisiondetimpcpventadetDao { get { return new VwGuiaremisiondetimpcpventadetDao(); } }
        public IGuiaremisiondetimpcpventadetDao GuiaremisiondetimpcpventadetDao { get { return new GuiaremisiondetimpcpventadetDao(); } }
        public IVwSalidaalmacendetimpentradaalmacenDao VwSalidaalmacendetimpentradaalmacenDao { get { return new VwSalidaalmacendetimpentradaalmacenDao(); } }
        public IVwCpcompradetimpentradaalmacenDao VwCpcompradetimpentradaalmacenDao { get { return new VwCpcompradetimpentradaalmacenDao(); } }
        public IVwRendicioncajachicaimpsalidaalmacenDao VwRendicioncajachicaimpsalidaalmacenDao { get { return new VwRendicioncajachicaimpsalidaalmacenDao(); } }
        public IVwNotacreditocliimpentradaalmacenDao VwNotacreditocliimpentradaalmacenDao { get { return new VwNotacreditocliimpentradaalmacenDao(); } }
        public IVwEntradaalmacendetimpguiaremisionDao VwEntradaalmacendetimpguiaremisionDao { get { return new VwEntradaalmacendetimpguiaremisionDao(); } }
        public IVwEntradaalmacendetverificacioncantidadDao VwEntradaalmacendetverificacioncantidadDao { get { return new VwEntradaalmacendetverificacioncantidadDao(); } }
        public IVwSalidaalmacendetverificacioncantidadDao VwSalidaalmacendetverificacioncantidadDao { get { return new VwSalidaalmacendetverificacioncantidadDao(); } }
        public IEntradaalmacendetitemcpcompradetDao EntradaalmacendetitemcpcompradetDao { get { return new EntradaalmacendetitemcpcompradetDao(); } }
        public IInventarioinicialDao InventarioinicialDao { get { return new InventarioinicialDao(); } }
        public IVwInventarioinicialDao VwInventarioinicialDao { get { return new VwInventarioinicialDao(); } }
        public IInventariostockdetserieDao InventariostockdetserieDao { get { return new InventariostockdetserieDao(); } }
        public IVwInventariostockdetserieDao VwInventariostockdetserieDao { get { return new VwInventariostockdetserieDao(); } }
        public IVwCpventaimpsalidaalmacenDao VwCpventaimpsalidaalmacenDao { get { return new VwCpventaimpsalidaalmacenDao(); } }
        #endregion

        #region Caja
        public ICierrecajaDao CierrecajaDao { get { return new CierrecajaDao(); } }
        public ICierrecajadetDao CierrecajadetDao { get { return new CierrecajadetDao(); } }
        public IVwCierrecajaDao VwCierrecajaDao { get { return new VwCierrecajaDao(); } }
        public IVwCierrecajadetDao VwCierrecajadetDao { get { return new VwCierrecajadetDao(); } }
        public IVwCierrecajaimpresionDao VwCierrecajaimpresionDao { get { return new VwCierrecajaimpresionDao(); } }
        public IVwReciboresumenDao VwReciboresumenDao { get { return new VwReciboresumenDao(); } }
        #endregion

        #region Compras

        public ICpcompraDao CpcompraDao { get { return new CpcompraDao(); } }
        public ICpcompradetDao CpcompradetDao { get { return new CpcompradetDao(); } }
        public IOrdencompraDao OrdencompraDao { get { return new OrdencompraDao(); } }
        public IOrdencompradetDao OrdencompradetDao { get { return new OrdencompradetDao(); } }
        public IRequerimientoDao RequerimientoDao { get { return new RequerimientoDao(); } }
        public IRequerimientodetDao RequerimientodetDao { get { return new RequerimientodetDao(); } }
        public IVwRequerimientoDao VwRequerimientoDao { get { return new VwRequerimientoDao(); } }
        public IVwRequerimientodetDao VwRequerimientodetDao { get { return new VwRequerimientodetDao(); } }
        public IVwRequerimientoimpresionDao VwRequerimientoimpresionDao { get { return new VwRequerimientoimpresionDao(); } }
        public IVwOrdencompraDao VwOrdencompraDao { get { return new VwOrdencompraDao(); } }
        public IVwOrdencompradetDao VwOrdencompradetDao { get { return new VwOrdencompradetDao(); } }
        public IVwCpcompraDao VwCpcompraDao { get { return new VwCpcompraDao(); } }
        public IVwCpcompradetDao VwCpcompradetDao { get { return new VwCpcompradetDao(); } }
        public IVwRequerimientodetordcompraimpDao VwRequerimientodetordcompraimpDao { get { return new VwRequerimientodetordcompraimpDao(); } }
        public IVwRequerimientosaaprobarDao VwRequerimientosaaprobarDao { get { return new VwRequerimientosaaprobarDao(); } }
        public IVwOrdencompraimpresionDao VwOrdencompraimpresionDao { get { return new VwOrdencompraimpresionDao(); } }
        public IVwOrdencompradetingresoimpDao VwOrdencompradetingresoimpDao { get { return new VwOrdencompradetingresoimpDao(); } }
        public IVwOrdencompradetcpcompraimpDao VwOrdencompradetcpcompraimpDao { get { return new VwOrdencompradetcpcompraimpDao(); } }
        public INotacreditoDao NotacreditoDao { get { return new NotacreditoDao(); } }
        public INotacreditodetDao NotacreditodetDao { get { return new NotacreditodetDao(); } }
        public IVwNotacreditoDao VwNotacreditoDao { get { return new VwNotacreditoDao(); } }
        public IVwNotacreditodetDao VwNotacreditodetDao { get { return new VwNotacreditodetDao(); } }
        public IEstadopagoDao EstadopagoDao { get { return new EstadopagoDao(); } }
        public INotadebitoDao NotadebitoDao { get { return new NotadebitoDao(); } }
        public INotadebitodetDao NotadebitodetDao { get { return new NotadebitodetDao(); } }
        public IVwNotadebitoDao VwNotadebitoDao { get { return new VwNotadebitoDao(); } }
        public IVwNotadebitodetDao VwNotadebitodetDao { get { return new VwNotadebitodetDao(); } }
        public IVwCpcompraimpncDao VwCpcompraimpncDao { get { return new VwCpcompraimpncDao(); } }
        public IVwCpcompraimpndDao VwCpcompraimpndDao { get { return new VwCpcompraimpndDao(); } }
        public ICotizacionprvDao CotizacionprvDao { get { return new CotizacionprvDao(); } }
        public ICotizacionprvdetDao CotizacionprvdetDao { get { return new CotizacionprvdetDao(); } }
        public ICuadrocomparativoDao CuadrocomparativoDao { get { return new CuadrocomparativoDao(); } }
        public ICuadrocomparativoarticuloDao CuadrocomparativoarticuloDao { get { return new CuadrocomparativoarticuloDao(); } }
        public ICuadrocomparativoprvDao CuadrocomparativoprvDao { get { return new CuadrocomparativoprvDao(); } }
        public IVwCotizacionprvDao VwCotizacionprvDao { get { return new VwCotizacionprvDao(); } }
        public IVwCotizacionprvdetDao VwCotizacionprvdetDao { get { return new VwCotizacionprvdetDao(); } }
        public IVwCuadrocomparativoDao VwCuadrocomparativoDao { get { return new VwCuadrocomparativoDao(); } }
        public IVwCuadrocomparativoarticuloDao VwCuadrocomparativoarticuloDao { get { return new VwCuadrocomparativoarticuloDao(); } }
        public IVwCuadrocomparativoprvDao VwCuadrocomparativoprvDao { get { return new VwCuadrocomparativoprvDao(); } }
        public IVwRequerimientodetcotizaprvimpDao VwRequerimientodetcotizaprvimpDao { get { return new VwRequerimientodetcotizaprvimpDao(); } }
        public IVwRequerimientodetimpguiaremisionDao VwRequerimientodetimpguiaremisionDao { get { return new VwRequerimientodetimpguiaremisionDao(); } }
        public ITiporegistroordenDao TiporegistroordenDao { get { return new TiporegistroordenDao(); } }
        public IVwCuadrocomparativoarticuloimpocDao VwCuadrocomparativoarticuloimpocDao { get { return new VwCuadrocomparativoarticuloimpocDao(); } }
        public IVwCuadrocomparativoaaprobarDao VwCuadrocomparativoaaprobarDao { get { return new VwCuadrocomparativoaaprobarDao(); } }
        public IVwCuadrocomparativomodeloautorizacionDao VwCuadrocomparativomodeloautorizacionDao { get { return new VwCuadrocomparativomodeloautorizacionDao(); } }
        public IOrdenservicioDao OrdenservicioDao { get { return new OrdenservicioDao(); } }
        public IOrdenserviciodetDao OrdenserviciodetDao { get { return new OrdenserviciodetDao(); } }
        public IVwCuadrocomparativoarticuloimposDao VwCuadrocomparativoarticuloimposDao { get { return new VwCuadrocomparativoarticuloimposDao(); } }
        public IVwOrdenservicioDao VwOrdenservicioDao { get { return new VwOrdenservicioDao(); } }
        public IVwOrdenserviciodetDao VwOrdenserviciodetDao { get { return new VwOrdenserviciodetDao(); } }
        public IVwOrdenservicioimpresionDao VwOrdenservicioimpresionDao { get { return new VwOrdenservicioimpresionDao(); } }
        public IVwRequerimientodetordservicioimpDao VwRequerimientodetordservicioimpDao { get { return new VwRequerimientodetordservicioimpDao(); } }
        public IVwOrdenserviciodetcpcompraimpDao VwOrdenserviciodetcpcompraimpDao { get { return new VwOrdenserviciodetcpcompraimpDao(); } }
        public IVwCpcompradetguiaremisionimpDao VwCpcompradetguiaremisionimpDao { get { return new VwCpcompradetguiaremisionimpDao(); } }
        public ICpcompradetserieDao CpcompradetserieDao { get { return new CpcompradetserieDao(); } }
        public IVwCpcompradetserieDao VwCpcompradetserieDao { get { return new VwCpcompradetserieDao(); } }
        #endregion

        #region Finanzas  
        public ITiporecibocajaDao TiporecibocajaDao { get { return new TiporecibocajaDao(); } }
        public IVwCtacteclienteDao VwCtacteclienteDao { get { return new VwCtacteclienteDao(); } }
        public IRendicioncajachicaDao RendicioncajachicaDao { get { return new RendicioncajachicaDao(); } }
        public IRendicioncajachicadetDao RendicioncajachicadetDao { get { return new RendicioncajachicadetDao(); } }
        public IVwRendicioncajachicaDao VwRendicioncajachicaDao { get { return new VwRendicioncajachicaDao(); } }
        public IVwRendicioncajachicadetDao VwRendicioncajachicadetDao { get { return new VwRendicioncajachicadetDao(); } }

        public IRecibocajaingresoDao RecibocajaingresoDao { get { return new RecibocajaingresoDao(); } }
        public IRecibocajaingresodetDao RecibocajaingresodetDao { get { return new RecibocajaingresodetDao(); } }
        public IRecibocajaingresoimprevistoDao RecibocajaingresoimprevistoDao { get { return new RecibocajaingresoimprevistoDao(); } }
        public IVwRecibocajaingresoDao VwRecibocajaingresoDao { get { return new VwRecibocajaingresoDao(); } }
        public IVwRecibocajaingresodetDao VwRecibocajaingresodetDao { get { return new VwRecibocajaingresodetDao(); } }
        public IVwRecibocajaingresoimprevistoDao VwRecibocajaingresoimprevistoDao { get { return new VwRecibocajaingresoimprevistoDao(); } }
        public IRecibocajaegresoDao RecibocajaegresoDao { get { return new RecibocajaegresoDao(); } }
        public IRecibocajaegresodetDao RecibocajaegresodetDao { get { return new RecibocajaegresodetDao(); } }
        public IRecibocajaegresoimprevistoDao RecibocajaegresoimprevistoDao { get { return new RecibocajaegresoimprevistoDao(); } }
        public IVwRecibocajaegresoDao VwRecibocajaegresoDao { get { return new VwRecibocajaegresoDao(); } }
        public IVwRecibocajaegresodetDao VwRecibocajaegresodetDao { get { return new VwRecibocajaegresodetDao(); } }
        public IVwRecibocajaegresoimprevistoDao VwRecibocajaegresoimprevistoDao { get { return new VwRecibocajaegresoimprevistoDao(); } }

        public IVwCtacteproveedorDao VwCtacteproveedorDao { get { return new VwCtacteproveedorDao(); } }

        #endregion

        #region Inntecc
        public IAccesoformDao AccesoformDao { get { return new AccesoformDao(); } }
        public IAreaDao AreaDao { get { return new AreaDao(); } }
        public IAreacentrocostroDao AreacentrocostroDao { get { return new AreacentrocostroDao(); } }
        public IArticuloDao ArticuloDao { get { return new ArticuloDao(); } }
        public IArticuloclasificacionDao ArticuloclasificacionDao { get { return new ArticuloclasificacionDao(); } }
        public IArticulodetalleunidadDao ArticulodetalleunidadDao { get { return new ArticulodetalleunidadDao(); } }
        public IArticuloimagenDao ArticuloimagenDao { get { return new ArticuloimagenDao(); } }
        public IArticuloubicacionDao ArticuloubicacionDao { get { return new ArticuloubicacionDao(); } }
        public ICentrodecostoDao CentrodecostoDao { get { return new CentrodecostoDao(); } }
        public ICptooperacionDao CptooperacionDao { get { return new CptooperacionDao(); } }
        public ICuentacontableDao CuentacontableDao { get { return new CuentacontableDao(); } }
        public IDepartamentoDao DepartamentoDao { get { return new DepartamentoDao(); } }
        public IDistritoDao DistritoDao { get { return new DistritoDao(); } }
        public IEjercicioDao EjercicioDao { get { return new EjercicioDao(); } }
        public IEmpleadoDao EmpleadoDao { get { return new EmpleadoDao(); } }
        public IEmpleadoanexoDao EmpleadoanexoDao { get { return new EmpleadoanexoDao(); } }
        public IEmpresaDao EmpresaDao { get { return new EmpresaDao(); } }
        public IEntidadfinancieraDao EntidadfinancieraDao { get { return new EntidadfinancieraDao(); } }
        public IGrupousuarioDao GrupousuarioDao { get { return new GrupousuarioDao(); } }
        public IImpuestoDao ImpuestoDao { get { return new ImpuestoDao(); } }
        public IImpuestoiscDao ImpuestoiscDao { get { return new ImpuestoiscDao(); } }
        public IListaprecioDao ListaprecioDao { get { return new ListaprecioDao(); } }
        public IMarcaDao MarcaDao { get { return new MarcaDao(); } }
        public IPeriodoDao PeriodoDao { get { return new PeriodoDao(); } }
        public IPersonaDao PersonaDao { get { return new PersonaDao(); } }
        public IPersonacontactoDao PersonacontactoDao { get { return new PersonacontactoDao(); } }
        public IPrioridadDao PrioridadDao { get { return new PrioridadDao(); } }
        public IProvinciaDao ProvinciaDao { get { return new ProvinciaDao(); } }
        public IProyectoDao ProyectoDao { get { return new ProyectoDao(); } }
        public ISocionegentidadfinancieraDao SocionegentidadfinancieraDao { get { return new SocionegentidadfinancieraDao(); } }
        public ISocionegocioDao SocionegocioDao { get { return new SocionegocioDao(); } }
        public ISocionegociocontactoDao SocionegociocontactoDao { get { return new SocionegociocontactoDao(); } }
        public ISocionegociodireccionDao SocionegociodireccionDao { get { return new SocionegociodireccionDao(); } }
        public ISocionegociolimitecreditoDao SocionegociolimitecreditoDao { get { return new SocionegociolimitecreditoDao(); } }
        public ISocionegocioproyectoDao SocionegocioproyectoDao { get { return new SocionegocioproyectoDao(); } }
        public ISucursalDao SucursalDao { get { return new SucursalDao(); } }
        public ITipocondicionDao TipocondicionDao { get { return new TipocondicionDao(); } }
        public ITipocpDao TipocpDao { get { return new TipocpDao(); } }
        public ITipocppagoDao TipocppagoDao { get { return new TipocppagoDao(); } }
        public ITipodocentidadDao TipodocentidadDao { get { return new TipodocentidadDao(); } }
        public ITipoformatoDao TipoformatoDao { get { return new TipoformatoDao(); } }
        public ITipolistaDao TipolistaDao { get { return new TipolistaDao(); } }
        public ITipomediopagoDao TipomediopagoDao { get { return new TipomediopagoDao(); } }
        public ITipomonedaDao TipomonedaDao { get { return new TipomonedaDao(); } }
        public ITipooperacionDao TipooperacionDao { get { return new TipooperacionDao(); } }
        public ITiposcontactoDao TiposcontactoDao { get { return new TiposcontactoDao(); } }
        public ITiposocioDao TiposocioDao { get { return new TiposocioDao(); } }
        public IUnidadmedidaDao UnidadmedidaDao { get { return new UnidadmedidaDao(); } }
        public IUsuarioDao UsuarioDao { get { return new UsuarioDao(); } }
        public IVwPersonaDao VwPersonaDao { get { return new VwPersonaDao(); } }
        public IVwSucursalDao VwSucursalDao { get { return new VwSucursalDao(); } }
        public IVwTipocpDao VwTipocpDao { get { return new VwTipocpDao(); } }
        public IVwUbigeoDao VwUbigeoDao { get { return new VwUbigeoDao(); } }
        public IVwAreaDao VwAreaDao { get { return new VwAreaDao(); } }
        public IVwPersonacontactoDao VwPersonacontactoDao { get { return new VwPersonacontactoDao(); } }
        public IVwSocionegocioDao VwSocionegocioDao { get { return new VwSocionegocioDao(); } }
        public IVwEmpleadoDao VwEmpleadoDao { get { return new VwEmpleadoDao(); } }
        public IVwListaprecioDao VwListaprecioDao { get { return new VwListaprecioDao(); } }
        public IVwArticuloDao VwArticuloDao { get { return new VwArticuloDao(); } }
        public IVwPeriodoDao VwPeriodoDao { get { return new VwPeriodoDao(); } }
        public ITipodocmovDao TipodocmovDao { get { return new TipodocmovDao(); } }
        public IVwCptooperacionDao VwCptooperacionDao { get { return new VwCptooperacionDao(); } }
        public IVwUsuarioDao VwUsuarioDao { get { return new VwUsuarioDao(); } }
        public IVwProyectoDao VwProyectoDao { get { return new VwProyectoDao(); } }
        public IEstadoreqDao EstadoreqDao { get { return new EstadoreqDao(); } }
        public IVwArticulodetalleunidadDao VwArticulodetalleunidadDao { get { return new VwArticulodetalleunidadDao(); } }
        public IVwArticuloubicacionDao VwArticuloubicacionDao { get { return new VwArticuloubicacionDao(); } }
        public IEmpleadoareaDao EmpleadoareaDao { get { return new EmpleadoareaDao(); } }
        public IEmpleadoareaproyectoDao EmpleadoareaproyectoDao { get { return new EmpleadoareaproyectoDao(); } }
        public IVwEmpleadoareaDao VwEmpleadoareaDao { get { return new VwEmpleadoareaDao(); } }
        public IVwEmpleadoareaproyectoDao VwEmpleadoareaproyectoDao { get { return new VwEmpleadoareaproyectoDao(); } }
        public IValorpordefectoDao ValorpordefectoDao { get { return new ValorpordefectoDao(); } }
        public IVwAccesoformDao VwAccesoformDao { get { return new VwAccesoformDao(); } }
        public IVwGrupousuarioitemDao VwGrupousuarioitemDao { get { return new VwGrupousuarioitemDao(); } }
        public IVwPaginaitemDao VwPaginaitemDao { get { return new VwPaginaitemDao(); } }
        public IGrupousuarioitemDao GrupousuarioitemDao { get { return new GrupousuarioitemDao(); } }
        public IVwAccesoopcionDao VwAccesoopcionDao { get { return new VwAccesoopcionDao(); } }
        public IVwSocionegociodireccionDao VwSocionegociodireccionDao { get { return new VwSocionegociodireccionDao(); } }
        public IVwSocionegociolimitecreditoDao VwSocionegociolimitecreditoDao { get { return new VwSocionegociolimitecreditoDao(); } }
        public ITipoafectacionigvDao TipoafectacionigvDao { get { return new TipoafectacionigvDao(); } }
        public IVwSocionegentidadfinancieraDao VwSocionegentidadfinancieraDao { get { return new VwSocionegentidadfinancieraDao(); } }
        public IVwSocionegocioproyectoDao VwSocionegocioproyectoDao { get { return new VwSocionegocioproyectoDao(); } }
        public IVwCentrodecostoDao VwCentrodecostoDao { get { return new VwCentrodecostoDao(); } }
        public IAutorizaciontipocondicionDao AutorizaciontipocondicionDao { get { return new AutorizaciontipocondicionDao(); } }
        public IEtapaautorizacionDao EtapaautorizacionDao { get { return new EtapaautorizacionDao(); } }
        public IEtapaautorizaciondetalleDao EtapaautorizaciondetalleDao { get { return new EtapaautorizaciondetalleDao(); } }
        public IModeloautorizacionDao ModeloautorizacionDao { get { return new ModeloautorizacionDao(); } }
        public IModeloautorizacioncondicionDao ModeloautorizacioncondicionDao { get { return new ModeloautorizacioncondicionDao(); } }
        public IModeloautorizacionetapaDao ModeloautorizacionetapaDao { get { return new ModeloautorizacionetapaDao(); } }
        public ITiporatioDao TiporatioDao { get { return new TiporatioDao(); } }
        public IVwEtapaautorizacionDao VwEtapaautorizacionDao { get { return new VwEtapaautorizacionDao(); } }
        public IVwEtapaautorizaciondetalleDao VwEtapaautorizaciondetalleDao { get { return new VwEtapaautorizaciondetalleDao(); } }
        public IVwModeloautorizacionDao VwModeloautorizacionDao { get { return new VwModeloautorizacionDao(); } }
        public IVwModeloautorizacioncondicionDao VwModeloautorizacioncondicionDao { get { return new VwModeloautorizacioncondicionDao(); } }
        public IVwModeloautorizacionetapaDao VwModeloautorizacionetapaDao { get { return new VwModeloautorizacionetapaDao(); } }
        public IDocumentoaprobacionDao DocumentoaprobacionDao { get { return new DocumentoaprobacionDao(); } }
        public IVwModeloautorizacioninfoDao VwModeloautorizacioninfoDao { get { return new VwModeloautorizacioninfoDao(); } }
        public IVwDocumentoaprobacionDao VwDocumentoaprobacionDao { get { return new VwDocumentoaprobacionDao(); } }
        public ITipoarticuloDao TipoarticuloDao { get { return new TipoarticuloDao(); } }
        public IElementogastoDao ElementogastoDao { get { return new ElementogastoDao(); } }
        public IVwReporteusuarioDao VwReporteusuarioDao { get { return new VwReporteusuarioDao(); } }
        public IArticulocompuestoDao ArticulocompuestoDao { get { return new ArticulocompuestoDao(); } }
        public IVwArticulocompuestoDao VwArticulocompuestoDao { get { return new VwArticulocompuestoDao(); } }
        public IVwArticuloinventarioDao VwArticuloinventarioDao { get { return new VwArticuloinventarioDao(); } }
        public IVwArticulounidadDao VwArticulounidadDao { get { return new VwArticulounidadDao(); } }
        public IReporteDao ReporteDao { get { return new ReporteDao(); } }
        public ITipocambioDao TipocambioDao { get { return new TipocambioDao(); } }
        public IVwTipocambioDao VwTipocambioDao { get { return new VwTipocambioDao(); } }
        public ITipogestionarticuloDao TipogestionarticuloDao { get { return new TipogestionarticuloDao(); } }
        public IEstadoarticuloDao EstadoarticuloDao { get { return new EstadoarticuloDao(); } }
        public ICategoriasocionegocioDao CategoriasocionegocioDao { get { return new CategoriasocionegocioDao(); } }
        public IGrupoeconomicoDao GrupoeconomicoDao { get { return new GrupoeconomicoDao(); } }
        public IPaisDao PaisDao { get { return new PaisDao(); } }
        public IRubronegocioDao RubronegocioDao { get { return new RubronegocioDao(); } }
        public ISocionegociogarantiaDao SocionegociogarantiaDao { get { return new SocionegociogarantiaDao(); } }
        public ISocionegociomarcaDao SocionegociomarcaDao { get { return new SocionegociomarcaDao(); } }
        public ITipogarantiaDao TipogarantiaDao { get { return new TipogarantiaDao(); } }
        public IVwSocionegociogarantiaDao VwSocionegociogarantiaDao { get { return new VwSocionegociogarantiaDao(); } }
        public IVwSocionegociomarcaDao VwSocionegociomarcaDao { get { return new VwSocionegociomarcaDao(); } }
        public IZonaDao ZonaDao { get { return new ZonaDao(); } }
        public IEstadosocionegocioDao EstadosocionegocioDao { get { return new EstadosocionegocioDao(); } }
        public ITipolistatipocondicionDao TipolistatipocondicionDao { get { return new TipolistatipocondicionDao(); } }
        public IVwTipolistatipocondicionDao VwTipolistatipocondicionDao { get { return new VwTipolistatipocondicionDao(); } }
        public IVwArticuloclasificacionDao VwArticuloclasificacionDao { get { return new VwArticuloclasificacionDao(); } }
        public IEstadocivilDao EstadocivilDao { get { return new EstadocivilDao(); } }
        public ITipocontratoempleadoDao TipocontratoempleadoDao { get { return new TipocontratoempleadoDao(); } }
        public ITiposnpDao TiposnpDao { get { return new TiposnpDao(); } }
        public IArticuloseriedetDao ArticuloseriedetDao { get { return new ArticuloseriedetDao(); } }
        public ISeriearticuloDao SeriearticuloDao { get { return new SeriearticuloDao(); } }
        public IVwArticuloseriedetDao VwArticuloseriedetDao { get { return new VwArticuloseriedetDao(); } }
        public IDiaferiadoDao DiaferiadoDao { get { return new DiaferiadoDao(); } }
        #endregion

        #region Ventas

        public IArticulolistaprecioDao ArticulolistaprecioDao { get { return new ArticulolistaprecioDao(); } }
        public ICotizacionclienteDao CotizacionclienteDao { get { return new CotizacionclienteDao(); } }
        public ICotizacionclientedetDao CotizacionclientedetDao { get { return new CotizacionclientedetDao(); } }
        public ICpventaDao CpventaDao { get { return new CpventaDao(); } }
        public ICpventadetDao CpventadetDao { get { return new CpventadetDao(); } }
        public IGuiaremisionmotivoDao GuiaremisionmotivoDao { get { return new GuiaremisionmotivoDao(); } }
        public IOrdendeventaDao OrdendeventaDao { get { return new OrdendeventaDao(); } }
        public IOrdendeventadetDao OrdendeventadetalleDao { get { return new OrdendeventadetalleDao(); } }
        public IVwCotizacionclienteDao VwCotizacionclienteDao { get { return new VwCotizacionclienteDao(); } }
        public IVwCotizacionclientedetDao VwCotizacionclientedetDao { get { return new VwCotizacionclientedetDao(); } }
        public IVwOrdendeventaDao VwOrdendeventaDao { get { return new VwOrdendeventaDao(); } }
        public IVwOrdendeventadetalleDao VwOrdendeventadetalleDao { get { return new VwOrdendeventadetDao(); } }
        public IVwCpventaDao VwCpventaDao { get { return new VwCpventaDao(); } }
        public IVwCpventadetDao VwCpventadetDao { get { return new VwCpventadetDao(); } }
        public IVwArticulolistaprecioDao VwArticulolistaprecioDao { get { return new VwArticulolistaprecioDao(); } }
        public INotacreditocliDao NotacreditocliDao { get { return new NotacreditocliDao(); } }
        public INotacreditoclidetDao NotacreditoclidetDao { get { return new NotacreditoclidetDao(); } }
        public INotadebitocliDao NotadebitocliDao { get { return new NotadebitocliDao(); } }
        public IVwCpventaimpncDao VwCpventaimpncDao { get { return new VwCpventaimpncDao(); } }
        public IVwCpventaimpndDao VwCpventaimpndDao { get { return new VwCpventaimpndDao(); } }
        public IVwNotacreditocliDao VwNotacreditocliDao { get { return new VwNotacreditocliDao(); } }
        public IVwNotacreditoclidetDao VwNotacreditoclidetDao { get { return new VwNotacreditoclidetDao(); } }
        public IVwNotadebitocliDao VwNotadebitocliDao { get { return new VwNotadebitocliDao(); } }
        public INotadebitoclidetDao NotadebitoclidetDao { get { return new NotadebitoclidetDao(); } }
        public IVwNotadebitoclidetDao VwNotadebitoclidetDao { get { return new VwNotadebitoclidetDao(); } }
        public IVwCotizacionclientedetovimpDao VwCotizacionclientedetovimpDao { get { return new VwCotizacionclientedetovimpDao(); } }
        public IVwOrdendeventadetcpventaimpDao VwOrdendeventadetcpventaimpDao { get { return new VwOrdendeventadetcpventaimpDao(); } }
        public IVwOrdendeventadetvalorizaimpDao VwOrdendeventadetvalorizaimpDao { get { return new VwOrdendeventadetvalorizaimpDao(); } }
        public IVwArticulostocklistaDao VwArticulostocklistaDao { get { return new VwArticulostocklistaDao(); } }
        public IVwOrdendeventadetimpguiaremisionDao VwOrdendeventadetimpguiaremisionDao { get { return new VwOrdendeventadetimpguiaremisionDao(); } }
        public IVwOrdendeventavalorizacpventaimpDao VwOrdendeventavalorizacpventaimpDao { get { return new VwOrdendeventavalorizacpventaimpDao(); } }
        public IComisioncobroDao ComisioncobroDao { get { return new ComisioncobroDao(); } }
        public IComisioncobrodetDao ComisioncobrodetDao { get { return new ComisioncobrodetDao(); } }
        public ITipocomisioncobroDao TipocomisioncobroDao { get { return new TipocomisioncobroDao(); } }
        public IVwComisioncobroDao VwComisioncobroDao { get { return new VwComisioncobroDao(); } }
        public IDetraccionclienteDao DetraccionclienteDao { get { return new DetraccionclienteDao(); } }
        public IVwDetraccionclienteDao VwDetraccionclienteDao { get { return new VwDetraccionclienteDao(); } }
        public ICpventadetserieDao CpventadetserieDao { get { return new CpventadetserieDao(); } }
        public IVwCpventadetserieDao VwCpventadetserieDao { get { return new VwCpventadetserieDao(); } }
        public IVwNotacreditoclireciboingresoimpDao VwNotacreditoclireciboingresoimpDao { get { return new VwNotacreditoclireciboingresoimpDao(); } }
        #endregion

        #region Logistica
         public ILogStocksDao LogStocksDao { get { return new LogStocksDao(); } }
        #endregion

        #region Maquinaria
        public IClasificacionequipoDao ClasificacionequipoDao { get { return new ClasificacionequipoDao(); } }
        public IEquipoDao EquipoDao { get { return new EquipoDao(); } }
        public IMarcaequipoDao MarcaequipoDao { get { return new MarcaequipoDao(); } }
        public IModeloequipoDao ModeloequipoDao { get { return new ModeloequipoDao(); } }
        public IVwEquipoDao VwEquipoDao { get { return new VwEquipoDao(); } }
        public IVwModeloequipoDao VwModeloequipoDao { get { return new VwModeloequipoDao(); } }
        public ITipoalquilerDao TipoalquilerDao { get { return new TipoalquilerDao(); } }
        public ITipoegresovalorizacionDao TipoegresovalorizacionDao { get { return new TipoegresovalorizacionDao(); } }
        public IValorizacionDao ValorizacionDao { get { return new ValorizacionDao(); } }
        public IValorizaciondetDao ValorizaciondetDao { get { return new ValorizaciondetDao(); } }
        public IValorizacionegresoDao ValorizacionegresoDao { get { return new ValorizacionegresoDao(); } }
        public IVwValorizacionDao VwValorizacionDao { get { return new VwValorizacionDao(); } }
        public IVwValorizaciondetDao VwValorizaciondetDao { get { return new VwValorizaciondetDao(); } }
        public IVwValorizacionegresoDao VwValorizacionegresoDao { get { return new VwValorizacionegresoDao(); } }
        public IValorizacionegresoproveedorDao ValorizacionegresoproveedorDao { get { return new ValorizacionegresoproveedorDao(); } }
        public IValorizacionproveedorDao ValorizacionproveedorDao { get { return new ValorizacionproveedorDao(); } }
        public IValorizacionproveedordetDao ValorizacionproveedordetDao { get { return new ValorizacionproveedordetDao(); } }
        public IVwValorizacionegresoproveedorDao VwValorizacionegresoproveedorDao { get { return new VwValorizacionegresoproveedorDao(); } }
        public IVwValorizacionproveedorDao VwValorizacionproveedorDao { get { return new VwValorizacionproveedorDao(); } }
        public IVwValorizacionproveedordetDao VwValorizacionproveedordetDao { get { return new VwValorizacionproveedordetDao(); } }
        public IVwOrdendeserviciodetvalorizaimpDao VwOrdendeserviciodetvalorizaimpDao { get { return new VwOrdendeserviciodetvalorizaimpDao(); } }
        public IMantenimientoDao MantenimientoDao { get { return new MantenimientoDao(); } }
        public IMantenimientoimagenDao MantenimientoimagenDao { get { return new MantenimientoimagenDao(); } }
        public IVwMantenimientoDao VwMantenimientoDao { get { return new VwMantenimientoDao(); } }
        public IOrdentrabajoDao OrdentrabajoDao { get { return new OrdentrabajoDao(); } }
        public IVwOrdentrabajoDao VwOrdentrabajoDao { get { return new VwOrdentrabajoDao(); } }
        public IValorizaciondanioDao ValorizaciondanioDao { get { return new ValorizaciondanioDao(); } }
        public IValorizaciondanioelementoDao ValorizaciondanioelementoDao { get { return new ValorizaciondanioelementoDao(); } }
        public IValorizacionelementoDao ValorizacionelementoDao { get { return new ValorizacionelementoDao(); } }
        public IVwValorizaciondanioDao VwValorizaciondanioDao { get { return new VwValorizaciondanioDao(); } }
        public IVwValorizaciondanioelementoDao VwValorizaciondanioelementoDao { get { return new VwValorizaciondanioelementoDao(); } }
        public IVwValorizacionelementoDao VwValorizacionelementoDao { get { return new VwValorizacionelementoDao(); } }
        public IVwResumenelementodanioDao VwResumenelementodanioDao { get { return new VwResumenelementodanioDao(); } }
        #endregion

        #region Clinica
        public IEstadocitaDao EstadocitaDao { get { return new EstadocitaDao(); } }
        public IProgramacioncitaDao ProgramacioncitaDao { get { return new ProgramacioncitaDao(); } }
        public IProgramacioncitadetDao ProgramacioncitadetDao { get { return new ProgramacioncitadetDao(); } }
        public IVwProgramacioncitaDao VwProgramacioncitaDao { get { return new VwProgramacioncitaDao(); } }
        public IVwProgramacioncitadetDao VwProgramacioncitadetDao { get { return new VwProgramacioncitadetDao(); } }
        public IMotivocitaDao MotivocitaDao { get { return new MotivocitaDao(); } }
        public IProgramacioncitadethistorialDao ProgramacioncitadethistorialDao { get { return new ProgramacioncitadethistorialDao(); } }
        public IVwProgramacioncitadethistorialDao VwProgramacioncitadethistorialDao { get { return new VwProgramacioncitadethistorialDao(); } }
        public IHistoriaclinicaDao HistoriaclinicaDao { get { return new HistoriaclinicaDao(); } }
        public IHistoriaclinicaanalisisDao HistoriaclinicaanalisisDao { get { return new HistoriaclinicaanalisisDao(); } }
        public IHistoriaclinicacitaDao HistoriaclinicacitaDao { get { return new HistoriaclinicacitaDao(); } }
        public ITipoanalisisDao TipoanalisisDao { get { return new TipoanalisisDao(); } }
        public ITipociclomenstrualDao TipociclomenstrualDao { get { return new TipociclomenstrualDao(); } }
        public IVwHistoriaclinicaDao VwHistoriaclinicaDao { get { return new VwHistoriaclinicaDao(); } }
        public IVwHistoriaclinicaanalisisDao VwHistoriaclinicaanalisisDao { get { return new VwHistoriaclinicaanalisisDao(); } }
        public IVwHistoriaclinicacitaDao VwHistoriaclinicacitaDao { get { return new VwHistoriaclinicacitaDao(); } }


        public ICategoriaitemDao CategoriaitemDao { get { return new CategoriaitemDao(); } }
        public IHistoriaDao HistoriaDao { get { return new HistoriaDao(); } }
        public IHistoriaarchivoDao HistoriaarchivoDao { get { return new HistoriaarchivoDao(); } }
        public IHistoriadetDao HistoriadetDao { get { return new HistoriadetDao(); } }
        public IHistoriadetitemDao HistoriadetitemDao { get { return new HistoriadetitemDao(); } }
        public IItemhistoriaDao ItemhistoriaDao { get { return new ItemhistoriaDao(); } }
        public IPlantillahistoriaDao PlantillahistoriaDao { get { return new PlantillahistoriaDao(); } }
        public IPlantillahistoriadetDao PlantillahistoriadetDao { get { return new PlantillahistoriadetDao(); } }
        public ITipoarchivoDao TipoarchivoDao { get { return new TipoarchivoDao(); } }
        public ITipohistoriaDao TipohistoriaDao { get { return new TipohistoriaDao(); } }
        public IVwHistoriaDao VwHistoriaDao { get { return new VwHistoriaDao(); } }
        public IVwHistoriaarchivoDao VwHistoriaarchivoDao { get { return new VwHistoriaarchivoDao(); } }
        public IVwHistoriadetDao VwHistoriadetDao { get { return new VwHistoriadetDao(); } }
        public IVwHistoriadetitemDao VwHistoriadetitemDao { get { return new VwHistoriadetitemDao(); } }
        public IVwItemhistoriaDao VwItemhistoriaDao { get { return new VwItemhistoriaDao(); } }
        public IVwPlantillahistoriaDao VwPlantillahistoriaDao { get { return new VwPlantillahistoriaDao(); } }
        public IVwPlantillahistoriadetDao VwPlantillahistoriadetDao { get { return new VwPlantillahistoriadetDao(); } }

        public ICieDao CieDao { get { return new CieDao(); } }
        public ICptDao CptDao { get { return new CptDao(); } }
        public IGrupoedadDao GrupoedadDao { get { return new GrupoedadDao(); } }
        public IServicioespecialidadDao ServicioespecialidadDao { get { return new ServicioespecialidadDao(); } }
        public ITipocirugiaDao TipocirugiaDao { get { return new TipocirugiaDao(); } }
        public ITipocolegioprofesionalDao TipocolegioprofesionalDao { get { return new TipocolegioprofesionalDao(); } }
        public ITipocomplicacionpartoDao TipocomplicacionpartoDao { get { return new TipocomplicacionpartoDao(); } }
        public ITipodiagnosticoDao TipodiagnosticoDao { get { return new TipodiagnosticoDao(); } }
        public ITipoeventoDao TipoeventoDao { get { return new TipoeventoDao(); } }
        public ITipopartoDao TipopartoDao { get { return new TipopartoDao(); } }
        #endregion

        #region Movil
        public IClaseDao ClaseDao { get { return new ClaseDao(); } }
        public IPlanDao PlanDao { get { return new PlanDao(); } }
        public ITipoDao TipoDao { get { return new TipoDao(); } }
        public ITipotopeDao TipotopeDao { get { return new TipotopeDao(); } }
        #endregion
    }
    
}
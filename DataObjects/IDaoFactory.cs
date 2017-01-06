namespace DataObjects
{
    public interface IDaoFactory
    {
        #region Almacen
        IAlmacenDao AlmacenDao { get; }
        IEntradaalmacenDao EntradaalmacenDao { get; }
        IEntradaalmacendetDao EntradaalmacendetDao { get; }
        IEntradaalmacenubicacionDao EntradaalmacenubicacionDao { get; }
        IGuiaremisionDao GuiaremisionDao { get; }
        IGuiaremisiondetDao GuiaremisiondetDao { get; }
        ISalidaalmacenDao SalidaalmacenDao { get; }
        ISalidaalmacendetDao SalidaalmacendetDao { get; }
        ISalidaalmacenubicacionDao SalidaalmacenubicacionDao { get; }
        IVwAlmacenDao VwAlmacenDao { get; }
        IVwEntradaalmacenDao VwEntradaalmacenDao { get; }
        IVwEntradaalmacendetDao VwEntradaalmacendetDao { get; }
        IVwGuiaremisionDao VwGuiaremisionDao { get; }
        IVwGuiaremisiondetDao VwGuiaremisiondetDao { get; }
        IVwSalidaalmacenDao VwSalidaalmacenDao { get; }
        IVwSalidaalmacendetDao VwSalidaalmacendetDao { get; }
        IEntradaalmacenobsDao EntradaalmacenobsDao { get; }
        IEstadoarticuloingresoDao EstadoarticuloingresoDao { get; }
        IVwEntradaalmacenobsDao VwEntradaalmacenobsDao { get; }
        IVwStockDao VwStockDao { get; }
        IEstadoreclamoDao EstadoreclamoDao { get; }
        IInventarioDao InventarioDao { get; }
        IInventariostockDao InventariostockDao { get; }
        IInventarioubicacionDao InventarioubicacionDao { get; }
        IUbicacionDao UbicacionDao { get; }
        IVwInventarioDao VwInventarioDao { get; }
        IVwInventariostockDao VwInventariostockDao { get; }
        IVwInventarioubicacionDao VwInventarioubicacionDao { get; }
        IVwUbicacionDao VwUbicacionDao { get; }
        IVwEntradaalmacenubicacionDao VwEntradaalmacenubicacionDao { get; }
        IVwSalidaalmacenubicacionDao VwSalidaalmacenubicacionDao { get; }
        IVwGuiaremisionimpsalidaalmacenDao VwGuiaremisionimpsalidaalmacenDao { get; }
        IVwOrdencompraimpentradaalmacenDao VwOrdencompraimpentradaalmacenDao { get; }
        IVwGuiaremisiondetimpcpventadetDao VwGuiaremisiondetimpcpventadetDao { get; }
        IGuiaremisiondetimpcpventadetDao GuiaremisiondetimpcpventadetDao { get; }
        IVwSalidaalmacendetimpentradaalmacenDao VwSalidaalmacendetimpentradaalmacenDao { get; }
        IVwCpcompradetimpentradaalmacenDao VwCpcompradetimpentradaalmacenDao { get; }
        IVwRendicioncajachicaimpsalidaalmacenDao VwRendicioncajachicaimpsalidaalmacenDao { get; }
        IVwNotacreditocliimpentradaalmacenDao VwNotacreditocliimpentradaalmacenDao { get; }
        IVwEntradaalmacendetimpguiaremisionDao VwEntradaalmacendetimpguiaremisionDao { get; }
        IVwEntradaalmacendetverificacioncantidadDao VwEntradaalmacendetverificacioncantidadDao { get; }
        IVwSalidaalmacendetverificacioncantidadDao VwSalidaalmacendetverificacioncantidadDao { get; }
        IEntradaalmacendetitemcpcompradetDao EntradaalmacendetitemcpcompradetDao { get; }
        IInventarioinicialDao InventarioinicialDao { get; }
        IVwInventarioinicialDao VwInventarioinicialDao { get; }
        IInventariostockdetserieDao InventariostockdetserieDao { get; }
        IVwInventariostockdetserieDao VwInventariostockdetserieDao { get; }
        IVwCpventaimpsalidaalmacenDao VwCpventaimpsalidaalmacenDao { get; }
        #endregion
        
        #region Caja
        ICierrecajaDao CierrecajaDao { get; }
        ICierrecajadetDao CierrecajadetDao { get; }
        IVwCierrecajaDao VwCierrecajaDao { get; }
        IVwCierrecajadetDao VwCierrecajadetDao { get; }
        IVwCierrecajaimpresionDao VwCierrecajaimpresionDao { get; }
        IVwReciboresumenDao VwReciboresumenDao { get; }

        #endregion

        #region Compras

        ICpcompraDao CpcompraDao { get; }
        ICpcompradetDao CpcompradetDao { get; }
        IOrdencompraDao OrdencompraDao { get; }
        IOrdencompradetDao OrdencompradetDao { get; }
        IRequerimientoDao RequerimientoDao { get; }
        IRequerimientodetDao RequerimientodetDao { get; }
        IVwCptooperacionDao VwCptooperacionDao { get; }
        IVwRequerimientoDao VwRequerimientoDao { get; }
        IVwRequerimientodetDao VwRequerimientodetDao { get; }
        IVwRequerimientoimpresionDao VwRequerimientoimpresionDao { get; }
        IVwOrdencompraDao VwOrdencompraDao { get; }
        IVwOrdencompradetDao VwOrdencompradetDao { get; }
        IVwCpcompraDao VwCpcompraDao { get; }
        IVwCpcompradetDao VwCpcompradetDao { get; }
        IVwRequerimientodetordcompraimpDao VwRequerimientodetordcompraimpDao { get; }
        IVwRequerimientosaaprobarDao VwRequerimientosaaprobarDao { get; }
        IEstadoreqDao EstadoreqDao { get; }
        IVwOrdencompraimpresionDao VwOrdencompraimpresionDao { get; }
        IVwOrdencompradetingresoimpDao VwOrdencompradetingresoimpDao { get; }
        IVwOrdencompradetcpcompraimpDao VwOrdencompradetcpcompraimpDao { get; }
        INotacreditoDao NotacreditoDao { get; }
        INotacreditodetDao NotacreditodetDao { get; }
        IVwNotacreditoDao VwNotacreditoDao { get; }
        IVwNotacreditodetDao VwNotacreditodetDao { get; }
        IEstadopagoDao EstadopagoDao { get; }
        INotadebitoDao NotadebitoDao { get; }
        INotadebitodetDao NotadebitodetDao { get; }
        IVwNotadebitoDao VwNotadebitoDao { get; }
        IVwNotadebitodetDao VwNotadebitodetDao { get; }
        IVwCpcompraimpncDao VwCpcompraimpncDao { get; }
        IVwCpcompraimpndDao VwCpcompraimpndDao { get; }
        ICotizacionprvDao CotizacionprvDao { get; }
        ICotizacionprvdetDao CotizacionprvdetDao { get; }
        ICuadrocomparativoDao CuadrocomparativoDao { get; }
        ICuadrocomparativoarticuloDao CuadrocomparativoarticuloDao { get; }
        ICuadrocomparativoprvDao CuadrocomparativoprvDao { get; }
        IVwCotizacionprvDao VwCotizacionprvDao { get; }
        IVwCotizacionprvdetDao VwCotizacionprvdetDao { get; }
        IVwCuadrocomparativoDao VwCuadrocomparativoDao { get; }
        IVwCuadrocomparativoarticuloDao VwCuadrocomparativoarticuloDao { get; }
        IVwCuadrocomparativoprvDao VwCuadrocomparativoprvDao { get; }
        IVwRequerimientodetcotizaprvimpDao VwRequerimientodetcotizaprvimpDao { get; }
        IVwRequerimientodetimpguiaremisionDao VwRequerimientodetimpguiaremisionDao { get; }
        ITiporegistroordenDao TiporegistroordenDao { get; }
        IVwCuadrocomparativoarticuloimpocDao VwCuadrocomparativoarticuloimpocDao { get; }
        IVwCuadrocomparativoaaprobarDao VwCuadrocomparativoaaprobarDao { get; }
        IVwCuadrocomparativomodeloautorizacionDao VwCuadrocomparativomodeloautorizacionDao { get; }
        IOrdenservicioDao OrdenservicioDao { get; }
        IOrdenserviciodetDao OrdenserviciodetDao { get; }
        IVwCuadrocomparativoarticuloimposDao VwCuadrocomparativoarticuloimposDao { get; }
        IVwOrdenservicioDao VwOrdenservicioDao { get; }
        IVwOrdenserviciodetDao VwOrdenserviciodetDao { get; }
        IVwOrdenservicioimpresionDao VwOrdenservicioimpresionDao { get; }
        IVwRequerimientodetordservicioimpDao VwRequerimientodetordservicioimpDao { get; }
        IVwOrdenserviciodetcpcompraimpDao VwOrdenserviciodetcpcompraimpDao { get; }
        IVwCpcompradetguiaremisionimpDao VwCpcompradetguiaremisionimpDao { get; }
        ICpcompradetserieDao CpcompradetserieDao { get; }
        IVwCpcompradetserieDao VwCpcompradetserieDao { get; }
        #endregion

        #region Finanzas
        ITiporecibocajaDao TiporecibocajaDao { get; }
        IVwCtacteclienteDao VwCtacteclienteDao { get; }
        IRendicioncajachicaDao RendicioncajachicaDao { get; }
        IRendicioncajachicadetDao RendicioncajachicadetDao { get; }
        IVwRendicioncajachicaDao VwRendicioncajachicaDao { get; }
        IVwRendicioncajachicadetDao VwRendicioncajachicadetDao { get; }

        IRecibocajaingresoDao RecibocajaingresoDao { get; }
        IRecibocajaingresodetDao RecibocajaingresodetDao { get; }
        IRecibocajaingresoimprevistoDao RecibocajaingresoimprevistoDao { get; }
        IVwRecibocajaingresoDao VwRecibocajaingresoDao { get; }
        IVwRecibocajaingresodetDao VwRecibocajaingresodetDao { get; }
        IVwRecibocajaingresoimprevistoDao VwRecibocajaingresoimprevistoDao { get; }

        IRecibocajaegresoDao RecibocajaegresoDao { get; }
        IRecibocajaegresodetDao RecibocajaegresodetDao { get; }
        IRecibocajaegresoimprevistoDao RecibocajaegresoimprevistoDao { get; }
        IVwRecibocajaegresoDao VwRecibocajaegresoDao { get; }
        IVwRecibocajaegresodetDao VwRecibocajaegresodetDao { get; }
        IVwRecibocajaegresoimprevistoDao VwRecibocajaegresoimprevistoDao { get; }

        IVwCtacteproveedorDao VwCtacteproveedorDao { get; }

        #endregion

        #region Inntecc
        IAccesoformDao AccesoformDao { get; }
        IAreaDao AreaDao { get; }
        IAreacentrocostroDao AreacentrocostroDao { get; }
        IArticuloDao ArticuloDao { get; }
        IArticuloclasificacionDao ArticuloclasificacionDao { get; }
        IArticulodetalleunidadDao ArticulodetalleunidadDao { get; }
        IArticuloimagenDao ArticuloimagenDao { get; }
        IArticuloubicacionDao ArticuloubicacionDao { get; }
        ICentrodecostoDao CentrodecostoDao { get; }
        ICptooperacionDao CptooperacionDao { get; }
        ICuentacontableDao CuentacontableDao { get; }
        IDepartamentoDao DepartamentoDao { get; }
        IDistritoDao DistritoDao { get; }
        IEjercicioDao EjercicioDao { get; }
        IEmpleadoDao EmpleadoDao { get; }
        IEmpleadoanexoDao EmpleadoanexoDao { get; }
        IEmpresaDao EmpresaDao { get; }
        IEntidadfinancieraDao EntidadfinancieraDao { get; }
        IGrupousuarioDao GrupousuarioDao { get; }
        IImpuestoDao ImpuestoDao { get; }
        IImpuestoiscDao ImpuestoiscDao { get; }
        IListaprecioDao ListaprecioDao { get; }
        IMarcaDao MarcaDao { get; }
        IPeriodoDao PeriodoDao { get; }
        IPersonaDao PersonaDao { get; }
        IPersonacontactoDao PersonacontactoDao { get; }
        IPrioridadDao PrioridadDao { get; }
        IProvinciaDao ProvinciaDao { get; }
        IProyectoDao ProyectoDao { get; }
        ISocionegentidadfinancieraDao SocionegentidadfinancieraDao { get; }
        ISocionegocioDao SocionegocioDao { get; }
        ISocionegociocontactoDao SocionegociocontactoDao { get; }
        ISocionegociodireccionDao SocionegociodireccionDao { get; }
        ISocionegociolimitecreditoDao SocionegociolimitecreditoDao { get; }
        ISocionegocioproyectoDao SocionegocioproyectoDao { get; }
        ISucursalDao SucursalDao { get; }
        ITipocondicionDao TipocondicionDao { get; }
        ITipocpDao TipocpDao { get; }
        ITipocppagoDao TipocppagoDao { get; }
        ITipodocentidadDao TipodocentidadDao { get; }
        ITipoformatoDao TipoformatoDao { get; }
        ITipolistaDao TipolistaDao { get; }
        ITipomediopagoDao TipomediopagoDao { get; }
        ITipomonedaDao TipomonedaDao { get; }
        ITipooperacionDao TipooperacionDao { get; }
        ITiposcontactoDao TiposcontactoDao { get; }
        ITiposocioDao TiposocioDao { get; }
        IUnidadmedidaDao UnidadmedidaDao { get; }
        IUsuarioDao UsuarioDao { get; }
        IVwPersonaDao VwPersonaDao { get; }
        IVwSucursalDao VwSucursalDao { get; }
        IVwTipocpDao VwTipocpDao { get; }
        IVwUbigeoDao VwUbigeoDao { get; }
        IVwAreaDao VwAreaDao { get; }
        IVwPersonacontactoDao VwPersonacontactoDao { get; }
        IVwSocionegocioDao VwSocionegocioDao { get; }
        IVwEmpleadoDao VwEmpleadoDao { get; }
        IVwListaprecioDao VwListaprecioDao { get; }
        IVwArticuloDao VwArticuloDao { get; }
        IVwPeriodoDao VwPeriodoDao { get; }
        ITipodocmovDao TipodocmovDao { get; }
        IVwUsuarioDao VwUsuarioDao { get; }
        IVwProyectoDao VwProyectoDao { get; }
        IVwArticulodetalleunidadDao VwArticulodetalleunidadDao { get; }
        IVwArticuloubicacionDao VwArticuloubicacionDao { get; }
        IEmpleadoareaDao EmpleadoareaDao { get; }
        IEmpleadoareaproyectoDao EmpleadoareaproyectoDao { get; }
        IVwEmpleadoareaDao VwEmpleadoareaDao { get; }
        IVwEmpleadoareaproyectoDao VwEmpleadoareaproyectoDao { get; }
        IValorpordefectoDao ValorpordefectoDao { get; }
        IVwAccesoformDao VwAccesoformDao { get; }
        IVwGrupousuarioitemDao VwGrupousuarioitemDao { get; }
        IVwPaginaitemDao VwPaginaitemDao { get; }
        IGrupousuarioitemDao GrupousuarioitemDao { get; }
        IVwAccesoopcionDao VwAccesoopcionDao { get; }
        IVwSocionegociodireccionDao VwSocionegociodireccionDao { get; }
        IVwSocionegociolimitecreditoDao VwSocionegociolimitecreditoDao { get; }
        ITipoafectacionigvDao TipoafectacionigvDao { get; }
        IVwSocionegentidadfinancieraDao VwSocionegentidadfinancieraDao { get; }
        IVwSocionegocioproyectoDao VwSocionegocioproyectoDao { get; }
        IVwCentrodecostoDao VwCentrodecostoDao { get; }
        IAutorizaciontipocondicionDao AutorizaciontipocondicionDao { get; }
        IEtapaautorizacionDao EtapaautorizacionDao { get; }
        IEtapaautorizaciondetalleDao EtapaautorizaciondetalleDao { get; }
        IModeloautorizacionDao ModeloautorizacionDao { get; }
        IModeloautorizacioncondicionDao ModeloautorizacioncondicionDao { get; }
        IModeloautorizacionetapaDao ModeloautorizacionetapaDao { get; }
        ITiporatioDao TiporatioDao { get; }
        IVwEtapaautorizacionDao VwEtapaautorizacionDao { get; }
        IVwEtapaautorizaciondetalleDao VwEtapaautorizaciondetalleDao { get; }
        IVwModeloautorizacionDao VwModeloautorizacionDao { get; }
        IVwModeloautorizacioncondicionDao VwModeloautorizacioncondicionDao { get; }
        IVwModeloautorizacionetapaDao VwModeloautorizacionetapaDao { get; }
        IDocumentoaprobacionDao DocumentoaprobacionDao { get; }
        IVwModeloautorizacioninfoDao VwModeloautorizacioninfoDao { get; }
        IVwDocumentoaprobacionDao VwDocumentoaprobacionDao { get; }
        ITipoarticuloDao TipoarticuloDao { get; }
        IElementogastoDao ElementogastoDao { get; }
        IVwReporteusuarioDao VwReporteusuarioDao { get; }
        IArticulocompuestoDao ArticulocompuestoDao { get; }
        IVwArticulocompuestoDao VwArticulocompuestoDao { get; }
        IVwArticuloinventarioDao VwArticuloinventarioDao { get; }
        IVwArticulounidadDao VwArticulounidadDao { get; }
        IReporteDao ReporteDao { get; }
        ITipocambioDao TipocambioDao { get; }
        IVwTipocambioDao VwTipocambioDao { get; }
        ITipogestionarticuloDao TipogestionarticuloDao { get; }
        IEstadoarticuloDao EstadoarticuloDao { get; }
        ICategoriasocionegocioDao CategoriasocionegocioDao { get; }
        IGrupoeconomicoDao GrupoeconomicoDao { get; }
        IPaisDao PaisDao { get; }
        IRubronegocioDao RubronegocioDao { get; }
        ISocionegociogarantiaDao SocionegociogarantiaDao { get; }
        ISocionegociomarcaDao SocionegociomarcaDao { get; }
        ITipogarantiaDao TipogarantiaDao { get; }
        IVwSocionegociogarantiaDao VwSocionegociogarantiaDao { get; }
        IVwSocionegociomarcaDao VwSocionegociomarcaDao { get; }
        IZonaDao ZonaDao { get; }
        IEstadosocionegocioDao EstadosocionegocioDao { get; }
        ITipolistatipocondicionDao TipolistatipocondicionDao { get; }
        IVwTipolistatipocondicionDao VwTipolistatipocondicionDao { get; }
        IVwArticuloclasificacionDao VwArticuloclasificacionDao { get; }
        IEstadocivilDao EstadocivilDao { get; }
        ITipocontratoempleadoDao TipocontratoempleadoDao { get; }
        ITiposnpDao TiposnpDao { get; }
        IArticuloseriedetDao ArticuloseriedetDao { get; }
        ISeriearticuloDao SeriearticuloDao { get; }
        IVwArticuloseriedetDao VwArticuloseriedetDao { get; }
        IDiaferiadoDao DiaferiadoDao { get; }
        #endregion

        #region Ventas

        IArticulolistaprecioDao ArticulolistaprecioDao { get; }
        ICotizacionclienteDao CotizacionclienteDao { get; }
        ICotizacionclientedetDao CotizacionclientedetDao { get; }
        ICpventaDao CpventaDao { get; }
        ICpventadetDao CpventadetDao { get; }
        IGuiaremisionmotivoDao GuiaremisionmotivoDao { get; }
        IOrdendeventaDao OrdendeventaDao { get; }
        IOrdendeventadetDao OrdendeventadetalleDao { get; }
        IVwCotizacionclienteDao VwCotizacionclienteDao { get; }
        IVwCotizacionclientedetDao VwCotizacionclientedetDao { get; }
        IVwOrdendeventaDao VwOrdendeventaDao { get; }
        IVwOrdendeventadetalleDao VwOrdendeventadetalleDao { get; }
        IVwCpventaDao VwCpventaDao { get; }
        IVwCpventadetDao VwCpventadetDao { get; }
        IVwArticulolistaprecioDao VwArticulolistaprecioDao { get; }
        INotacreditocliDao NotacreditocliDao { get; }
        INotacreditoclidetDao NotacreditoclidetDao { get; }
        INotadebitocliDao NotadebitocliDao { get; }
        IVwCpventaimpncDao VwCpventaimpncDao { get; }
        IVwCpventaimpndDao VwCpventaimpndDao { get; }
        IVwNotacreditocliDao VwNotacreditocliDao { get; }
        IVwNotacreditoclidetDao VwNotacreditoclidetDao { get; }
        IVwNotadebitocliDao VwNotadebitocliDao { get; }
        INotadebitoclidetDao NotadebitoclidetDao { get; }
        IVwNotadebitoclidetDao VwNotadebitoclidetDao { get; }
        IVwCotizacionclientedetovimpDao VwCotizacionclientedetovimpDao { get; }
        IVwOrdendeventadetcpventaimpDao VwOrdendeventadetcpventaimpDao { get; }
        IVwOrdendeventadetvalorizaimpDao VwOrdendeventadetvalorizaimpDao { get; }
        IVwArticulostocklistaDao VwArticulostocklistaDao { get; }
        IVwOrdendeventadetimpguiaremisionDao VwOrdendeventadetimpguiaremisionDao { get; }
        IVwOrdendeventavalorizacpventaimpDao VwOrdendeventavalorizacpventaimpDao { get; }
        IComisioncobroDao ComisioncobroDao { get; }
        IComisioncobrodetDao ComisioncobrodetDao { get; }
        ITipocomisioncobroDao TipocomisioncobroDao { get; }
        IVwComisioncobroDao VwComisioncobroDao { get; }
        IDetraccionclienteDao DetraccionclienteDao { get; }
        IVwDetraccionclienteDao VwDetraccionclienteDao { get; }
        ICpventadetserieDao CpventadetserieDao { get; }
        IVwCpventadetserieDao VwCpventadetserieDao { get; }
        IVwNotacreditoclireciboingresoimpDao VwNotacreditoclireciboingresoimpDao { get; }
        #endregion

        #region Logistica
        ILogStocksDao LogStocksDao { get; }
        #endregion

        #region Maquinaria
        IClasificacionequipoDao ClasificacionequipoDao { get; }
        IEquipoDao EquipoDao { get; }
        IMarcaequipoDao MarcaequipoDao { get; }
        IModeloequipoDao ModeloequipoDao { get; }
        IVwEquipoDao VwEquipoDao { get; }
        IVwModeloequipoDao VwModeloequipoDao { get; }
        ITipoalquilerDao TipoalquilerDao { get; }
        ITipoegresovalorizacionDao TipoegresovalorizacionDao { get; }
        IValorizacionDao ValorizacionDao { get; }
        IValorizaciondetDao ValorizaciondetDao { get; }
        IValorizacionegresoDao ValorizacionegresoDao { get; }
        IVwValorizacionDao VwValorizacionDao { get; }
        IVwValorizaciondetDao VwValorizaciondetDao { get; }
        IVwValorizacionegresoDao VwValorizacionegresoDao { get; }
        IValorizacionegresoproveedorDao ValorizacionegresoproveedorDao { get; }
        IValorizacionproveedorDao ValorizacionproveedorDao { get; }
        IValorizacionproveedordetDao ValorizacionproveedordetDao { get; }
        IVwValorizacionegresoproveedorDao VwValorizacionegresoproveedorDao { get; }
        IVwValorizacionproveedorDao VwValorizacionproveedorDao { get; }
        IVwValorizacionproveedordetDao VwValorizacionproveedordetDao { get; }
        IVwOrdendeserviciodetvalorizaimpDao VwOrdendeserviciodetvalorizaimpDao { get; }
        IMantenimientoDao MantenimientoDao { get; }
        IMantenimientoimagenDao MantenimientoimagenDao { get; }
        IVwMantenimientoDao VwMantenimientoDao { get; }
        IOrdentrabajoDao OrdentrabajoDao { get; }
        IVwOrdentrabajoDao VwOrdentrabajoDao { get; }
        IValorizaciondanioDao ValorizaciondanioDao { get; }
        IValorizaciondanioelementoDao ValorizaciondanioelementoDao { get; }
        IValorizacionelementoDao ValorizacionelementoDao { get; }
        IVwValorizaciondanioDao VwValorizaciondanioDao { get; }
        IVwValorizaciondanioelementoDao VwValorizaciondanioelementoDao { get; }
        IVwValorizacionelementoDao VwValorizacionelementoDao { get; }
        IVwResumenelementodanioDao VwResumenelementodanioDao { get; }
        #endregion

        #region Clinica
        IEstadocitaDao EstadocitaDao { get; }
        IProgramacioncitaDao ProgramacioncitaDao { get; }
        IProgramacioncitadetDao ProgramacioncitadetDao { get; }
        IVwProgramacioncitaDao VwProgramacioncitaDao { get; }
        IVwProgramacioncitadetDao VwProgramacioncitadetDao { get; }
        IMotivocitaDao MotivocitaDao { get; }
        IProgramacioncitadethistorialDao ProgramacioncitadethistorialDao { get; }
        IVwProgramacioncitadethistorialDao VwProgramacioncitadethistorialDao { get; }
        IHistoriaclinicaDao HistoriaclinicaDao { get; }
        IHistoriaclinicaanalisisDao HistoriaclinicaanalisisDao { get; }
        IHistoriaclinicacitaDao HistoriaclinicacitaDao { get; }
        ITipoanalisisDao TipoanalisisDao { get; }
        ITipociclomenstrualDao TipociclomenstrualDao { get; }
        IVwHistoriaclinicaDao VwHistoriaclinicaDao { get; }
        IVwHistoriaclinicaanalisisDao VwHistoriaclinicaanalisisDao { get; }
        IVwHistoriaclinicacitaDao VwHistoriaclinicacitaDao { get; }


        ICategoriaitemDao CategoriaitemDao { get; }
        IHistoriaDao HistoriaDao { get; }
        IHistoriaarchivoDao HistoriaarchivoDao { get; }
        IHistoriadetDao HistoriadetDao { get; }
        IHistoriadetitemDao HistoriadetitemDao { get; }
        IItemhistoriaDao ItemhistoriaDao { get; }
        IPlantillahistoriaDao PlantillahistoriaDao { get; }
        IPlantillahistoriadetDao PlantillahistoriadetDao { get; }
        ITipoarchivoDao TipoarchivoDao { get; }
        ITipohistoriaDao TipohistoriaDao { get; }
        IVwHistoriaDao VwHistoriaDao { get; }
        IVwHistoriaarchivoDao VwHistoriaarchivoDao { get; }
        IVwHistoriadetDao VwHistoriadetDao { get; }
        IVwHistoriadetitemDao VwHistoriadetitemDao { get; }
        IVwItemhistoriaDao VwItemhistoriaDao { get; }
        IVwPlantillahistoriaDao VwPlantillahistoriaDao { get; }
        IVwPlantillahistoriadetDao VwPlantillahistoriadetDao { get; }


        ICieDao CieDao { get; }
        ICptDao CptDao { get; }
        IGrupoedadDao GrupoedadDao { get; }
        IServicioespecialidadDao ServicioespecialidadDao { get; }
        ITipocirugiaDao TipocirugiaDao { get; }
        ITipocolegioprofesionalDao TipocolegioprofesionalDao { get; }
        ITipocomplicacionpartoDao TipocomplicacionpartoDao { get; }
        ITipodiagnosticoDao TipodiagnosticoDao { get; }
        ITipoeventoDao TipoeventoDao { get; }
        ITipopartoDao TipopartoDao { get; }

        #endregion

        #region Movil
        IClaseDao ClaseDao { get; }
        IPlanDao PlanDao { get; }
        ITipoDao TipoDao { get; }
        ITipotopeDao TipotopeDao { get; }
        #endregion
    }
}
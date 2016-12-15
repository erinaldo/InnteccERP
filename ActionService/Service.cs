using System.Configuration;
using DataObjects;

namespace ActionService
{
    public partial class Service : IService
    {

        static readonly string Provider = ConfigurationManager.AppSettings.Get("DataProvider");
        static readonly IDaoFactory Factory = DaoFactories.GetFactory(Provider);

        #region Almacen

        static readonly IAlmacenDao AlmacenDao = Factory.AlmacenDao;
        static readonly IEntradaalmacenDao EntradaalmacenDao = Factory.EntradaalmacenDao;
        static readonly IEntradaalmacendetDao EntradaalmacendetDao = Factory.EntradaalmacendetDao;
        static readonly IEntradaalmacenubicacionDao EntradaalmacenubicacionDao = Factory.EntradaalmacenubicacionDao;
        static readonly IGuiaremisionDao GuiaremisionDao = Factory.GuiaremisionDao;
        static readonly IGuiaremisiondetDao GuiaremisiondetDao = Factory.GuiaremisiondetDao;
        static readonly ISalidaalmacenDao SalidaalmacenDao = Factory.SalidaalmacenDao;
        static readonly ISalidaalmacendetDao SalidaalmacendetDao = Factory.SalidaalmacendetDao;
        static readonly ISalidaalmacenubicacionDao SalidaalmacenubicacionDao = Factory.SalidaalmacenubicacionDao;
        static readonly IVwAlmacenDao VwAlmacenDao = Factory.VwAlmacenDao;
        static readonly IVwEntradaalmacenDao VwEntradaalmacenDao = Factory.VwEntradaalmacenDao;
        static readonly IVwEntradaalmacendetDao VwEntradaalmacendetDao = Factory.VwEntradaalmacendetDao;
        static readonly IVwGuiaremisionDao VwGuiaremisionDao = Factory.VwGuiaremisionDao;
        static readonly IVwGuiaremisiondetDao VwGuiaremisiondetDao = Factory.VwGuiaremisiondetDao;
        static readonly IVwSalidaalmacenDao VwSalidaalmacenDao = Factory.VwSalidaalmacenDao;
        static readonly IVwSalidaalmacendetDao VwSalidaalmacendetDao = Factory.VwSalidaalmacendetDao;
        static readonly IEntradaalmacenobsDao EntradaalmacenobsDao = Factory.EntradaalmacenobsDao;
        static readonly IEstadoarticuloingresoDao EstadoarticuloingresoDao = Factory.EstadoarticuloingresoDao;
        static readonly IVwEntradaalmacenobsDao VwEntradaalmacenobsDao = Factory.VwEntradaalmacenobsDao;
        static readonly IVwStockDao VwStockDao = Factory.VwStockDao;
        static readonly IEstadoreclamoDao EstadoreclamoDao = Factory.EstadoreclamoDao;
        static readonly IInventarioDao InventarioDao = Factory.InventarioDao;
        static readonly IInventariostockDao InventariostockDao = Factory.InventariostockDao;
        static readonly IInventarioubicacionDao InventarioubicacionDao = Factory.InventarioubicacionDao;
        static readonly IUbicacionDao UbicacionDao = Factory.UbicacionDao;
        static readonly IVwInventarioDao VwInventarioDao = Factory.VwInventarioDao;
        static readonly IVwInventariostockDao VwInventariostockDao = Factory.VwInventariostockDao;
        static readonly IVwInventarioubicacionDao VwInventarioubicacionDao = Factory.VwInventarioubicacionDao;
        static readonly IVwUbicacionDao VwUbicacionDao = Factory.VwUbicacionDao;
        static readonly IVwEntradaalmacenubicacionDao VwEntradaalmacenubicacionDao = Factory.VwEntradaalmacenubicacionDao;
        static readonly IVwSalidaalmacenubicacionDao VwSalidaalmacenubicacionDao = Factory.VwSalidaalmacenubicacionDao;
        static readonly IVwGuiaremisionimpsalidaalmacenDao VwGuiaremisionimpsalidaalmacenDao = Factory.VwGuiaremisionimpsalidaalmacenDao;
        static readonly IVwOrdencompraimpentradaalmacenDao VwOrdencompraimpentradaalmacenDao = Factory.VwOrdencompraimpentradaalmacenDao;
        static readonly IVwGuiaremisiondetimpcpventadetDao VwGuiaremisiondetimpcpventadetDao = Factory.VwGuiaremisiondetimpcpventadetDao;
        static readonly IGuiaremisiondetimpcpventadetDao GuiaremisiondetimpcpventadetDao = Factory.GuiaremisiondetimpcpventadetDao;
        static readonly IVwSalidaalmacendetimpentradaalmacenDao VwSalidaalmacendetimpentradaalmacenDao = Factory.VwSalidaalmacendetimpentradaalmacenDao;
        static readonly IVwCpcompradetimpentradaalmacenDao VwCpcompradetimpentradaalmacenDao = Factory.VwCpcompradetimpentradaalmacenDao;
        static readonly IVwRendicioncajachicaimpsalidaalmacenDao VwRendicioncajachicaimpsalidaalmacenDao = Factory.VwRendicioncajachicaimpsalidaalmacenDao;
        static readonly IVwNotacreditocliimpentradaalmacenDao VwNotacreditocliimpentradaalmacenDao = Factory.VwNotacreditocliimpentradaalmacenDao;
        static readonly IVwEntradaalmacendetimpguiaremisionDao VwEntradaalmacendetimpguiaremisionDao = Factory.VwEntradaalmacendetimpguiaremisionDao;
        static readonly IVwEntradaalmacendetverificacioncantidadDao VwEntradaalmacendetverificacioncantidadDao = Factory.VwEntradaalmacendetverificacioncantidadDao;
        static readonly IVwSalidaalmacendetverificacioncantidadDao VwSalidaalmacendetverificacioncantidadDao = Factory.VwSalidaalmacendetverificacioncantidadDao;
        static readonly IInventarioinicialDao InventarioinicialDao = Factory.InventarioinicialDao;
        static readonly IVwInventarioinicialDao VwInventarioinicialDao = Factory.VwInventarioinicialDao;
        static readonly IInventariostockdetserieDao InventariostockdetserieDao = Factory.InventariostockdetserieDao;
        static readonly IVwInventariostockdetserieDao VwInventariostockdetserieDao = Factory.VwInventariostockdetserieDao;
        static readonly IVwCpventaimpsalidaalmacenDao VwCpventaimpsalidaalmacenDao = Factory.VwCpventaimpsalidaalmacenDao;


        #endregion

        #region Caja
        static readonly ICierrecajaDao CierrecajaDao = Factory.CierrecajaDao;
        static readonly ICierrecajadetDao CierrecajadetDao = Factory.CierrecajadetDao;
        static readonly IVwCierrecajaDao VwCierrecajaDao = Factory.VwCierrecajaDao;
        static readonly IVwCierrecajadetDao VwCierrecajadetDao = Factory.VwCierrecajadetDao;
        static readonly IVwCierrecajaimpresionDao VwCierrecajaimpresionDao = Factory.VwCierrecajaimpresionDao;
        static readonly IVwReciboresumenDao VwReciboresumenDao = Factory.VwReciboresumenDao;
        #endregion

        #region Compras

        static readonly ICpcompraDao CpcompraDao = Factory.CpcompraDao;
        static readonly ICpcompradetDao CpcompradetDao = Factory.CpcompradetDao;
        static readonly IOrdencompraDao OrdencompraDao = Factory.OrdencompraDao;
        static readonly IOrdencompradetDao OrdencompradetDao = Factory.OrdencompradetDao;
        static readonly IRequerimientoDao RequerimientoDao = Factory.RequerimientoDao;
        static readonly IRequerimientodetDao RequerimientodetDao = Factory.RequerimientodetDao;
        static readonly IVwRequerimientoDao VwRequerimientoDao = Factory.VwRequerimientoDao;
        static readonly IVwRequerimientodetDao VwRequerimientodetDao = Factory.VwRequerimientodetDao;
        static readonly IVwRequerimientoimpresionDao VwRequerimientoimpresionDao = Factory.VwRequerimientoimpresionDao;
        static readonly IVwOrdencompraDao VwOrdencompraDao = Factory.VwOrdencompraDao;
        static readonly IVwOrdencompradetDao VwOrdencompradetDao = Factory.VwOrdencompradetDao;
        static readonly IVwCpcompraDao VwCpcompraDao = Factory.VwCpcompraDao;
        static readonly IVwCpcompradetDao VwCpcompradetDao = Factory.VwCpcompradetDao;
        static readonly IVwRequerimientodetordcompraimpDao VwRequerimientodetordcompraimpDao = Factory.VwRequerimientodetordcompraimpDao;
        static readonly IVwRequerimientosaaprobarDao VwRequerimientosaaprobarDao = Factory.VwRequerimientosaaprobarDao;
        static readonly IVwProyectoDao VwProyectoDao = Factory.VwProyectoDao;
        static readonly IEstadoreqDao EstadoreqDao = Factory.EstadoreqDao;
        static readonly IVwOrdencompraimpresionDao VwOrdencompraimpresionDao = Factory.VwOrdencompraimpresionDao;
        static readonly IVwOrdencompradetingresoimpDao VwOrdencompradetingresoimpDao = Factory.VwOrdencompradetingresoimpDao;
        static readonly IVwOrdencompradetcpcompraimpDao VwOrdencompradetcpcompraimpDao = Factory.VwOrdencompradetcpcompraimpDao;
        static readonly INotacreditoDao NotacreditoDao = Factory.NotacreditoDao;
        static readonly INotacreditodetDao NotacreditodetDao = Factory.NotacreditodetDao;
        static readonly IVwNotacreditoDao VwNotacreditoDao = Factory.VwNotacreditoDao;
        static readonly IVwNotacreditodetDao VwNotacreditodetDao = Factory.VwNotacreditodetDao;
        static readonly IEstadopagoDao EstadopagoDao = Factory.EstadopagoDao;
        static readonly INotadebitoDao NotadebitoDao = Factory.NotadebitoDao;
        static readonly INotadebitodetDao NotadebitodetDao = Factory.NotadebitodetDao;
        static readonly IVwNotadebitoDao VwNotadebitoDao = Factory.VwNotadebitoDao;
        static readonly IVwNotadebitodetDao VwNotadebitodetDao = Factory.VwNotadebitodetDao;
        static readonly IVwCpcompraimpncDao VwCpcompraimpncDao = Factory.VwCpcompraimpncDao;
        static readonly IVwCpcompraimpndDao VwCpcompraimpndDao = Factory.VwCpcompraimpndDao;
        static readonly ICotizacionprvDao CotizacionprvDao = Factory.CotizacionprvDao;
        static readonly ICotizacionprvdetDao CotizacionprvdetDao = Factory.CotizacionprvdetDao;
        static readonly ICuadrocomparativoDao CuadrocomparativoDao = Factory.CuadrocomparativoDao;
        static readonly ICuadrocomparativoarticuloDao CuadrocomparativoarticuloDao = Factory.CuadrocomparativoarticuloDao;
        static readonly ICuadrocomparativoprvDao CuadrocomparativoprvDao = Factory.CuadrocomparativoprvDao;
        static readonly IVwCotizacionprvDao VwCotizacionprvDao = Factory.VwCotizacionprvDao;
        static readonly IVwCotizacionprvdetDao VwCotizacionprvdetDao = Factory.VwCotizacionprvdetDao;
        static readonly IVwCuadrocomparativoDao VwCuadrocomparativoDao = Factory.VwCuadrocomparativoDao;
        static readonly IVwCuadrocomparativoarticuloDao VwCuadrocomparativoarticuloDao = Factory.VwCuadrocomparativoarticuloDao;
        static readonly IVwCuadrocomparativoprvDao VwCuadrocomparativoprvDao = Factory.VwCuadrocomparativoprvDao;
        static readonly IVwRequerimientodetcotizaprvimpDao VwRequerimientodetcotizaprvimpDao = Factory.VwRequerimientodetcotizaprvimpDao;
        static readonly IVwRequerimientodetimpguiaremisionDao VwRequerimientodetimpguiaremisionDao = Factory.VwRequerimientodetimpguiaremisionDao;
        static readonly ITiporegistroordenDao TiporegistroordenDao = Factory.TiporegistroordenDao;
        static readonly IVwCuadrocomparativoarticuloimpocDao VwCuadrocomparativoarticuloimpocDao = Factory.VwCuadrocomparativoarticuloimpocDao;
        static readonly IVwCuadrocomparativoaaprobarDao VwCuadrocomparativoaaprobarDao = Factory.VwCuadrocomparativoaaprobarDao;
        static readonly IVwCuadrocomparativomodeloautorizacionDao VwCuadrocomparativomodeloautorizacionDao = Factory.VwCuadrocomparativomodeloautorizacionDao;
        static readonly IOrdenservicioDao OrdenservicioDao = Factory.OrdenservicioDao;
        static readonly IOrdenserviciodetDao OrdenserviciodetDao = Factory.OrdenserviciodetDao;
        static readonly IVwCuadrocomparativoarticuloimposDao VwCuadrocomparativoarticuloimposDao = Factory.VwCuadrocomparativoarticuloimposDao;
        static readonly IVwOrdenservicioDao VwOrdenservicioDao = Factory.VwOrdenservicioDao;
        static readonly IVwOrdenserviciodetDao VwOrdenserviciodetDao = Factory.VwOrdenserviciodetDao;
        static readonly IVwOrdenservicioimpresionDao VwOrdenservicioimpresionDao = Factory.VwOrdenservicioimpresionDao;
        static readonly IVwRequerimientodetordservicioimpDao VwRequerimientodetordservicioimpDao = Factory.VwRequerimientodetordservicioimpDao;
        static readonly IVwOrdenserviciodetcpcompraimpDao VwOrdenserviciodetcpcompraimpDao = Factory.VwOrdenserviciodetcpcompraimpDao;
        static readonly IVwCpcompradetguiaremisionimpDao VwCpcompradetguiaremisionimpDao = Factory.VwCpcompradetguiaremisionimpDao;
        static readonly IEntradaalmacendetitemcpcompradetDao EntradaalmacendetitemcpcompradetDao = Factory.EntradaalmacendetitemcpcompradetDao;
        static readonly ICpcompradetserieDao CpcompradetserieDao = Factory.CpcompradetserieDao;
        static readonly IVwCpcompradetserieDao VwCpcompradetserieDao = Factory.VwCpcompradetserieDao;
        #endregion

        #region Finanzas 
        static readonly ITiporecibocajaDao TiporecibocajaDao = Factory.TiporecibocajaDao;
        static readonly IVwCtacteclienteDao VwCtacteclienteDao = Factory.VwCtacteclienteDao;
        static readonly IRendicioncajachicaDao RendicioncajachicaDao = Factory.RendicioncajachicaDao;
        static readonly IRendicioncajachicadetDao RendicioncajachicadetDao = Factory.RendicioncajachicadetDao;
        static readonly IVwRendicioncajachicaDao VwRendicioncajachicaDao = Factory.VwRendicioncajachicaDao;
        static readonly IVwRendicioncajachicadetDao VwRendicioncajachicadetDao = Factory.VwRendicioncajachicadetDao;

        static readonly IRecibocajaingresoDao RecibocajaingresoDao = Factory.RecibocajaingresoDao;
        static readonly IRecibocajaingresodetDao RecibocajaingresodetDao = Factory.RecibocajaingresodetDao;
        static readonly IRecibocajaingresoimprevistoDao RecibocajaingresoimprevistoDao = Factory.RecibocajaingresoimprevistoDao;
        static readonly IVwRecibocajaingresoDao VwRecibocajaingresoDao = Factory.VwRecibocajaingresoDao;
        static readonly IVwRecibocajaingresodetDao VwRecibocajaingresodetDao = Factory.VwRecibocajaingresodetDao;
        static readonly IVwRecibocajaingresoimprevistoDao VwRecibocajaingresoimprevistoDao = Factory.VwRecibocajaingresoimprevistoDao;

        static readonly IRecibocajaegresoDao RecibocajaegresoDao = Factory.RecibocajaegresoDao;
        static readonly IRecibocajaegresodetDao RecibocajaegresodetDao = Factory.RecibocajaegresodetDao;
        static readonly IRecibocajaegresoimprevistoDao RecibocajaegresoimprevistoDao = Factory.RecibocajaegresoimprevistoDao;
        static readonly IVwRecibocajaegresoDao VwRecibocajaegresoDao = Factory.VwRecibocajaegresoDao;
        static readonly IVwRecibocajaegresodetDao VwRecibocajaegresodetDao = Factory.VwRecibocajaegresodetDao;
        static readonly IVwRecibocajaegresoimprevistoDao VwRecibocajaegresoimprevistoDao = Factory.VwRecibocajaegresoimprevistoDao;

        static readonly IVwCtacteproveedorDao VwCtacteproveedorDao = Factory.VwCtacteproveedorDao;
        #endregion

        #region Inntecc

        static readonly IAccesoformDao AccesoformDao = Factory.AccesoformDao;
        static readonly IAreaDao AreaDao = Factory.AreaDao;
        static readonly IAreacentrocostroDao AreacentrocostroDao = Factory.AreacentrocostroDao;
        static readonly IArticuloDao ArticuloDao = Factory.ArticuloDao;
        static readonly IArticuloclasificacionDao ArticuloclasificacionDao = Factory.ArticuloclasificacionDao;
        static readonly IArticulodetalleunidadDao ArticulodetalleunidadDao = Factory.ArticulodetalleunidadDao;
        static readonly IArticuloimagenDao ArticuloimagenDao = Factory.ArticuloimagenDao;
        static readonly IArticuloubicacionDao ArticuloubicacionDao = Factory.ArticuloubicacionDao;
        static readonly ICentrodecostoDao CentrodecostoDao = Factory.CentrodecostoDao;
        static readonly ICptooperacionDao CptooperacionDao = Factory.CptooperacionDao;
        static readonly ICuentacontableDao CuentacontableDao = Factory.CuentacontableDao;
        static readonly IDepartamentoDao DepartamentoDao = Factory.DepartamentoDao;
        static readonly IDistritoDao DistritoDao = Factory.DistritoDao;
        static readonly IEjercicioDao EjercicioDao = Factory.EjercicioDao;
        static readonly IEmpleadoDao EmpleadoDao = Factory.EmpleadoDao;
        static readonly IEmpleadoanexoDao EmpleadoanexoDao = Factory.EmpleadoanexoDao;
        static readonly IEmpresaDao EmpresaDao = Factory.EmpresaDao;
        static readonly IEntidadfinancieraDao EntidadfinancieraDao = Factory.EntidadfinancieraDao;
        static readonly IGrupousuarioDao GrupousuarioDao = Factory.GrupousuarioDao;
        static readonly IImpuestoDao ImpuestoDao = Factory.ImpuestoDao;
        static readonly IImpuestoiscDao ImpuestoiscDao = Factory.ImpuestoiscDao;
        static readonly IListaprecioDao ListaprecioDao = Factory.ListaprecioDao;
        static readonly IMarcaDao MarcaDao = Factory.MarcaDao;
        static readonly IPeriodoDao PeriodoDao = Factory.PeriodoDao;
        static readonly IPersonaDao PersonaDao = Factory.PersonaDao;
        static readonly IPersonacontactoDao PersonacontactoDao = Factory.PersonacontactoDao;
        static readonly IPrioridadDao PrioridadDao = Factory.PrioridadDao;
        static readonly IProvinciaDao ProvinciaDao = Factory.ProvinciaDao;
        static readonly IProyectoDao ProyectoDao = Factory.ProyectoDao;
        static readonly ISocionegentidadfinancieraDao SocionegentidadfinancieraDao = Factory.SocionegentidadfinancieraDao;
        static readonly ISocionegocioDao SocionegocioDao = Factory.SocionegocioDao;
        static readonly ISocionegociocontactoDao SocionegociocontactoDao = Factory.SocionegociocontactoDao;
        static readonly ISocionegociodireccionDao SocionegociodireccionDao = Factory.SocionegociodireccionDao;
        static readonly ISocionegociolimitecreditoDao SocionegociolimitecreditoDao = Factory.SocionegociolimitecreditoDao;
        static readonly ISocionegocioproyectoDao SocionegocioproyectoDao = Factory.SocionegocioproyectoDao;
        static readonly ISucursalDao SucursalDao = Factory.SucursalDao;
        static readonly ITipocondicionDao TipocondicionDao = Factory.TipocondicionDao;
        static readonly ITipocpDao TipocpDao = Factory.TipocpDao;
        static readonly ITipocppagoDao TipocppagoDao = Factory.TipocppagoDao;
        static readonly ITipodocentidadDao TipodocentidadDao = Factory.TipodocentidadDao;
        static readonly ITipoformatoDao TipoformatoDao = Factory.TipoformatoDao;
        static readonly ITipolistaDao TipolistaDao = Factory.TipolistaDao;
        static readonly ITipomediopagoDao TipomediopagoDao = Factory.TipomediopagoDao;
        static readonly ITipomonedaDao TipomonedaDao = Factory.TipomonedaDao;
        static readonly ITipooperacionDao TipooperacionDao = Factory.TipooperacionDao;
        static readonly ITiposcontactoDao TiposcontactoDao = Factory.TiposcontactoDao;
        static readonly ITiposocioDao TiposocioDao = Factory.TiposocioDao;
        static readonly IUnidadmedidaDao UnidadmedidaDao = Factory.UnidadmedidaDao;
        static readonly IUsuarioDao UsuarioDao = Factory.UsuarioDao;
        static readonly IVwPersonaDao VwPersonaDao = Factory.VwPersonaDao;
        static readonly IVwSucursalDao VwSucursalDao = Factory.VwSucursalDao;
        static readonly IVwTipocpDao VwTipocpDao = Factory.VwTipocpDao;
        static readonly IVwUbigeoDao VwUbigeoDao = Factory.VwUbigeoDao;
        static readonly IVwAreaDao VwAreaDao = Factory.VwAreaDao;
        static readonly IVwPersonacontactoDao VwPersonacontactoDao = Factory.VwPersonacontactoDao;
        static readonly IVwSocionegocioDao VwSocionegocioDao = Factory.VwSocionegocioDao;
        static readonly IVwEmpleadoDao VwEmpleadoDao = Factory.VwEmpleadoDao;
        static readonly IVwListaprecioDao VwListaprecioDao = Factory.VwListaprecioDao;
        static readonly IVwArticuloDao VwArticuloDao = Factory.VwArticuloDao;
        static readonly IVwPeriodoDao VwPeriodoDao = Factory.VwPeriodoDao;
        static readonly ITipodocmovDao TipodocmovDao = Factory.TipodocmovDao;
        static readonly IVwCptooperacionDao VwCptooperacionDao = Factory.VwCptooperacionDao;
        static readonly IVwUsuarioDao VwUsuarioDao = Factory.VwUsuarioDao;
        static readonly IVwArticulodetalleunidadDao VwArticulodetalleunidadDao = Factory.VwArticulodetalleunidadDao;
        static readonly IVwArticuloubicacionDao VwArticuloubicacionDao = Factory.VwArticuloubicacionDao;
        static readonly IEmpleadoareaDao EmpleadoareaDao = Factory.EmpleadoareaDao;
        static readonly IEmpleadoareaproyectoDao EmpleadoareaproyectoDao = Factory.EmpleadoareaproyectoDao;
        static readonly IVwEmpleadoareaDao VwEmpleadoareaDao = Factory.VwEmpleadoareaDao;
        static readonly IVwEmpleadoareaproyectoDao VwEmpleadoareaproyectoDao = Factory.VwEmpleadoareaproyectoDao;
        static readonly IValorpordefectoDao ValorpordefectoDao = Factory.ValorpordefectoDao;
        static readonly IVwAccesoformDao VwAccesoformDao = Factory.VwAccesoformDao;
        static readonly IVwGrupousuarioitemDao VwGrupousuarioitemDao = Factory.VwGrupousuarioitemDao;
        static readonly IVwPaginaitemDao VwPaginaitemDao = Factory.VwPaginaitemDao;
        static readonly IGrupousuarioitemDao GrupousuarioitemDao = Factory.GrupousuarioitemDao;
        static readonly IVwAccesoopcionDao VwAccesoopcionDao = Factory.VwAccesoopcionDao;
        static readonly IVwSocionegociodireccionDao VwSocionegociodireccionDao = Factory.VwSocionegociodireccionDao;
        static readonly IVwSocionegociolimitecreditoDao VwSocionegociolimitecreditoDao = Factory.VwSocionegociolimitecreditoDao;
        static readonly ITipoafectacionigvDao TipoafectacionigvDao = Factory.TipoafectacionigvDao;
        static readonly IVwSocionegentidadfinancieraDao VwSocionegentidadfinancieraDao = Factory.VwSocionegentidadfinancieraDao;
        static readonly IVwSocionegocioproyectoDao VwSocionegocioproyectoDao = Factory.VwSocionegocioproyectoDao;
        static readonly IVwCentrodecostoDao VwCentrodecostoDao = Factory.VwCentrodecostoDao;
        static readonly IAutorizaciontipocondicionDao AutorizaciontipocondicionDao = Factory.AutorizaciontipocondicionDao;
        static readonly IEtapaautorizacionDao EtapaautorizacionDao = Factory.EtapaautorizacionDao;
        static readonly IEtapaautorizaciondetalleDao EtapaautorizaciondetalleDao = Factory.EtapaautorizaciondetalleDao;
        static readonly IModeloautorizacionDao ModeloautorizacionDao = Factory.ModeloautorizacionDao;
        static readonly IModeloautorizacioncondicionDao ModeloautorizacioncondicionDao = Factory.ModeloautorizacioncondicionDao;
        static readonly IModeloautorizacionetapaDao ModeloautorizacionetapaDao = Factory.ModeloautorizacionetapaDao;
        static readonly ITiporatioDao TiporatioDao = Factory.TiporatioDao;
        static readonly IVwEtapaautorizacionDao VwEtapaautorizacionDao = Factory.VwEtapaautorizacionDao;
        static readonly IVwEtapaautorizaciondetalleDao VwEtapaautorizaciondetalleDao = Factory.VwEtapaautorizaciondetalleDao;
        static readonly IVwModeloautorizacionDao VwModeloautorizacionDao = Factory.VwModeloautorizacionDao;
        static readonly IVwModeloautorizacioncondicionDao VwModeloautorizacioncondicionDao = Factory.VwModeloautorizacioncondicionDao;
        static readonly IVwModeloautorizacionetapaDao VwModeloautorizacionetapaDao = Factory.VwModeloautorizacionetapaDao;
        static readonly IDocumentoaprobacionDao DocumentoaprobacionDao = Factory.DocumentoaprobacionDao;
        static readonly IVwModeloautorizacioninfoDao VwModeloautorizacioninfoDao = Factory.VwModeloautorizacioninfoDao;
        static readonly IVwDocumentoaprobacionDao VwDocumentoaprobacionDao = Factory.VwDocumentoaprobacionDao;
        static readonly ITipoarticuloDao TipoarticuloDao = Factory.TipoarticuloDao;
        static readonly IElementogastoDao ElementogastoDao = Factory.ElementogastoDao;
        static readonly IVwReporteusuarioDao VwReporteusuarioDao = Factory.VwReporteusuarioDao;
        static readonly IArticulocompuestoDao ArticulocompuestoDao = Factory.ArticulocompuestoDao;
        static readonly IVwArticulocompuestoDao VwArticulocompuestoDao = Factory.VwArticulocompuestoDao;
        static readonly IVwArticuloinventarioDao VwArticuloinventarioDao = Factory.VwArticuloinventarioDao;
        static readonly IVwArticulounidadDao VwArticulounidadDao = Factory.VwArticulounidadDao;
        static readonly IReporteDao ReporteDao = Factory.ReporteDao;
        static readonly ITipocambioDao TipocambioDao = Factory.TipocambioDao;
        static readonly IVwTipocambioDao VwTipocambioDao = Factory.VwTipocambioDao;
        static readonly ITipogestionarticuloDao TipogestionarticuloDao = Factory.TipogestionarticuloDao;
        static readonly IEstadoarticuloDao EstadoarticuloDao = Factory.EstadoarticuloDao;
        static readonly ICategoriasocionegocioDao CategoriasocionegocioDao = Factory.CategoriasocionegocioDao;
        static readonly IGrupoeconomicoDao GrupoeconomicoDao = Factory.GrupoeconomicoDao;
        static readonly IPaisDao PaisDao = Factory.PaisDao;
        static readonly IRubronegocioDao RubronegocioDao = Factory.RubronegocioDao;
        static readonly ISocionegociogarantiaDao SocionegociogarantiaDao = Factory.SocionegociogarantiaDao;
        static readonly ISocionegociomarcaDao SocionegociomarcaDao = Factory.SocionegociomarcaDao;
        static readonly ITipogarantiaDao TipogarantiaDao = Factory.TipogarantiaDao;
        static readonly IVwSocionegociogarantiaDao VwSocionegociogarantiaDao = Factory.VwSocionegociogarantiaDao;
        static readonly IVwSocionegociomarcaDao VwSocionegociomarcaDao = Factory.VwSocionegociomarcaDao;
        static readonly IZonaDao ZonaDao = Factory.ZonaDao;
        static readonly IEstadosocionegocioDao EstadosocionegocioDao = Factory.EstadosocionegocioDao;
        static readonly IVwTipolistatipocondicionDao VwTipolistatipocondicionDao = Factory.VwTipolistatipocondicionDao;
        static readonly IVwArticuloclasificacionDao VwArticuloclasificacionDao = Factory.VwArticuloclasificacionDao;
        static readonly IEstadocivilDao EstadocivilDao = Factory.EstadocivilDao;
        static readonly ITipocontratoempleadoDao TipocontratoempleadoDao = Factory.TipocontratoempleadoDao;
        static readonly ITiposnpDao TiposnpDao = Factory.TiposnpDao;
        static readonly IArticuloseriedetDao ArticuloseriedetDao = Factory.ArticuloseriedetDao;
        static readonly ISeriearticuloDao SeriearticuloDao = Factory.SeriearticuloDao;
        static readonly IVwArticuloseriedetDao VwArticuloseriedetDao = Factory.VwArticuloseriedetDao;
        static readonly IDiaferiadoDao DiaferiadoDao = Factory.DiaferiadoDao;
        #endregion

        #region Ventas

        static readonly IArticulolistaprecioDao ArticulolistaprecioDao = Factory.ArticulolistaprecioDao;
        static readonly ICotizacionclienteDao CotizacionclienteDao = Factory.CotizacionclienteDao;
        static readonly ICotizacionclientedetDao CotizacionclientedetDao = Factory.CotizacionclientedetDao;
        static readonly ICpventaDao CpventaDao = Factory.CpventaDao;
        static readonly ICpventadetDao CpventadetDao = Factory.CpventadetDao;
        static readonly IGuiaremisionmotivoDao GuiaremisionmotivoDao = Factory.GuiaremisionmotivoDao;
        static readonly IOrdendeventaDao OrdendeventaDao = Factory.OrdendeventaDao;
        static readonly IOrdendeventadetDao OrdendeventadetalleDao = Factory.OrdendeventadetalleDao;
        static readonly IVwCotizacionclienteDao VwCotizacionclienteDao = Factory.VwCotizacionclienteDao;
        static readonly IVwCotizacionclientedetDao VwCotizacionclientedetDao = Factory.VwCotizacionclientedetDao;
        static readonly IVwOrdendeventaDao VwOrdendeventaDao = Factory.VwOrdendeventaDao;
        static readonly IVwOrdendeventadetalleDao VwOrdendeventadetalleDao = Factory.VwOrdendeventadetalleDao;
        static readonly IVwCpventaDao VwCpventaDao = Factory.VwCpventaDao;
        static readonly IVwCpventadetDao VwCpventadetDao = Factory.VwCpventadetDao;
        static readonly IVwArticulolistaprecioDao VwArticulolistaprecioDao = Factory.VwArticulolistaprecioDao;
        static readonly INotacreditocliDao NotacreditocliDao = Factory.NotacreditocliDao;
        static readonly INotacreditoclidetDao NotacreditoclidetDao = Factory.NotacreditoclidetDao;
        static readonly INotadebitocliDao NotadebitocliDao = Factory.NotadebitocliDao;
        static readonly IVwCpventaimpncDao VwCpventaimpncDao = Factory.VwCpventaimpncDao;
        static readonly IVwCpventaimpndDao VwCpventaimpndDao = Factory.VwCpventaimpndDao;
        static readonly IVwNotacreditocliDao VwNotacreditocliDao = Factory.VwNotacreditocliDao;
        static readonly IVwNotacreditoclidetDao VwNotacreditoclidetDao = Factory.VwNotacreditoclidetDao;
        static readonly IVwNotadebitocliDao VwNotadebitocliDao = Factory.VwNotadebitocliDao;
        static readonly INotadebitoclidetDao NotadebitoclidetDao = Factory.NotadebitoclidetDao;
        static readonly IVwNotadebitoclidetDao VwNotadebitoclidetDao = Factory.VwNotadebitoclidetDao;
        static readonly IVwCotizacionclientedetovimpDao VwCotizacionclientedetovimpDao = Factory.VwCotizacionclientedetovimpDao;
        static readonly IVwOrdendeventadetcpventaimpDao VwOrdendeventadetcpventaimpDao = Factory.VwOrdendeventadetcpventaimpDao;
        static readonly IVwOrdendeventadetvalorizaimpDao VwOrdendeventadetvalorizaimpDao = Factory.VwOrdendeventadetvalorizaimpDao;
        static readonly IVwArticulostocklistaDao VwArticulostocklistaDao = Factory.VwArticulostocklistaDao;
        static readonly IVwOrdendeventadetimpguiaremisionDao VwOrdendeventadetimpguiaremisionDao = Factory.VwOrdendeventadetimpguiaremisionDao;
        static readonly IVwOrdendeventavalorizacpventaimpDao VwOrdendeventavalorizacpventaimpDao = Factory.VwOrdendeventavalorizacpventaimpDao;
        static readonly IComisioncobroDao ComisioncobroDao = Factory.ComisioncobroDao;
        static readonly IComisioncobrodetDao ComisioncobrodetDao = Factory.ComisioncobrodetDao;
        static readonly ITipocomisioncobroDao TipocomisioncobroDao = Factory.TipocomisioncobroDao;
        static readonly IVwComisioncobroDao VwComisioncobroDao = Factory.VwComisioncobroDao;
        static readonly IDetraccionclienteDao DetraccionclienteDao = Factory.DetraccionclienteDao;
        static readonly IVwDetraccionclienteDao VwDetraccionclienteDao = Factory.VwDetraccionclienteDao;
        static readonly ITipolistatipocondicionDao TipolistatipocondicionDao = Factory.TipolistatipocondicionDao;
        static readonly ICpventadetserieDao CpventadetserieDao = Factory.CpventadetserieDao;
        static readonly IVwCpventadetserieDao VwCpventadetserieDao = Factory.VwCpventadetserieDao;
        static readonly IVwNotacreditoclireciboingresoimpDao VwNotacreditoclireciboingresoimpDao = Factory.VwNotacreditoclireciboingresoimpDao;
        #endregion

        #region Logistica
        static readonly ILogStocksDao LogStocksDao = Factory.LogStocksDao;
        #endregion

        #region Maquinaria
        static readonly IClasificacionequipoDao ClasificacionequipoDao = Factory.ClasificacionequipoDao;
        static readonly IEquipoDao EquipoDao = Factory.EquipoDao;
        static readonly IMarcaequipoDao MarcaequipoDao = Factory.MarcaequipoDao;
        static readonly IModeloequipoDao ModeloequipoDao = Factory.ModeloequipoDao;
        static readonly IVwEquipoDao VwEquipoDao = Factory.VwEquipoDao;
        static readonly IVwModeloequipoDao VwModeloequipoDao = Factory.VwModeloequipoDao;
        static readonly ITipoalquilerDao TipoalquilerDao = Factory.TipoalquilerDao;
        static readonly ITipoegresovalorizacionDao TipoegresovalorizacionDao = Factory.TipoegresovalorizacionDao;
        static readonly IValorizacionDao ValorizacionDao = Factory.ValorizacionDao;
        static readonly IValorizaciondetDao ValorizaciondetDao = Factory.ValorizaciondetDao;
        static readonly IValorizacionegresoDao ValorizacionegresoDao = Factory.ValorizacionegresoDao;
        static readonly IVwValorizacionDao VwValorizacionDao = Factory.VwValorizacionDao;
        static readonly IVwValorizaciondetDao VwValorizaciondetDao = Factory.VwValorizaciondetDao;
        static readonly IVwValorizacionegresoDao VwValorizacionegresoDao = Factory.VwValorizacionegresoDao;

        static readonly IValorizacionegresoproveedorDao ValorizacionegresoproveedorDao = Factory.ValorizacionegresoproveedorDao;
        static readonly IValorizacionproveedorDao ValorizacionproveedorDao = Factory.ValorizacionproveedorDao;
        static readonly IValorizacionproveedordetDao ValorizacionproveedordetDao = Factory.ValorizacionproveedordetDao;
        static readonly IVwValorizacionegresoproveedorDao VwValorizacionegresoproveedorDao = Factory.VwValorizacionegresoproveedorDao;
        static readonly IVwValorizacionproveedorDao VwValorizacionproveedorDao = Factory.VwValorizacionproveedorDao;
        static readonly IVwValorizacionproveedordetDao VwValorizacionproveedordetDao = Factory.VwValorizacionproveedordetDao;
        static readonly IVwOrdendeserviciodetvalorizaimpDao VwOrdendeserviciodetvalorizaimpDao = Factory.VwOrdendeserviciodetvalorizaimpDao;
        static readonly IMantenimientoDao MantenimientoDao = Factory.MantenimientoDao;
        static readonly IMantenimientoimagenDao MantenimientoimagenDao = Factory.MantenimientoimagenDao;
        static readonly IVwMantenimientoDao VwMantenimientoDao = Factory.VwMantenimientoDao;
        static readonly IOrdentrabajoDao OrdentrabajoDao = Factory.OrdentrabajoDao;
        static readonly IVwOrdentrabajoDao VwOrdentrabajoDao = Factory.VwOrdentrabajoDao;

        static readonly IValorizaciondanioDao ValorizaciondanioDao = Factory.ValorizaciondanioDao;
        static readonly IValorizaciondanioelementoDao ValorizaciondanioelementoDao = Factory.ValorizaciondanioelementoDao;
        static readonly IValorizacionelementoDao ValorizacionelementoDao = Factory.ValorizacionelementoDao;
        static readonly IVwValorizaciondanioDao VwValorizaciondanioDao = Factory.VwValorizaciondanioDao;
        static readonly IVwValorizaciondanioelementoDao VwValorizaciondanioelementoDao = Factory.VwValorizaciondanioelementoDao;
        static readonly IVwValorizacionelementoDao VwValorizacionelementoDao = Factory.VwValorizacionelementoDao;
        static readonly IVwResumenelementodanioDao VwResumenelementodanioDao = Factory.VwResumenelementodanioDao;
        #endregion

        #region Clinica

        static readonly IEstadocitaDao EstadocitaDao = Factory.EstadocitaDao;
        static readonly IProgramacioncitaDao ProgramacioncitaDao = Factory.ProgramacioncitaDao;
        static readonly IProgramacioncitadetDao ProgramacioncitadetDao = Factory.ProgramacioncitadetDao;
        static readonly IVwProgramacioncitaDao VwProgramacioncitaDao = Factory.VwProgramacioncitaDao;
        static readonly IVwProgramacioncitadetDao VwProgramacioncitadetDao = Factory.VwProgramacioncitadetDao;
        static readonly IMotivocitaDao MotivocitaDao = Factory.MotivocitaDao;
        static readonly IProgramacioncitadethistorialDao ProgramacioncitadethistorialDao = Factory.ProgramacioncitadethistorialDao;
        static readonly IVwProgramacioncitadethistorialDao VwProgramacioncitadethistorialDao = Factory.VwProgramacioncitadethistorialDao;

        static readonly IHistoriaclinicaDao HistoriaclinicaDao = Factory.HistoriaclinicaDao;
        static readonly IHistoriaclinicaanalisisDao HistoriaclinicaanalisisDao = Factory.HistoriaclinicaanalisisDao;
        static readonly IHistoriaclinicacitaDao HistoriaclinicacitaDao = Factory.HistoriaclinicacitaDao;
        static readonly ITipoanalisisDao TipoanalisisDao = Factory.TipoanalisisDao;
        static readonly ITipociclomenstrualDao TipociclomenstrualDao = Factory.TipociclomenstrualDao;
        static readonly IVwHistoriaclinicaDao VwHistoriaclinicaDao = Factory.VwHistoriaclinicaDao;
        static readonly IVwHistoriaclinicaanalisisDao VwHistoriaclinicaanalisisDao = Factory.VwHistoriaclinicaanalisisDao;
        static readonly IVwHistoriaclinicacitaDao VwHistoriaclinicacitaDao = Factory.VwHistoriaclinicacitaDao;

        static readonly ICategoriaitemDao CategoriaitemDao = Factory.CategoriaitemDao;
        static readonly IHistoriaDao HistoriaDao = Factory.HistoriaDao;
        static readonly IHistoriaarchivoDao HistoriaarchivoDao = Factory.HistoriaarchivoDao;
        static readonly IHistoriadetDao HistoriadetDao = Factory.HistoriadetDao;
        static readonly IHistoriadetitemDao HistoriadetitemDao = Factory.HistoriadetitemDao;
        static readonly IItemhistoriaDao ItemhistoriaDao = Factory.ItemhistoriaDao;
        static readonly IPlantillahistoriaDao PlantillahistoriaDao = Factory.PlantillahistoriaDao;
        static readonly IPlantillahistoriadetDao PlantillahistoriadetDao = Factory.PlantillahistoriadetDao;
        static readonly ITipoarchivoDao TipoarchivoDao = Factory.TipoarchivoDao;
        static readonly ITipohistoriaDao TipohistoriaDao = Factory.TipohistoriaDao;
        static readonly IVwHistoriaDao VwHistoriaDao = Factory.VwHistoriaDao;
        static readonly IVwHistoriaarchivoDao VwHistoriaarchivoDao = Factory.VwHistoriaarchivoDao;
        static readonly IVwHistoriadetDao VwHistoriadetDao = Factory.VwHistoriadetDao;
        static readonly IVwHistoriadetitemDao VwHistoriadetitemDao = Factory.VwHistoriadetitemDao;
        static readonly IVwItemhistoriaDao VwItemhistoriaDao = Factory.VwItemhistoriaDao;
        static readonly IVwPlantillahistoriaDao VwPlantillahistoriaDao = Factory.VwPlantillahistoriaDao;
        static readonly IVwPlantillahistoriadetDao VwPlantillahistoriadetDao = Factory.VwPlantillahistoriadetDao;

        #endregion

        #region Movil

        static readonly IClaseDao ClaseDao = Factory.ClaseDao;
        static readonly IPlanDao PlanDao = Factory.PlanDao;
        static readonly ITipoDao TipoDao = Factory.TipoDao;
        static readonly ITipotopeDao TipotopeDao = Factory.TipotopeDao;

        #endregion


    }
}
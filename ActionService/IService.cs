using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public interface IService
    {
        #region Almacen

        #region Almacen service

        long CountAlmacen();
        long CountAlmacen(Expression<Func<Almacen, bool>> criteria);
        int SaveAlmacen(Almacen entity);
        void UpdateAlmacen(Almacen entity);
        void DeleteAlmacen(int id);
        List<Almacen> GetAllAlmacen();
        List<Almacen> GetAllAlmacen(Expression<Func<Almacen, bool>> criteria);
        List<Almacen> GetAllAlmacen(string orders);
        List<Almacen> GetAllAlmacen(string conditions, string orders);
        Almacen GetAlmacen(int id);
        Almacen GetAlmacen(Expression<Func<Almacen, bool>> criteria);
        bool RegistrarUbicacionPorDefectoInventario(int idempresa, int idArticulo, int idInventarioInicial);

        #endregion

        #region Entradaalmacen service

        long CountEntradaalmacen();
        long CountEntradaalmacen(Expression<Func<Entradaalmacen, bool>> criteria);
        int SaveEntradaalmacen(Entradaalmacen entity);
        void UpdateEntradaalmacen(Entradaalmacen entity);
        void DeleteEntradaalmacen(int id);
        List<Entradaalmacen> GetAllEntradaalmacen();
        List<Entradaalmacen> GetAllEntradaalmacen(Expression<Func<Entradaalmacen, bool>> criteria);
        List<Entradaalmacen> GetAllEntradaalmacen(string orders);
        List<Entradaalmacen> GetAllEntradaalmacen(string conditions, string orders);
        Entradaalmacen GetEntradaalmacen(int id);
        Entradaalmacen GetEntradaalmacen(Expression<Func<Entradaalmacen, bool>> criteria);
        void AnularReferenciaEntradaOrdenCompraDet(int identradaalmacen);
        bool EntradaAlmacenTieneReferenciaVerificacion(int idEntradaAlmacen);
        void AnularEntradaDeAlmacen(string sqlCommand);
        void ActualizarArticuloListaPrecioDesdeCostoPromedio(int idArticulo, int idlistaprecio, decimal costoPromedio);
        bool ActualizarTotalesEntradaAlmacen(Entradaalmacen entradaalmacen);
        bool NumeroEntradaAlmacenExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        #endregion

        #region Entradaalmacendet service

        long CountEntradaalmacendet();
        long CountEntradaalmacendet(Expression<Func<Entradaalmacendet, bool>> criteria);
        int SaveEntradaalmacendet(Entradaalmacendet entity);
        void UpdateEntradaalmacendet(Entradaalmacendet entity);
        void DeleteEntradaalmacendet(int id);
        List<Entradaalmacendet> GetAllEntradaalmacendet();
        List<Entradaalmacendet> GetAllEntradaalmacendet(Expression<Func<Entradaalmacendet, bool>> criteria);
        List<Entradaalmacendet> GetAllEntradaalmacendet(string orders);
        List<Entradaalmacendet> GetAllEntradaalmacendet(string conditions, string orders);
        Entradaalmacendet GetEntradaalmacendet(int id);
        Entradaalmacendet GetEntradaalmacendet(Expression<Func<Entradaalmacendet, bool>> criteria);
        void ActualizarEntradaalmacendetCantidadVerificada(Entradaalmacendet entradaalmacendet);

        #endregion

        #region Entradaalmacenubicacion service

        long CountEntradaalmacenubicacion();
        long CountEntradaalmacenubicacion(Expression<Func<Entradaalmacenubicacion, bool>> criteria);
        int SaveEntradaalmacenubicacion(Entradaalmacenubicacion entity);
        void UpdateEntradaalmacenubicacion(Entradaalmacenubicacion entity);
        void DeleteEntradaalmacenubicacion(int id);
        List<Entradaalmacenubicacion> GetAllEntradaalmacenubicacion();
        List<Entradaalmacenubicacion> GetAllEntradaalmacenubicacion(Expression<Func<Entradaalmacenubicacion, bool>> criteria);
        List<Entradaalmacenubicacion> GetAllEntradaalmacenubicacion(string orders);
        List<Entradaalmacenubicacion> GetAllEntradaalmacenubicacion(string conditions, string orders);
        Entradaalmacenubicacion GetEntradaalmacenubicacion(int id);
        Entradaalmacenubicacion GetEntradaalmacenubicacion(Expression<Func<Entradaalmacenubicacion, bool>> criteria);

        #endregion

        #region Guiaremision service

        long CountGuiaremision();
        long CountGuiaremision(Expression<Func<Guiaremision, bool>> criteria);
        int SaveGuiaremision(Guiaremision entity);
        void UpdateGuiaremision(Guiaremision entity);
        void DeleteGuiaremision(int id);
        List<Guiaremision> GetAllGuiaremision();
        List<Guiaremision> GetAllGuiaremision(Expression<Func<Guiaremision, bool>> criteria);
        List<Guiaremision> GetAllGuiaremision(string orders);
        List<Guiaremision> GetAllGuiaremision(string conditions, string orders);
        Guiaremision GetGuiaremision(int id);
        Guiaremision GetGuiaremision(Expression<Func<Guiaremision, bool>> criteria);
        bool GuardarGuiaremision(TipoMantenimiento tipoMantenimiento, Guiaremision entidadCab,List<VwGuiaremisiondet> entidadDetList);
        bool GuiaRemisionTieneReferenciaSalidaAlmacen(int idGuiaRemision);

        #endregion

        #region Guiaremisiondet service

        long CountGuiaremisiondet();
        long CountGuiaremisiondet(Expression<Func<Guiaremisiondet, bool>> criteria);
        int SaveGuiaremisiondet(Guiaremisiondet entity);
        void UpdateGuiaremisiondet(Guiaremisiondet entity);
        void DeleteGuiaremisiondet(int id);
        List<Guiaremisiondet> GetAllGuiaremisiondet();
        List<Guiaremisiondet> GetAllGuiaremisiondet(Expression<Func<Guiaremisiondet, bool>> criteria);
        List<Guiaremisiondet> GetAllGuiaremisiondet(string orders);
        List<Guiaremisiondet> GetAllGuiaremisiondet(string conditions, string orders);
        Guiaremisiondet GetGuiaremisiondet(int id);
        Guiaremisiondet GetGuiaremisiondet(Expression<Func<Guiaremisiondet, bool>> criteria);

        #endregion

        #region Salidaalmacen service

        long CountSalidaalmacen();
        long CountSalidaalmacen(Expression<Func<Salidaalmacen, bool>> criteria);
        int SaveSalidaalmacen(Salidaalmacen entity);
        void UpdateSalidaalmacen(Salidaalmacen entity);
        void DeleteSalidaalmacen(int id);
        List<Salidaalmacen> GetAllSalidaalmacen();
        List<Salidaalmacen> GetAllSalidaalmacen(Expression<Func<Salidaalmacen, bool>> criteria);
        List<Salidaalmacen> GetAllSalidaalmacen(string orders);
        List<Salidaalmacen> GetAllSalidaalmacen(string conditions, string orders);
        Salidaalmacen GetSalidaalmacen(int id);
        Salidaalmacen GetSalidaalmacen(Expression<Func<Salidaalmacen, bool>> criteria);
        void AnularSalidaDeAlmacen(string sqlCommand);
        bool ActualizarTotalesSalidaAlmacen(Salidaalmacen salidaalmacen);
        bool NumeroSalidaAlmacenExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        #endregion

        #region Salidaalmacendet service

        long CountSalidaalmacendet();
        long CountSalidaalmacendet(Expression<Func<Salidaalmacendet, bool>> criteria);
        int SaveSalidaalmacendet(Salidaalmacendet entity);
        void UpdateSalidaalmacendet(Salidaalmacendet entity);
        void DeleteSalidaalmacendet(int id);
        List<Salidaalmacendet> GetAllSalidaalmacendet();
        List<Salidaalmacendet> GetAllSalidaalmacendet(Expression<Func<Salidaalmacendet, bool>> criteria);
        List<Salidaalmacendet> GetAllSalidaalmacendet(string orders);
        List<Salidaalmacendet> GetAllSalidaalmacendet(string conditions, string orders);
        Salidaalmacendet GetSalidaalmacendet(int id);
        Salidaalmacendet GetSalidaalmacendet(Expression<Func<Salidaalmacendet, bool>> criteria);

        #endregion

        #region Salidaalmacenubicacion service

        long CountSalidaalmacenubicacion();
        long CountSalidaalmacenubicacion(Expression<Func<Salidaalmacenubicacion, bool>> criteria);
        int SaveSalidaalmacenubicacion(Salidaalmacenubicacion entity);
        void UpdateSalidaalmacenubicacion(Salidaalmacenubicacion entity);
        void DeleteSalidaalmacenubicacion(int id);
        List<Salidaalmacenubicacion> GetAllSalidaalmacenubicacion();
        List<Salidaalmacenubicacion> GetAllSalidaalmacenubicacion(Expression<Func<Salidaalmacenubicacion, bool>> criteria);
        List<Salidaalmacenubicacion> GetAllSalidaalmacenubicacion(string orders);
        List<Salidaalmacenubicacion> GetAllSalidaalmacenubicacion(string conditions, string orders);
        Salidaalmacenubicacion GetSalidaalmacenubicacion(int id);
        Salidaalmacenubicacion GetSalidaalmacenubicacion(Expression<Func<Salidaalmacenubicacion, bool>> criteria);

        #endregion

        #region VwAlmacen service

        long CountVwAlmacen();
        long CountVwAlmacen(Expression<Func<VwAlmacen, bool>> criteria);
        List<VwAlmacen> GetAllVwAlmacen();
        List<VwAlmacen> GetAllVwAlmacen(Expression<Func<VwAlmacen, bool>> criteria);
        List<VwAlmacen> GetAllVwAlmacen(string orders);
        List<VwAlmacen> GetAllVwAlmacen(string conditions, string orders);
        VwAlmacen GetVwAlmacen(int id);
        VwAlmacen GetVwAlmacen(Expression<Func<VwAlmacen, bool>> criteria);

        #endregion

        #region VwEntradaalmacen service

        long CountVwEntradaalmacen();
        long CountVwEntradaalmacen(Expression<Func<VwEntradaalmacen, bool>> criteria);
        List<VwEntradaalmacen> GetAllVwEntradaalmacen();
        List<VwEntradaalmacen> GetAllVwEntradaalmacen(Expression<Func<VwEntradaalmacen, bool>> criteria);
        List<VwEntradaalmacen> GetAllVwEntradaalmacen(string orders);
        List<VwEntradaalmacen> GetAllVwEntradaalmacen(string conditions, string orders);
        VwEntradaalmacen GetVwEntradaalmacen(int id);
        VwEntradaalmacen GetVwEntradaalmacen(Expression<Func<VwEntradaalmacen, bool>> criteria);

        #endregion

        #region VwEntradaalmacendet service

        long CountVwEntradaalmacendet();
        long CountVwEntradaalmacendet(Expression<Func<VwEntradaalmacendet, bool>> criteria);
        List<VwEntradaalmacendet> GetAllVwEntradaalmacendet();
        List<VwEntradaalmacendet> GetAllVwEntradaalmacendet(Expression<Func<VwEntradaalmacendet, bool>> criteria);
        List<VwEntradaalmacendet> GetAllVwEntradaalmacendet(string orders);
        List<VwEntradaalmacendet> GetAllVwEntradaalmacendet(string conditions, string orders);
        VwEntradaalmacendet GetVwEntradaalmacendet(int id);
        VwEntradaalmacendet GetVwEntradaalmacendet(Expression<Func<VwEntradaalmacendet, bool>> criteria);

        #endregion

        #region VwGuiaremision service

        long CountVwGuiaremision();
        long CountVwGuiaremision(Expression<Func<VwGuiaremision, bool>> criteria);
        List<VwGuiaremision> GetAllVwGuiaremision();
        List<VwGuiaremision> GetAllVwGuiaremision(Expression<Func<VwGuiaremision, bool>> criteria);
        List<VwGuiaremision> GetAllVwGuiaremision(string orders);
        List<VwGuiaremision> GetAllVwGuiaremision(string conditions, string orders);
        VwGuiaremision GetVwGuiaremision(int id);
        VwGuiaremision GetVwGuiaremision(Expression<Func<VwGuiaremision, bool>> criteria);

        #endregion

        #region VwGuiaremisiondet service

        long CountVwGuiaremisiondet();
        long CountVwGuiaremisiondet(Expression<Func<VwGuiaremisiondet, bool>> criteria);
        List<VwGuiaremisiondet> GetAllVwGuiaremisiondet();
        List<VwGuiaremisiondet> GetAllVwGuiaremisiondet(Expression<Func<VwGuiaremisiondet, bool>> criteria);
        List<VwGuiaremisiondet> GetAllVwGuiaremisiondet(string orders);
        List<VwGuiaremisiondet> GetAllVwGuiaremisiondet(string conditions, string orders);
        VwGuiaremisiondet GetVwGuiaremisiondet(int id);
        VwGuiaremisiondet GetVwGuiaremisiondet(Expression<Func<VwGuiaremisiondet, bool>> criteria);

        #endregion

        #region VwSalidaalmacen service

        long CountVwSalidaalmacen();
        long CountVwSalidaalmacen(Expression<Func<VwSalidaalmacen, bool>> criteria);
        List<VwSalidaalmacen> GetAllVwSalidaalmacen();
        List<VwSalidaalmacen> GetAllVwSalidaalmacen(Expression<Func<VwSalidaalmacen, bool>> criteria);
        List<VwSalidaalmacen> GetAllVwSalidaalmacen(string orders);
        List<VwSalidaalmacen> GetAllVwSalidaalmacen(string conditions, string orders);
        VwSalidaalmacen GetVwSalidaalmacen(int id);
        VwSalidaalmacen GetVwSalidaalmacen(Expression<Func<VwSalidaalmacen, bool>> criteria);

        #endregion

        #region VwSalidaalmacendet service

        long CountVwSalidaalmacendet();
        long CountVwSalidaalmacendet(Expression<Func<VwSalidaalmacendet, bool>> criteria);
        List<VwSalidaalmacendet> GetAllVwSalidaalmacendet();
        List<VwSalidaalmacendet> GetAllVwSalidaalmacendet(Expression<Func<VwSalidaalmacendet, bool>> criteria);
        List<VwSalidaalmacendet> GetAllVwSalidaalmacendet(string orders);
        List<VwSalidaalmacendet> GetAllVwSalidaalmacendet(string conditions, string orders);
        VwSalidaalmacendet GetVwSalidaalmacendet(int id);
        VwSalidaalmacendet GetVwSalidaalmacendet(Expression<Func<VwSalidaalmacendet, bool>> criteria);

        #endregion

        #region VwRequerimientosaaprobar service

        long CountVwRequerimientosaaprobar();
        long CountVwRequerimientosaaprobar(Expression<Func<VwRequerimientosaaprobar, bool>> criteria);
        List<VwRequerimientosaaprobar> GetAllVwRequerimientosaaprobar();
        List<VwRequerimientosaaprobar> GetAllVwRequerimientosaaprobar(Expression<Func<VwRequerimientosaaprobar, bool>> criteria);
        List<VwRequerimientosaaprobar> GetAllVwRequerimientosaaprobar(string orders);
        List<VwRequerimientosaaprobar> GetAllVwRequerimientosaaprobar(string conditions, string orders);
        VwRequerimientosaaprobar GetVwRequerimientosaaprobar(int id);
        VwRequerimientosaaprobar GetVwRequerimientosaaprobar(Expression<Func<VwRequerimientosaaprobar, bool>> criteria);

        #endregion

        #region Entradaalmacenobs service

		long CountEntradaalmacenobs();
		long CountEntradaalmacenobs(Expression<Func<Entradaalmacenobs, bool>> criteria);
		int SaveEntradaalmacenobs(Entradaalmacenobs entity);
		void UpdateEntradaalmacenobs(Entradaalmacenobs entity);
		void DeleteEntradaalmacenobs(int id);
		List<Entradaalmacenobs> GetAllEntradaalmacenobs();
		List<Entradaalmacenobs> GetAllEntradaalmacenobs(Expression<Func<Entradaalmacenobs, bool>> criteria);
		List<Entradaalmacenobs> GetAllEntradaalmacenobs(string orders);
		List<Entradaalmacenobs> GetAllEntradaalmacenobs(string conditions, string orders);
		Entradaalmacenobs GetEntradaalmacenobs(int id);
		Entradaalmacenobs GetEntradaalmacenobs(Expression<Func<Entradaalmacenobs, bool>> criteria);

		#endregion

		#region Estadoarticuloingreso service

		long CountEstadoarticuloingreso();
		long CountEstadoarticuloingreso(Expression<Func<Estadoarticuloingreso, bool>> criteria);
		int SaveEstadoarticuloingreso(Estadoarticuloingreso entity);
		void UpdateEstadoarticuloingreso(Estadoarticuloingreso entity);
		void DeleteEstadoarticuloingreso(int id);
		List<Estadoarticuloingreso> GetAllEstadoarticuloingreso();
		List<Estadoarticuloingreso> GetAllEstadoarticuloingreso(Expression<Func<Estadoarticuloingreso, bool>> criteria);
		List<Estadoarticuloingreso> GetAllEstadoarticuloingreso(string orders);
		List<Estadoarticuloingreso> GetAllEstadoarticuloingreso(string conditions, string orders);
		Estadoarticuloingreso GetEstadoarticuloingreso(int id);
		Estadoarticuloingreso GetEstadoarticuloingreso(Expression<Func<Estadoarticuloingreso, bool>> criteria);

		#endregion

		#region VwEntradaalmacenobs service

		long CountVwEntradaalmacenobs();
		long CountVwEntradaalmacenobs(Expression<Func<VwEntradaalmacenobs, bool>> criteria);
		List<VwEntradaalmacenobs> GetAllVwEntradaalmacenobs();
		List<VwEntradaalmacenobs> GetAllVwEntradaalmacenobs(Expression<Func<VwEntradaalmacenobs, bool>> criteria);
		List<VwEntradaalmacenobs> GetAllVwEntradaalmacenobs(string orders);
		List<VwEntradaalmacenobs> GetAllVwEntradaalmacenobs(string conditions, string orders);
		VwEntradaalmacenobs GetVwEntradaalmacenobs(int id);
		VwEntradaalmacenobs GetVwEntradaalmacenobs(Expression<Func<VwEntradaalmacenobs, bool>> criteria);

		#endregion

        #region VwStock service

        long CountVwStock();
        long CountVwStock(Expression<Func<VwStock, bool>> criteria);
        List<VwStock> GetAllVwStock();
        List<VwStock> GetAllVwStock(Expression<Func<VwStock, bool>> criteria);
        List<VwStock> GetAllVwStock(string orders);
        List<VwStock> GetAllVwStock(string conditions, string orders);
        VwStock GetVwStock(int id);
        VwStock GetVwStock(Expression<Func<VwStock, bool>> criteria);

        #endregion

        #region Estadoreclamo service

        long CountEstadoreclamo();
        long CountEstadoreclamo(Expression<Func<Estadoreclamo, bool>> criteria);
        int SaveEstadoreclamo(Estadoreclamo entity);
        void UpdateEstadoreclamo(Estadoreclamo entity);
        void DeleteEstadoreclamo(int id);
        List<Estadoreclamo> GetAllEstadoreclamo();
        List<Estadoreclamo> GetAllEstadoreclamo(Expression<Func<Estadoreclamo, bool>> criteria);
        List<Estadoreclamo> GetAllEstadoreclamo(string orders);
        List<Estadoreclamo> GetAllEstadoreclamo(string conditions, string orders);
        Estadoreclamo GetEstadoreclamo(int id);
        Estadoreclamo GetEstadoreclamo(Expression<Func<Estadoreclamo, bool>> criteria);

        #endregion

        #region Inventario service

        long CountInventario();
        long CountInventario(Expression<Func<Inventario, bool>> criteria);
        int SaveInventario(Inventario entity);
        void UpdateInventario(Inventario entity);
        void DeleteInventario(int id);
        List<Inventario> GetAllInventario();
        List<Inventario> GetAllInventario(Expression<Func<Inventario, bool>> criteria);
        List<Inventario> GetAllInventario(string orders);
        List<Inventario> GetAllInventario(string conditions, string orders);
        Inventario GetInventario(int id);
        Inventario GetInventario(Expression<Func<Inventario, bool>> criteria);

        #endregion

        #region Inventariostock service

        long CountInventariostock();
        long CountInventariostock(Expression<Func<Inventariostock, bool>> criteria);
        int SaveInventariostock(Inventariostock entity);
        void UpdateInventariostock(Inventariostock entity);
        void DeleteInventariostock(int id);
        List<Inventariostock> GetAllInventariostock();
        List<Inventariostock> GetAllInventariostock(Expression<Func<Inventariostock, bool>> criteria);
        List<Inventariostock> GetAllInventariostock(string orders);
        List<Inventariostock> GetAllInventariostock(string conditions, string orders);
        Inventariostock GetInventariostock(int id);
        Inventariostock GetInventariostock(Expression<Func<Inventariostock, bool>> criteria);

        #endregion

        #region Inventarioubicacion service

        long CountInventarioubicacion();
        long CountInventarioubicacion(Expression<Func<Inventarioubicacion, bool>> criteria);
        int SaveInventarioubicacion(Inventarioubicacion entity);
        void UpdateInventarioubicacion(Inventarioubicacion entity);
        void DeleteInventarioubicacion(int id);
        List<Inventarioubicacion> GetAllInventarioubicacion();
        List<Inventarioubicacion> GetAllInventarioubicacion(Expression<Func<Inventarioubicacion, bool>> criteria);
        List<Inventarioubicacion> GetAllInventarioubicacion(string orders);
        List<Inventarioubicacion> GetAllInventarioubicacion(string conditions, string orders);
        Inventarioubicacion GetInventarioubicacion(int id);
        Inventarioubicacion GetInventarioubicacion(Expression<Func<Inventarioubicacion, bool>> criteria);

        #endregion

        #region Ubicacion service

        long CountUbicacion();
        long CountUbicacion(Expression<Func<Ubicacion, bool>> criteria);
        int SaveUbicacion(Ubicacion entity);
        void UpdateUbicacion(Ubicacion entity);
        void DeleteUbicacion(int id);
        List<Ubicacion> GetAllUbicacion();
        List<Ubicacion> GetAllUbicacion(Expression<Func<Ubicacion, bool>> criteria);
        List<Ubicacion> GetAllUbicacion(string orders);
        List<Ubicacion> GetAllUbicacion(string conditions, string orders);
        Ubicacion GetUbicacion(int id);
        Ubicacion GetUbicacion(Expression<Func<Ubicacion, bool>> criteria);

        #endregion

        #region VwInventario service

        long CountVwInventario();
        long CountVwInventario(Expression<Func<VwInventario, bool>> criteria);
        List<VwInventario> GetAllVwInventario();
        List<VwInventario> GetAllVwInventario(Expression<Func<VwInventario, bool>> criteria);
        List<VwInventario> GetAllVwInventario(string orders);
        List<VwInventario> GetAllVwInventario(string conditions, string orders);
        VwInventario GetVwInventario(int id);
        VwInventario GetVwInventario(Expression<Func<VwInventario, bool>> criteria);

        #endregion

        #region VwInventariostock service

        long CountVwInventariostock();
        long CountVwInventariostock(Expression<Func<VwInventariostock, bool>> criteria);
        List<VwInventariostock> GetAllVwInventariostock();
        List<VwInventariostock> GetAllVwInventariostock(Expression<Func<VwInventariostock, bool>> criteria);
        List<VwInventariostock> GetAllVwInventariostock(string orders);
        List<VwInventariostock> GetAllVwInventariostock(string conditions, string orders);
        VwInventariostock GetVwInventariostock(int id);
        VwInventariostock GetVwInventariostock(Expression<Func<VwInventariostock, bool>> criteria);

        #endregion

        #region VwInventarioubicacion service

        long CountVwInventarioubicacion();
        long CountVwInventarioubicacion(Expression<Func<VwInventarioubicacion, bool>> criteria);
        List<VwInventarioubicacion> GetAllVwInventarioubicacion();
        List<VwInventarioubicacion> GetAllVwInventarioubicacion(Expression<Func<VwInventarioubicacion, bool>> criteria);
        List<VwInventarioubicacion> GetAllVwInventarioubicacion(string orders);
        List<VwInventarioubicacion> GetAllVwInventarioubicacion(string conditions, string orders);
        VwInventarioubicacion GetVwInventarioubicacion(int id);
        VwInventarioubicacion GetVwInventarioubicacion(Expression<Func<VwInventarioubicacion, bool>> criteria);

        #endregion

        #region VwUbicacion service

        long CountVwUbicacion();
        long CountVwUbicacion(Expression<Func<VwUbicacion, bool>> criteria);
        List<VwUbicacion> GetAllVwUbicacion();
        List<VwUbicacion> GetAllVwUbicacion(Expression<Func<VwUbicacion, bool>> criteria);
        List<VwUbicacion> GetAllVwUbicacion(string orders);
        List<VwUbicacion> GetAllVwUbicacion(string conditions, string orders);
        VwUbicacion GetVwUbicacion(int id);
        VwUbicacion GetVwUbicacion(Expression<Func<VwUbicacion, bool>> criteria);

        #endregion

        #region VwEntradaalmacenubicacion service

        long CountVwEntradaalmacenubicacion();
        long CountVwEntradaalmacenubicacion(Expression<Func<VwEntradaalmacenubicacion, bool>> criteria);
        List<VwEntradaalmacenubicacion> GetAllVwEntradaalmacenubicacion();
        List<VwEntradaalmacenubicacion> GetAllVwEntradaalmacenubicacion(Expression<Func<VwEntradaalmacenubicacion, bool>> criteria);
        List<VwEntradaalmacenubicacion> GetAllVwEntradaalmacenubicacion(string orders);
        List<VwEntradaalmacenubicacion> GetAllVwEntradaalmacenubicacion(string conditions, string orders);
        VwEntradaalmacenubicacion GetVwEntradaalmacenubicacion(int id);
        VwEntradaalmacenubicacion GetVwEntradaalmacenubicacion(Expression<Func<VwEntradaalmacenubicacion, bool>> criteria);

        #endregion

        #region VwSalidaalmacenubicacion service

        long CountVwSalidaalmacenubicacion();
        long CountVwSalidaalmacenubicacion(Expression<Func<VwSalidaalmacenubicacion, bool>> criteria);
        List<VwSalidaalmacenubicacion> GetAllVwSalidaalmacenubicacion();
        List<VwSalidaalmacenubicacion> GetAllVwSalidaalmacenubicacion(Expression<Func<VwSalidaalmacenubicacion, bool>> criteria);
        List<VwSalidaalmacenubicacion> GetAllVwSalidaalmacenubicacion(string orders);
        List<VwSalidaalmacenubicacion> GetAllVwSalidaalmacenubicacion(string conditions, string orders);
        VwSalidaalmacenubicacion GetVwSalidaalmacenubicacion(int id);
        VwSalidaalmacenubicacion GetVwSalidaalmacenubicacion(Expression<Func<VwSalidaalmacenubicacion, bool>> criteria);

        #endregion

        #region VwGuiaremisionimpsalidaalmacen service

        long CountVwGuiaremisionimpsalidaalmacen();
        long CountVwGuiaremisionimpsalidaalmacen(Expression<Func<VwGuiaremisionimpsalidaalmacen, bool>> criteria);
        List<VwGuiaremisionimpsalidaalmacen> GetAllVwGuiaremisionimpsalidaalmacen();
        List<VwGuiaremisionimpsalidaalmacen> GetAllVwGuiaremisionimpsalidaalmacen(Expression<Func<VwGuiaremisionimpsalidaalmacen, bool>> criteria);
        List<VwGuiaremisionimpsalidaalmacen> GetAllVwGuiaremisionimpsalidaalmacen(string orders);
        List<VwGuiaremisionimpsalidaalmacen> GetAllVwGuiaremisionimpsalidaalmacen(string conditions, string orders);
        VwGuiaremisionimpsalidaalmacen GetVwGuiaremisionimpsalidaalmacen(int id);
        VwGuiaremisionimpsalidaalmacen GetVwGuiaremisionimpsalidaalmacen(Expression<Func<VwGuiaremisionimpsalidaalmacen, bool>> criteria);

        #endregion

        #region VwOrdencompraimpentradaalmacen service

        long CountVwOrdencompraimpentradaalmacen();
        long CountVwOrdencompraimpentradaalmacen(Expression<Func<VwOrdencompraimpentradaalmacen, bool>> criteria);
        List<VwOrdencompraimpentradaalmacen> GetAllVwOrdencompraimpentradaalmacen();
        List<VwOrdencompraimpentradaalmacen> GetAllVwOrdencompraimpentradaalmacen(Expression<Func<VwOrdencompraimpentradaalmacen, bool>> criteria);
        List<VwOrdencompraimpentradaalmacen> GetAllVwOrdencompraimpentradaalmacen(string orders);
        List<VwOrdencompraimpentradaalmacen> GetAllVwOrdencompraimpentradaalmacen(string conditions, string orders);
        VwOrdencompraimpentradaalmacen GetVwOrdencompraimpentradaalmacen(int id);
        VwOrdencompraimpentradaalmacen GetVwOrdencompraimpentradaalmacen(Expression<Func<VwOrdencompraimpentradaalmacen, bool>> criteria);

        #endregion

        #region VwGuiaremisiondetimpcpventadet service

        long CountVwGuiaremisiondetimpcpventadet();
        long CountVwGuiaremisiondetimpcpventadet(Expression<Func<VwGuiaremisiondetimpcpventadet, bool>> criteria);
        List<VwGuiaremisiondetimpcpventadet> GetAllVwGuiaremisiondetimpcpventadet();
        List<VwGuiaremisiondetimpcpventadet> GetAllVwGuiaremisiondetimpcpventadet(Expression<Func<VwGuiaremisiondetimpcpventadet, bool>> criteria);
        List<VwGuiaremisiondetimpcpventadet> GetAllVwGuiaremisiondetimpcpventadet(string orders);
        List<VwGuiaremisiondetimpcpventadet> GetAllVwGuiaremisiondetimpcpventadet(string conditions, string orders);
        VwGuiaremisiondetimpcpventadet GetVwGuiaremisiondetimpcpventadet(int id);
        VwGuiaremisiondetimpcpventadet GetVwGuiaremisiondetimpcpventadet(Expression<Func<VwGuiaremisiondetimpcpventadet, bool>> criteria);

        #endregion

        #region Guiaremisiondetimpcpventadet service

        long CountGuiaremisiondetimpcpventadet();
        long CountGuiaremisiondetimpcpventadet(Expression<Func<Guiaremisiondetimpcpventadet, bool>> criteria);
        int SaveGuiaremisiondetimpcpventadet(Guiaremisiondetimpcpventadet entity);
        void UpdateGuiaremisiondetimpcpventadet(Guiaremisiondetimpcpventadet entity);
        void DeleteGuiaremisiondetimpcpventadet(int id);
        List<Guiaremisiondetimpcpventadet> GetAllGuiaremisiondetimpcpventadet();
        List<Guiaremisiondetimpcpventadet> GetAllGuiaremisiondetimpcpventadet(Expression<Func<Guiaremisiondetimpcpventadet, bool>> criteria);
        List<Guiaremisiondetimpcpventadet> GetAllGuiaremisiondetimpcpventadet(string orders);
        List<Guiaremisiondetimpcpventadet> GetAllGuiaremisiondetimpcpventadet(string conditions, string orders);
        Guiaremisiondetimpcpventadet GetGuiaremisiondetimpcpventadet(int id);
        Guiaremisiondetimpcpventadet GetGuiaremisiondetimpcpventadet(Expression<Func<Guiaremisiondetimpcpventadet, bool>> criteria);

        #endregion

        #region VwSalidaalmacendetimpentradaalmacen service

        long CountVwSalidaalmacendetimpentradaalmacen();
        long CountVwSalidaalmacendetimpentradaalmacen(Expression<Func<VwSalidaalmacendetimpentradaalmacen, bool>> criteria);
        List<VwSalidaalmacendetimpentradaalmacen> GetAllVwSalidaalmacendetimpentradaalmacen();
        List<VwSalidaalmacendetimpentradaalmacen> GetAllVwSalidaalmacendetimpentradaalmacen(Expression<Func<VwSalidaalmacendetimpentradaalmacen, bool>> criteria);
        List<VwSalidaalmacendetimpentradaalmacen> GetAllVwSalidaalmacendetimpentradaalmacen(string orders);
        List<VwSalidaalmacendetimpentradaalmacen> GetAllVwSalidaalmacendetimpentradaalmacen(string conditions, string orders);
        VwSalidaalmacendetimpentradaalmacen GetVwSalidaalmacendetimpentradaalmacen(int id);
        VwSalidaalmacendetimpentradaalmacen GetVwSalidaalmacendetimpentradaalmacen(Expression<Func<VwSalidaalmacendetimpentradaalmacen, bool>> criteria);

        #endregion

        #region VwCpcompradetimpentradaalmacen service

        long CountVwCpcompradetimpentradaalmacen();
        long CountVwCpcompradetimpentradaalmacen(Expression<Func<VwCpcompradetimpentradaalmacen, bool>> criteria);
        List<VwCpcompradetimpentradaalmacen> GetAllVwCpcompradetimpentradaalmacen();
        List<VwCpcompradetimpentradaalmacen> GetAllVwCpcompradetimpentradaalmacen(Expression<Func<VwCpcompradetimpentradaalmacen, bool>> criteria);
        List<VwCpcompradetimpentradaalmacen> GetAllVwCpcompradetimpentradaalmacen(string orders);
        List<VwCpcompradetimpentradaalmacen> GetAllVwCpcompradetimpentradaalmacen(string conditions, string orders);
        VwCpcompradetimpentradaalmacen GetVwCpcompradetimpentradaalmacen(int id);
        VwCpcompradetimpentradaalmacen GetVwCpcompradetimpentradaalmacen(Expression<Func<VwCpcompradetimpentradaalmacen, bool>> criteria);

        #endregion

        #region VwRendicioncajachicaimpsalidaalmacen service

        long CountVwRendicioncajachicaimpsalidaalmacen();
        long CountVwRendicioncajachicaimpsalidaalmacen(Expression<Func<VwRendicioncajachicaimpsalidaalmacen, bool>> criteria);
        List<VwRendicioncajachicaimpsalidaalmacen> GetAllVwRendicioncajachicaimpsalidaalmacen();
        List<VwRendicioncajachicaimpsalidaalmacen> GetAllVwRendicioncajachicaimpsalidaalmacen(Expression<Func<VwRendicioncajachicaimpsalidaalmacen, bool>> criteria);
        List<VwRendicioncajachicaimpsalidaalmacen> GetAllVwRendicioncajachicaimpsalidaalmacen(string orders);
        List<VwRendicioncajachicaimpsalidaalmacen> GetAllVwRendicioncajachicaimpsalidaalmacen(string conditions, string orders);
        VwRendicioncajachicaimpsalidaalmacen GetVwRendicioncajachicaimpsalidaalmacen(int id);
        VwRendicioncajachicaimpsalidaalmacen GetVwRendicioncajachicaimpsalidaalmacen(Expression<Func<VwRendicioncajachicaimpsalidaalmacen, bool>> criteria);

        #endregion

        #region VwNotacreditocliimpentradaalmacen service

        long CountVwNotacreditocliimpentradaalmacen();
        long CountVwNotacreditocliimpentradaalmacen(Expression<Func<VwNotacreditocliimpentradaalmacen, bool>> criteria);
        List<VwNotacreditocliimpentradaalmacen> GetAllVwNotacreditocliimpentradaalmacen();
        List<VwNotacreditocliimpentradaalmacen> GetAllVwNotacreditocliimpentradaalmacen(Expression<Func<VwNotacreditocliimpentradaalmacen, bool>> criteria);
        List<VwNotacreditocliimpentradaalmacen> GetAllVwNotacreditocliimpentradaalmacen(string orders);
        List<VwNotacreditocliimpentradaalmacen> GetAllVwNotacreditocliimpentradaalmacen(string conditions, string orders);
        VwNotacreditocliimpentradaalmacen GetVwNotacreditocliimpentradaalmacen(int id);
        VwNotacreditocliimpentradaalmacen GetVwNotacreditocliimpentradaalmacen(Expression<Func<VwNotacreditocliimpentradaalmacen, bool>> criteria);

        #endregion

        #region VwEntradaalmacendetimpguiaremision service

        long CountVwEntradaalmacendetimpguiaremision();
        long CountVwEntradaalmacendetimpguiaremision(Expression<Func<VwEntradaalmacendetimpguiaremision, bool>> criteria);
        List<VwEntradaalmacendetimpguiaremision> GetAllVwEntradaalmacendetimpguiaremision();
        List<VwEntradaalmacendetimpguiaremision> GetAllVwEntradaalmacendetimpguiaremision(Expression<Func<VwEntradaalmacendetimpguiaremision, bool>> criteria);
        List<VwEntradaalmacendetimpguiaremision> GetAllVwEntradaalmacendetimpguiaremision(string orders);
        List<VwEntradaalmacendetimpguiaremision> GetAllVwEntradaalmacendetimpguiaremision(string conditions, string orders);
        VwEntradaalmacendetimpguiaremision GetVwEntradaalmacendetimpguiaremision(int id);
        VwEntradaalmacendetimpguiaremision GetVwEntradaalmacendetimpguiaremision(Expression<Func<VwEntradaalmacendetimpguiaremision, bool>> criteria);

        #endregion

        #region VwEntradaalmacendetverificacioncantidad service

        long CountVwEntradaalmacendetverificacioncantidad();
        long CountVwEntradaalmacendetverificacioncantidad(Expression<Func<VwEntradaalmacendetverificacioncantidad, bool>> criteria);
        List<VwEntradaalmacendetverificacioncantidad> GetAllVwEntradaalmacendetverificacioncantidad();
        List<VwEntradaalmacendetverificacioncantidad> GetAllVwEntradaalmacendetverificacioncantidad(Expression<Func<VwEntradaalmacendetverificacioncantidad, bool>> criteria);
        List<VwEntradaalmacendetverificacioncantidad> GetAllVwEntradaalmacendetverificacioncantidad(string orders);
        List<VwEntradaalmacendetverificacioncantidad> GetAllVwEntradaalmacendetverificacioncantidad(string conditions, string orders);
        VwEntradaalmacendetverificacioncantidad GetVwEntradaalmacendetverificacioncantidad(int id);
        VwEntradaalmacendetverificacioncantidad GetVwEntradaalmacendetverificacioncantidad(Expression<Func<VwEntradaalmacendetverificacioncantidad, bool>> criteria);

        #endregion

        #region VwSalidaalmacendetverificacioncantidad service

        long CountVwSalidaalmacendetverificacioncantidad();
        long CountVwSalidaalmacendetverificacioncantidad(Expression<Func<VwSalidaalmacendetverificacioncantidad, bool>> criteria);
        List<VwSalidaalmacendetverificacioncantidad> GetAllVwSalidaalmacendetverificacioncantidad();
        List<VwSalidaalmacendetverificacioncantidad> GetAllVwSalidaalmacendetverificacioncantidad(Expression<Func<VwSalidaalmacendetverificacioncantidad, bool>> criteria);
        List<VwSalidaalmacendetverificacioncantidad> GetAllVwSalidaalmacendetverificacioncantidad(string orders);
        List<VwSalidaalmacendetverificacioncantidad> GetAllVwSalidaalmacendetverificacioncantidad(string conditions, string orders);
        VwSalidaalmacendetverificacioncantidad GetVwSalidaalmacendetverificacioncantidad(int id);
        VwSalidaalmacendetverificacioncantidad GetVwSalidaalmacendetverificacioncantidad(Expression<Func<VwSalidaalmacendetverificacioncantidad, bool>> criteria);

        #endregion

        #region Entradaalmacendetitemcpcompradet service

        long CountEntradaalmacendetitemcpcompradet();
        long CountEntradaalmacendetitemcpcompradet(Expression<Func<Entradaalmacendetitemcpcompradet, bool>> criteria);
        int SaveEntradaalmacendetitemcpcompradet(Entradaalmacendetitemcpcompradet entity);
        void UpdateEntradaalmacendetitemcpcompradet(Entradaalmacendetitemcpcompradet entity);
        void DeleteEntradaalmacendetitemcpcompradet(int id);
        List<Entradaalmacendetitemcpcompradet> GetAllEntradaalmacendetitemcpcompradet();
        List<Entradaalmacendetitemcpcompradet> GetAllEntradaalmacendetitemcpcompradet(Expression<Func<Entradaalmacendetitemcpcompradet, bool>> criteria);
        List<Entradaalmacendetitemcpcompradet> GetAllEntradaalmacendetitemcpcompradet(string orders);
        List<Entradaalmacendetitemcpcompradet> GetAllEntradaalmacendetitemcpcompradet(string conditions, string orders);
        Entradaalmacendetitemcpcompradet GetEntradaalmacendetitemcpcompradet(int id);
        Entradaalmacendetitemcpcompradet GetEntradaalmacendetitemcpcompradet(Expression<Func<Entradaalmacendetitemcpcompradet, bool>> criteria);

        #endregion

        #region Inventarioinicial service

        long CountInventarioinicial();
        long CountInventarioinicial(Expression<Func<Inventarioinicial, bool>> criteria);
        int SaveInventarioinicial(Inventarioinicial entity);
        void UpdateInventarioinicial(Inventarioinicial entity);
        void DeleteInventarioinicial(int id);
        List<Inventarioinicial> GetAllInventarioinicial();
        List<Inventarioinicial> GetAllInventarioinicial(Expression<Func<Inventarioinicial, bool>> criteria);
        List<Inventarioinicial> GetAllInventarioinicial(string orders);
        List<Inventarioinicial> GetAllInventarioinicial(string conditions, string orders);
        Inventarioinicial GetInventarioinicial(int id);
        Inventarioinicial GetInventarioinicial(Expression<Func<Inventarioinicial, bool>> criteria);

        #endregion

        #region VwInventarioinicial service

        long CountVwInventarioinicial();
        long CountVwInventarioinicial(Expression<Func<VwInventarioinicial, bool>> criteria);
        List<VwInventarioinicial> GetAllVwInventarioinicial();
        List<VwInventarioinicial> GetAllVwInventarioinicial(Expression<Func<VwInventarioinicial, bool>> criteria);
        List<VwInventarioinicial> GetAllVwInventarioinicial(string orders);
        List<VwInventarioinicial> GetAllVwInventarioinicial(string conditions, string orders);
        VwInventarioinicial GetVwInventarioinicial(int id);
        VwInventarioinicial GetVwInventarioinicial(Expression<Func<VwInventarioinicial, bool>> criteria);

        #endregion

        #region Inventariostockdetserie service

        long CountInventariostockdetserie();
        long CountInventariostockdetserie(Expression<Func<Inventariostockdetserie, bool>> criteria);
        int SaveInventariostockdetserie(Inventariostockdetserie entity);
        void UpdateInventariostockdetserie(Inventariostockdetserie entity);
        void DeleteInventariostockdetserie(int id);
        List<Inventariostockdetserie> GetAllInventariostockdetserie();
        List<Inventariostockdetserie> GetAllInventariostockdetserie(Expression<Func<Inventariostockdetserie, bool>> criteria);
        List<Inventariostockdetserie> GetAllInventariostockdetserie(string orders);
        List<Inventariostockdetserie> GetAllInventariostockdetserie(string conditions, string orders);
        Inventariostockdetserie GetInventariostockdetserie(int id);
        Inventariostockdetserie GetInventariostockdetserie(Expression<Func<Inventariostockdetserie, bool>> criteria);

        #endregion

        #region VwInventariostockdetserie service

        long CountVwInventariostockdetserie();
        long CountVwInventariostockdetserie(Expression<Func<VwInventariostockdetserie, bool>> criteria);
        List<VwInventariostockdetserie> GetAllVwInventariostockdetserie();
        List<VwInventariostockdetserie> GetAllVwInventariostockdetserie(Expression<Func<VwInventariostockdetserie, bool>> criteria);
        List<VwInventariostockdetserie> GetAllVwInventariostockdetserie(string orders);
        List<VwInventariostockdetserie> GetAllVwInventariostockdetserie(string conditions, string orders);
        VwInventariostockdetserie GetVwInventariostockdetserie(int id);
        VwInventariostockdetserie GetVwInventariostockdetserie(Expression<Func<VwInventariostockdetserie, bool>> criteria);

        #endregion

        #region VwCpventaimpsalidaalmacen service

        long CountVwCpventaimpsalidaalmacen();
        long CountVwCpventaimpsalidaalmacen(Expression<Func<VwCpventaimpsalidaalmacen, bool>> criteria);
        List<VwCpventaimpsalidaalmacen> GetAllVwCpventaimpsalidaalmacen();
        List<VwCpventaimpsalidaalmacen> GetAllVwCpventaimpsalidaalmacen(Expression<Func<VwCpventaimpsalidaalmacen, bool>> criteria);
        List<VwCpventaimpsalidaalmacen> GetAllVwCpventaimpsalidaalmacen(string orders);
        List<VwCpventaimpsalidaalmacen> GetAllVwCpventaimpsalidaalmacen(string conditions, string orders);
        VwCpventaimpsalidaalmacen GetVwCpventaimpsalidaalmacen(int id);
        VwCpventaimpsalidaalmacen GetVwCpventaimpsalidaalmacen(Expression<Func<VwCpventaimpsalidaalmacen, bool>> criteria);

        #endregion


        #endregion

        #region Caja

        #region Cierrecaja service

        long CountCierrecaja();
        long CountCierrecaja(Expression<Func<Cierrecaja, bool>> criteria);
        int SaveCierrecaja(Cierrecaja entity);
        void UpdateCierrecaja(Cierrecaja entity);
        void DeleteCierrecaja(int id);
        List<Cierrecaja> GetAllCierrecaja();
        List<Cierrecaja> GetAllCierrecaja(Expression<Func<Cierrecaja, bool>> criteria);
        List<Cierrecaja> GetAllCierrecaja(string orders);
        List<Cierrecaja> GetAllCierrecaja(string conditions, string orders);
        Cierrecaja GetCierrecaja(int id);
        Cierrecaja GetCierrecaja(Expression<Func<Cierrecaja, bool>> criteria);
        bool GuardarCierrecaja(TipoMantenimiento tipoMantenimiento, Cierrecaja entidadCab, List<VwCierrecajadet> elementoDetList);
        #endregion

        #region Cierrecajadet service

        long CountCierrecajadet();
        long CountCierrecajadet(Expression<Func<Cierrecajadet, bool>> criteria);
        int SaveCierrecajadet(Cierrecajadet entity);
        void UpdateCierrecajadet(Cierrecajadet entity);
        void DeleteCierrecajadet(int id);
        List<Cierrecajadet> GetAllCierrecajadet();
        List<Cierrecajadet> GetAllCierrecajadet(Expression<Func<Cierrecajadet, bool>> criteria);
        List<Cierrecajadet> GetAllCierrecajadet(string orders);
        List<Cierrecajadet> GetAllCierrecajadet(string conditions, string orders);
        Cierrecajadet GetCierrecajadet(int id);
        Cierrecajadet GetCierrecajadet(Expression<Func<Cierrecajadet, bool>> criteria);

        #endregion

        #region VwCierrecaja service

        long CountVwCierrecaja();
        long CountVwCierrecaja(Expression<Func<VwCierrecaja, bool>> criteria);
        List<VwCierrecaja> GetAllVwCierrecaja();
        List<VwCierrecaja> GetAllVwCierrecaja(Expression<Func<VwCierrecaja, bool>> criteria);
        List<VwCierrecaja> GetAllVwCierrecaja(string orders);
        List<VwCierrecaja> GetAllVwCierrecaja(string conditions, string orders);
        VwCierrecaja GetVwCierrecaja(int id);
        VwCierrecaja GetVwCierrecaja(Expression<Func<VwCierrecaja, bool>> criteria);

        #endregion

        #region VwCierrecajadet service

        long CountVwCierrecajadet();
        long CountVwCierrecajadet(Expression<Func<VwCierrecajadet, bool>> criteria);
        List<VwCierrecajadet> GetAllVwCierrecajadet();
        List<VwCierrecajadet> GetAllVwCierrecajadet(Expression<Func<VwCierrecajadet, bool>> criteria);
        List<VwCierrecajadet> GetAllVwCierrecajadet(string orders);
        List<VwCierrecajadet> GetAllVwCierrecajadet(string conditions, string orders);
        VwCierrecajadet GetVwCierrecajadet(int id);
        VwCierrecajadet GetVwCierrecajadet(Expression<Func<VwCierrecajadet, bool>> criteria);

        #endregion

        #region VwCierrecajaimpresion service

        long CountVwCierrecajaimpresion();
        long CountVwCierrecajaimpresion(Expression<Func<VwCierrecajaimpresion, bool>> criteria);
        List<VwCierrecajaimpresion> GetAllVwCierrecajaimpresion();
        List<VwCierrecajaimpresion> GetAllVwCierrecajaimpresion(Expression<Func<VwCierrecajaimpresion, bool>> criteria);
        List<VwCierrecajaimpresion> GetAllVwCierrecajaimpresion(string orders);
        List<VwCierrecajaimpresion> GetAllVwCierrecajaimpresion(string conditions, string orders);
        VwCierrecajaimpresion GetVwCierrecajaimpresion(int id);
        VwCierrecajaimpresion GetVwCierrecajaimpresion(Expression<Func<VwCierrecajaimpresion, bool>> criteria);

        #endregion

        #region VwReciboresumen service

        long CountVwReciboresumen();
        long CountVwReciboresumen(Expression<Func<VwReciboresumen, bool>> criteria);
        List<VwReciboresumen> GetAllVwReciboresumen();
        List<VwReciboresumen> GetAllVwReciboresumen(Expression<Func<VwReciboresumen, bool>> criteria);
        List<VwReciboresumen> GetAllVwReciboresumen(string orders);
        List<VwReciboresumen> GetAllVwReciboresumen(string conditions, string orders);
        VwReciboresumen GetVwReciboresumen(int id);
        VwReciboresumen GetVwReciboresumen(Expression<Func<VwReciboresumen, bool>> criteria);

        #endregion

        #endregion

        #region Compras

        #region Cpcompra service

        long CountCpcompra();
        long CountCpcompra(Expression<Func<Cpcompra, bool>> criteria);
        int SaveCpcompra(Cpcompra entity);
        void UpdateCpcompra(Cpcompra entity);
        void DeleteCpcompra(int id);
        List<Cpcompra> GetAllCpcompra();
        List<Cpcompra> GetAllCpcompra(Expression<Func<Cpcompra, bool>> criteria);
        List<Cpcompra> GetAllCpcompra(string orders);
        List<Cpcompra> GetAllCpcompra(string conditions, string orders);
        Cpcompra GetCpcompra(int id);
        Cpcompra GetCpcompra(Expression<Func<Cpcompra, bool>> criteria);
        bool GuardarCpCompra(TipoMantenimiento tipoMantenimiento, Cpcompra entidadCab, List<VwCpcompradet> entidadDetList, List<VwEntradaalmacendet> vwEntradaalmacendetListOrigen);
        string SiguienteNumeroCpCompraPorProveedor(int idTipoCp, int idProveedor, string numeroserie);
        bool CpCompraTieneReferenciaCaja(int idTipoCp, string serieTipoCp, string numeroTipoCp);
        bool CpCompraTieneNotaCredito(int idcpcompra);

        #endregion

        #region Cpcompradet service

        long CountCpcompradet();
        long CountCpcompradet(Expression<Func<Cpcompradet, bool>> criteria);
        int SaveCpcompradet(Cpcompradet entity);
        void UpdateCpcompradet(Cpcompradet entity);
        void DeleteCpcompradet(int id);
        List<Cpcompradet> GetAllCpcompradet();
        List<Cpcompradet> GetAllCpcompradet(Expression<Func<Cpcompradet, bool>> criteria);
        List<Cpcompradet> GetAllCpcompradet(string orders);
        List<Cpcompradet> GetAllCpcompradet(string conditions, string orders);
        Cpcompradet GetCpcompradet(int id);
        Cpcompradet GetCpcompradet(Expression<Func<Cpcompradet, bool>> criteria);

        #endregion

        #region Ordencompra service

        long CountOrdencompra();
        long CountOrdencompra(Expression<Func<Ordencompra, bool>> criteria);
        int SaveOrdencompra(Ordencompra entity);
        void UpdateOrdencompra(Ordencompra entity);
        void DeleteOrdencompra(int id);
        List<Ordencompra> GetAllOrdencompra();
        List<Ordencompra> GetAllOrdencompra(Expression<Func<Ordencompra, bool>> criteria);
        List<Ordencompra> GetAllOrdencompra(string orders);
        List<Ordencompra> GetAllOrdencompra(string conditions, string orders);
        Ordencompra GetOrdencompra(int id);
        Ordencompra GetOrdencompra(Expression<Func<Ordencompra, bool>> criteria);
        bool NumeroOrdenCompraExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        bool GuardarOrdenDeCompra(TipoMantenimiento tipoMantenimiento, Ordencompra entidadCab, List<VwOrdencompradet> entidadDetList);
        bool OrdenCompraTieneReferenciaEntradaAlmacen(int idOrdenCompra);
        bool CpCompraTieneReferenciasRendicionCajaChica(int idTipoCp, int idProveedor, string numeroserie, string numero);
        #endregion

        #region Ordencompradet service

        long CountOrdencompradet();
        long CountOrdencompradet(Expression<Func<Ordencompradet, bool>> criteria);
        int SaveOrdencompradet(Ordencompradet entity);
        void UpdateOrdencompradet(Ordencompradet entity);
        void DeleteOrdencompradet(int id);
        List<Ordencompradet> GetAllOrdencompradet();
        List<Ordencompradet> GetAllOrdencompradet(Expression<Func<Ordencompradet, bool>> criteria);
        List<Ordencompradet> GetAllOrdencompradet(string orders);
        List<Ordencompradet> GetAllOrdencompradet(string conditions, string orders);
        Ordencompradet GetOrdencompradet(int id);
        Ordencompradet GetOrdencompradet(Expression<Func<Ordencompradet, bool>> criteria);
        long CantidadReferenciasItemOrdenCompra(int idordencompradet);
        Ordencompradet UltimoRegistroOrdenCompraDet();
        #endregion

        #region Requerimiento service

        long CountRequerimiento();
        long CountRequerimiento(Expression<Func<Requerimiento, bool>> criteria);
        int SaveRequerimiento(Requerimiento entity);
        void UpdateRequerimiento(Requerimiento entity);
        void DeleteRequerimiento(int id);
        List<Requerimiento> GetAllRequerimiento();
        List<Requerimiento> GetAllRequerimiento(Expression<Func<Requerimiento, bool>> criteria);
        List<Requerimiento> GetAllRequerimiento(string orders);
        List<Requerimiento> GetAllRequerimiento(string conditions, string orders);
        Requerimiento GetRequerimiento(int id);
        Requerimiento GetRequerimiento(Expression<Func<Requerimiento, bool>> criteria);
        bool NumeroRequerimientoExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        bool GuardarRequerimiento(TipoMantenimiento tipoMantenimiento, Requerimiento entidadCab, List<VwRequerimientodet> entidadDetList);
        bool RequerimientoAprobado(int idrequerimiento);
        bool RequerimientoTieneReferenciasOrdenDeCompra(int idRequerimiento);
        Estadoreq GetEstadoRequerimiento(int idRequerimiento);
        #endregion

        #region Requerimientodet service

        long CountRequerimientodet();
        long CountRequerimientodet(Expression<Func<Requerimientodet, bool>> criteria);
        int SaveRequerimientodet(Requerimientodet entity);
        void UpdateRequerimientodet(Requerimientodet entity);
        void DeleteRequerimientodet(int id);
        List<Requerimientodet> GetAllRequerimientodet();
        List<Requerimientodet> GetAllRequerimientodet(Expression<Func<Requerimientodet, bool>> criteria);
        List<Requerimientodet> GetAllRequerimientodet(string orders);
        List<Requerimientodet> GetAllRequerimientodet(string conditions, string orders);
        Requerimientodet GetRequerimientodet(int id);
        Requerimientodet GetRequerimientodet(Expression<Func<Requerimientodet, bool>> criteria);

        #endregion

        #region VwRequerimiento service

        long CountVwRequerimiento();
        long CountVwRequerimiento(Expression<Func<VwRequerimiento, bool>> criteria);
        List<VwRequerimiento> GetAllVwRequerimiento();
        List<VwRequerimiento> GetAllVwRequerimiento(Expression<Func<VwRequerimiento, bool>> criteria);
        List<VwRequerimiento> GetAllVwRequerimiento(string orders);
        List<VwRequerimiento> GetAllVwRequerimiento(string conditions, string orders);
        VwRequerimiento GetVwRequerimiento(int id);
        VwRequerimiento GetVwRequerimiento(Expression<Func<VwRequerimiento, bool>> criteria);
        #region VwRequerimientodet service

        long CountVwRequerimientodet();
        long CountVwRequerimientodet(Expression<Func<VwRequerimientodet, bool>> criteria);
        List<VwRequerimientodet> GetAllVwRequerimientodet();
        List<VwRequerimientodet> GetAllVwRequerimientodet(Expression<Func<VwRequerimientodet, bool>> criteria);
        List<VwRequerimientodet> GetAllVwRequerimientodet(string orders);
        List<VwRequerimientodet> GetAllVwRequerimientodet(string conditions, string orders);
        VwRequerimientodet GetVwRequerimientodet(int id);
        VwRequerimientodet GetVwRequerimientodet(Expression<Func<VwRequerimientodet, bool>> criteria);

        #endregion
        #endregion

        #region VwRequerimientoimpresion service

        long CountVwRequerimientoimpresion();
        long CountVwRequerimientoimpresion(Expression<Func<VwRequerimientoimpresion, bool>> criteria);
        List<VwRequerimientoimpresion> GetAllVwRequerimientoimpresion();
        List<VwRequerimientoimpresion> GetAllVwRequerimientoimpresion(Expression<Func<VwRequerimientoimpresion, bool>> criteria);
        List<VwRequerimientoimpresion> GetAllVwRequerimientoimpresion(string orders);
        List<VwRequerimientoimpresion> GetAllVwRequerimientoimpresion(string conditions, string orders);
        VwRequerimientoimpresion GetVwRequerimientoimpresion(int id);
        VwRequerimientoimpresion GetVwRequerimientoimpresion(Expression<Func<VwRequerimientoimpresion, bool>> criteria);

        #endregion

        #region VwOrdencompra service

        long CountVwOrdencompra();
        long CountVwOrdencompra(Expression<Func<VwOrdencompra, bool>> criteria);
        List<VwOrdencompra> GetAllVwOrdencompra();
        List<VwOrdencompra> GetAllVwOrdencompra(Expression<Func<VwOrdencompra, bool>> criteria);
        List<VwOrdencompra> GetAllVwOrdencompra(string orders);
        List<VwOrdencompra> GetAllVwOrdencompra(string conditions, string orders);
        VwOrdencompra GetVwOrdencompra(int id);
        VwOrdencompra GetVwOrdencompra(Expression<Func<VwOrdencompra, bool>> criteria);

        #endregion

        #region VwOrdencompradet service

        long CountVwOrdencompradet();
        long CountVwOrdencompradet(Expression<Func<VwOrdencompradet, bool>> criteria);
        List<VwOrdencompradet> GetAllVwOrdencompradet();
        List<VwOrdencompradet> GetAllVwOrdencompradet(Expression<Func<VwOrdencompradet, bool>> criteria);
        List<VwOrdencompradet> GetAllVwOrdencompradet(string orders);
        List<VwOrdencompradet> GetAllVwOrdencompradet(string conditions, string orders);
        VwOrdencompradet GetVwOrdencompradet(int id);
        VwOrdencompradet GetVwOrdencompradet(Expression<Func<VwOrdencompradet, bool>> criteria);

        #endregion

        #region VwCpcompra service

        long CountVwCpcompra();
        long CountVwCpcompra(Expression<Func<VwCpcompra, bool>> criteria);
        List<VwCpcompra> GetAllVwCpcompra();
        List<VwCpcompra> GetAllVwCpcompra(Expression<Func<VwCpcompra, bool>> criteria);
        List<VwCpcompra> GetAllVwCpcompra(string orders);
        List<VwCpcompra> GetAllVwCpcompra(string conditions, string orders);
        VwCpcompra GetVwCpcompra(int id);
        VwCpcompra GetVwCpcompra(Expression<Func<VwCpcompra, bool>> criteria);

        #endregion

        #region VwCpcompradet service

        long CountVwCpcompradet();
        long CountVwCpcompradet(Expression<Func<VwCpcompradet, bool>> criteria);
        List<VwCpcompradet> GetAllVwCpcompradet();
        List<VwCpcompradet> GetAllVwCpcompradet(Expression<Func<VwCpcompradet, bool>> criteria);
        List<VwCpcompradet> GetAllVwCpcompradet(string orders);
        List<VwCpcompradet> GetAllVwCpcompradet(string conditions, string orders);
        VwCpcompradet GetVwCpcompradet(int id);
        VwCpcompradet GetVwCpcompradet(Expression<Func<VwCpcompradet, bool>> criteria);

        #endregion

        #region VwRequerimientodetordcompraimp service

        long CountVwRequerimientodetordcompraimp();
        long CountVwRequerimientodetordcompraimp(Expression<Func<VwRequerimientodetordcompraimp, bool>> criteria);
        List<VwRequerimientodetordcompraimp> GetAllVwRequerimientodetordcompraimp();
        List<VwRequerimientodetordcompraimp> GetAllVwRequerimientodetordcompraimp(Expression<Func<VwRequerimientodetordcompraimp, bool>> criteria);
        List<VwRequerimientodetordcompraimp> GetAllVwRequerimientodetordcompraimp(string orders);
        List<VwRequerimientodetordcompraimp> GetAllVwRequerimientodetordcompraimp(string conditions, string orders);
        VwRequerimientodetordcompraimp GetVwRequerimientodetordcompraimp(int id);
        VwRequerimientodetordcompraimp GetVwRequerimientodetordcompraimp(Expression<Func<VwRequerimientodetordcompraimp, bool>> criteria);

        #endregion

        #region Estadoreq service

        long CountEstadoreq();
        long CountEstadoreq(Expression<Func<Estadoreq, bool>> criteria);
        int SaveEstadoreq(Estadoreq entity);
        void UpdateEstadoreq(Estadoreq entity);
        void DeleteEstadoreq(int id);
        List<Estadoreq> GetAllEstadoreq();
        List<Estadoreq> GetAllEstadoreq(Expression<Func<Estadoreq, bool>> criteria);
        List<Estadoreq> GetAllEstadoreq(string orders);
        List<Estadoreq> GetAllEstadoreq(string conditions, string orders);
        Estadoreq GetEstadoreq(int id);
        Estadoreq GetEstadoreq(Expression<Func<Estadoreq, bool>> criteria);

        #endregion

        #region VwOrdencompraimpresion service

        long CountVwOrdencompraimpresion();
        long CountVwOrdencompraimpresion(Expression<Func<VwOrdencompraimpresion, bool>> criteria);
        List<VwOrdencompraimpresion> GetAllVwOrdencompraimpresion();
        List<VwOrdencompraimpresion> GetAllVwOrdencompraimpresion(Expression<Func<VwOrdencompraimpresion, bool>> criteria);
        List<VwOrdencompraimpresion> GetAllVwOrdencompraimpresion(string orders);
        List<VwOrdencompraimpresion> GetAllVwOrdencompraimpresion(string conditions, string orders);
        VwOrdencompraimpresion GetVwOrdencompraimpresion(int id);
        VwOrdencompraimpresion GetVwOrdencompraimpresion(Expression<Func<VwOrdencompraimpresion, bool>> criteria);

        #endregion

        #region VwOrdencompradetingresoimp service

        long CountVwOrdencompradetingresoimp();
        long CountVwOrdencompradetingresoimp(Expression<Func<VwOrdencompradetingresoimp, bool>> criteria);
        List<VwOrdencompradetingresoimp> GetAllVwOrdencompradetingresoimp();
        List<VwOrdencompradetingresoimp> GetAllVwOrdencompradetingresoimp(Expression<Func<VwOrdencompradetingresoimp, bool>> criteria);
        List<VwOrdencompradetingresoimp> GetAllVwOrdencompradetingresoimp(string orders);
        List<VwOrdencompradetingresoimp> GetAllVwOrdencompradetingresoimp(string conditions, string orders);
        VwOrdencompradetingresoimp GetVwOrdencompradetingresoimp(int id);
        VwOrdencompradetingresoimp GetVwOrdencompradetingresoimp(Expression<Func<VwOrdencompradetingresoimp, bool>> criteria);

        #endregion

        #region VwOrdencompradetcpcompraimp service

        long CountVwOrdencompradetcpcompraimp();
        long CountVwOrdencompradetcpcompraimp(Expression<Func<VwOrdencompradetcpcompraimp, bool>> criteria);
        List<VwOrdencompradetcpcompraimp> GetAllVwOrdencompradetcpcompraimp();
        List<VwOrdencompradetcpcompraimp> GetAllVwOrdencompradetcpcompraimp(Expression<Func<VwOrdencompradetcpcompraimp, bool>> criteria);
        List<VwOrdencompradetcpcompraimp> GetAllVwOrdencompradetcpcompraimp(string orders);
        List<VwOrdencompradetcpcompraimp> GetAllVwOrdencompradetcpcompraimp(string conditions, string orders);
        VwOrdencompradetcpcompraimp GetVwOrdencompradetcpcompraimp(int id);
        VwOrdencompradetcpcompraimp GetVwOrdencompradetcpcompraimp(Expression<Func<VwOrdencompradetcpcompraimp, bool>> criteria);

        #endregion

        #region Notacredito service

        long CountNotacredito();
        long CountNotacredito(Expression<Func<Notacredito, bool>> criteria);
        int SaveNotacredito(Notacredito entity);
        void UpdateNotacredito(Notacredito entity);
        void DeleteNotacredito(int id);
        List<Notacredito> GetAllNotacredito();
        List<Notacredito> GetAllNotacredito(Expression<Func<Notacredito, bool>> criteria);
        List<Notacredito> GetAllNotacredito(string orders);
        List<Notacredito> GetAllNotacredito(string conditions, string orders);
        Notacredito GetNotacredito(int id);
        Notacredito GetNotacredito(Expression<Func<Notacredito, bool>> criteria);
        bool GuardarNotacredito(TipoMantenimiento tipoMantenimiento, Notacredito entidadCab, List<VwNotacreditodet> entidadDetList);


        #endregion

        #region Notacreditodet service

        long CountNotacreditodet();
        long CountNotacreditodet(Expression<Func<Notacreditodet, bool>> criteria);
        int SaveNotacreditodet(Notacreditodet entity);
        void UpdateNotacreditodet(Notacreditodet entity);
        void DeleteNotacreditodet(int id);
        List<Notacreditodet> GetAllNotacreditodet();
        List<Notacreditodet> GetAllNotacreditodet(Expression<Func<Notacreditodet, bool>> criteria);
        List<Notacreditodet> GetAllNotacreditodet(string orders);
        List<Notacreditodet> GetAllNotacreditodet(string conditions, string orders);
        Notacreditodet GetNotacreditodet(int id);
        Notacreditodet GetNotacreditodet(Expression<Func<Notacreditodet, bool>> criteria);

        #endregion

        #region VwNotacredito service

        long CountVwNotacredito();
        long CountVwNotacredito(Expression<Func<VwNotacredito, bool>> criteria);
        List<VwNotacredito> GetAllVwNotacredito();
        List<VwNotacredito> GetAllVwNotacredito(Expression<Func<VwNotacredito, bool>> criteria);
        List<VwNotacredito> GetAllVwNotacredito(string orders);
        List<VwNotacredito> GetAllVwNotacredito(string conditions, string orders);
        VwNotacredito GetVwNotacredito(int id);
        VwNotacredito GetVwNotacredito(Expression<Func<VwNotacredito, bool>> criteria);

        #endregion

        #region VwNotacreditodet service

        long CountVwNotacreditodet();
        long CountVwNotacreditodet(Expression<Func<VwNotacreditodet, bool>> criteria);
        List<VwNotacreditodet> GetAllVwNotacreditodet();
        List<VwNotacreditodet> GetAllVwNotacreditodet(Expression<Func<VwNotacreditodet, bool>> criteria);
        List<VwNotacreditodet> GetAllVwNotacreditodet(string orders);
        List<VwNotacreditodet> GetAllVwNotacreditodet(string conditions, string orders);
        VwNotacreditodet GetVwNotacreditodet(int id);
        VwNotacreditodet GetVwNotacreditodet(Expression<Func<VwNotacreditodet, bool>> criteria);

        #endregion

        #region Estadopago service

        long CountEstadopago();
        long CountEstadopago(Expression<Func<Estadopago, bool>> criteria);
        int SaveEstadopago(Estadopago entity);
        void UpdateEstadopago(Estadopago entity);
        void DeleteEstadopago(int id);
        List<Estadopago> GetAllEstadopago();
        List<Estadopago> GetAllEstadopago(Expression<Func<Estadopago, bool>> criteria);
        List<Estadopago> GetAllEstadopago(string orders);
        List<Estadopago> GetAllEstadopago(string conditions, string orders);
        Estadopago GetEstadopago(int id);
        Estadopago GetEstadopago(Expression<Func<Estadopago, bool>> criteria);

        #endregion

        #region Notadebito service

        long CountNotadebito();
        long CountNotadebito(Expression<Func<Notadebito, bool>> criteria);
        int SaveNotadebito(Notadebito entity);
        void UpdateNotadebito(Notadebito entity);
        void DeleteNotadebito(int id);
        List<Notadebito> GetAllNotadebito();
        List<Notadebito> GetAllNotadebito(Expression<Func<Notadebito, bool>> criteria);
        List<Notadebito> GetAllNotadebito(string orders);
        List<Notadebito> GetAllNotadebito(string conditions, string orders);
        Notadebito GetNotadebito(int id);
        Notadebito GetNotadebito(Expression<Func<Notadebito, bool>> criteria);
        bool GuardarNotadebito(TipoMantenimiento tipoMantenimiento, Notadebito entidadCab, List<VwNotadebitodet> entidadDetList);

        #endregion

        #region Notadebitodet service

        long CountNotadebitodet();
        long CountNotadebitodet(Expression<Func<Notadebitodet, bool>> criteria);
        int SaveNotadebitodet(Notadebitodet entity);
        void UpdateNotadebitodet(Notadebitodet entity);
        void DeleteNotadebitodet(int id);
        List<Notadebitodet> GetAllNotadebitodet();
        List<Notadebitodet> GetAllNotadebitodet(Expression<Func<Notadebitodet, bool>> criteria);
        List<Notadebitodet> GetAllNotadebitodet(string orders);
        List<Notadebitodet> GetAllNotadebitodet(string conditions, string orders);
        Notadebitodet GetNotadebitodet(int id);
        Notadebitodet GetNotadebitodet(Expression<Func<Notadebitodet, bool>> criteria);

        #endregion

        #region VwNotadebito service

        long CountVwNotadebito();
        long CountVwNotadebito(Expression<Func<VwNotadebito, bool>> criteria);
        List<VwNotadebito> GetAllVwNotadebito();
        List<VwNotadebito> GetAllVwNotadebito(Expression<Func<VwNotadebito, bool>> criteria);
        List<VwNotadebito> GetAllVwNotadebito(string orders);
        List<VwNotadebito> GetAllVwNotadebito(string conditions, string orders);
        VwNotadebito GetVwNotadebito(int id);
        VwNotadebito GetVwNotadebito(Expression<Func<VwNotadebito, bool>> criteria);

        #endregion

        #region VwNotadebitodet service

        long CountVwNotadebitodet();
        long CountVwNotadebitodet(Expression<Func<VwNotadebitodet, bool>> criteria);
        List<VwNotadebitodet> GetAllVwNotadebitodet();
        List<VwNotadebitodet> GetAllVwNotadebitodet(Expression<Func<VwNotadebitodet, bool>> criteria);
        List<VwNotadebitodet> GetAllVwNotadebitodet(string orders);
        List<VwNotadebitodet> GetAllVwNotadebitodet(string conditions, string orders);
        VwNotadebitodet GetVwNotadebitodet(int id);
        VwNotadebitodet GetVwNotadebitodet(Expression<Func<VwNotadebitodet, bool>> criteria);

        #endregion

        #region VwCpcompraimpnc service

        long CountVwCpcompraimpnc();
        long CountVwCpcompraimpnc(Expression<Func<VwCpcompraimpnc, bool>> criteria);
        List<VwCpcompraimpnc> GetAllVwCpcompraimpnc();
        List<VwCpcompraimpnc> GetAllVwCpcompraimpnc(Expression<Func<VwCpcompraimpnc, bool>> criteria);
        List<VwCpcompraimpnc> GetAllVwCpcompraimpnc(string orders);
        List<VwCpcompraimpnc> GetAllVwCpcompraimpnc(string conditions, string orders);
        VwCpcompraimpnc GetVwCpcompraimpnc(int id);
        VwCpcompraimpnc GetVwCpcompraimpnc(Expression<Func<VwCpcompraimpnc, bool>> criteria);

        #endregion

        #region VwCpcompraimpnd service

        long CountVwCpcompraimpnd();
        long CountVwCpcompraimpnd(Expression<Func<VwCpcompraimpnd, bool>> criteria);
        List<VwCpcompraimpnd> GetAllVwCpcompraimpnd();
        List<VwCpcompraimpnd> GetAllVwCpcompraimpnd(Expression<Func<VwCpcompraimpnd, bool>> criteria);
        List<VwCpcompraimpnd> GetAllVwCpcompraimpnd(string orders);
        List<VwCpcompraimpnd> GetAllVwCpcompraimpnd(string conditions, string orders);
        VwCpcompraimpnd GetVwCpcompraimpnd(int id);
        VwCpcompraimpnd GetVwCpcompraimpnd(Expression<Func<VwCpcompraimpnd, bool>> criteria);

        #endregion

        #region Cotizacionprv service

        long CountCotizacionprv();
        long CountCotizacionprv(Expression<Func<Cotizacionprv, bool>> criteria);
        int SaveCotizacionprv(Cotizacionprv entity);
        void UpdateCotizacionprv(Cotizacionprv entity);
        void DeleteCotizacionprv(int id);
        List<Cotizacionprv> GetAllCotizacionprv();
        List<Cotizacionprv> GetAllCotizacionprv(Expression<Func<Cotizacionprv, bool>> criteria);
        List<Cotizacionprv> GetAllCotizacionprv(string orders);
        List<Cotizacionprv> GetAllCotizacionprv(string conditions, string orders);
        Cotizacionprv GetCotizacionprv(int id);
        Cotizacionprv GetCotizacionprv(Expression<Func<Cotizacionprv, bool>> criteria);
        bool CotizacionPrvTieneReferenciaCuadroComparativo(int idcotizacionprv);
        #endregion

        #region Cotizacionprvdet service

        long CountCotizacionprvdet();
        long CountCotizacionprvdet(Expression<Func<Cotizacionprvdet, bool>> criteria);
        int SaveCotizacionprvdet(Cotizacionprvdet entity);
        void UpdateCotizacionprvdet(Cotizacionprvdet entity);
        void DeleteCotizacionprvdet(int id);
        List<Cotizacionprvdet> GetAllCotizacionprvdet();
        List<Cotizacionprvdet> GetAllCotizacionprvdet(Expression<Func<Cotizacionprvdet, bool>> criteria);
        List<Cotizacionprvdet> GetAllCotizacionprvdet(string orders);
        List<Cotizacionprvdet> GetAllCotizacionprvdet(string conditions, string orders);
        Cotizacionprvdet GetCotizacionprvdet(int id);
        Cotizacionprvdet GetCotizacionprvdet(Expression<Func<Cotizacionprvdet, bool>> criteria);

        #endregion

        #region Cuadrocomparativo service

        long CountCuadrocomparativo();
        long CountCuadrocomparativo(Expression<Func<Cuadrocomparativo, bool>> criteria);
        int SaveCuadrocomparativo(Cuadrocomparativo entity);
        void UpdateCuadrocomparativo(Cuadrocomparativo entity);
        void DeleteCuadrocomparativo(int id);
        List<Cuadrocomparativo> GetAllCuadrocomparativo();
        List<Cuadrocomparativo> GetAllCuadrocomparativo(Expression<Func<Cuadrocomparativo, bool>> criteria);
        List<Cuadrocomparativo> GetAllCuadrocomparativo(string orders);
        List<Cuadrocomparativo> GetAllCuadrocomparativo(string conditions, string orders);
        Cuadrocomparativo GetCuadrocomparativo(int id);
        Cuadrocomparativo GetCuadrocomparativo(Expression<Func<Cuadrocomparativo, bool>> criteria);
        void AnularReferenciaCotizacionPrvCuadroComparativo(int idcuadrocomparativo);
        bool CuadrocomparativoAprobado(int idcuadrocomparativo);
        #endregion

        #region Cuadrocomparativoarticulo service

        long CountCuadrocomparativoarticulo();
        long CountCuadrocomparativoarticulo(Expression<Func<Cuadrocomparativoarticulo, bool>> criteria);
        int SaveCuadrocomparativoarticulo(Cuadrocomparativoarticulo entity);
        void UpdateCuadrocomparativoarticulo(Cuadrocomparativoarticulo entity);
        void DeleteCuadrocomparativoarticulo(int id);
        List<Cuadrocomparativoarticulo> GetAllCuadrocomparativoarticulo();
        List<Cuadrocomparativoarticulo> GetAllCuadrocomparativoarticulo(Expression<Func<Cuadrocomparativoarticulo, bool>> criteria);
        List<Cuadrocomparativoarticulo> GetAllCuadrocomparativoarticulo(string orders);
        List<Cuadrocomparativoarticulo> GetAllCuadrocomparativoarticulo(string conditions, string orders);
        Cuadrocomparativoarticulo GetCuadrocomparativoarticulo(int id);
        Cuadrocomparativoarticulo GetCuadrocomparativoarticulo(Expression<Func<Cuadrocomparativoarticulo, bool>> criteria);

        #endregion

        #region Cuadrocomparativoprv service

        long CountCuadrocomparativoprv();
        long CountCuadrocomparativoprv(Expression<Func<Cuadrocomparativoprv, bool>> criteria);
        int SaveCuadrocomparativoprv(Cuadrocomparativoprv entity);
        void UpdateCuadrocomparativoprv(Cuadrocomparativoprv entity);
        void DeleteCuadrocomparativoprv(int id);
        List<Cuadrocomparativoprv> GetAllCuadrocomparativoprv();
        List<Cuadrocomparativoprv> GetAllCuadrocomparativoprv(Expression<Func<Cuadrocomparativoprv, bool>> criteria);
        List<Cuadrocomparativoprv> GetAllCuadrocomparativoprv(string orders);
        List<Cuadrocomparativoprv> GetAllCuadrocomparativoprv(string conditions, string orders);
        Cuadrocomparativoprv GetCuadrocomparativoprv(int id);
        Cuadrocomparativoprv GetCuadrocomparativoprv(Expression<Func<Cuadrocomparativoprv, bool>> criteria);
        bool ActualizarTotalCuadroComparativoPrv(int idcuadrocomparativoprv, decimal totalDocumento);
        bool ActualizarItemBuenaProCuadroComparativoPrv(int idcuadrocomparativoprv, bool buenapro);
        #endregion

        #region VwCotizacionprv service

        long CountVwCotizacionprv();
        long CountVwCotizacionprv(Expression<Func<VwCotizacionprv, bool>> criteria);
        List<VwCotizacionprv> GetAllVwCotizacionprv();
        List<VwCotizacionprv> GetAllVwCotizacionprv(Expression<Func<VwCotizacionprv, bool>> criteria);
        List<VwCotizacionprv> GetAllVwCotizacionprv(string orders);
        List<VwCotizacionprv> GetAllVwCotizacionprv(string conditions, string orders);
        VwCotizacionprv GetVwCotizacionprv(int id);
        VwCotizacionprv GetVwCotizacionprv(Expression<Func<VwCotizacionprv, bool>> criteria);

        #endregion

        #region VwCotizacionprvdet service

        long CountVwCotizacionprvdet();
        long CountVwCotizacionprvdet(Expression<Func<VwCotizacionprvdet, bool>> criteria);
        List<VwCotizacionprvdet> GetAllVwCotizacionprvdet();
        List<VwCotizacionprvdet> GetAllVwCotizacionprvdet(Expression<Func<VwCotizacionprvdet, bool>> criteria);
        List<VwCotizacionprvdet> GetAllVwCotizacionprvdet(string orders);
        List<VwCotizacionprvdet> GetAllVwCotizacionprvdet(string conditions, string orders);
        VwCotizacionprvdet GetVwCotizacionprvdet(int id);
        VwCotizacionprvdet GetVwCotizacionprvdet(Expression<Func<VwCotizacionprvdet, bool>> criteria);

        #endregion

        #region VwCuadrocomparativo service

        long CountVwCuadrocomparativo();
        long CountVwCuadrocomparativo(Expression<Func<VwCuadrocomparativo, bool>> criteria);
        List<VwCuadrocomparativo> GetAllVwCuadrocomparativo();
        List<VwCuadrocomparativo> GetAllVwCuadrocomparativo(Expression<Func<VwCuadrocomparativo, bool>> criteria);
        List<VwCuadrocomparativo> GetAllVwCuadrocomparativo(string orders);
        List<VwCuadrocomparativo> GetAllVwCuadrocomparativo(string conditions, string orders);
        VwCuadrocomparativo GetVwCuadrocomparativo(int id);
        VwCuadrocomparativo GetVwCuadrocomparativo(Expression<Func<VwCuadrocomparativo, bool>> criteria);

        #endregion

        #region VwCuadrocomparativoarticulo service

        long CountVwCuadrocomparativoarticulo();
        long CountVwCuadrocomparativoarticulo(Expression<Func<VwCuadrocomparativoarticulo, bool>> criteria);
        List<VwCuadrocomparativoarticulo> GetAllVwCuadrocomparativoarticulo();
        List<VwCuadrocomparativoarticulo> GetAllVwCuadrocomparativoarticulo(Expression<Func<VwCuadrocomparativoarticulo, bool>> criteria);
        List<VwCuadrocomparativoarticulo> GetAllVwCuadrocomparativoarticulo(string orders);
        List<VwCuadrocomparativoarticulo> GetAllVwCuadrocomparativoarticulo(string conditions, string orders);
        VwCuadrocomparativoarticulo GetVwCuadrocomparativoarticulo(int id);
        VwCuadrocomparativoarticulo GetVwCuadrocomparativoarticulo(Expression<Func<VwCuadrocomparativoarticulo, bool>> criteria);

        #endregion

        #region VwCuadrocomparativoprv service

        long CountVwCuadrocomparativoprv();
        long CountVwCuadrocomparativoprv(Expression<Func<VwCuadrocomparativoprv, bool>> criteria);
        List<VwCuadrocomparativoprv> GetAllVwCuadrocomparativoprv();
        List<VwCuadrocomparativoprv> GetAllVwCuadrocomparativoprv(Expression<Func<VwCuadrocomparativoprv, bool>> criteria);
        List<VwCuadrocomparativoprv> GetAllVwCuadrocomparativoprv(string orders);
        List<VwCuadrocomparativoprv> GetAllVwCuadrocomparativoprv(string conditions, string orders);
        VwCuadrocomparativoprv GetVwCuadrocomparativoprv(int id);
        VwCuadrocomparativoprv GetVwCuadrocomparativoprv(Expression<Func<VwCuadrocomparativoprv, bool>> criteria);

        #endregion

        #region VwRequerimientodetcotizaprvimp service

        long CountVwRequerimientodetcotizaprvimp();
        long CountVwRequerimientodetcotizaprvimp(Expression<Func<VwRequerimientodetcotizaprvimp, bool>> criteria);
        List<VwRequerimientodetcotizaprvimp> GetAllVwRequerimientodetcotizaprvimp();
        List<VwRequerimientodetcotizaprvimp> GetAllVwRequerimientodetcotizaprvimp(Expression<Func<VwRequerimientodetcotizaprvimp, bool>> criteria);
        List<VwRequerimientodetcotizaprvimp> GetAllVwRequerimientodetcotizaprvimp(string orders);
        List<VwRequerimientodetcotizaprvimp> GetAllVwRequerimientodetcotizaprvimp(string conditions, string orders);
        VwRequerimientodetcotizaprvimp GetVwRequerimientodetcotizaprvimp(int id);
        VwRequerimientodetcotizaprvimp GetVwRequerimientodetcotizaprvimp(Expression<Func<VwRequerimientodetcotizaprvimp, bool>> criteria);

        #endregion

        #region VwRequerimientodetimpguiaremision service

        long CountVwRequerimientodetimpguiaremision();
        long CountVwRequerimientodetimpguiaremision(Expression<Func<VwRequerimientodetimpguiaremision, bool>> criteria);
        List<VwRequerimientodetimpguiaremision> GetAllVwRequerimientodetimpguiaremision();
        List<VwRequerimientodetimpguiaremision> GetAllVwRequerimientodetimpguiaremision(Expression<Func<VwRequerimientodetimpguiaremision, bool>> criteria);
        List<VwRequerimientodetimpguiaremision> GetAllVwRequerimientodetimpguiaremision(string orders);
        List<VwRequerimientodetimpguiaremision> GetAllVwRequerimientodetimpguiaremision(string conditions, string orders);
        VwRequerimientodetimpguiaremision GetVwRequerimientodetimpguiaremision(int id);
        VwRequerimientodetimpguiaremision GetVwRequerimientodetimpguiaremision(Expression<Func<VwRequerimientodetimpguiaremision, bool>> criteria);

        #endregion

        #region Tiporegistroorden service

        long CountTiporegistroorden();
        long CountTiporegistroorden(Expression<Func<Tiporegistroorden, bool>> criteria);
        int SaveTiporegistroorden(Tiporegistroorden entity);
        void UpdateTiporegistroorden(Tiporegistroorden entity);
        void DeleteTiporegistroorden(int id);
        List<Tiporegistroorden> GetAllTiporegistroorden();
        List<Tiporegistroorden> GetAllTiporegistroorden(Expression<Func<Tiporegistroorden, bool>> criteria);
        List<Tiporegistroorden> GetAllTiporegistroorden(string orders);
        List<Tiporegistroorden> GetAllTiporegistroorden(string conditions, string orders);
        Tiporegistroorden GetTiporegistroorden(int id);
        Tiporegistroorden GetTiporegistroorden(Expression<Func<Tiporegistroorden, bool>> criteria);

        #endregion

        #region VwCuadrocomparativoarticuloimpoc service

        long CountVwCuadrocomparativoarticuloimpoc();
        long CountVwCuadrocomparativoarticuloimpoc(Expression<Func<VwCuadrocomparativoarticuloimpoc, bool>> criteria);
        List<VwCuadrocomparativoarticuloimpoc> GetAllVwCuadrocomparativoarticuloimpoc();
        List<VwCuadrocomparativoarticuloimpoc> GetAllVwCuadrocomparativoarticuloimpoc(Expression<Func<VwCuadrocomparativoarticuloimpoc, bool>> criteria);
        List<VwCuadrocomparativoarticuloimpoc> GetAllVwCuadrocomparativoarticuloimpoc(string orders);
        List<VwCuadrocomparativoarticuloimpoc> GetAllVwCuadrocomparativoarticuloimpoc(string conditions, string orders);
        VwCuadrocomparativoarticuloimpoc GetVwCuadrocomparativoarticuloimpoc(int id);
        VwCuadrocomparativoarticuloimpoc GetVwCuadrocomparativoarticuloimpoc(Expression<Func<VwCuadrocomparativoarticuloimpoc, bool>> criteria);

        #endregion

        #region VwCuadrocomparativoaaprobar service

        long CountVwCuadrocomparativoaaprobar();
        long CountVwCuadrocomparativoaaprobar(Expression<Func<VwCuadrocomparativoaaprobar, bool>> criteria);
        List<VwCuadrocomparativoaaprobar> GetAllVwCuadrocomparativoaaprobar();
        List<VwCuadrocomparativoaaprobar> GetAllVwCuadrocomparativoaaprobar(Expression<Func<VwCuadrocomparativoaaprobar, bool>> criteria);
        List<VwCuadrocomparativoaaprobar> GetAllVwCuadrocomparativoaaprobar(string orders);
        List<VwCuadrocomparativoaaprobar> GetAllVwCuadrocomparativoaaprobar(string conditions, string orders);
        VwCuadrocomparativoaaprobar GetVwCuadrocomparativoaaprobar(int id);
        VwCuadrocomparativoaaprobar GetVwCuadrocomparativoaaprobar(Expression<Func<VwCuadrocomparativoaaprobar, bool>> criteria);

        #endregion

        #region VwCuadrocomparativomodeloautorizacion service

        long CountVwCuadrocomparativomodeloautorizacion();
        long CountVwCuadrocomparativomodeloautorizacion(Expression<Func<VwCuadrocomparativomodeloautorizacion, bool>> criteria);
        List<VwCuadrocomparativomodeloautorizacion> GetAllVwCuadrocomparativomodeloautorizacion();
        List<VwCuadrocomparativomodeloautorizacion> GetAllVwCuadrocomparativomodeloautorizacion(Expression<Func<VwCuadrocomparativomodeloautorizacion, bool>> criteria);
        List<VwCuadrocomparativomodeloautorizacion> GetAllVwCuadrocomparativomodeloautorizacion(string orders);
        List<VwCuadrocomparativomodeloautorizacion> GetAllVwCuadrocomparativomodeloautorizacion(string conditions, string orders);
        VwCuadrocomparativomodeloautorizacion GetVwCuadrocomparativomodeloautorizacion(int id);
        VwCuadrocomparativomodeloautorizacion GetVwCuadrocomparativomodeloautorizacion(Expression<Func<VwCuadrocomparativomodeloautorizacion, bool>> criteria);

        #endregion

        #region Ordenservicio service

        long CountOrdenservicio();
        long CountOrdenservicio(Expression<Func<Ordenservicio, bool>> criteria);
        int SaveOrdenservicio(Ordenservicio entity);
        void UpdateOrdenservicio(Ordenservicio entity);
        void DeleteOrdenservicio(int id);
        List<Ordenservicio> GetAllOrdenservicio();
        List<Ordenservicio> GetAllOrdenservicio(Expression<Func<Ordenservicio, bool>> criteria);
        List<Ordenservicio> GetAllOrdenservicio(string orders);
        List<Ordenservicio> GetAllOrdenservicio(string conditions, string orders);
        Ordenservicio GetOrdenservicio(int id);
        Ordenservicio GetOrdenservicio(Expression<Func<Ordenservicio, bool>> criteria);
        bool GuardarOrdenDeServicio(TipoMantenimiento tipoMantenimiento, Ordenservicio entidadCab, List<VwOrdenserviciodet> entidadDetList);
        bool NumeroOrdenServicioExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        bool OrdenServicioTieneReferenciaCpCompra(int idOrdenServicio);
        #endregion

        #region Ordenserviciodet service

        long CountOrdenserviciodet();
        long CountOrdenserviciodet(Expression<Func<Ordenserviciodet, bool>> criteria);
        int SaveOrdenserviciodet(Ordenserviciodet entity);
        void UpdateOrdenserviciodet(Ordenserviciodet entity);
        void DeleteOrdenserviciodet(int id);
        List<Ordenserviciodet> GetAllOrdenserviciodet();
        List<Ordenserviciodet> GetAllOrdenserviciodet(Expression<Func<Ordenserviciodet, bool>> criteria);
        List<Ordenserviciodet> GetAllOrdenserviciodet(string orders);
        List<Ordenserviciodet> GetAllOrdenserviciodet(string conditions, string orders);
        Ordenserviciodet GetOrdenserviciodet(int id);
        Ordenserviciodet GetOrdenserviciodet(Expression<Func<Ordenserviciodet, bool>> criteria);

        #endregion

        #region VwCuadrocomparativoarticuloimpos service

        long CountVwCuadrocomparativoarticuloimpos();
        long CountVwCuadrocomparativoarticuloimpos(Expression<Func<VwCuadrocomparativoarticuloimpos, bool>> criteria);
        List<VwCuadrocomparativoarticuloimpos> GetAllVwCuadrocomparativoarticuloimpos();
        List<VwCuadrocomparativoarticuloimpos> GetAllVwCuadrocomparativoarticuloimpos(Expression<Func<VwCuadrocomparativoarticuloimpos, bool>> criteria);
        List<VwCuadrocomparativoarticuloimpos> GetAllVwCuadrocomparativoarticuloimpos(string orders);
        List<VwCuadrocomparativoarticuloimpos> GetAllVwCuadrocomparativoarticuloimpos(string conditions, string orders);
        VwCuadrocomparativoarticuloimpos GetVwCuadrocomparativoarticuloimpos(int id);
        VwCuadrocomparativoarticuloimpos GetVwCuadrocomparativoarticuloimpos(Expression<Func<VwCuadrocomparativoarticuloimpos, bool>> criteria);

        #endregion

        #region VwOrdenservicio service

        long CountVwOrdenservicio();
        long CountVwOrdenservicio(Expression<Func<VwOrdenservicio, bool>> criteria);
        List<VwOrdenservicio> GetAllVwOrdenservicio();
        List<VwOrdenservicio> GetAllVwOrdenservicio(Expression<Func<VwOrdenservicio, bool>> criteria);
        List<VwOrdenservicio> GetAllVwOrdenservicio(string orders);
        List<VwOrdenservicio> GetAllVwOrdenservicio(string conditions, string orders);
        VwOrdenservicio GetVwOrdenservicio(int id);
        VwOrdenservicio GetVwOrdenservicio(Expression<Func<VwOrdenservicio, bool>> criteria);

        #endregion

        #region VwOrdenserviciodet service

        long CountVwOrdenserviciodet();
        long CountVwOrdenserviciodet(Expression<Func<VwOrdenserviciodet, bool>> criteria);
        List<VwOrdenserviciodet> GetAllVwOrdenserviciodet();
        List<VwOrdenserviciodet> GetAllVwOrdenserviciodet(Expression<Func<VwOrdenserviciodet, bool>> criteria);
        List<VwOrdenserviciodet> GetAllVwOrdenserviciodet(string orders);
        List<VwOrdenserviciodet> GetAllVwOrdenserviciodet(string conditions, string orders);
        VwOrdenserviciodet GetVwOrdenserviciodet(int id);
        VwOrdenserviciodet GetVwOrdenserviciodet(Expression<Func<VwOrdenserviciodet, bool>> criteria);

        #endregion

        #region VwOrdenservicioimpresion service

        long CountVwOrdenservicioimpresion();
        long CountVwOrdenservicioimpresion(Expression<Func<VwOrdenservicioimpresion, bool>> criteria);
        List<VwOrdenservicioimpresion> GetAllVwOrdenservicioimpresion();
        List<VwOrdenservicioimpresion> GetAllVwOrdenservicioimpresion(Expression<Func<VwOrdenservicioimpresion, bool>> criteria);
        List<VwOrdenservicioimpresion> GetAllVwOrdenservicioimpresion(string orders);
        List<VwOrdenservicioimpresion> GetAllVwOrdenservicioimpresion(string conditions, string orders);
        VwOrdenservicioimpresion GetVwOrdenservicioimpresion(int id);
        VwOrdenservicioimpresion GetVwOrdenservicioimpresion(Expression<Func<VwOrdenservicioimpresion, bool>> criteria);

        #endregion

        #region VwRequerimientodetordservicioimp service

        long CountVwRequerimientodetordservicioimp();
        long CountVwRequerimientodetordservicioimp(Expression<Func<VwRequerimientodetordservicioimp, bool>> criteria);
        List<VwRequerimientodetordservicioimp> GetAllVwRequerimientodetordservicioimp();
        List<VwRequerimientodetordservicioimp> GetAllVwRequerimientodetordservicioimp(Expression<Func<VwRequerimientodetordservicioimp, bool>> criteria);
        List<VwRequerimientodetordservicioimp> GetAllVwRequerimientodetordservicioimp(string orders);
        List<VwRequerimientodetordservicioimp> GetAllVwRequerimientodetordservicioimp(string conditions, string orders);
        VwRequerimientodetordservicioimp GetVwRequerimientodetordservicioimp(int id);
        VwRequerimientodetordservicioimp GetVwRequerimientodetordservicioimp(Expression<Func<VwRequerimientodetordservicioimp, bool>> criteria);

        #endregion

        #region VwOrdenserviciodetcpcompraimp service

        long CountVwOrdenserviciodetcpcompraimp();
        long CountVwOrdenserviciodetcpcompraimp(Expression<Func<VwOrdenserviciodetcpcompraimp, bool>> criteria);
        List<VwOrdenserviciodetcpcompraimp> GetAllVwOrdenserviciodetcpcompraimp();
        List<VwOrdenserviciodetcpcompraimp> GetAllVwOrdenserviciodetcpcompraimp(Expression<Func<VwOrdenserviciodetcpcompraimp, bool>> criteria);
        List<VwOrdenserviciodetcpcompraimp> GetAllVwOrdenserviciodetcpcompraimp(string orders);
        List<VwOrdenserviciodetcpcompraimp> GetAllVwOrdenserviciodetcpcompraimp(string conditions, string orders);
        VwOrdenserviciodetcpcompraimp GetVwOrdenserviciodetcpcompraimp(int id);
        VwOrdenserviciodetcpcompraimp GetVwOrdenserviciodetcpcompraimp(Expression<Func<VwOrdenserviciodetcpcompraimp, bool>> criteria);

        #endregion

        #region VwCpcompradetguiaremisionimp service

        long CountVwCpcompradetguiaremisionimp();
        long CountVwCpcompradetguiaremisionimp(Expression<Func<VwCpcompradetguiaremisionimp, bool>> criteria);
        List<VwCpcompradetguiaremisionimp> GetAllVwCpcompradetguiaremisionimp();
        List<VwCpcompradetguiaremisionimp> GetAllVwCpcompradetguiaremisionimp(Expression<Func<VwCpcompradetguiaremisionimp, bool>> criteria);
        List<VwCpcompradetguiaremisionimp> GetAllVwCpcompradetguiaremisionimp(string orders);
        List<VwCpcompradetguiaremisionimp> GetAllVwCpcompradetguiaremisionimp(string conditions, string orders);
        VwCpcompradetguiaremisionimp GetVwCpcompradetguiaremisionimp(int id);
        VwCpcompradetguiaremisionimp GetVwCpcompradetguiaremisionimp(Expression<Func<VwCpcompradetguiaremisionimp, bool>> criteria);

        #endregion


        #region Cpcompradetserie service

        long CountCpcompradetserie();
        long CountCpcompradetserie(Expression<Func<Cpcompradetserie, bool>> criteria);
        int SaveCpcompradetserie(Cpcompradetserie entity);
        void UpdateCpcompradetserie(Cpcompradetserie entity);
        void DeleteCpcompradetserie(int id);
        List<Cpcompradetserie> GetAllCpcompradetserie();
        List<Cpcompradetserie> GetAllCpcompradetserie(Expression<Func<Cpcompradetserie, bool>> criteria);
        List<Cpcompradetserie> GetAllCpcompradetserie(string orders);
        List<Cpcompradetserie> GetAllCpcompradetserie(string conditions, string orders);
        Cpcompradetserie GetCpcompradetserie(int id);
        Cpcompradetserie GetCpcompradetserie(Expression<Func<Cpcompradetserie, bool>> criteria);

        #endregion

        #region VwCpcompradetserie service

        long CountVwCpcompradetserie();
        long CountVwCpcompradetserie(Expression<Func<VwCpcompradetserie, bool>> criteria);
        List<VwCpcompradetserie> GetAllVwCpcompradetserie();
        List<VwCpcompradetserie> GetAllVwCpcompradetserie(Expression<Func<VwCpcompradetserie, bool>> criteria);
        List<VwCpcompradetserie> GetAllVwCpcompradetserie(string orders);
        List<VwCpcompradetserie> GetAllVwCpcompradetserie(string conditions, string orders);
        VwCpcompradetserie GetVwCpcompradetserie(int id);
        VwCpcompradetserie GetVwCpcompradetserie(Expression<Func<VwCpcompradetserie, bool>> criteria);

        #endregion


        #endregion

        #region Finanzas
     
        #region Tiporecibocaja service

        long CountTiporecibocaja();
        long CountTiporecibocaja(Expression<Func<Tiporecibocaja, bool>> criteria);
        int SaveTiporecibocaja(Tiporecibocaja entity);
        void UpdateTiporecibocaja(Tiporecibocaja entity);
        void DeleteTiporecibocaja(int id);
        List<Tiporecibocaja> GetAllTiporecibocaja();
        List<Tiporecibocaja> GetAllTiporecibocaja(Expression<Func<Tiporecibocaja, bool>> criteria);
        List<Tiporecibocaja> GetAllTiporecibocaja(string orders);
        List<Tiporecibocaja> GetAllTiporecibocaja(string conditions, string orders);
        Tiporecibocaja GetTiporecibocaja(int id);
        Tiporecibocaja GetTiporecibocaja(Expression<Func<Tiporecibocaja, bool>> criteria);

        #endregion

        #region VwCtactecliente service

        long CountVwCtactecliente();
        long CountVwCtactecliente(Expression<Func<VwCtactecliente, bool>> criteria);
        List<VwCtactecliente> GetAllVwCtactecliente();
        List<VwCtactecliente> GetAllVwCtactecliente(Expression<Func<VwCtactecliente, bool>> criteria);
        List<VwCtactecliente> GetAllVwCtactecliente(string orders);
        List<VwCtactecliente> GetAllVwCtactecliente(string conditions, string orders);
        VwCtactecliente GetVwCtactecliente(int id);
        VwCtactecliente GetVwCtactecliente(Expression<Func<VwCtactecliente, bool>> criteria);

        #endregion

        #region Rendicioncajachica service

        long CountRendicioncajachica();
        long CountRendicioncajachica(Expression<Func<Rendicioncajachica, bool>> criteria);
        int SaveRendicioncajachica(Rendicioncajachica entity);
        void UpdateRendicioncajachica(Rendicioncajachica entity);
        void DeleteRendicioncajachica(int id);
        List<Rendicioncajachica> GetAllRendicioncajachica();
        List<Rendicioncajachica> GetAllRendicioncajachica(Expression<Func<Rendicioncajachica, bool>> criteria);
        List<Rendicioncajachica> GetAllRendicioncajachica(string orders);
        List<Rendicioncajachica> GetAllRendicioncajachica(string conditions, string orders);
        Rendicioncajachica GetRendicioncajachica(int id);
        Rendicioncajachica GetRendicioncajachica(Expression<Func<Rendicioncajachica, bool>> criteria);
        bool ActualizarTotalesRendicionCajaChica(Rendicioncajachica rendicioncajachica);
        #endregion

        #region Rendicioncajachicadet service

        long CountRendicioncajachicadet();
        long CountRendicioncajachicadet(Expression<Func<Rendicioncajachicadet, bool>> criteria);
        int SaveRendicioncajachicadet(Rendicioncajachicadet entity);
        void UpdateRendicioncajachicadet(Rendicioncajachicadet entity);
        void DeleteRendicioncajachicadet(int id);
        List<Rendicioncajachicadet> GetAllRendicioncajachicadet();
        List<Rendicioncajachicadet> GetAllRendicioncajachicadet(Expression<Func<Rendicioncajachicadet, bool>> criteria);
        List<Rendicioncajachicadet> GetAllRendicioncajachicadet(string orders);
        List<Rendicioncajachicadet> GetAllRendicioncajachicadet(string conditions, string orders);
        Rendicioncajachicadet GetRendicioncajachicadet(int id);
        Rendicioncajachicadet GetRendicioncajachicadet(Expression<Func<Rendicioncajachicadet, bool>> criteria);

        #endregion

        #region VwRendicioncajachica service

        long CountVwRendicioncajachica();
        long CountVwRendicioncajachica(Expression<Func<VwRendicioncajachica, bool>> criteria);
        List<VwRendicioncajachica> GetAllVwRendicioncajachica();
        List<VwRendicioncajachica> GetAllVwRendicioncajachica(Expression<Func<VwRendicioncajachica, bool>> criteria);
        List<VwRendicioncajachica> GetAllVwRendicioncajachica(string orders);
        List<VwRendicioncajachica> GetAllVwRendicioncajachica(string conditions, string orders);
        VwRendicioncajachica GetVwRendicioncajachica(int id);
        VwRendicioncajachica GetVwRendicioncajachica(Expression<Func<VwRendicioncajachica, bool>> criteria);

        #endregion

        #region VwRendicioncajachicadet service

        long CountVwRendicioncajachicadet();
        long CountVwRendicioncajachicadet(Expression<Func<VwRendicioncajachicadet, bool>> criteria);
        List<VwRendicioncajachicadet> GetAllVwRendicioncajachicadet();
        List<VwRendicioncajachicadet> GetAllVwRendicioncajachicadet(Expression<Func<VwRendicioncajachicadet, bool>> criteria);
        List<VwRendicioncajachicadet> GetAllVwRendicioncajachicadet(string orders);
        List<VwRendicioncajachicadet> GetAllVwRendicioncajachicadet(string conditions, string orders);
        VwRendicioncajachicadet GetVwRendicioncajachicadet(int id);
        VwRendicioncajachicadet GetVwRendicioncajachicadet(Expression<Func<VwRendicioncajachicadet, bool>> criteria);

        #endregion

        #region Recibocajaingreso service

        long CountRecibocajaingreso();
        long CountRecibocajaingreso(Expression<Func<Recibocajaingreso, bool>> criteria);
        int SaveRecibocajaingreso(Recibocajaingreso entity);
        void UpdateRecibocajaingreso(Recibocajaingreso entity);
        void DeleteRecibocajaingreso(int id);
        List<Recibocajaingreso> GetAllRecibocajaingreso();
        List<Recibocajaingreso> GetAllRecibocajaingreso(Expression<Func<Recibocajaingreso, bool>> criteria);
        List<Recibocajaingreso> GetAllRecibocajaingreso(string orders);
        List<Recibocajaingreso> GetAllRecibocajaingreso(string conditions, string orders);
        Recibocajaingreso GetRecibocajaingreso(int id);
        Recibocajaingreso GetRecibocajaingreso(Expression<Func<Recibocajaingreso, bool>> criteria);
        bool ActualizarTotalesReciboCajaIngreso(Recibocajaingreso recibocajaingreso);
        bool CajaegresoTieneReferenciaCajaChica(int idRecibocajaegreo);
        int GuardarReciboCajaIngreso(TipoMantenimiento tipoMantenimiento, int idCpVenta, Recibocajaingreso recibocajaingreso, List<VwRecibocajaingresodet> vWrecibocajaingresodetList);
        #endregion

        #region Recibocajaingresodet service

        long CountRecibocajaingresodet();
        long CountRecibocajaingresodet(Expression<Func<Recibocajaingresodet, bool>> criteria);
        int SaveRecibocajaingresodet(Recibocajaingresodet entity);
        void UpdateRecibocajaingresodet(Recibocajaingresodet entity);
        void DeleteRecibocajaingresodet(int id);
        List<Recibocajaingresodet> GetAllRecibocajaingresodet();
        List<Recibocajaingresodet> GetAllRecibocajaingresodet(Expression<Func<Recibocajaingresodet, bool>> criteria);
        List<Recibocajaingresodet> GetAllRecibocajaingresodet(string orders);
        List<Recibocajaingresodet> GetAllRecibocajaingresodet(string conditions, string orders);
        Recibocajaingresodet GetRecibocajaingresodet(int id);
        Recibocajaingresodet GetRecibocajaingresodet(Expression<Func<Recibocajaingresodet, bool>> criteria);

        #endregion

        #region Recibocajaingresoimprevisto service

        long CountRecibocajaingresoimprevisto();
        long CountRecibocajaingresoimprevisto(Expression<Func<Recibocajaingresoimprevisto, bool>> criteria);
        int SaveRecibocajaingresoimprevisto(Recibocajaingresoimprevisto entity);
        void UpdateRecibocajaingresoimprevisto(Recibocajaingresoimprevisto entity);
        void DeleteRecibocajaingresoimprevisto(int id);
        List<Recibocajaingresoimprevisto> GetAllRecibocajaingresoimprevisto();
        List<Recibocajaingresoimprevisto> GetAllRecibocajaingresoimprevisto(Expression<Func<Recibocajaingresoimprevisto, bool>> criteria);
        List<Recibocajaingresoimprevisto> GetAllRecibocajaingresoimprevisto(string orders);
        List<Recibocajaingresoimprevisto> GetAllRecibocajaingresoimprevisto(string conditions, string orders);
        Recibocajaingresoimprevisto GetRecibocajaingresoimprevisto(int id);
        Recibocajaingresoimprevisto GetRecibocajaingresoimprevisto(Expression<Func<Recibocajaingresoimprevisto, bool>> criteria);

        #endregion

        #region VwRecibocajaingreso service

        long CountVwRecibocajaingreso();
        long CountVwRecibocajaingreso(Expression<Func<VwRecibocajaingreso, bool>> criteria);
        List<VwRecibocajaingreso> GetAllVwRecibocajaingreso();
        List<VwRecibocajaingreso> GetAllVwRecibocajaingreso(Expression<Func<VwRecibocajaingreso, bool>> criteria);
        List<VwRecibocajaingreso> GetAllVwRecibocajaingreso(string orders);
        List<VwRecibocajaingreso> GetAllVwRecibocajaingreso(string conditions, string orders);
        VwRecibocajaingreso GetVwRecibocajaingreso(int id);
        VwRecibocajaingreso GetVwRecibocajaingreso(Expression<Func<VwRecibocajaingreso, bool>> criteria);

        #endregion

        #region VwRecibocajaingresodet service

        long CountVwRecibocajaingresodet();
        long CountVwRecibocajaingresodet(Expression<Func<VwRecibocajaingresodet, bool>> criteria);
        List<VwRecibocajaingresodet> GetAllVwRecibocajaingresodet();
        List<VwRecibocajaingresodet> GetAllVwRecibocajaingresodet(Expression<Func<VwRecibocajaingresodet, bool>> criteria);
        List<VwRecibocajaingresodet> GetAllVwRecibocajaingresodet(string orders);
        List<VwRecibocajaingresodet> GetAllVwRecibocajaingresodet(string conditions, string orders);
        VwRecibocajaingresodet GetVwRecibocajaingresodet(int id);
        VwRecibocajaingresodet GetVwRecibocajaingresodet(Expression<Func<VwRecibocajaingresodet, bool>> criteria);

        #endregion

        #region VwRecibocajaingresoimprevisto service

        long CountVwRecibocajaingresoimprevisto();
        long CountVwRecibocajaingresoimprevisto(Expression<Func<VwRecibocajaingresoimprevisto, bool>> criteria);
        List<VwRecibocajaingresoimprevisto> GetAllVwRecibocajaingresoimprevisto();
        List<VwRecibocajaingresoimprevisto> GetAllVwRecibocajaingresoimprevisto(Expression<Func<VwRecibocajaingresoimprevisto, bool>> criteria);
        List<VwRecibocajaingresoimprevisto> GetAllVwRecibocajaingresoimprevisto(string orders);
        List<VwRecibocajaingresoimprevisto> GetAllVwRecibocajaingresoimprevisto(string conditions, string orders);
        VwRecibocajaingresoimprevisto GetVwRecibocajaingresoimprevisto(int id);
        VwRecibocajaingresoimprevisto GetVwRecibocajaingresoimprevisto(Expression<Func<VwRecibocajaingresoimprevisto, bool>> criteria);

        #endregion

        #region Recibocajaegreso service

        long CountRecibocajaegreso();
        long CountRecibocajaegreso(Expression<Func<Recibocajaegreso, bool>> criteria);
        int SaveRecibocajaegreso(Recibocajaegreso entity);
        void UpdateRecibocajaegreso(Recibocajaegreso entity);
        void DeleteRecibocajaegreso(int id);
        List<Recibocajaegreso> GetAllRecibocajaegreso();
        List<Recibocajaegreso> GetAllRecibocajaegreso(Expression<Func<Recibocajaegreso, bool>> criteria);
        List<Recibocajaegreso> GetAllRecibocajaegreso(string orders);
        List<Recibocajaegreso> GetAllRecibocajaegreso(string conditions, string orders);
        Recibocajaegreso GetRecibocajaegreso(int id);
        Recibocajaegreso GetRecibocajaegreso(Expression<Func<Recibocajaegreso, bool>> criteria);
        bool ActualizarTotalesReciboCajaEgreso(Recibocajaegreso recibocajaegreso);
        #endregion

        #region Recibocajaegresodet service

        long CountRecibocajaegresodet();
        long CountRecibocajaegresodet(Expression<Func<Recibocajaegresodet, bool>> criteria);
        int SaveRecibocajaegresodet(Recibocajaegresodet entity);
        void UpdateRecibocajaegresodet(Recibocajaegresodet entity);
        void DeleteRecibocajaegresodet(int id);
        List<Recibocajaegresodet> GetAllRecibocajaegresodet();
        List<Recibocajaegresodet> GetAllRecibocajaegresodet(Expression<Func<Recibocajaegresodet, bool>> criteria);
        List<Recibocajaegresodet> GetAllRecibocajaegresodet(string orders);
        List<Recibocajaegresodet> GetAllRecibocajaegresodet(string conditions, string orders);
        Recibocajaegresodet GetRecibocajaegresodet(int id);
        Recibocajaegresodet GetRecibocajaegresodet(Expression<Func<Recibocajaegresodet, bool>> criteria);

        #endregion

        #region Recibocajaegresoimprevisto service

        long CountRecibocajaegresoimprevisto();
        long CountRecibocajaegresoimprevisto(Expression<Func<Recibocajaegresoimprevisto, bool>> criteria);
        int SaveRecibocajaegresoimprevisto(Recibocajaegresoimprevisto entity);
        void UpdateRecibocajaegresoimprevisto(Recibocajaegresoimprevisto entity);
        void DeleteRecibocajaegresoimprevisto(int id);
        List<Recibocajaegresoimprevisto> GetAllRecibocajaegresoimprevisto();
        List<Recibocajaegresoimprevisto> GetAllRecibocajaegresoimprevisto(Expression<Func<Recibocajaegresoimprevisto, bool>> criteria);
        List<Recibocajaegresoimprevisto> GetAllRecibocajaegresoimprevisto(string orders);
        List<Recibocajaegresoimprevisto> GetAllRecibocajaegresoimprevisto(string conditions, string orders);
        Recibocajaegresoimprevisto GetRecibocajaegresoimprevisto(int id);
        Recibocajaegresoimprevisto GetRecibocajaegresoimprevisto(Expression<Func<Recibocajaegresoimprevisto, bool>> criteria);

        #endregion

        #region VwRecibocajaegreso service

        long CountVwRecibocajaegreso();
        long CountVwRecibocajaegreso(Expression<Func<VwRecibocajaegreso, bool>> criteria);
        List<VwRecibocajaegreso> GetAllVwRecibocajaegreso();
        List<VwRecibocajaegreso> GetAllVwRecibocajaegreso(Expression<Func<VwRecibocajaegreso, bool>> criteria);
        List<VwRecibocajaegreso> GetAllVwRecibocajaegreso(string orders);
        List<VwRecibocajaegreso> GetAllVwRecibocajaegreso(string conditions, string orders);
        VwRecibocajaegreso GetVwRecibocajaegreso(int id);
        VwRecibocajaegreso GetVwRecibocajaegreso(Expression<Func<VwRecibocajaegreso, bool>> criteria);

        #endregion

        #region VwRecibocajaegresodet service

        long CountVwRecibocajaegresodet();
        long CountVwRecibocajaegresodet(Expression<Func<VwRecibocajaegresodet, bool>> criteria);
        List<VwRecibocajaegresodet> GetAllVwRecibocajaegresodet();
        List<VwRecibocajaegresodet> GetAllVwRecibocajaegresodet(Expression<Func<VwRecibocajaegresodet, bool>> criteria);
        List<VwRecibocajaegresodet> GetAllVwRecibocajaegresodet(string orders);
        List<VwRecibocajaegresodet> GetAllVwRecibocajaegresodet(string conditions, string orders);
        VwRecibocajaegresodet GetVwRecibocajaegresodet(int id);
        VwRecibocajaegresodet GetVwRecibocajaegresodet(Expression<Func<VwRecibocajaegresodet, bool>> criteria);

        #endregion

        #region VwRecibocajaegresoimprevisto service

        long CountVwRecibocajaegresoimprevisto();
        long CountVwRecibocajaegresoimprevisto(Expression<Func<VwRecibocajaegresoimprevisto, bool>> criteria);
        List<VwRecibocajaegresoimprevisto> GetAllVwRecibocajaegresoimprevisto();
        List<VwRecibocajaegresoimprevisto> GetAllVwRecibocajaegresoimprevisto(Expression<Func<VwRecibocajaegresoimprevisto, bool>> criteria);
        List<VwRecibocajaegresoimprevisto> GetAllVwRecibocajaegresoimprevisto(string orders);
        List<VwRecibocajaegresoimprevisto> GetAllVwRecibocajaegresoimprevisto(string conditions, string orders);
        VwRecibocajaegresoimprevisto GetVwRecibocajaegresoimprevisto(int id);
        VwRecibocajaegresoimprevisto GetVwRecibocajaegresoimprevisto(Expression<Func<VwRecibocajaegresoimprevisto, bool>> criteria);

        #endregion

        #region VwCtacteproveedor service

        long CountVwCtacteproveedor();
        long CountVwCtacteproveedor(Expression<Func<VwCtacteproveedor, bool>> criteria);
        List<VwCtacteproveedor> GetAllVwCtacteproveedor();
        List<VwCtacteproveedor> GetAllVwCtacteproveedor(Expression<Func<VwCtacteproveedor, bool>> criteria);
        List<VwCtacteproveedor> GetAllVwCtacteproveedor(string orders);
        List<VwCtacteproveedor> GetAllVwCtacteproveedor(string conditions, string orders);
        VwCtacteproveedor GetVwCtacteproveedor(int id);
        VwCtacteproveedor GetVwCtacteproveedor(Expression<Func<VwCtacteproveedor, bool>> criteria);

        #endregion

        #endregion

        #region Inntecc

        #region Accesoform service

        long CountAccesoform();
        long CountAccesoform(Expression<Func<Accesoform, bool>> criteria);
        int SaveAccesoform(Accesoform entity);
        void UpdateAccesoform(Accesoform entity);
        void DeleteAccesoform(int id);
        List<Accesoform> GetAllAccesoform();
        List<Accesoform> GetAllAccesoform(Expression<Func<Accesoform, bool>> criteria);
        List<Accesoform> GetAllAccesoform(string orders);
        List<Accesoform> GetAllAccesoform(string conditions, string orders);
        Accesoform GetAccesoform(int id);
        Accesoform GetAccesoform(Expression<Func<Accesoform, bool>> criteria);
        Accesoform GetPermisosForm(int idUsuario, string nameFormMnt);
        #endregion

        #region Area service

        long CountArea();
        long CountArea(Expression<Func<Area, bool>> criteria);
        int SaveArea(Area entity);
        void UpdateArea(Area entity);
        void DeleteArea(int id);
        List<Area> GetAllArea();
        List<Area> GetAllArea(Expression<Func<Area, bool>> criteria);
        List<Area> GetAllArea(string orders);
        List<Area> GetAllArea(string conditions, string orders);
        Area GetArea(int id);
        Area GetArea(Expression<Func<Area, bool>> criteria);
        string GetSiguienteCodigoArea(int idEmpresa);
        bool CodigoAreaExiste(string codigo,int idEmpresa);

        #endregion

        #region Areacentrocostro service

        long CountAreacentrocostro();
        long CountAreacentrocostro(Expression<Func<Areacentrocostro, bool>> criteria);
        int SaveAreacentrocostro(Areacentrocostro entity);
        void UpdateAreacentrocostro(Areacentrocostro entity);
        void DeleteAreacentrocostro(int id);
        List<Areacentrocostro> GetAllAreacentrocostro();
        List<Areacentrocostro> GetAllAreacentrocostro(Expression<Func<Areacentrocostro, bool>> criteria);
        List<Areacentrocostro> GetAllAreacentrocostro(string orders);
        List<Areacentrocostro> GetAllAreacentrocostro(string conditions, string orders);
        Areacentrocostro GetAreacentrocostro(int id);
        Areacentrocostro GetAreacentrocostro(Expression<Func<Areacentrocostro, bool>> criteria);

        #endregion

        #region Articulo service

        long CountArticulo();
        long CountArticulo(Expression<Func<Articulo, bool>> criteria);
        int SaveArticulo(Articulo entity);
        void UpdateArticulo(Articulo entity);
        void DeleteArticulo(int id);
        List<Articulo> GetAllArticulo();
        List<Articulo> GetAllArticulo(Expression<Func<Articulo, bool>> criteria);
        List<Articulo> GetAllArticulo(string orders);
        List<Articulo> GetAllArticulo(string conditions, string orders);
        Articulo GetArticulo(int id);
        Articulo GetArticulo(Expression<Func<Articulo, bool>> criteria);
        string GetSiguienteCodigoArticulo();
        bool CodigoArticuloExiste(string codigo);
        bool CodigoBarraArticuloExiste(string codigoBarra, int idEmpresaSel);
        decimal ObtenerStockAlmacen(int idArticulo, DateTime fechaInicial, DateTime fechaFinal, int? idAlmacen);

        #endregion

        #region Articuloclasificacion service

        long CountArticuloclasificacion();
        long CountArticuloclasificacion(Expression<Func<Articuloclasificacion, bool>> criteria);
        int SaveArticuloclasificacion(Articuloclasificacion entity);
        void UpdateArticuloclasificacion(Articuloclasificacion entity);
        void DeleteArticuloclasificacion(int id);
        List<Articuloclasificacion> GetAllArticuloclasificacion();
        List<Articuloclasificacion> GetAllArticuloclasificacion(Expression<Func<Articuloclasificacion, bool>> criteria);
        List<Articuloclasificacion> GetAllArticuloclasificacion(string orders);
        List<Articuloclasificacion> GetAllArticuloclasificacion(string conditions, string orders);
        Articuloclasificacion GetArticuloclasificacion(int id);
        Articuloclasificacion GetArticuloclasificacion(Expression<Func<Articuloclasificacion, bool>> criteria);
        string GetSiguienteCodigoClasificacionArticulo();
        bool CodigoClasificacionArticuloExiste(string codigo);
        #endregion

        #region Articulodetalleunidad service

        long CountArticulodetalleunidad();
        long CountArticulodetalleunidad(Expression<Func<Articulodetalleunidad, bool>> criteria);
        int SaveArticulodetalleunidad(Articulodetalleunidad entity);
        void UpdateArticulodetalleunidad(Articulodetalleunidad entity);
        void DeleteArticulodetalleunidad(int id);
        List<Articulodetalleunidad> GetAllArticulodetalleunidad();
        List<Articulodetalleunidad> GetAllArticulodetalleunidad(Expression<Func<Articulodetalleunidad, bool>> criteria);
        List<Articulodetalleunidad> GetAllArticulodetalleunidad(string orders);
        List<Articulodetalleunidad> GetAllArticulodetalleunidad(string conditions, string orders);
        Articulodetalleunidad GetArticulodetalleunidad(int id);
        Articulodetalleunidad GetArticulodetalleunidad(Expression<Func<Articulodetalleunidad, bool>> criteria);

        #endregion

        #region Articuloimagen service

        long CountArticuloimagen();
        long CountArticuloimagen(Expression<Func<Articuloimagen, bool>> criteria);
        int SaveArticuloimagen(Articuloimagen entity);
        void UpdateArticuloimagen(Articuloimagen entity);
        void DeleteArticuloimagen(int id);
        List<Articuloimagen> GetAllArticuloimagen();
        List<Articuloimagen> GetAllArticuloimagen(Expression<Func<Articuloimagen, bool>> criteria);
        List<Articuloimagen> GetAllArticuloimagen(string orders);
        List<Articuloimagen> GetAllArticuloimagen(string conditions, string orders);
        Articuloimagen GetArticuloimagen(int id);
        Articuloimagen GetArticuloimagen(Expression<Func<Articuloimagen, bool>> criteria);

        #endregion

        #region Articuloubicacion service

        long CountArticuloubicacion();
        long CountArticuloubicacion(Expression<Func<Articuloubicacion, bool>> criteria);
        int SaveArticuloubicacion(Articuloubicacion entity);
        void UpdateArticuloubicacion(Articuloubicacion entity);
        void DeleteArticuloubicacion(int id);
        List<Articuloubicacion> GetAllArticuloubicacion();
        List<Articuloubicacion> GetAllArticuloubicacion(Expression<Func<Articuloubicacion, bool>> criteria);
        List<Articuloubicacion> GetAllArticuloubicacion(string orders);
        List<Articuloubicacion> GetAllArticuloubicacion(string conditions, string orders);
        Articuloubicacion GetArticuloubicacion(int id);
        Articuloubicacion GetArticuloubicacion(Expression<Func<Articuloubicacion, bool>> criteria);

        #endregion

        #region Centrodecosto service

        long CountCentrodecosto();
        long CountCentrodecosto(Expression<Func<Centrodecosto, bool>> criteria);
        int SaveCentrodecosto(Centrodecosto entity);
        void UpdateCentrodecosto(Centrodecosto entity);
        void DeleteCentrodecosto(int id);
        List<Centrodecosto> GetAllCentrodecosto();
        List<Centrodecosto> GetAllCentrodecosto(Expression<Func<Centrodecosto, bool>> criteria);
        List<Centrodecosto> GetAllCentrodecosto(string orders);
        List<Centrodecosto> GetAllCentrodecosto(string conditions, string orders);
        Centrodecosto GetCentrodecosto(int id);
        Centrodecosto GetCentrodecosto(Expression<Func<Centrodecosto, bool>> criteria);
        string GetSiguienteCodigoCentroDeCosto(int idSucursal);
        bool CodigoCentroDeCostoExiste(string codigo, int idSucursal);

        #endregion

        #region Cptooperacion service

        long CountCptooperacion();
        long CountCptooperacion(Expression<Func<Cptooperacion, bool>> criteria);
        int SaveCptooperacion(Cptooperacion entity);
        void UpdateCptooperacion(Cptooperacion entity);
        void DeleteCptooperacion(int id);
        List<Cptooperacion> GetAllCptooperacion();
        List<Cptooperacion> GetAllCptooperacion(Expression<Func<Cptooperacion, bool>> criteria);
        List<Cptooperacion> GetAllCptooperacion(string orders);
        List<Cptooperacion> GetAllCptooperacion(string conditions, string orders);
        Cptooperacion GetCptooperacion(int id);
        Cptooperacion GetCptooperacion(Expression<Func<Cptooperacion, bool>> criteria);
        string GetSiguienteCodigoCptooperacion();
        bool CodigoCptooperacionExiste(string codigo);
        #endregion

        #region Cuentacontable service

        long CountCuentacontable();
        long CountCuentacontable(Expression<Func<Cuentacontable, bool>> criteria);
        int SaveCuentacontable(Cuentacontable entity);
        void UpdateCuentacontable(Cuentacontable entity);
        void DeleteCuentacontable(int id);
        List<Cuentacontable> GetAllCuentacontable();
        List<Cuentacontable> GetAllCuentacontable(Expression<Func<Cuentacontable, bool>> criteria);
        List<Cuentacontable> GetAllCuentacontable(string orders);
        List<Cuentacontable> GetAllCuentacontable(string conditions, string orders);
        Cuentacontable GetCuentacontable(int id);
        Cuentacontable GetCuentacontable(Expression<Func<Cuentacontable, bool>> criteria);

        #endregion

        #region Departamento service

        long CountDepartamento();
        long CountDepartamento(Expression<Func<Departamento, bool>> criteria);
        int SaveDepartamento(Departamento entity);
        void UpdateDepartamento(Departamento entity);
        void DeleteDepartamento(int id);
        List<Departamento> GetAllDepartamento();
        List<Departamento> GetAllDepartamento(Expression<Func<Departamento, bool>> criteria);
        List<Departamento> GetAllDepartamento(string orders);
        List<Departamento> GetAllDepartamento(string conditions, string orders);
        Departamento GetDepartamento(int id);
        Departamento GetDepartamento(Expression<Func<Departamento, bool>> criteria);

        #endregion

        #region Distrito service

        long CountDistrito();
        long CountDistrito(Expression<Func<Distrito, bool>> criteria);
        int SaveDistrito(Distrito entity);
        void UpdateDistrito(Distrito entity);
        void DeleteDistrito(int id);
        List<Distrito> GetAllDistrito();
        List<Distrito> GetAllDistrito(Expression<Func<Distrito, bool>> criteria);
        List<Distrito> GetAllDistrito(string orders);
        List<Distrito> GetAllDistrito(string conditions, string orders);
        Distrito GetDistrito(int id);
        Distrito GetDistrito(Expression<Func<Distrito, bool>> criteria);

        #endregion

        #region Ejercicio service

        long CountEjercicio();
        long CountEjercicio(Expression<Func<Ejercicio, bool>> criteria);
        int SaveEjercicio(Ejercicio entity);
        void UpdateEjercicio(Ejercicio entity);
        void DeleteEjercicio(int id);
        List<Ejercicio> GetAllEjercicio();
        List<Ejercicio> GetAllEjercicio(Expression<Func<Ejercicio, bool>> criteria);
        List<Ejercicio> GetAllEjercicio(string orders);
        List<Ejercicio> GetAllEjercicio(string conditions, string orders);
        Ejercicio GetEjercicio(int id);
        Ejercicio GetEjercicio(Expression<Func<Ejercicio, bool>> criteria);

        #endregion

        #region Empleado service

        long CountEmpleado();
        long CountEmpleado(Expression<Func<Empleado, bool>> criteria);
        int SaveEmpleado(Empleado entity);
        void UpdateEmpleado(Empleado entity);
        void DeleteEmpleado(int id);
        List<Empleado> GetAllEmpleado();
        List<Empleado> GetAllEmpleado(Expression<Func<Empleado, bool>> criteria);
        List<Empleado> GetAllEmpleado(string orders);
        List<Empleado> GetAllEmpleado(string conditions, string orders);
        Empleado GetEmpleado(int id);
        Empleado GetEmpleado(Expression<Func<Empleado, bool>> criteria);

        #endregion

        #region Empleadoanexo service

        long CountEmpleadoanexo();
        long CountEmpleadoanexo(Expression<Func<Empleadoanexo, bool>> criteria);
        int SaveEmpleadoanexo(Empleadoanexo entity);
        void UpdateEmpleadoanexo(Empleadoanexo entity);
        void DeleteEmpleadoanexo(int id);
        List<Empleadoanexo> GetAllEmpleadoanexo();
        List<Empleadoanexo> GetAllEmpleadoanexo(Expression<Func<Empleadoanexo, bool>> criteria);
        List<Empleadoanexo> GetAllEmpleadoanexo(string orders);
        List<Empleadoanexo> GetAllEmpleadoanexo(string conditions, string orders);
        Empleadoanexo GetEmpleadoanexo(int id);
        Empleadoanexo GetEmpleadoanexo(Expression<Func<Empleadoanexo, bool>> criteria);

        #endregion

        #region Empresa service

        long CountEmpresa();
        long CountEmpresa(Expression<Func<Empresa, bool>> criteria);
        int SaveEmpresa(Empresa entity);
        void UpdateEmpresa(Empresa entity);
        void DeleteEmpresa(int id);
        List<Empresa> GetAllEmpresa();
        List<Empresa> GetAllEmpresa(Expression<Func<Empresa, bool>> criteria);
        List<Empresa> GetAllEmpresa(string orders);
        List<Empresa> GetAllEmpresa(string conditions, string orders);
        Empresa GetEmpresa(int id);
        Empresa GetEmpresa(Expression<Func<Empresa, bool>> criteria);

        #endregion

        #region Entidadfinanciera service

        long CountEntidadfinanciera();
        long CountEntidadfinanciera(Expression<Func<Entidadfinanciera, bool>> criteria);
        int SaveEntidadfinanciera(Entidadfinanciera entity);
        void UpdateEntidadfinanciera(Entidadfinanciera entity);
        void DeleteEntidadfinanciera(int id);
        List<Entidadfinanciera> GetAllEntidadfinanciera();
        List<Entidadfinanciera> GetAllEntidadfinanciera(Expression<Func<Entidadfinanciera, bool>> criteria);
        List<Entidadfinanciera> GetAllEntidadfinanciera(string orders);
        List<Entidadfinanciera> GetAllEntidadfinanciera(string conditions, string orders);
        Entidadfinanciera GetEntidadfinanciera(int id);
        Entidadfinanciera GetEntidadfinanciera(Expression<Func<Entidadfinanciera, bool>> criteria);

        #endregion

        #region Grupousuario service

        long CountGrupousuario();
        long CountGrupousuario(Expression<Func<Grupousuario, bool>> criteria);
        int SaveGrupousuario(Grupousuario entity);
        void UpdateGrupousuario(Grupousuario entity);
        void DeleteGrupousuario(int id);
        List<Grupousuario> GetAllGrupousuario();
        List<Grupousuario> GetAllGrupousuario(Expression<Func<Grupousuario, bool>> criteria);
        List<Grupousuario> GetAllGrupousuario(string orders);
        List<Grupousuario> GetAllGrupousuario(string conditions, string orders);
        Grupousuario GetGrupousuario(int id);
        Grupousuario GetGrupousuario(Expression<Func<Grupousuario, bool>> criteria);

        #endregion

        #region Impuesto service

        long CountImpuesto();
        long CountImpuesto(Expression<Func<Impuesto, bool>> criteria);
        int SaveImpuesto(Impuesto entity);
        void UpdateImpuesto(Impuesto entity);
        void DeleteImpuesto(int id);
        List<Impuesto> GetAllImpuesto();
        List<Impuesto> GetAllImpuesto(Expression<Func<Impuesto, bool>> criteria);
        List<Impuesto> GetAllImpuesto(string orders);
        List<Impuesto> GetAllImpuesto(string conditions, string orders);
        Impuesto GetImpuesto(int id);
        Impuesto GetImpuesto(Expression<Func<Impuesto, bool>> criteria);

        #endregion

        #region Impuestoisc service

        long CountImpuestoisc();
        long CountImpuestoisc(Expression<Func<Impuestoisc, bool>> criteria);
        int SaveImpuestoisc(Impuestoisc entity);
        void UpdateImpuestoisc(Impuestoisc entity);
        void DeleteImpuestoisc(int id);
        List<Impuestoisc> GetAllImpuestoisc();
        List<Impuestoisc> GetAllImpuestoisc(Expression<Func<Impuestoisc, bool>> criteria);
        List<Impuestoisc> GetAllImpuestoisc(string orders);
        List<Impuestoisc> GetAllImpuestoisc(string conditions, string orders);
        Impuestoisc GetImpuestoisc(int id);
        Impuestoisc GetImpuestoisc(Expression<Func<Impuestoisc, bool>> criteria);

        #endregion

        #region Listaprecio service

        long CountListaprecio();
        long CountListaprecio(Expression<Func<Listaprecio, bool>> criteria);
        int SaveListaprecio(Listaprecio entity);
        void UpdateListaprecio(Listaprecio entity);
        void DeleteListaprecio(int id);
        List<Listaprecio> GetAllListaprecio();
        List<Listaprecio> GetAllListaprecio(Expression<Func<Listaprecio, bool>> criteria);
        List<Listaprecio> GetAllListaprecio(string orders);
        List<Listaprecio> GetAllListaprecio(string conditions, string orders);
        Listaprecio GetListaprecio(int id);
        Listaprecio GetListaprecio(Expression<Func<Listaprecio, bool>> criteria);
        int GuardarListaprecio(TipoMantenimiento tipoMantenimiento, Listaprecio listaprecioMnt);

        #endregion

        #region Marca service

        long CountMarca();
        long CountMarca(Expression<Func<Marca, bool>> criteria);
        int SaveMarca(Marca entity);
        void UpdateMarca(Marca entity);
        void DeleteMarca(int id);
        List<Marca> GetAllMarca();
        List<Marca> GetAllMarca(Expression<Func<Marca, bool>> criteria);
        List<Marca> GetAllMarca(string orders);
        List<Marca> GetAllMarca(string conditions, string orders);
        Marca GetMarca(int id);
        Marca GetMarca(Expression<Func<Marca, bool>> criteria);

        #endregion

        #region Periodo service

        long CountPeriodo();
        long CountPeriodo(Expression<Func<Periodo, bool>> criteria);
        int SavePeriodo(Periodo entity);
        void UpdatePeriodo(Periodo entity);
        void DeletePeriodo(int id);
        List<Periodo> GetAllPeriodo();
        List<Periodo> GetAllPeriodo(Expression<Func<Periodo, bool>> criteria);
        List<Periodo> GetAllPeriodo(string orders);
        List<Periodo> GetAllPeriodo(string conditions, string orders);
        Periodo GetPeriodo(int id);
        Periodo GetPeriodo(Expression<Func<Periodo, bool>> criteria);
        int GetIdPeriodo(DateTime fecha);
        #endregion

        #region Persona service

        long CountPersona();
        long CountPersona(Expression<Func<Persona, bool>> criteria);
        int SavePersona(Persona entity);
        void UpdatePersona(Persona entity);
        void DeletePersona(int id);
        List<Persona> GetAllPersona();
        List<Persona> GetAllPersona(Expression<Func<Persona, bool>> criteria);
        List<Persona> GetAllPersona(string orders);
        List<Persona> GetAllPersona(string conditions, string orders);
        Persona GetPersona(int id);
        Persona GetPersona(Expression<Func<Persona, bool>> criteria);
        bool NroDocumentoPersonaExiste(string nroDocumento, int idPersona);
        #endregion

        #region Personacontacto service

        long CountPersonacontacto();
        long CountPersonacontacto(Expression<Func<Personacontacto, bool>> criteria);
        int SavePersonacontacto(Personacontacto entity);
        void UpdatePersonacontacto(Personacontacto entity);
        void DeletePersonacontacto(int id);
        List<Personacontacto> GetAllPersonacontacto();
        List<Personacontacto> GetAllPersonacontacto(Expression<Func<Personacontacto, bool>> criteria);
        List<Personacontacto> GetAllPersonacontacto(string orders);
        List<Personacontacto> GetAllPersonacontacto(string conditions, string orders);
        Personacontacto GetPersonacontacto(int id);
        Personacontacto GetPersonacontacto(Expression<Func<Personacontacto, bool>> criteria);

        #endregion

        #region Prioridad service

        long CountPrioridad();
        long CountPrioridad(Expression<Func<Prioridad, bool>> criteria);
        int SavePrioridad(Prioridad entity);
        void UpdatePrioridad(Prioridad entity);
        void DeletePrioridad(int id);
        List<Prioridad> GetAllPrioridad();
        List<Prioridad> GetAllPrioridad(Expression<Func<Prioridad, bool>> criteria);
        List<Prioridad> GetAllPrioridad(string orders);
        List<Prioridad> GetAllPrioridad(string conditions, string orders);
        Prioridad GetPrioridad(int id);
        Prioridad GetPrioridad(Expression<Func<Prioridad, bool>> criteria);
        string GetSiguienteCodigoPrioridad();
        bool CodigoPrioridadExiste(string codigo);
        #endregion

        #region Provincia service

        long CountProvincia();
        long CountProvincia(Expression<Func<Provincia, bool>> criteria);
        int SaveProvincia(Provincia entity);
        void UpdateProvincia(Provincia entity);
        void DeleteProvincia(int id);
        List<Provincia> GetAllProvincia();
        List<Provincia> GetAllProvincia(Expression<Func<Provincia, bool>> criteria);
        List<Provincia> GetAllProvincia(string orders);
        List<Provincia> GetAllProvincia(string conditions, string orders);
        Provincia GetProvincia(int id);
        Provincia GetProvincia(Expression<Func<Provincia, bool>> criteria);

        #endregion

        #region Proyecto service

        long CountProyecto();
        long CountProyecto(Expression<Func<Proyecto, bool>> criteria);
        int SaveProyecto(Proyecto entity);
        void UpdateProyecto(Proyecto entity);
        void DeleteProyecto(int id);
        List<Proyecto> GetAllProyecto();
        List<Proyecto> GetAllProyecto(Expression<Func<Proyecto, bool>> criteria);
        List<Proyecto> GetAllProyecto(string orders);
        List<Proyecto> GetAllProyecto(string conditions, string orders);
        Proyecto GetProyecto(int id);
        Proyecto GetProyecto(Expression<Func<Proyecto, bool>> criteria);
        string GetSiguienteCodigoProyecto(int idEmpresa);
        bool CodigoProyectoExiste(string codigo, int idEmpresa);


        #endregion

        #region Socionegentidadfinanciera service

        long CountSocionegentidadfinanciera();
        long CountSocionegentidadfinanciera(Expression<Func<Socionegentidadfinanciera, bool>> criteria);
        int SaveSocionegentidadfinanciera(Socionegentidadfinanciera entity);
        void UpdateSocionegentidadfinanciera(Socionegentidadfinanciera entity);
        void DeleteSocionegentidadfinanciera(int id);
        List<Socionegentidadfinanciera> GetAllSocionegentidadfinanciera();
        List<Socionegentidadfinanciera> GetAllSocionegentidadfinanciera(Expression<Func<Socionegentidadfinanciera, bool>> criteria);
        List<Socionegentidadfinanciera> GetAllSocionegentidadfinanciera(string orders);
        List<Socionegentidadfinanciera> GetAllSocionegentidadfinanciera(string conditions, string orders);
        Socionegentidadfinanciera GetSocionegentidadfinanciera(int id);
        Socionegentidadfinanciera GetSocionegentidadfinanciera(Expression<Func<Socionegentidadfinanciera, bool>> criteria);

        #endregion

        #region Socionegocio service

        long CountSocionegocio();
        long CountSocionegocio(Expression<Func<Socionegocio, bool>> criteria);
        int SaveSocionegocio(Socionegocio entity);
        void UpdateSocionegocio(Socionegocio entity);
        void DeleteSocionegocio(int id);
        List<Socionegocio> GetAllSocionegocio();
        List<Socionegocio> GetAllSocionegocio(Expression<Func<Socionegocio, bool>> criteria);
        List<Socionegocio> GetAllSocionegocio(string orders);
        List<Socionegocio> GetAllSocionegocio(string conditions, string orders);
        Socionegocio GetSocionegocio(int id);
        Socionegocio GetSocionegocio(Expression<Func<Socionegocio, bool>> criteria);
        string GetSiguienteCodigoSocioNegocio();
        bool CodigoSocioNegocioExiste(string codigo);
        int GetIdDireccionPrincipal(int idSocioNegocio);
        #endregion

        #region Socionegociocontacto service

        long CountSocionegociocontacto();
        long CountSocionegociocontacto(Expression<Func<Socionegociocontacto, bool>> criteria);
        int SaveSocionegociocontacto(Socionegociocontacto entity);
        void UpdateSocionegociocontacto(Socionegociocontacto entity);
        void DeleteSocionegociocontacto(int id);
        List<Socionegociocontacto> GetAllSocionegociocontacto();
        List<Socionegociocontacto> GetAllSocionegociocontacto(Expression<Func<Socionegociocontacto, bool>> criteria);
        List<Socionegociocontacto> GetAllSocionegociocontacto(string orders);
        List<Socionegociocontacto> GetAllSocionegociocontacto(string conditions, string orders);
        Socionegociocontacto GetSocionegociocontacto(int id);
        Socionegociocontacto GetSocionegociocontacto(Expression<Func<Socionegociocontacto, bool>> criteria);

        #endregion

        #region Socionegociodireccion service

        long CountSocionegociodireccion();
        long CountSocionegociodireccion(Expression<Func<Socionegociodireccion, bool>> criteria);
        int SaveSocionegociodireccion(Socionegociodireccion entity);
        void UpdateSocionegociodireccion(Socionegociodireccion entity);
        void DeleteSocionegociodireccion(int id);
        List<Socionegociodireccion> GetAllSocionegociodireccion();
        List<Socionegociodireccion> GetAllSocionegociodireccion(Expression<Func<Socionegociodireccion, bool>> criteria);
        List<Socionegociodireccion> GetAllSocionegociodireccion(string orders);
        List<Socionegociodireccion> GetAllSocionegociodireccion(string conditions, string orders);
        Socionegociodireccion GetSocionegociodireccion(int id);
        Socionegociodireccion GetSocionegociodireccion(Expression<Func<Socionegociodireccion, bool>> criteria);

        #endregion

        #region Socionegociolimitecredito service

        long CountSocionegociolimitecredito();
        long CountSocionegociolimitecredito(Expression<Func<Socionegociolimitecredito, bool>> criteria);
        int SaveSocionegociolimitecredito(Socionegociolimitecredito entity);
        void UpdateSocionegociolimitecredito(Socionegociolimitecredito entity);
        void DeleteSocionegociolimitecredito(int id);
        List<Socionegociolimitecredito> GetAllSocionegociolimitecredito();
        List<Socionegociolimitecredito> GetAllSocionegociolimitecredito(Expression<Func<Socionegociolimitecredito, bool>> criteria);
        List<Socionegociolimitecredito> GetAllSocionegociolimitecredito(string orders);
        List<Socionegociolimitecredito> GetAllSocionegociolimitecredito(string conditions, string orders);
        Socionegociolimitecredito GetSocionegociolimitecredito(int id);
        Socionegociolimitecredito GetSocionegociolimitecredito(Expression<Func<Socionegociolimitecredito, bool>> criteria);

        #endregion

        #region Socionegocioproyecto service

        long CountSocionegocioproyecto();
        long CountSocionegocioproyecto(Expression<Func<Socionegocioproyecto, bool>> criteria);
        int SaveSocionegocioproyecto(Socionegocioproyecto entity);
        void UpdateSocionegocioproyecto(Socionegocioproyecto entity);
        void DeleteSocionegocioproyecto(int id);
        List<Socionegocioproyecto> GetAllSocionegocioproyecto();
        List<Socionegocioproyecto> GetAllSocionegocioproyecto(Expression<Func<Socionegocioproyecto, bool>> criteria);
        List<Socionegocioproyecto> GetAllSocionegocioproyecto(string orders);
        List<Socionegocioproyecto> GetAllSocionegocioproyecto(string conditions, string orders);
        Socionegocioproyecto GetSocionegocioproyecto(int id);
        Socionegocioproyecto GetSocionegocioproyecto(Expression<Func<Socionegocioproyecto, bool>> criteria);

        #endregion

        #region Sucursal service

        long CountSucursal();
        long CountSucursal(Expression<Func<Sucursal, bool>> criteria);
        int SaveSucursal(Sucursal entity);
        void UpdateSucursal(Sucursal entity);
        void DeleteSucursal(int id);
        List<Sucursal> GetAllSucursal();
        List<Sucursal> GetAllSucursal(Expression<Func<Sucursal, bool>> criteria);
        List<Sucursal> GetAllSucursal(string orders);
        List<Sucursal> GetAllSucursal(string conditions, string orders);
        Sucursal GetSucursal(int id);
        Sucursal GetSucursal(Expression<Func<Sucursal, bool>> criteria);

        #endregion

        #region Tipocondicion service

        long CountTipocondicion();
        long CountTipocondicion(Expression<Func<Tipocondicion, bool>> criteria);
        int SaveTipocondicion(Tipocondicion entity);
        void UpdateTipocondicion(Tipocondicion entity);
        void DeleteTipocondicion(int id);
        List<Tipocondicion> GetAllTipocondicion();
        List<Tipocondicion> GetAllTipocondicion(Expression<Func<Tipocondicion, bool>> criteria);
        List<Tipocondicion> GetAllTipocondicion(string orders);
        List<Tipocondicion> GetAllTipocondicion(string conditions, string orders);
        Tipocondicion GetTipocondicion(int id);
        Tipocondicion GetTipocondicion(Expression<Func<Tipocondicion, bool>> criteria);

        #endregion

        #region Tipocp service

        long CountTipocp();
        long CountTipocp(Expression<Func<Tipocp, bool>> criteria);
        int SaveTipocp(Tipocp entity);
        void UpdateTipocp(Tipocp entity);
        void DeleteTipocp(int id);
        List<Tipocp> GetAllTipocp();
        List<Tipocp> GetAllTipocp(Expression<Func<Tipocp, bool>> criteria);
        List<Tipocp> GetAllTipocp(string orders);
        List<Tipocp> GetAllTipocp(string conditions, string orders);
        Tipocp GetTipocp(int id);
        Tipocp GetTipocp(Expression<Func<Tipocp, bool>> criteria);
        string GetSiguienteCodigoTipoCp();
        bool CodigoTipoCpExiste(string codigotipocp);
        int ObtenerSiguienteCorrelativo(int idtipocp);
        bool ActualizarCorrelativo(int idtipocp, int sgtNumerocorrelativocp);

        #endregion

        #region Tipocppago service

        long CountTipocppago();
        long CountTipocppago(Expression<Func<Tipocppago, bool>> criteria);
        int SaveTipocppago(Tipocppago entity);
        void UpdateTipocppago(Tipocppago entity);
        void DeleteTipocppago(int id);
        List<Tipocppago> GetAllTipocppago();
        List<Tipocppago> GetAllTipocppago(Expression<Func<Tipocppago, bool>> criteria);
        List<Tipocppago> GetAllTipocppago(string orders);
        List<Tipocppago> GetAllTipocppago(string conditions, string orders);
        Tipocppago GetTipocppago(int id);
        Tipocppago GetTipocppago(Expression<Func<Tipocppago, bool>> criteria);

        #endregion

        #region Tipodocentidad service

        long CountTipodocentidad();
        long CountTipodocentidad(Expression<Func<Tipodocentidad, bool>> criteria);
        int SaveTipodocentidad(Tipodocentidad entity);
        void UpdateTipodocentidad(Tipodocentidad entity);
        void DeleteTipodocentidad(int id);
        List<Tipodocentidad> GetAllTipodocentidad();
        List<Tipodocentidad> GetAllTipodocentidad(Expression<Func<Tipodocentidad, bool>> criteria);
        List<Tipodocentidad> GetAllTipodocentidad(string orders);
        List<Tipodocentidad> GetAllTipodocentidad(string conditions, string orders);
        Tipodocentidad GetTipodocentidad(int id);
        Tipodocentidad GetTipodocentidad(Expression<Func<Tipodocentidad, bool>> criteria);

        #endregion

        #region Tipoformato service

        long CountTipoformato();
        long CountTipoformato(Expression<Func<Tipoformato, bool>> criteria);
        int SaveTipoformato(Tipoformato entity);
        void UpdateTipoformato(Tipoformato entity);
        void DeleteTipoformato(int id);
        List<Tipoformato> GetAllTipoformato();
        List<Tipoformato> GetAllTipoformato(Expression<Func<Tipoformato, bool>> criteria);
        List<Tipoformato> GetAllTipoformato(string orders);
        List<Tipoformato> GetAllTipoformato(string conditions, string orders);
        Tipoformato GetTipoformato(int id);
        Tipoformato GetTipoformato(Expression<Func<Tipoformato, bool>> criteria);

        #endregion

        #region Tipolista service

        long CountTipolista();
        long CountTipolista(Expression<Func<Tipolista, bool>> criteria);
        int SaveTipolista(Tipolista entity);
        void UpdateTipolista(Tipolista entity);
        void DeleteTipolista(int id);
        List<Tipolista> GetAllTipolista();
        List<Tipolista> GetAllTipolista(Expression<Func<Tipolista, bool>> criteria);
        List<Tipolista> GetAllTipolista(string orders);
        List<Tipolista> GetAllTipolista(string conditions, string orders);
        Tipolista GetTipolista(int id);
        Tipolista GetTipolista(Expression<Func<Tipolista, bool>> criteria);

        #endregion

        #region Tipomediopago service

        long CountTipomediopago();
        long CountTipomediopago(Expression<Func<Tipomediopago, bool>> criteria);
        int SaveTipomediopago(Tipomediopago entity);
        void UpdateTipomediopago(Tipomediopago entity);
        void DeleteTipomediopago(int id);
        List<Tipomediopago> GetAllTipomediopago();
        List<Tipomediopago> GetAllTipomediopago(Expression<Func<Tipomediopago, bool>> criteria);
        List<Tipomediopago> GetAllTipomediopago(string orders);
        List<Tipomediopago> GetAllTipomediopago(string conditions, string orders);
        Tipomediopago GetTipomediopago(int id);
        Tipomediopago GetTipomediopago(Expression<Func<Tipomediopago, bool>> criteria);
        string GetSiguienteCodigoMedioPago();
        bool CodigoCodigoMedioPagoExiste(string codigo);

        #endregion

        #region Tipomoneda service

        long CountTipomoneda();
        long CountTipomoneda(Expression<Func<Tipomoneda, bool>> criteria);
        int SaveTipomoneda(Tipomoneda entity);
        void UpdateTipomoneda(Tipomoneda entity);
        void DeleteTipomoneda(int id);
        List<Tipomoneda> GetAllTipomoneda();
        List<Tipomoneda> GetAllTipomoneda(Expression<Func<Tipomoneda, bool>> criteria);
        List<Tipomoneda> GetAllTipomoneda(string orders);
        List<Tipomoneda> GetAllTipomoneda(string conditions, string orders);
        Tipomoneda GetTipomoneda(int id);
        Tipomoneda GetTipomoneda(Expression<Func<Tipomoneda, bool>> criteria);

        #endregion

        #region Tipooperacion service

        long CountTipooperacion();
        long CountTipooperacion(Expression<Func<Tipooperacion, bool>> criteria);
        int SaveTipooperacion(Tipooperacion entity);
        void UpdateTipooperacion(Tipooperacion entity);
        void DeleteTipooperacion(int id);
        List<Tipooperacion> GetAllTipooperacion();
        List<Tipooperacion> GetAllTipooperacion(Expression<Func<Tipooperacion, bool>> criteria);
        List<Tipooperacion> GetAllTipooperacion(string orders);
        List<Tipooperacion> GetAllTipooperacion(string conditions, string orders);
        Tipooperacion GetTipooperacion(int id);
        Tipooperacion GetTipooperacion(Expression<Func<Tipooperacion, bool>> criteria);

        #endregion

        #region Tiposcontacto service

        long CountTiposcontacto();
        long CountTiposcontacto(Expression<Func<Tiposcontacto, bool>> criteria);
        int SaveTiposcontacto(Tiposcontacto entity);
        void UpdateTiposcontacto(Tiposcontacto entity);
        void DeleteTiposcontacto(int id);
        List<Tiposcontacto> GetAllTiposcontacto();
        List<Tiposcontacto> GetAllTiposcontacto(Expression<Func<Tiposcontacto, bool>> criteria);
        List<Tiposcontacto> GetAllTiposcontacto(string orders);
        List<Tiposcontacto> GetAllTiposcontacto(string conditions, string orders);
        Tiposcontacto GetTiposcontacto(int id);
        Tiposcontacto GetTiposcontacto(Expression<Func<Tiposcontacto, bool>> criteria);

        #endregion

        #region Tiposocio service

        long CountTiposocio();
        long CountTiposocio(Expression<Func<Tiposocio, bool>> criteria);
        int SaveTiposocio(Tiposocio entity);
        void UpdateTiposocio(Tiposocio entity);
        void DeleteTiposocio(int id);
        List<Tiposocio> GetAllTiposocio();
        List<Tiposocio> GetAllTiposocio(Expression<Func<Tiposocio, bool>> criteria);
        List<Tiposocio> GetAllTiposocio(string orders);
        List<Tiposocio> GetAllTiposocio(string conditions, string orders);
        Tiposocio GetTiposocio(int id);
        Tiposocio GetTiposocio(Expression<Func<Tiposocio, bool>> criteria);

        #endregion

        #region Unidadmedida service

        long CountUnidadmedida();
        long CountUnidadmedida(Expression<Func<Unidadmedida, bool>> criteria);
        int SaveUnidadmedida(Unidadmedida entity);
        void UpdateUnidadmedida(Unidadmedida entity);
        void DeleteUnidadmedida(int id);
        List<Unidadmedida> GetAllUnidadmedida();
        List<Unidadmedida> GetAllUnidadmedida(Expression<Func<Unidadmedida, bool>> criteria);
        List<Unidadmedida> GetAllUnidadmedida(string orders);
        List<Unidadmedida> GetAllUnidadmedida(string conditions, string orders);
        Unidadmedida GetUnidadmedida(int id);
        Unidadmedida GetUnidadmedida(Expression<Func<Unidadmedida, bool>> criteria);
        string GetSiguienteCodigoUnidadDeMedida();
        bool CodigoUnidadDeMedidaExiste(string codigo);


        #endregion

        #region Usuario service

        long CountUsuario();
        long CountUsuario(Expression<Func<Usuario, bool>> criteria);
        int SaveUsuario(Usuario entity);
        void UpdateUsuario(Usuario entity);
        void DeleteUsuario(int id);
        List<Usuario> GetAllUsuario();
        List<Usuario> GetAllUsuario(Expression<Func<Usuario, bool>> criteria);
        List<Usuario> GetAllUsuario(string orders);
        List<Usuario> GetAllUsuario(string conditions, string orders);
        Usuario GetUsuario(int id);
        Usuario GetUsuario(Expression<Func<Usuario, bool>> criteria);
        bool ContraseniaValida(string contraseniaUsuario, string contraseniaIngresada);
        #endregion

        #region VwPersona service

        List<VwPersona> GetAllVwPersona();
        List<VwPersona> GetAllVwPersona(Expression<Func<VwPersona, bool>> criteria);
        List<VwPersona> GetAllVwPersona(string orders);
        List<VwPersona> GetAllVwPersona(string conditions, string orders);
        VwPersona GetVwPersona(int id);
        VwPersona GetVwPersona(Expression<Func<VwPersona, bool>> criteria);

        #endregion

        #region VwSucursal service

        List<VwSucursal> GetAllVwSucursal();
        List<VwSucursal> GetAllVwSucursal(Expression<Func<VwSucursal, bool>> criteria);
        List<VwSucursal> GetAllVwSucursal(string orders);
        List<VwSucursal> GetAllVwSucursal(string conditions, string orders);
        VwSucursal GetVwSucursal(int id);
        VwSucursal GetVwSucursal(Expression<Func<VwSucursal, bool>> criteria);

        #endregion

        #region VwTipocp service

        long CountVwTipocp();
        List<VwTipocp> GetAllVwTipocp();
        List<VwTipocp> GetAllVwTipocp(Expression<Func<VwTipocp, bool>> criteria);
        List<VwTipocp> GetAllVwTipocp(string orders);
        List<VwTipocp> GetAllVwTipocp(string conditions, string orders);
        VwTipocp GetVwTipocp(int id);
        VwTipocp GetVwTipocp(Expression<Func<VwTipocp, bool>> criteria);

        #endregion

        #region VwUbigeo service

        List<VwUbigeo> GetAllVwUbigeo();
        List<VwUbigeo> GetAllVwUbigeo(Expression<Func<VwUbigeo, bool>> criteria);
        List<VwUbigeo> GetAllVwUbigeo(string orders);
        List<VwUbigeo> GetAllVwUbigeo(string conditions, string orders);
        VwUbigeo GetVwUbigeo(int id);
        VwUbigeo GetVwUbigeo(Expression<Func<VwUbigeo, bool>> criteria);

        #endregion

        #region VwArea service

        long CountVwArea();
        long CountVwArea(Expression<Func<VwArea, bool>> criteria);
        List<VwArea> GetAllVwArea();
        List<VwArea> GetAllVwArea(Expression<Func<VwArea, bool>> criteria);
        List<VwArea> GetAllVwArea(string orders);
        List<VwArea> GetAllVwArea(string conditions, string orders);
        VwArea GetVwArea(int id);
        VwArea GetVwArea(Expression<Func<VwArea, bool>> criteria);

        #endregion

        #region VwPersonacontacto service

        long CountVwPersonacontacto();
        long CountVwPersonacontacto(Expression<Func<VwPersonacontacto, bool>> criteria);
        List<VwPersonacontacto> GetAllVwPersonacontacto();
        List<VwPersonacontacto> GetAllVwPersonacontacto(Expression<Func<VwPersonacontacto, bool>> criteria);
        List<VwPersonacontacto> GetAllVwPersonacontacto(string orders);
        List<VwPersonacontacto> GetAllVwPersonacontacto(string conditions, string orders);
        VwPersonacontacto GetVwPersonacontacto(int id);
        VwPersonacontacto GetVwPersonacontacto(Expression<Func<VwPersonacontacto, bool>> criteria);

        #endregion

        #region VwSocionegocio service

        long CountVwSocionegocio();
        long CountVwSocionegocio(Expression<Func<VwSocionegocio, bool>> criteria);
        List<VwSocionegocio> GetAllVwSocionegocio();
        List<VwSocionegocio> GetAllVwSocionegocio(Expression<Func<VwSocionegocio, bool>> criteria);
        List<VwSocionegocio> GetAllVwSocionegocio(string orders);
        List<VwSocionegocio> GetAllVwSocionegocio(string conditions, string orders);
        VwSocionegocio GetVwSocionegocio(int id);
        VwSocionegocio GetVwSocionegocio(Expression<Func<VwSocionegocio, bool>> criteria);

        #endregion

        #region VwEmpleado service

        long CountVwEmpleado();
        long CountVwEmpleado(Expression<Func<VwEmpleado, bool>> criteria);
        List<VwEmpleado> GetAllVwEmpleado();
        List<VwEmpleado> GetAllVwEmpleado(Expression<Func<VwEmpleado, bool>> criteria);
        List<VwEmpleado> GetAllVwEmpleado(string orders);
        List<VwEmpleado> GetAllVwEmpleado(string conditions, string orders);
        VwEmpleado GetVwEmpleado(int id);
        VwEmpleado GetVwEmpleado(Expression<Func<VwEmpleado, bool>> criteria);

        #endregion

        #region VwListaprecio service

        long CountVwListaprecio();
        long CountVwListaprecio(Expression<Func<VwListaprecio, bool>> criteria);
        List<VwListaprecio> GetAllVwListaprecio();
        List<VwListaprecio> GetAllVwListaprecio(Expression<Func<VwListaprecio, bool>> criteria);
        List<VwListaprecio> GetAllVwListaprecio(string orders);
        List<VwListaprecio> GetAllVwListaprecio(string conditions, string orders);
        VwListaprecio GetVwListaprecio(int id);
        VwListaprecio GetVwListaprecio(Expression<Func<VwListaprecio, bool>> criteria);

        #endregion

        #region VwArticulo service

        long CountVwArticulo();
        long CountVwArticulo(Expression<Func<VwArticulo, bool>> criteria);
        List<VwArticulo> GetAllVwArticulo();
        List<VwArticulo> GetAllVwArticulo(Expression<Func<VwArticulo, bool>> criteria);
        List<VwArticulo> GetAllVwArticulo(string orders);
        List<VwArticulo> GetAllVwArticulo(string conditions, string orders);
        VwArticulo GetVwArticulo(int id);
        VwArticulo GetVwArticulo(Expression<Func<VwArticulo, bool>> criteria);

        #endregion

        #region VwPeriodo service

        long CountVwPeriodo();
        long CountVwPeriodo(Expression<Func<VwPeriodo, bool>> criteria);
        List<VwPeriodo> GetAllVwPeriodo();
        List<VwPeriodo> GetAllVwPeriodo(Expression<Func<VwPeriodo, bool>> criteria);
        List<VwPeriodo> GetAllVwPeriodo(string orders);
        List<VwPeriodo> GetAllVwPeriodo(string conditions, string orders);
        VwPeriodo GetVwPeriodo(int id);
        VwPeriodo GetVwPeriodo(Expression<Func<VwPeriodo, bool>> criteria);

        #endregion

        #region Tipodocmov service

		long CountTipodocmov();
		long CountTipodocmov(Expression<Func<Tipodocmov, bool>> criteria);
		int SaveTipodocmov(Tipodocmov entity);
		void UpdateTipodocmov(Tipodocmov entity);
		void DeleteTipodocmov(int id);
		List<Tipodocmov> GetAllTipodocmov();
		List<Tipodocmov> GetAllTipodocmov(Expression<Func<Tipodocmov, bool>> criteria);
		List<Tipodocmov> GetAllTipodocmov(string orders);
		List<Tipodocmov> GetAllTipodocmov(string conditions, string orders);
		Tipodocmov GetTipodocmov(int id);
		Tipodocmov GetTipodocmov(Expression<Func<Tipodocmov, bool>> criteria);

        #endregion

        #region VwCptooperacion service

        long CountVwCptooperacion();
        long CountVwCptooperacion(Expression<Func<VwCptooperacion, bool>> criteria);
        List<VwCptooperacion> GetAllVwCptooperacion();
        List<VwCptooperacion> GetAllVwCptooperacion(Expression<Func<VwCptooperacion, bool>> criteria);
        List<VwCptooperacion> GetAllVwCptooperacion(string orders);
        List<VwCptooperacion> GetAllVwCptooperacion(string conditions, string orders);
        VwCptooperacion GetVwCptooperacion(int id);
        VwCptooperacion GetVwCptooperacion(Expression<Func<VwCptooperacion, bool>> criteria);

        #endregion

        #region VwUsuario service

        long CountVwUsuario();
        long CountVwUsuario(Expression<Func<VwUsuario, bool>> criteria);
        List<VwUsuario> GetAllVwUsuario();
        List<VwUsuario> GetAllVwUsuario(Expression<Func<VwUsuario, bool>> criteria);
        List<VwUsuario> GetAllVwUsuario(string orders);
        List<VwUsuario> GetAllVwUsuario(string conditions, string orders);
        VwUsuario GetVwUsuario(int id);
        VwUsuario GetVwUsuario(Expression<Func<VwUsuario, bool>> criteria);

        #endregion

        #region VwProyecto service

        long CountVwProyecto();
        long CountVwProyecto(Expression<Func<VwProyecto, bool>> criteria);
        List<VwProyecto> GetAllVwProyecto();
        List<VwProyecto> GetAllVwProyecto(Expression<Func<VwProyecto, bool>> criteria);
        List<VwProyecto> GetAllVwProyecto(string orders);
        List<VwProyecto> GetAllVwProyecto(string conditions, string orders);
        VwProyecto GetVwProyecto(int id);
        VwProyecto GetVwProyecto(Expression<Func<VwProyecto, bool>> criteria);

        #endregion

        #region VwArticulodetalleunidad service

        long CountVwArticulodetalleunidad();
        long CountVwArticulodetalleunidad(Expression<Func<VwArticulodetalleunidad, bool>> criteria);
        List<VwArticulodetalleunidad> GetAllVwArticulodetalleunidad();
        List<VwArticulodetalleunidad> GetAllVwArticulodetalleunidad(Expression<Func<VwArticulodetalleunidad, bool>> criteria);
        List<VwArticulodetalleunidad> GetAllVwArticulodetalleunidad(string orders);
        List<VwArticulodetalleunidad> GetAllVwArticulodetalleunidad(string conditions, string orders);
        VwArticulodetalleunidad GetVwArticulodetalleunidad(int id);
        VwArticulodetalleunidad GetVwArticulodetalleunidad(Expression<Func<VwArticulodetalleunidad, bool>> criteria);

        #endregion

        #region VwArticuloubicacion service

        long CountVwArticuloubicacion();
        long CountVwArticuloubicacion(Expression<Func<VwArticuloubicacion, bool>> criteria);
        List<VwArticuloubicacion> GetAllVwArticuloubicacion();
        List<VwArticuloubicacion> GetAllVwArticuloubicacion(Expression<Func<VwArticuloubicacion, bool>> criteria);
        List<VwArticuloubicacion> GetAllVwArticuloubicacion(string orders);
        List<VwArticuloubicacion> GetAllVwArticuloubicacion(string conditions, string orders);
        VwArticuloubicacion GetVwArticuloubicacion(int id);
        VwArticuloubicacion GetVwArticuloubicacion(Expression<Func<VwArticuloubicacion, bool>> criteria);

        #endregion

        #region Empleadoarea service

        long CountEmpleadoarea();
        long CountEmpleadoarea(Expression<Func<Empleadoarea, bool>> criteria);
        int SaveEmpleadoarea(Empleadoarea entity);
        void UpdateEmpleadoarea(Empleadoarea entity);
        void DeleteEmpleadoarea(int id);
        List<Empleadoarea> GetAllEmpleadoarea();
        List<Empleadoarea> GetAllEmpleadoarea(Expression<Func<Empleadoarea, bool>> criteria);
        List<Empleadoarea> GetAllEmpleadoarea(string orders);
        List<Empleadoarea> GetAllEmpleadoarea(string conditions, string orders);
        Empleadoarea GetEmpleadoarea(int id);
        Empleadoarea GetEmpleadoarea(Expression<Func<Empleadoarea, bool>> criteria);

        #endregion

        #region Empleadoareaproyecto service

        long CountEmpleadoareaproyecto();
        long CountEmpleadoareaproyecto(Expression<Func<Empleadoareaproyecto, bool>> criteria);
        int SaveEmpleadoareaproyecto(Empleadoareaproyecto entity);
        void UpdateEmpleadoareaproyecto(Empleadoareaproyecto entity);
        void DeleteEmpleadoareaproyecto(int id);
        List<Empleadoareaproyecto> GetAllEmpleadoareaproyecto();
        List<Empleadoareaproyecto> GetAllEmpleadoareaproyecto(Expression<Func<Empleadoareaproyecto, bool>> criteria);
        List<Empleadoareaproyecto> GetAllEmpleadoareaproyecto(string orders);
        List<Empleadoareaproyecto> GetAllEmpleadoareaproyecto(string conditions, string orders);
        Empleadoareaproyecto GetEmpleadoareaproyecto(int id);
        Empleadoareaproyecto GetEmpleadoareaproyecto(Expression<Func<Empleadoareaproyecto, bool>> criteria);

        #endregion

        #region VwEmpleadoarea service

        long CountVwEmpleadoarea();
        long CountVwEmpleadoarea(Expression<Func<VwEmpleadoarea, bool>> criteria);
        List<VwEmpleadoarea> GetAllVwEmpleadoarea();
        List<VwEmpleadoarea> GetAllVwEmpleadoarea(Expression<Func<VwEmpleadoarea, bool>> criteria);
        List<VwEmpleadoarea> GetAllVwEmpleadoarea(string orders);
        List<VwEmpleadoarea> GetAllVwEmpleadoarea(string conditions, string orders);
        VwEmpleadoarea GetVwEmpleadoarea(int id);
        VwEmpleadoarea GetVwEmpleadoarea(Expression<Func<VwEmpleadoarea, bool>> criteria);

        #endregion

        #region VwEmpleadoareaproyecto service

        long CountVwEmpleadoareaproyecto();
        long CountVwEmpleadoareaproyecto(Expression<Func<VwEmpleadoareaproyecto, bool>> criteria);
        List<VwEmpleadoareaproyecto> GetAllVwEmpleadoareaproyecto();
        List<VwEmpleadoareaproyecto> GetAllVwEmpleadoareaproyecto(Expression<Func<VwEmpleadoareaproyecto, bool>> criteria);
        List<VwEmpleadoareaproyecto> GetAllVwEmpleadoareaproyecto(string orders);
        List<VwEmpleadoareaproyecto> GetAllVwEmpleadoareaproyecto(string conditions, string orders);
        VwEmpleadoareaproyecto GetVwEmpleadoareaproyecto(int id);
        VwEmpleadoareaproyecto GetVwEmpleadoareaproyecto(Expression<Func<VwEmpleadoareaproyecto, bool>> criteria);

        #endregion

        #region Valorpordefecto service

        long CountValorpordefecto();
        long CountValorpordefecto(Expression<Func<Valorpordefecto, bool>> criteria);
        int SaveValorpordefecto(Valorpordefecto entity);
        void UpdateValorpordefecto(Valorpordefecto entity);
        void DeleteValorpordefecto(int id);
        List<Valorpordefecto> GetAllValorpordefecto();
        List<Valorpordefecto> GetAllValorpordefecto(Expression<Func<Valorpordefecto, bool>> criteria);
        List<Valorpordefecto> GetAllValorpordefecto(string orders);
        List<Valorpordefecto> GetAllValorpordefecto(string conditions, string orders);
        Valorpordefecto GetValorpordefecto(int id);
        Valorpordefecto GetValorpordefecto(Expression<Func<Valorpordefecto, bool>> criteria);
        Valorpordefecto ObtenerObjectoValoresPorDefecto(int idSucursal, int idEmpleado, string nombreTipodocMov);
        bool RegistrarObjectoValoresPorDefecto(int idSucursal, int idEmpleado, string nombreTipodocMov, int idTipoCpPorDefecto, int idCptoOperacionPorDefecto);
        #endregion

        #region VwAccesoform service

        long CountVwAccesoform();
        long CountVwAccesoform(Expression<Func<VwAccesoform, bool>> criteria);
        List<VwAccesoform> GetAllVwAccesoform();
        List<VwAccesoform> GetAllVwAccesoform(Expression<Func<VwAccesoform, bool>> criteria);
        List<VwAccesoform> GetAllVwAccesoform(string orders);
        List<VwAccesoform> GetAllVwAccesoform(string conditions, string orders);
        VwAccesoform GetVwAccesoform(int id);
        VwAccesoform GetVwAccesoform(Expression<Func<VwAccesoform, bool>> criteria);

        #endregion

        #region VwGrupousuarioitem service

        long CountVwGrupousuarioitem();
        long CountVwGrupousuarioitem(Expression<Func<VwGrupousuarioitem, bool>> criteria);
        List<VwGrupousuarioitem> GetAllVwGrupousuarioitem();
        List<VwGrupousuarioitem> GetAllVwGrupousuarioitem(Expression<Func<VwGrupousuarioitem, bool>> criteria);
        List<VwGrupousuarioitem> GetAllVwGrupousuarioitem(string orders);
        List<VwGrupousuarioitem> GetAllVwGrupousuarioitem(string conditions, string orders);
        VwGrupousuarioitem GetVwGrupousuarioitem(int id);
        VwGrupousuarioitem GetVwGrupousuarioitem(Expression<Func<VwGrupousuarioitem, bool>> criteria);

        #endregion

        #region VwPaginaitem service

        long CountVwPaginaitem();
        long CountVwPaginaitem(Expression<Func<VwPaginaitem, bool>> criteria);
        List<VwPaginaitem> GetAllVwPaginaitem();
        List<VwPaginaitem> GetAllVwPaginaitem(Expression<Func<VwPaginaitem, bool>> criteria);
        List<VwPaginaitem> GetAllVwPaginaitem(string orders);
        List<VwPaginaitem> GetAllVwPaginaitem(string conditions, string orders);
        VwPaginaitem GetVwPaginaitem(int id);
        VwPaginaitem GetVwPaginaitem(Expression<Func<VwPaginaitem, bool>> criteria);

        #endregion

        #region Grupousuarioitem service

        long CountGrupousuarioitem();
        long CountGrupousuarioitem(Expression<Func<Grupousuarioitem, bool>> criteria);
        int SaveGrupousuarioitem(Grupousuarioitem entity);
        void UpdateGrupousuarioitem(Grupousuarioitem entity);
        void DeleteGrupousuarioitem(int id);
        List<Grupousuarioitem> GetAllGrupousuarioitem();
        List<Grupousuarioitem> GetAllGrupousuarioitem(Expression<Func<Grupousuarioitem, bool>> criteria);
        List<Grupousuarioitem> GetAllGrupousuarioitem(string orders);
        List<Grupousuarioitem> GetAllGrupousuarioitem(string conditions, string orders);
        Grupousuarioitem GetGrupousuarioitem(int id);
        Grupousuarioitem GetGrupousuarioitem(Expression<Func<Grupousuarioitem, bool>> criteria);

        #endregion

        #region VwAccesoopcion service

        long CountVwAccesoopcion();
        long CountVwAccesoopcion(Expression<Func<VwAccesoopcion, bool>> criteria);
        List<VwAccesoopcion> GetAllVwAccesoopcion();
        List<VwAccesoopcion> GetAllVwAccesoopcion(Expression<Func<VwAccesoopcion, bool>> criteria);
        List<VwAccesoopcion> GetAllVwAccesoopcion(string orders);
        List<VwAccesoopcion> GetAllVwAccesoopcion(string conditions, string orders);
        VwAccesoopcion GetVwAccesoopcion(int id);
        VwAccesoopcion GetVwAccesoopcion(Expression<Func<VwAccesoopcion, bool>> criteria);

        #endregion

        #region VwSocionegociodireccion service

        long CountVwSocionegociodireccion();
        long CountVwSocionegociodireccion(Expression<Func<VwSocionegociodireccion, bool>> criteria);
        List<VwSocionegociodireccion> GetAllVwSocionegociodireccion();
        List<VwSocionegociodireccion> GetAllVwSocionegociodireccion(Expression<Func<VwSocionegociodireccion, bool>> criteria);
        List<VwSocionegociodireccion> GetAllVwSocionegociodireccion(string orders);
        List<VwSocionegociodireccion> GetAllVwSocionegociodireccion(string conditions, string orders);
        VwSocionegociodireccion GetVwSocionegociodireccion(int id);
        VwSocionegociodireccion GetVwSocionegociodireccion(Expression<Func<VwSocionegociodireccion, bool>> criteria);

        #endregion

        #region VwSocionegociolimitecredito service

        long CountVwSocionegociolimitecredito();
        long CountVwSocionegociolimitecredito(Expression<Func<VwSocionegociolimitecredito, bool>> criteria);
        List<VwSocionegociolimitecredito> GetAllVwSocionegociolimitecredito();
        List<VwSocionegociolimitecredito> GetAllVwSocionegociolimitecredito(Expression<Func<VwSocionegociolimitecredito, bool>> criteria);
        List<VwSocionegociolimitecredito> GetAllVwSocionegociolimitecredito(string orders);
        List<VwSocionegociolimitecredito> GetAllVwSocionegociolimitecredito(string conditions, string orders);
        VwSocionegociolimitecredito GetVwSocionegociolimitecredito(int id);
        VwSocionegociolimitecredito GetVwSocionegociolimitecredito(Expression<Func<VwSocionegociolimitecredito, bool>> criteria);

        #endregion

        #region Tipoafectacionigv service

        long CountTipoafectacionigv();
        long CountTipoafectacionigv(Expression<Func<Tipoafectacionigv, bool>> criteria);
        int SaveTipoafectacionigv(Tipoafectacionigv entity);
        void UpdateTipoafectacionigv(Tipoafectacionigv entity);
        void DeleteTipoafectacionigv(int id);
        List<Tipoafectacionigv> GetAllTipoafectacionigv();
        List<Tipoafectacionigv> GetAllTipoafectacionigv(Expression<Func<Tipoafectacionigv, bool>> criteria);
        List<Tipoafectacionigv> GetAllTipoafectacionigv(string orders);
        List<Tipoafectacionigv> GetAllTipoafectacionigv(string conditions, string orders);
        Tipoafectacionigv GetTipoafectacionigv(int id);
        Tipoafectacionigv GetTipoafectacionigv(Expression<Func<Tipoafectacionigv, bool>> criteria);

        #endregion

        #region VwSocionegentidadfinanciera service

        long CountVwSocionegentidadfinanciera();
        long CountVwSocionegentidadfinanciera(Expression<Func<VwSocionegentidadfinanciera, bool>> criteria);
        List<VwSocionegentidadfinanciera> GetAllVwSocionegentidadfinanciera();
        List<VwSocionegentidadfinanciera> GetAllVwSocionegentidadfinanciera(Expression<Func<VwSocionegentidadfinanciera, bool>> criteria);
        List<VwSocionegentidadfinanciera> GetAllVwSocionegentidadfinanciera(string orders);
        List<VwSocionegentidadfinanciera> GetAllVwSocionegentidadfinanciera(string conditions, string orders);
        VwSocionegentidadfinanciera GetVwSocionegentidadfinanciera(int id);
        VwSocionegentidadfinanciera GetVwSocionegentidadfinanciera(Expression<Func<VwSocionegentidadfinanciera, bool>> criteria);

        #endregion

        #region VwSocionegocioproyecto service

        long CountVwSocionegocioproyecto();
        long CountVwSocionegocioproyecto(Expression<Func<VwSocionegocioproyecto, bool>> criteria);
        List<VwSocionegocioproyecto> GetAllVwSocionegocioproyecto();
        List<VwSocionegocioproyecto> GetAllVwSocionegocioproyecto(Expression<Func<VwSocionegocioproyecto, bool>> criteria);
        List<VwSocionegocioproyecto> GetAllVwSocionegocioproyecto(string orders);
        List<VwSocionegocioproyecto> GetAllVwSocionegocioproyecto(string conditions, string orders);
        VwSocionegocioproyecto GetVwSocionegocioproyecto(int id);
        VwSocionegocioproyecto GetVwSocionegocioproyecto(Expression<Func<VwSocionegocioproyecto, bool>> criteria);

        #endregion

        #region VwCentrodecosto service

        long CountVwCentrodecosto();
        long CountVwCentrodecosto(Expression<Func<VwCentrodecosto, bool>> criteria);
        List<VwCentrodecosto> GetAllVwCentrodecosto();
        List<VwCentrodecosto> GetAllVwCentrodecosto(Expression<Func<VwCentrodecosto, bool>> criteria);
        List<VwCentrodecosto> GetAllVwCentrodecosto(string orders);
        List<VwCentrodecosto> GetAllVwCentrodecosto(string conditions, string orders);
        VwCentrodecosto GetVwCentrodecosto(int id);
        VwCentrodecosto GetVwCentrodecosto(Expression<Func<VwCentrodecosto, bool>> criteria);

        #endregion

        #region Autorizaciontipocondicion service

        long CountAutorizaciontipocondicion();
        long CountAutorizaciontipocondicion(Expression<Func<Autorizaciontipocondicion, bool>> criteria);
        int SaveAutorizaciontipocondicion(Autorizaciontipocondicion entity);
        void UpdateAutorizaciontipocondicion(Autorizaciontipocondicion entity);
        void DeleteAutorizaciontipocondicion(int id);
        List<Autorizaciontipocondicion> GetAllAutorizaciontipocondicion();
        List<Autorizaciontipocondicion> GetAllAutorizaciontipocondicion(Expression<Func<Autorizaciontipocondicion, bool>> criteria);
        List<Autorizaciontipocondicion> GetAllAutorizaciontipocondicion(string orders);
        List<Autorizaciontipocondicion> GetAllAutorizaciontipocondicion(string conditions, string orders);
        Autorizaciontipocondicion GetAutorizaciontipocondicion(int id);
        Autorizaciontipocondicion GetAutorizaciontipocondicion(Expression<Func<Autorizaciontipocondicion, bool>> criteria);

        #endregion

        #region Etapaautorizacion service

        long CountEtapaautorizacion();
        long CountEtapaautorizacion(Expression<Func<Etapaautorizacion, bool>> criteria);
        int SaveEtapaautorizacion(Etapaautorizacion entity);
        void UpdateEtapaautorizacion(Etapaautorizacion entity);
        void DeleteEtapaautorizacion(int id);
        List<Etapaautorizacion> GetAllEtapaautorizacion();
        List<Etapaautorizacion> GetAllEtapaautorizacion(Expression<Func<Etapaautorizacion, bool>> criteria);
        List<Etapaautorizacion> GetAllEtapaautorizacion(string orders);
        List<Etapaautorizacion> GetAllEtapaautorizacion(string conditions, string orders);
        Etapaautorizacion GetEtapaautorizacion(int id);
        Etapaautorizacion GetEtapaautorizacion(Expression<Func<Etapaautorizacion, bool>> criteria);

        #endregion

        #region Etapaautorizaciondetalle service

        long CountEtapaautorizaciondetalle();
        long CountEtapaautorizaciondetalle(Expression<Func<Etapaautorizaciondetalle, bool>> criteria);
        int SaveEtapaautorizaciondetalle(Etapaautorizaciondetalle entity);
        void UpdateEtapaautorizaciondetalle(Etapaautorizaciondetalle entity);
        void DeleteEtapaautorizaciondetalle(int id);
        List<Etapaautorizaciondetalle> GetAllEtapaautorizaciondetalle();
        List<Etapaautorizaciondetalle> GetAllEtapaautorizaciondetalle(Expression<Func<Etapaautorizaciondetalle, bool>> criteria);
        List<Etapaautorizaciondetalle> GetAllEtapaautorizaciondetalle(string orders);
        List<Etapaautorizaciondetalle> GetAllEtapaautorizaciondetalle(string conditions, string orders);
        Etapaautorizaciondetalle GetEtapaautorizaciondetalle(int id);
        Etapaautorizaciondetalle GetEtapaautorizaciondetalle(Expression<Func<Etapaautorizaciondetalle, bool>> criteria);

        #endregion

        #region Modeloautorizacion service

        long CountModeloautorizacion();
        long CountModeloautorizacion(Expression<Func<Modeloautorizacion, bool>> criteria);
        int SaveModeloautorizacion(Modeloautorizacion entity);
        void UpdateModeloautorizacion(Modeloautorizacion entity);
        void DeleteModeloautorizacion(int id);
        List<Modeloautorizacion> GetAllModeloautorizacion();
        List<Modeloautorizacion> GetAllModeloautorizacion(Expression<Func<Modeloautorizacion, bool>> criteria);
        List<Modeloautorizacion> GetAllModeloautorizacion(string orders);
        List<Modeloautorizacion> GetAllModeloautorizacion(string conditions, string orders);
        Modeloautorizacion GetModeloautorizacion(int id);
        Modeloautorizacion GetModeloautorizacion(Expression<Func<Modeloautorizacion, bool>> criteria);

        #endregion

        #region Modeloautorizacioncondicion service

        long CountModeloautorizacioncondicion();
        long CountModeloautorizacioncondicion(Expression<Func<Modeloautorizacioncondicion, bool>> criteria);
        int SaveModeloautorizacioncondicion(Modeloautorizacioncondicion entity);
        void UpdateModeloautorizacioncondicion(Modeloautorizacioncondicion entity);
        void DeleteModeloautorizacioncondicion(int id);
        List<Modeloautorizacioncondicion> GetAllModeloautorizacioncondicion();
        List<Modeloautorizacioncondicion> GetAllModeloautorizacioncondicion(Expression<Func<Modeloautorizacioncondicion, bool>> criteria);
        List<Modeloautorizacioncondicion> GetAllModeloautorizacioncondicion(string orders);
        List<Modeloautorizacioncondicion> GetAllModeloautorizacioncondicion(string conditions, string orders);
        Modeloautorizacioncondicion GetModeloautorizacioncondicion(int id);
        Modeloautorizacioncondicion GetModeloautorizacioncondicion(Expression<Func<Modeloautorizacioncondicion, bool>> criteria);

        #endregion

        #region Modeloautorizacionetapa service

        long CountModeloautorizacionetapa();
        long CountModeloautorizacionetapa(Expression<Func<Modeloautorizacionetapa, bool>> criteria);
        int SaveModeloautorizacionetapa(Modeloautorizacionetapa entity);
        void UpdateModeloautorizacionetapa(Modeloautorizacionetapa entity);
        void DeleteModeloautorizacionetapa(int id);
        List<Modeloautorizacionetapa> GetAllModeloautorizacionetapa();
        List<Modeloautorizacionetapa> GetAllModeloautorizacionetapa(Expression<Func<Modeloautorizacionetapa, bool>> criteria);
        List<Modeloautorizacionetapa> GetAllModeloautorizacionetapa(string orders);
        List<Modeloautorizacionetapa> GetAllModeloautorizacionetapa(string conditions, string orders);
        Modeloautorizacionetapa GetModeloautorizacionetapa(int id);
        Modeloautorizacionetapa GetModeloautorizacionetapa(Expression<Func<Modeloautorizacionetapa, bool>> criteria);

        #endregion

        #region Tiporatio service

        long CountTiporatio();
        long CountTiporatio(Expression<Func<Tiporatio, bool>> criteria);
        int SaveTiporatio(Tiporatio entity);
        void UpdateTiporatio(Tiporatio entity);
        void DeleteTiporatio(int id);
        List<Tiporatio> GetAllTiporatio();
        List<Tiporatio> GetAllTiporatio(Expression<Func<Tiporatio, bool>> criteria);
        List<Tiporatio> GetAllTiporatio(string orders);
        List<Tiporatio> GetAllTiporatio(string conditions, string orders);
        Tiporatio GetTiporatio(int id);
        Tiporatio GetTiporatio(Expression<Func<Tiporatio, bool>> criteria);

        #endregion

        #region VwEtapaautorizacion service

        long CountVwEtapaautorizacion();
        long CountVwEtapaautorizacion(Expression<Func<VwEtapaautorizacion, bool>> criteria);
        List<VwEtapaautorizacion> GetAllVwEtapaautorizacion();
        List<VwEtapaautorizacion> GetAllVwEtapaautorizacion(Expression<Func<VwEtapaautorizacion, bool>> criteria);
        List<VwEtapaautorizacion> GetAllVwEtapaautorizacion(string orders);
        List<VwEtapaautorizacion> GetAllVwEtapaautorizacion(string conditions, string orders);
        VwEtapaautorizacion GetVwEtapaautorizacion(int id);
        VwEtapaautorizacion GetVwEtapaautorizacion(Expression<Func<VwEtapaautorizacion, bool>> criteria);

        #endregion

        #region VwEtapaautorizaciondetalle service

        long CountVwEtapaautorizaciondetalle();
        long CountVwEtapaautorizaciondetalle(Expression<Func<VwEtapaautorizaciondetalle, bool>> criteria);
        List<VwEtapaautorizaciondetalle> GetAllVwEtapaautorizaciondetalle();
        List<VwEtapaautorizaciondetalle> GetAllVwEtapaautorizaciondetalle(Expression<Func<VwEtapaautorizaciondetalle, bool>> criteria);
        List<VwEtapaautorizaciondetalle> GetAllVwEtapaautorizaciondetalle(string orders);
        List<VwEtapaautorizaciondetalle> GetAllVwEtapaautorizaciondetalle(string conditions, string orders);
        VwEtapaautorizaciondetalle GetVwEtapaautorizaciondetalle(int id);
        VwEtapaautorizaciondetalle GetVwEtapaautorizaciondetalle(Expression<Func<VwEtapaautorizaciondetalle, bool>> criteria);

        #endregion

        #region VwModeloautorizacion service

        long CountVwModeloautorizacion();
        long CountVwModeloautorizacion(Expression<Func<VwModeloautorizacion, bool>> criteria);
        List<VwModeloautorizacion> GetAllVwModeloautorizacion();
        List<VwModeloautorizacion> GetAllVwModeloautorizacion(Expression<Func<VwModeloautorizacion, bool>> criteria);
        List<VwModeloautorizacion> GetAllVwModeloautorizacion(string orders);
        List<VwModeloautorizacion> GetAllVwModeloautorizacion(string conditions, string orders);
        VwModeloautorizacion GetVwModeloautorizacion(int id);
        VwModeloautorizacion GetVwModeloautorizacion(Expression<Func<VwModeloautorizacion, bool>> criteria);

        #endregion

        #region VwModeloautorizacioncondicion service

        long CountVwModeloautorizacioncondicion();
        long CountVwModeloautorizacioncondicion(Expression<Func<VwModeloautorizacioncondicion, bool>> criteria);
        List<VwModeloautorizacioncondicion> GetAllVwModeloautorizacioncondicion();
        List<VwModeloautorizacioncondicion> GetAllVwModeloautorizacioncondicion(Expression<Func<VwModeloautorizacioncondicion, bool>> criteria);
        List<VwModeloautorizacioncondicion> GetAllVwModeloautorizacioncondicion(string orders);
        List<VwModeloautorizacioncondicion> GetAllVwModeloautorizacioncondicion(string conditions, string orders);
        VwModeloautorizacioncondicion GetVwModeloautorizacioncondicion(int id);
        VwModeloautorizacioncondicion GetVwModeloautorizacioncondicion(Expression<Func<VwModeloautorizacioncondicion, bool>> criteria);

        #endregion

        #region VwModeloautorizacionetapa service

        long CountVwModeloautorizacionetapa();
        long CountVwModeloautorizacionetapa(Expression<Func<VwModeloautorizacionetapa, bool>> criteria);
        List<VwModeloautorizacionetapa> GetAllVwModeloautorizacionetapa();
        List<VwModeloautorizacionetapa> GetAllVwModeloautorizacionetapa(Expression<Func<VwModeloautorizacionetapa, bool>> criteria);
        List<VwModeloautorizacionetapa> GetAllVwModeloautorizacionetapa(string orders);
        List<VwModeloautorizacionetapa> GetAllVwModeloautorizacionetapa(string conditions, string orders);
        VwModeloautorizacionetapa GetVwModeloautorizacionetapa(int id);
        VwModeloautorizacionetapa GetVwModeloautorizacionetapa(Expression<Func<VwModeloautorizacionetapa, bool>> criteria);

        #endregion

        #region Documentoaprobacion service

        long CountDocumentoaprobacion();
        long CountDocumentoaprobacion(Expression<Func<Documentoaprobacion, bool>> criteria);
        int SaveDocumentoaprobacion(Documentoaprobacion entity);
        void UpdateDocumentoaprobacion(Documentoaprobacion entity);
        void DeleteDocumentoaprobacion(int id);
        List<Documentoaprobacion> GetAllDocumentoaprobacion();
        List<Documentoaprobacion> GetAllDocumentoaprobacion(Expression<Func<Documentoaprobacion, bool>> criteria);
        List<Documentoaprobacion> GetAllDocumentoaprobacion(string orders);
        List<Documentoaprobacion> GetAllDocumentoaprobacion(string conditions, string orders);
        Documentoaprobacion GetDocumentoaprobacion(int id);
        Documentoaprobacion GetDocumentoaprobacion(Expression<Func<Documentoaprobacion, bool>> criteria);
        bool EliminarReferenciasDocumentoAprobacion(int idtipodocmov, int iddocumentomov);
        #endregion

        #region VwModeloautorizacioninfo service
        long CountVwModeloautorizacioninfo();
        long CountVwModeloautorizacioninfo(Expression<Func<VwModeloautorizacioninfo, bool>> criteria);
        List<VwModeloautorizacioninfo> GetAllVwModeloautorizacioninfo();
        List<VwModeloautorizacioninfo> GetAllVwModeloautorizacioninfo(Expression<Func<VwModeloautorizacioninfo, bool>> criteria);
        List<VwModeloautorizacioninfo> GetAllVwModeloautorizacioninfo(string orders);
        List<VwModeloautorizacioninfo> GetAllVwModeloautorizacioninfo(string conditions, string orders);
        VwModeloautorizacioninfo GetVwModeloautorizacioninfo(int id);
        VwModeloautorizacioninfo GetVwModeloautorizacioninfo(Expression<Func<VwModeloautorizacioninfo, bool>> criteria);
        int ObtenerIdEmpleadoApruebaModeloAutorizacion(int idtipodocmov, int idcptooperacion, decimal importeDocumento);
        #endregion

        #region VwDocumentoaprobacion service

        long CountVwDocumentoaprobacion();
        long CountVwDocumentoaprobacion(Expression<Func<VwDocumentoaprobacion, bool>> criteria);
        List<VwDocumentoaprobacion> GetAllVwDocumentoaprobacion();
        List<VwDocumentoaprobacion> GetAllVwDocumentoaprobacion(Expression<Func<VwDocumentoaprobacion, bool>> criteria);
        List<VwDocumentoaprobacion> GetAllVwDocumentoaprobacion(string orders);
        List<VwDocumentoaprobacion> GetAllVwDocumentoaprobacion(string conditions, string orders);
        VwDocumentoaprobacion GetVwDocumentoaprobacion(int id);
        VwDocumentoaprobacion GetVwDocumentoaprobacion(Expression<Func<VwDocumentoaprobacion, bool>> criteria);

        #endregion

        #region Tipoarticulo service

        long CountTipoarticulo();
        long CountTipoarticulo(Expression<Func<Tipoarticulo, bool>> criteria);
        int SaveTipoarticulo(Tipoarticulo entity);
        void UpdateTipoarticulo(Tipoarticulo entity);
        void DeleteTipoarticulo(int id);
        List<Tipoarticulo> GetAllTipoarticulo();
        List<Tipoarticulo> GetAllTipoarticulo(Expression<Func<Tipoarticulo, bool>> criteria);
        List<Tipoarticulo> GetAllTipoarticulo(string orders);
        List<Tipoarticulo> GetAllTipoarticulo(string conditions, string orders);
        Tipoarticulo GetTipoarticulo(int id);
        Tipoarticulo GetTipoarticulo(Expression<Func<Tipoarticulo, bool>> criteria);

        #endregion

        #region Elementogasto service

        long CountElementogasto();
        long CountElementogasto(Expression<Func<Elementogasto, bool>> criteria);
        int SaveElementogasto(Elementogasto entity);
        void UpdateElementogasto(Elementogasto entity);
        void DeleteElementogasto(int id);
        List<Elementogasto> GetAllElementogasto();
        List<Elementogasto> GetAllElementogasto(Expression<Func<Elementogasto, bool>> criteria);
        List<Elementogasto> GetAllElementogasto(string orders);
        List<Elementogasto> GetAllElementogasto(string conditions, string orders);
        Elementogasto GetElementogasto(int id);
        Elementogasto GetElementogasto(Expression<Func<Elementogasto, bool>> criteria);

        #endregion

        #region VwReporteusuario service

        long CountVwReporteusuario();
        long CountVwReporteusuario(Expression<Func<VwReporteusuario, bool>> criteria);
        List<VwReporteusuario> GetAllVwReporteusuario();
        List<VwReporteusuario> GetAllVwReporteusuario(Expression<Func<VwReporteusuario, bool>> criteria);
        List<VwReporteusuario> GetAllVwReporteusuario(string orders);
        List<VwReporteusuario> GetAllVwReporteusuario(string conditions, string orders);
        VwReporteusuario GetVwReporteusuario(int id);
        VwReporteusuario GetVwReporteusuario(Expression<Func<VwReporteusuario, bool>> criteria);

        #endregion

        #region Articulocompuesto service

        long CountArticulocompuesto();
        long CountArticulocompuesto(Expression<Func<Articulocompuesto, bool>> criteria);
        int SaveArticulocompuesto(Articulocompuesto entity);
        void UpdateArticulocompuesto(Articulocompuesto entity);
        void DeleteArticulocompuesto(int id);
        List<Articulocompuesto> GetAllArticulocompuesto();
        List<Articulocompuesto> GetAllArticulocompuesto(Expression<Func<Articulocompuesto, bool>> criteria);
        List<Articulocompuesto> GetAllArticulocompuesto(string orders);
        List<Articulocompuesto> GetAllArticulocompuesto(string conditions, string orders);
        Articulocompuesto GetArticulocompuesto(int id);
        Articulocompuesto GetArticulocompuesto(Expression<Func<Articulocompuesto, bool>> criteria);

        #endregion

        #region VwArticulocompuesto service

        long CountVwArticulocompuesto();
        long CountVwArticulocompuesto(Expression<Func<VwArticulocompuesto, bool>> criteria);
        List<VwArticulocompuesto> GetAllVwArticulocompuesto();
        List<VwArticulocompuesto> GetAllVwArticulocompuesto(Expression<Func<VwArticulocompuesto, bool>> criteria);
        List<VwArticulocompuesto> GetAllVwArticulocompuesto(string orders);
        List<VwArticulocompuesto> GetAllVwArticulocompuesto(string conditions, string orders);
        VwArticulocompuesto GetVwArticulocompuesto(int id);
        VwArticulocompuesto GetVwArticulocompuesto(Expression<Func<VwArticulocompuesto, bool>> criteria);

        #endregion

        #region VwArticuloinventario service

        long CountVwArticuloinventario();
        long CountVwArticuloinventario(Expression<Func<VwArticuloinventario, bool>> criteria);
        List<VwArticuloinventario> GetAllVwArticuloinventario();
        List<VwArticuloinventario> GetAllVwArticuloinventario(Expression<Func<VwArticuloinventario, bool>> criteria);
        List<VwArticuloinventario> GetAllVwArticuloinventario(string orders);
        List<VwArticuloinventario> GetAllVwArticuloinventario(string conditions, string orders);
        VwArticuloinventario GetVwArticuloinventario(int id);
        VwArticuloinventario GetVwArticuloinventario(Expression<Func<VwArticuloinventario, bool>> criteria);

        #endregion

        #region VwArticulounidad service

        long CountVwArticulounidad();
        long CountVwArticulounidad(Expression<Func<VwArticulounidad, bool>> criteria);
        List<VwArticulounidad> GetAllVwArticulounidad();
        List<VwArticulounidad> GetAllVwArticulounidad(Expression<Func<VwArticulounidad, bool>> criteria);
        List<VwArticulounidad> GetAllVwArticulounidad(string orders);
        List<VwArticulounidad> GetAllVwArticulounidad(string conditions, string orders);
        VwArticulounidad GetVwArticulounidad(int id);
        VwArticulounidad GetVwArticulounidad(Expression<Func<VwArticulounidad, bool>> criteria);

        #endregion

        #region Reporte service

        long CountReporte();
        long CountReporte(Expression<Func<Reporte, bool>> criteria);
        int SaveReporte(Reporte entity);
        void UpdateReporte(Reporte entity);
        void DeleteReporte(int id);
        List<Reporte> GetAllReporte();
        List<Reporte> GetAllReporte(Expression<Func<Reporte, bool>> criteria);
        List<Reporte> GetAllReporte(string orders);
        List<Reporte> GetAllReporte(string conditions, string orders);
        Reporte GetReporte(int id);
        Reporte GetReporte(Expression<Func<Reporte, bool>> criteria);

        #endregion

        #region Tipocambio service

        long CountTipocambio();
        long CountTipocambio(Expression<Func<Tipocambio, bool>> criteria);
        int SaveTipocambio(Tipocambio entity);
        void UpdateTipocambio(Tipocambio entity);
        void DeleteTipocambio(int id);
        List<Tipocambio> GetAllTipocambio();
        List<Tipocambio> GetAllTipocambio(Expression<Func<Tipocambio, bool>> criteria);
        List<Tipocambio> GetAllTipocambio(string orders);
        List<Tipocambio> GetAllTipocambio(string conditions, string orders);
        Tipocambio GetTipocambio(int id);
        Tipocambio GetTipocambio(Expression<Func<Tipocambio, bool>> criteria);

        #endregion

        #region VwTipocambio service

        long CountVwTipocambio();
        long CountVwTipocambio(Expression<Func<VwTipocambio, bool>> criteria);
        List<VwTipocambio> GetAllVwTipocambio();
        List<VwTipocambio> GetAllVwTipocambio(Expression<Func<VwTipocambio, bool>> criteria);
        List<VwTipocambio> GetAllVwTipocambio(string orders);
        List<VwTipocambio> GetAllVwTipocambio(string conditions, string orders);
        VwTipocambio GetVwTipocambio(int id);
        VwTipocambio GetVwTipocambio(Expression<Func<VwTipocambio, bool>> criteria);

        #endregion

        #region Tipogestionarticulo service

        long CountTipogestionarticulo();
        long CountTipogestionarticulo(Expression<Func<Tipogestionarticulo, bool>> criteria);
        int SaveTipogestionarticulo(Tipogestionarticulo entity);
        void UpdateTipogestionarticulo(Tipogestionarticulo entity);
        void DeleteTipogestionarticulo(int id);
        List<Tipogestionarticulo> GetAllTipogestionarticulo();
        List<Tipogestionarticulo> GetAllTipogestionarticulo(Expression<Func<Tipogestionarticulo, bool>> criteria);
        List<Tipogestionarticulo> GetAllTipogestionarticulo(string orders);
        List<Tipogestionarticulo> GetAllTipogestionarticulo(string conditions, string orders);
        Tipogestionarticulo GetTipogestionarticulo(int id);
        Tipogestionarticulo GetTipogestionarticulo(Expression<Func<Tipogestionarticulo, bool>> criteria);

        #endregion

        #region Estadoarticulo service

        long CountEstadoarticulo();
        long CountEstadoarticulo(Expression<Func<Estadoarticulo, bool>> criteria);
        int SaveEstadoarticulo(Estadoarticulo entity);
        void UpdateEstadoarticulo(Estadoarticulo entity);
        void DeleteEstadoarticulo(int id);
        List<Estadoarticulo> GetAllEstadoarticulo();
        List<Estadoarticulo> GetAllEstadoarticulo(Expression<Func<Estadoarticulo, bool>> criteria);
        List<Estadoarticulo> GetAllEstadoarticulo(string orders);
        List<Estadoarticulo> GetAllEstadoarticulo(string conditions, string orders);
        Estadoarticulo GetEstadoarticulo(int id);
        Estadoarticulo GetEstadoarticulo(Expression<Func<Estadoarticulo, bool>> criteria);

        #endregion

        #region Categoriasocionegocio service

        long CountCategoriasocionegocio();
        long CountCategoriasocionegocio(Expression<Func<Categoriasocionegocio, bool>> criteria);
        int SaveCategoriasocionegocio(Categoriasocionegocio entity);
        void UpdateCategoriasocionegocio(Categoriasocionegocio entity);
        void DeleteCategoriasocionegocio(int id);
        List<Categoriasocionegocio> GetAllCategoriasocionegocio();
        List<Categoriasocionegocio> GetAllCategoriasocionegocio(Expression<Func<Categoriasocionegocio, bool>> criteria);
        List<Categoriasocionegocio> GetAllCategoriasocionegocio(string orders);
        List<Categoriasocionegocio> GetAllCategoriasocionegocio(string conditions, string orders);
        Categoriasocionegocio GetCategoriasocionegocio(int id);
        Categoriasocionegocio GetCategoriasocionegocio(Expression<Func<Categoriasocionegocio, bool>> criteria);

        #endregion

        #region Grupoeconomico service

        long CountGrupoeconomico();
        long CountGrupoeconomico(Expression<Func<Grupoeconomico, bool>> criteria);
        int SaveGrupoeconomico(Grupoeconomico entity);
        void UpdateGrupoeconomico(Grupoeconomico entity);
        void DeleteGrupoeconomico(int id);
        List<Grupoeconomico> GetAllGrupoeconomico();
        List<Grupoeconomico> GetAllGrupoeconomico(Expression<Func<Grupoeconomico, bool>> criteria);
        List<Grupoeconomico> GetAllGrupoeconomico(string orders);
        List<Grupoeconomico> GetAllGrupoeconomico(string conditions, string orders);
        Grupoeconomico GetGrupoeconomico(int id);
        Grupoeconomico GetGrupoeconomico(Expression<Func<Grupoeconomico, bool>> criteria);

        #endregion

        #region Pais service

        long CountPais();
        long CountPais(Expression<Func<Pais, bool>> criteria);
        int SavePais(Pais entity);
        void UpdatePais(Pais entity);
        void DeletePais(int id);
        List<Pais> GetAllPais();
        List<Pais> GetAllPais(Expression<Func<Pais, bool>> criteria);
        List<Pais> GetAllPais(string orders);
        List<Pais> GetAllPais(string conditions, string orders);
        Pais GetPais(int id);
        Pais GetPais(Expression<Func<Pais, bool>> criteria);

        #endregion

        #region Rubronegocio service

        long CountRubronegocio();
        long CountRubronegocio(Expression<Func<Rubronegocio, bool>> criteria);
        int SaveRubronegocio(Rubronegocio entity);
        void UpdateRubronegocio(Rubronegocio entity);
        void DeleteRubronegocio(int id);
        List<Rubronegocio> GetAllRubronegocio();
        List<Rubronegocio> GetAllRubronegocio(Expression<Func<Rubronegocio, bool>> criteria);
        List<Rubronegocio> GetAllRubronegocio(string orders);
        List<Rubronegocio> GetAllRubronegocio(string conditions, string orders);
        Rubronegocio GetRubronegocio(int id);
        Rubronegocio GetRubronegocio(Expression<Func<Rubronegocio, bool>> criteria);

        #endregion

        #region Socionegociogarantia service

        long CountSocionegociogarantia();
        long CountSocionegociogarantia(Expression<Func<Socionegociogarantia, bool>> criteria);
        int SaveSocionegociogarantia(Socionegociogarantia entity);
        void UpdateSocionegociogarantia(Socionegociogarantia entity);
        void DeleteSocionegociogarantia(int id);
        List<Socionegociogarantia> GetAllSocionegociogarantia();
        List<Socionegociogarantia> GetAllSocionegociogarantia(Expression<Func<Socionegociogarantia, bool>> criteria);
        List<Socionegociogarantia> GetAllSocionegociogarantia(string orders);
        List<Socionegociogarantia> GetAllSocionegociogarantia(string conditions, string orders);
        Socionegociogarantia GetSocionegociogarantia(int id);
        Socionegociogarantia GetSocionegociogarantia(Expression<Func<Socionegociogarantia, bool>> criteria);

        #endregion

        #region Socionegociomarca service

        long CountSocionegociomarca();
        long CountSocionegociomarca(Expression<Func<Socionegociomarca, bool>> criteria);
        int SaveSocionegociomarca(Socionegociomarca entity);
        void UpdateSocionegociomarca(Socionegociomarca entity);
        void DeleteSocionegociomarca(int id);
        List<Socionegociomarca> GetAllSocionegociomarca();
        List<Socionegociomarca> GetAllSocionegociomarca(Expression<Func<Socionegociomarca, bool>> criteria);
        List<Socionegociomarca> GetAllSocionegociomarca(string orders);
        List<Socionegociomarca> GetAllSocionegociomarca(string conditions, string orders);
        Socionegociomarca GetSocionegociomarca(int id);
        Socionegociomarca GetSocionegociomarca(Expression<Func<Socionegociomarca, bool>> criteria);

        #endregion

        #region Tipogarantia service

        long CountTipogarantia();
        long CountTipogarantia(Expression<Func<Tipogarantia, bool>> criteria);
        int SaveTipogarantia(Tipogarantia entity);
        void UpdateTipogarantia(Tipogarantia entity);
        void DeleteTipogarantia(int id);
        List<Tipogarantia> GetAllTipogarantia();
        List<Tipogarantia> GetAllTipogarantia(Expression<Func<Tipogarantia, bool>> criteria);
        List<Tipogarantia> GetAllTipogarantia(string orders);
        List<Tipogarantia> GetAllTipogarantia(string conditions, string orders);
        Tipogarantia GetTipogarantia(int id);
        Tipogarantia GetTipogarantia(Expression<Func<Tipogarantia, bool>> criteria);

        #endregion

        #region VwSocionegociogarantia service

        long CountVwSocionegociogarantia();
        long CountVwSocionegociogarantia(Expression<Func<VwSocionegociogarantia, bool>> criteria);
        List<VwSocionegociogarantia> GetAllVwSocionegociogarantia();
        List<VwSocionegociogarantia> GetAllVwSocionegociogarantia(Expression<Func<VwSocionegociogarantia, bool>> criteria);
        List<VwSocionegociogarantia> GetAllVwSocionegociogarantia(string orders);
        List<VwSocionegociogarantia> GetAllVwSocionegociogarantia(string conditions, string orders);
        VwSocionegociogarantia GetVwSocionegociogarantia(int id);
        VwSocionegociogarantia GetVwSocionegociogarantia(Expression<Func<VwSocionegociogarantia, bool>> criteria);

        #endregion

        #region VwSocionegociomarca service

        long CountVwSocionegociomarca();
        long CountVwSocionegociomarca(Expression<Func<VwSocionegociomarca, bool>> criteria);
        List<VwSocionegociomarca> GetAllVwSocionegociomarca();
        List<VwSocionegociomarca> GetAllVwSocionegociomarca(Expression<Func<VwSocionegociomarca, bool>> criteria);
        List<VwSocionegociomarca> GetAllVwSocionegociomarca(string orders);
        List<VwSocionegociomarca> GetAllVwSocionegociomarca(string conditions, string orders);
        VwSocionegociomarca GetVwSocionegociomarca(int id);
        VwSocionegociomarca GetVwSocionegociomarca(Expression<Func<VwSocionegociomarca, bool>> criteria);

        #endregion

        #region Zona service

        long CountZona();
        long CountZona(Expression<Func<Zona, bool>> criteria);
        int SaveZona(Zona entity);
        void UpdateZona(Zona entity);
        void DeleteZona(int id);
        List<Zona> GetAllZona();
        List<Zona> GetAllZona(Expression<Func<Zona, bool>> criteria);
        List<Zona> GetAllZona(string orders);
        List<Zona> GetAllZona(string conditions, string orders);
        Zona GetZona(int id);
        Zona GetZona(Expression<Func<Zona, bool>> criteria);

        #endregion

        #region Estadosocionegocio service

        long CountEstadosocionegocio();
        long CountEstadosocionegocio(Expression<Func<Estadosocionegocio, bool>> criteria);
        int SaveEstadosocionegocio(Estadosocionegocio entity);
        void UpdateEstadosocionegocio(Estadosocionegocio entity);
        void DeleteEstadosocionegocio(int id);
        List<Estadosocionegocio> GetAllEstadosocionegocio();
        List<Estadosocionegocio> GetAllEstadosocionegocio(Expression<Func<Estadosocionegocio, bool>> criteria);
        List<Estadosocionegocio> GetAllEstadosocionegocio(string orders);
        List<Estadosocionegocio> GetAllEstadosocionegocio(string conditions, string orders);
        Estadosocionegocio GetEstadosocionegocio(int id);
        Estadosocionegocio GetEstadosocionegocio(Expression<Func<Estadosocionegocio, bool>> criteria);

        #endregion

        #region Tipolistatipocondicion service

        long CountTipolistatipocondicion();
        long CountTipolistatipocondicion(Expression<Func<Tipolistatipocondicion, bool>> criteria);
        int SaveTipolistatipocondicion(Tipolistatipocondicion entity);
        void UpdateTipolistatipocondicion(Tipolistatipocondicion entity);
        void DeleteTipolistatipocondicion(int id);
        List<Tipolistatipocondicion> GetAllTipolistatipocondicion();
        List<Tipolistatipocondicion> GetAllTipolistatipocondicion(Expression<Func<Tipolistatipocondicion, bool>> criteria);
        List<Tipolistatipocondicion> GetAllTipolistatipocondicion(string orders);
        List<Tipolistatipocondicion> GetAllTipolistatipocondicion(string conditions, string orders);
        Tipolistatipocondicion GetTipolistatipocondicion(int id);
        Tipolistatipocondicion GetTipolistatipocondicion(Expression<Func<Tipolistatipocondicion, bool>> criteria);

        #endregion

        #region VwTipolistatipocondicion service

        long CountVwTipolistatipocondicion();
        long CountVwTipolistatipocondicion(Expression<Func<VwTipolistatipocondicion, bool>> criteria);
        List<VwTipolistatipocondicion> GetAllVwTipolistatipocondicion();
        List<VwTipolistatipocondicion> GetAllVwTipolistatipocondicion(Expression<Func<VwTipolistatipocondicion, bool>> criteria);
        List<VwTipolistatipocondicion> GetAllVwTipolistatipocondicion(string orders);
        List<VwTipolistatipocondicion> GetAllVwTipolistatipocondicion(string conditions, string orders);
        VwTipolistatipocondicion GetVwTipolistatipocondicion(int id);
        VwTipolistatipocondicion GetVwTipolistatipocondicion(Expression<Func<VwTipolistatipocondicion, bool>> criteria);

        #endregion

        #region VwArticuloclasificacion service

        long CountVwArticuloclasificacion();
        long CountVwArticuloclasificacion(Expression<Func<VwArticuloclasificacion, bool>> criteria);
        List<VwArticuloclasificacion> GetAllVwArticuloclasificacion();
        List<VwArticuloclasificacion> GetAllVwArticuloclasificacion(Expression<Func<VwArticuloclasificacion, bool>> criteria);
        List<VwArticuloclasificacion> GetAllVwArticuloclasificacion(string orders);
        List<VwArticuloclasificacion> GetAllVwArticuloclasificacion(string conditions, string orders);
        VwArticuloclasificacion GetVwArticuloclasificacion(int id);
        VwArticuloclasificacion GetVwArticuloclasificacion(Expression<Func<VwArticuloclasificacion, bool>> criteria);

        #endregion

        #region Estadocivil service

        long CountEstadocivil();
        long CountEstadocivil(Expression<Func<Estadocivil, bool>> criteria);
        int SaveEstadocivil(Estadocivil entity);
        void UpdateEstadocivil(Estadocivil entity);
        void DeleteEstadocivil(int id);
        List<Estadocivil> GetAllEstadocivil();
        List<Estadocivil> GetAllEstadocivil(Expression<Func<Estadocivil, bool>> criteria);
        List<Estadocivil> GetAllEstadocivil(string orders);
        List<Estadocivil> GetAllEstadocivil(string conditions, string orders);
        Estadocivil GetEstadocivil(int id);
        Estadocivil GetEstadocivil(Expression<Func<Estadocivil, bool>> criteria);

        #endregion

        #region Tipocontratoempleado service

        long CountTipocontratoempleado();
        long CountTipocontratoempleado(Expression<Func<Tipocontratoempleado, bool>> criteria);
        int SaveTipocontratoempleado(Tipocontratoempleado entity);
        void UpdateTipocontratoempleado(Tipocontratoempleado entity);
        void DeleteTipocontratoempleado(int id);
        List<Tipocontratoempleado> GetAllTipocontratoempleado();
        List<Tipocontratoempleado> GetAllTipocontratoempleado(Expression<Func<Tipocontratoempleado, bool>> criteria);
        List<Tipocontratoempleado> GetAllTipocontratoempleado(string orders);
        List<Tipocontratoempleado> GetAllTipocontratoempleado(string conditions, string orders);
        Tipocontratoempleado GetTipocontratoempleado(int id);
        Tipocontratoempleado GetTipocontratoempleado(Expression<Func<Tipocontratoempleado, bool>> criteria);

        #endregion

        #region Tiposnp service

        long CountTiposnp();
        long CountTiposnp(Expression<Func<Tiposnp, bool>> criteria);
        int SaveTiposnp(Tiposnp entity);
        void UpdateTiposnp(Tiposnp entity);
        void DeleteTiposnp(int id);
        List<Tiposnp> GetAllTiposnp();
        List<Tiposnp> GetAllTiposnp(Expression<Func<Tiposnp, bool>> criteria);
        List<Tiposnp> GetAllTiposnp(string orders);
        List<Tiposnp> GetAllTiposnp(string conditions, string orders);
        Tiposnp GetTiposnp(int id);
        Tiposnp GetTiposnp(Expression<Func<Tiposnp, bool>> criteria);

        #endregion

        #region Articuloseriedet service

        long CountArticuloseriedet();
        long CountArticuloseriedet(Expression<Func<Articuloseriedet, bool>> criteria);
        int SaveArticuloseriedet(Articuloseriedet entity);
        void UpdateArticuloseriedet(Articuloseriedet entity);
        void DeleteArticuloseriedet(int id);
        List<Articuloseriedet> GetAllArticuloseriedet();
        List<Articuloseriedet> GetAllArticuloseriedet(Expression<Func<Articuloseriedet, bool>> criteria);
        List<Articuloseriedet> GetAllArticuloseriedet(string orders);
        List<Articuloseriedet> GetAllArticuloseriedet(string conditions, string orders);
        Articuloseriedet GetArticuloseriedet(int id);
        Articuloseriedet GetArticuloseriedet(Expression<Func<Articuloseriedet, bool>> criteria);

        #endregion

        #region Seriearticulo service

        long CountSeriearticulo();
        long CountSeriearticulo(Expression<Func<Seriearticulo, bool>> criteria);
        int SaveSeriearticulo(Seriearticulo entity);
        void UpdateSeriearticulo(Seriearticulo entity);
        void DeleteSeriearticulo(int id);
        List<Seriearticulo> GetAllSeriearticulo();
        List<Seriearticulo> GetAllSeriearticulo(Expression<Func<Seriearticulo, bool>> criteria);
        List<Seriearticulo> GetAllSeriearticulo(string orders);
        List<Seriearticulo> GetAllSeriearticulo(string conditions, string orders);
        Seriearticulo GetSeriearticulo(int id);
        Seriearticulo GetSeriearticulo(Expression<Func<Seriearticulo, bool>> criteria);
        bool EstablecerSerieUtilizada(int idseriearticulo, bool serieutilizada);
        bool SerieArticuloExiste(string numeroserieitem);

        #endregion

        #region VwArticuloseriedet service

        long CountVwArticuloseriedet();
        long CountVwArticuloseriedet(Expression<Func<VwArticuloseriedet, bool>> criteria);
        List<VwArticuloseriedet> GetAllVwArticuloseriedet();
        List<VwArticuloseriedet> GetAllVwArticuloseriedet(Expression<Func<VwArticuloseriedet, bool>> criteria);
        List<VwArticuloseriedet> GetAllVwArticuloseriedet(string orders);
        List<VwArticuloseriedet> GetAllVwArticuloseriedet(string conditions, string orders);
        VwArticuloseriedet GetVwArticuloseriedet(int id);
        VwArticuloseriedet GetVwArticuloseriedet(Expression<Func<VwArticuloseriedet, bool>> criteria);

        #endregion

        #region Diaferiado service

        long CountDiaferiado();
        long CountDiaferiado(Expression<Func<Diaferiado, bool>> criteria);
        int SaveDiaferiado(Diaferiado entity);
        void UpdateDiaferiado(Diaferiado entity);
        void DeleteDiaferiado(int id);
        List<Diaferiado> GetAllDiaferiado();
        List<Diaferiado> GetAllDiaferiado(Expression<Func<Diaferiado, bool>> criteria);
        List<Diaferiado> GetAllDiaferiado(string orders);
        List<Diaferiado> GetAllDiaferiado(string conditions, string orders);
        Diaferiado GetDiaferiado(int id);
        Diaferiado GetDiaferiado(Expression<Func<Diaferiado, bool>> criteria);

        #endregion

        #endregion

        #region Ventas

        #region Articulolistaprecio service

        long CountArticulolistaprecio();
        long CountArticulolistaprecio(Expression<Func<Articulolistaprecio, bool>> criteria);
        int SaveArticulolistaprecio(Articulolistaprecio entity);
        void UpdateArticulolistaprecio(Articulolistaprecio entity);
        void DeleteArticulolistaprecio(int id);
        List<Articulolistaprecio> GetAllArticulolistaprecio();
        List<Articulolistaprecio> GetAllArticulolistaprecio(Expression<Func<Articulolistaprecio, bool>> criteria);
        List<Articulolistaprecio> GetAllArticulolistaprecio(string orders);
        List<Articulolistaprecio> GetAllArticulolistaprecio(string conditions, string orders);
        Articulolistaprecio GetArticulolistaprecio(int id);
        Articulolistaprecio GetArticulolistaprecio(Expression<Func<Articulolistaprecio, bool>> criteria);

        #endregion

        #region Cotizacioncliente service

        long CountCotizacioncliente();
        long CountCotizacioncliente(Expression<Func<Cotizacioncliente, bool>> criteria);
        int SaveCotizacioncliente(Cotizacioncliente entity);
        void UpdateCotizacioncliente(Cotizacioncliente entity);
        void DeleteCotizacioncliente(int id);
        List<Cotizacioncliente> GetAllCotizacioncliente();
        List<Cotizacioncliente> GetAllCotizacioncliente(Expression<Func<Cotizacioncliente, bool>> criteria);
        List<Cotizacioncliente> GetAllCotizacioncliente(string orders);
        List<Cotizacioncliente> GetAllCotizacioncliente(string conditions, string orders);
        Cotizacioncliente GetCotizacioncliente(int id);
        Cotizacioncliente GetCotizacioncliente(Expression<Func<Cotizacioncliente, bool>> criteria);
        bool GuardarCotizacionCliente(TipoMantenimiento tipoMantenimiento, Cotizacioncliente entidadCab,List<VwCotizacionclientedet> entidadDetList);
        bool NumeroCotizacionClienteExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        bool CotizacionClienteTieneReferenciaOrdenVenta(int idCotizacioncliente);
        #endregion

        #region Cotizacionclientedet service

        long CountCotizacionclientedet();
        long CountCotizacionclientedet(Expression<Func<Cotizacionclientedet, bool>> criteria);
        int SaveCotizacionclientedet(Cotizacionclientedet entity);
        void UpdateCotizacionclientedet(Cotizacionclientedet entity);
        void DeleteCotizacionclientedet(int id);
        List<Cotizacionclientedet> GetAllCotizacionclientedet();
        List<Cotizacionclientedet> GetAllCotizacionclientedet(Expression<Func<Cotizacionclientedet, bool>> criteria);
        List<Cotizacionclientedet> GetAllCotizacionclientedet(string orders);
        List<Cotizacionclientedet> GetAllCotizacionclientedet(string conditions, string orders);
        Cotizacionclientedet GetCotizacionclientedet(int id);
        Cotizacionclientedet GetCotizacionclientedet(Expression<Func<Cotizacionclientedet, bool>> criteria);

        #endregion

        #region Cpventa service

        long CountCpventa();
        long CountCpventa(Expression<Func<Cpventa, bool>> criteria);
        int SaveCpventa(Cpventa entity);
        void UpdateCpventa(Cpventa entity);
        void DeleteCpventa(int id);
        List<Cpventa> GetAllCpventa();
        List<Cpventa> GetAllCpventa(Expression<Func<Cpventa, bool>> criteria);
        List<Cpventa> GetAllCpventa(string orders);
        List<Cpventa> GetAllCpventa(string conditions, string orders);
        Cpventa GetCpventa(int id);
        Cpventa GetCpventa(Expression<Func<Cpventa, bool>> criteria);
        bool GuardarCpVenta(TipoMantenimiento tipoMantenimiento, Cpventa entidadCab, List<VwCpventadet> entidadDetList, List<VwGuiaremisiondetimpcpventadet> vwGuiaremisiondetimpcpventadetImpList);
        bool CpVentaTieneReferenciaCaja(int idTipoCp, string serieTipoCp, string numeroTipoCp);
        bool CpVentaTieneNotacredito(int idCpventa);
        int GuardarCpVentaReciboIngreso(TipoMantenimiento tipoMantenimiento, Cpventa entidadCab, List<VwCpventadet> entidadDetList, Recibocajaingreso recibocajaingreso, List<VwRecibocajaingresodet> vWrecibocajaingresodetList);
        bool CpVentaTieneReferenciaSalidaAlmacen(int idCpVenta);
        #endregion

        #region Cpventadet service

        long CountCpventadet();
        long CountCpventadet(Expression<Func<Cpventadet, bool>> criteria);
        int SaveCpventadet(Cpventadet entity);
        void UpdateCpventadet(Cpventadet entity);
        void DeleteCpventadet(int id);
        List<Cpventadet> GetAllCpventadet();
        List<Cpventadet> GetAllCpventadet(Expression<Func<Cpventadet, bool>> criteria);
        List<Cpventadet> GetAllCpventadet(string orders);
        List<Cpventadet> GetAllCpventadet(string conditions, string orders);
        Cpventadet GetCpventadet(int id);
        Cpventadet GetCpventadet(Expression<Func<Cpventadet, bool>> criteria);

        #endregion

        #region Guiaremisionmotivo service

        long CountGuiaremisionmotivo();
        long CountGuiaremisionmotivo(Expression<Func<Guiaremisionmotivo, bool>> criteria);
        int SaveGuiaremisionmotivo(Guiaremisionmotivo entity);
        void UpdateGuiaremisionmotivo(Guiaremisionmotivo entity);
        void DeleteGuiaremisionmotivo(int id);
        List<Guiaremisionmotivo> GetAllGuiaremisionmotivo();
        List<Guiaremisionmotivo> GetAllGuiaremisionmotivo(Expression<Func<Guiaremisionmotivo, bool>> criteria);
        List<Guiaremisionmotivo> GetAllGuiaremisionmotivo(string orders);
        List<Guiaremisionmotivo> GetAllGuiaremisionmotivo(string conditions, string orders);
        Guiaremisionmotivo GetGuiaremisionmotivo(int id);
        Guiaremisionmotivo GetGuiaremisionmotivo(Expression<Func<Guiaremisionmotivo, bool>> criteria);

        #endregion

        #region Ordendeventa service

        long CountOrdendeventa();
        long CountOrdendeventa(Expression<Func<Ordendeventa, bool>> criteria);
        int SaveOrdendeventa(Ordendeventa entity);
        void UpdateOrdendeventa(Ordendeventa entity);
        void DeleteOrdendeventa(int id);
        List<Ordendeventa> GetAllOrdendeventa();
        List<Ordendeventa> GetAllOrdendeventa(Expression<Func<Ordendeventa, bool>> criteria);
        List<Ordendeventa> GetAllOrdendeventa(string orders);
        List<Ordendeventa> GetAllOrdendeventa(string conditions, string orders);
        Ordendeventa GetOrdendeventa(int id);
        Ordendeventa GetOrdendeventa(Expression<Func<Ordendeventa, bool>> criteria);
        bool NumeroOrdendeventaExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        bool GuardarOrdendeVenta(TipoMantenimiento tipoMantenimiento, Ordendeventa entidadCab, List<VwOrdendeventadet> entidadDetList);
        bool OrdenVentaTieneReferenciaCpventa(int idOrdenVenta);
        bool OrdenVentaTieneReferenciaValorizacion(int idOrdenVenta);
        #endregion

        #region Ordendeventadetalle service

        long CountOrdendeventadetalle();
        long CountOrdendeventadetalle(Expression<Func<Ordendeventadet, bool>> criteria);
        int SaveOrdendeventadetalle(Ordendeventadet entity);
        void UpdateOrdendeventadetalle(Ordendeventadet entity);
        void DeleteOrdendeventadetalle(int id);
        List<Ordendeventadet> GetAllOrdendeventadetalle();
        List<Ordendeventadet> GetAllOrdendeventadetalle(Expression<Func<Ordendeventadet, bool>> criteria);
        List<Ordendeventadet> GetAllOrdendeventadetalle(string orders);
        List<Ordendeventadet> GetAllOrdendeventadetalle(string conditions, string orders);
        Ordendeventadet GetOrdendeventadetalle(int id);
        Ordendeventadet GetOrdendeventadetalle(Expression<Func<Ordendeventadet, bool>> criteria);

        #endregion

        #region VwCotizacioncliente service

        long CountVwCotizacioncliente();
        long CountVwCotizacioncliente(Expression<Func<VwCotizacioncliente, bool>> criteria);
        List<VwCotizacioncliente> GetAllVwCotizacioncliente();
        List<VwCotizacioncliente> GetAllVwCotizacioncliente(Expression<Func<VwCotizacioncliente, bool>> criteria);
        List<VwCotizacioncliente> GetAllVwCotizacioncliente(string orders);
        List<VwCotizacioncliente> GetAllVwCotizacioncliente(string conditions, string orders);
        VwCotizacioncliente GetVwCotizacioncliente(int id);
        VwCotizacioncliente GetVwCotizacioncliente(Expression<Func<VwCotizacioncliente, bool>> criteria);

        #endregion

        #region VwCotizacionclientedet service

        long CountVwCotizacionclientedet();
        long CountVwCotizacionclientedet(Expression<Func<VwCotizacionclientedet, bool>> criteria);
        List<VwCotizacionclientedet> GetAllVwCotizacionclientedet();
        List<VwCotizacionclientedet> GetAllVwCotizacionclientedet(Expression<Func<VwCotizacionclientedet, bool>> criteria);
        List<VwCotizacionclientedet> GetAllVwCotizacionclientedet(string orders);
        List<VwCotizacionclientedet> GetAllVwCotizacionclientedet(string conditions, string orders);
        VwCotizacionclientedet GetVwCotizacionclientedet(int id);
        VwCotizacionclientedet GetVwCotizacionclientedet(Expression<Func<VwCotizacionclientedet, bool>> criteria);

        #endregion

        #region VwOrdendeventa service

        long CountVwOrdendeventa();
        long CountVwOrdendeventa(Expression<Func<VwOrdendeventa, bool>> criteria);
        List<VwOrdendeventa> GetAllVwOrdendeventa();
        List<VwOrdendeventa> GetAllVwOrdendeventa(Expression<Func<VwOrdendeventa, bool>> criteria);
        List<VwOrdendeventa> GetAllVwOrdendeventa(string orders);
        List<VwOrdendeventa> GetAllVwOrdendeventa(string conditions, string orders);
        VwOrdendeventa GetVwOrdendeventa(int id);
        VwOrdendeventa GetVwOrdendeventa(Expression<Func<VwOrdendeventa, bool>> criteria);

        #endregion

        #region VwOrdendeventadetalle service

        long CountVwOrdendeventadetalle();
        long CountVwOrdendeventadetalle(Expression<Func<VwOrdendeventadet, bool>> criteria);
        List<VwOrdendeventadet> GetAllVwOrdendeventadetalle();
        List<VwOrdendeventadet> GetAllVwOrdendeventadetalle(Expression<Func<VwOrdendeventadet, bool>> criteria);
        List<VwOrdendeventadet> GetAllVwOrdendeventadetalle(string orders);
        List<VwOrdendeventadet> GetAllVwOrdendeventadetalle(string conditions, string orders);
        VwOrdendeventadet GetVwOrdendeventadetalle(int id);
        VwOrdendeventadet GetVwOrdendeventadetalle(Expression<Func<VwOrdendeventadet, bool>> criteria);

        #endregion

        #region VwCpventa service

        long CountVwCpventa();
        long CountVwCpventa(Expression<Func<VwCpventa, bool>> criteria);
        List<VwCpventa> GetAllVwCpventa();
        List<VwCpventa> GetAllVwCpventa(Expression<Func<VwCpventa, bool>> criteria);
        List<VwCpventa> GetAllVwCpventa(string orders);
        List<VwCpventa> GetAllVwCpventa(string conditions, string orders);
        VwCpventa GetVwCpventa(int id);
        VwCpventa GetVwCpventa(Expression<Func<VwCpventa, bool>> criteria);

        #endregion

        #region VwCpventadet service

        long CountVwCpventadet();
        long CountVwCpventadet(Expression<Func<VwCpventadet, bool>> criteria);
        List<VwCpventadet> GetAllVwCpventadet();
        List<VwCpventadet> GetAllVwCpventadet(Expression<Func<VwCpventadet, bool>> criteria);
        List<VwCpventadet> GetAllVwCpventadet(string orders);
        List<VwCpventadet> GetAllVwCpventadet(string conditions, string orders);
        VwCpventadet GetVwCpventadet(int id);
        VwCpventadet GetVwCpventadet(Expression<Func<VwCpventadet, bool>> criteria);

        #endregion

        #region VwArticulolistaprecio service

        long CountVwArticulolistaprecio();
        long CountVwArticulolistaprecio(Expression<Func<VwArticulolistaprecio, bool>> criteria);
        List<VwArticulolistaprecio> GetAllVwArticulolistaprecio();
        List<VwArticulolistaprecio> GetAllVwArticulolistaprecio(Expression<Func<VwArticulolistaprecio, bool>> criteria);
        List<VwArticulolistaprecio> GetAllVwArticulolistaprecio(string orders);
        List<VwArticulolistaprecio> GetAllVwArticulolistaprecio(string conditions, string orders);
        VwArticulolistaprecio GetVwArticulolistaprecio(int id);
        VwArticulolistaprecio GetVwArticulolistaprecio(Expression<Func<VwArticulolistaprecio, bool>> criteria);

        #endregion

        #region Notacreditocli service

        long CountNotacreditocli();
        long CountNotacreditocli(Expression<Func<Notacreditocli, bool>> criteria);
        int SaveNotacreditocli(Notacreditocli entity);
        void UpdateNotacreditocli(Notacreditocli entity);
        void DeleteNotacreditocli(int id);
        List<Notacreditocli> GetAllNotacreditocli();
        List<Notacreditocli> GetAllNotacreditocli(Expression<Func<Notacreditocli, bool>> criteria);
        List<Notacreditocli> GetAllNotacreditocli(string orders);
        List<Notacreditocli> GetAllNotacreditocli(string conditions, string orders);
        Notacreditocli GetNotacreditocli(int id);
        Notacreditocli GetNotacreditocli(Expression<Func<Notacreditocli, bool>> criteria);
        bool GuardarNotaCreditoCli(TipoMantenimiento tipoMantenimiento, Notacreditocli entidadCab, List<VwNotacreditoclidet> entidadDetList);
        #endregion

        #region Notacreditoclidet service

        long CountNotacreditoclidet();
        long CountNotacreditoclidet(Expression<Func<Notacreditoclidet, bool>> criteria);
        int SaveNotacreditoclidet(Notacreditoclidet entity);
        void UpdateNotacreditoclidet(Notacreditoclidet entity);
        void DeleteNotacreditoclidet(int id);
        List<Notacreditoclidet> GetAllNotacreditoclidet();
        List<Notacreditoclidet> GetAllNotacreditoclidet(Expression<Func<Notacreditoclidet, bool>> criteria);
        List<Notacreditoclidet> GetAllNotacreditoclidet(string orders);
        List<Notacreditoclidet> GetAllNotacreditoclidet(string conditions, string orders);
        Notacreditoclidet GetNotacreditoclidet(int id);
        Notacreditoclidet GetNotacreditoclidet(Expression<Func<Notacreditoclidet, bool>> criteria);

        #endregion

        #region Notadebitocli service

        long CountNotadebitocli();
        long CountNotadebitocli(Expression<Func<Notadebitocli, bool>> criteria);
        int SaveNotadebitocli(Notadebitocli entity);
        void UpdateNotadebitocli(Notadebitocli entity);
        void DeleteNotadebitocli(int id);
        List<Notadebitocli> GetAllNotadebitocli();
        List<Notadebitocli> GetAllNotadebitocli(Expression<Func<Notadebitocli, bool>> criteria);
        List<Notadebitocli> GetAllNotadebitocli(string orders);
        List<Notadebitocli> GetAllNotadebitocli(string conditions, string orders);
        Notadebitocli GetNotadebitocli(int id);
        Notadebitocli GetNotadebitocli(Expression<Func<Notadebitocli, bool>> criteria);

        #endregion

        #region VwCpventaimpnc service

        long CountVwCpventaimpnc();
        long CountVwCpventaimpnc(Expression<Func<VwCpventaimpnc, bool>> criteria);
        List<VwCpventaimpnc> GetAllVwCpventaimpnc();
        List<VwCpventaimpnc> GetAllVwCpventaimpnc(Expression<Func<VwCpventaimpnc, bool>> criteria);
        List<VwCpventaimpnc> GetAllVwCpventaimpnc(string orders);
        List<VwCpventaimpnc> GetAllVwCpventaimpnc(string conditions, string orders);
        VwCpventaimpnc GetVwCpventaimpnc(int id);
        VwCpventaimpnc GetVwCpventaimpnc(Expression<Func<VwCpventaimpnc, bool>> criteria);

        #endregion

        #region VwCpventaimpnd service

        long CountVwCpventaimpnd();
        long CountVwCpventaimpnd(Expression<Func<VwCpventaimpnd, bool>> criteria);
        List<VwCpventaimpnd> GetAllVwCpventaimpnd();
        List<VwCpventaimpnd> GetAllVwCpventaimpnd(Expression<Func<VwCpventaimpnd, bool>> criteria);
        List<VwCpventaimpnd> GetAllVwCpventaimpnd(string orders);
        List<VwCpventaimpnd> GetAllVwCpventaimpnd(string conditions, string orders);
        VwCpventaimpnd GetVwCpventaimpnd(int id);
        VwCpventaimpnd GetVwCpventaimpnd(Expression<Func<VwCpventaimpnd, bool>> criteria);

        #endregion

        #region VwNotacreditocli service

        long CountVwNotacreditocli();
        long CountVwNotacreditocli(Expression<Func<VwNotacreditocli, bool>> criteria);
        List<VwNotacreditocli> GetAllVwNotacreditocli();
        List<VwNotacreditocli> GetAllVwNotacreditocli(Expression<Func<VwNotacreditocli, bool>> criteria);
        List<VwNotacreditocli> GetAllVwNotacreditocli(string orders);
        List<VwNotacreditocli> GetAllVwNotacreditocli(string conditions, string orders);
        VwNotacreditocli GetVwNotacreditocli(int id);
        VwNotacreditocli GetVwNotacreditocli(Expression<Func<VwNotacreditocli, bool>> criteria);

        #endregion

        #region VwNotacreditoclidet service

        long CountVwNotacreditoclidet();
        long CountVwNotacreditoclidet(Expression<Func<VwNotacreditoclidet, bool>> criteria);
        List<VwNotacreditoclidet> GetAllVwNotacreditoclidet();
        List<VwNotacreditoclidet> GetAllVwNotacreditoclidet(Expression<Func<VwNotacreditoclidet, bool>> criteria);
        List<VwNotacreditoclidet> GetAllVwNotacreditoclidet(string orders);
        List<VwNotacreditoclidet> GetAllVwNotacreditoclidet(string conditions, string orders);
        VwNotacreditoclidet GetVwNotacreditoclidet(int id);
        VwNotacreditoclidet GetVwNotacreditoclidet(Expression<Func<VwNotacreditoclidet, bool>> criteria);

        #endregion

        #region VwNotadebitocli service

        long CountVwNotadebitocli();
        long CountVwNotadebitocli(Expression<Func<VwNotadebitocli, bool>> criteria);
        List<VwNotadebitocli> GetAllVwNotadebitocli();
        List<VwNotadebitocli> GetAllVwNotadebitocli(Expression<Func<VwNotadebitocli, bool>> criteria);
        List<VwNotadebitocli> GetAllVwNotadebitocli(string orders);
        List<VwNotadebitocli> GetAllVwNotadebitocli(string conditions, string orders);
        VwNotadebitocli GetVwNotadebitocli(int id);
        VwNotadebitocli GetVwNotadebitocli(Expression<Func<VwNotadebitocli, bool>> criteria);

        #endregion

        #region Notadebitoclidet service

        long CountNotadebitoclidet();
        long CountNotadebitoclidet(Expression<Func<Notadebitoclidet, bool>> criteria);
        int SaveNotadebitoclidet(Notadebitoclidet entity);
        void UpdateNotadebitoclidet(Notadebitoclidet entity);
        void DeleteNotadebitoclidet(int id);
        List<Notadebitoclidet> GetAllNotadebitoclidet();
        List<Notadebitoclidet> GetAllNotadebitoclidet(Expression<Func<Notadebitoclidet, bool>> criteria);
        List<Notadebitoclidet> GetAllNotadebitoclidet(string orders);
        List<Notadebitoclidet> GetAllNotadebitoclidet(string conditions, string orders);
        Notadebitoclidet GetNotadebitoclidet(int id);
        Notadebitoclidet GetNotadebitoclidet(Expression<Func<Notadebitoclidet, bool>> criteria);
        bool GuardarNotaDebitoCli(TipoMantenimiento tipoMantenimiento, Notadebitocli entidadCab, List<VwNotadebitoclidet> entidadDetList);
        #endregion

        #region VwNotadebitoclidet service

        long CountVwNotadebitoclidet();
        long CountVwNotadebitoclidet(Expression<Func<VwNotadebitoclidet, bool>> criteria);
        List<VwNotadebitoclidet> GetAllVwNotadebitoclidet();
        List<VwNotadebitoclidet> GetAllVwNotadebitoclidet(Expression<Func<VwNotadebitoclidet, bool>> criteria);
        List<VwNotadebitoclidet> GetAllVwNotadebitoclidet(string orders);
        List<VwNotadebitoclidet> GetAllVwNotadebitoclidet(string conditions, string orders);
        VwNotadebitoclidet GetVwNotadebitoclidet(int id);
        VwNotadebitoclidet GetVwNotadebitoclidet(Expression<Func<VwNotadebitoclidet, bool>> criteria);

        #endregion

        #region VwCotizacionclientedetovimp service

        long CountVwCotizacionclientedetovimp();
        long CountVwCotizacionclientedetovimp(Expression<Func<VwCotizacionclientedetovimp, bool>> criteria);
        List<VwCotizacionclientedetovimp> GetAllVwCotizacionclientedetovimp();
        List<VwCotizacionclientedetovimp> GetAllVwCotizacionclientedetovimp(Expression<Func<VwCotizacionclientedetovimp, bool>> criteria);
        List<VwCotizacionclientedetovimp> GetAllVwCotizacionclientedetovimp(string orders);
        List<VwCotizacionclientedetovimp> GetAllVwCotizacionclientedetovimp(string conditions, string orders);
        VwCotizacionclientedetovimp GetVwCotizacionclientedetovimp(int id);
        VwCotizacionclientedetovimp GetVwCotizacionclientedetovimp(Expression<Func<VwCotizacionclientedetovimp, bool>> criteria);

        #endregion

        #region VwOrdendeventadetcpventaimp service

        long CountVwOrdendeventadetcpventaimp();
        long CountVwOrdendeventadetcpventaimp(Expression<Func<VwOrdendeventadetcpventaimp, bool>> criteria);
        List<VwOrdendeventadetcpventaimp> GetAllVwOrdendeventadetcpventaimp();
        List<VwOrdendeventadetcpventaimp> GetAllVwOrdendeventadetcpventaimp(Expression<Func<VwOrdendeventadetcpventaimp, bool>> criteria);
        List<VwOrdendeventadetcpventaimp> GetAllVwOrdendeventadetcpventaimp(string orders);
        List<VwOrdendeventadetcpventaimp> GetAllVwOrdendeventadetcpventaimp(string conditions, string orders);
        VwOrdendeventadetcpventaimp GetVwOrdendeventadetcpventaimp(int id);
        VwOrdendeventadetcpventaimp GetVwOrdendeventadetcpventaimp(Expression<Func<VwOrdendeventadetcpventaimp, bool>> criteria);

        #endregion
        
        #region VwOrdendeventadetvalorizaimp service

        long CountVwOrdendeventadetvalorizaimp();
        long CountVwOrdendeventadetvalorizaimp(Expression<Func<VwOrdendeventadetvalorizaimp, bool>> criteria);
        List<VwOrdendeventadetvalorizaimp> GetAllVwOrdendeventadetvalorizaimp();
        List<VwOrdendeventadetvalorizaimp> GetAllVwOrdendeventadetvalorizaimp(Expression<Func<VwOrdendeventadetvalorizaimp, bool>> criteria);
        List<VwOrdendeventadetvalorizaimp> GetAllVwOrdendeventadetvalorizaimp(string orders);
        List<VwOrdendeventadetvalorizaimp> GetAllVwOrdendeventadetvalorizaimp(string conditions, string orders);
        VwOrdendeventadetvalorizaimp GetVwOrdendeventadetvalorizaimp(int id);
        VwOrdendeventadetvalorizaimp GetVwOrdendeventadetvalorizaimp(Expression<Func<VwOrdendeventadetvalorizaimp, bool>> criteria);

        #endregion

        #region VwArticulostocklista service

        long CountVwArticulostocklista();
        long CountVwArticulostocklista(Expression<Func<VwArticulostocklista, bool>> criteria);
        List<VwArticulostocklista> GetAllVwArticulostocklista();
        List<VwArticulostocklista> GetAllVwArticulostocklista(Expression<Func<VwArticulostocklista, bool>> criteria);
        List<VwArticulostocklista> GetAllVwArticulostocklista(string orders);
        List<VwArticulostocklista> GetAllVwArticulostocklista(string conditions, string orders);
        VwArticulostocklista GetVwArticulostocklista(int id);
        VwArticulostocklista GetVwArticulostocklista(Expression<Func<VwArticulostocklista, bool>> criteria);
        List<VwArticulostocklista> ConsultaArticuloStockLista(int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta, string condicion);        
        List<VwArticulostocklista> ConsultaArticuloStockLista(int idArticulo, int idSucursal, int idAlmacen,int idTipoLista, DateTime fechaConsulta);
        List<VwArticulostocklista> ConsultaArticuloStockLista(int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta, int idArticulo);
        #endregion

        #region VwOrdendeventadetimpguiaremision service

        long CountVwOrdendeventadetimpguiaremision();
        long CountVwOrdendeventadetimpguiaremision(Expression<Func<VwOrdendeventadetimpguiaremision, bool>> criteria);
        List<VwOrdendeventadetimpguiaremision> GetAllVwOrdendeventadetimpguiaremision();
        List<VwOrdendeventadetimpguiaremision> GetAllVwOrdendeventadetimpguiaremision(Expression<Func<VwOrdendeventadetimpguiaremision, bool>> criteria);
        List<VwOrdendeventadetimpguiaremision> GetAllVwOrdendeventadetimpguiaremision(string orders);
        List<VwOrdendeventadetimpguiaremision> GetAllVwOrdendeventadetimpguiaremision(string conditions, string orders);
        VwOrdendeventadetimpguiaremision GetVwOrdendeventadetimpguiaremision(int id);
        VwOrdendeventadetimpguiaremision GetVwOrdendeventadetimpguiaremision(Expression<Func<VwOrdendeventadetimpguiaremision, bool>> criteria);

        #endregion

        #region VwOrdendeventavalorizacpventaimp service

        long CountVwOrdendeventavalorizacpventaimp();
        long CountVwOrdendeventavalorizacpventaimp(Expression<Func<VwOrdendeventavalorizacpventaimp, bool>> criteria);
        List<VwOrdendeventavalorizacpventaimp> GetAllVwOrdendeventavalorizacpventaimp();
        List<VwOrdendeventavalorizacpventaimp> GetAllVwOrdendeventavalorizacpventaimp(Expression<Func<VwOrdendeventavalorizacpventaimp, bool>> criteria);
        List<VwOrdendeventavalorizacpventaimp> GetAllVwOrdendeventavalorizacpventaimp(string orders);
        List<VwOrdendeventavalorizacpventaimp> GetAllVwOrdendeventavalorizacpventaimp(string conditions, string orders);
        VwOrdendeventavalorizacpventaimp GetVwOrdendeventavalorizacpventaimp(int id);
        VwOrdendeventavalorizacpventaimp GetVwOrdendeventavalorizacpventaimp(Expression<Func<VwOrdendeventavalorizacpventaimp, bool>> criteria);

        #endregion

        #region Comisioncobro service

        long CountComisioncobro();
        long CountComisioncobro(Expression<Func<Comisioncobro, bool>> criteria);
        int SaveComisioncobro(Comisioncobro entity);
        void UpdateComisioncobro(Comisioncobro entity);
        void DeleteComisioncobro(int id);
        List<Comisioncobro> GetAllComisioncobro();
        List<Comisioncobro> GetAllComisioncobro(Expression<Func<Comisioncobro, bool>> criteria);
        List<Comisioncobro> GetAllComisioncobro(string orders);
        List<Comisioncobro> GetAllComisioncobro(string conditions, string orders);
        Comisioncobro GetComisioncobro(int id);
        Comisioncobro GetComisioncobro(Expression<Func<Comisioncobro, bool>> criteria);

        bool GuardarComisionCobro(TipoMantenimiento tipoMantenimiento, Comisioncobro entidadCab, List<Comisioncobrodet> entidadDetList);

        #endregion

        #region Comisioncobrodet service

        long CountComisioncobrodet();
        long CountComisioncobrodet(Expression<Func<Comisioncobrodet, bool>> criteria);
        int SaveComisioncobrodet(Comisioncobrodet entity);
        void UpdateComisioncobrodet(Comisioncobrodet entity);
        void DeleteComisioncobrodet(int id);
        List<Comisioncobrodet> GetAllComisioncobrodet();
        List<Comisioncobrodet> GetAllComisioncobrodet(Expression<Func<Comisioncobrodet, bool>> criteria);
        List<Comisioncobrodet> GetAllComisioncobrodet(string orders);
        List<Comisioncobrodet> GetAllComisioncobrodet(string conditions, string orders);
        Comisioncobrodet GetComisioncobrodet(int id);
        Comisioncobrodet GetComisioncobrodet(Expression<Func<Comisioncobrodet, bool>> criteria);

        #endregion

        #region Tipocomisioncobro service

        long CountTipocomisioncobro();
        long CountTipocomisioncobro(Expression<Func<Tipocomisioncobro, bool>> criteria);
        int SaveTipocomisioncobro(Tipocomisioncobro entity);
        void UpdateTipocomisioncobro(Tipocomisioncobro entity);
        void DeleteTipocomisioncobro(int id);
        List<Tipocomisioncobro> GetAllTipocomisioncobro();
        List<Tipocomisioncobro> GetAllTipocomisioncobro(Expression<Func<Tipocomisioncobro, bool>> criteria);
        List<Tipocomisioncobro> GetAllTipocomisioncobro(string orders);
        List<Tipocomisioncobro> GetAllTipocomisioncobro(string conditions, string orders);
        Tipocomisioncobro GetTipocomisioncobro(int id);
        Tipocomisioncobro GetTipocomisioncobro(Expression<Func<Tipocomisioncobro, bool>> criteria);

        #endregion

        #region VwComisioncobro service

        long CountVwComisioncobro();
        long CountVwComisioncobro(Expression<Func<VwComisioncobro, bool>> criteria);
        List<VwComisioncobro> GetAllVwComisioncobro();
        List<VwComisioncobro> GetAllVwComisioncobro(Expression<Func<VwComisioncobro, bool>> criteria);
        List<VwComisioncobro> GetAllVwComisioncobro(string orders);
        List<VwComisioncobro> GetAllVwComisioncobro(string conditions, string orders);
        VwComisioncobro GetVwComisioncobro(int id);
        VwComisioncobro GetVwComisioncobro(Expression<Func<VwComisioncobro, bool>> criteria);

        #endregion

        #region Detraccioncliente service

        long CountDetraccioncliente();
        long CountDetraccioncliente(Expression<Func<Detraccioncliente, bool>> criteria);
        int SaveDetraccioncliente(Detraccioncliente entity);
        void UpdateDetraccioncliente(Detraccioncliente entity);
        void DeleteDetraccioncliente(int id);
        List<Detraccioncliente> GetAllDetraccioncliente();
        List<Detraccioncliente> GetAllDetraccioncliente(Expression<Func<Detraccioncliente, bool>> criteria);
        List<Detraccioncliente> GetAllDetraccioncliente(string orders);
        List<Detraccioncliente> GetAllDetraccioncliente(string conditions, string orders);
        Detraccioncliente GetDetraccioncliente(int id);
        Detraccioncliente GetDetraccioncliente(Expression<Func<Detraccioncliente, bool>> criteria);

        #endregion

        #region VwDetraccioncliente service

        long CountVwDetraccioncliente();
        long CountVwDetraccioncliente(Expression<Func<VwDetraccioncliente, bool>> criteria);
        List<VwDetraccioncliente> GetAllVwDetraccioncliente();
        List<VwDetraccioncliente> GetAllVwDetraccioncliente(Expression<Func<VwDetraccioncliente, bool>> criteria);
        List<VwDetraccioncliente> GetAllVwDetraccioncliente(string orders);
        List<VwDetraccioncliente> GetAllVwDetraccioncliente(string conditions, string orders);
        VwDetraccioncliente GetVwDetraccioncliente(int id);
        VwDetraccioncliente GetVwDetraccioncliente(Expression<Func<VwDetraccioncliente, bool>> criteria);

        #endregion

        #region Cpventadetserie service

        long CountCpventadetserie();
        long CountCpventadetserie(Expression<Func<Cpventadetserie, bool>> criteria);
        int SaveCpventadetserie(Cpventadetserie entity);
        void UpdateCpventadetserie(Cpventadetserie entity);
        void DeleteCpventadetserie(int id);
        List<Cpventadetserie> GetAllCpventadetserie();
        List<Cpventadetserie> GetAllCpventadetserie(Expression<Func<Cpventadetserie, bool>> criteria);
        List<Cpventadetserie> GetAllCpventadetserie(string orders);
        List<Cpventadetserie> GetAllCpventadetserie(string conditions, string orders);
        Cpventadetserie GetCpventadetserie(int id);
        Cpventadetserie GetCpventadetserie(Expression<Func<Cpventadetserie, bool>> criteria);

        #endregion

        #region VwCpventadetserie service

        long CountVwCpventadetserie();
        long CountVwCpventadetserie(Expression<Func<VwCpventadetserie, bool>> criteria);
        List<VwCpventadetserie> GetAllVwCpventadetserie();
        List<VwCpventadetserie> GetAllVwCpventadetserie(Expression<Func<VwCpventadetserie, bool>> criteria);
        List<VwCpventadetserie> GetAllVwCpventadetserie(string orders);
        List<VwCpventadetserie> GetAllVwCpventadetserie(string conditions, string orders);
        VwCpventadetserie GetVwCpventadetserie(int id);
        VwCpventadetserie GetVwCpventadetserie(Expression<Func<VwCpventadetserie, bool>> criteria);

        #endregion

        #region VwNotacreditoclireciboingresoimp service

        long CountVwNotacreditoclireciboingresoimp();
        long CountVwNotacreditoclireciboingresoimp(Expression<Func<VwNotacreditoclireciboingresoimp, bool>> criteria);
        List<VwNotacreditoclireciboingresoimp> GetAllVwNotacreditoclireciboingresoimp();
        List<VwNotacreditoclireciboingresoimp> GetAllVwNotacreditoclireciboingresoimp(Expression<Func<VwNotacreditoclireciboingresoimp, bool>> criteria);
        List<VwNotacreditoclireciboingresoimp> GetAllVwNotacreditoclireciboingresoimp(string orders);
        List<VwNotacreditoclireciboingresoimp> GetAllVwNotacreditoclireciboingresoimp(string conditions, string orders);
        VwNotacreditoclireciboingresoimp GetVwNotacreditoclireciboingresoimp(int id);
        VwNotacreditoclireciboingresoimp GetVwNotacreditoclireciboingresoimp(Expression<Func<VwNotacreditoclireciboingresoimp, bool>> criteria);

        #endregion

        #endregion

        #region Logistica

        #region LogStocks service

        long CountLogStocks();
        long CountLogStocks(Expression<Func<LogStocks, bool>> criteria);
        int SaveLogStocks(LogStocks entity);
        void UpdateLogStocks(LogStocks entity);
        void DeleteLogStocks(int id);
        List<LogStocks> GetAllLogStocks();
        List<LogStocks> GetAllLogStocks(Expression<Func<LogStocks, bool>> criteria);
        List<LogStocks> GetAllLogStocks(string orders);
        List<LogStocks> GetAllLogStocks(string conditions, string orders);
        LogStocks GetLogStocks(int id);
        LogStocks GetLogStocks(Expression<Func<LogStocks, bool>> criteria);

        #endregion

        #endregion

        #region Maquinaria
        #region Clasificacionequipo service

        long CountClasificacionequipo();
        long CountClasificacionequipo(Expression<Func<Clasificacionequipo, bool>> criteria);
        int SaveClasificacionequipo(Clasificacionequipo entity);
        void UpdateClasificacionequipo(Clasificacionequipo entity);
        void DeleteClasificacionequipo(int id);
        List<Clasificacionequipo> GetAllClasificacionequipo();
        List<Clasificacionequipo> GetAllClasificacionequipo(Expression<Func<Clasificacionequipo, bool>> criteria);
        List<Clasificacionequipo> GetAllClasificacionequipo(string orders);
        List<Clasificacionequipo> GetAllClasificacionequipo(string conditions, string orders);
        Clasificacionequipo GetClasificacionequipo(int id);
        Clasificacionequipo GetClasificacionequipo(Expression<Func<Clasificacionequipo, bool>> criteria);

        #endregion

        #region Equipo service

        long CountEquipo();
        long CountEquipo(Expression<Func<Equipo, bool>> criteria);
        int SaveEquipo(Equipo entity);
        void UpdateEquipo(Equipo entity);
        void DeleteEquipo(int id);
        List<Equipo> GetAllEquipo();
        List<Equipo> GetAllEquipo(Expression<Func<Equipo, bool>> criteria);
        List<Equipo> GetAllEquipo(string orders);
        List<Equipo> GetAllEquipo(string conditions, string orders);
        Equipo GetEquipo(int id);
        Equipo GetEquipo(Expression<Func<Equipo, bool>> criteria);
        string GetSiguienteCodigoEquipo();
        bool CodigoEquipoExiste(string codigo);
        bool CodigoBarraEquipoExiste(string codigoBarra);

        #endregion

        #region Marcaequipo service

        long CountMarcaequipo();
        long CountMarcaequipo(Expression<Func<Marcaequipo, bool>> criteria);
        int SaveMarcaequipo(Marcaequipo entity);
        void UpdateMarcaequipo(Marcaequipo entity);
        void DeleteMarcaequipo(int id);
        List<Marcaequipo> GetAllMarcaequipo();
        List<Marcaequipo> GetAllMarcaequipo(Expression<Func<Marcaequipo, bool>> criteria);
        List<Marcaequipo> GetAllMarcaequipo(string orders);
        List<Marcaequipo> GetAllMarcaequipo(string conditions, string orders);
        Marcaequipo GetMarcaequipo(int id);
        Marcaequipo GetMarcaequipo(Expression<Func<Marcaequipo, bool>> criteria);

        #endregion

        #region Modeloequipo service

        long CountModeloequipo();
        long CountModeloequipo(Expression<Func<Modeloequipo, bool>> criteria);
        int SaveModeloequipo(Modeloequipo entity);
        void UpdateModeloequipo(Modeloequipo entity);
        void DeleteModeloequipo(int id);
        List<Modeloequipo> GetAllModeloequipo();
        List<Modeloequipo> GetAllModeloequipo(Expression<Func<Modeloequipo, bool>> criteria);
        List<Modeloequipo> GetAllModeloequipo(string orders);
        List<Modeloequipo> GetAllModeloequipo(string conditions, string orders);
        Modeloequipo GetModeloequipo(int id);
        Modeloequipo GetModeloequipo(Expression<Func<Modeloequipo, bool>> criteria);

        #endregion

        #region VwEquipo service

        long CountVwEquipo();
        long CountVwEquipo(Expression<Func<VwEquipo, bool>> criteria);
        List<VwEquipo> GetAllVwEquipo();
        List<VwEquipo> GetAllVwEquipo(Expression<Func<VwEquipo, bool>> criteria);
        List<VwEquipo> GetAllVwEquipo(string orders);
        List<VwEquipo> GetAllVwEquipo(string conditions, string orders);
        VwEquipo GetVwEquipo(int id);
        VwEquipo GetVwEquipo(Expression<Func<VwEquipo, bool>> criteria);

        #endregion

        #region VwModeloequipo service

        long CountVwModeloequipo();
        long CountVwModeloequipo(Expression<Func<VwModeloequipo, bool>> criteria);
        List<VwModeloequipo> GetAllVwModeloequipo();
        List<VwModeloequipo> GetAllVwModeloequipo(Expression<Func<VwModeloequipo, bool>> criteria);
        List<VwModeloequipo> GetAllVwModeloequipo(string orders);
        List<VwModeloequipo> GetAllVwModeloequipo(string conditions, string orders);
        VwModeloequipo GetVwModeloequipo(int id);
        VwModeloequipo GetVwModeloequipo(Expression<Func<VwModeloequipo, bool>> criteria);

        #endregion

        #region Tipoalquiler service

        long CountTipoalquiler();
        long CountTipoalquiler(Expression<Func<Tipoalquiler, bool>> criteria);
        int SaveTipoalquiler(Tipoalquiler entity);
        void UpdateTipoalquiler(Tipoalquiler entity);
        void DeleteTipoalquiler(int id);
        List<Tipoalquiler> GetAllTipoalquiler();
        List<Tipoalquiler> GetAllTipoalquiler(Expression<Func<Tipoalquiler, bool>> criteria);
        List<Tipoalquiler> GetAllTipoalquiler(string orders);
        List<Tipoalquiler> GetAllTipoalquiler(string conditions, string orders);
        Tipoalquiler GetTipoalquiler(int id);
        Tipoalquiler GetTipoalquiler(Expression<Func<Tipoalquiler, bool>> criteria);

        #endregion

        #region Tipoegresovalorizacion service

        long CountTipoegresovalorizacion();
        long CountTipoegresovalorizacion(Expression<Func<Tipoegresovalorizacion, bool>> criteria);
        int SaveTipoegresovalorizacion(Tipoegresovalorizacion entity);
        void UpdateTipoegresovalorizacion(Tipoegresovalorizacion entity);
        void DeleteTipoegresovalorizacion(int id);
        List<Tipoegresovalorizacion> GetAllTipoegresovalorizacion();
        List<Tipoegresovalorizacion> GetAllTipoegresovalorizacion(Expression<Func<Tipoegresovalorizacion, bool>> criteria);
        List<Tipoegresovalorizacion> GetAllTipoegresovalorizacion(string orders);
        List<Tipoegresovalorizacion> GetAllTipoegresovalorizacion(string conditions, string orders);
        Tipoegresovalorizacion GetTipoegresovalorizacion(int id);
        Tipoegresovalorizacion GetTipoegresovalorizacion(Expression<Func<Tipoegresovalorizacion, bool>> criteria);

        #endregion

        #region Valorizacion service

        long CountValorizacion();
        long CountValorizacion(Expression<Func<Valorizacion, bool>> criteria);
        int SaveValorizacion(Valorizacion entity);
        void UpdateValorizacion(Valorizacion entity);
        void DeleteValorizacion(int id);
        List<Valorizacion> GetAllValorizacion();
        List<Valorizacion> GetAllValorizacion(Expression<Func<Valorizacion, bool>> criteria);
        List<Valorizacion> GetAllValorizacion(string orders);
        List<Valorizacion> GetAllValorizacion(string conditions, string orders);
        Valorizacion GetValorizacion(int id);
        Valorizacion GetValorizacion(Expression<Func<Valorizacion, bool>> criteria);
        bool NumeroValorizacionExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        bool GuardarValorizacion(TipoMantenimiento tipoMantenimiento, Valorizacion entidadCab, List<VwValorizaciondet> entidadDetList);
        bool ValorizacionTieneReferenciaCpventa(int idvalorizacion);
        #endregion

        #region Valorizaciondet service

        long CountValorizaciondet();
        long CountValorizaciondet(Expression<Func<Valorizaciondet, bool>> criteria);
        int SaveValorizaciondet(Valorizaciondet entity);
        void UpdateValorizaciondet(Valorizaciondet entity);
        void DeleteValorizaciondet(int id);
        List<Valorizaciondet> GetAllValorizaciondet();
        List<Valorizaciondet> GetAllValorizaciondet(Expression<Func<Valorizaciondet, bool>> criteria);
        List<Valorizaciondet> GetAllValorizaciondet(string orders);
        List<Valorizaciondet> GetAllValorizaciondet(string conditions, string orders);
        Valorizaciondet GetValorizaciondet(int id);
        Valorizaciondet GetValorizaciondet(Expression<Func<Valorizaciondet, bool>> criteria);

        #endregion

        #region Valorizacionegreso service

        long CountValorizacionegreso();
        long CountValorizacionegreso(Expression<Func<Valorizacionegreso, bool>> criteria);
        int SaveValorizacionegreso(Valorizacionegreso entity);
        void UpdateValorizacionegreso(Valorizacionegreso entity);
        void DeleteValorizacionegreso(int id);
        List<Valorizacionegreso> GetAllValorizacionegreso();
        List<Valorizacionegreso> GetAllValorizacionegreso(Expression<Func<Valorizacionegreso, bool>> criteria);
        List<Valorizacionegreso> GetAllValorizacionegreso(string orders);
        List<Valorizacionegreso> GetAllValorizacionegreso(string conditions, string orders);
        Valorizacionegreso GetValorizacionegreso(int id);
        Valorizacionegreso GetValorizacionegreso(Expression<Func<Valorizacionegreso, bool>> criteria);

        #endregion

        #region VwValorizacion service

        long CountVwValorizacion();
        long CountVwValorizacion(Expression<Func<VwValorizacion, bool>> criteria);
        List<VwValorizacion> GetAllVwValorizacion();
        List<VwValorizacion> GetAllVwValorizacion(Expression<Func<VwValorizacion, bool>> criteria);
        List<VwValorizacion> GetAllVwValorizacion(string orders);
        List<VwValorizacion> GetAllVwValorizacion(string conditions, string orders);
        VwValorizacion GetVwValorizacion(int id);
        VwValorizacion GetVwValorizacion(Expression<Func<VwValorizacion, bool>> criteria);

        #endregion

        #region VwValorizaciondet service

        long CountVwValorizaciondet();
        long CountVwValorizaciondet(Expression<Func<VwValorizaciondet, bool>> criteria);
        List<VwValorizaciondet> GetAllVwValorizaciondet();
        List<VwValorizaciondet> GetAllVwValorizaciondet(Expression<Func<VwValorizaciondet, bool>> criteria);
        List<VwValorizaciondet> GetAllVwValorizaciondet(string orders);
        List<VwValorizaciondet> GetAllVwValorizaciondet(string conditions, string orders);
        VwValorizaciondet GetVwValorizaciondet(int id);
        VwValorizaciondet GetVwValorizaciondet(Expression<Func<VwValorizaciondet, bool>> criteria);

        #endregion

        #region VwValorizacionegreso service

        long CountVwValorizacionegreso();
        long CountVwValorizacionegreso(Expression<Func<VwValorizacionegreso, bool>> criteria);
        List<VwValorizacionegreso> GetAllVwValorizacionegreso();
        List<VwValorizacionegreso> GetAllVwValorizacionegreso(Expression<Func<VwValorizacionegreso, bool>> criteria);
        List<VwValorizacionegreso> GetAllVwValorizacionegreso(string orders);
        List<VwValorizacionegreso> GetAllVwValorizacionegreso(string conditions, string orders);
        VwValorizacionegreso GetVwValorizacionegreso(int id);
        VwValorizacionegreso GetVwValorizacionegreso(Expression<Func<VwValorizacionegreso, bool>> criteria);

        #endregion

        #region Valorizacionegresoproveedor service

        long CountValorizacionegresoproveedor();
        long CountValorizacionegresoproveedor(Expression<Func<Valorizacionegresoproveedor, bool>> criteria);
        int SaveValorizacionegresoproveedor(Valorizacionegresoproveedor entity);
        void UpdateValorizacionegresoproveedor(Valorizacionegresoproveedor entity);
        void DeleteValorizacionegresoproveedor(int id);
        List<Valorizacionegresoproveedor> GetAllValorizacionegresoproveedor();
        List<Valorizacionegresoproveedor> GetAllValorizacionegresoproveedor(Expression<Func<Valorizacionegresoproveedor, bool>> criteria);
        List<Valorizacionegresoproveedor> GetAllValorizacionegresoproveedor(string orders);
        List<Valorizacionegresoproveedor> GetAllValorizacionegresoproveedor(string conditions, string orders);
        Valorizacionegresoproveedor GetValorizacionegresoproveedor(int id);
        Valorizacionegresoproveedor GetValorizacionegresoproveedor(Expression<Func<Valorizacionegresoproveedor, bool>> criteria);

        #endregion

        #region Valorizacionproveedor service

        long CountValorizacionproveedor();
        long CountValorizacionproveedor(Expression<Func<Valorizacionproveedor, bool>> criteria);
        int SaveValorizacionproveedor(Valorizacionproveedor entity);
        void UpdateValorizacionproveedor(Valorizacionproveedor entity);
        void DeleteValorizacionproveedor(int id);
        List<Valorizacionproveedor> GetAllValorizacionproveedor();
        List<Valorizacionproveedor> GetAllValorizacionproveedor(Expression<Func<Valorizacionproveedor, bool>> criteria);
        List<Valorizacionproveedor> GetAllValorizacionproveedor(string orders);
        List<Valorizacionproveedor> GetAllValorizacionproveedor(string conditions, string orders);
        Valorizacionproveedor GetValorizacionproveedor(int id);
        Valorizacionproveedor GetValorizacionproveedor(Expression<Func<Valorizacionproveedor, bool>> criteria);
        bool GuardarValorizacionProveedor(TipoMantenimiento tipoMantenimiento, Valorizacionproveedor entidadCab, List<VwValorizacionproveedordet> entidadDetList);

        #endregion

        #region Valorizacionproveedordet service

        long CountValorizacionproveedordet();
        long CountValorizacionproveedordet(Expression<Func<Valorizacionproveedordet, bool>> criteria);
        int SaveValorizacionproveedordet(Valorizacionproveedordet entity);
        void UpdateValorizacionproveedordet(Valorizacionproveedordet entity);
        void DeleteValorizacionproveedordet(int id);
        List<Valorizacionproveedordet> GetAllValorizacionproveedordet();
        List<Valorizacionproveedordet> GetAllValorizacionproveedordet(Expression<Func<Valorizacionproveedordet, bool>> criteria);
        List<Valorizacionproveedordet> GetAllValorizacionproveedordet(string orders);
        List<Valorizacionproveedordet> GetAllValorizacionproveedordet(string conditions, string orders);
        Valorizacionproveedordet GetValorizacionproveedordet(int id);
        Valorizacionproveedordet GetValorizacionproveedordet(Expression<Func<Valorizacionproveedordet, bool>> criteria);

        #endregion

        #region VwValorizacionegresoproveedor service

        long CountVwValorizacionegresoproveedor();
        long CountVwValorizacionegresoproveedor(Expression<Func<VwValorizacionegresoproveedor, bool>> criteria);
        List<VwValorizacionegresoproveedor> GetAllVwValorizacionegresoproveedor();
        List<VwValorizacionegresoproveedor> GetAllVwValorizacionegresoproveedor(Expression<Func<VwValorizacionegresoproveedor, bool>> criteria);
        List<VwValorizacionegresoproveedor> GetAllVwValorizacionegresoproveedor(string orders);
        List<VwValorizacionegresoproveedor> GetAllVwValorizacionegresoproveedor(string conditions, string orders);
        VwValorizacionegresoproveedor GetVwValorizacionegresoproveedor(int id);
        VwValorizacionegresoproveedor GetVwValorizacionegresoproveedor(Expression<Func<VwValorizacionegresoproveedor, bool>> criteria);

        #endregion

        #region VwValorizacionproveedor service

        long CountVwValorizacionproveedor();
        long CountVwValorizacionproveedor(Expression<Func<VwValorizacionproveedor, bool>> criteria);
        List<VwValorizacionproveedor> GetAllVwValorizacionproveedor();
        List<VwValorizacionproveedor> GetAllVwValorizacionproveedor(Expression<Func<VwValorizacionproveedor, bool>> criteria);
        List<VwValorizacionproveedor> GetAllVwValorizacionproveedor(string orders);
        List<VwValorizacionproveedor> GetAllVwValorizacionproveedor(string conditions, string orders);
        VwValorizacionproveedor GetVwValorizacionproveedor(int id);
        VwValorizacionproveedor GetVwValorizacionproveedor(Expression<Func<VwValorizacionproveedor, bool>> criteria);

        #endregion

        #region VwValorizacionproveedordet service

        long CountVwValorizacionproveedordet();
        long CountVwValorizacionproveedordet(Expression<Func<VwValorizacionproveedordet, bool>> criteria);
        List<VwValorizacionproveedordet> GetAllVwValorizacionproveedordet();
        List<VwValorizacionproveedordet> GetAllVwValorizacionproveedordet(Expression<Func<VwValorizacionproveedordet, bool>> criteria);
        List<VwValorizacionproveedordet> GetAllVwValorizacionproveedordet(string orders);
        List<VwValorizacionproveedordet> GetAllVwValorizacionproveedordet(string conditions, string orders);
        VwValorizacionproveedordet GetVwValorizacionproveedordet(int id);
        VwValorizacionproveedordet GetVwValorizacionproveedordet(Expression<Func<VwValorizacionproveedordet, bool>> criteria);

        #endregion

        #region VwOrdendeserviciodetvalorizaimp service

        long CountVwOrdendeserviciodetvalorizaimp();
        long CountVwOrdendeserviciodetvalorizaimp(Expression<Func<VwOrdendeserviciodetvalorizaimp, bool>> criteria);
        List<VwOrdendeserviciodetvalorizaimp> GetAllVwOrdendeserviciodetvalorizaimp();
        List<VwOrdendeserviciodetvalorizaimp> GetAllVwOrdendeserviciodetvalorizaimp(Expression<Func<VwOrdendeserviciodetvalorizaimp, bool>> criteria);
        List<VwOrdendeserviciodetvalorizaimp> GetAllVwOrdendeserviciodetvalorizaimp(string orders);
        List<VwOrdendeserviciodetvalorizaimp> GetAllVwOrdendeserviciodetvalorizaimp(string conditions, string orders);
        VwOrdendeserviciodetvalorizaimp GetVwOrdendeserviciodetvalorizaimp(int id);
        VwOrdendeserviciodetvalorizaimp GetVwOrdendeserviciodetvalorizaimp(Expression<Func<VwOrdendeserviciodetvalorizaimp, bool>> criteria);

        #endregion

        #region Mantenimiento service

        long CountMantenimiento();
        long CountMantenimiento(Expression<Func<Mantenimiento, bool>> criteria);
        int SaveMantenimiento(Mantenimiento entity);
        void UpdateMantenimiento(Mantenimiento entity);
        void DeleteMantenimiento(int id);
        List<Mantenimiento> GetAllMantenimiento();
        List<Mantenimiento> GetAllMantenimiento(Expression<Func<Mantenimiento, bool>> criteria);
        List<Mantenimiento> GetAllMantenimiento(string orders);
        List<Mantenimiento> GetAllMantenimiento(string conditions, string orders);
        Mantenimiento GetMantenimiento(int id);
        Mantenimiento GetMantenimiento(Expression<Func<Mantenimiento, bool>> criteria);
        bool GuardarMantenimiento(TipoMantenimiento tipoMantenimiento, Mantenimiento entidadCab, List<Mantenimientoimagen> entidadDetList, string rutaArchivosServidor);
        bool NumeroMantenimientoExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento);
        #endregion

        #region Mantenimientoimagen service

        long CountMantenimientoimagen();
        long CountMantenimientoimagen(Expression<Func<Mantenimientoimagen, bool>> criteria);
        int SaveMantenimientoimagen(Mantenimientoimagen entity);
        void UpdateMantenimientoimagen(Mantenimientoimagen entity);
        void DeleteMantenimientoimagen(int id);
        List<Mantenimientoimagen> GetAllMantenimientoimagen();
        List<Mantenimientoimagen> GetAllMantenimientoimagen(Expression<Func<Mantenimientoimagen, bool>> criteria);
        List<Mantenimientoimagen> GetAllMantenimientoimagen(string orders);
        List<Mantenimientoimagen> GetAllMantenimientoimagen(string conditions, string orders);
        Mantenimientoimagen GetMantenimientoimagen(int id);
        Mantenimientoimagen GetMantenimientoimagen(Expression<Func<Mantenimientoimagen, bool>> criteria);

        #endregion

        #region VwMantenimiento service

        long CountVwMantenimiento();
        long CountVwMantenimiento(Expression<Func<VwMantenimiento, bool>> criteria);
        List<VwMantenimiento> GetAllVwMantenimiento();
        List<VwMantenimiento> GetAllVwMantenimiento(Expression<Func<VwMantenimiento, bool>> criteria);
        List<VwMantenimiento> GetAllVwMantenimiento(string orders);
        List<VwMantenimiento> GetAllVwMantenimiento(string conditions, string orders);
        VwMantenimiento GetVwMantenimiento(int id);
        VwMantenimiento GetVwMantenimiento(Expression<Func<VwMantenimiento, bool>> criteria);

        #endregion

        #region Ordentrabajo service

        long CountOrdentrabajo();
        long CountOrdentrabajo(Expression<Func<Ordentrabajo, bool>> criteria);
        int SaveOrdentrabajo(Ordentrabajo entity);
        void UpdateOrdentrabajo(Ordentrabajo entity);
        void DeleteOrdentrabajo(int id);
        List<Ordentrabajo> GetAllOrdentrabajo();
        List<Ordentrabajo> GetAllOrdentrabajo(Expression<Func<Ordentrabajo, bool>> criteria);
        List<Ordentrabajo> GetAllOrdentrabajo(string orders);
        List<Ordentrabajo> GetAllOrdentrabajo(string conditions, string orders);
        Ordentrabajo GetOrdentrabajo(int id);
        Ordentrabajo GetOrdentrabajo(Expression<Func<Ordentrabajo, bool>> criteria);

        #endregion

        #region VwOrdentrabajo service

        long CountVwOrdentrabajo();
        long CountVwOrdentrabajo(Expression<Func<VwOrdentrabajo, bool>> criteria);
        List<VwOrdentrabajo> GetAllVwOrdentrabajo();
        List<VwOrdentrabajo> GetAllVwOrdentrabajo(Expression<Func<VwOrdentrabajo, bool>> criteria);
        List<VwOrdentrabajo> GetAllVwOrdentrabajo(string orders);
        List<VwOrdentrabajo> GetAllVwOrdentrabajo(string conditions, string orders);
        VwOrdentrabajo GetVwOrdentrabajo(int id);
        VwOrdentrabajo GetVwOrdentrabajo(Expression<Func<VwOrdentrabajo, bool>> criteria);

        #endregion

        #region Valorizaciondanio service

        long CountValorizaciondanio();
        long CountValorizaciondanio(Expression<Func<Valorizaciondanio, bool>> criteria);
        int SaveValorizaciondanio(Valorizaciondanio entity);
        void UpdateValorizaciondanio(Valorizaciondanio entity);
        void DeleteValorizaciondanio(int id);
        List<Valorizaciondanio> GetAllValorizaciondanio();
        List<Valorizaciondanio> GetAllValorizaciondanio(Expression<Func<Valorizaciondanio, bool>> criteria);
        List<Valorizaciondanio> GetAllValorizaciondanio(string orders);
        List<Valorizaciondanio> GetAllValorizaciondanio(string conditions, string orders);
        Valorizaciondanio GetValorizaciondanio(int id);
        Valorizaciondanio GetValorizaciondanio(Expression<Func<Valorizaciondanio, bool>> criteria);

        #endregion

        #region Valorizaciondanioelemento service

        long CountValorizaciondanioelemento();
        long CountValorizaciondanioelemento(Expression<Func<Valorizaciondanioelemento, bool>> criteria);
        int SaveValorizaciondanioelemento(Valorizaciondanioelemento entity);
        void UpdateValorizaciondanioelemento(Valorizaciondanioelemento entity);
        void DeleteValorizaciondanioelemento(int id);
        List<Valorizaciondanioelemento> GetAllValorizaciondanioelemento();
        List<Valorizaciondanioelemento> GetAllValorizaciondanioelemento(Expression<Func<Valorizaciondanioelemento, bool>> criteria);
        List<Valorizaciondanioelemento> GetAllValorizaciondanioelemento(string orders);
        List<Valorizaciondanioelemento> GetAllValorizaciondanioelemento(string conditions, string orders);
        Valorizaciondanioelemento GetValorizaciondanioelemento(int id);
        Valorizaciondanioelemento GetValorizaciondanioelemento(Expression<Func<Valorizaciondanioelemento, bool>> criteria);
        bool GuardarValorizacionDanioElemento(TipoMantenimiento tipoMantenimiento, Valorizaciondanioelemento entidadCab, List<VwValorizacionelemento> elementoDetList, List<VwValorizaciondanio> danioDetList);
        bool ValorizaciondanioelementoTieneReferenciaCpVenta(int idValorizacion, int idarticulodanio, int idarticuloelementodesgaste);
        #endregion

        #region Valorizacionelemento service

        long CountValorizacionelemento();
        long CountValorizacionelemento(Expression<Func<Valorizacionelemento, bool>> criteria);
        int SaveValorizacionelemento(Valorizacionelemento entity);
        void UpdateValorizacionelemento(Valorizacionelemento entity);
        void DeleteValorizacionelemento(int id);
        List<Valorizacionelemento> GetAllValorizacionelemento();
        List<Valorizacionelemento> GetAllValorizacionelemento(Expression<Func<Valorizacionelemento, bool>> criteria);
        List<Valorizacionelemento> GetAllValorizacionelemento(string orders);
        List<Valorizacionelemento> GetAllValorizacionelemento(string conditions, string orders);
        Valorizacionelemento GetValorizacionelemento(int id);
        Valorizacionelemento GetValorizacionelemento(Expression<Func<Valorizacionelemento, bool>> criteria);

        #endregion

        #region VwValorizaciondanio service

        long CountVwValorizaciondanio();
        long CountVwValorizaciondanio(Expression<Func<VwValorizaciondanio, bool>> criteria);
        List<VwValorizaciondanio> GetAllVwValorizaciondanio();
        List<VwValorizaciondanio> GetAllVwValorizaciondanio(Expression<Func<VwValorizaciondanio, bool>> criteria);
        List<VwValorizaciondanio> GetAllVwValorizaciondanio(string orders);
        List<VwValorizaciondanio> GetAllVwValorizaciondanio(string conditions, string orders);
        VwValorizaciondanio GetVwValorizaciondanio(int id);
        VwValorizaciondanio GetVwValorizaciondanio(Expression<Func<VwValorizaciondanio, bool>> criteria);

        #endregion

        #region VwValorizaciondanioelemento service

        long CountVwValorizaciondanioelemento();
        long CountVwValorizaciondanioelemento(Expression<Func<VwValorizaciondanioelemento, bool>> criteria);
        List<VwValorizaciondanioelemento> GetAllVwValorizaciondanioelemento();
        List<VwValorizaciondanioelemento> GetAllVwValorizaciondanioelemento(Expression<Func<VwValorizaciondanioelemento, bool>> criteria);
        List<VwValorizaciondanioelemento> GetAllVwValorizaciondanioelemento(string orders);
        List<VwValorizaciondanioelemento> GetAllVwValorizaciondanioelemento(string conditions, string orders);
        VwValorizaciondanioelemento GetVwValorizaciondanioelemento(int id);
        VwValorizaciondanioelemento GetVwValorizaciondanioelemento(Expression<Func<VwValorizaciondanioelemento, bool>> criteria);

        #endregion

        #region VwValorizacionelemento service

        long CountVwValorizacionelemento();
        long CountVwValorizacionelemento(Expression<Func<VwValorizacionelemento, bool>> criteria);
        List<VwValorizacionelemento> GetAllVwValorizacionelemento();
        List<VwValorizacionelemento> GetAllVwValorizacionelemento(Expression<Func<VwValorizacionelemento, bool>> criteria);
        List<VwValorizacionelemento> GetAllVwValorizacionelemento(string orders);
        List<VwValorizacionelemento> GetAllVwValorizacionelemento(string conditions, string orders);
        VwValorizacionelemento GetVwValorizacionelemento(int id);
        VwValorizacionelemento GetVwValorizacionelemento(Expression<Func<VwValorizacionelemento, bool>> criteria);

        #endregion

        #region VwResumenelementodanio service

        long CountVwResumenelementodanio();
        long CountVwResumenelementodanio(Expression<Func<VwResumenelementodanio, bool>> criteria);
        List<VwResumenelementodanio> GetAllVwResumenelementodanio();
        List<VwResumenelementodanio> GetAllVwResumenelementodanio(Expression<Func<VwResumenelementodanio, bool>> criteria);
        List<VwResumenelementodanio> GetAllVwResumenelementodanio(string orders);
        List<VwResumenelementodanio> GetAllVwResumenelementodanio(string conditions, string orders);
        VwResumenelementodanio GetVwResumenelementodanio(int id);
        VwResumenelementodanio GetVwResumenelementodanio(Expression<Func<VwResumenelementodanio, bool>> criteria);

        #endregion

        #endregion

        #region Clinica

        #region Estadocita service

        long CountEstadocita();
        long CountEstadocita(Expression<Func<Estadocita, bool>> criteria);
        int SaveEstadocita(Estadocita entity);
        void UpdateEstadocita(Estadocita entity);
        void DeleteEstadocita(int id);
        List<Estadocita> GetAllEstadocita();
        List<Estadocita> GetAllEstadocita(Expression<Func<Estadocita, bool>> criteria);
        List<Estadocita> GetAllEstadocita(string orders);
        List<Estadocita> GetAllEstadocita(string conditions, string orders);
        Estadocita GetEstadocita(int id);
        Estadocita GetEstadocita(Expression<Func<Estadocita, bool>> criteria);

        #endregion

        #region Programacioncita service

        long CountProgramacioncita();
        long CountProgramacioncita(Expression<Func<Programacioncita, bool>> criteria);
        int SaveProgramacioncita(Programacioncita entity);
        void UpdateProgramacioncita(Programacioncita entity);
        void DeleteProgramacioncita(int id);
        List<Programacioncita> GetAllProgramacioncita();
        List<Programacioncita> GetAllProgramacioncita(Expression<Func<Programacioncita, bool>> criteria);
        List<Programacioncita> GetAllProgramacioncita(string orders);
        List<Programacioncita> GetAllProgramacioncita(string conditions, string orders);
        Programacioncita GetProgramacioncita(int id);
        Programacioncita GetProgramacioncita(Expression<Func<Programacioncita, bool>> criteria);

        #endregion

        #region Programacioncitadet service

        long CountProgramacioncitadet();
        long CountProgramacioncitadet(Expression<Func<Programacioncitadet, bool>> criteria);
        int SaveProgramacioncitadet(Programacioncitadet entity);
        void UpdateProgramacioncitadet(Programacioncitadet entity);
        void DeleteProgramacioncitadet(int id);
        List<Programacioncitadet> GetAllProgramacioncitadet();
        List<Programacioncitadet> GetAllProgramacioncitadet(Expression<Func<Programacioncitadet, bool>> criteria);
        List<Programacioncitadet> GetAllProgramacioncitadet(string orders);
        List<Programacioncitadet> GetAllProgramacioncitadet(string conditions, string orders);
        Programacioncitadet GetProgramacioncitadet(int id);
        Programacioncitadet GetProgramacioncitadet(Expression<Func<Programacioncitadet, bool>> criteria);

        #endregion

        #region VwProgramacioncita service

        long CountVwProgramacioncita();
        long CountVwProgramacioncita(Expression<Func<VwProgramacioncita, bool>> criteria);
        List<VwProgramacioncita> GetAllVwProgramacioncita();
        List<VwProgramacioncita> GetAllVwProgramacioncita(Expression<Func<VwProgramacioncita, bool>> criteria);
        List<VwProgramacioncita> GetAllVwProgramacioncita(string orders);
        List<VwProgramacioncita> GetAllVwProgramacioncita(string conditions, string orders);
        VwProgramacioncita GetVwProgramacioncita(int id);
        VwProgramacioncita GetVwProgramacioncita(Expression<Func<VwProgramacioncita, bool>> criteria);

        #endregion

        #region VwProgramacioncitadet service

        long CountVwProgramacioncitadet();
        long CountVwProgramacioncitadet(Expression<Func<VwProgramacioncitadet, bool>> criteria);
        List<VwProgramacioncitadet> GetAllVwProgramacioncitadet();
        List<VwProgramacioncitadet> GetAllVwProgramacioncitadet(Expression<Func<VwProgramacioncitadet, bool>> criteria);
        List<VwProgramacioncitadet> GetAllVwProgramacioncitadet(string orders);
        List<VwProgramacioncitadet> GetAllVwProgramacioncitadet(string conditions, string orders);
        VwProgramacioncitadet GetVwProgramacioncitadet(int id);
        VwProgramacioncitadet GetVwProgramacioncitadet(Expression<Func<VwProgramacioncitadet, bool>> criteria);

        #endregion

        #region Motivocita service

        long CountMotivocita();
        long CountMotivocita(Expression<Func<Motivocita, bool>> criteria);
        int SaveMotivocita(Motivocita entity);
        void UpdateMotivocita(Motivocita entity);
        void DeleteMotivocita(int id);
        List<Motivocita> GetAllMotivocita();
        List<Motivocita> GetAllMotivocita(Expression<Func<Motivocita, bool>> criteria);
        List<Motivocita> GetAllMotivocita(string orders);
        List<Motivocita> GetAllMotivocita(string conditions, string orders);
        Motivocita GetMotivocita(int id);
        Motivocita GetMotivocita(Expression<Func<Motivocita, bool>> criteria);

        #endregion

        #region Programacioncitadethistorial service

        long CountProgramacioncitadethistorial();
        long CountProgramacioncitadethistorial(Expression<Func<Programacioncitadethistorial, bool>> criteria);
        int SaveProgramacioncitadethistorial(Programacioncitadethistorial entity);
        void UpdateProgramacioncitadethistorial(Programacioncitadethistorial entity);
        void DeleteProgramacioncitadethistorial(int id);
        List<Programacioncitadethistorial> GetAllProgramacioncitadethistorial();
        List<Programacioncitadethistorial> GetAllProgramacioncitadethistorial(Expression<Func<Programacioncitadethistorial, bool>> criteria);
        List<Programacioncitadethistorial> GetAllProgramacioncitadethistorial(string orders);
        List<Programacioncitadethistorial> GetAllProgramacioncitadethistorial(string conditions, string orders);
        Programacioncitadethistorial GetProgramacioncitadethistorial(int id);
        Programacioncitadethistorial GetProgramacioncitadethistorial(Expression<Func<Programacioncitadethistorial, bool>> criteria);

        #endregion

        #region VwProgramacioncitadethistorial service

        long CountVwProgramacioncitadethistorial();
        long CountVwProgramacioncitadethistorial(Expression<Func<VwProgramacioncitadethistorial, bool>> criteria);
        List<VwProgramacioncitadethistorial> GetAllVwProgramacioncitadethistorial();
        List<VwProgramacioncitadethistorial> GetAllVwProgramacioncitadethistorial(Expression<Func<VwProgramacioncitadethistorial, bool>> criteria);
        List<VwProgramacioncitadethistorial> GetAllVwProgramacioncitadethistorial(string orders);
        List<VwProgramacioncitadethistorial> GetAllVwProgramacioncitadethistorial(string conditions, string orders);
        VwProgramacioncitadethistorial GetVwProgramacioncitadethistorial(int id);
        VwProgramacioncitadethistorial GetVwProgramacioncitadethistorial(Expression<Func<VwProgramacioncitadethistorial, bool>> criteria);

        #endregion

        #region Historiaclinica service

		long CountHistoriaclinica();
		long CountHistoriaclinica(Expression<Func<Historiaclinica, bool>> criteria);
		int SaveHistoriaclinica(Historiaclinica entity);
		void UpdateHistoriaclinica(Historiaclinica entity);
		void DeleteHistoriaclinica(int id);
		List<Historiaclinica> GetAllHistoriaclinica();
		List<Historiaclinica> GetAllHistoriaclinica(Expression<Func<Historiaclinica, bool>> criteria);
		List<Historiaclinica> GetAllHistoriaclinica(string orders);
		List<Historiaclinica> GetAllHistoriaclinica(string conditions, string orders);
		Historiaclinica GetHistoriaclinica(int id);
		Historiaclinica GetHistoriaclinica(Expression<Func<Historiaclinica, bool>> criteria);

		#endregion

		#region Historiaclinicaanalisis service

		long CountHistoriaclinicaanalisis();
		long CountHistoriaclinicaanalisis(Expression<Func<Historiaclinicaanalisis, bool>> criteria);
		int SaveHistoriaclinicaanalisis(Historiaclinicaanalisis entity);
		void UpdateHistoriaclinicaanalisis(Historiaclinicaanalisis entity);
		void DeleteHistoriaclinicaanalisis(int id);
		List<Historiaclinicaanalisis> GetAllHistoriaclinicaanalisis();
		List<Historiaclinicaanalisis> GetAllHistoriaclinicaanalisis(Expression<Func<Historiaclinicaanalisis, bool>> criteria);
		List<Historiaclinicaanalisis> GetAllHistoriaclinicaanalisis(string orders);
		List<Historiaclinicaanalisis> GetAllHistoriaclinicaanalisis(string conditions, string orders);
		Historiaclinicaanalisis GetHistoriaclinicaanalisis(int id);
		Historiaclinicaanalisis GetHistoriaclinicaanalisis(Expression<Func<Historiaclinicaanalisis, bool>> criteria);

		#endregion

		#region Historiaclinicacita service

		long CountHistoriaclinicacita();
		long CountHistoriaclinicacita(Expression<Func<Historiaclinicacita, bool>> criteria);
		int SaveHistoriaclinicacita(Historiaclinicacita entity);
		void UpdateHistoriaclinicacita(Historiaclinicacita entity);
		void DeleteHistoriaclinicacita(int id);
		List<Historiaclinicacita> GetAllHistoriaclinicacita();
		List<Historiaclinicacita> GetAllHistoriaclinicacita(Expression<Func<Historiaclinicacita, bool>> criteria);
		List<Historiaclinicacita> GetAllHistoriaclinicacita(string orders);
		List<Historiaclinicacita> GetAllHistoriaclinicacita(string conditions, string orders);
		Historiaclinicacita GetHistoriaclinicacita(int id);
		Historiaclinicacita GetHistoriaclinicacita(Expression<Func<Historiaclinicacita, bool>> criteria);

		#endregion

		#region Tipoanalisis service

		long CountTipoanalisis();
		long CountTipoanalisis(Expression<Func<Tipoanalisis, bool>> criteria);
		int SaveTipoanalisis(Tipoanalisis entity);
		void UpdateTipoanalisis(Tipoanalisis entity);
		void DeleteTipoanalisis(int id);
		List<Tipoanalisis> GetAllTipoanalisis();
		List<Tipoanalisis> GetAllTipoanalisis(Expression<Func<Tipoanalisis, bool>> criteria);
		List<Tipoanalisis> GetAllTipoanalisis(string orders);
		List<Tipoanalisis> GetAllTipoanalisis(string conditions, string orders);
		Tipoanalisis GetTipoanalisis(int id);
		Tipoanalisis GetTipoanalisis(Expression<Func<Tipoanalisis, bool>> criteria);

		#endregion

		#region Tipociclomenstrual service

		long CountTipociclomenstrual();
		long CountTipociclomenstrual(Expression<Func<Tipociclomenstrual, bool>> criteria);
		int SaveTipociclomenstrual(Tipociclomenstrual entity);
		void UpdateTipociclomenstrual(Tipociclomenstrual entity);
		void DeleteTipociclomenstrual(int id);
		List<Tipociclomenstrual> GetAllTipociclomenstrual();
		List<Tipociclomenstrual> GetAllTipociclomenstrual(Expression<Func<Tipociclomenstrual, bool>> criteria);
		List<Tipociclomenstrual> GetAllTipociclomenstrual(string orders);
		List<Tipociclomenstrual> GetAllTipociclomenstrual(string conditions, string orders);
		Tipociclomenstrual GetTipociclomenstrual(int id);
		Tipociclomenstrual GetTipociclomenstrual(Expression<Func<Tipociclomenstrual, bool>> criteria);

		#endregion

		#region VwHistoriaclinica service

		long CountVwHistoriaclinica();
		long CountVwHistoriaclinica(Expression<Func<VwHistoriaclinica, bool>> criteria);
		List<VwHistoriaclinica> GetAllVwHistoriaclinica();
		List<VwHistoriaclinica> GetAllVwHistoriaclinica(Expression<Func<VwHistoriaclinica, bool>> criteria);
		List<VwHistoriaclinica> GetAllVwHistoriaclinica(string orders);
		List<VwHistoriaclinica> GetAllVwHistoriaclinica(string conditions, string orders);
		VwHistoriaclinica GetVwHistoriaclinica(int id);
		VwHistoriaclinica GetVwHistoriaclinica(Expression<Func<VwHistoriaclinica, bool>> criteria);

		#endregion

		#region VwHistoriaclinicaanalisis service

		long CountVwHistoriaclinicaanalisis();
		long CountVwHistoriaclinicaanalisis(Expression<Func<VwHistoriaclinicaanalisis, bool>> criteria);
		List<VwHistoriaclinicaanalisis> GetAllVwHistoriaclinicaanalisis();
		List<VwHistoriaclinicaanalisis> GetAllVwHistoriaclinicaanalisis(Expression<Func<VwHistoriaclinicaanalisis, bool>> criteria);
		List<VwHistoriaclinicaanalisis> GetAllVwHistoriaclinicaanalisis(string orders);
		List<VwHistoriaclinicaanalisis> GetAllVwHistoriaclinicaanalisis(string conditions, string orders);
		VwHistoriaclinicaanalisis GetVwHistoriaclinicaanalisis(int id);
		VwHistoriaclinicaanalisis GetVwHistoriaclinicaanalisis(Expression<Func<VwHistoriaclinicaanalisis, bool>> criteria);

		#endregion

		#region VwHistoriaclinicacita service

		long CountVwHistoriaclinicacita();
		long CountVwHistoriaclinicacita(Expression<Func<VwHistoriaclinicacita, bool>> criteria);
		List<VwHistoriaclinicacita> GetAllVwHistoriaclinicacita();
		List<VwHistoriaclinicacita> GetAllVwHistoriaclinicacita(Expression<Func<VwHistoriaclinicacita, bool>> criteria);
		List<VwHistoriaclinicacita> GetAllVwHistoriaclinicacita(string orders);
		List<VwHistoriaclinicacita> GetAllVwHistoriaclinicacita(string conditions, string orders);
		VwHistoriaclinicacita GetVwHistoriaclinicacita(int id);
		VwHistoriaclinicacita GetVwHistoriaclinicacita(Expression<Func<VwHistoriaclinicacita, bool>> criteria);

		#endregion

        #region Categoriaitem service

        long CountCategoriaitem();
        long CountCategoriaitem(Expression<Func<Categoriaitem, bool>> criteria);
        int SaveCategoriaitem(Categoriaitem entity);
        void UpdateCategoriaitem(Categoriaitem entity);
        void DeleteCategoriaitem(int id);
        List<Categoriaitem> GetAllCategoriaitem();
        List<Categoriaitem> GetAllCategoriaitem(Expression<Func<Categoriaitem, bool>> criteria);
        List<Categoriaitem> GetAllCategoriaitem(string orders);
        List<Categoriaitem> GetAllCategoriaitem(string conditions, string orders);
        Categoriaitem GetCategoriaitem(int id);
        Categoriaitem GetCategoriaitem(Expression<Func<Categoriaitem, bool>> criteria);

        #endregion

        #region Historia service

        long CountHistoria();
        long CountHistoria(Expression<Func<Historia, bool>> criteria);
        int SaveHistoria(Historia entity);
        void UpdateHistoria(Historia entity);
        void DeleteHistoria(int id);
        List<Historia> GetAllHistoria();
        List<Historia> GetAllHistoria(Expression<Func<Historia, bool>> criteria);
        List<Historia> GetAllHistoria(string orders);
        List<Historia> GetAllHistoria(string conditions, string orders);
        Historia GetHistoria(int id);
        Historia GetHistoria(Expression<Func<Historia, bool>> criteria);

        #endregion

        #region Historiaarchivo service

        long CountHistoriaarchivo();
        long CountHistoriaarchivo(Expression<Func<Historiaarchivo, bool>> criteria);
        int SaveHistoriaarchivo(Historiaarchivo entity);
        void UpdateHistoriaarchivo(Historiaarchivo entity);
        void DeleteHistoriaarchivo(int id);
        List<Historiaarchivo> GetAllHistoriaarchivo();
        List<Historiaarchivo> GetAllHistoriaarchivo(Expression<Func<Historiaarchivo, bool>> criteria);
        List<Historiaarchivo> GetAllHistoriaarchivo(string orders);
        List<Historiaarchivo> GetAllHistoriaarchivo(string conditions, string orders);
        Historiaarchivo GetHistoriaarchivo(int id);
        Historiaarchivo GetHistoriaarchivo(Expression<Func<Historiaarchivo, bool>> criteria);

        #endregion

        #region Historiadet service

        long CountHistoriadet();
        long CountHistoriadet(Expression<Func<Historiadet, bool>> criteria);
        int SaveHistoriadet(Historiadet entity);
        void UpdateHistoriadet(Historiadet entity);
        void DeleteHistoriadet(int id);
        List<Historiadet> GetAllHistoriadet();
        List<Historiadet> GetAllHistoriadet(Expression<Func<Historiadet, bool>> criteria);
        List<Historiadet> GetAllHistoriadet(string orders);
        List<Historiadet> GetAllHistoriadet(string conditions, string orders);
        Historiadet GetHistoriadet(int id);
        Historiadet GetHistoriadet(Expression<Func<Historiadet, bool>> criteria);

        #endregion

        #region Historiadetitem service

        long CountHistoriadetitem();
        long CountHistoriadetitem(Expression<Func<Historiadetitem, bool>> criteria);
        int SaveHistoriadetitem(Historiadetitem entity);
        void UpdateHistoriadetitem(Historiadetitem entity);
        void DeleteHistoriadetitem(int id);
        List<Historiadetitem> GetAllHistoriadetitem();
        List<Historiadetitem> GetAllHistoriadetitem(Expression<Func<Historiadetitem, bool>> criteria);
        List<Historiadetitem> GetAllHistoriadetitem(string orders);
        List<Historiadetitem> GetAllHistoriadetitem(string conditions, string orders);
        Historiadetitem GetHistoriadetitem(int id);
        Historiadetitem GetHistoriadetitem(Expression<Func<Historiadetitem, bool>> criteria);

        #endregion

        #region Itemhistoria service

        long CountItemhistoria();
        long CountItemhistoria(Expression<Func<Itemhistoria, bool>> criteria);
        int SaveItemhistoria(Itemhistoria entity);
        void UpdateItemhistoria(Itemhistoria entity);
        void DeleteItemhistoria(int id);
        List<Itemhistoria> GetAllItemhistoria();
        List<Itemhistoria> GetAllItemhistoria(Expression<Func<Itemhistoria, bool>> criteria);
        List<Itemhistoria> GetAllItemhistoria(string orders);
        List<Itemhistoria> GetAllItemhistoria(string conditions, string orders);
        Itemhistoria GetItemhistoria(int id);
        Itemhistoria GetItemhistoria(Expression<Func<Itemhistoria, bool>> criteria);

        #endregion

        #region Plantillahistoria service

        long CountPlantillahistoria();
        long CountPlantillahistoria(Expression<Func<Plantillahistoria, bool>> criteria);
        int SavePlantillahistoria(Plantillahistoria entity);
        void UpdatePlantillahistoria(Plantillahistoria entity);
        void DeletePlantillahistoria(int id);
        List<Plantillahistoria> GetAllPlantillahistoria();
        List<Plantillahistoria> GetAllPlantillahistoria(Expression<Func<Plantillahistoria, bool>> criteria);
        List<Plantillahistoria> GetAllPlantillahistoria(string orders);
        List<Plantillahistoria> GetAllPlantillahistoria(string conditions, string orders);
        Plantillahistoria GetPlantillahistoria(int id);
        Plantillahistoria GetPlantillahistoria(Expression<Func<Plantillahistoria, bool>> criteria);

        #endregion

        #region Plantillahistoriadet service

        long CountPlantillahistoriadet();
        long CountPlantillahistoriadet(Expression<Func<Plantillahistoriadet, bool>> criteria);
        int SavePlantillahistoriadet(Plantillahistoriadet entity);
        void UpdatePlantillahistoriadet(Plantillahistoriadet entity);
        void DeletePlantillahistoriadet(int id);
        List<Plantillahistoriadet> GetAllPlantillahistoriadet();
        List<Plantillahistoriadet> GetAllPlantillahistoriadet(Expression<Func<Plantillahistoriadet, bool>> criteria);
        List<Plantillahistoriadet> GetAllPlantillahistoriadet(string orders);
        List<Plantillahistoriadet> GetAllPlantillahistoriadet(string conditions, string orders);
        Plantillahistoriadet GetPlantillahistoriadet(int id);
        Plantillahistoriadet GetPlantillahistoriadet(Expression<Func<Plantillahistoriadet, bool>> criteria);

        #endregion

        #region Tipoarchivo service

        long CountTipoarchivo();
        long CountTipoarchivo(Expression<Func<Tipoarchivo, bool>> criteria);
        int SaveTipoarchivo(Tipoarchivo entity);
        void UpdateTipoarchivo(Tipoarchivo entity);
        void DeleteTipoarchivo(int id);
        List<Tipoarchivo> GetAllTipoarchivo();
        List<Tipoarchivo> GetAllTipoarchivo(Expression<Func<Tipoarchivo, bool>> criteria);
        List<Tipoarchivo> GetAllTipoarchivo(string orders);
        List<Tipoarchivo> GetAllTipoarchivo(string conditions, string orders);
        Tipoarchivo GetTipoarchivo(int id);
        Tipoarchivo GetTipoarchivo(Expression<Func<Tipoarchivo, bool>> criteria);

        #endregion

        #region Tipohistoria service

        long CountTipohistoria();
        long CountTipohistoria(Expression<Func<Tipohistoria, bool>> criteria);
        int SaveTipohistoria(Tipohistoria entity);
        void UpdateTipohistoria(Tipohistoria entity);
        void DeleteTipohistoria(int id);
        List<Tipohistoria> GetAllTipohistoria();
        List<Tipohistoria> GetAllTipohistoria(Expression<Func<Tipohistoria, bool>> criteria);
        List<Tipohistoria> GetAllTipohistoria(string orders);
        List<Tipohistoria> GetAllTipohistoria(string conditions, string orders);
        Tipohistoria GetTipohistoria(int id);
        Tipohistoria GetTipohistoria(Expression<Func<Tipohistoria, bool>> criteria);

        #endregion

        #region VwHistoria service

        long CountVwHistoria();
        long CountVwHistoria(Expression<Func<VwHistoria, bool>> criteria);
        List<VwHistoria> GetAllVwHistoria();
        List<VwHistoria> GetAllVwHistoria(Expression<Func<VwHistoria, bool>> criteria);
        List<VwHistoria> GetAllVwHistoria(string orders);
        List<VwHistoria> GetAllVwHistoria(string conditions, string orders);
        VwHistoria GetVwHistoria(int id);
        VwHistoria GetVwHistoria(Expression<Func<VwHistoria, bool>> criteria);

        #endregion

        #region VwHistoriaarchivo service

        long CountVwHistoriaarchivo();
        long CountVwHistoriaarchivo(Expression<Func<VwHistoriaarchivo, bool>> criteria);
        List<VwHistoriaarchivo> GetAllVwHistoriaarchivo();
        List<VwHistoriaarchivo> GetAllVwHistoriaarchivo(Expression<Func<VwHistoriaarchivo, bool>> criteria);
        List<VwHistoriaarchivo> GetAllVwHistoriaarchivo(string orders);
        List<VwHistoriaarchivo> GetAllVwHistoriaarchivo(string conditions, string orders);
        VwHistoriaarchivo GetVwHistoriaarchivo(int id);
        VwHistoriaarchivo GetVwHistoriaarchivo(Expression<Func<VwHistoriaarchivo, bool>> criteria);

        #endregion

        #region VwHistoriadet service

        long CountVwHistoriadet();
        long CountVwHistoriadet(Expression<Func<VwHistoriadet, bool>> criteria);
        List<VwHistoriadet> GetAllVwHistoriadet();
        List<VwHistoriadet> GetAllVwHistoriadet(Expression<Func<VwHistoriadet, bool>> criteria);
        List<VwHistoriadet> GetAllVwHistoriadet(string orders);
        List<VwHistoriadet> GetAllVwHistoriadet(string conditions, string orders);
        VwHistoriadet GetVwHistoriadet(int id);
        VwHistoriadet GetVwHistoriadet(Expression<Func<VwHistoriadet, bool>> criteria);

        #endregion

        #region VwHistoriadetitem service

        long CountVwHistoriadetitem();
        long CountVwHistoriadetitem(Expression<Func<VwHistoriadetitem, bool>> criteria);
        List<VwHistoriadetitem> GetAllVwHistoriadetitem();
        List<VwHistoriadetitem> GetAllVwHistoriadetitem(Expression<Func<VwHistoriadetitem, bool>> criteria);
        List<VwHistoriadetitem> GetAllVwHistoriadetitem(string orders);
        List<VwHistoriadetitem> GetAllVwHistoriadetitem(string conditions, string orders);
        VwHistoriadetitem GetVwHistoriadetitem(int id);
        VwHistoriadetitem GetVwHistoriadetitem(Expression<Func<VwHistoriadetitem, bool>> criteria);

        #endregion

        #region VwItemhistoria service

        long CountVwItemhistoria();
        long CountVwItemhistoria(Expression<Func<VwItemhistoria, bool>> criteria);
        List<VwItemhistoria> GetAllVwItemhistoria();
        List<VwItemhistoria> GetAllVwItemhistoria(Expression<Func<VwItemhistoria, bool>> criteria);
        List<VwItemhistoria> GetAllVwItemhistoria(string orders);
        List<VwItemhistoria> GetAllVwItemhistoria(string conditions, string orders);
        VwItemhistoria GetVwItemhistoria(int id);
        VwItemhistoria GetVwItemhistoria(Expression<Func<VwItemhistoria, bool>> criteria);

        #endregion

        #region VwPlantillahistoria service

        long CountVwPlantillahistoria();
        long CountVwPlantillahistoria(Expression<Func<VwPlantillahistoria, bool>> criteria);
        List<VwPlantillahistoria> GetAllVwPlantillahistoria();
        List<VwPlantillahistoria> GetAllVwPlantillahistoria(Expression<Func<VwPlantillahistoria, bool>> criteria);
        List<VwPlantillahistoria> GetAllVwPlantillahistoria(string orders);
        List<VwPlantillahistoria> GetAllVwPlantillahistoria(string conditions, string orders);
        VwPlantillahistoria GetVwPlantillahistoria(int id);
        VwPlantillahistoria GetVwPlantillahistoria(Expression<Func<VwPlantillahistoria, bool>> criteria);

        #endregion

        #region VwPlantillahistoriadet service

        long CountVwPlantillahistoriadet();
        long CountVwPlantillahistoriadet(Expression<Func<VwPlantillahistoriadet, bool>> criteria);
        List<VwPlantillahistoriadet> GetAllVwPlantillahistoriadet();
        List<VwPlantillahistoriadet> GetAllVwPlantillahistoriadet(Expression<Func<VwPlantillahistoriadet, bool>> criteria);
        List<VwPlantillahistoriadet> GetAllVwPlantillahistoriadet(string orders);
        List<VwPlantillahistoriadet> GetAllVwPlantillahistoriadet(string conditions, string orders);
        VwPlantillahistoriadet GetVwPlantillahistoriadet(int id);
        VwPlantillahistoriadet GetVwPlantillahistoriadet(Expression<Func<VwPlantillahistoriadet, bool>> criteria);

        #endregion
        #endregion

        #region Movil
        #region Clase service

        long CountClase();
        long CountClase(Expression<Func<Clase, bool>> criteria);
        int SaveClase(Clase entity);
        void UpdateClase(Clase entity);
        void DeleteClase(int id);
        List<Clase> GetAllClase();
        List<Clase> GetAllClase(Expression<Func<Clase, bool>> criteria);
        List<Clase> GetAllClase(string orders);
        List<Clase> GetAllClase(string conditions, string orders);
        Clase GetClase(int id);
        Clase GetClase(Expression<Func<Clase, bool>> criteria);

        #endregion

        #region Plan service

        long CountPlan();
        long CountPlan(Expression<Func<Plan, bool>> criteria);
        int SavePlan(Plan entity);
        void UpdatePlan(Plan entity);
        void DeletePlan(int id);
        List<Plan> GetAllPlan();
        List<Plan> GetAllPlan(Expression<Func<Plan, bool>> criteria);
        List<Plan> GetAllPlan(string orders);
        List<Plan> GetAllPlan(string conditions, string orders);
        Plan GetPlan(int id);
        Plan GetPlan(Expression<Func<Plan, bool>> criteria);

        #endregion

        #region Tipo service

        long CountTipo();
        long CountTipo(Expression<Func<Tipo, bool>> criteria);
        int SaveTipo(Tipo entity);
        void UpdateTipo(Tipo entity);
        void DeleteTipo(int id);
        List<Tipo> GetAllTipo();
        List<Tipo> GetAllTipo(Expression<Func<Tipo, bool>> criteria);
        List<Tipo> GetAllTipo(string orders);
        List<Tipo> GetAllTipo(string conditions, string orders);
        Tipo GetTipo(int id);
        Tipo GetTipo(Expression<Func<Tipo, bool>> criteria);

        #endregion

        #region Tipotope service

        long CountTipotope();
        long CountTipotope(Expression<Func<Tipotope, bool>> criteria);
        int SaveTipotope(Tipotope entity);
        void UpdateTipotope(Tipotope entity);
        void DeleteTipotope(int id);
        List<Tipotope> GetAllTipotope();
        List<Tipotope> GetAllTipotope(Expression<Func<Tipotope, bool>> criteria);
        List<Tipotope> GetAllTipotope(string orders);
        List<Tipotope> GetAllTipotope(string conditions, string orders);
        Tipotope GetTipotope(int id);
        Tipotope GetTipotope(Expression<Func<Tipotope, bool>> criteria);

        #endregion

        #endregion

    }
}
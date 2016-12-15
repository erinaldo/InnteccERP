using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool NumeroOrdendeventaExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            var ordenventa = OrdendeventaDao.Get(x => x.Idsucursal == idSucursal
                          && x.Idtipocp == idTipoCp
                          && x.Serieordenventa == numeroSerie
                          && x.Numeroordenventa == numeroDocumento);
            return ordenventa != null;
        }

        public bool GuardarOrdendeVenta(TipoMantenimiento tipoMantenimiento, Ordendeventa entidadCab, List<VwOrdendeventadet> entidadDetList)
        {
            return OrdendeventaDao.GuardarOrdendeVenta(tipoMantenimiento, entidadCab, entidadDetList);
        }

        public bool OrdenVentaTieneReferenciaCpventa(int idOrdenVenta)
        {
            return VwCpventadetDao.Count(x => x.Idordendeventa == idOrdenVenta) > 0;
        }

        public bool OrdenVentaTieneReferenciaValorizacion(int idOrdenVenta)
        {
            return VwValorizacionDao.Count(x => x.Idordendeventa == idOrdenVenta) > 0;
        }
    }
}
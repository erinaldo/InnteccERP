using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarOrdenDeServicio(TipoMantenimiento tipoMantenimiento, Ordenservicio entidadCab, List<VwOrdenserviciodet> entidadDetList)
        {
            return OrdenservicioDao.GuardarOrdenDeServicio(tipoMantenimiento, entidadCab, entidadDetList);
        }

        public bool NumeroOrdenServicioExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            var ordenservicio = OrdenservicioDao.Get(x => x.Idsucursal == idSucursal
                  && x.Idtipocp == idTipoCp
                  && x.Serieorden == numeroSerie
                  && x.Numeroorden == numeroDocumento);
            return ordenservicio != null;
        }

        public bool OrdenServicioTieneReferenciaCpCompra(int idOrdenServicio)
        {
            return VwCpcompradetDao.Count(x => x.Idordenservicio == idOrdenServicio) > 0;
        }
    }
}
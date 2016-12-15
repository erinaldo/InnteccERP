using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool NumeroOrdenCompraExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            var ordencompra = OrdencompraDao.Get(x => x.Idsucursal  == idSucursal
                              && x.Idtipocp == idTipoCp
                              && x.Serieorden == numeroSerie
                              && x.Numeroorden == numeroDocumento);
            return ordencompra != null;
        }

        public bool GuardarOrdenDeCompra(TipoMantenimiento tipoMantenimiento, Ordencompra entidadCab, List<VwOrdencompradet> entidadDetList)
        {
            return OrdencompraDao.GuardarOrdenDeCompra(tipoMantenimiento, entidadCab, entidadDetList);
        }

        public bool OrdenCompraTieneReferenciaEntradaAlmacen(int idOrdenCompra)
        {
            return VwEntradaalmacendetDao.Count(x => x.Idordencompra == idOrdenCompra) > 0;
        }
    }
}
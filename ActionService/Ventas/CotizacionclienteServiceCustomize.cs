using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class  Service
    {
        public bool NumeroCotizacionClienteExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            var cotizacliente = CotizacionclienteDao.Get(x => x.Idsucursal == idSucursal
                            && x.Idtipocp == idTipoCp
                            && x.Seriecotizacion == numeroSerie
                            && x.Numerocotizacion == numeroDocumento);
            return cotizacliente != null;
        }

        public bool CotizacionClienteTieneReferenciaOrdenVenta(int idCotizacioncliente)
        {
            return VwOrdendeventadetalleDao.Count(x => x.Idcotizacioncliente == idCotizacioncliente) > 0;
        }

        public bool GuardarCotizacionCliente(TipoMantenimiento tipoMantenimiento, Cotizacioncliente entidadCab, List<VwCotizacionclientedet> entidadDetList)
        {
            return CotizacionclienteDao.GuardarCotizacionCliente(tipoMantenimiento, entidadCab, entidadDetList);
        }
    }
}
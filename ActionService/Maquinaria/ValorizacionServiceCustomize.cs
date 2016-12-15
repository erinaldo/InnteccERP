using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool NumeroValorizacionExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            var valoriza = ValorizacionDao.Get(x => x.Idsucursal == idSucursal
                           && x.Idtipocp == idTipoCp
                           && x.Serievalorizacion == numeroSerie
                           && x.Numerovalorizacion == numeroDocumento);
            return valoriza != null;
        }

        public bool GuardarValorizacion(TipoMantenimiento tipoMantenimiento, Valorizacion entidadCab, List<VwValorizaciondet> entidadDetList)
        {
            return ValorizacionDao.GuardarValorizacion(tipoMantenimiento, entidadCab, entidadDetList);
        }

        public bool ValorizacionTieneReferenciaCpventa(int idValorizacion)
        {
            return VwCpventadetDao.Count(x => x.Idvalorizacion == idValorizacion && !x.Anulado) > 0;
        }
    }
}
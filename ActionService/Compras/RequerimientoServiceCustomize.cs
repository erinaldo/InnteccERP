using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool NumeroRequerimientoExiste(int idSucursal, int idTipoCp, string numeroSerie, string numeroDocumento)
        {
            var requerimiento = RequerimientoDao.Get(x => x.Idsucursal   == idSucursal
                  && x.Idtipocp == idTipoCp
                  && x.Seriereq == numeroSerie
                  && x.Numeroreq == numeroDocumento);
            return requerimiento != null;
        }

        public bool GuardarRequerimiento(TipoMantenimiento tipoMantenimiento, Requerimiento entidadCab, List<VwRequerimientodet> entidadDetList)
        {
            return RequerimientoDao.GuardarRequerimiento(tipoMantenimiento, entidadCab, entidadDetList);
        }

        public bool RequerimientoAprobado(int idrequerimiento)
        {
            //Id Estado = 3 (Aprobado)
            Requerimiento requerimiento = RequerimientoDao.Get(x => x.Idrequerimiento == idrequerimiento && x.Idestadoreq == 3);
            return requerimiento != null;
        }

        public bool RequerimientoTieneReferenciasOrdenDeCompra(int idRequerimiento)
        {
            return RequerimientoDao.RequerimientoTieneReferenciasOrdenDeCompra(idRequerimiento);
        }

        public Estadoreq GetEstadoRequerimiento(int idRequerimiento)
        {
            Estadoreq estadoreq = null;
            Requerimiento requerimiento = RequerimientoDao.Get(x => x.Idrequerimiento == idRequerimiento);
            if (requerimiento != null)
            {
                estadoreq = EstadoreqDao.Get(x => x.Idestadoreq == requerimiento.Idestadoreq);
            }
            return estadoreq;

        }
    }
}
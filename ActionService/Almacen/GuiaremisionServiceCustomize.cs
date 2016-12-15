using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarGuiaremision(TipoMantenimiento tipoMantenimiento, Guiaremision entidadCab, List<VwGuiaremisiondet> entidadDetList)
        {
            return GuiaremisionDao.GuardarGuiaremision(tipoMantenimiento, entidadCab, entidadDetList);
        }

        public bool GuiaRemisionTieneReferenciaSalidaAlmacen(int idGuiaRemision)
        {
            return VwSalidaalmacendetDao.Count(x => x.Idguiaremision == idGuiaRemision && !x.Anulado) > 0;
        }
    }
}
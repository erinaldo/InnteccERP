using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarNotaCreditoCli(TipoMantenimiento tipoMantenimiento, Notacreditocli entidadCab, List<VwNotacreditoclidet> entidadDetList)
        {
            return NotacreditocliDao.GuardarNotaCreditoCli(tipoMantenimiento, entidadCab, entidadDetList);
        }
    }
}
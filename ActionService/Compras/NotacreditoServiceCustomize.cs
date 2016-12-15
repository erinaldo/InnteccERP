using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarNotacredito(TipoMantenimiento tipoMantenimiento, Notacredito entidadCab, List<VwNotacreditodet> entidadDetList)
        {
            return NotacreditoDao.GuardarNotacredito(tipoMantenimiento, entidadCab, entidadDetList);
        }
    }
}
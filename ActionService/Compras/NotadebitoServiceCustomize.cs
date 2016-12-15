using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarNotadebito(TipoMantenimiento tipoMantenimiento, Notadebito entidadCab, List<VwNotadebitodet> entidadDetList)
        {
            return NotadebitoDao.GuardarNotadebito(tipoMantenimiento, entidadCab, entidadDetList);
        }
    }
}
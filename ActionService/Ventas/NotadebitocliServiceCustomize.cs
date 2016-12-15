using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarNotaDebitoCli(TipoMantenimiento tipoMantenimiento, Notadebitocli entidadCab, List<VwNotadebitoclidet> entidadDetList)
        {
            return NotadebitocliDao.GuardarNotaDebitoCli(tipoMantenimiento, entidadCab, entidadDetList);
        }
    }
}
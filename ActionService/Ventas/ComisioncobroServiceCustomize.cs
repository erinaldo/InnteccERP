using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarComisionCobro(TipoMantenimiento tipoMantenimiento, Comisioncobro entidadCab, List<Comisioncobrodet> entidadDetList)
        {
            return ComisioncobroDao.GuardarComisionCobro(tipoMantenimiento, entidadCab, entidadDetList);
        }
    }
}
using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarCierrecaja(TipoMantenimiento tipoMantenimiento, Cierrecaja entidadCab, List<VwCierrecajadet> elementoDetList)
        {
            return CierrecajaDao.GuardarCierrecaja(tipoMantenimiento, entidadCab, elementoDetList);
        }
    }
}
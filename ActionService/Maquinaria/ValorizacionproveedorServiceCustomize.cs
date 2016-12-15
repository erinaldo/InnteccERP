using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool GuardarValorizacionProveedor(TipoMantenimiento tipoMantenimiento, Valorizacionproveedor entidadCab, List<VwValorizacionproveedordet> entidadDetList)
        {
            return ValorizacionproveedorDao.GuardarValorizacionProveedor(tipoMantenimiento, entidadCab, entidadDetList);
        }
    }
}
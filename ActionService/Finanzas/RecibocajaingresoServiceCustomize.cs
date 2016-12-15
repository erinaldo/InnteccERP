using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public bool ActualizarTotalesReciboCajaIngreso(Recibocajaingreso recibocajaingreso)
        {
            return RecibocajaingresoDao.ActualizarTotalesReciboCajaIngreso(recibocajaingreso);
        }

        public int GuardarReciboCajaIngreso(TipoMantenimiento tipoMantenimiento, int idCpVenta, Recibocajaingreso recibocajaingreso,List<VwRecibocajaingresodet> vWrecibocajaingresodetList)
        {
            return RecibocajaingresoDao.GuardarReciboCajaIngreso(tipoMantenimiento, idCpVenta, recibocajaingreso,vWrecibocajaingresodetList);
        }
    }
}
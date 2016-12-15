using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ICpventaDao : IDao<Cpventa>
	{
        bool GuardarCpVenta(TipoMantenimiento tipoMantenimiento, Cpventa entidadCab, List<VwCpventadet> entidadDetList, List<VwGuiaremisiondetimpcpventadet> vwGuiaremisiondetimpcpventadetImpList);
        int GuardarCpVentaReciboIngreso(TipoMantenimiento tipoMantenimiento, Cpventa entidadCab, List<VwCpventadet> entidadDetList, Recibocajaingreso recibocajaingreso, List<VwRecibocajaingresodet> vWrecibocajaingresodetList);
	}
}

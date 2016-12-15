using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IRecibocajaingresoDao : IDao<Recibocajaingreso>
	{
        bool ActualizarTotalesReciboCajaIngreso(Recibocajaingreso recibocajaingreso);

	    int GuardarReciboCajaIngreso(TipoMantenimiento tipoMantenimiento,int idCpVenta, Recibocajaingreso recibocajaingreso,List<VwRecibocajaingresodet> vWrecibocajaingresodetList);
	}
}

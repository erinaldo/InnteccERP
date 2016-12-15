using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IRecibocajaegresoDao : IDao<Recibocajaegreso>
	{
        bool ActualizarTotalesReciboCajaEgreso(Recibocajaegreso recibocajaegreso);
	}
}

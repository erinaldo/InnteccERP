using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ISalidaalmacenDao : IDao<Salidaalmacen>
	{
	    bool ActualizarTotalesSalidaAlmacen(Salidaalmacen salidaalmacen);
	}
}

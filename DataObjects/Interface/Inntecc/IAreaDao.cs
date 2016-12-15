using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IAreaDao : IDao<Area>
	{
	    string GetSiguienteCodigoArea(int idSucursal);
	}
}

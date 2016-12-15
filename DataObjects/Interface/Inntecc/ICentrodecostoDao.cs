using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ICentrodecostoDao : IDao<Centrodecosto>
	{
        string GetSiguienteCodigoCentroDeCosto(int idSucursal);
	}
}

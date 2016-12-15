using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ISeriearticuloDao : IDao<Seriearticulo>
	{
	    bool EstablecerSerieUtilizada(int idseriearticulo, bool serieutilizada);
	}
}

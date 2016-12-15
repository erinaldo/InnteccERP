using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IOrdencompradetDao : IDao<Ordencompradet>
	{
	    Ordencompradet UltimoRegistroOrdenCompraDet();
	}
}

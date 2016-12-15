using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ICuadrocomparativoprvDao : IDao<Cuadrocomparativoprv>
	{
	    bool ActualizarTotalCuadroComparativoPrv(int idcuadrocomparativoprv, decimal totalDocumento);
        bool ActualizarItemBuenaProCuadroComparativoPrv(int idcuadrocomparativoprv, bool buenapro);
	}
}

using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ICuadrocomparativoDao : IDao<Cuadrocomparativo>
	{
        void AnularReferenciaCotizacionPrvCuadroComparativo(int idcuadrocomparativo);
	}
}

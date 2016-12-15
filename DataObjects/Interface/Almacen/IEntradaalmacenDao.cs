using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IEntradaalmacenDao : IDao<Entradaalmacen>
	{
        void AnularReferenciaEntradaOrdenCompraDet(int identradaalmacen);
        bool ActualizarTotalesEntradaAlmacen(Entradaalmacen entradaalmacen);
	}
}

using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IEntradaalmacendetDao : IDao<Entradaalmacendet>
	{
        void ActualizarEntradaalmacendetCantidadVerificada(Entradaalmacendet entradaalmacendet);
	}
}

using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IRendicioncajachicaDao : IDao<Rendicioncajachica>
	{
        bool ActualizarTotalesRendicionCajaChica(Rendicioncajachica rendicioncajachica);
	}
}

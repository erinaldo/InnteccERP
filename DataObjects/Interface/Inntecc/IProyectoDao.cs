using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IProyectoDao : IDao<Proyecto>
	{
        string GetSiguienteCodigoProyecto(int idEmpresa);
	}
}

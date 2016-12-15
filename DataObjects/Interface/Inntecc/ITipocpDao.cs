using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ITipocpDao : IDao<Tipocp>
	{
        string GetSiguienteCodigoTipoCp();
        bool ActualizarCorrelativo(int idtipocp, int sgtNumerocorrelativocp);
	}
}

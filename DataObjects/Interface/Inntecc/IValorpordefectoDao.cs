using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IValorpordefectoDao : IDao<Valorpordefecto>
	{
	    bool RegistrarObjectoValoresPorDefecto(int idSucursal, int idEmpleado, string nombreTipodocMov,int idTipoCpPorDefecto, int idCptoOperacionPorDefecto);
	}
}

using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IVwModeloautorizacioninfoDao : IDao<VwModeloautorizacioninfo>
	{
	    int ObtenerIdEmpleadoApruebaModeloAutorizacion(int idtipodocmov, int idcptooperacion, decimal importeDocumento);
	}
}

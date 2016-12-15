using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class VwModeloautorizacioninfoDao : Dao<VwModeloautorizacioninfo>, IVwModeloautorizacioninfoDao
	{
        public int ObtenerIdEmpleadoApruebaModeloAutorizacion(int idtipodocmov, int  idcptooperacion, decimal importeDocumento)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                string sql = string.Format(@"SELECT idempleado,ordenautorizacion
                                            FROM inntecc.vwmodeloautorizacioninfo where idtipodocmov = {0} and requiereautorizacion = '1'
                                            and {1} BETWEEN valor1 AND valor2 and idcptooperacion = {2} ORDER BY ordenautorizacion DESC limit 1", idtipodocmov, importeDocumento, idcptooperacion);
                return db.SqlScalar<int>(sql);
            }
	    }
	}
}

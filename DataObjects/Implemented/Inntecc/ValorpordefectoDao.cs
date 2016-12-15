using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class ValorpordefectoDao : Dao<Valorpordefecto>, IValorpordefectoDao
	{
	    public bool RegistrarObjectoValoresPorDefecto(int idSucursal, int idEmpleado, string nombreTipodocMov, int idTipoCpPorDefecto, int idCptoOperacionPorDefecto)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {

                db.Delete<Valorpordefecto>(x =>
                    x.Idsucursal == idSucursal
                    && x.Idempleado == idEmpleado
                    && x.Nombretipodocmov == nombreTipodocMov);

                Valorpordefecto valorpordefecto = new Valorpordefecto
                {
                    Idsucursal = idSucursal,
                    Idtipocp = idTipoCpPorDefecto,
                    Idcptooperacion = idCptoOperacionPorDefecto,
                    Idempleado = idEmpleado,
                    Nombretipodocmov = nombreTipodocMov
                };

                db.Save(valorpordefecto);

                return true;
            }
	    }
	}
}

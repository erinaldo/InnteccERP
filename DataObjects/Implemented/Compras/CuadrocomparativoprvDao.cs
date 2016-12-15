using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class CuadrocomparativoprvDao : Dao<Cuadrocomparativoprv>, ICuadrocomparativoprvDao
	{
	    public bool ActualizarTotalCuadroComparativoPrv(int idcuadrocomparativoprv, decimal totalDocumento)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Update<Cuadrocomparativoprv>(new { Totaldocumento = totalDocumento }, p => p.Idcuadrocomparativoprv == idcuadrocomparativoprv);
                return true;
            }
	    }

	    public bool ActualizarItemBuenaProCuadroComparativoPrv(int idcuadrocomparativoprv, bool buenapro)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Update<Cuadrocomparativoarticulo>(new { Buenapro = buenapro }, p => p.Idcuadrocomparativoprv == idcuadrocomparativoprv);
                return true;
            }
	    }
	}
}

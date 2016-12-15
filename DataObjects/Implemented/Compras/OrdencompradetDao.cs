using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class OrdencompradetDao : Dao<Ordencompradet>, IOrdencompradetDao
	{
	    public Ordencompradet UltimoRegistroOrdenCompraDet()
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                int lastRow =
                    db.Scalar<int>(
                        "select max(idordencompradet) from compras.ordencompradet");
                return db.SingleById<Ordencompradet>(lastRow);
            }
	    }
	}
}

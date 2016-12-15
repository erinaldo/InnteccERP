using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class DocumentoaprobacionDao : Dao<Documentoaprobacion>, IDocumentoaprobacionDao
	{
	    public bool EliminarReferenciasDocumentoAprobacion(int idtipodocmov, int iddocumentomov)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Delete<Documentoaprobacion>(x =>
                x.Idtipodocmov == idtipodocmov
                && x.Iddocumentomov == iddocumentomov);
                return true;
            }
	    }
	}
}

using System.Data;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class EntradaalmacenDao : Dao<Entradaalmacen>, IEntradaalmacenDao
	{
        public void AnularReferenciaEntradaOrdenCompraDet(int identradaalmacen)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    string sqlUpdate =
                        string.Format(
                            "update almacen.entradaalmacendet set idordencompradet = null where identradaalmacen = {0}",
                            identradaalmacen);
                    db.ExecuteNonQuery(sqlUpdate);
                    trans.Commit();
                }
            }
	    }

	    public bool ActualizarTotalesEntradaAlmacen(Entradaalmacen entradaalmacen)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Update<Entradaalmacen>(new
                {
                    entradaalmacen.Totalbruto,
                    entradaalmacen.Totalgravado,
                    entradaalmacen.Totalinafecto,
                    entradaalmacen.Totalexonerado,
                    entradaalmacen.Importetotal,
                    entradaalmacen.Porcentajepercepcion,
                    entradaalmacen.Importetotalpercepcion,
                    entradaalmacen.Totaldocumento,
                    entradaalmacen.Totalimpuesto
                }, p => p.Identradaalmacen == entradaalmacen.Identradaalmacen);
                return true;
            }
	    }
	}
}

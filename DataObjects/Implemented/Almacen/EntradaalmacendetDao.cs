using System.Diagnostics;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class EntradaalmacendetDao : Dao<Entradaalmacendet>, IEntradaalmacendetDao
	{
        public void ActualizarEntradaalmacendetCantidadVerificada(Entradaalmacendet entradaalmacendet)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {

                db.Update<Entradaalmacendet>(new { entradaalmacendet.Cantidadverificada }, p => p.Identradaalmacendet == entradaalmacendet.Identradaalmacendet);
                Debug.WriteLine(db.GetLastSql());
            }
        }
	}
}

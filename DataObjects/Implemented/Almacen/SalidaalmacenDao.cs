using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class SalidaalmacenDao : Dao<Salidaalmacen>, ISalidaalmacenDao
	{
	    public bool ActualizarTotalesSalidaAlmacen(Salidaalmacen salidaalmacen)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Update<Salidaalmacen>(new { 
                    salidaalmacen.Totalbruto,
                    salidaalmacen.Totalgravado,
                    salidaalmacen.Totalinafecto,
                    salidaalmacen.Totalexonerado,
                    salidaalmacen.Importetotal,
                    salidaalmacen.Porcentajepercepcion,
                    salidaalmacen.Importetotalpercepcion,
                    salidaalmacen.Totaldocumento,
                    salidaalmacen.Totalimpuesto
                }, p => p.Idsalidaalmacen == salidaalmacen.Idsalidaalmacen);
                return true;
            }
	    }
	}
}

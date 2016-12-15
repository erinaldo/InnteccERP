using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class RecibocajaegresoDao : Dao<Recibocajaegreso>, IRecibocajaegresoDao
	{
	    public bool ActualizarTotalesReciboCajaEgreso(Recibocajaegreso recibocajaegreso)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Update<Recibocajaegreso>(new
                {
                    recibocajaegreso.Totaldocumento
                }, p => p.Idrecibocajaegreso == recibocajaegreso.Idrecibocajaegreso);


                ////Anular detalle de recibo
                //if (recibocajaegreso.Anulado)
                //{
                //    //Anular referencias
                //    db.UpdateOnly(new Recibocajaegresodet()
                //    {
                //        Idcpcompra = null
                //    },
                //    f => new
                //    {
                //        f.Idcpcompra
                //    }, w => w.Idrecibocajaegreso == recibocajaegreso.Idrecibocajaegreso);
                //}

                return true;


            }
	    }
	}
}

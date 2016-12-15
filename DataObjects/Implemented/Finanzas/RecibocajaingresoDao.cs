using System;
using System.Collections.Generic;
using System.Data;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class RecibocajaingresoDao : Dao<Recibocajaingreso>, IRecibocajaingresoDao
	{
	    public bool ActualizarTotalesReciboCajaIngreso(Recibocajaingreso recibocajaingreso)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Update<Recibocajaingreso>(new
                {
                    recibocajaingreso.Totaldocumento
                }, p => p.Idrecibocajaingreso == recibocajaingreso.Idrecibocajaingreso);



                //Anular detalle de recibo
                if (recibocajaingreso.Anulado)
                {
                    //Anular referencias
                    db.UpdateOnly(new Recibocajaingresodet()
                    {
                        Idcpventa = null
                    },
                    f => new
                    {
                        f.Idcpventa
                    }, w => w.Idrecibocajaingreso == recibocajaingreso.Idrecibocajaingreso);
                }

                return true;
            }
	    }

	    public int GuardarReciboCajaIngreso(TipoMantenimiento tipoMantenimiento, int idCpVenta, Recibocajaingreso recibocajaingreso, List<VwRecibocajaingresodet> vWrecibocajaingresodetList)
	    {
	        using (var db = OrmLiteHelper.DbFactory.Open())
	        {
	            using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
	            {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(recibocajaingreso);
                            if (recibocajaingreso.Idrecibocajaingreso > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(recibocajaingreso.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(recibocajaingreso.Numerorecibo) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(recibocajaingreso);
                            break;
                    }

                    if (recibocajaingreso.Idrecibocajaingreso > 0)
                    {
                        foreach (var item in vWrecibocajaingresodetList)
                        {
                            Recibocajaingresodet recibocajaingresodet = new Recibocajaingresodet();

                            recibocajaingresodet.Idrecibocajaingresodet = 0;
                            recibocajaingresodet.Idrecibocajaingreso = recibocajaingreso.Idrecibocajaingreso;
                            recibocajaingresodet.Importepago = item.Importepago;
                            recibocajaingresodet.Idmediopago = item.Idmediopago;
                            recibocajaingresodet.Numeromediopago = item.Numeromediopago;
                            recibocajaingresodet.Numeroitem = item.Numeroitem;
                            recibocajaingresodet.Comentario = item.Comentario;
                            recibocajaingresodet.Idcpventa = idCpVenta;
                            recibocajaingresodet.Idnotacreditocli = item.Idnotacreditocli;
                            recibocajaingresodet.Importenc = item.Importenc;


                            //Nuevo
                            if (item.Idrecibocajaingresodet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(recibocajaingresodet);
                                item.Idrecibocajaingresodet = recibocajaingresodet.Idrecibocajaingresodet;
                            }
                        }
                    }

                    trans.Commit();
                    return recibocajaingreso.Idrecibocajaingreso;
	            }
	        }
	    }
	}
}

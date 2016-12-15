using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class ValorizacionDao : Dao<Valorizacion>, IValorizacionDao
	{
	    public bool GuardarValorizacion(TipoMantenimiento tipoMantenimiento, Valorizacion entidadCab, List<VwValorizaciondet> entidadDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idvalorizacion > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numerovalorizacion) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idvalorizacion > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Valorizaciondet valorizaciondet = new Valorizaciondet();

                            valorizaciondet.Idvalorizaciondet = item.Idvalorizaciondet;
                            valorizaciondet.Idvalorizacion = entidadCab.Idvalorizacion;
                            valorizaciondet.Numeroitem = item.Numeroitem;
                            valorizaciondet.Fecha = item.Fecha;
                            valorizaciondet.Turno = item.Turno;
                            valorizaciondet.Horometroinicio = item.Horometroinicio;
                            valorizaciondet.Horometrofinal = item.Horometrofinal;
                            valorizaciondet.Horometrodia = item.Horometrodia;
                            valorizaciondet.Descuentohorometro = item.Descuentohorometro;
                            valorizaciondet.Horometrorealdia = item.Horometrodia;
                            valorizaciondet.Horometrominimo = item.Horometrominimo;
                            valorizaciondet.Diastrabajo = item.Diastrabajo;
                            valorizaciondet.Idcentrodecosto = item.Idcentrodecosto;
                            valorizaciondet.Observaciones = item.Observaciones;


                            //ordencompradet.Createdby = item.Createdby;
                            //ordencompradet.Creationdate = item.Creationdate;
                            //ordencompradet.Modifiedby = item.Modifiedby;
                            //ordencompradet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idvalorizaciondet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(valorizaciondet);
                                item.Idvalorizaciondet = valorizaciondet.Idvalorizaciondet;
                            }

                            //Modificar
                            if (item.Idvalorizaciondet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(valorizaciondet);
                            }

                            //Eliminar
                            if (item.Idvalorizaciondet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Valorizaciondet>(item.Idvalorizaciondet);
                            }
                        }
                    }
                    //Verificar si hubo cambios en el orden de items
                    int cntNoOrden = 0;
                    int nItemInicial = 0;
                    foreach (var item in entidadDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                    {
                        if (nItemInicial + 1 != item.Numeroitem)
                        {
                            cntNoOrden++;
                        }
                        nItemInicial = item.Numeroitem;
                    }

                    if (cntNoOrden > 0)
                    {
                        int numeroItem = 1;
                        //Reenumerar y actualizar solo el nro de item
                        foreach (var item in entidadDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            item.Numeroitem = numeroItem;
                            Valorizaciondet crdendeventadetalle = new Valorizaciondet
                            {
                                Numeroitem = item.Numeroitem,
                                Idvalorizaciondet = item.Idvalorizaciondet
                            };
                            db.Update<Valorizaciondet>(new { crdendeventadetalle.Numeroitem },
                                p => p.Idvalorizaciondet == crdendeventadetalle.Idvalorizaciondet);
                            numeroItem++;
                        }
                    }

                    trans.Commit();
                    return true;
                }
            }
	    }
	}
}

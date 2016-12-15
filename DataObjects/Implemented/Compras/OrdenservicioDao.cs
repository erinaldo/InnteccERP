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
	public class OrdenservicioDao : Dao<Ordenservicio>, IOrdenservicioDao
	{
	    public bool GuardarOrdenDeServicio(TipoMantenimiento tipoMantenimiento, Ordenservicio entidadCab, List<VwOrdenserviciodet> entidadDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idordenservicio > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numeroorden) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    //int numeroItem = 1;
                    //foreach (var item in entidadDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                    //{
                    //    item.DataEntityState = DataEntityState.Modified;
                    //    item.Numeroitem = numeroItem;
                    //    numeroItem++;
                    //}

                    if (entidadCab.Idordenservicio > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Ordenserviciodet ordenserviciodet = new Ordenserviciodet();

                            ordenserviciodet.Idordenserviciodet = item.Idordenserviciodet;
                            ordenserviciodet.Idordenservicio = entidadCab.Idordenservicio;
                            ordenserviciodet.Numeroitem = item.Numeroitem;
                            ordenserviciodet.Idarticulo = item.Idarticulo;
                            ordenserviciodet.Cantidad = item.Cantidad;
                            ordenserviciodet.Idunidadmedida = item.Idunidadmedida;
                            ordenserviciodet.Preciounitario = item.Preciounitario;
                            ordenserviciodet.Especificacion = item.Especificacion;
                            ordenserviciodet.Descuento1 = item.Descuento1;
                            ordenserviciodet.Descuento2 = item.Descuento2;
                            ordenserviciodet.Descuento3 = item.Descuento3;
                            ordenserviciodet.Descuento4 = item.Descuento4;
                            ordenserviciodet.Preciounitarioneto = item.Preciounitarioneto;
                            ordenserviciodet.Importetotal = item.Importetotal;
                            ordenserviciodet.Idimpuesto = item.Idimpuesto;
                            ordenserviciodet.Idcentrodecosto = item.Idcentrodecosto;
                            ordenserviciodet.Porcentajepercepcion = item.Porcentajepercepcion;
                            ordenserviciodet.Idrequerimientodet = item.Idrequerimientodet;
                            ordenserviciodet.Idarea = item.Idarea;
                            ordenserviciodet.Idproyecto = item.Idproyecto;
                            ordenserviciodet.Idtipoafectacionigv = item.Idtipoafectacionigv;

                            ordenserviciodet.Createdby = item.Createdby;
                            ordenserviciodet.Creationdate = item.Creationdate;
                            ordenserviciodet.Modifiedby = item.Modifiedby;
                            ordenserviciodet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idordenserviciodet  == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(ordenserviciodet);
                                item.Idordenserviciodet = ordenserviciodet.Idordenserviciodet;
                            }

                            //Modificar
                            if (item.Idordenserviciodet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(ordenserviciodet);
                            }

                            //Eliminar
                            if (item.Idordenserviciodet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Ordenserviciodet>(item.Idordenserviciodet);
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
                            Ordenserviciodet ordenserviciodet = new Ordenserviciodet
                            {
                                Numeroitem = item.Numeroitem,
                                Idordenserviciodet = item.Idordenserviciodet
                            };
                            db.Update<Ordenserviciodet>(new { ordenserviciodet.Numeroitem },
                                p => p.Idordenserviciodet == ordenserviciodet.Idordenserviciodet);
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

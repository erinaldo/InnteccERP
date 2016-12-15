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
	public class OrdendeventaDao : Dao<Ordendeventa>, IOrdendeventaDao
	{
	    public bool GuardarOrdendeVenta(TipoMantenimiento tipoMantenimiento, Ordendeventa entidadCab, List<VwOrdendeventadet> entidadDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idordendeventa > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numeroordenventa) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }


                    if (entidadCab.Idordendeventa > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Ordendeventadet ordendeventadetalle = new Ordendeventadet();

                            ordendeventadetalle.Idordendeventadet = item.Idordendeventadet;
                            ordendeventadetalle.Idordendeventa = entidadCab.Idordendeventa;
                            ordendeventadetalle.Numeroitem = item.Numeroitem;
                            ordendeventadetalle.Idarticulo = item.Idarticulo;
                            ordendeventadetalle.Cantidad = item.Cantidad;
                            ordendeventadetalle.Idunidadmedida = item.Idunidadmedida;
                            ordendeventadetalle.Preciounitario = item.Preciounitario;
                            ordendeventadetalle.Especificacion = item.Especificacion;
                            ordendeventadetalle.Descuento1 = item.Descuento1;
                            ordendeventadetalle.Descuento2 = item.Descuento2;
                            ordendeventadetalle.Descuento3 = item.Descuento3;
                            ordendeventadetalle.Descuento4 = item.Descuento4;
                            ordendeventadetalle.Preciounitarioneto = item.Preciounitarioneto;
                            ordendeventadetalle.Importetotal = item.Importetotal;
                            ordendeventadetalle.Idimpuesto = item.Idimpuesto;
                            ordendeventadetalle.Diasdeentrega = item.Diasdeentrega;
                            ordendeventadetalle.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            ordendeventadetalle.Porcentajepercepcion = item.Porcentajepercepcion;
                            ordendeventadetalle.Idalmacen = item.Idalmacen;
                            ordendeventadetalle.Idarea = item.Idarea;
                            ordendeventadetalle.Idproyecto = item.Idproyecto;
                            ordendeventadetalle.Idcentrodecosto = item.Idcentrodecosto;
                            ordendeventadetalle.Idcotizacionclientedet = item.Idcotizacionclientedet;
                            ordendeventadetalle.Calcularitem = item.Calcularitem;
                            ordendeventadetalle.Idequipo = item.Idequipo;
                            ordendeventadetalle.Numeromeses = item.Numeromeses;
                            //ordencompradet.Createdby = item.Createdby;
                            //ordencompradet.Creationdate = item.Creationdate;
                            //ordencompradet.Modifiedby = item.Modifiedby;
                            //ordencompradet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idordendeventadet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(ordendeventadetalle);
                                item.Idordendeventadet = ordendeventadetalle.Idordendeventadet;
                            }

                            //Modificar
                            if (item.Idordendeventadet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(ordendeventadetalle);
                            }

                            //Eliminar
                            if (item.Idordendeventadet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Ordendeventadet>(item.Idordendeventadet);
                            }
                        }
                    }

                    //Anular detalle de orden de venta
                    if (entidadCab.Anulado)
                    {
                        //Anular referencias
                        db.UpdateOnly(new Ordendeventadet
                        {
                            Idcotizacionclientedet = null
                        },
                        f => new
                        {
                            f.Idcotizacionclientedet
                        }, w => w.Idordendeventa == entidadCab.Idordendeventa);
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
                            Ordendeventadet crdendeventadetalle = new Ordendeventadet
                            {
                                Numeroitem = item.Numeroitem,
                                Idordendeventadet = item.Idordendeventadet
                            };
                            db.Update<Ordendeventadet>(new { crdendeventadetalle.Numeroitem },
                                p => p.Idordendeventadet == crdendeventadetalle.Idordendeventadet);
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

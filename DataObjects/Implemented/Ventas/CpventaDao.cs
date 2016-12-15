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
	public class CpventaDao : Dao<Cpventa>, ICpventaDao
	{
        public bool GuardarCpVenta(TipoMantenimiento tipoMantenimiento, Cpventa entidadCab, List<VwCpventadet> entidadDetList, List<VwGuiaremisiondetimpcpventadet> vwGuiaremisiondetimpcpventadetImpList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idcpventa  > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numerocpventa) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idcpventa  > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Cpventadet cpventadet = new Cpventadet();

                            cpventadet.Idcpventadet = item.Idcpventadet;
                            cpventadet.Idcpventa = entidadCab.Idcpventa;
                            cpventadet.Numeroitem = item.Numeroitem;
                            cpventadet.Idarticulo = item.Idarticulo;
                            cpventadet.Articulomodificado = item.Articulomodificado;
                            cpventadet.Nombrearticulo = item.Nombrearticulo;
                            cpventadet.Idunidadmedida = item.Idunidadmedida;
                            cpventadet.Idimpuesto = item.Idimpuesto;
                            cpventadet.Cantidad = item.Cantidad;
                            cpventadet.Preciounitario = item.Preciounitario;
                            cpventadet.Especificacion = item.Especificacion;
                            cpventadet.Descuento1 = item.Descuento1;
                            cpventadet.Descuento2 = item.Descuento2;
                            cpventadet.Descuento4 = item.Descuento4;
                            cpventadet.Descuento3 = item.Descuento3;
                            cpventadet.Preciounitarioneto = item.Preciounitarioneto;
                            cpventadet.Importetotal = item.Importetotal;
                            cpventadet.Porcentajepercepcion = item.Porcentajepercepcion;
                            cpventadet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            cpventadet.Idalmacen = item.Idalmacen;
                            cpventadet.Idarea = item.Idarea;
                            cpventadet.Idproyecto = item.Idproyecto;
                            cpventadet.Idcentrodecosto = item.Idcentrodecosto;
                            cpventadet.Idordendeventadet = item.Idordendeventadet;
                            cpventadet.Idvalorizacion = item.Idvalorizacion;
                            cpventadet.Calcularitem = item.Calcularitem;
                            cpventadet.Bonificacion = item.Bonificacion;
                            cpventadet.Idubicacion = item.Idubicacion;

                            cpventadet.Idclase = item.Idclase;
                            cpventadet.Idplan = item.Idplan;
                            cpventadet.Idtipo = item.Idtipo;
                            cpventadet.Idtipotope = item.Idtipotope;
                            cpventadet.Numerolinea = item.Numerolinea;
                            cpventadet.Idseriearticulo = item.Idseriearticulo;
                            
                            //Actualizar utilizacion de serie de articulo
                            bool serieUtilizada = item.Serieutilizada;
                            int? idSerieArticulo = item.Idseriearticulo;
                            if (idSerieArticulo != null && idSerieArticulo > 0)
                            {
                                db.UpdateOnly(new Seriearticulo { Serieutilizada = serieUtilizada },
                                q => q.Update(p => p.Serieutilizada)
                                    .Where(x => x.Idseriearticulo == idSerieArticulo));
                            }
                            

                            cpventadet.Createdby = item.Createdby;
                            cpventadet.Creationdate = item.Creationdate;
                            cpventadet.Modifiedby = item.Modifiedby;
                            cpventadet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idcpventadet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(cpventadet);
                                item.Idcpventadet = cpventadet.Idcpventadet;
                            }

                            //Modificar
                            if (item.Idcpventadet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(cpventadet);
                            }

                            //Eliminar
                            if (item.Idcpventadet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Cpventadet>(item.Idcpventadet);
                            }
                        }
                    }

                    if (vwGuiaremisiondetimpcpventadetImpList != null && vwGuiaremisiondetimpcpventadetImpList.Count > 0)
                    {
                        foreach (var itemGuiaRemDetImp in vwGuiaremisiondetimpcpventadetImpList.Where(x=>x.Itemseleccionado))
                        {
                            Guiaremisiondetimpcpventadet guiaremisiondetimpcpventadet = new Guiaremisiondetimpcpventadet();
                            guiaremisiondetimpcpventadet.Idguiaremisiondet = itemGuiaRemDetImp.Idguiaremisiondet;
                            guiaremisiondetimpcpventadet.Cantidadimportada = itemGuiaRemDetImp.Cantidadaimportar;
                            guiaremisiondetimpcpventadet.Idcpventa = entidadCab.Idcpventa;
                            db.Insert(guiaremisiondetimpcpventadet);
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
                            Cpventadet cpventadet = new Cpventadet
                            {
                                Numeroitem = item.Numeroitem,
                                Idcpventadet = item.Idcpventadet
                            };
                            db.Update<Cpventadet>(new { cpventadet.Numeroitem },
                                p => p.Idcpventadet == cpventadet.Idcpventadet);
                            numeroItem++;
                        }
                    }

                    trans.Commit();
                    return true;
                }
            }
	    }

        public int GuardarCpVentaReciboIngreso(TipoMantenimiento tipoMantenimiento, Cpventa entidadCab, List<VwCpventadet> entidadDetList, Recibocajaingreso recibocajaingreso, List<VwRecibocajaingresodet> vWrecibocajaingresodetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idcpventa > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numerocpventa) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idcpventa > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Cpventadet cpventadet = new Cpventadet();

                            cpventadet.Idcpventadet = item.Idcpventadet;
                            cpventadet.Idcpventa = entidadCab.Idcpventa;
                            cpventadet.Numeroitem = item.Numeroitem;
                            cpventadet.Idarticulo = item.Idarticulo;
                            cpventadet.Articulomodificado = item.Articulomodificado;
                            cpventadet.Nombrearticulo = item.Nombrearticulo;
                            cpventadet.Idunidadmedida = item.Idunidadmedida;
                            cpventadet.Idimpuesto = item.Idimpuesto;
                            cpventadet.Cantidad = item.Cantidad;
                            cpventadet.Preciounitario = item.Preciounitario;
                            cpventadet.Especificacion = item.Especificacion;
                            cpventadet.Descuento1 = item.Descuento1;
                            cpventadet.Descuento2 = item.Descuento2;
                            cpventadet.Descuento4 = item.Descuento4;
                            cpventadet.Descuento3 = item.Descuento3;
                            cpventadet.Preciounitarioneto = item.Preciounitarioneto;
                            cpventadet.Importetotal = item.Importetotal;
                            cpventadet.Porcentajepercepcion = item.Porcentajepercepcion;
                            cpventadet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            cpventadet.Idalmacen = item.Idalmacen;
                            cpventadet.Idarea = item.Idarea;
                            cpventadet.Idproyecto = item.Idproyecto;
                            cpventadet.Idcentrodecosto = item.Idcentrodecosto;
                            cpventadet.Idordendeventadet = item.Idordendeventadet;
                            cpventadet.Idvalorizacion = item.Idvalorizacion;
                            cpventadet.Calcularitem = item.Calcularitem;
                            //ordencompradet.Createdby = item.Createdby;
                            //ordencompradet.Creationdate = item.Creationdate;
                            //ordencompradet.Modifiedby = item.Modifiedby;
                            //ordencompradet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idcpventadet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(cpventadet);
                                item.Idcpventadet = cpventadet.Idcpventadet;
                            }

                            //Modificar
                            if (item.Idcpventadet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(cpventadet);
                            }

                            //Eliminar
                            if (item.Idcpventadet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Cpventadet>(item.Idcpventadet);
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
                            Cpventadet cpventadet = new Cpventadet
                            {
                                Numeroitem = item.Numeroitem,
                                Idcpventadet = item.Idcpventadet
                            };
                            db.Update<Cpventadet>(new { cpventadet.Numeroitem },
                                p => p.Idcpventadet == cpventadet.Idcpventadet);
                            numeroItem++;
                        }
                    }


                    //Grabar recibo


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
                            recibocajaingresodet.Idcpventa = entidadCab.Idcpventa;

                            //Nuevo
                            if (item.Idrecibocajaingresodet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(recibocajaingresodet);
                                item.Idrecibocajaingresodet = recibocajaingresodet.Idrecibocajaingresodet;
                            }
                        }
                    }

                    trans.Commit();
                    return entidadCab.Idcpventa;
                }
            }	        
	    }
	}
}

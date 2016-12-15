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
	public class NotadebitocliDao : Dao<Notadebitocli>, INotadebitocliDao
	{
	    public bool GuardarNotaDebitoCli(TipoMantenimiento tipoMantenimiento, Notadebitocli entidadCab, List<VwNotadebitoclidet> entidadDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idnotadebitocli > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numeronotadebito) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idnotadebitocli > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Notadebitoclidet notacreditoclidet = new Notadebitoclidet();

                            notacreditoclidet.Idnotadebitoclidet = item.Idnotadebitoclidet;
                            notacreditoclidet.Idnotadebitocli = entidadCab.Idnotadebitocli;
                            notacreditoclidet.Numeroitem = item.Numeroitem;
                            notacreditoclidet.Idarticulo = item.Idarticulo;
                            notacreditoclidet.Articulomodificado = item.Articulomodificado;
                            notacreditoclidet.Nombrearticulo = item.Nombrearticulo;
                            notacreditoclidet.Idunidadmedida = item.Idunidadmedida;
                            notacreditoclidet.Idimpuesto = item.Idimpuesto;
                            notacreditoclidet.Cantidad = item.Cantidad;
                            notacreditoclidet.Preciounitario = item.Preciounitario;
                            notacreditoclidet.Especificacion = item.Especificacion;
                            notacreditoclidet.Descuento1 = item.Descuento1;
                            notacreditoclidet.Descuento2 = item.Descuento2;
                            notacreditoclidet.Descuento4 = item.Descuento4;
                            notacreditoclidet.Descuento3 = item.Descuento3;
                            notacreditoclidet.Preciounitarioneto = item.Preciounitarioneto;
                            notacreditoclidet.Importetotal = item.Importetotal;
                            notacreditoclidet.Porcentajepercepcion = item.Porcentajepercepcion;
                            notacreditoclidet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            notacreditoclidet.Idalmacen = item.Idalmacen;
                            notacreditoclidet.Idarea = item.Idarea;
                            notacreditoclidet.Idproyecto = item.Idproyecto;
                            notacreditoclidet.Idcentrodecosto = item.Idcentrodecosto;
                            notacreditoclidet.Idcpventadet = item.Idcpventadet;
                            //ordencompradet.Createdby = item.Createdby;
                            //ordencompradet.Creationdate = item.Creationdate;
                            //ordencompradet.Modifiedby = item.Modifiedby;
                            //ordencompradet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idnotadebitoclidet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(notacreditoclidet);
                                item.Idnotadebitoclidet = notacreditoclidet.Idnotadebitoclidet;
                            }

                            //Modificar
                            if (item.Idnotadebitoclidet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(notacreditoclidet);
                            }

                            //Eliminar
                            if (item.Idnotadebitoclidet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Notadebitoclidet>(item.Idnotadebitoclidet);
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
                            Notadebitoclidet notadebitoclidet = new Notadebitoclidet
                            {
                                Numeroitem = item.Numeroitem,
                                Idnotadebitoclidet = item.Idnotadebitoclidet
                            };
                            db.Update<Notadebitoclidet>(new { notadebitoclidet.Numeroitem },
                                p => p.Idnotadebitoclidet == notadebitoclidet.Idnotadebitoclidet);
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

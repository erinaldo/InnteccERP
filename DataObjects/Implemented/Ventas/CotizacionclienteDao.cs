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
	public class CotizacionclienteDao : Dao<Cotizacioncliente>, ICotizacionclienteDao
	{

	    public bool GuardarCotizacionCliente(TipoMantenimiento tipoMantenimiento, Cotizacioncliente entidadCab, List<VwCotizacionclientedet> entidadDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idcotizacioncliente > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numerocotizacion) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idcotizacioncliente > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Cotizacionclientedet cotizacionclientedet = new Cotizacionclientedet();

                            cotizacionclientedet.Idcotizacionclientedet = item.Idcotizacionclientedet;
                            cotizacionclientedet.Idcotizacioncliente = entidadCab.Idcotizacioncliente;
                            cotizacionclientedet.Numeroitem = item.Numeroitem;
                            cotizacionclientedet.Idarticulo = item.Idarticulo;
                            cotizacionclientedet.Articulomodificado = false;
                            cotizacionclientedet.Nombrearticulo = string.Empty;
                            cotizacionclientedet.Cantidad = item.Cantidad;
                            cotizacionclientedet.Idunidadmedida = item.Idunidadmedida;
                            cotizacionclientedet.Preciounitario = item.Preciounitario;
                            cotizacionclientedet.Especificacion = item.Especificacion;
                            cotizacionclientedet.Descuento1 = item.Descuento1;
                            cotizacionclientedet.Descuento2 = item.Descuento2;
                            cotizacionclientedet.Descuento3 = item.Descuento3;
                            cotizacionclientedet.Descuento4 = item.Descuento4;
                            cotizacionclientedet.Preciounitarioneto = item.Preciounitarioneto;
                            cotizacionclientedet.Importetotal = item.Importetotal;
                            cotizacionclientedet.Idimpuesto = item.Idimpuesto;
                            cotizacionclientedet.Diasdeentrega = item.Diasdeentrega;
                            cotizacionclientedet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            cotizacionclientedet.Idcentrodecosto = item.Idcentrodecosto;
                            cotizacionclientedet.Porcentajepercepcion = item.Porcentajepercepcion;
                            cotizacionclientedet.Idalmacen = item.Idalmacen;
                            cotizacionclientedet.Calcularitem = item.Calcularitem;
                            cotizacionclientedet.Bonificacion = item.Bonificacion;
                            cotizacionclientedet.Idubicacion = item.Idubicacion;
                            cotizacionclientedet.Createdby = item.Createdby;
                            cotizacionclientedet.Creationdate = item.Creationdate;
                            cotizacionclientedet.Modifiedby = item.Modifiedby;
                            cotizacionclientedet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idcotizacionclientedet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(cotizacionclientedet);
                                item.Idcotizacionclientedet = cotizacionclientedet.Idcotizacionclientedet;
                            }

                            //Modificar
                            if (item.Idcotizacionclientedet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(cotizacionclientedet);
                            }

                            //Eliminar
                            if (item.Idcotizacionclientedet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Cotizacionclientedet>(item.Idcotizacionclientedet);
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
                            Cotizacionclientedet cotizacionclientedet = new Cotizacionclientedet
                            {
                                Numeroitem = item.Numeroitem,
                                Idcotizacionclientedet = item.Idcotizacionclientedet 
                            };
                            db.Update<Cotizacionclientedet>(new { cotizacionclientedet.Numeroitem },
                            p => p.Idcotizacionclientedet == cotizacionclientedet.Idcotizacionclientedet);
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

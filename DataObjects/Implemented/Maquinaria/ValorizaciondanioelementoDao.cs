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
	public class ValorizaciondanioelementoDao : Dao<Valorizaciondanioelemento>, IValorizaciondanioelementoDao
	{
        public bool GuardarValorizacionDanioElemento(TipoMantenimiento tipoMantenimiento, Valorizaciondanioelemento entidadCab, List<VwValorizacionelemento> elementoDetList, List<VwValorizaciondanio> danioDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idvalorizaciondanioelemento > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numerode) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }


                    if (entidadCab.Idvalorizaciondanioelemento > 0)
                    {
                        foreach (var item in elementoDetList)
                        {
                            Valorizacionelemento valorizacionelemento = new Valorizacionelemento();

                            valorizacionelemento.Idvalorizacionelemento  = item.Idvalorizacionelemento;
                            valorizacionelemento.Idvalorizaciondanioelemento = entidadCab.Idvalorizaciondanioelemento;
                            valorizacionelemento.Idarticulo = item.Idarticulo;
                            valorizacionelemento.Cantidad = item.Cantidad;
                            valorizacionelemento.Valorunitario = item.Valorunitario;
                            valorizacionelemento.Subtotal = item.Subtotal;
                            valorizacionelemento.Idunidadmedida = item.Idunidadmedida;
                            valorizacionelemento.Comentario = item.Comentario;
                            valorizacionelemento.Numeroitem = item.Numeroitem;

                            //Nuevo
                            if (item.Idvalorizacionelemento == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(valorizacionelemento);
                                item.Idvalorizacionelemento = valorizacionelemento.Idvalorizacionelemento;

                            }

                            //Modificar
                            if (item.Idvalorizacionelemento > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(valorizacionelemento);
                            }

                            //Eliminar
                            if (item.Idvalorizacionelemento > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Valorizacionelemento>(item.Idvalorizacionelemento);
                            }
                        }

                        //Verificar si hubo cambios en el orden de items
                        int cntNoOrden = 0;
                        int nItemInicial = 0;
                        foreach (var item in elementoDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
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
                            foreach (var item in elementoDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                            {
                                item.Numeroitem = numeroItem;
                                Valorizacionelemento valorizacionelemento = new Valorizacionelemento
                                {
                                    Numeroitem = item.Numeroitem,
                                    Idvalorizacionelemento = item.Idvalorizacionelemento
                                };
                                db.Update<Valorizacionelemento>(new { valorizacionelemento.Numeroitem }, p => p.Idvalorizacionelemento == valorizacionelemento.Idvalorizacionelemento);
                                numeroItem++;
                            }
                        }
                    }

                    if (entidadCab.Idvalorizaciondanioelemento > 0)
                    {
                        foreach (var item in danioDetList)
                        {
                            Valorizaciondanio valorizaciondanio = new Valorizaciondanio();

                            valorizaciondanio.Idvalorizaciondanio  = item.Idvalorizaciondanio;
                            valorizaciondanio.Idvalorizaciondanioelemento = entidadCab.Idvalorizaciondanioelemento;
                            valorizaciondanio.Idarticulo = item.Idarticulo;
                            valorizaciondanio.Cantidad = item.Cantidad;
                            valorizaciondanio.Valorunitario = item.Valorunitario;
                            valorizaciondanio.Subtotal = item.Subtotal;
                            valorizaciondanio.Idunidadmedida = item.Idunidadmedida;
                            valorizaciondanio.Comentario = item.Comentario;
                            valorizaciondanio.Numeroitem = item.Numeroitem;

                            //Nuevo
                            if (item.Idvalorizaciondanio  == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(valorizaciondanio);
                                item.Idvalorizaciondanio = valorizaciondanio.Idvalorizaciondanio;

                            }

                            //Modificar
                            if (item.Idvalorizaciondanio > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(valorizaciondanio);
                            }

                            //Eliminar
                            if (item.Idvalorizaciondanio > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Valorizaciondanio>(item.Idvalorizaciondanio);
                            }
                        }

                        //Verificar si hubo cambios en el orden de items
                        int cntNoOrden = 0;
                        int nItemInicial = 0;
                        foreach (var item in danioDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
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
                            foreach (var item in elementoDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                            {
                                item.Numeroitem = numeroItem;
                                Valorizaciondanio valorizacionelemento = new Valorizaciondanio
                                {
                                    Numeroitem = item.Numeroitem,
                                    Idvalorizaciondanio = item.Idvalorizacionelemento
                                };
                                db.Update<Valorizaciondanio>(new { valorizacionelemento.Numeroitem }, p => p.Idvalorizaciondanio == valorizacionelemento.Idvalorizaciondanio);
                                numeroItem++;
                            }
                        }
                    }

                    trans.Commit();
                    return true;
                }
            }
	    }
	}
}

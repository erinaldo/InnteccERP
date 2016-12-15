using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
    public class OrdencompraDao : Dao<Ordencompra>, IOrdencompraDao
    {
        public bool GuardarOrdenDeCompra(TipoMantenimiento tipoMantenimiento, Ordencompra entidadCab, List<VwOrdencompradet> entidadDetList)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idordencompra > 0)
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



                    if (entidadCab.Idordencompra > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Ordencompradet ordencompradet = new Ordencompradet();

                            ordencompradet.Idordencompradet = item.Idordencompradet;
                            ordencompradet.Idordencompra = entidadCab.Idordencompra;
                            ordencompradet.Numeroitem = item.Numeroitem;
                            ordencompradet.Idarticulo = item.Idarticulo;
                            ordencompradet.Cantidad = item.Cantidad;
                            ordencompradet.Idunidadmedida = item.Idunidadmedida;
                            ordencompradet.Preciounitario = item.Preciounitario;
                            ordencompradet.Especificacion = item.Especificacion;
                            ordencompradet.Descuento1 = item.Descuento1;
                            ordencompradet.Descuento2 = item.Descuento2;
                            ordencompradet.Descuento3 = item.Descuento3;
                            ordencompradet.Descuento4 = item.Descuento4;
                            ordencompradet.Preciounitarioneto = item.Preciounitarioneto;
                            ordencompradet.Importetotal = item.Importetotal;
                            ordencompradet.Idimpuesto = item.Idimpuesto;
                            ordencompradet.Idcentrodecosto = item.Idcentrodecosto;
                            ordencompradet.Porcentajepercepcion = item.Porcentajepercepcion;
                            ordencompradet.Idrequerimientodet = item.Idrequerimientodet;
                            ordencompradet.Idarea = item.Idarea;
                            ordencompradet.Idproyecto = item.Idproyecto;
                            ordencompradet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            ordencompradet.Calcularitem = item.Calcularitem;
                            ordencompradet.Fechaentrega = item.Fechaentrega;
                            ordencompradet.Createdby = item.Createdby;
                            ordencompradet.Creationdate = item.Creationdate;
                            ordencompradet.Modifiedby = item.Modifiedby;
                            ordencompradet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idordencompradet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(ordencompradet);
                                item.Idordencompradet = ordencompradet.Idordencompradet;
                            }

                            //Modificar
                            if (item.Idordencompradet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(ordencompradet);
                            }

                            //Eliminar
                            if (item.Idordencompradet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Ordencompradet>(item.Idordencompradet);
                            }
                        }
                    }

                    //Anular detalle de orden de compra
                    if (entidadCab.Anulado)
                    {
                        //Anular referencia de requerimiento
                        db.UpdateOnly(new Ordencompradet { Idrequerimientodet = null },
                            q => q.Update(p => p.Idrequerimientodet).Where(x => x.Idordencompra == entidadCab.Idordencompra));
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
                            Ordencompradet ordencompradet = new Ordencompradet
                            {
                                Numeroitem = item.Numeroitem,
                                Idordencompradet = item.Idordencompradet
                            };
                            db.Update<Ordencompradet>(new { ordencompradet.Numeroitem },
                                p => p.Idordencompradet == ordencompradet.Idordencompradet);
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

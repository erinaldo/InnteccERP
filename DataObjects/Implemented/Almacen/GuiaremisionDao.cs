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
    public class GuiaremisionDao : Dao<Guiaremision>, IGuiaremisionDao
    {
        public bool GuardarGuiaremision(TipoMantenimiento tipoMantenimiento, Guiaremision entidadCab, List<VwGuiaremisiondet> entidadDetList)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idguiaremision > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numeroguiaremision) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idguiaremision > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Guiaremisiondet guiaremisiondet = new Guiaremisiondet();

                            guiaremisiondet.Idguiaremisiondet = item.Idguiaremisiondet;
                            guiaremisiondet.Idguiaremision = entidadCab.Idguiaremision;
                            guiaremisiondet.Idarticulo = item.Idarticulo;
                            guiaremisiondet.Articulomoficado = item.Articulomoficado;
                            guiaremisiondet.Nombrearticulo = item.Nombrearticulo;
                            guiaremisiondet.Idunidadmedida = item.Idunidadmedida;
                            guiaremisiondet.Idimpuesto = item.Idimpuesto;
                            guiaremisiondet.Numeroitem = item.Numeroitem;
                            guiaremisiondet.Cantidad = item.Cantidad;
                            guiaremisiondet.Pesounitario = item.Pesounitario;
                            guiaremisiondet.Pesototal = item.Pesototal;
                            guiaremisiondet.Preciounitario = item.Preciounitario;
                            guiaremisiondet.Importetotal = item.Importetotal;
                            guiaremisiondet.Especificacion = item.Especificacion;
                            guiaremisiondet.Idordendeventadet = item.Idordendeventadet;
                            guiaremisiondet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            guiaremisiondet.Porcentajepercepcion = item.Porcentajepercepcion;
                            guiaremisiondet.Idproyecto = item.Idproyecto;
                            guiaremisiondet.Idarea = item.Idarea;
                            guiaremisiondet.Idcentrodecosto = item.Idcentrodecosto;
                            guiaremisiondet.Idrequerimientodet = item.Idrequerimientodet;
                            guiaremisiondet.Calcularitem = item.Calcularitem;
                            guiaremisiondet.Idcpcompradet = item.Idcpcompradet;
                            guiaremisiondet.Identradaalmacendet = item.Identradaalmacendet;

                            //Nuevo
                            if (item.Idguiaremisiondet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(guiaremisiondet);
                                item.Idguiaremisiondet = guiaremisiondet.Idguiaremisiondet;
                            }

                            //Modificar
                            if (item.Idguiaremisiondet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(guiaremisiondet);
                            }

                            //Eliminar
                            if (item.Idguiaremisiondet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Guiaremisiondet>(item.Idguiaremisiondet);
                            }
                        }
                    }

                    //Anular detalle de orden de compra
                    if (entidadCab.Anulado)
                    {
                        //Anular referencias
                        db.UpdateOnly(new Guiaremisiondet
                        {
                            Idordendeventadet = null,
                            Idrequerimientodet = null,
                            Idcpcompradet = null,
                            Identradaalmacendet = null
                        },
                        f => new
                        {
                            f.Idordendeventadet,
                            f.Idrequerimientodet,
                            f.Idcpcompradet,
                            f.Identradaalmacendet
                        }, w => w.Idguiaremision == entidadCab.Idguiaremision);
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
                            Guiaremisiondet guiaremisiondet = new Guiaremisiondet
                            {
                                Numeroitem = item.Numeroitem,
                                Idguiaremisiondet = item.Idguiaremisiondet
                            };
                            db.Update<Guiaremisiondet>(new { guiaremisiondet.Numeroitem },
                                p => p.Idguiaremisiondet == guiaremisiondet.Idguiaremisiondet);
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

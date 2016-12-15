using System.Collections.Generic;
using System.Data;
using System.Linq;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class NotacreditoDao : Dao<Notacredito>, INotacreditoDao
	{
	    public bool GuardarNotacredito(TipoMantenimiento tipoMantenimiento, Notacredito entidadCab, List<VwNotacreditodet> entidadDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }


                    if (entidadCab.Idnotacredito > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Notacreditodet notacreditodet = new Notacreditodet();

                            notacreditodet.Idnotacreditodet = item.Idnotacreditodet;
                            notacreditodet.Idnotacredito = entidadCab.Idnotacredito;
                            notacreditodet.Numeroitem = item.Numeroitem;
                            notacreditodet.Idarticulo = item.Idarticulo;
                            notacreditodet.Cantidad = item.Cantidad;
                            notacreditodet.Idunidadmedida = item.Idunidadmedida;
                            notacreditodet.Idimpuesto = item.Idimpuesto;
                            notacreditodet.Preciounitario = item.Preciounitario;
                            notacreditodet.Especificacion = item.Especificacion;
                            notacreditodet.Descuento1 = item.Descuento1;
                            notacreditodet.Descuento2 = item.Descuento2;
                            notacreditodet.Descuento3 = item.Descuento3;
                            notacreditodet.Descuento4 = item.Descuento4;
                            notacreditodet.Preciounitarioneto = item.Preciounitarioneto;
                            notacreditodet.Importetotal = item.Importetotal;
                            notacreditodet.Idcentrodecosto = item.Idcentrodecosto;
                            notacreditodet.Porcentajepercepcion = item.Porcentajepercepcion;
                            notacreditodet.Idarea = item.Idarea;
                            notacreditodet.Idproyecto = item.Idproyecto;
                            notacreditodet.Idcpcompradet = item.Idcpcompradet;

                            notacreditodet.Createdby = item.Createdby;
                            notacreditodet.Creationdate = item.Creationdate;
                            notacreditodet.Modifiedby = item.Modifiedby;
                            notacreditodet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idnotacreditodet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(notacreditodet);
                                item.Idnotacreditodet = notacreditodet.Idnotacreditodet;
                            }

                            //Modificar
                            if (item.Idnotacreditodet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(notacreditodet);
                            }

                            //Eliminar
                            if (item.Idnotacreditodet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Notacreditodet>(item.Idnotacreditodet);
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
                            foreach (var item in entidadDetList.Where(x => x.DataEntityState != DataEntityState.Deleted)
                                )
                            {
                                item.Numeroitem = numeroItem;
                                Notacreditodet notacreditodet = new Notacreditodet
                                {
                                    Numeroitem = item.Numeroitem,
                                    Idnotacreditodet = item.Idnotacreditodet
                                };
                                db.Update<Notacreditodet>(new {notacreditodet.Numeroitem},
                                    p => p.Idnotacreditodet == notacreditodet.Idnotacreditodet);
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

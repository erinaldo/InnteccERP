using System.Collections.Generic;
using System.Data;
using System.Linq;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class NotadebitoDao : Dao<Notadebito>, INotadebitoDao
	{
        public bool GuardarNotadebito(TipoMantenimiento tipoMantenimiento, Notadebito entidadCab, List<VwNotadebitodet> entidadDetList)
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


                    if (entidadCab.Idnotadebito > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Notadebitodet notadebitodet = new Notadebitodet();

                            notadebitodet.Idnotadebitodet = item.Idnotadebitodet;
                            notadebitodet.Idnotadebito = entidadCab.Idnotadebito;
                            notadebitodet.Numeroitem = item.Numeroitem;
                            notadebitodet.Idarticulo = item.Idarticulo;
                            notadebitodet.Cantidad = item.Cantidad;
                            notadebitodet.Idunidadmedida = item.Idunidadmedida;
                            notadebitodet.Idimpuesto = item.Idimpuesto;
                            notadebitodet.Preciounitario = item.Preciounitario;
                            notadebitodet.Especificacion = item.Especificacion;
                            notadebitodet.Descuento1 = item.Descuento1;
                            notadebitodet.Descuento2 = item.Descuento2;
                            notadebitodet.Descuento3 = item.Descuento3;
                            notadebitodet.Descuento4 = item.Descuento4;
                            notadebitodet.Preciounitarioneto = item.Preciounitarioneto;
                            notadebitodet.Importetotal = item.Importetotal;
                            notadebitodet.Idcentrodecosto = item.Idcentrodecosto;
                            notadebitodet.Porcentajepercepcion = item.Porcentajepercepcion;
                            notadebitodet.Idarea = item.Idarea;
                            notadebitodet.Idproyecto = item.Idproyecto;
                            notadebitodet.Idcpcompradet = item.Idcpcompradet;

                            notadebitodet.Createdby = item.Createdby;
                            notadebitodet.Creationdate = item.Creationdate;
                            notadebitodet.Modifiedby = item.Modifiedby;
                            notadebitodet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idnotadebitodet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(notadebitodet);
                                item.Idnotadebitodet = notadebitodet.Idnotadebitodet;
                            }

                            //Modificar
                            if (item.Idnotadebitodet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(notadebitodet);
                            }

                            //Eliminar
                            if (item.Idnotadebitodet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Notadebitodet>(item.Idnotadebitodet);
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
                                Notadebitodet notadebitodet = new Notadebitodet
                                {
                                    Numeroitem = item.Numeroitem,
                                    Idnotadebitodet = item.Idnotadebitodet
                                };
                                db.Update<Notadebitodet>(new {notadebitodet.Numeroitem},
                                    p => p.Idnotadebitodet == notadebitodet.Idnotadebitodet);
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

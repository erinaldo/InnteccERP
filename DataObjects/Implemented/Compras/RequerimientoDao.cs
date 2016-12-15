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
	public class RequerimientoDao : Dao<Requerimiento>, IRequerimientoDao
	{
        public bool GuardarRequerimiento(TipoMantenimiento tipoMantenimiento, Requerimiento entidadCab, List<VwRequerimientodet> entidadDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idrequerimiento > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numeroreq) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }                           
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    //int numeroItem = 1;
                    //foreach (var item in entidadDetList.Where(x=>x.DataEntityState != DataEntityState.Deleted))
                    //{
                    //    item.DataEntityState = DataEntityState.Modified;
                    //    item.Numeroitem = numeroItem;
                    //    numeroItem++;
                    //}

                    if (entidadCab.Idrequerimiento > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Requerimientodet requerimientodet = new Requerimientodet();

                            requerimientodet.Idrequerimientodet = item.Idrequerimientodet;
                            requerimientodet.Idrequerimiento = entidadCab.Idrequerimiento;
                            requerimientodet.Numeroitem = item.Numeroitem;
                            requerimientodet.Idarticulo = item.Idarticulo;
                            requerimientodet.Idimpuesto = item.Idimpuesto;
                            requerimientodet.Idunidadmedida = item.Idunidadmedida;
                            requerimientodet.Especificacion = item.Especificacion;
                            requerimientodet.Cantidad = item.Cantidad;
                            requerimientodet.Preciounitario = item.Preciounitario;
                            requerimientodet.Importetotal = item.Importetotal;
                            requerimientodet.Idcentrodecosto = item.Idcentrodecosto;
                            requerimientodet.Cantidadinicial = item.Cantidadinicial;
                            requerimientodet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            requerimientodet.Porcentajepercepcion = item.Porcentajepercepcion;
                            requerimientodet.Aprobado = item.Aprobado;
                            requerimientodet.Calcularitem = item.Calcularitem;

                            requerimientodet.Createdby = item.Createdby;
                            requerimientodet.Creationdate = item.Creationdate;
                            requerimientodet.Modifiedby = item.Modifiedby;
                            requerimientodet.Lastmodified = item.Lastmodified;


                            //Nuevo
                            if (item.Idrequerimientodet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(requerimientodet);
                                item.Idrequerimientodet = requerimientodet.Idrequerimientodet;

                            }

                            //Modificar
                            if (item.Idrequerimientodet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(requerimientodet);
                            }

                            //Eliminar
                            if (item.Idrequerimientodet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Requerimientodet>(item.Idrequerimientodet);
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
                                Requerimientodet requerimientodet = new Requerimientodet
                                {
                                    Numeroitem = item.Numeroitem,
                                    Idrequerimientodet = item.Idrequerimientodet
                                };
                                db.Update<Requerimientodet>(new { requerimientodet.Numeroitem }, p => p.Idrequerimientodet == requerimientodet.Idrequerimientodet);
                                numeroItem++;
                            }
                        }


                    }
                    trans.Commit();
                    return true;
                }                
            }
	    }

	    public bool RequerimientoTieneReferenciasOrdenDeCompra(int idRequerimiento)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                var queryReqRef = string.Format(@"SELECT count(ordencompradet.idordencompra) as cntreferencias,requerimientodet.idrequerimiento
                                    FROM compras.ordencompradet
                                    LEFT JOIN compras.ordencompra ON ordencompradet.idordencompra = ordencompra.idordencompra
                                    LEFT JOIN compras.requerimientodet ON (ordencompradet.idrequerimientodet = requerimientodet.idrequerimientodet)
                                    LEFT JOIN compras.requerimiento ON (requerimientodet.idrequerimiento = requerimiento.idrequerimiento)
                                    where requerimientodet.idrequerimiento is not null and ordencompra.anulado = '0' and requerimiento.idrequerimiento = {0}
                                    GROUP BY requerimientodet.idrequerimiento ", idRequerimiento);

                var cantidadReferencias = db.SqlScalar<int>(queryReqRef);

                return cantidadReferencias > 0;
            }
	    }
	}
}

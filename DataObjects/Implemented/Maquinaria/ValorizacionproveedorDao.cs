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
	public class ValorizacionproveedorDao : Dao<Valorizacionproveedor>, IValorizacionproveedorDao
	{
	    public bool GuardarValorizacionProveedor(TipoMantenimiento tipoMantenimiento, Valorizacionproveedor entidadCab, List<VwValorizacionproveedordet> entidadDetList)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idvalorizacionproveedor > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numerovalorizacion) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idvalorizacionproveedor > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Valorizacionproveedordet valorizacionproveedordet = new Valorizacionproveedordet();

                            valorizacionproveedordet.Idvalorizacionproveedordet = item.Idvalorizacionproveedordet;
                            valorizacionproveedordet.Idvalorizacionproveedor = entidadCab.Idvalorizacionproveedor;
                            valorizacionproveedordet.Numeroitem = item.Numeroitem;
                            valorizacionproveedordet.Fecha = item.Fecha;
                            valorizacionproveedordet.Turno = item.Turno;
                            valorizacionproveedordet.Horometroinicio = item.Horometroinicio;
                            valorizacionproveedordet.Horometrofinal = item.Horometrofinal;
                            valorizacionproveedordet.Horometrodia = item.Horometrodia;
                            valorizacionproveedordet.Descuentohorometro = item.Descuentohorometro;
                            valorizacionproveedordet.Horometrorealdia = item.Horometrodia;
                            valorizacionproveedordet.Horometrominimo = item.Horometrominimo;
                            valorizacionproveedordet.Diastrabajo = item.Diastrabajo;
                            valorizacionproveedordet.Idcentrodecosto = item.Idcentrodecosto;
                            valorizacionproveedordet.Observaciones = item.Observaciones;


                            //ordencompradet.Createdby = item.Createdby;
                            //ordencompradet.Creationdate = item.Creationdate;
                            //ordencompradet.Modifiedby = item.Modifiedby;
                            //ordencompradet.Lastmodified = item.Lastmodified;

                            //Nuevo
                            if (item.Idvalorizacionproveedordet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(valorizacionproveedordet);
                                item.Idvalorizacionproveedordet = valorizacionproveedordet.Idvalorizacionproveedordet;
                            }

                            //Modificar
                            if (item.Idvalorizacionproveedordet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(valorizacionproveedordet);
                            }

                            //Eliminar
                            if (item.Idvalorizacionproveedordet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Valorizacionproveedordet>(item.Idvalorizacionproveedordet);
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
                            Valorizacionproveedordet valorizacionproveedordet = new Valorizacionproveedordet
                            {
                                Numeroitem = item.Numeroitem,
                                Idvalorizacionproveedordet = item.Idvalorizacionproveedordet
                            };
                            db.Update<Valorizacionproveedordet>(new { valorizacionproveedordet.Numeroitem },
                                p => p.Idvalorizacionproveedordet == valorizacionproveedordet.Idvalorizacionproveedordet);
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

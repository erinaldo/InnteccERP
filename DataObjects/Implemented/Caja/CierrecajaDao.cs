using System.Collections.Generic;
using System.Data;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class CierrecajaDao : Dao<Cierrecaja>, ICierrecajaDao
	{
        public bool GuardarCierrecaja(TipoMantenimiento tipoMantenimiento, Cierrecaja entidadCab,
         List<VwCierrecajadet> elementoDetList)
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


                    if (entidadCab.Idcierrecaja > 0)
                    {
                        foreach (var item in elementoDetList)
                        {
                            Cierrecajadet recibodet = new Cierrecajadet();

                            recibodet.Idcierrecajadet = item.Idcierrecajadet;
                            recibodet.Idcierrecaja = entidadCab.Idcierrecaja;
                            recibodet.Idmediopago = item.Idmediopago;
                            recibodet.Importe = item.Importe;
                            recibodet.Idcptooperacion = item.Idcptooperacion;

                            //Nuevo
                            if (item.Idcierrecajadet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(recibodet);
                                item.Idcierrecajadet = recibodet.Idcierrecajadet;

                            }

                            //Modificar
                            if (item.Idcierrecajadet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(recibodet);
                            }

                            //Eliminar
                            if (item.Idcierrecajadet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Cierrecajadet>(item.Idcierrecajadet);
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

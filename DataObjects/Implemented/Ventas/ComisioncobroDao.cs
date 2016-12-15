using System.Collections.Generic;
using System.Data;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class ComisioncobroDao : Dao<Comisioncobro>, IComisioncobroDao
	{
	    public bool GuardarComisionCobro(TipoMantenimiento tipoMantenimiento, Comisioncobro entidadCab, List<Comisioncobrodet> entidadDetList)
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

                    if (entidadCab.Idcomisioncobro  > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Comisioncobrodet comisioncobrodet = new Comisioncobrodet();

                            comisioncobrodet.Idcomisioncobro = entidadCab.Idcomisioncobro;
                            comisioncobrodet.Rangoinicial = item.Rangoinicial;
                            comisioncobrodet.Rangofinal = item.Rangofinal;
                            comisioncobrodet.Porcentajecomision = item.Porcentajecomision;                            

                            //Nuevo
                            if (item.Idcomisioncobrodet == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(comisioncobrodet);
                                item.Idcomisioncobrodet = comisioncobrodet.Idcomisioncobrodet;
                            }

                            //Modificar
                            if (item.Idcomisioncobrodet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(comisioncobrodet);
                            }

                            //Eliminar
                            if (item.Idcomisioncobrodet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Comisioncobrodet>(item.Idcomisioncobrodet);
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

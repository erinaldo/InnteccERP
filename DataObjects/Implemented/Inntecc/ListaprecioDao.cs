using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
    public class ListaprecioDao : Dao<Listaprecio>, IListaprecioDao
    {
        public int GuardarListaprecio(TipoMantenimiento tipoMantenimiento, Listaprecio listaprecioMnt)
        {

            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(listaprecioMnt);
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(listaprecioMnt);
                            break;
                    }
                    if (listaprecioMnt.Idlistaprecio > 0)
                    {                      
                        Tipolistatipocondicion tipolistatipocondicion1 = new Tipolistatipocondicion();
                        tipolistatipocondicion1.Idtipolistatipocondicion = 0;
                        tipolistatipocondicion1.Idtipolista = listaprecioMnt.Idtipolista;
                        tipolistatipocondicion1.Idtipocondicion = listaprecioMnt.Idcondicioncreditoopcion1;
                        tipolistatipocondicion1.Idlistaprecio = listaprecioMnt.Idlistaprecio;

                        Tipolistatipocondicion tipolistatipocondicion2 = new Tipolistatipocondicion();
                        tipolistatipocondicion2.Idtipolistatipocondicion = 0;
                        tipolistatipocondicion2.Idtipolista = listaprecioMnt.Idtipolista;
                        tipolistatipocondicion2.Idtipocondicion = listaprecioMnt.Idcondicioncreditoopcion2;
                        tipolistatipocondicion2.Idlistaprecio = listaprecioMnt.Idlistaprecio;

                        db.Save(tipolistatipocondicion1);
                        db.Save(tipolistatipocondicion2);

                        Tipocondicion tipocondicionContado = db.Single<Tipocondicion>(x => x.Nombrecondicion == "CONTADO");

                        if (tipocondicionContado != null)
                        {
                            Tipolistatipocondicion tipolistacontado = new Tipolistatipocondicion();
                            tipolistacontado.Idtipolistatipocondicion = 0;
                            tipolistacontado.Idtipolista = listaprecioMnt.Idtipolista;
                            tipolistacontado.Idtipocondicion = tipocondicionContado.Idtipocondicion;
                            tipolistacontado.Idlistaprecio = listaprecioMnt.Idlistaprecio;
                            db.Save(tipolistacontado);
                        }

                    }
                    trans.Commit();
                }
            }
            return listaprecioMnt.Idlistaprecio;
        }
    }
}

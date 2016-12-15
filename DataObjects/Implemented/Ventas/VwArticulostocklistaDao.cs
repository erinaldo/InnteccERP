using System;
using System.Collections.Generic;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
    public class VwArticulostocklistaDao : Dao<VwArticulostocklista>, IVwArticulostocklistaDao
	{
        public List<VwArticulostocklista> ConsultaArticuloStockLista(int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta, string condicion)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                string sql = string.Format("SELECT * FROM ventas.fnlistaprecio(null,{0},{1},{2},'{3:yyyy-MM-dd}') where {4}", idSucursal, idAlmacen, idTipoLista, fechaConsulta, condicion);
                List<VwArticulostocklista> results = db.SqlList<VwArticulostocklista>(sql);
                return results;
            }
	    }

        public List<VwArticulostocklista> ConsultaArticuloStockLista(int idArticulo, int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                string sql = string.Format("SELECT * FROM ventas.fnlistaprecio({0},{1},{2},{3},'{4:yyyy-MM-dd}')", idArticulo, idSucursal, idAlmacen, idTipoLista, fechaConsulta);
                List<VwArticulostocklista> results = db.SqlList<VwArticulostocklista>(sql);
                return results;
            }

        }

        public List<VwArticulostocklista> ConsultaArticuloStockLista(int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta, int idArticulo)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                string sql = string.Format("SELECT * FROM ventas.fnlistaprecio({0},{1},{2},{3},'{4:yyyy-MM-dd}')", idArticulo, idSucursal, idAlmacen, idTipoLista, fechaConsulta);
                List<VwArticulostocklista> results = db.SqlList<VwArticulostocklista>(sql);
                return results;
            }
        }
	}
}

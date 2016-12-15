using System;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class ArticuloDao : Dao<Articulo>, IArticuloDao
	{
	    public decimal ObtenerStockAlmacen(int idArticulo, DateTime fechaInicial, DateTime fechaFinal, int? idAlmacen)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                string query =
                String.Format(@"select  COALESCE(sum(kardex.inicial), 0) + 
                                        COALESCE(sum(kardex.entrada), 0) -
                                        COALESCE(sum(kardex.salida), 0) as stock
                                        FROM almacen.fnkardexfisico({0}, '{1}', '{2}', {3}) kardex", idArticulo, fechaInicial.ToString("yyyy-MM-dd"), fechaFinal.ToString("yyyy-MM-dd"), idAlmacen);

                return  db.SqlScalar<decimal>(query);
                
            }
	    }
	}
}

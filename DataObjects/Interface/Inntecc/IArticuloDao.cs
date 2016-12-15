using System;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IArticuloDao : IDao<Articulo>
	{
        decimal ObtenerStockAlmacen(int idArticulo, DateTime fechaInicial, DateTime fechaFinal, int? idAlmacen);
	}
}

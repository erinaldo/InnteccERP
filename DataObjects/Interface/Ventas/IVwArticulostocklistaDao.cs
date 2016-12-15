using System;
using System.Collections.Generic;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IVwArticulostocklistaDao : IDao<VwArticulostocklista>
	{
	    List<VwArticulostocklista> ConsultaArticuloStockLista(int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta,string condicion);
        List<VwArticulostocklista> ConsultaArticuloStockLista(int idArticulo, int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta);
        List<VwArticulostocklista> ConsultaArticuloStockLista(int idSucursal, int idAlmacen, int idTipoLista, DateTime fechaConsulta, int idArticulo);
	}
}

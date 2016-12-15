using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IOrdencompraDao : IDao<Ordencompra>
	{
	    bool GuardarOrdenDeCompra(TipoMantenimiento tipoMantenimiento, Ordencompra entidadCab, List<VwOrdencompradet> entidadDetList);
	}
}

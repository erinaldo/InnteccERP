using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IOrdendeventaDao : IDao<Ordendeventa>
	{
        bool GuardarOrdendeVenta(TipoMantenimiento tipoMantenimiento, Ordendeventa entidadCab, List<VwOrdendeventadet> entidadDetList);
	}
}

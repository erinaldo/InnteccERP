using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface INotacreditoDao : IDao<Notacredito>
	{
        bool GuardarNotacredito(TipoMantenimiento tipoMantenimiento, Notacredito entidadCab, List<VwNotacreditodet> entidadDetList);
	}
}

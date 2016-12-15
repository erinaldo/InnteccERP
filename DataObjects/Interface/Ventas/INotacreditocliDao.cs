using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface INotacreditocliDao : IDao<Notacreditocli>
	{
	    bool GuardarNotaCreditoCli(TipoMantenimiento tipoMantenimiento, Notacreditocli entidadCab, List<VwNotacreditoclidet> entidadDetList);
	}
}

using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface INotadebitoDao : IDao<Notadebito>
	{
        bool GuardarNotadebito(TipoMantenimiento tipoMantenimiento, Notadebito entidadCab, List<VwNotadebitodet> entidadDetList);
	}
}

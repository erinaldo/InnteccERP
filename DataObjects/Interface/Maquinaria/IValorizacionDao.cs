using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IValorizacionDao : IDao<Valorizacion>
	{
        bool GuardarValorizacion(TipoMantenimiento tipoMantenimiento, Valorizacion entidadCab, List<VwValorizaciondet> entidadDetList);
	}
}

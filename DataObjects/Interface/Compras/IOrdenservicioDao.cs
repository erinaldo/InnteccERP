using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IOrdenservicioDao : IDao<Ordenservicio>
	{
        bool GuardarOrdenDeServicio(TipoMantenimiento tipoMantenimiento, Ordenservicio entidadCab, List<VwOrdenserviciodet> entidadDetList);
	}
}

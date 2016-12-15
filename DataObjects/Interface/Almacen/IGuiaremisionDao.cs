using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IGuiaremisionDao : IDao<Guiaremision>
	{
        bool GuardarGuiaremision(TipoMantenimiento tipoMantenimiento, Guiaremision entidadCab, List<VwGuiaremisiondet> entidadDetList);
	}
}

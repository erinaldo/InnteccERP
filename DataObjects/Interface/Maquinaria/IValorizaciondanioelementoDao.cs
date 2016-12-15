using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IValorizaciondanioelementoDao : IDao<Valorizaciondanioelemento>
	{
	    bool GuardarValorizacionDanioElemento(TipoMantenimiento tipoMantenimiento, Valorizaciondanioelemento entidadCab,List<VwValorizacionelemento> elementoDetList, List<VwValorizaciondanio> danioDetList);

	}
}

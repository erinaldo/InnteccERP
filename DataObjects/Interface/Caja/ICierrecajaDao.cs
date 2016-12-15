using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ICierrecajaDao : IDao<Cierrecaja>
	{
        bool GuardarCierrecaja(TipoMantenimiento tipoMantenimiento, Cierrecaja entidadCab, List<VwCierrecajadet> elementoDetList);

	}
}

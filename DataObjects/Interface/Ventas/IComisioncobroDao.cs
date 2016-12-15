using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IComisioncobroDao : IDao<Comisioncobro>
	{
        bool GuardarComisionCobro(TipoMantenimiento tipoMantenimiento, Comisioncobro entidadCab, List<Comisioncobrodet> entidadDetList);
	}
}

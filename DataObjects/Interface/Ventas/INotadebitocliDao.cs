using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface INotadebitocliDao : IDao<Notadebitocli>
	{
        bool GuardarNotaDebitoCli(TipoMantenimiento tipoMantenimiento, Notadebitocli entidadCab, List<VwNotadebitoclidet> entidadDetList);
	}
}

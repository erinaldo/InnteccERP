using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IRequerimientoDao : IDao<Requerimiento>
	{
	    bool GuardarRequerimiento(TipoMantenimiento tipoMantenimiento, Requerimiento entidadCab, List<VwRequerimientodet> entidadDetList);
	    bool RequerimientoTieneReferenciasOrdenDeCompra(int idRequerimiento);
	}
}

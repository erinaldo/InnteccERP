using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface ICotizacionclienteDao : IDao<Cotizacioncliente>
	{
        bool GuardarCotizacionCliente(TipoMantenimiento tipoMantenimiento, Cotizacioncliente entidadCab, List<VwCotizacionclientedet> entidadDetList);
	}
}

using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IValorizacionproveedorDao : IDao<Valorizacionproveedor>
	{
	    bool GuardarValorizacionProveedor(TipoMantenimiento tipoMantenimiento, Valorizacionproveedor entidadCab, List<VwValorizacionproveedordet> entidadDetList);
	}
}

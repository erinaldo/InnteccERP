using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IMantenimientoDao : IDao<Mantenimiento>
	{
	    bool GuardarMantenimiento(TipoMantenimiento tipoMantenimiento, Mantenimiento entidadCab, List<Mantenimientoimagen> entidadDetList, string rutaArchivosServidor);
	}
}

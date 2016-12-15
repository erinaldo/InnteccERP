using System.Collections.Generic;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;

namespace DataObjects
{
	public interface IListaprecioDao : IDao<Listaprecio>
	{
        int GuardarListaprecio(TipoMantenimiento tipoMantenimiento, Listaprecio listaprecioMnt);
        
	}
}

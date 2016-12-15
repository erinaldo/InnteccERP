using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticulolistaprecio()
		{
			return VwArticulolistaprecioDao.Count();
		}

		public long CountVwArticulolistaprecio(Expression<Func<VwArticulolistaprecio, bool>> criteria)
		{
			return VwArticulolistaprecioDao.Count(criteria);
		}

		public List<VwArticulolistaprecio> GetAllVwArticulolistaprecio()
		{
			return VwArticulolistaprecioDao.GetAll();
		}

		public List<VwArticulolistaprecio> GetAllVwArticulolistaprecio(Expression<Func<VwArticulolistaprecio, bool>> criteria)
		{
			return VwArticulolistaprecioDao.GetAll(criteria);
		}

		public List<VwArticulolistaprecio> GetAllVwArticulolistaprecio(string orders)
		{
			return VwArticulolistaprecioDao.GetAll(orders);
		}

		public List<VwArticulolistaprecio> GetAllVwArticulolistaprecio(string conditions, string orders)
		{
			return VwArticulolistaprecioDao.GetAll(conditions, orders);
		}

		public VwArticulolistaprecio GetVwArticulolistaprecio(int id)
		{
			return VwArticulolistaprecioDao.Get(id);
		}

		public VwArticulolistaprecio GetVwArticulolistaprecio(Expression<Func<VwArticulolistaprecio, bool>> criteria)
		{
			return VwArticulolistaprecioDao.Get(criteria);
		}
	}
}

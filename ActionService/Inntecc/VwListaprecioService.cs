using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwListaprecio()
		{
			return VwListaprecioDao.Count();
		}

		public long CountVwListaprecio(Expression<Func<VwListaprecio, bool>> criteria)
		{
			return VwListaprecioDao.Count(criteria);
		}

		public List<VwListaprecio> GetAllVwListaprecio()
		{
			return VwListaprecioDao.GetAll();
		}

		public List<VwListaprecio> GetAllVwListaprecio(Expression<Func<VwListaprecio, bool>> criteria)
		{
			return VwListaprecioDao.GetAll(criteria);
		}

		public List<VwListaprecio> GetAllVwListaprecio(string orders)
		{
			return VwListaprecioDao.GetAll(orders);
		}

		public List<VwListaprecio> GetAllVwListaprecio(string conditions, string orders)
		{
			return VwListaprecioDao.GetAll(conditions, orders);
		}

		public VwListaprecio GetVwListaprecio(int id)
		{
			return VwListaprecioDao.Get(id);
		}

		public VwListaprecio GetVwListaprecio(Expression<Func<VwListaprecio, bool>> criteria)
		{
			return VwListaprecioDao.Get(criteria);
		}
	}
}

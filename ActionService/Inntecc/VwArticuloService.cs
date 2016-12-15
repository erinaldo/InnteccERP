using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticulo()
		{
			return VwArticuloDao.Count();
		}

		public long CountVwArticulo(Expression<Func<VwArticulo, bool>> criteria)
		{
			return VwArticuloDao.Count(criteria);
		}

		public List<VwArticulo> GetAllVwArticulo()
		{
			return VwArticuloDao.GetAll();
		}

		public List<VwArticulo> GetAllVwArticulo(Expression<Func<VwArticulo, bool>> criteria)
		{
			return VwArticuloDao.GetAll(criteria);
		}

		public List<VwArticulo> GetAllVwArticulo(string orders)
		{
			return VwArticuloDao.GetAll(orders);
		}

		public List<VwArticulo> GetAllVwArticulo(string conditions, string orders)
		{
			return VwArticuloDao.GetAll(conditions, orders);
		}

		public VwArticulo GetVwArticulo(int id)
		{
			return VwArticuloDao.Get(id);
		}

		public VwArticulo GetVwArticulo(Expression<Func<VwArticulo, bool>> criteria)
		{
			return VwArticuloDao.Get(criteria);
		}
	}
}

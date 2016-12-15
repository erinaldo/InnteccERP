using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwPaginaitem()
		{
			return VwPaginaitemDao.Count();
		}

		public long CountVwPaginaitem(Expression<Func<VwPaginaitem, bool>> criteria)
		{
			return VwPaginaitemDao.Count(criteria);
		}

		public List<VwPaginaitem> GetAllVwPaginaitem()
		{
			return VwPaginaitemDao.GetAll();
		}

		public List<VwPaginaitem> GetAllVwPaginaitem(Expression<Func<VwPaginaitem, bool>> criteria)
		{
			return VwPaginaitemDao.GetAll(criteria);
		}

		public List<VwPaginaitem> GetAllVwPaginaitem(string orders)
		{
			return VwPaginaitemDao.GetAll(orders);
		}

		public List<VwPaginaitem> GetAllVwPaginaitem(string conditions, string orders)
		{
			return VwPaginaitemDao.GetAll(conditions, orders);
		}

		public VwPaginaitem GetVwPaginaitem(int id)
		{
			return VwPaginaitemDao.Get(id);
		}

		public VwPaginaitem GetVwPaginaitem(Expression<Func<VwPaginaitem, bool>> criteria)
		{
			return VwPaginaitemDao.Get(criteria);
		}
	}
}

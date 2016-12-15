using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotadebitocli()
		{
			return VwNotadebitocliDao.Count();
		}

		public long CountVwNotadebitocli(Expression<Func<VwNotadebitocli, bool>> criteria)
		{
			return VwNotadebitocliDao.Count(criteria);
		}

		public List<VwNotadebitocli> GetAllVwNotadebitocli()
		{
			return VwNotadebitocliDao.GetAll();
		}

		public List<VwNotadebitocli> GetAllVwNotadebitocli(Expression<Func<VwNotadebitocli, bool>> criteria)
		{
			return VwNotadebitocliDao.GetAll(criteria);
		}

		public List<VwNotadebitocli> GetAllVwNotadebitocli(string orders)
		{
			return VwNotadebitocliDao.GetAll(orders);
		}

		public List<VwNotadebitocli> GetAllVwNotadebitocli(string conditions, string orders)
		{
			return VwNotadebitocliDao.GetAll(conditions, orders);
		}

		public VwNotadebitocli GetVwNotadebitocli(int id)
		{
			return VwNotadebitocliDao.Get(id);
		}

		public VwNotadebitocli GetVwNotadebitocli(Expression<Func<VwNotadebitocli, bool>> criteria)
		{
			return VwNotadebitocliDao.Get(criteria);
		}
	}
}

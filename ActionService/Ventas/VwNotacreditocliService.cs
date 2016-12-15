using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotacreditocli()
		{
			return VwNotacreditocliDao.Count();
		}

		public long CountVwNotacreditocli(Expression<Func<VwNotacreditocli, bool>> criteria)
		{
			return VwNotacreditocliDao.Count(criteria);
		}

		public List<VwNotacreditocli> GetAllVwNotacreditocli()
		{
			return VwNotacreditocliDao.GetAll();
		}

		public List<VwNotacreditocli> GetAllVwNotacreditocli(Expression<Func<VwNotacreditocli, bool>> criteria)
		{
			return VwNotacreditocliDao.GetAll(criteria);
		}

		public List<VwNotacreditocli> GetAllVwNotacreditocli(string orders)
		{
			return VwNotacreditocliDao.GetAll(orders);
		}

		public List<VwNotacreditocli> GetAllVwNotacreditocli(string conditions, string orders)
		{
			return VwNotacreditocliDao.GetAll(conditions, orders);
		}

		public VwNotacreditocli GetVwNotacreditocli(int id)
		{
			return VwNotacreditocliDao.Get(id);
		}

		public VwNotacreditocli GetVwNotacreditocli(Expression<Func<VwNotacreditocli, bool>> criteria)
		{
			return VwNotacreditocliDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotacredito()
		{
			return VwNotacreditoDao.Count();
		}

		public long CountVwNotacredito(Expression<Func<VwNotacredito, bool>> criteria)
		{
			return VwNotacreditoDao.Count(criteria);
		}

		public List<VwNotacredito> GetAllVwNotacredito()
		{
			return VwNotacreditoDao.GetAll();
		}

		public List<VwNotacredito> GetAllVwNotacredito(Expression<Func<VwNotacredito, bool>> criteria)
		{
			return VwNotacreditoDao.GetAll(criteria);
		}

		public List<VwNotacredito> GetAllVwNotacredito(string orders)
		{
			return VwNotacreditoDao.GetAll(orders);
		}

		public List<VwNotacredito> GetAllVwNotacredito(string conditions, string orders)
		{
			return VwNotacreditoDao.GetAll(conditions, orders);
		}

		public VwNotacredito GetVwNotacredito(int id)
		{
			return VwNotacreditoDao.Get(id);
		}

		public VwNotacredito GetVwNotacredito(Expression<Func<VwNotacredito, bool>> criteria)
		{
			return VwNotacreditoDao.Get(criteria);
		}
	}
}

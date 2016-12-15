using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotacreditodet()
		{
			return VwNotacreditodetDao.Count();
		}

		public long CountVwNotacreditodet(Expression<Func<VwNotacreditodet, bool>> criteria)
		{
			return VwNotacreditodetDao.Count(criteria);
		}

		public List<VwNotacreditodet> GetAllVwNotacreditodet()
		{
			return VwNotacreditodetDao.GetAll();
		}

		public List<VwNotacreditodet> GetAllVwNotacreditodet(Expression<Func<VwNotacreditodet, bool>> criteria)
		{
			return VwNotacreditodetDao.GetAll(criteria);
		}

		public List<VwNotacreditodet> GetAllVwNotacreditodet(string orders)
		{
			return VwNotacreditodetDao.GetAll(orders);
		}

		public List<VwNotacreditodet> GetAllVwNotacreditodet(string conditions, string orders)
		{
			return VwNotacreditodetDao.GetAll(conditions, orders);
		}

		public VwNotacreditodet GetVwNotacreditodet(int id)
		{
			return VwNotacreditodetDao.Get(id);
		}

		public VwNotacreditodet GetVwNotacreditodet(Expression<Func<VwNotacreditodet, bool>> criteria)
		{
			return VwNotacreditodetDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotacreditoclidet()
		{
			return VwNotacreditoclidetDao.Count();
		}

		public long CountVwNotacreditoclidet(Expression<Func<VwNotacreditoclidet, bool>> criteria)
		{
			return VwNotacreditoclidetDao.Count(criteria);
		}

		public List<VwNotacreditoclidet> GetAllVwNotacreditoclidet()
		{
			return VwNotacreditoclidetDao.GetAll();
		}

		public List<VwNotacreditoclidet> GetAllVwNotacreditoclidet(Expression<Func<VwNotacreditoclidet, bool>> criteria)
		{
			return VwNotacreditoclidetDao.GetAll(criteria);
		}

		public List<VwNotacreditoclidet> GetAllVwNotacreditoclidet(string orders)
		{
			return VwNotacreditoclidetDao.GetAll(orders);
		}

		public List<VwNotacreditoclidet> GetAllVwNotacreditoclidet(string conditions, string orders)
		{
			return VwNotacreditoclidetDao.GetAll(conditions, orders);
		}

		public VwNotacreditoclidet GetVwNotacreditoclidet(int id)
		{
			return VwNotacreditoclidetDao.Get(id);
		}

		public VwNotacreditoclidet GetVwNotacreditoclidet(Expression<Func<VwNotacreditoclidet, bool>> criteria)
		{
			return VwNotacreditoclidetDao.Get(criteria);
		}
	}
}

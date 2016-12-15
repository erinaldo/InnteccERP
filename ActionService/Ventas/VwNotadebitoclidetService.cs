using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotadebitoclidet()
		{
			return VwNotadebitoclidetDao.Count();
		}

		public long CountVwNotadebitoclidet(Expression<Func<VwNotadebitoclidet, bool>> criteria)
		{
			return VwNotadebitoclidetDao.Count(criteria);
		}

		public List<VwNotadebitoclidet> GetAllVwNotadebitoclidet()
		{
			return VwNotadebitoclidetDao.GetAll();
		}

		public List<VwNotadebitoclidet> GetAllVwNotadebitoclidet(Expression<Func<VwNotadebitoclidet, bool>> criteria)
		{
			return VwNotadebitoclidetDao.GetAll(criteria);
		}

		public List<VwNotadebitoclidet> GetAllVwNotadebitoclidet(string orders)
		{
			return VwNotadebitoclidetDao.GetAll(orders);
		}

		public List<VwNotadebitoclidet> GetAllVwNotadebitoclidet(string conditions, string orders)
		{
			return VwNotadebitoclidetDao.GetAll(conditions, orders);
		}

		public VwNotadebitoclidet GetVwNotadebitoclidet(int id)
		{
			return VwNotadebitoclidetDao.Get(id);
		}

		public VwNotadebitoclidet GetVwNotadebitoclidet(Expression<Func<VwNotadebitoclidet, bool>> criteria)
		{
			return VwNotadebitoclidetDao.Get(criteria);
		}
	}
}

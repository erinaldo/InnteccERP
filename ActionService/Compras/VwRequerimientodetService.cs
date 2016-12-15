using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRequerimientodet()
		{
			return VwRequerimientodetDao.Count();
		}

		public long CountVwRequerimientodet(Expression<Func<VwRequerimientodet, bool>> criteria)
		{
			return VwRequerimientodetDao.Count(criteria);
		}

		public List<VwRequerimientodet> GetAllVwRequerimientodet()
		{
			return VwRequerimientodetDao.GetAll();
		}

		public List<VwRequerimientodet> GetAllVwRequerimientodet(Expression<Func<VwRequerimientodet, bool>> criteria)
		{
			return VwRequerimientodetDao.GetAll(criteria);
		}

		public List<VwRequerimientodet> GetAllVwRequerimientodet(string orders)
		{
			return VwRequerimientodetDao.GetAll(orders);
		}

		public List<VwRequerimientodet> GetAllVwRequerimientodet(string conditions, string orders)
		{
			return VwRequerimientodetDao.GetAll(conditions, orders);
		}

		public VwRequerimientodet GetVwRequerimientodet(int id)
		{
			return VwRequerimientodetDao.Get(id);
		}

		public VwRequerimientodet GetVwRequerimientodet(Expression<Func<VwRequerimientodet, bool>> criteria)
		{
			return VwRequerimientodetDao.Get(criteria);
		}
	}
}

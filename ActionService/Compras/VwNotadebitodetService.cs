using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotadebitodet()
		{
			return VwNotadebitodetDao.Count();
		}

		public long CountVwNotadebitodet(Expression<Func<VwNotadebitodet, bool>> criteria)
		{
			return VwNotadebitodetDao.Count(criteria);
		}

		public List<VwNotadebitodet> GetAllVwNotadebitodet()
		{
			return VwNotadebitodetDao.GetAll();
		}

		public List<VwNotadebitodet> GetAllVwNotadebitodet(Expression<Func<VwNotadebitodet, bool>> criteria)
		{
			return VwNotadebitodetDao.GetAll(criteria);
		}

		public List<VwNotadebitodet> GetAllVwNotadebitodet(string orders)
		{
			return VwNotadebitodetDao.GetAll(orders);
		}

		public List<VwNotadebitodet> GetAllVwNotadebitodet(string conditions, string orders)
		{
			return VwNotadebitodetDao.GetAll(conditions, orders);
		}

		public VwNotadebitodet GetVwNotadebitodet(int id)
		{
			return VwNotadebitodetDao.Get(id);
		}

		public VwNotadebitodet GetVwNotadebitodet(Expression<Func<VwNotadebitodet, bool>> criteria)
		{
			return VwNotadebitodetDao.Get(criteria);
		}
	}
}

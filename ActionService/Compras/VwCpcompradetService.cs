using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpcompradet()
		{
			return VwCpcompradetDao.Count();
		}

		public long CountVwCpcompradet(Expression<Func<VwCpcompradet, bool>> criteria)
		{
			return VwCpcompradetDao.Count(criteria);
		}

		public List<VwCpcompradet> GetAllVwCpcompradet()
		{
			return VwCpcompradetDao.GetAll();
		}

		public List<VwCpcompradet> GetAllVwCpcompradet(Expression<Func<VwCpcompradet, bool>> criteria)
		{
			return VwCpcompradetDao.GetAll(criteria);
		}

		public List<VwCpcompradet> GetAllVwCpcompradet(string orders)
		{
			return VwCpcompradetDao.GetAll(orders);
		}

		public List<VwCpcompradet> GetAllVwCpcompradet(string conditions, string orders)
		{
			return VwCpcompradetDao.GetAll(conditions, orders);
		}

		public VwCpcompradet GetVwCpcompradet(int id)
		{
			return VwCpcompradetDao.Get(id);
		}

		public VwCpcompradet GetVwCpcompradet(Expression<Func<VwCpcompradet, bool>> criteria)
		{
			return VwCpcompradetDao.Get(criteria);
		}
	}
}

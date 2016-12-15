using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpcompraimpnd()
		{
			return VwCpcompraimpndDao.Count();
		}

		public long CountVwCpcompraimpnd(Expression<Func<VwCpcompraimpnd, bool>> criteria)
		{
			return VwCpcompraimpndDao.Count(criteria);
		}

		public List<VwCpcompraimpnd> GetAllVwCpcompraimpnd()
		{
			return VwCpcompraimpndDao.GetAll();
		}

		public List<VwCpcompraimpnd> GetAllVwCpcompraimpnd(Expression<Func<VwCpcompraimpnd, bool>> criteria)
		{
			return VwCpcompraimpndDao.GetAll(criteria);
		}

		public List<VwCpcompraimpnd> GetAllVwCpcompraimpnd(string orders)
		{
			return VwCpcompraimpndDao.GetAll(orders);
		}

		public List<VwCpcompraimpnd> GetAllVwCpcompraimpnd(string conditions, string orders)
		{
			return VwCpcompraimpndDao.GetAll(conditions, orders);
		}

		public VwCpcompraimpnd GetVwCpcompraimpnd(int id)
		{
			return VwCpcompraimpndDao.Get(id);
		}

		public VwCpcompraimpnd GetVwCpcompraimpnd(Expression<Func<VwCpcompraimpnd, bool>> criteria)
		{
			return VwCpcompraimpndDao.Get(criteria);
		}
	}
}

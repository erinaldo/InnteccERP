using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpventaimpnd()
		{
			return VwCpventaimpndDao.Count();
		}

		public long CountVwCpventaimpnd(Expression<Func<VwCpventaimpnd, bool>> criteria)
		{
			return VwCpventaimpndDao.Count(criteria);
		}

		public List<VwCpventaimpnd> GetAllVwCpventaimpnd()
		{
			return VwCpventaimpndDao.GetAll();
		}

		public List<VwCpventaimpnd> GetAllVwCpventaimpnd(Expression<Func<VwCpventaimpnd, bool>> criteria)
		{
			return VwCpventaimpndDao.GetAll(criteria);
		}

		public List<VwCpventaimpnd> GetAllVwCpventaimpnd(string orders)
		{
			return VwCpventaimpndDao.GetAll(orders);
		}

		public List<VwCpventaimpnd> GetAllVwCpventaimpnd(string conditions, string orders)
		{
			return VwCpventaimpndDao.GetAll(conditions, orders);
		}

		public VwCpventaimpnd GetVwCpventaimpnd(int id)
		{
			return VwCpventaimpndDao.Get(id);
		}

		public VwCpventaimpnd GetVwCpventaimpnd(Expression<Func<VwCpventaimpnd, bool>> criteria)
		{
			return VwCpventaimpndDao.Get(criteria);
		}
	}
}

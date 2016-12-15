using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpventadet()
		{
			return VwCpventadetDao.Count();
		}

		public long CountVwCpventadet(Expression<Func<VwCpventadet, bool>> criteria)
		{
			return VwCpventadetDao.Count(criteria);
		}

		public List<VwCpventadet> GetAllVwCpventadet()
		{
			return VwCpventadetDao.GetAll();
		}

		public List<VwCpventadet> GetAllVwCpventadet(Expression<Func<VwCpventadet, bool>> criteria)
		{
			return VwCpventadetDao.GetAll(criteria);
		}

		public List<VwCpventadet> GetAllVwCpventadet(string orders)
		{
			return VwCpventadetDao.GetAll(orders);
		}

		public List<VwCpventadet> GetAllVwCpventadet(string conditions, string orders)
		{
			return VwCpventadetDao.GetAll(conditions, orders);
		}

		public VwCpventadet GetVwCpventadet(int id)
		{
			return VwCpventadetDao.Get(id);
		}

		public VwCpventadet GetVwCpventadet(Expression<Func<VwCpventadet, bool>> criteria)
		{
			return VwCpventadetDao.Get(criteria);
		}
	}
}

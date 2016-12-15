using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdendeventavalorizacpventaimp()
		{
			return VwOrdendeventavalorizacpventaimpDao.Count();
		}

		public long CountVwOrdendeventavalorizacpventaimp(Expression<Func<VwOrdendeventavalorizacpventaimp, bool>> criteria)
		{
			return VwOrdendeventavalorizacpventaimpDao.Count(criteria);
		}

		public List<VwOrdendeventavalorizacpventaimp> GetAllVwOrdendeventavalorizacpventaimp()
		{
			return VwOrdendeventavalorizacpventaimpDao.GetAll();
		}

		public List<VwOrdendeventavalorizacpventaimp> GetAllVwOrdendeventavalorizacpventaimp(Expression<Func<VwOrdendeventavalorizacpventaimp, bool>> criteria)
		{
			return VwOrdendeventavalorizacpventaimpDao.GetAll(criteria);
		}

		public List<VwOrdendeventavalorizacpventaimp> GetAllVwOrdendeventavalorizacpventaimp(string orders)
		{
			return VwOrdendeventavalorizacpventaimpDao.GetAll(orders);
		}

		public List<VwOrdendeventavalorizacpventaimp> GetAllVwOrdendeventavalorizacpventaimp(string conditions, string orders)
		{
			return VwOrdendeventavalorizacpventaimpDao.GetAll(conditions, orders);
		}

		public VwOrdendeventavalorizacpventaimp GetVwOrdendeventavalorizacpventaimp(int id)
		{
			return VwOrdendeventavalorizacpventaimpDao.Get(id);
		}

		public VwOrdendeventavalorizacpventaimp GetVwOrdendeventavalorizacpventaimp(Expression<Func<VwOrdendeventavalorizacpventaimp, bool>> criteria)
		{
			return VwOrdendeventavalorizacpventaimpDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdendeventadetcpventaimp()
		{
			return VwOrdendeventadetcpventaimpDao.Count();
		}

		public long CountVwOrdendeventadetcpventaimp(Expression<Func<VwOrdendeventadetcpventaimp, bool>> criteria)
		{
			return VwOrdendeventadetcpventaimpDao.Count(criteria);
		}

		public List<VwOrdendeventadetcpventaimp> GetAllVwOrdendeventadetcpventaimp()
		{
			return VwOrdendeventadetcpventaimpDao.GetAll();
		}

		public List<VwOrdendeventadetcpventaimp> GetAllVwOrdendeventadetcpventaimp(Expression<Func<VwOrdendeventadetcpventaimp, bool>> criteria)
		{
			return VwOrdendeventadetcpventaimpDao.GetAll(criteria);
		}

		public List<VwOrdendeventadetcpventaimp> GetAllVwOrdendeventadetcpventaimp(string orders)
		{
			return VwOrdendeventadetcpventaimpDao.GetAll(orders);
		}

		public List<VwOrdendeventadetcpventaimp> GetAllVwOrdendeventadetcpventaimp(string conditions, string orders)
		{
			return VwOrdendeventadetcpventaimpDao.GetAll(conditions, orders);
		}

		public VwOrdendeventadetcpventaimp GetVwOrdendeventadetcpventaimp(int id)
		{
			return VwOrdendeventadetcpventaimpDao.Get(id);
		}

		public VwOrdendeventadetcpventaimp GetVwOrdendeventadetcpventaimp(Expression<Func<VwOrdendeventadetcpventaimp, bool>> criteria)
		{
			return VwOrdendeventadetcpventaimpDao.Get(criteria);
		}
	}
}

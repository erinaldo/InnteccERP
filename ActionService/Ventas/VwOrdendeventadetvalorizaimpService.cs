using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdendeventadetvalorizaimp()
		{
			return VwOrdendeventadetvalorizaimpDao.Count();
		}

		public long CountVwOrdendeventadetvalorizaimp(Expression<Func<VwOrdendeventadetvalorizaimp, bool>> criteria)
		{
			return VwOrdendeventadetvalorizaimpDao.Count(criteria);
		}

		public List<VwOrdendeventadetvalorizaimp> GetAllVwOrdendeventadetvalorizaimp()
		{
			return VwOrdendeventadetvalorizaimpDao.GetAll();
		}

		public List<VwOrdendeventadetvalorizaimp> GetAllVwOrdendeventadetvalorizaimp(Expression<Func<VwOrdendeventadetvalorizaimp, bool>> criteria)
		{
			return VwOrdendeventadetvalorizaimpDao.GetAll(criteria);
		}

		public List<VwOrdendeventadetvalorizaimp> GetAllVwOrdendeventadetvalorizaimp(string orders)
		{
			return VwOrdendeventadetvalorizaimpDao.GetAll(orders);
		}

		public List<VwOrdendeventadetvalorizaimp> GetAllVwOrdendeventadetvalorizaimp(string conditions, string orders)
		{
			return VwOrdendeventadetvalorizaimpDao.GetAll(conditions, orders);
		}

		public VwOrdendeventadetvalorizaimp GetVwOrdendeventadetvalorizaimp(int id)
		{
			return VwOrdendeventadetvalorizaimpDao.Get(id);
		}

		public VwOrdendeventadetvalorizaimp GetVwOrdendeventadetvalorizaimp(Expression<Func<VwOrdendeventadetvalorizaimp, bool>> criteria)
		{
			return VwOrdendeventadetvalorizaimpDao.Get(criteria);
		}
	}
}

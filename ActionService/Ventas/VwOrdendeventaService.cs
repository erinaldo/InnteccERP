using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdendeventa()
		{
			return VwOrdendeventaDao.Count();
		}

		public long CountVwOrdendeventa(Expression<Func<VwOrdendeventa, bool>> criteria)
		{
			return VwOrdendeventaDao.Count(criteria);
		}

		public List<VwOrdendeventa> GetAllVwOrdendeventa()
		{
			return VwOrdendeventaDao.GetAll();
		}

		public List<VwOrdendeventa> GetAllVwOrdendeventa(Expression<Func<VwOrdendeventa, bool>> criteria)
		{
			return VwOrdendeventaDao.GetAll(criteria);
		}

		public List<VwOrdendeventa> GetAllVwOrdendeventa(string orders)
		{
			return VwOrdendeventaDao.GetAll(orders);
		}

		public List<VwOrdendeventa> GetAllVwOrdendeventa(string conditions, string orders)
		{
			return VwOrdendeventaDao.GetAll(conditions, orders);
		}

		public VwOrdendeventa GetVwOrdendeventa(int id)
		{
			return VwOrdendeventaDao.Get(id);
		}

		public VwOrdendeventa GetVwOrdendeventa(Expression<Func<VwOrdendeventa, bool>> criteria)
		{
			return VwOrdendeventaDao.Get(criteria);
		}
	}
}

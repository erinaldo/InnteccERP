using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdendeventadetalle()
		{
			return VwOrdendeventadetalleDao.Count();
		}

		public long CountVwOrdendeventadetalle(Expression<Func<VwOrdendeventadet, bool>> criteria)
		{
			return VwOrdendeventadetalleDao.Count(criteria);
		}

		public List<VwOrdendeventadet> GetAllVwOrdendeventadetalle()
		{
			return VwOrdendeventadetalleDao.GetAll();
		}

		public List<VwOrdendeventadet> GetAllVwOrdendeventadetalle(Expression<Func<VwOrdendeventadet, bool>> criteria)
		{
			return VwOrdendeventadetalleDao.GetAll(criteria);
		}

		public List<VwOrdendeventadet> GetAllVwOrdendeventadetalle(string orders)
		{
			return VwOrdendeventadetalleDao.GetAll(orders);
		}

		public List<VwOrdendeventadet> GetAllVwOrdendeventadetalle(string conditions, string orders)
		{
			return VwOrdendeventadetalleDao.GetAll(conditions, orders);
		}

		public VwOrdendeventadet GetVwOrdendeventadetalle(int id)
		{
			return VwOrdendeventadetalleDao.Get(id);
		}

		public VwOrdendeventadet GetVwOrdendeventadetalle(Expression<Func<VwOrdendeventadet, bool>> criteria)
		{
			return VwOrdendeventadetalleDao.Get(criteria);
		}
	}
}

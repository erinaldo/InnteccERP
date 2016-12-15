using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdendeventadetimpguiaremision()
		{
			return VwOrdendeventadetimpguiaremisionDao.Count();
		}

		public long CountVwOrdendeventadetimpguiaremision(Expression<Func<VwOrdendeventadetimpguiaremision, bool>> criteria)
		{
			return VwOrdendeventadetimpguiaremisionDao.Count(criteria);
		}

		public List<VwOrdendeventadetimpguiaremision> GetAllVwOrdendeventadetimpguiaremision()
		{
			return VwOrdendeventadetimpguiaremisionDao.GetAll();
		}

		public List<VwOrdendeventadetimpguiaremision> GetAllVwOrdendeventadetimpguiaremision(Expression<Func<VwOrdendeventadetimpguiaremision, bool>> criteria)
		{
			return VwOrdendeventadetimpguiaremisionDao.GetAll(criteria);
		}

		public List<VwOrdendeventadetimpguiaremision> GetAllVwOrdendeventadetimpguiaremision(string orders)
		{
			return VwOrdendeventadetimpguiaremisionDao.GetAll(orders);
		}

		public List<VwOrdendeventadetimpguiaremision> GetAllVwOrdendeventadetimpguiaremision(string conditions, string orders)
		{
			return VwOrdendeventadetimpguiaremisionDao.GetAll(conditions, orders);
		}

		public VwOrdendeventadetimpguiaremision GetVwOrdendeventadetimpguiaremision(int id)
		{
			return VwOrdendeventadetimpguiaremisionDao.Get(id);
		}

		public VwOrdendeventadetimpguiaremision GetVwOrdendeventadetimpguiaremision(Expression<Func<VwOrdendeventadetimpguiaremision, bool>> criteria)
		{
			return VwOrdendeventadetimpguiaremisionDao.Get(criteria);
		}
	}
}

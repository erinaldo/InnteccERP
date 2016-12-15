using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwGuiaremisiondetimpcpventadet()
		{
			return VwGuiaremisiondetimpcpventadetDao.Count();
		}

		public long CountVwGuiaremisiondetimpcpventadet(Expression<Func<VwGuiaremisiondetimpcpventadet, bool>> criteria)
		{
			return VwGuiaremisiondetimpcpventadetDao.Count(criteria);
		}

		public List<VwGuiaremisiondetimpcpventadet> GetAllVwGuiaremisiondetimpcpventadet()
		{
			return VwGuiaremisiondetimpcpventadetDao.GetAll();
		}

		public List<VwGuiaremisiondetimpcpventadet> GetAllVwGuiaremisiondetimpcpventadet(Expression<Func<VwGuiaremisiondetimpcpventadet, bool>> criteria)
		{
			return VwGuiaremisiondetimpcpventadetDao.GetAll(criteria);
		}

		public List<VwGuiaremisiondetimpcpventadet> GetAllVwGuiaremisiondetimpcpventadet(string orders)
		{
			return VwGuiaremisiondetimpcpventadetDao.GetAll(orders);
		}

		public List<VwGuiaremisiondetimpcpventadet> GetAllVwGuiaremisiondetimpcpventadet(string conditions, string orders)
		{
			return VwGuiaremisiondetimpcpventadetDao.GetAll(conditions, orders);
		}

		public VwGuiaremisiondetimpcpventadet GetVwGuiaremisiondetimpcpventadet(int id)
		{
			return VwGuiaremisiondetimpcpventadetDao.Get(id);
		}

		public VwGuiaremisiondetimpcpventadet GetVwGuiaremisiondetimpcpventadet(Expression<Func<VwGuiaremisiondetimpcpventadet, bool>> criteria)
		{
			return VwGuiaremisiondetimpcpventadetDao.Get(criteria);
		}
	}
}

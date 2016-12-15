using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpventa()
		{
			return VwCpventaDao.Count();
		}

		public long CountVwCpventa(Expression<Func<VwCpventa, bool>> criteria)
		{
			return VwCpventaDao.Count(criteria);
		}

		public List<VwCpventa> GetAllVwCpventa()
		{
			return VwCpventaDao.GetAll();
		}

		public List<VwCpventa> GetAllVwCpventa(Expression<Func<VwCpventa, bool>> criteria)
		{
			return VwCpventaDao.GetAll(criteria);
		}

		public List<VwCpventa> GetAllVwCpventa(string orders)
		{
			return VwCpventaDao.GetAll(orders);
		}

		public List<VwCpventa> GetAllVwCpventa(string conditions, string orders)
		{
			return VwCpventaDao.GetAll(conditions, orders);
		}

		public VwCpventa GetVwCpventa(int id)
		{
			return VwCpventaDao.Get(id);
		}

		public VwCpventa GetVwCpventa(Expression<Func<VwCpventa, bool>> criteria)
		{
			return VwCpventaDao.Get(criteria);
		}
	}
}

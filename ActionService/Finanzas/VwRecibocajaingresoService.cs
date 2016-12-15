using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRecibocajaingreso()
		{
			return VwRecibocajaingresoDao.Count();
		}

		public long CountVwRecibocajaingreso(Expression<Func<VwRecibocajaingreso, bool>> criteria)
		{
			return VwRecibocajaingresoDao.Count(criteria);
		}

		public List<VwRecibocajaingreso> GetAllVwRecibocajaingreso()
		{
			return VwRecibocajaingresoDao.GetAll();
		}

		public List<VwRecibocajaingreso> GetAllVwRecibocajaingreso(Expression<Func<VwRecibocajaingreso, bool>> criteria)
		{
			return VwRecibocajaingresoDao.GetAll(criteria);
		}

		public List<VwRecibocajaingreso> GetAllVwRecibocajaingreso(string orders)
		{
			return VwRecibocajaingresoDao.GetAll(orders);
		}

		public List<VwRecibocajaingreso> GetAllVwRecibocajaingreso(string conditions, string orders)
		{
			return VwRecibocajaingresoDao.GetAll(conditions, orders);
		}

		public VwRecibocajaingreso GetVwRecibocajaingreso(int id)
		{
			return VwRecibocajaingresoDao.Get(id);
		}

		public VwRecibocajaingreso GetVwRecibocajaingreso(Expression<Func<VwRecibocajaingreso, bool>> criteria)
		{
			return VwRecibocajaingresoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRecibocajaegreso()
		{
			return VwRecibocajaegresoDao.Count();
		}

		public long CountVwRecibocajaegreso(Expression<Func<VwRecibocajaegreso, bool>> criteria)
		{
			return VwRecibocajaegresoDao.Count(criteria);
		}

		public List<VwRecibocajaegreso> GetAllVwRecibocajaegreso()
		{
			return VwRecibocajaegresoDao.GetAll();
		}

		public List<VwRecibocajaegreso> GetAllVwRecibocajaegreso(Expression<Func<VwRecibocajaegreso, bool>> criteria)
		{
			return VwRecibocajaegresoDao.GetAll(criteria);
		}

		public List<VwRecibocajaegreso> GetAllVwRecibocajaegreso(string orders)
		{
			return VwRecibocajaegresoDao.GetAll(orders);
		}

		public List<VwRecibocajaegreso> GetAllVwRecibocajaegreso(string conditions, string orders)
		{
			return VwRecibocajaegresoDao.GetAll(conditions, orders);
		}

		public VwRecibocajaegreso GetVwRecibocajaegreso(int id)
		{
			return VwRecibocajaegresoDao.Get(id);
		}

		public VwRecibocajaegreso GetVwRecibocajaegreso(Expression<Func<VwRecibocajaegreso, bool>> criteria)
		{
			return VwRecibocajaegresoDao.Get(criteria);
		}
	}
}

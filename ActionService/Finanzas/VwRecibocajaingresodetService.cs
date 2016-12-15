using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRecibocajaingresodet()
		{
			return VwRecibocajaingresodetDao.Count();
		}

		public long CountVwRecibocajaingresodet(Expression<Func<VwRecibocajaingresodet, bool>> criteria)
		{
			return VwRecibocajaingresodetDao.Count(criteria);
		}

		public List<VwRecibocajaingresodet> GetAllVwRecibocajaingresodet()
		{
			return VwRecibocajaingresodetDao.GetAll();
		}

		public List<VwRecibocajaingresodet> GetAllVwRecibocajaingresodet(Expression<Func<VwRecibocajaingresodet, bool>> criteria)
		{
			return VwRecibocajaingresodetDao.GetAll(criteria);
		}

		public List<VwRecibocajaingresodet> GetAllVwRecibocajaingresodet(string orders)
		{
			return VwRecibocajaingresodetDao.GetAll(orders);
		}

		public List<VwRecibocajaingresodet> GetAllVwRecibocajaingresodet(string conditions, string orders)
		{
			return VwRecibocajaingresodetDao.GetAll(conditions, orders);
		}

		public VwRecibocajaingresodet GetVwRecibocajaingresodet(int id)
		{
			return VwRecibocajaingresodetDao.Get(id);
		}

		public VwRecibocajaingresodet GetVwRecibocajaingresodet(Expression<Func<VwRecibocajaingresodet, bool>> criteria)
		{
			return VwRecibocajaingresodetDao.Get(criteria);
		}
	}
}

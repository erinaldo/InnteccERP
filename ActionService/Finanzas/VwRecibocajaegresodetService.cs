using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRecibocajaegresodet()
		{
			return VwRecibocajaegresodetDao.Count();
		}

		public long CountVwRecibocajaegresodet(Expression<Func<VwRecibocajaegresodet, bool>> criteria)
		{
			return VwRecibocajaegresodetDao.Count(criteria);
		}

		public List<VwRecibocajaegresodet> GetAllVwRecibocajaegresodet()
		{
			return VwRecibocajaegresodetDao.GetAll();
		}

		public List<VwRecibocajaegresodet> GetAllVwRecibocajaegresodet(Expression<Func<VwRecibocajaegresodet, bool>> criteria)
		{
			return VwRecibocajaegresodetDao.GetAll(criteria);
		}

		public List<VwRecibocajaegresodet> GetAllVwRecibocajaegresodet(string orders)
		{
			return VwRecibocajaegresodetDao.GetAll(orders);
		}

		public List<VwRecibocajaegresodet> GetAllVwRecibocajaegresodet(string conditions, string orders)
		{
			return VwRecibocajaegresodetDao.GetAll(conditions, orders);
		}

		public VwRecibocajaegresodet GetVwRecibocajaegresodet(int id)
		{
			return VwRecibocajaegresodetDao.Get(id);
		}

		public VwRecibocajaegresodet GetVwRecibocajaegresodet(Expression<Func<VwRecibocajaegresodet, bool>> criteria)
		{
			return VwRecibocajaegresodetDao.Get(criteria);
		}
	}
}

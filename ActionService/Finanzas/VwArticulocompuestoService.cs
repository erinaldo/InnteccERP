using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticulocompuesto()
		{
			return VwArticulocompuestoDao.Count();
		}

		public long CountVwArticulocompuesto(Expression<Func<VwArticulocompuesto, bool>> criteria)
		{
			return VwArticulocompuestoDao.Count(criteria);
		}

		public List<VwArticulocompuesto> GetAllVwArticulocompuesto()
		{
			return VwArticulocompuestoDao.GetAll();
		}

		public List<VwArticulocompuesto> GetAllVwArticulocompuesto(Expression<Func<VwArticulocompuesto, bool>> criteria)
		{
			return VwArticulocompuestoDao.GetAll(criteria);
		}

		public List<VwArticulocompuesto> GetAllVwArticulocompuesto(string orders)
		{
			return VwArticulocompuestoDao.GetAll(orders);
		}

		public List<VwArticulocompuesto> GetAllVwArticulocompuesto(string conditions, string orders)
		{
			return VwArticulocompuestoDao.GetAll(conditions, orders);
		}

		public VwArticulocompuesto GetVwArticulocompuesto(int id)
		{
			return VwArticulocompuestoDao.Get(id);
		}

		public VwArticulocompuesto GetVwArticulocompuesto(Expression<Func<VwArticulocompuesto, bool>> criteria)
		{
			return VwArticulocompuestoDao.Get(criteria);
		}
	}
}

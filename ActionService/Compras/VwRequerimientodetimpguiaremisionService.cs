using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRequerimientodetimpguiaremision()
		{
			return VwRequerimientodetimpguiaremisionDao.Count();
		}

		public long CountVwRequerimientodetimpguiaremision(Expression<Func<VwRequerimientodetimpguiaremision, bool>> criteria)
		{
			return VwRequerimientodetimpguiaremisionDao.Count(criteria);
		}

		public List<VwRequerimientodetimpguiaremision> GetAllVwRequerimientodetimpguiaremision()
		{
			return VwRequerimientodetimpguiaremisionDao.GetAll();
		}

		public List<VwRequerimientodetimpguiaremision> GetAllVwRequerimientodetimpguiaremision(Expression<Func<VwRequerimientodetimpguiaremision, bool>> criteria)
		{
			return VwRequerimientodetimpguiaremisionDao.GetAll(criteria);
		}

		public List<VwRequerimientodetimpguiaremision> GetAllVwRequerimientodetimpguiaremision(string orders)
		{
			return VwRequerimientodetimpguiaremisionDao.GetAll(orders);
		}

		public List<VwRequerimientodetimpguiaremision> GetAllVwRequerimientodetimpguiaremision(string conditions, string orders)
		{
			return VwRequerimientodetimpguiaremisionDao.GetAll(conditions, orders);
		}

		public VwRequerimientodetimpguiaremision GetVwRequerimientodetimpguiaremision(int id)
		{
			return VwRequerimientodetimpguiaremisionDao.Get(id);
		}

		public VwRequerimientodetimpguiaremision GetVwRequerimientodetimpguiaremision(Expression<Func<VwRequerimientodetimpguiaremision, bool>> criteria)
		{
			return VwRequerimientodetimpguiaremisionDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwGuiaremision()
		{
			return VwGuiaremisionDao.Count();
		}

		public long CountVwGuiaremision(Expression<Func<VwGuiaremision, bool>> criteria)
		{
			return VwGuiaremisionDao.Count(criteria);
		}

		public List<VwGuiaremision> GetAllVwGuiaremision()
		{
			return VwGuiaremisionDao.GetAll();
		}

		public List<VwGuiaremision> GetAllVwGuiaremision(Expression<Func<VwGuiaremision, bool>> criteria)
		{
			return VwGuiaremisionDao.GetAll(criteria);
		}

		public List<VwGuiaremision> GetAllVwGuiaremision(string orders)
		{
			return VwGuiaremisionDao.GetAll(orders);
		}

		public List<VwGuiaremision> GetAllVwGuiaremision(string conditions, string orders)
		{
			return VwGuiaremisionDao.GetAll(conditions, orders);
		}

		public VwGuiaremision GetVwGuiaremision(int id)
		{
			return VwGuiaremisionDao.Get(id);
		}

		public VwGuiaremision GetVwGuiaremision(Expression<Func<VwGuiaremision, bool>> criteria)
		{
			return VwGuiaremisionDao.Get(criteria);
		}
	}
}

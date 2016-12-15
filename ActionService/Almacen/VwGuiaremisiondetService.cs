using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwGuiaremisiondet()
		{
			return VwGuiaremisiondetDao.Count();
		}

		public long CountVwGuiaremisiondet(Expression<Func<VwGuiaremisiondet, bool>> criteria)
		{
			return VwGuiaremisiondetDao.Count(criteria);
		}

		public List<VwGuiaremisiondet> GetAllVwGuiaremisiondet()
		{
			return VwGuiaremisiondetDao.GetAll();
		}

		public List<VwGuiaremisiondet> GetAllVwGuiaremisiondet(Expression<Func<VwGuiaremisiondet, bool>> criteria)
		{
			return VwGuiaremisiondetDao.GetAll(criteria);
		}

		public List<VwGuiaremisiondet> GetAllVwGuiaremisiondet(string orders)
		{
			return VwGuiaremisiondetDao.GetAll(orders);
		}

		public List<VwGuiaremisiondet> GetAllVwGuiaremisiondet(string conditions, string orders)
		{
			return VwGuiaremisiondetDao.GetAll(conditions, orders);
		}

		public VwGuiaremisiondet GetVwGuiaremisiondet(int id)
		{
			return VwGuiaremisiondetDao.Get(id);
		}

		public VwGuiaremisiondet GetVwGuiaremisiondet(Expression<Func<VwGuiaremisiondet, bool>> criteria)
		{
			return VwGuiaremisiondetDao.Get(criteria);
		}
	}
}

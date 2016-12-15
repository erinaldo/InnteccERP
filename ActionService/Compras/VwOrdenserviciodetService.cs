using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdenserviciodet()
		{
			return VwOrdenserviciodetDao.Count();
		}

		public long CountVwOrdenserviciodet(Expression<Func<VwOrdenserviciodet, bool>> criteria)
		{
			return VwOrdenserviciodetDao.Count(criteria);
		}

		public List<VwOrdenserviciodet> GetAllVwOrdenserviciodet()
		{
			return VwOrdenserviciodetDao.GetAll();
		}

		public List<VwOrdenserviciodet> GetAllVwOrdenserviciodet(Expression<Func<VwOrdenserviciodet, bool>> criteria)
		{
			return VwOrdenserviciodetDao.GetAll(criteria);
		}

		public List<VwOrdenserviciodet> GetAllVwOrdenserviciodet(string orders)
		{
			return VwOrdenserviciodetDao.GetAll(orders);
		}

		public List<VwOrdenserviciodet> GetAllVwOrdenserviciodet(string conditions, string orders)
		{
			return VwOrdenserviciodetDao.GetAll(conditions, orders);
		}

		public VwOrdenserviciodet GetVwOrdenserviciodet(int id)
		{
			return VwOrdenserviciodetDao.Get(id);
		}

		public VwOrdenserviciodet GetVwOrdenserviciodet(Expression<Func<VwOrdenserviciodet, bool>> criteria)
		{
			return VwOrdenserviciodetDao.Get(criteria);
		}
	}
}

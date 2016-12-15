using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdendeserviciodetvalorizaimp()
		{
			return VwOrdendeserviciodetvalorizaimpDao.Count();
		}

		public long CountVwOrdendeserviciodetvalorizaimp(Expression<Func<VwOrdendeserviciodetvalorizaimp, bool>> criteria)
		{
			return VwOrdendeserviciodetvalorizaimpDao.Count(criteria);
		}

		public List<VwOrdendeserviciodetvalorizaimp> GetAllVwOrdendeserviciodetvalorizaimp()
		{
			return VwOrdendeserviciodetvalorizaimpDao.GetAll();
		}

		public List<VwOrdendeserviciodetvalorizaimp> GetAllVwOrdendeserviciodetvalorizaimp(Expression<Func<VwOrdendeserviciodetvalorizaimp, bool>> criteria)
		{
			return VwOrdendeserviciodetvalorizaimpDao.GetAll(criteria);
		}

		public List<VwOrdendeserviciodetvalorizaimp> GetAllVwOrdendeserviciodetvalorizaimp(string orders)
		{
			return VwOrdendeserviciodetvalorizaimpDao.GetAll(orders);
		}

		public List<VwOrdendeserviciodetvalorizaimp> GetAllVwOrdendeserviciodetvalorizaimp(string conditions, string orders)
		{
			return VwOrdendeserviciodetvalorizaimpDao.GetAll(conditions, orders);
		}

		public VwOrdendeserviciodetvalorizaimp GetVwOrdendeserviciodetvalorizaimp(int id)
		{
			return VwOrdendeserviciodetvalorizaimpDao.Get(id);
		}

		public VwOrdendeserviciodetvalorizaimp GetVwOrdendeserviciodetvalorizaimp(Expression<Func<VwOrdendeserviciodetvalorizaimp, bool>> criteria)
		{
			return VwOrdendeserviciodetvalorizaimpDao.Get(criteria);
		}
	}
}

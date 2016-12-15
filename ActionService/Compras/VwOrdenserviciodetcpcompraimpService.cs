using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdenserviciodetcpcompraimp()
		{
			return VwOrdenserviciodetcpcompraimpDao.Count();
		}

		public long CountVwOrdenserviciodetcpcompraimp(Expression<Func<VwOrdenserviciodetcpcompraimp, bool>> criteria)
		{
			return VwOrdenserviciodetcpcompraimpDao.Count(criteria);
		}

		public List<VwOrdenserviciodetcpcompraimp> GetAllVwOrdenserviciodetcpcompraimp()
		{
			return VwOrdenserviciodetcpcompraimpDao.GetAll();
		}

		public List<VwOrdenserviciodetcpcompraimp> GetAllVwOrdenserviciodetcpcompraimp(Expression<Func<VwOrdenserviciodetcpcompraimp, bool>> criteria)
		{
			return VwOrdenserviciodetcpcompraimpDao.GetAll(criteria);
		}

		public List<VwOrdenserviciodetcpcompraimp> GetAllVwOrdenserviciodetcpcompraimp(string orders)
		{
			return VwOrdenserviciodetcpcompraimpDao.GetAll(orders);
		}

		public List<VwOrdenserviciodetcpcompraimp> GetAllVwOrdenserviciodetcpcompraimp(string conditions, string orders)
		{
			return VwOrdenserviciodetcpcompraimpDao.GetAll(conditions, orders);
		}

		public VwOrdenserviciodetcpcompraimp GetVwOrdenserviciodetcpcompraimp(int id)
		{
			return VwOrdenserviciodetcpcompraimpDao.Get(id);
		}

		public VwOrdenserviciodetcpcompraimp GetVwOrdenserviciodetcpcompraimp(Expression<Func<VwOrdenserviciodetcpcompraimp, bool>> criteria)
		{
			return VwOrdenserviciodetcpcompraimpDao.Get(criteria);
		}
	}
}

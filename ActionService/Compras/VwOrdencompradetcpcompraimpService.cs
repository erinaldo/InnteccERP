using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdencompradetcpcompraimp()
		{
			return VwOrdencompradetcpcompraimpDao.Count();
		}

		public long CountVwOrdencompradetcpcompraimp(Expression<Func<VwOrdencompradetcpcompraimp, bool>> criteria)
		{
			return VwOrdencompradetcpcompraimpDao.Count(criteria);
		}

		public List<VwOrdencompradetcpcompraimp> GetAllVwOrdencompradetcpcompraimp()
		{
			return VwOrdencompradetcpcompraimpDao.GetAll();
		}

		public List<VwOrdencompradetcpcompraimp> GetAllVwOrdencompradetcpcompraimp(Expression<Func<VwOrdencompradetcpcompraimp, bool>> criteria)
		{
			return VwOrdencompradetcpcompraimpDao.GetAll(criteria);
		}

		public List<VwOrdencompradetcpcompraimp> GetAllVwOrdencompradetcpcompraimp(string orders)
		{
			return VwOrdencompradetcpcompraimpDao.GetAll(orders);
		}

		public List<VwOrdencompradetcpcompraimp> GetAllVwOrdencompradetcpcompraimp(string conditions, string orders)
		{
			return VwOrdencompradetcpcompraimpDao.GetAll(conditions, orders);
		}

		public VwOrdencompradetcpcompraimp GetVwOrdencompradetcpcompraimp(int id)
		{
			return VwOrdencompradetcpcompraimpDao.Get(id);
		}

		public VwOrdencompradetcpcompraimp GetVwOrdencompradetcpcompraimp(Expression<Func<VwOrdencompradetcpcompraimp, bool>> criteria)
		{
			return VwOrdencompradetcpcompraimpDao.Get(criteria);
		}
	}
}

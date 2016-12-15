using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRequerimientodetordcompraimp()
		{
			return VwRequerimientodetordcompraimpDao.Count();
		}

		public long CountVwRequerimientodetordcompraimp(Expression<Func<VwRequerimientodetordcompraimp, bool>> criteria)
		{
			return VwRequerimientodetordcompraimpDao.Count(criteria);
		}

		public List<VwRequerimientodetordcompraimp> GetAllVwRequerimientodetordcompraimp()
		{
			return VwRequerimientodetordcompraimpDao.GetAll();
		}

		public List<VwRequerimientodetordcompraimp> GetAllVwRequerimientodetordcompraimp(Expression<Func<VwRequerimientodetordcompraimp, bool>> criteria)
		{
			return VwRequerimientodetordcompraimpDao.GetAll(criteria);
		}

		public List<VwRequerimientodetordcompraimp> GetAllVwRequerimientodetordcompraimp(string orders)
		{
			return VwRequerimientodetordcompraimpDao.GetAll(orders);
		}

		public List<VwRequerimientodetordcompraimp> GetAllVwRequerimientodetordcompraimp(string conditions, string orders)
		{
			return VwRequerimientodetordcompraimpDao.GetAll(conditions, orders);
		}

		public VwRequerimientodetordcompraimp GetVwRequerimientodetordcompraimp(int id)
		{
			return VwRequerimientodetordcompraimpDao.Get(id);
		}

		public VwRequerimientodetordcompraimp GetVwRequerimientodetordcompraimp(Expression<Func<VwRequerimientodetordcompraimp, bool>> criteria)
		{
			return VwRequerimientodetordcompraimpDao.Get(criteria);
		}
	}
}

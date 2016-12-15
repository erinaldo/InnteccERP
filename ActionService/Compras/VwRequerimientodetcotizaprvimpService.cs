using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRequerimientodetcotizaprvimp()
		{
			return VwRequerimientodetcotizaprvimpDao.Count();
		}

		public long CountVwRequerimientodetcotizaprvimp(Expression<Func<VwRequerimientodetcotizaprvimp, bool>> criteria)
		{
			return VwRequerimientodetcotizaprvimpDao.Count(criteria);
		}

		public List<VwRequerimientodetcotizaprvimp> GetAllVwRequerimientodetcotizaprvimp()
		{
			return VwRequerimientodetcotizaprvimpDao.GetAll();
		}

		public List<VwRequerimientodetcotizaprvimp> GetAllVwRequerimientodetcotizaprvimp(Expression<Func<VwRequerimientodetcotizaprvimp, bool>> criteria)
		{
			return VwRequerimientodetcotizaprvimpDao.GetAll(criteria);
		}

		public List<VwRequerimientodetcotizaprvimp> GetAllVwRequerimientodetcotizaprvimp(string orders)
		{
			return VwRequerimientodetcotizaprvimpDao.GetAll(orders);
		}

		public List<VwRequerimientodetcotizaprvimp> GetAllVwRequerimientodetcotizaprvimp(string conditions, string orders)
		{
			return VwRequerimientodetcotizaprvimpDao.GetAll(conditions, orders);
		}

		public VwRequerimientodetcotizaprvimp GetVwRequerimientodetcotizaprvimp(int id)
		{
			return VwRequerimientodetcotizaprvimpDao.Get(id);
		}

		public VwRequerimientodetcotizaprvimp GetVwRequerimientodetcotizaprvimp(Expression<Func<VwRequerimientodetcotizaprvimp, bool>> criteria)
		{
			return VwRequerimientodetcotizaprvimpDao.Get(criteria);
		}
	}
}

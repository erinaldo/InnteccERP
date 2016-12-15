using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRequerimientoimpresion()
		{
			return VwRequerimientoimpresionDao.Count();
		}

		public long CountVwRequerimientoimpresion(Expression<Func<VwRequerimientoimpresion, bool>> criteria)
		{
			return VwRequerimientoimpresionDao.Count(criteria);
		}

		public List<VwRequerimientoimpresion> GetAllVwRequerimientoimpresion()
		{
			return VwRequerimientoimpresionDao.GetAll();
		}

		public List<VwRequerimientoimpresion> GetAllVwRequerimientoimpresion(Expression<Func<VwRequerimientoimpresion, bool>> criteria)
		{
			return VwRequerimientoimpresionDao.GetAll(criteria);
		}

		public List<VwRequerimientoimpresion> GetAllVwRequerimientoimpresion(string orders)
		{
			return VwRequerimientoimpresionDao.GetAll(orders);
		}

		public List<VwRequerimientoimpresion> GetAllVwRequerimientoimpresion(string conditions, string orders)
		{
			return VwRequerimientoimpresionDao.GetAll(conditions, orders);
		}

		public VwRequerimientoimpresion GetVwRequerimientoimpresion(int id)
		{
			return VwRequerimientoimpresionDao.Get(id);
		}

		public VwRequerimientoimpresion GetVwRequerimientoimpresion(Expression<Func<VwRequerimientoimpresion, bool>> criteria)
		{
			return VwRequerimientoimpresionDao.Get(criteria);
		}
	}
}

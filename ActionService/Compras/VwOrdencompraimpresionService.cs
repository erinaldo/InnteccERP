using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdencompraimpresion()
		{
			return VwOrdencompraimpresionDao.Count();
		}

		public long CountVwOrdencompraimpresion(Expression<Func<VwOrdencompraimpresion, bool>> criteria)
		{
			return VwOrdencompraimpresionDao.Count(criteria);
		}

		public List<VwOrdencompraimpresion> GetAllVwOrdencompraimpresion()
		{
			return VwOrdencompraimpresionDao.GetAll();
		}

		public List<VwOrdencompraimpresion> GetAllVwOrdencompraimpresion(Expression<Func<VwOrdencompraimpresion, bool>> criteria)
		{
			return VwOrdencompraimpresionDao.GetAll(criteria);
		}

		public List<VwOrdencompraimpresion> GetAllVwOrdencompraimpresion(string orders)
		{
			return VwOrdencompraimpresionDao.GetAll(orders);
		}

		public List<VwOrdencompraimpresion> GetAllVwOrdencompraimpresion(string conditions, string orders)
		{
			return VwOrdencompraimpresionDao.GetAll(conditions, orders);
		}

		public VwOrdencompraimpresion GetVwOrdencompraimpresion(int id)
		{
			return VwOrdencompraimpresionDao.Get(id);
		}

		public VwOrdencompraimpresion GetVwOrdencompraimpresion(Expression<Func<VwOrdencompraimpresion, bool>> criteria)
		{
			return VwOrdencompraimpresionDao.Get(criteria);
		}
	}
}

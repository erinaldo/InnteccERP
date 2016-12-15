using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdenservicioimpresion()
		{
			return VwOrdenservicioimpresionDao.Count();
		}

		public long CountVwOrdenservicioimpresion(Expression<Func<VwOrdenservicioimpresion, bool>> criteria)
		{
			return VwOrdenservicioimpresionDao.Count(criteria);
		}

		public List<VwOrdenservicioimpresion> GetAllVwOrdenservicioimpresion()
		{
			return VwOrdenservicioimpresionDao.GetAll();
		}

		public List<VwOrdenservicioimpresion> GetAllVwOrdenservicioimpresion(Expression<Func<VwOrdenservicioimpresion, bool>> criteria)
		{
			return VwOrdenservicioimpresionDao.GetAll(criteria);
		}

		public List<VwOrdenservicioimpresion> GetAllVwOrdenservicioimpresion(string orders)
		{
			return VwOrdenservicioimpresionDao.GetAll(orders);
		}

		public List<VwOrdenservicioimpresion> GetAllVwOrdenservicioimpresion(string conditions, string orders)
		{
			return VwOrdenservicioimpresionDao.GetAll(conditions, orders);
		}

		public VwOrdenservicioimpresion GetVwOrdenservicioimpresion(int id)
		{
			return VwOrdenservicioimpresionDao.Get(id);
		}

		public VwOrdenservicioimpresion GetVwOrdenservicioimpresion(Expression<Func<VwOrdenservicioimpresion, bool>> criteria)
		{
			return VwOrdenservicioimpresionDao.Get(criteria);
		}
	}
}

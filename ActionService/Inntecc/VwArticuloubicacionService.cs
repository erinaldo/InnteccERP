using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticuloubicacion()
		{
			return VwArticuloubicacionDao.Count();
		}

		public long CountVwArticuloubicacion(Expression<Func<VwArticuloubicacion, bool>> criteria)
		{
			return VwArticuloubicacionDao.Count(criteria);
		}

		public List<VwArticuloubicacion> GetAllVwArticuloubicacion()
		{
			return VwArticuloubicacionDao.GetAll();
		}

		public List<VwArticuloubicacion> GetAllVwArticuloubicacion(Expression<Func<VwArticuloubicacion, bool>> criteria)
		{
			return VwArticuloubicacionDao.GetAll(criteria);
		}

		public List<VwArticuloubicacion> GetAllVwArticuloubicacion(string orders)
		{
			return VwArticuloubicacionDao.GetAll(orders);
		}

		public List<VwArticuloubicacion> GetAllVwArticuloubicacion(string conditions, string orders)
		{
			return VwArticuloubicacionDao.GetAll(conditions, orders);
		}

		public VwArticuloubicacion GetVwArticuloubicacion(int id)
		{
			return VwArticuloubicacionDao.Get(id);
		}

		public VwArticuloubicacion GetVwArticuloubicacion(Expression<Func<VwArticuloubicacion, bool>> criteria)
		{
			return VwArticuloubicacionDao.Get(criteria);
		}
	}
}

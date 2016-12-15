using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwInventarioubicacion()
		{
			return VwInventarioubicacionDao.Count();
		}

		public long CountVwInventarioubicacion(Expression<Func<VwInventarioubicacion, bool>> criteria)
		{
			return VwInventarioubicacionDao.Count(criteria);
		}

		public List<VwInventarioubicacion> GetAllVwInventarioubicacion()
		{
			return VwInventarioubicacionDao.GetAll();
		}

		public List<VwInventarioubicacion> GetAllVwInventarioubicacion(Expression<Func<VwInventarioubicacion, bool>> criteria)
		{
			return VwInventarioubicacionDao.GetAll(criteria);
		}

		public List<VwInventarioubicacion> GetAllVwInventarioubicacion(string orders)
		{
			return VwInventarioubicacionDao.GetAll(orders);
		}

		public List<VwInventarioubicacion> GetAllVwInventarioubicacion(string conditions, string orders)
		{
			return VwInventarioubicacionDao.GetAll(conditions, orders);
		}

		public VwInventarioubicacion GetVwInventarioubicacion(int id)
		{
			return VwInventarioubicacionDao.Get(id);
		}

		public VwInventarioubicacion GetVwInventarioubicacion(Expression<Func<VwInventarioubicacion, bool>> criteria)
		{
			return VwInventarioubicacionDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEntradaalmacenubicacion()
		{
			return VwEntradaalmacenubicacionDao.Count();
		}

		public long CountVwEntradaalmacenubicacion(Expression<Func<VwEntradaalmacenubicacion, bool>> criteria)
		{
			return VwEntradaalmacenubicacionDao.Count(criteria);
		}

		public List<VwEntradaalmacenubicacion> GetAllVwEntradaalmacenubicacion()
		{
			return VwEntradaalmacenubicacionDao.GetAll();
		}

		public List<VwEntradaalmacenubicacion> GetAllVwEntradaalmacenubicacion(Expression<Func<VwEntradaalmacenubicacion, bool>> criteria)
		{
			return VwEntradaalmacenubicacionDao.GetAll(criteria);
		}

		public List<VwEntradaalmacenubicacion> GetAllVwEntradaalmacenubicacion(string orders)
		{
			return VwEntradaalmacenubicacionDao.GetAll(orders);
		}

		public List<VwEntradaalmacenubicacion> GetAllVwEntradaalmacenubicacion(string conditions, string orders)
		{
			return VwEntradaalmacenubicacionDao.GetAll(conditions, orders);
		}

		public VwEntradaalmacenubicacion GetVwEntradaalmacenubicacion(int id)
		{
			return VwEntradaalmacenubicacionDao.Get(id);
		}

		public VwEntradaalmacenubicacion GetVwEntradaalmacenubicacion(Expression<Func<VwEntradaalmacenubicacion, bool>> criteria)
		{
			return VwEntradaalmacenubicacionDao.Get(criteria);
		}
	}
}

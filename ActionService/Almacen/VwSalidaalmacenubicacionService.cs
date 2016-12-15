using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSalidaalmacenubicacion()
		{
			return VwSalidaalmacenubicacionDao.Count();
		}

		public long CountVwSalidaalmacenubicacion(Expression<Func<VwSalidaalmacenubicacion, bool>> criteria)
		{
			return VwSalidaalmacenubicacionDao.Count(criteria);
		}

		public List<VwSalidaalmacenubicacion> GetAllVwSalidaalmacenubicacion()
		{
			return VwSalidaalmacenubicacionDao.GetAll();
		}

		public List<VwSalidaalmacenubicacion> GetAllVwSalidaalmacenubicacion(Expression<Func<VwSalidaalmacenubicacion, bool>> criteria)
		{
			return VwSalidaalmacenubicacionDao.GetAll(criteria);
		}

		public List<VwSalidaalmacenubicacion> GetAllVwSalidaalmacenubicacion(string orders)
		{
			return VwSalidaalmacenubicacionDao.GetAll(orders);
		}

		public List<VwSalidaalmacenubicacion> GetAllVwSalidaalmacenubicacion(string conditions, string orders)
		{
			return VwSalidaalmacenubicacionDao.GetAll(conditions, orders);
		}

		public VwSalidaalmacenubicacion GetVwSalidaalmacenubicacion(int id)
		{
			return VwSalidaalmacenubicacionDao.Get(id);
		}

		public VwSalidaalmacenubicacion GetVwSalidaalmacenubicacion(Expression<Func<VwSalidaalmacenubicacion, bool>> criteria)
		{
			return VwSalidaalmacenubicacionDao.Get(criteria);
		}
	}
}

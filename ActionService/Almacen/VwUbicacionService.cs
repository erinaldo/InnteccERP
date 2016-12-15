using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwUbicacion()
		{
			return VwUbicacionDao.Count();
		}

		public long CountVwUbicacion(Expression<Func<VwUbicacion, bool>> criteria)
		{
			return VwUbicacionDao.Count(criteria);
		}

		public List<VwUbicacion> GetAllVwUbicacion()
		{
			return VwUbicacionDao.GetAll();
		}

		public List<VwUbicacion> GetAllVwUbicacion(Expression<Func<VwUbicacion, bool>> criteria)
		{
			return VwUbicacionDao.GetAll(criteria);
		}

		public List<VwUbicacion> GetAllVwUbicacion(string orders)
		{
			return VwUbicacionDao.GetAll(orders);
		}

		public List<VwUbicacion> GetAllVwUbicacion(string conditions, string orders)
		{
			return VwUbicacionDao.GetAll(conditions, orders);
		}

		public VwUbicacion GetVwUbicacion(int id)
		{
			return VwUbicacionDao.Get(id);
		}

		public VwUbicacion GetVwUbicacion(Expression<Func<VwUbicacion, bool>> criteria)
		{
			return VwUbicacionDao.Get(criteria);
		}
	}
}

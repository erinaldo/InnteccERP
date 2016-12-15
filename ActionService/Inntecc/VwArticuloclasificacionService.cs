using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticuloclasificacion()
		{
			return VwArticuloclasificacionDao.Count();
		}

		public long CountVwArticuloclasificacion(Expression<Func<VwArticuloclasificacion, bool>> criteria)
		{
			return VwArticuloclasificacionDao.Count(criteria);
		}

		public List<VwArticuloclasificacion> GetAllVwArticuloclasificacion()
		{
			return VwArticuloclasificacionDao.GetAll();
		}

		public List<VwArticuloclasificacion> GetAllVwArticuloclasificacion(Expression<Func<VwArticuloclasificacion, bool>> criteria)
		{
			return VwArticuloclasificacionDao.GetAll(criteria);
		}

		public List<VwArticuloclasificacion> GetAllVwArticuloclasificacion(string orders)
		{
			return VwArticuloclasificacionDao.GetAll(orders);
		}

		public List<VwArticuloclasificacion> GetAllVwArticuloclasificacion(string conditions, string orders)
		{
			return VwArticuloclasificacionDao.GetAll(conditions, orders);
		}

		public VwArticuloclasificacion GetVwArticuloclasificacion(int id)
		{
			return VwArticuloclasificacionDao.Get(id);
		}

		public VwArticuloclasificacion GetVwArticuloclasificacion(Expression<Func<VwArticuloclasificacion, bool>> criteria)
		{
			return VwArticuloclasificacionDao.Get(criteria);
		}
	}
}

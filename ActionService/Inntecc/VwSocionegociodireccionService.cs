using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSocionegociodireccion()
		{
			return VwSocionegociodireccionDao.Count();
		}

		public long CountVwSocionegociodireccion(Expression<Func<VwSocionegociodireccion, bool>> criteria)
		{
			return VwSocionegociodireccionDao.Count(criteria);
		}

		public List<VwSocionegociodireccion> GetAllVwSocionegociodireccion()
		{
			return VwSocionegociodireccionDao.GetAll();
		}

		public List<VwSocionegociodireccion> GetAllVwSocionegociodireccion(Expression<Func<VwSocionegociodireccion, bool>> criteria)
		{
			return VwSocionegociodireccionDao.GetAll(criteria);
		}

		public List<VwSocionegociodireccion> GetAllVwSocionegociodireccion(string orders)
		{
			return VwSocionegociodireccionDao.GetAll(orders);
		}

		public List<VwSocionegociodireccion> GetAllVwSocionegociodireccion(string conditions, string orders)
		{
			return VwSocionegociodireccionDao.GetAll(conditions, orders);
		}

		public VwSocionegociodireccion GetVwSocionegociodireccion(int id)
		{
			return VwSocionegociodireccionDao.Get(id);
		}

		public VwSocionegociodireccion GetVwSocionegociodireccion(Expression<Func<VwSocionegociodireccion, bool>> criteria)
		{
			return VwSocionegociodireccionDao.Get(criteria);
		}
	}
}

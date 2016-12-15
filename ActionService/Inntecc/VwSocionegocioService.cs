using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSocionegocio()
		{
			return VwSocionegocioDao.Count();
		}

		public long CountVwSocionegocio(Expression<Func<VwSocionegocio, bool>> criteria)
		{
			return VwSocionegocioDao.Count(criteria);
		}

		public List<VwSocionegocio> GetAllVwSocionegocio()
		{
			return VwSocionegocioDao.GetAll();
		}

		public List<VwSocionegocio> GetAllVwSocionegocio(Expression<Func<VwSocionegocio, bool>> criteria)
		{
			return VwSocionegocioDao.GetAll(criteria);
		}

		public List<VwSocionegocio> GetAllVwSocionegocio(string orders)
		{
			return VwSocionegocioDao.GetAll(orders);
		}

		public List<VwSocionegocio> GetAllVwSocionegocio(string conditions, string orders)
		{
			return VwSocionegocioDao.GetAll(conditions, orders);
		}

		public VwSocionegocio GetVwSocionegocio(int id)
		{
			return VwSocionegocioDao.Get(id);
		}

		public VwSocionegocio GetVwSocionegocio(Expression<Func<VwSocionegocio, bool>> criteria)
		{
			return VwSocionegocioDao.Get(criteria);
		}
	}
}

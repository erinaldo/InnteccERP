using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwModeloautorizacion()
		{
			return VwModeloautorizacionDao.Count();
		}

		public long CountVwModeloautorizacion(Expression<Func<VwModeloautorizacion, bool>> criteria)
		{
			return VwModeloautorizacionDao.Count(criteria);
		}

		public List<VwModeloautorizacion> GetAllVwModeloautorizacion()
		{
			return VwModeloautorizacionDao.GetAll();
		}

		public List<VwModeloautorizacion> GetAllVwModeloautorizacion(Expression<Func<VwModeloautorizacion, bool>> criteria)
		{
			return VwModeloautorizacionDao.GetAll(criteria);
		}

		public List<VwModeloautorizacion> GetAllVwModeloautorizacion(string orders)
		{
			return VwModeloautorizacionDao.GetAll(orders);
		}

		public List<VwModeloautorizacion> GetAllVwModeloautorizacion(string conditions, string orders)
		{
			return VwModeloautorizacionDao.GetAll(conditions, orders);
		}

		public VwModeloautorizacion GetVwModeloautorizacion(int id)
		{
			return VwModeloautorizacionDao.Get(id);
		}

		public VwModeloautorizacion GetVwModeloautorizacion(Expression<Func<VwModeloautorizacion, bool>> criteria)
		{
			return VwModeloautorizacionDao.Get(criteria);
		}
	}
}

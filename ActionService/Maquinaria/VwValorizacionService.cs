using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizacion()
		{
			return VwValorizacionDao.Count();
		}

		public long CountVwValorizacion(Expression<Func<VwValorizacion, bool>> criteria)
		{
			return VwValorizacionDao.Count(criteria);
		}

		public List<VwValorizacion> GetAllVwValorizacion()
		{
			return VwValorizacionDao.GetAll();
		}

		public List<VwValorizacion> GetAllVwValorizacion(Expression<Func<VwValorizacion, bool>> criteria)
		{
			return VwValorizacionDao.GetAll(criteria);
		}

		public List<VwValorizacion> GetAllVwValorizacion(string orders)
		{
			return VwValorizacionDao.GetAll(orders);
		}

		public List<VwValorizacion> GetAllVwValorizacion(string conditions, string orders)
		{
			return VwValorizacionDao.GetAll(conditions, orders);
		}

		public VwValorizacion GetVwValorizacion(int id)
		{
			return VwValorizacionDao.Get(id);
		}

		public VwValorizacion GetVwValorizacion(Expression<Func<VwValorizacion, bool>> criteria)
		{
			return VwValorizacionDao.Get(criteria);
		}
	}
}

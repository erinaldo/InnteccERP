using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwAccesoopcion()
		{
			return VwAccesoopcionDao.Count();
		}

		public long CountVwAccesoopcion(Expression<Func<VwAccesoopcion, bool>> criteria)
		{
			return VwAccesoopcionDao.Count(criteria);
		}

		public List<VwAccesoopcion> GetAllVwAccesoopcion()
		{
			return VwAccesoopcionDao.GetAll();
		}

		public List<VwAccesoopcion> GetAllVwAccesoopcion(Expression<Func<VwAccesoopcion, bool>> criteria)
		{
			return VwAccesoopcionDao.GetAll(criteria);
		}

		public List<VwAccesoopcion> GetAllVwAccesoopcion(string orders)
		{
			return VwAccesoopcionDao.GetAll(orders);
		}

		public List<VwAccesoopcion> GetAllVwAccesoopcion(string conditions, string orders)
		{
			return VwAccesoopcionDao.GetAll(conditions, orders);
		}

		public VwAccesoopcion GetVwAccesoopcion(int id)
		{
			return VwAccesoopcionDao.Get(id);
		}

		public VwAccesoopcion GetVwAccesoopcion(Expression<Func<VwAccesoopcion, bool>> criteria)
		{
			return VwAccesoopcionDao.Get(criteria);
		}
	}
}

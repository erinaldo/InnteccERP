using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizaciondanio()
		{
			return VwValorizaciondanioDao.Count();
		}

		public long CountVwValorizaciondanio(Expression<Func<VwValorizaciondanio, bool>> criteria)
		{
			return VwValorizaciondanioDao.Count(criteria);
		}

		public List<VwValorizaciondanio> GetAllVwValorizaciondanio()
		{
			return VwValorizaciondanioDao.GetAll();
		}

		public List<VwValorizaciondanio> GetAllVwValorizaciondanio(Expression<Func<VwValorizaciondanio, bool>> criteria)
		{
			return VwValorizaciondanioDao.GetAll(criteria);
		}

		public List<VwValorizaciondanio> GetAllVwValorizaciondanio(string orders)
		{
			return VwValorizaciondanioDao.GetAll(orders);
		}

		public List<VwValorizaciondanio> GetAllVwValorizaciondanio(string conditions, string orders)
		{
			return VwValorizaciondanioDao.GetAll(conditions, orders);
		}

		public VwValorizaciondanio GetVwValorizaciondanio(int id)
		{
			return VwValorizaciondanioDao.Get(id);
		}

		public VwValorizaciondanio GetVwValorizaciondanio(Expression<Func<VwValorizaciondanio, bool>> criteria)
		{
			return VwValorizaciondanioDao.Get(criteria);
		}
	}
}

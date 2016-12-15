using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizacionegreso()
		{
			return VwValorizacionegresoDao.Count();
		}

		public long CountVwValorizacionegreso(Expression<Func<VwValorizacionegreso, bool>> criteria)
		{
			return VwValorizacionegresoDao.Count(criteria);
		}

		public List<VwValorizacionegreso> GetAllVwValorizacionegreso()
		{
			return VwValorizacionegresoDao.GetAll();
		}

		public List<VwValorizacionegreso> GetAllVwValorizacionegreso(Expression<Func<VwValorizacionegreso, bool>> criteria)
		{
			return VwValorizacionegresoDao.GetAll(criteria);
		}

		public List<VwValorizacionegreso> GetAllVwValorizacionegreso(string orders)
		{
			return VwValorizacionegresoDao.GetAll(orders);
		}

		public List<VwValorizacionegreso> GetAllVwValorizacionegreso(string conditions, string orders)
		{
			return VwValorizacionegresoDao.GetAll(conditions, orders);
		}

		public VwValorizacionegreso GetVwValorizacionegreso(int id)
		{
			return VwValorizacionegresoDao.Get(id);
		}

		public VwValorizacionegreso GetVwValorizacionegreso(Expression<Func<VwValorizacionegreso, bool>> criteria)
		{
			return VwValorizacionegresoDao.Get(criteria);
		}
	}
}

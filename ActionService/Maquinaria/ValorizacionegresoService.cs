using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizacionegreso()
		{
			return ValorizacionegresoDao.Count();
		}

		public long CountValorizacionegreso(Expression<Func<Valorizacionegreso, bool>> criteria)
		{
			return ValorizacionegresoDao.Count(criteria);
		}

		public int SaveValorizacionegreso(Valorizacionegreso entity)
		{
			return ValorizacionegresoDao.Save(entity);
		}

		public void UpdateValorizacionegreso(Valorizacionegreso entity)
		{
			ValorizacionegresoDao.Update(entity);
		}

		public void DeleteValorizacionegreso(int id)
		{
			ValorizacionegresoDao.Delete(id);
		}

		public List<Valorizacionegreso> GetAllValorizacionegreso()
		{
			return ValorizacionegresoDao.GetAll();
		}

		public List<Valorizacionegreso> GetAllValorizacionegreso(Expression<Func<Valorizacionegreso, bool>> criteria)
		{
			return ValorizacionegresoDao.GetAll(criteria);
		}

		public List<Valorizacionegreso> GetAllValorizacionegreso(string orders)
		{
			return ValorizacionegresoDao.GetAll(orders);
		}

		public List<Valorizacionegreso> GetAllValorizacionegreso(string conditions, string orders)
		{
			return ValorizacionegresoDao.GetAll(conditions, orders);
		}

		public Valorizacionegreso GetValorizacionegreso(int id)
		{
			return ValorizacionegresoDao.Get(id);
		}

		public Valorizacionegreso GetValorizacionegreso(Expression<Func<Valorizacionegreso, bool>> criteria)
		{
			return ValorizacionegresoDao.Get(criteria);
		}
	}
}

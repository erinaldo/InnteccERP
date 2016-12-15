using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRecibocajaegreso()
		{
			return RecibocajaegresoDao.Count();
		}

		public long CountRecibocajaegreso(Expression<Func<Recibocajaegreso, bool>> criteria)
		{
			return RecibocajaegresoDao.Count(criteria);
		}

		public int SaveRecibocajaegreso(Recibocajaegreso entity)
		{
			return RecibocajaegresoDao.Save(entity);
		}

		public void UpdateRecibocajaegreso(Recibocajaegreso entity)
		{
			RecibocajaegresoDao.Update(entity);
		}

		public void DeleteRecibocajaegreso(int id)
		{
			RecibocajaegresoDao.Delete(id);
		}

		public List<Recibocajaegreso> GetAllRecibocajaegreso()
		{
			return RecibocajaegresoDao.GetAll();
		}

		public List<Recibocajaegreso> GetAllRecibocajaegreso(Expression<Func<Recibocajaegreso, bool>> criteria)
		{
			return RecibocajaegresoDao.GetAll(criteria);
		}

		public List<Recibocajaegreso> GetAllRecibocajaegreso(string orders)
		{
			return RecibocajaegresoDao.GetAll(orders);
		}

		public List<Recibocajaegreso> GetAllRecibocajaegreso(string conditions, string orders)
		{
			return RecibocajaegresoDao.GetAll(conditions, orders);
		}

		public Recibocajaegreso GetRecibocajaegreso(int id)
		{
			return RecibocajaegresoDao.Get(id);
		}

		public Recibocajaegreso GetRecibocajaegreso(Expression<Func<Recibocajaegreso, bool>> criteria)
		{
			return RecibocajaegresoDao.Get(criteria);
		}
	}
}

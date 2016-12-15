using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRecibocajaingreso()
		{
			return RecibocajaingresoDao.Count();
		}

		public long CountRecibocajaingreso(Expression<Func<Recibocajaingreso, bool>> criteria)
		{
			return RecibocajaingresoDao.Count(criteria);
		}

		public int SaveRecibocajaingreso(Recibocajaingreso entity)
		{
			return RecibocajaingresoDao.Save(entity);
		}

		public void UpdateRecibocajaingreso(Recibocajaingreso entity)
		{
			RecibocajaingresoDao.Update(entity);
		}

		public void DeleteRecibocajaingreso(int id)
		{
			RecibocajaingresoDao.Delete(id);
		}

		public List<Recibocajaingreso> GetAllRecibocajaingreso()
		{
			return RecibocajaingresoDao.GetAll();
		}

		public List<Recibocajaingreso> GetAllRecibocajaingreso(Expression<Func<Recibocajaingreso, bool>> criteria)
		{
			return RecibocajaingresoDao.GetAll(criteria);
		}

		public List<Recibocajaingreso> GetAllRecibocajaingreso(string orders)
		{
			return RecibocajaingresoDao.GetAll(orders);
		}

		public List<Recibocajaingreso> GetAllRecibocajaingreso(string conditions, string orders)
		{
			return RecibocajaingresoDao.GetAll(conditions, orders);
		}

		public Recibocajaingreso GetRecibocajaingreso(int id)
		{
			return RecibocajaingresoDao.Get(id);
		}

		public Recibocajaingreso GetRecibocajaingreso(Expression<Func<Recibocajaingreso, bool>> criteria)
		{
			return RecibocajaingresoDao.Get(criteria);
		}
	}
}

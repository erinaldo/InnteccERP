using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRecibocajaingresodet()
		{
			return RecibocajaingresodetDao.Count();
		}

		public long CountRecibocajaingresodet(Expression<Func<Recibocajaingresodet, bool>> criteria)
		{
			return RecibocajaingresodetDao.Count(criteria);
		}

		public int SaveRecibocajaingresodet(Recibocajaingresodet entity)
		{
			return RecibocajaingresodetDao.Save(entity);
		}

		public void UpdateRecibocajaingresodet(Recibocajaingresodet entity)
		{
			RecibocajaingresodetDao.Update(entity);
		}

		public void DeleteRecibocajaingresodet(int id)
		{
			RecibocajaingresodetDao.Delete(id);
		}

		public List<Recibocajaingresodet> GetAllRecibocajaingresodet()
		{
			return RecibocajaingresodetDao.GetAll();
		}

		public List<Recibocajaingresodet> GetAllRecibocajaingresodet(Expression<Func<Recibocajaingresodet, bool>> criteria)
		{
			return RecibocajaingresodetDao.GetAll(criteria);
		}

		public List<Recibocajaingresodet> GetAllRecibocajaingresodet(string orders)
		{
			return RecibocajaingresodetDao.GetAll(orders);
		}

		public List<Recibocajaingresodet> GetAllRecibocajaingresodet(string conditions, string orders)
		{
			return RecibocajaingresodetDao.GetAll(conditions, orders);
		}

		public Recibocajaingresodet GetRecibocajaingresodet(int id)
		{
			return RecibocajaingresodetDao.Get(id);
		}

		public Recibocajaingresodet GetRecibocajaingresodet(Expression<Func<Recibocajaingresodet, bool>> criteria)
		{
			return RecibocajaingresodetDao.Get(criteria);
		}
	}
}

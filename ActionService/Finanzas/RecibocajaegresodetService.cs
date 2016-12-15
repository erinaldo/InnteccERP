using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRecibocajaegresodet()
		{
			return RecibocajaegresodetDao.Count();
		}

		public long CountRecibocajaegresodet(Expression<Func<Recibocajaegresodet, bool>> criteria)
		{
			return RecibocajaegresodetDao.Count(criteria);
		}

		public int SaveRecibocajaegresodet(Recibocajaegresodet entity)
		{
			return RecibocajaegresodetDao.Save(entity);
		}

		public void UpdateRecibocajaegresodet(Recibocajaegresodet entity)
		{
			RecibocajaegresodetDao.Update(entity);
		}

		public void DeleteRecibocajaegresodet(int id)
		{
			RecibocajaegresodetDao.Delete(id);
		}

		public List<Recibocajaegresodet> GetAllRecibocajaegresodet()
		{
			return RecibocajaegresodetDao.GetAll();
		}

		public List<Recibocajaegresodet> GetAllRecibocajaegresodet(Expression<Func<Recibocajaegresodet, bool>> criteria)
		{
			return RecibocajaegresodetDao.GetAll(criteria);
		}

		public List<Recibocajaegresodet> GetAllRecibocajaegresodet(string orders)
		{
			return RecibocajaegresodetDao.GetAll(orders);
		}

		public List<Recibocajaegresodet> GetAllRecibocajaegresodet(string conditions, string orders)
		{
			return RecibocajaegresodetDao.GetAll(conditions, orders);
		}

		public Recibocajaegresodet GetRecibocajaegresodet(int id)
		{
			return RecibocajaegresodetDao.Get(id);
		}

		public Recibocajaegresodet GetRecibocajaegresodet(Expression<Func<Recibocajaegresodet, bool>> criteria)
		{
			return RecibocajaegresodetDao.Get(criteria);
		}
	}
}

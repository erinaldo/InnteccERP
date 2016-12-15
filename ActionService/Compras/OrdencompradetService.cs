using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountOrdencompradet()
		{
			return OrdencompradetDao.Count();
		}

		public long CountOrdencompradet(Expression<Func<Ordencompradet, bool>> criteria)
		{
			return OrdencompradetDao.Count(criteria);
		}

		public int SaveOrdencompradet(Ordencompradet entity)
		{
			return OrdencompradetDao.Save(entity);
		}

		public void UpdateOrdencompradet(Ordencompradet entity)
		{
			OrdencompradetDao.Update(entity);
		}

		public void DeleteOrdencompradet(int id)
		{
			OrdencompradetDao.Delete(id);
		}

		public List<Ordencompradet> GetAllOrdencompradet()
		{
			return OrdencompradetDao.GetAll();
		}

		public List<Ordencompradet> GetAllOrdencompradet(Expression<Func<Ordencompradet, bool>> criteria)
		{
			return OrdencompradetDao.GetAll(criteria);
		}

		public List<Ordencompradet> GetAllOrdencompradet(string orders)
		{
			return OrdencompradetDao.GetAll(orders);
		}

		public List<Ordencompradet> GetAllOrdencompradet(string conditions, string orders)
		{
			return OrdencompradetDao.GetAll(conditions, orders);
		}

		public Ordencompradet GetOrdencompradet(int id)
		{
			return OrdencompradetDao.Get(id);
		}

		public Ordencompradet GetOrdencompradet(Expression<Func<Ordencompradet, bool>> criteria)
		{
			return OrdencompradetDao.Get(criteria);
		}
	}
}

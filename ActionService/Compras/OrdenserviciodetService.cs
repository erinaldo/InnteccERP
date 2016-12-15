using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountOrdenserviciodet()
		{
			return OrdenserviciodetDao.Count();
		}

		public long CountOrdenserviciodet(Expression<Func<Ordenserviciodet, bool>> criteria)
		{
			return OrdenserviciodetDao.Count(criteria);
		}

		public int SaveOrdenserviciodet(Ordenserviciodet entity)
		{
			return OrdenserviciodetDao.Save(entity);
		}

		public void UpdateOrdenserviciodet(Ordenserviciodet entity)
		{
			OrdenserviciodetDao.Update(entity);
		}

		public void DeleteOrdenserviciodet(int id)
		{
			OrdenserviciodetDao.Delete(id);
		}

		public List<Ordenserviciodet> GetAllOrdenserviciodet()
		{
			return OrdenserviciodetDao.GetAll();
		}

		public List<Ordenserviciodet> GetAllOrdenserviciodet(Expression<Func<Ordenserviciodet, bool>> criteria)
		{
			return OrdenserviciodetDao.GetAll(criteria);
		}

		public List<Ordenserviciodet> GetAllOrdenserviciodet(string orders)
		{
			return OrdenserviciodetDao.GetAll(orders);
		}

		public List<Ordenserviciodet> GetAllOrdenserviciodet(string conditions, string orders)
		{
			return OrdenserviciodetDao.GetAll(conditions, orders);
		}

		public Ordenserviciodet GetOrdenserviciodet(int id)
		{
			return OrdenserviciodetDao.Get(id);
		}

		public Ordenserviciodet GetOrdenserviciodet(Expression<Func<Ordenserviciodet, bool>> criteria)
		{
			return OrdenserviciodetDao.Get(criteria);
		}
	}
}

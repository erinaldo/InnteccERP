using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountOrdencompra()
		{
			return OrdencompraDao.Count();
		}

		public long CountOrdencompra(Expression<Func<Ordencompra, bool>> criteria)
		{
			return OrdencompraDao.Count(criteria);
		}

		public int SaveOrdencompra(Ordencompra entity)
		{
			return OrdencompraDao.Save(entity);
		}

		public void UpdateOrdencompra(Ordencompra entity)
		{
			OrdencompraDao.Update(entity);
		}

		public void DeleteOrdencompra(int id)
		{
			OrdencompraDao.Delete(id);
		}

		public List<Ordencompra> GetAllOrdencompra()
		{
			return OrdencompraDao.GetAll();
		}

		public List<Ordencompra> GetAllOrdencompra(Expression<Func<Ordencompra, bool>> criteria)
		{
			return OrdencompraDao.GetAll(criteria);
		}

		public List<Ordencompra> GetAllOrdencompra(string orders)
		{
			return OrdencompraDao.GetAll(orders);
		}

		public List<Ordencompra> GetAllOrdencompra(string conditions, string orders)
		{
			return OrdencompraDao.GetAll(conditions, orders);
		}

		public Ordencompra GetOrdencompra(int id)
		{
			return OrdencompraDao.Get(id);
		}

		public Ordencompra GetOrdencompra(Expression<Func<Ordencompra, bool>> criteria)
		{
			return OrdencompraDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountOrdendeventa()
		{
			return OrdendeventaDao.Count();
		}

		public long CountOrdendeventa(Expression<Func<Ordendeventa, bool>> criteria)
		{
			return OrdendeventaDao.Count(criteria);
		}

		public int SaveOrdendeventa(Ordendeventa entity)
		{
			return OrdendeventaDao.Save(entity);
		}

		public void UpdateOrdendeventa(Ordendeventa entity)
		{
			OrdendeventaDao.Update(entity);
		}

		public void DeleteOrdendeventa(int id)
		{
			OrdendeventaDao.Delete(id);
		}

		public List<Ordendeventa> GetAllOrdendeventa()
		{
			return OrdendeventaDao.GetAll();
		}

		public List<Ordendeventa> GetAllOrdendeventa(Expression<Func<Ordendeventa, bool>> criteria)
		{
			return OrdendeventaDao.GetAll(criteria);
		}

		public List<Ordendeventa> GetAllOrdendeventa(string orders)
		{
			return OrdendeventaDao.GetAll(orders);
		}

		public List<Ordendeventa> GetAllOrdendeventa(string conditions, string orders)
		{
			return OrdendeventaDao.GetAll(conditions, orders);
		}

		public Ordendeventa GetOrdendeventa(int id)
		{
			return OrdendeventaDao.Get(id);
		}

		public Ordendeventa GetOrdendeventa(Expression<Func<Ordendeventa, bool>> criteria)
		{
			return OrdendeventaDao.Get(criteria);
		}
	}
}

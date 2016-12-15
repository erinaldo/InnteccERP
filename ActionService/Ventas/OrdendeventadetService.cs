using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountOrdendeventadetalle()
		{
			return OrdendeventadetalleDao.Count();
		}

		public long CountOrdendeventadetalle(Expression<Func<Ordendeventadet, bool>> criteria)
		{
			return OrdendeventadetalleDao.Count(criteria);
		}

		public int SaveOrdendeventadetalle(Ordendeventadet entity)
		{
			return OrdendeventadetalleDao.Save(entity);
		}

		public void UpdateOrdendeventadetalle(Ordendeventadet entity)
		{
			OrdendeventadetalleDao.Update(entity);
		}

		public void DeleteOrdendeventadetalle(int id)
		{
			OrdendeventadetalleDao.Delete(id);
		}

		public List<Ordendeventadet> GetAllOrdendeventadetalle()
		{
			return OrdendeventadetalleDao.GetAll();
		}

		public List<Ordendeventadet> GetAllOrdendeventadetalle(Expression<Func<Ordendeventadet, bool>> criteria)
		{
			return OrdendeventadetalleDao.GetAll(criteria);
		}

		public List<Ordendeventadet> GetAllOrdendeventadetalle(string orders)
		{
			return OrdendeventadetalleDao.GetAll(orders);
		}

		public List<Ordendeventadet> GetAllOrdendeventadetalle(string conditions, string orders)
		{
			return OrdendeventadetalleDao.GetAll(conditions, orders);
		}

		public Ordendeventadet GetOrdendeventadetalle(int id)
		{
			return OrdendeventadetalleDao.Get(id);
		}

		public Ordendeventadet GetOrdendeventadetalle(Expression<Func<Ordendeventadet, bool>> criteria)
		{
			return OrdendeventadetalleDao.Get(criteria);
		}
	}
}

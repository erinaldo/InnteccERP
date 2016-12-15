using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountInventarioubicacion()
		{
			return InventarioubicacionDao.Count();
		}

		public long CountInventarioubicacion(Expression<Func<Inventarioubicacion, bool>> criteria)
		{
			return InventarioubicacionDao.Count(criteria);
		}

		public int SaveInventarioubicacion(Inventarioubicacion entity)
		{
			return InventarioubicacionDao.Save(entity);
		}

		public void UpdateInventarioubicacion(Inventarioubicacion entity)
		{
			InventarioubicacionDao.Update(entity);
		}

		public void DeleteInventarioubicacion(int id)
		{
			InventarioubicacionDao.Delete(id);
		}

		public List<Inventarioubicacion> GetAllInventarioubicacion()
		{
			return InventarioubicacionDao.GetAll();
		}

		public List<Inventarioubicacion> GetAllInventarioubicacion(Expression<Func<Inventarioubicacion, bool>> criteria)
		{
			return InventarioubicacionDao.GetAll(criteria);
		}

		public List<Inventarioubicacion> GetAllInventarioubicacion(string orders)
		{
			return InventarioubicacionDao.GetAll(orders);
		}

		public List<Inventarioubicacion> GetAllInventarioubicacion(string conditions, string orders)
		{
			return InventarioubicacionDao.GetAll(conditions, orders);
		}

		public Inventarioubicacion GetInventarioubicacion(int id)
		{
			return InventarioubicacionDao.Get(id);
		}

		public Inventarioubicacion GetInventarioubicacion(Expression<Func<Inventarioubicacion, bool>> criteria)
		{
			return InventarioubicacionDao.Get(criteria);
		}
	}
}

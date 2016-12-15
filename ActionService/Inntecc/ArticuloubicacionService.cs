using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountArticuloubicacion()
		{
			return ArticuloubicacionDao.Count();
		}

		public long CountArticuloubicacion(Expression<Func<Articuloubicacion, bool>> criteria)
		{
			return ArticuloubicacionDao.Count(criteria);
		}

		public int SaveArticuloubicacion(Articuloubicacion entity)
		{
			return ArticuloubicacionDao.Save(entity);
		}

		public void UpdateArticuloubicacion(Articuloubicacion entity)
		{
			ArticuloubicacionDao.Update(entity);
		}

		public void DeleteArticuloubicacion(int id)
		{
			ArticuloubicacionDao.Delete(id);
		}

		public List<Articuloubicacion> GetAllArticuloubicacion()
		{
			return ArticuloubicacionDao.GetAll();
		}

		public List<Articuloubicacion> GetAllArticuloubicacion(Expression<Func<Articuloubicacion, bool>> criteria)
		{
			return ArticuloubicacionDao.GetAll(criteria);
		}

		public List<Articuloubicacion> GetAllArticuloubicacion(string orders)
		{
			return ArticuloubicacionDao.GetAll(orders);
		}

		public List<Articuloubicacion> GetAllArticuloubicacion(string conditions, string orders)
		{
			return ArticuloubicacionDao.GetAll(conditions, orders);
		}

		public Articuloubicacion GetArticuloubicacion(int id)
		{
			return ArticuloubicacionDao.Get(id);
		}

		public Articuloubicacion GetArticuloubicacion(Expression<Func<Articuloubicacion, bool>> criteria)
		{
			return ArticuloubicacionDao.Get(criteria);
		}
	}
}

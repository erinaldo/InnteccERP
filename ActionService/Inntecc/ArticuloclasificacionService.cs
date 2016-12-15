using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountArticuloclasificacion()
		{
			return ArticuloclasificacionDao.Count();
		}

		public long CountArticuloclasificacion(Expression<Func<Articuloclasificacion, bool>> criteria)
		{
			return ArticuloclasificacionDao.Count(criteria);
		}

		public int SaveArticuloclasificacion(Articuloclasificacion entity)
		{
			return ArticuloclasificacionDao.Save(entity);
		}

		public void UpdateArticuloclasificacion(Articuloclasificacion entity)
		{
			ArticuloclasificacionDao.Update(entity);
		}

		public void DeleteArticuloclasificacion(int id)
		{
			ArticuloclasificacionDao.Delete(id);
		}

		public List<Articuloclasificacion> GetAllArticuloclasificacion()
		{
			return ArticuloclasificacionDao.GetAll();
		}

		public List<Articuloclasificacion> GetAllArticuloclasificacion(Expression<Func<Articuloclasificacion, bool>> criteria)
		{
			return ArticuloclasificacionDao.GetAll(criteria);
		}

		public List<Articuloclasificacion> GetAllArticuloclasificacion(string orders)
		{
			return ArticuloclasificacionDao.GetAll(orders);
		}

		public List<Articuloclasificacion> GetAllArticuloclasificacion(string conditions, string orders)
		{
			return ArticuloclasificacionDao.GetAll(conditions, orders);
		}

		public Articuloclasificacion GetArticuloclasificacion(int id)
		{
			return ArticuloclasificacionDao.Get(id);
		}

		public Articuloclasificacion GetArticuloclasificacion(Expression<Func<Articuloclasificacion, bool>> criteria)
		{
			return ArticuloclasificacionDao.Get(criteria);
		}
	}
}

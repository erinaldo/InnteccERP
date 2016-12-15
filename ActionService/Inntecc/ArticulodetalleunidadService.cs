using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountArticulodetalleunidad()
		{
			return ArticulodetalleunidadDao.Count();
		}

		public long CountArticulodetalleunidad(Expression<Func<Articulodetalleunidad, bool>> criteria)
		{
			return ArticulodetalleunidadDao.Count(criteria);
		}

		public int SaveArticulodetalleunidad(Articulodetalleunidad entity)
		{
			return ArticulodetalleunidadDao.Save(entity);
		}

		public void UpdateArticulodetalleunidad(Articulodetalleunidad entity)
		{
			ArticulodetalleunidadDao.Update(entity);
		}

		public void DeleteArticulodetalleunidad(int id)
		{
			ArticulodetalleunidadDao.Delete(id);
		}

		public List<Articulodetalleunidad> GetAllArticulodetalleunidad()
		{
			return ArticulodetalleunidadDao.GetAll();
		}

		public List<Articulodetalleunidad> GetAllArticulodetalleunidad(Expression<Func<Articulodetalleunidad, bool>> criteria)
		{
			return ArticulodetalleunidadDao.GetAll(criteria);
		}

		public List<Articulodetalleunidad> GetAllArticulodetalleunidad(string orders)
		{
			return ArticulodetalleunidadDao.GetAll(orders);
		}

		public List<Articulodetalleunidad> GetAllArticulodetalleunidad(string conditions, string orders)
		{
			return ArticulodetalleunidadDao.GetAll(conditions, orders);
		}

		public Articulodetalleunidad GetArticulodetalleunidad(int id)
		{
			return ArticulodetalleunidadDao.Get(id);
		}

		public Articulodetalleunidad GetArticulodetalleunidad(Expression<Func<Articulodetalleunidad, bool>> criteria)
		{
			return ArticulodetalleunidadDao.Get(criteria);
		}
	}
}

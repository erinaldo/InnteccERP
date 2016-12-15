using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountUnidadmedida()
		{
			return UnidadmedidaDao.Count();
		}

		public long CountUnidadmedida(Expression<Func<Unidadmedida, bool>> criteria)
		{
			return UnidadmedidaDao.Count(criteria);
		}

		public int SaveUnidadmedida(Unidadmedida entity)
		{
			return UnidadmedidaDao.Save(entity);
		}

		public void UpdateUnidadmedida(Unidadmedida entity)
		{
			UnidadmedidaDao.Update(entity);
		}

		public void DeleteUnidadmedida(int id)
		{
			UnidadmedidaDao.Delete(id);
		}

		public List<Unidadmedida> GetAllUnidadmedida()
		{
			return UnidadmedidaDao.GetAll();
		}

		public List<Unidadmedida> GetAllUnidadmedida(Expression<Func<Unidadmedida, bool>> criteria)
		{
			return UnidadmedidaDao.GetAll(criteria);
		}

		public List<Unidadmedida> GetAllUnidadmedida(string orders)
		{
			return UnidadmedidaDao.GetAll(orders);
		}

		public List<Unidadmedida> GetAllUnidadmedida(string conditions, string orders)
		{
			return UnidadmedidaDao.GetAll(conditions, orders);
		}

		public Unidadmedida GetUnidadmedida(int id)
		{
			return UnidadmedidaDao.Get(id);
		}

		public Unidadmedida GetUnidadmedida(Expression<Func<Unidadmedida, bool>> criteria)
		{
			return UnidadmedidaDao.Get(criteria);
		}
	}
}

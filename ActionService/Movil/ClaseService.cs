using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountClase()
		{
			return ClaseDao.Count();
		}

		public long CountClase(Expression<Func<Clase, bool>> criteria)
		{
			return ClaseDao.Count(criteria);
		}

		public int SaveClase(Clase entity)
		{
			return ClaseDao.Save(entity);
		}

		public void UpdateClase(Clase entity)
		{
			ClaseDao.Update(entity);
		}

		public void DeleteClase(int id)
		{
			ClaseDao.Delete(id);
		}

		public List<Clase> GetAllClase()
		{
			return ClaseDao.GetAll();
		}

		public List<Clase> GetAllClase(Expression<Func<Clase, bool>> criteria)
		{
			return ClaseDao.GetAll(criteria);
		}

		public List<Clase> GetAllClase(string orders)
		{
			return ClaseDao.GetAll(orders);
		}

		public List<Clase> GetAllClase(string conditions, string orders)
		{
			return ClaseDao.GetAll(conditions, orders);
		}

		public Clase GetClase(int id)
		{
			return ClaseDao.Get(id);
		}

		public Clase GetClase(Expression<Func<Clase, bool>> criteria)
		{
			return ClaseDao.Get(criteria);
		}
	}
}

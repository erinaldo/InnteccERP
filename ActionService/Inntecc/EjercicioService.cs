using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEjercicio()
		{
			return EjercicioDao.Count();
		}

		public long CountEjercicio(Expression<Func<Ejercicio, bool>> criteria)
		{
			return EjercicioDao.Count(criteria);
		}

		public int SaveEjercicio(Ejercicio entity)
		{
			return EjercicioDao.Save(entity);
		}

		public void UpdateEjercicio(Ejercicio entity)
		{
			EjercicioDao.Update(entity);
		}

		public void DeleteEjercicio(int id)
		{
			EjercicioDao.Delete(id);
		}

		public List<Ejercicio> GetAllEjercicio()
		{
			return EjercicioDao.GetAll();
		}

		public List<Ejercicio> GetAllEjercicio(Expression<Func<Ejercicio, bool>> criteria)
		{
			return EjercicioDao.GetAll(criteria);
		}

		public List<Ejercicio> GetAllEjercicio(string orders)
		{
			return EjercicioDao.GetAll(orders);
		}

		public List<Ejercicio> GetAllEjercicio(string conditions, string orders)
		{
			return EjercicioDao.GetAll(conditions, orders);
		}

		public Ejercicio GetEjercicio(int id)
		{
			return EjercicioDao.Get(id);
		}

		public Ejercicio GetEjercicio(Expression<Func<Ejercicio, bool>> criteria)
		{
			return EjercicioDao.Get(criteria);
		}
	}
}

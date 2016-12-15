using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountEstadocita()
		{
			return EstadocitaDao.Count();
		}

		public long CountEstadocita(Expression<Func<Estadocita, bool>> criteria)
		{
			return EstadocitaDao.Count(criteria);
		}

		public int SaveEstadocita(Estadocita entity)
		{
			return EstadocitaDao.Save(entity);
		}

		public void UpdateEstadocita(Estadocita entity)
		{
			EstadocitaDao.Update(entity);
		}

		public void DeleteEstadocita(int id)
		{
			EstadocitaDao.Delete(id);
		}

		public List<Estadocita> GetAllEstadocita()
		{
			return EstadocitaDao.GetAll();
		}

		public List<Estadocita> GetAllEstadocita(Expression<Func<Estadocita, bool>> criteria)
		{
			return EstadocitaDao.GetAll(criteria);
		}

		public List<Estadocita> GetAllEstadocita(string orders)
		{
			return EstadocitaDao.GetAll(orders);
		}

		public List<Estadocita> GetAllEstadocita(string conditions, string orders)
		{
			return EstadocitaDao.GetAll(conditions, orders);
		}

		public Estadocita GetEstadocita(int id)
		{
			return EstadocitaDao.Get(id);
		}

		public Estadocita GetEstadocita(Expression<Func<Estadocita, bool>> criteria)
		{
			return EstadocitaDao.Get(criteria);
		}
	}
}

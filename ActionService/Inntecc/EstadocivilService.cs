using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEstadocivil()
		{
			return EstadocivilDao.Count();
		}

		public long CountEstadocivil(Expression<Func<Estadocivil, bool>> criteria)
		{
			return EstadocivilDao.Count(criteria);
		}

		public int SaveEstadocivil(Estadocivil entity)
		{
			return EstadocivilDao.Save(entity);
		}

		public void UpdateEstadocivil(Estadocivil entity)
		{
			EstadocivilDao.Update(entity);
		}

		public void DeleteEstadocivil(int id)
		{
			EstadocivilDao.Delete(id);
		}

		public List<Estadocivil> GetAllEstadocivil()
		{
			return EstadocivilDao.GetAll();
		}

		public List<Estadocivil> GetAllEstadocivil(Expression<Func<Estadocivil, bool>> criteria)
		{
			return EstadocivilDao.GetAll(criteria);
		}

		public List<Estadocivil> GetAllEstadocivil(string orders)
		{
			return EstadocivilDao.GetAll(orders);
		}

		public List<Estadocivil> GetAllEstadocivil(string conditions, string orders)
		{
			return EstadocivilDao.GetAll(conditions, orders);
		}

		public Estadocivil GetEstadocivil(int id)
		{
			return EstadocivilDao.Get(id);
		}

		public Estadocivil GetEstadocivil(Expression<Func<Estadocivil, bool>> criteria)
		{
			return EstadocivilDao.Get(criteria);
		}
	}
}

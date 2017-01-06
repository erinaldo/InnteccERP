using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountServicioespecialidad()
		{
			return ServicioespecialidadDao.Count();
		}

		public long CountServicioespecialidad(Expression<Func<Servicioespecialidad, bool>> criteria)
		{
			return ServicioespecialidadDao.Count(criteria);
		}

		public int SaveServicioespecialidad(Servicioespecialidad entity)
		{
			return ServicioespecialidadDao.Save(entity);
		}

		public void UpdateServicioespecialidad(Servicioespecialidad entity)
		{
			ServicioespecialidadDao.Update(entity);
		}

		public void DeleteServicioespecialidad(int id)
		{
			ServicioespecialidadDao.Delete(id);
		}

		public List<Servicioespecialidad> GetAllServicioespecialidad()
		{
			return ServicioespecialidadDao.GetAll();
		}

		public List<Servicioespecialidad> GetAllServicioespecialidad(Expression<Func<Servicioespecialidad, bool>> criteria)
		{
			return ServicioespecialidadDao.GetAll(criteria);
		}

		public List<Servicioespecialidad> GetAllServicioespecialidad(string orders)
		{
			return ServicioespecialidadDao.GetAll(orders);
		}

		public List<Servicioespecialidad> GetAllServicioespecialidad(string conditions, string orders)
		{
			return ServicioespecialidadDao.GetAll(conditions, orders);
		}

		public Servicioespecialidad GetServicioespecialidad(int id)
		{
			return ServicioespecialidadDao.Get(id);
		}

		public Servicioespecialidad GetServicioespecialidad(Expression<Func<Servicioespecialidad, bool>> criteria)
		{
			return ServicioespecialidadDao.Get(criteria);
		}
	}
}

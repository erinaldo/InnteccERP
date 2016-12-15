using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountPrioridad()
		{
			return PrioridadDao.Count();
		}

		public long CountPrioridad(Expression<Func<Prioridad, bool>> criteria)
		{
			return PrioridadDao.Count(criteria);
		}

		public int SavePrioridad(Prioridad entity)
		{
			return PrioridadDao.Save(entity);
		}

		public void UpdatePrioridad(Prioridad entity)
		{
			PrioridadDao.Update(entity);
		}

		public void DeletePrioridad(int id)
		{
			PrioridadDao.Delete(id);
		}

		public List<Prioridad> GetAllPrioridad()
		{
			return PrioridadDao.GetAll();
		}

		public List<Prioridad> GetAllPrioridad(Expression<Func<Prioridad, bool>> criteria)
		{
			return PrioridadDao.GetAll(criteria);
		}

		public List<Prioridad> GetAllPrioridad(string orders)
		{
			return PrioridadDao.GetAll(orders);
		}

		public List<Prioridad> GetAllPrioridad(string conditions, string orders)
		{
			return PrioridadDao.GetAll(conditions, orders);
		}

		public Prioridad GetPrioridad(int id)
		{
			return PrioridadDao.Get(id);
		}

		public Prioridad GetPrioridad(Expression<Func<Prioridad, bool>> criteria)
		{
			return PrioridadDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEstadoreq()
		{
			return EstadoreqDao.Count();
		}

		public long CountEstadoreq(Expression<Func<Estadoreq, bool>> criteria)
		{
			return EstadoreqDao.Count(criteria);
		}

		public int SaveEstadoreq(Estadoreq entity)
		{
			return EstadoreqDao.Save(entity);
		}

		public void UpdateEstadoreq(Estadoreq entity)
		{
			EstadoreqDao.Update(entity);
		}

		public void DeleteEstadoreq(int id)
		{
			EstadoreqDao.Delete(id);
		}

		public List<Estadoreq> GetAllEstadoreq()
		{
			return EstadoreqDao.GetAll();
		}

		public List<Estadoreq> GetAllEstadoreq(Expression<Func<Estadoreq, bool>> criteria)
		{
			return EstadoreqDao.GetAll(criteria);
		}

		public List<Estadoreq> GetAllEstadoreq(string orders)
		{
			return EstadoreqDao.GetAll(orders);
		}

		public List<Estadoreq> GetAllEstadoreq(string conditions, string orders)
		{
			return EstadoreqDao.GetAll(conditions, orders);
		}

		public Estadoreq GetEstadoreq(int id)
		{
			return EstadoreqDao.Get(id);
		}

		public Estadoreq GetEstadoreq(Expression<Func<Estadoreq, bool>> criteria)
		{
			return EstadoreqDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountPeriodo()
		{
			return PeriodoDao.Count();
		}

		public long CountPeriodo(Expression<Func<Periodo, bool>> criteria)
		{
			return PeriodoDao.Count(criteria);
		}

		public int SavePeriodo(Periodo entity)
		{
			return PeriodoDao.Save(entity);
		}

		public void UpdatePeriodo(Periodo entity)
		{
			PeriodoDao.Update(entity);
		}

		public void DeletePeriodo(int id)
		{
			PeriodoDao.Delete(id);
		}

		public List<Periodo> GetAllPeriodo()
		{
			return PeriodoDao.GetAll();
		}

		public List<Periodo> GetAllPeriodo(Expression<Func<Periodo, bool>> criteria)
		{
			return PeriodoDao.GetAll(criteria);
		}

		public List<Periodo> GetAllPeriodo(string orders)
		{
			return PeriodoDao.GetAll(orders);
		}

		public List<Periodo> GetAllPeriodo(string conditions, string orders)
		{
			return PeriodoDao.GetAll(conditions, orders);
		}

		public Periodo GetPeriodo(int id)
		{
			return PeriodoDao.Get(id);
		}

		public Periodo GetPeriodo(Expression<Func<Periodo, bool>> criteria)
		{
			return PeriodoDao.Get(criteria);
		}
	}
}

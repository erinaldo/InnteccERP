using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwPeriodo()
		{
			return VwPeriodoDao.Count();
		}

		public long CountVwPeriodo(Expression<Func<VwPeriodo, bool>> criteria)
		{
			return VwPeriodoDao.Count(criteria);
		}

		public List<VwPeriodo> GetAllVwPeriodo()
		{
			return VwPeriodoDao.GetAll();
		}

		public List<VwPeriodo> GetAllVwPeriodo(Expression<Func<VwPeriodo, bool>> criteria)
		{
			return VwPeriodoDao.GetAll(criteria);
		}

		public List<VwPeriodo> GetAllVwPeriodo(string orders)
		{
			return VwPeriodoDao.GetAll(orders);
		}

		public List<VwPeriodo> GetAllVwPeriodo(string conditions, string orders)
		{
			return VwPeriodoDao.GetAll(conditions, orders);
		}

		public VwPeriodo GetVwPeriodo(int id)
		{
			return VwPeriodoDao.Get(id);
		}

		public VwPeriodo GetVwPeriodo(Expression<Func<VwPeriodo, bool>> criteria)
		{
			return VwPeriodoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEntradaalmacenobs()
		{
			return VwEntradaalmacenobsDao.Count();
		}

		public long CountVwEntradaalmacenobs(Expression<Func<VwEntradaalmacenobs, bool>> criteria)
		{
			return VwEntradaalmacenobsDao.Count(criteria);
		}

		public List<VwEntradaalmacenobs> GetAllVwEntradaalmacenobs()
		{
			return VwEntradaalmacenobsDao.GetAll();
		}

		public List<VwEntradaalmacenobs> GetAllVwEntradaalmacenobs(Expression<Func<VwEntradaalmacenobs, bool>> criteria)
		{
			return VwEntradaalmacenobsDao.GetAll(criteria);
		}

		public List<VwEntradaalmacenobs> GetAllVwEntradaalmacenobs(string orders)
		{
			return VwEntradaalmacenobsDao.GetAll(orders);
		}

		public List<VwEntradaalmacenobs> GetAllVwEntradaalmacenobs(string conditions, string orders)
		{
			return VwEntradaalmacenobsDao.GetAll(conditions, orders);
		}

		public VwEntradaalmacenobs GetVwEntradaalmacenobs(int id)
		{
			return VwEntradaalmacenobsDao.Get(id);
		}

		public VwEntradaalmacenobs GetVwEntradaalmacenobs(Expression<Func<VwEntradaalmacenobs, bool>> criteria)
		{
			return VwEntradaalmacenobsDao.Get(criteria);
		}
	}
}

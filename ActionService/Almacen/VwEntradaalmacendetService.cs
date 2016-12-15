using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEntradaalmacendet()
		{
			return VwEntradaalmacendetDao.Count();
		}

		public long CountVwEntradaalmacendet(Expression<Func<VwEntradaalmacendet, bool>> criteria)
		{
			return VwEntradaalmacendetDao.Count(criteria);
		}

		public List<VwEntradaalmacendet> GetAllVwEntradaalmacendet()
		{
			return VwEntradaalmacendetDao.GetAll();
		}

		public List<VwEntradaalmacendet> GetAllVwEntradaalmacendet(Expression<Func<VwEntradaalmacendet, bool>> criteria)
		{
			return VwEntradaalmacendetDao.GetAll(criteria);
		}

		public List<VwEntradaalmacendet> GetAllVwEntradaalmacendet(string orders)
		{
			return VwEntradaalmacendetDao.GetAll(orders);
		}

		public List<VwEntradaalmacendet> GetAllVwEntradaalmacendet(string conditions, string orders)
		{
			return VwEntradaalmacendetDao.GetAll(conditions, orders);
		}

		public VwEntradaalmacendet GetVwEntradaalmacendet(int id)
		{
			return VwEntradaalmacendetDao.Get(id);
		}

		public VwEntradaalmacendet GetVwEntradaalmacendet(Expression<Func<VwEntradaalmacendet, bool>> criteria)
		{
			return VwEntradaalmacendetDao.Get(criteria);
		}
	}
}

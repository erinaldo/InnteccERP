using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwTipocambio()
		{
			return VwTipocambioDao.Count();
		}

		public long CountVwTipocambio(Expression<Func<VwTipocambio, bool>> criteria)
		{
			return VwTipocambioDao.Count(criteria);
		}

		public List<VwTipocambio> GetAllVwTipocambio()
		{
			return VwTipocambioDao.GetAll();
		}

		public List<VwTipocambio> GetAllVwTipocambio(Expression<Func<VwTipocambio, bool>> criteria)
		{
			return VwTipocambioDao.GetAll(criteria);
		}

		public List<VwTipocambio> GetAllVwTipocambio(string orders)
		{
			return VwTipocambioDao.GetAll(orders);
		}

		public List<VwTipocambio> GetAllVwTipocambio(string conditions, string orders)
		{
			return VwTipocambioDao.GetAll(conditions, orders);
		}

		public VwTipocambio GetVwTipocambio(int id)
		{
			return VwTipocambioDao.Get(id);
		}

		public VwTipocambio GetVwTipocambio(Expression<Func<VwTipocambio, bool>> criteria)
		{
			return VwTipocambioDao.Get(criteria);
		}
	}
}

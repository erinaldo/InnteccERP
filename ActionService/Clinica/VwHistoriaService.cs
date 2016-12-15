using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwHistoria()
		{
			return VwHistoriaDao.Count();
		}

		public long CountVwHistoria(Expression<Func<VwHistoria, bool>> criteria)
		{
			return VwHistoriaDao.Count(criteria);
		}

		public List<VwHistoria> GetAllVwHistoria()
		{
			return VwHistoriaDao.GetAll();
		}

		public List<VwHistoria> GetAllVwHistoria(Expression<Func<VwHistoria, bool>> criteria)
		{
			return VwHistoriaDao.GetAll(criteria);
		}

		public List<VwHistoria> GetAllVwHistoria(string orders)
		{
			return VwHistoriaDao.GetAll(orders);
		}

		public List<VwHistoria> GetAllVwHistoria(string conditions, string orders)
		{
			return VwHistoriaDao.GetAll(conditions, orders);
		}

		public VwHistoria GetVwHistoria(int id)
		{
			return VwHistoriaDao.Get(id);
		}

		public VwHistoria GetVwHistoria(Expression<Func<VwHistoria, bool>> criteria)
		{
			return VwHistoriaDao.Get(criteria);
		}
	}
}

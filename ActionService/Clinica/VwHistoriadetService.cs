using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwHistoriadet()
		{
			return VwHistoriadetDao.Count();
		}

		public long CountVwHistoriadet(Expression<Func<VwHistoriadet, bool>> criteria)
		{
			return VwHistoriadetDao.Count(criteria);
		}

		public List<VwHistoriadet> GetAllVwHistoriadet()
		{
			return VwHistoriadetDao.GetAll();
		}

		public List<VwHistoriadet> GetAllVwHistoriadet(Expression<Func<VwHistoriadet, bool>> criteria)
		{
			return VwHistoriadetDao.GetAll(criteria);
		}

		public List<VwHistoriadet> GetAllVwHistoriadet(string orders)
		{
			return VwHistoriadetDao.GetAll(orders);
		}

		public List<VwHistoriadet> GetAllVwHistoriadet(string conditions, string orders)
		{
			return VwHistoriadetDao.GetAll(conditions, orders);
		}

		public VwHistoriadet GetVwHistoriadet(int id)
		{
			return VwHistoriadetDao.Get(id);
		}

		public VwHistoriadet GetVwHistoriadet(Expression<Func<VwHistoriadet, bool>> criteria)
		{
			return VwHistoriadetDao.Get(criteria);
		}
	}
}

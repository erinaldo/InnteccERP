using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwHistoriadetitem()
		{
			return VwHistoriadetitemDao.Count();
		}

		public long CountVwHistoriadetitem(Expression<Func<VwHistoriadetitem, bool>> criteria)
		{
			return VwHistoriadetitemDao.Count(criteria);
		}

		public List<VwHistoriadetitem> GetAllVwHistoriadetitem()
		{
			return VwHistoriadetitemDao.GetAll();
		}

		public List<VwHistoriadetitem> GetAllVwHistoriadetitem(Expression<Func<VwHistoriadetitem, bool>> criteria)
		{
			return VwHistoriadetitemDao.GetAll(criteria);
		}

		public List<VwHistoriadetitem> GetAllVwHistoriadetitem(string orders)
		{
			return VwHistoriadetitemDao.GetAll(orders);
		}

		public List<VwHistoriadetitem> GetAllVwHistoriadetitem(string conditions, string orders)
		{
			return VwHistoriadetitemDao.GetAll(conditions, orders);
		}

		public VwHistoriadetitem GetVwHistoriadetitem(int id)
		{
			return VwHistoriadetitemDao.Get(id);
		}

		public VwHistoriadetitem GetVwHistoriadetitem(Expression<Func<VwHistoriadetitem, bool>> criteria)
		{
			return VwHistoriadetitemDao.Get(criteria);
		}
	}
}

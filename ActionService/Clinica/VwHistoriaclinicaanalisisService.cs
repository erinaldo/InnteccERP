using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwHistoriaclinicaanalisis()
		{
			return VwHistoriaclinicaanalisisDao.Count();
		}

		public long CountVwHistoriaclinicaanalisis(Expression<Func<VwHistoriaclinicaanalisis, bool>> criteria)
		{
			return VwHistoriaclinicaanalisisDao.Count(criteria);
		}

		public List<VwHistoriaclinicaanalisis> GetAllVwHistoriaclinicaanalisis()
		{
			return VwHistoriaclinicaanalisisDao.GetAll();
		}

		public List<VwHistoriaclinicaanalisis> GetAllVwHistoriaclinicaanalisis(Expression<Func<VwHistoriaclinicaanalisis, bool>> criteria)
		{
			return VwHistoriaclinicaanalisisDao.GetAll(criteria);
		}

		public List<VwHistoriaclinicaanalisis> GetAllVwHistoriaclinicaanalisis(string orders)
		{
			return VwHistoriaclinicaanalisisDao.GetAll(orders);
		}

		public List<VwHistoriaclinicaanalisis> GetAllVwHistoriaclinicaanalisis(string conditions, string orders)
		{
			return VwHistoriaclinicaanalisisDao.GetAll(conditions, orders);
		}

		public VwHistoriaclinicaanalisis GetVwHistoriaclinicaanalisis(int id)
		{
			return VwHistoriaclinicaanalisisDao.Get(id);
		}

		public VwHistoriaclinicaanalisis GetVwHistoriaclinicaanalisis(Expression<Func<VwHistoriaclinicaanalisis, bool>> criteria)
		{
			return VwHistoriaclinicaanalisisDao.Get(criteria);
		}
	}
}

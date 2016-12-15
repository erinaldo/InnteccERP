using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwHistoriaclinica()
		{
			return VwHistoriaclinicaDao.Count();
		}

		public long CountVwHistoriaclinica(Expression<Func<VwHistoriaclinica, bool>> criteria)
		{
			return VwHistoriaclinicaDao.Count(criteria);
		}

		public List<VwHistoriaclinica> GetAllVwHistoriaclinica()
		{
			return VwHistoriaclinicaDao.GetAll();
		}

		public List<VwHistoriaclinica> GetAllVwHistoriaclinica(Expression<Func<VwHistoriaclinica, bool>> criteria)
		{
			return VwHistoriaclinicaDao.GetAll(criteria);
		}

		public List<VwHistoriaclinica> GetAllVwHistoriaclinica(string orders)
		{
			return VwHistoriaclinicaDao.GetAll(orders);
		}

		public List<VwHistoriaclinica> GetAllVwHistoriaclinica(string conditions, string orders)
		{
			return VwHistoriaclinicaDao.GetAll(conditions, orders);
		}

		public VwHistoriaclinica GetVwHistoriaclinica(int id)
		{
			return VwHistoriaclinicaDao.Get(id);
		}

		public VwHistoriaclinica GetVwHistoriaclinica(Expression<Func<VwHistoriaclinica, bool>> criteria)
		{
			return VwHistoriaclinicaDao.Get(criteria);
		}
	}
}

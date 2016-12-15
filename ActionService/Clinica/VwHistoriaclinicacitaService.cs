using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwHistoriaclinicacita()
		{
			return VwHistoriaclinicacitaDao.Count();
		}

		public long CountVwHistoriaclinicacita(Expression<Func<VwHistoriaclinicacita, bool>> criteria)
		{
			return VwHistoriaclinicacitaDao.Count(criteria);
		}

		public List<VwHistoriaclinicacita> GetAllVwHistoriaclinicacita()
		{
			return VwHistoriaclinicacitaDao.GetAll();
		}

		public List<VwHistoriaclinicacita> GetAllVwHistoriaclinicacita(Expression<Func<VwHistoriaclinicacita, bool>> criteria)
		{
			return VwHistoriaclinicacitaDao.GetAll(criteria);
		}

		public List<VwHistoriaclinicacita> GetAllVwHistoriaclinicacita(string orders)
		{
			return VwHistoriaclinicacitaDao.GetAll(orders);
		}

		public List<VwHistoriaclinicacita> GetAllVwHistoriaclinicacita(string conditions, string orders)
		{
			return VwHistoriaclinicacitaDao.GetAll(conditions, orders);
		}

		public VwHistoriaclinicacita GetVwHistoriaclinicacita(int id)
		{
			return VwHistoriaclinicacitaDao.Get(id);
		}

		public VwHistoriaclinicacita GetVwHistoriaclinicacita(Expression<Func<VwHistoriaclinicacita, bool>> criteria)
		{
			return VwHistoriaclinicacitaDao.Get(criteria);
		}
	}
}

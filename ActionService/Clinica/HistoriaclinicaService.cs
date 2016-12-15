using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountHistoriaclinica()
		{
			return HistoriaclinicaDao.Count();
		}

		public long CountHistoriaclinica(Expression<Func<Historiaclinica, bool>> criteria)
		{
			return HistoriaclinicaDao.Count(criteria);
		}

		public int SaveHistoriaclinica(Historiaclinica entity)
		{
			return HistoriaclinicaDao.Save(entity);
		}

		public void UpdateHistoriaclinica(Historiaclinica entity)
		{
			HistoriaclinicaDao.Update(entity);
		}

		public void DeleteHistoriaclinica(int id)
		{
			HistoriaclinicaDao.Delete(id);
		}

		public List<Historiaclinica> GetAllHistoriaclinica()
		{
			return HistoriaclinicaDao.GetAll();
		}

		public List<Historiaclinica> GetAllHistoriaclinica(Expression<Func<Historiaclinica, bool>> criteria)
		{
			return HistoriaclinicaDao.GetAll(criteria);
		}

		public List<Historiaclinica> GetAllHistoriaclinica(string orders)
		{
			return HistoriaclinicaDao.GetAll(orders);
		}

		public List<Historiaclinica> GetAllHistoriaclinica(string conditions, string orders)
		{
			return HistoriaclinicaDao.GetAll(conditions, orders);
		}

		public Historiaclinica GetHistoriaclinica(int id)
		{
			return HistoriaclinicaDao.Get(id);
		}

		public Historiaclinica GetHistoriaclinica(Expression<Func<Historiaclinica, bool>> criteria)
		{
			return HistoriaclinicaDao.Get(criteria);
		}
	}
}

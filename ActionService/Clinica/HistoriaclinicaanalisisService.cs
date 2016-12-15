using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountHistoriaclinicaanalisis()
		{
			return HistoriaclinicaanalisisDao.Count();
		}

		public long CountHistoriaclinicaanalisis(Expression<Func<Historiaclinicaanalisis, bool>> criteria)
		{
			return HistoriaclinicaanalisisDao.Count(criteria);
		}

		public int SaveHistoriaclinicaanalisis(Historiaclinicaanalisis entity)
		{
			return HistoriaclinicaanalisisDao.Save(entity);
		}

		public void UpdateHistoriaclinicaanalisis(Historiaclinicaanalisis entity)
		{
			HistoriaclinicaanalisisDao.Update(entity);
		}

		public void DeleteHistoriaclinicaanalisis(int id)
		{
			HistoriaclinicaanalisisDao.Delete(id);
		}

		public List<Historiaclinicaanalisis> GetAllHistoriaclinicaanalisis()
		{
			return HistoriaclinicaanalisisDao.GetAll();
		}

		public List<Historiaclinicaanalisis> GetAllHistoriaclinicaanalisis(Expression<Func<Historiaclinicaanalisis, bool>> criteria)
		{
			return HistoriaclinicaanalisisDao.GetAll(criteria);
		}

		public List<Historiaclinicaanalisis> GetAllHistoriaclinicaanalisis(string orders)
		{
			return HistoriaclinicaanalisisDao.GetAll(orders);
		}

		public List<Historiaclinicaanalisis> GetAllHistoriaclinicaanalisis(string conditions, string orders)
		{
			return HistoriaclinicaanalisisDao.GetAll(conditions, orders);
		}

		public Historiaclinicaanalisis GetHistoriaclinicaanalisis(int id)
		{
			return HistoriaclinicaanalisisDao.Get(id);
		}

		public Historiaclinicaanalisis GetHistoriaclinicaanalisis(Expression<Func<Historiaclinicaanalisis, bool>> criteria)
		{
			return HistoriaclinicaanalisisDao.Get(criteria);
		}
	}
}

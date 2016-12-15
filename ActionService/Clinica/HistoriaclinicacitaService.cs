using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountHistoriaclinicacita()
		{
			return HistoriaclinicacitaDao.Count();
		}

		public long CountHistoriaclinicacita(Expression<Func<Historiaclinicacita, bool>> criteria)
		{
			return HistoriaclinicacitaDao.Count(criteria);
		}

		public int SaveHistoriaclinicacita(Historiaclinicacita entity)
		{
			return HistoriaclinicacitaDao.Save(entity);
		}

		public void UpdateHistoriaclinicacita(Historiaclinicacita entity)
		{
			HistoriaclinicacitaDao.Update(entity);
		}

		public void DeleteHistoriaclinicacita(int id)
		{
			HistoriaclinicacitaDao.Delete(id);
		}

		public List<Historiaclinicacita> GetAllHistoriaclinicacita()
		{
			return HistoriaclinicacitaDao.GetAll();
		}

		public List<Historiaclinicacita> GetAllHistoriaclinicacita(Expression<Func<Historiaclinicacita, bool>> criteria)
		{
			return HistoriaclinicacitaDao.GetAll(criteria);
		}

		public List<Historiaclinicacita> GetAllHistoriaclinicacita(string orders)
		{
			return HistoriaclinicacitaDao.GetAll(orders);
		}

		public List<Historiaclinicacita> GetAllHistoriaclinicacita(string conditions, string orders)
		{
			return HistoriaclinicacitaDao.GetAll(conditions, orders);
		}

		public Historiaclinicacita GetHistoriaclinicacita(int id)
		{
			return HistoriaclinicacitaDao.Get(id);
		}

		public Historiaclinicacita GetHistoriaclinicacita(Expression<Func<Historiaclinicacita, bool>> criteria)
		{
			return HistoriaclinicacitaDao.Get(criteria);
		}
	}
}

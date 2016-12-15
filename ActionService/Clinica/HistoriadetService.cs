using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountHistoriadet()
		{
			return HistoriadetDao.Count();
		}

		public long CountHistoriadet(Expression<Func<Historiadet, bool>> criteria)
		{
			return HistoriadetDao.Count(criteria);
		}

		public int SaveHistoriadet(Historiadet entity)
		{
			return HistoriadetDao.Save(entity);
		}

		public void UpdateHistoriadet(Historiadet entity)
		{
			HistoriadetDao.Update(entity);
		}

		public void DeleteHistoriadet(int id)
		{
			HistoriadetDao.Delete(id);
		}

		public List<Historiadet> GetAllHistoriadet()
		{
			return HistoriadetDao.GetAll();
		}

		public List<Historiadet> GetAllHistoriadet(Expression<Func<Historiadet, bool>> criteria)
		{
			return HistoriadetDao.GetAll(criteria);
		}

		public List<Historiadet> GetAllHistoriadet(string orders)
		{
			return HistoriadetDao.GetAll(orders);
		}

		public List<Historiadet> GetAllHistoriadet(string conditions, string orders)
		{
			return HistoriadetDao.GetAll(conditions, orders);
		}

		public Historiadet GetHistoriadet(int id)
		{
			return HistoriadetDao.Get(id);
		}

		public Historiadet GetHistoriadet(Expression<Func<Historiadet, bool>> criteria)
		{
			return HistoriadetDao.Get(criteria);
		}
	}
}

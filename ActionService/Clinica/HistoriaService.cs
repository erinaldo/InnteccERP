using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountHistoria()
		{
			return HistoriaDao.Count();
		}

		public long CountHistoria(Expression<Func<Historia, bool>> criteria)
		{
			return HistoriaDao.Count(criteria);
		}

		public int SaveHistoria(Historia entity)
		{
			return HistoriaDao.Save(entity);
		}

		public void UpdateHistoria(Historia entity)
		{
			HistoriaDao.Update(entity);
		}

		public void DeleteHistoria(int id)
		{
			HistoriaDao.Delete(id);
		}

		public List<Historia> GetAllHistoria()
		{
			return HistoriaDao.GetAll();
		}

		public List<Historia> GetAllHistoria(Expression<Func<Historia, bool>> criteria)
		{
			return HistoriaDao.GetAll(criteria);
		}

		public List<Historia> GetAllHistoria(string orders)
		{
			return HistoriaDao.GetAll(orders);
		}

		public List<Historia> GetAllHistoria(string conditions, string orders)
		{
			return HistoriaDao.GetAll(conditions, orders);
		}

		public Historia GetHistoria(int id)
		{
			return HistoriaDao.Get(id);
		}

		public Historia GetHistoria(Expression<Func<Historia, bool>> criteria)
		{
			return HistoriaDao.Get(criteria);
		}
	}
}

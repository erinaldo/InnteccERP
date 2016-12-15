using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountHistoriadetitem()
		{
			return HistoriadetitemDao.Count();
		}

		public long CountHistoriadetitem(Expression<Func<Historiadetitem, bool>> criteria)
		{
			return HistoriadetitemDao.Count(criteria);
		}

		public int SaveHistoriadetitem(Historiadetitem entity)
		{
			return HistoriadetitemDao.Save(entity);
		}

		public void UpdateHistoriadetitem(Historiadetitem entity)
		{
			HistoriadetitemDao.Update(entity);
		}

		public void DeleteHistoriadetitem(int id)
		{
			HistoriadetitemDao.Delete(id);
		}

		public List<Historiadetitem> GetAllHistoriadetitem()
		{
			return HistoriadetitemDao.GetAll();
		}

		public List<Historiadetitem> GetAllHistoriadetitem(Expression<Func<Historiadetitem, bool>> criteria)
		{
			return HistoriadetitemDao.GetAll(criteria);
		}

		public List<Historiadetitem> GetAllHistoriadetitem(string orders)
		{
			return HistoriadetitemDao.GetAll(orders);
		}

		public List<Historiadetitem> GetAllHistoriadetitem(string conditions, string orders)
		{
			return HistoriadetitemDao.GetAll(conditions, orders);
		}

		public Historiadetitem GetHistoriadetitem(int id)
		{
			return HistoriadetitemDao.Get(id);
		}

		public Historiadetitem GetHistoriadetitem(Expression<Func<Historiadetitem, bool>> criteria)
		{
			return HistoriadetitemDao.Get(criteria);
		}
	}
}

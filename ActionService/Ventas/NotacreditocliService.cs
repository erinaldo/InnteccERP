using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountNotacreditocli()
		{
			return NotacreditocliDao.Count();
		}

		public long CountNotacreditocli(Expression<Func<Notacreditocli, bool>> criteria)
		{
			return NotacreditocliDao.Count(criteria);
		}

		public int SaveNotacreditocli(Notacreditocli entity)
		{
			return NotacreditocliDao.Save(entity);
		}

		public void UpdateNotacreditocli(Notacreditocli entity)
		{
			NotacreditocliDao.Update(entity);
		}

		public void DeleteNotacreditocli(int id)
		{
			NotacreditocliDao.Delete(id);
		}

		public List<Notacreditocli> GetAllNotacreditocli()
		{
			return NotacreditocliDao.GetAll();
		}

		public List<Notacreditocli> GetAllNotacreditocli(Expression<Func<Notacreditocli, bool>> criteria)
		{
			return NotacreditocliDao.GetAll(criteria);
		}

		public List<Notacreditocli> GetAllNotacreditocli(string orders)
		{
			return NotacreditocliDao.GetAll(orders);
		}

		public List<Notacreditocli> GetAllNotacreditocli(string conditions, string orders)
		{
			return NotacreditocliDao.GetAll(conditions, orders);
		}

		public Notacreditocli GetNotacreditocli(int id)
		{
			return NotacreditocliDao.Get(id);
		}

		public Notacreditocli GetNotacreditocli(Expression<Func<Notacreditocli, bool>> criteria)
		{
			return NotacreditocliDao.Get(criteria);
		}
	}
}

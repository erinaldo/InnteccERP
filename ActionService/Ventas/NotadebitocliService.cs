using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountNotadebitocli()
		{
			return NotadebitocliDao.Count();
		}

		public long CountNotadebitocli(Expression<Func<Notadebitocli, bool>> criteria)
		{
			return NotadebitocliDao.Count(criteria);
		}

		public int SaveNotadebitocli(Notadebitocli entity)
		{
			return NotadebitocliDao.Save(entity);
		}

		public void UpdateNotadebitocli(Notadebitocli entity)
		{
			NotadebitocliDao.Update(entity);
		}

		public void DeleteNotadebitocli(int id)
		{
			NotadebitocliDao.Delete(id);
		}

		public List<Notadebitocli> GetAllNotadebitocli()
		{
			return NotadebitocliDao.GetAll();
		}

		public List<Notadebitocli> GetAllNotadebitocli(Expression<Func<Notadebitocli, bool>> criteria)
		{
			return NotadebitocliDao.GetAll(criteria);
		}

		public List<Notadebitocli> GetAllNotadebitocli(string orders)
		{
			return NotadebitocliDao.GetAll(orders);
		}

		public List<Notadebitocli> GetAllNotadebitocli(string conditions, string orders)
		{
			return NotadebitocliDao.GetAll(conditions, orders);
		}

		public Notadebitocli GetNotadebitocli(int id)
		{
			return NotadebitocliDao.Get(id);
		}

		public Notadebitocli GetNotadebitocli(Expression<Func<Notadebitocli, bool>> criteria)
		{
			return NotadebitocliDao.Get(criteria);
		}
	}
}

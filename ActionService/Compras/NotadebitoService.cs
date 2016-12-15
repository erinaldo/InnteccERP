using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountNotadebito()
		{
			return NotadebitoDao.Count();
		}

		public long CountNotadebito(Expression<Func<Notadebito, bool>> criteria)
		{
			return NotadebitoDao.Count(criteria);
		}

		public int SaveNotadebito(Notadebito entity)
		{
			return NotadebitoDao.Save(entity);
		}

		public void UpdateNotadebito(Notadebito entity)
		{
			NotadebitoDao.Update(entity);
		}

		public void DeleteNotadebito(int id)
		{
			NotadebitoDao.Delete(id);
		}

		public List<Notadebito> GetAllNotadebito()
		{
			return NotadebitoDao.GetAll();
		}

		public List<Notadebito> GetAllNotadebito(Expression<Func<Notadebito, bool>> criteria)
		{
			return NotadebitoDao.GetAll(criteria);
		}

		public List<Notadebito> GetAllNotadebito(string orders)
		{
			return NotadebitoDao.GetAll(orders);
		}

		public List<Notadebito> GetAllNotadebito(string conditions, string orders)
		{
			return NotadebitoDao.GetAll(conditions, orders);
		}

		public Notadebito GetNotadebito(int id)
		{
			return NotadebitoDao.Get(id);
		}

		public Notadebito GetNotadebito(Expression<Func<Notadebito, bool>> criteria)
		{
			return NotadebitoDao.Get(criteria);
		}
	}
}

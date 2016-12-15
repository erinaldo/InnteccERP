using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountNotadebitodet()
		{
			return NotadebitodetDao.Count();
		}

		public long CountNotadebitodet(Expression<Func<Notadebitodet, bool>> criteria)
		{
			return NotadebitodetDao.Count(criteria);
		}

		public int SaveNotadebitodet(Notadebitodet entity)
		{
			return NotadebitodetDao.Save(entity);
		}

		public void UpdateNotadebitodet(Notadebitodet entity)
		{
			NotadebitodetDao.Update(entity);
		}

		public void DeleteNotadebitodet(int id)
		{
			NotadebitodetDao.Delete(id);
		}

		public List<Notadebitodet> GetAllNotadebitodet()
		{
			return NotadebitodetDao.GetAll();
		}

		public List<Notadebitodet> GetAllNotadebitodet(Expression<Func<Notadebitodet, bool>> criteria)
		{
			return NotadebitodetDao.GetAll(criteria);
		}

		public List<Notadebitodet> GetAllNotadebitodet(string orders)
		{
			return NotadebitodetDao.GetAll(orders);
		}

		public List<Notadebitodet> GetAllNotadebitodet(string conditions, string orders)
		{
			return NotadebitodetDao.GetAll(conditions, orders);
		}

		public Notadebitodet GetNotadebitodet(int id)
		{
			return NotadebitodetDao.Get(id);
		}

		public Notadebitodet GetNotadebitodet(Expression<Func<Notadebitodet, bool>> criteria)
		{
			return NotadebitodetDao.Get(criteria);
		}
	}
}

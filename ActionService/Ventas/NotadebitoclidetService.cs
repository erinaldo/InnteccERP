using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountNotadebitoclidet()
		{
			return NotadebitoclidetDao.Count();
		}

		public long CountNotadebitoclidet(Expression<Func<Notadebitoclidet, bool>> criteria)
		{
			return NotadebitoclidetDao.Count(criteria);
		}

		public int SaveNotadebitoclidet(Notadebitoclidet entity)
		{
			return NotadebitoclidetDao.Save(entity);
		}

		public void UpdateNotadebitoclidet(Notadebitoclidet entity)
		{
			NotadebitoclidetDao.Update(entity);
		}

		public void DeleteNotadebitoclidet(int id)
		{
			NotadebitoclidetDao.Delete(id);
		}

		public List<Notadebitoclidet> GetAllNotadebitoclidet()
		{
			return NotadebitoclidetDao.GetAll();
		}

		public List<Notadebitoclidet> GetAllNotadebitoclidet(Expression<Func<Notadebitoclidet, bool>> criteria)
		{
			return NotadebitoclidetDao.GetAll(criteria);
		}

		public List<Notadebitoclidet> GetAllNotadebitoclidet(string orders)
		{
			return NotadebitoclidetDao.GetAll(orders);
		}

		public List<Notadebitoclidet> GetAllNotadebitoclidet(string conditions, string orders)
		{
			return NotadebitoclidetDao.GetAll(conditions, orders);
		}

		public Notadebitoclidet GetNotadebitoclidet(int id)
		{
			return NotadebitoclidetDao.Get(id);
		}

		public Notadebitoclidet GetNotadebitoclidet(Expression<Func<Notadebitoclidet, bool>> criteria)
		{
			return NotadebitoclidetDao.Get(criteria);
		}
	}
}

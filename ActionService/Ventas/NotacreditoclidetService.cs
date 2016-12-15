using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountNotacreditoclidet()
		{
			return NotacreditoclidetDao.Count();
		}

		public long CountNotacreditoclidet(Expression<Func<Notacreditoclidet, bool>> criteria)
		{
			return NotacreditoclidetDao.Count(criteria);
		}

		public int SaveNotacreditoclidet(Notacreditoclidet entity)
		{
			return NotacreditoclidetDao.Save(entity);
		}

		public void UpdateNotacreditoclidet(Notacreditoclidet entity)
		{
			NotacreditoclidetDao.Update(entity);
		}

		public void DeleteNotacreditoclidet(int id)
		{
			NotacreditoclidetDao.Delete(id);
		}

		public List<Notacreditoclidet> GetAllNotacreditoclidet()
		{
			return NotacreditoclidetDao.GetAll();
		}

		public List<Notacreditoclidet> GetAllNotacreditoclidet(Expression<Func<Notacreditoclidet, bool>> criteria)
		{
			return NotacreditoclidetDao.GetAll(criteria);
		}

		public List<Notacreditoclidet> GetAllNotacreditoclidet(string orders)
		{
			return NotacreditoclidetDao.GetAll(orders);
		}

		public List<Notacreditoclidet> GetAllNotacreditoclidet(string conditions, string orders)
		{
			return NotacreditoclidetDao.GetAll(conditions, orders);
		}

		public Notacreditoclidet GetNotacreditoclidet(int id)
		{
			return NotacreditoclidetDao.Get(id);
		}

		public Notacreditoclidet GetNotacreditoclidet(Expression<Func<Notacreditoclidet, bool>> criteria)
		{
			return NotacreditoclidetDao.Get(criteria);
		}
	}
}

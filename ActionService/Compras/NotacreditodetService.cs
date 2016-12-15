using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountNotacreditodet()
		{
			return NotacreditodetDao.Count();
		}

		public long CountNotacreditodet(Expression<Func<Notacreditodet, bool>> criteria)
		{
			return NotacreditodetDao.Count(criteria);
		}

		public int SaveNotacreditodet(Notacreditodet entity)
		{
			return NotacreditodetDao.Save(entity);
		}

		public void UpdateNotacreditodet(Notacreditodet entity)
		{
			NotacreditodetDao.Update(entity);
		}

		public void DeleteNotacreditodet(int id)
		{
			NotacreditodetDao.Delete(id);
		}

		public List<Notacreditodet> GetAllNotacreditodet()
		{
			return NotacreditodetDao.GetAll();
		}

		public List<Notacreditodet> GetAllNotacreditodet(Expression<Func<Notacreditodet, bool>> criteria)
		{
			return NotacreditodetDao.GetAll(criteria);
		}

		public List<Notacreditodet> GetAllNotacreditodet(string orders)
		{
			return NotacreditodetDao.GetAll(orders);
		}

		public List<Notacreditodet> GetAllNotacreditodet(string conditions, string orders)
		{
			return NotacreditodetDao.GetAll(conditions, orders);
		}

		public Notacreditodet GetNotacreditodet(int id)
		{
			return NotacreditodetDao.Get(id);
		}

		public Notacreditodet GetNotacreditodet(Expression<Func<Notacreditodet, bool>> criteria)
		{
			return NotacreditodetDao.Get(criteria);
		}
	}
}

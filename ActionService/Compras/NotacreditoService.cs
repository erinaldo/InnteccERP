using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountNotacredito()
		{
			return NotacreditoDao.Count();
		}

		public long CountNotacredito(Expression<Func<Notacredito, bool>> criteria)
		{
			return NotacreditoDao.Count(criteria);
		}

		public int SaveNotacredito(Notacredito entity)
		{
			return NotacreditoDao.Save(entity);
		}

		public void UpdateNotacredito(Notacredito entity)
		{
			NotacreditoDao.Update(entity);
		}

		public void DeleteNotacredito(int id)
		{
			NotacreditoDao.Delete(id);
		}

		public List<Notacredito> GetAllNotacredito()
		{
			return NotacreditoDao.GetAll();
		}

		public List<Notacredito> GetAllNotacredito(Expression<Func<Notacredito, bool>> criteria)
		{
			return NotacreditoDao.GetAll(criteria);
		}

		public List<Notacredito> GetAllNotacredito(string orders)
		{
			return NotacreditoDao.GetAll(orders);
		}

		public List<Notacredito> GetAllNotacredito(string conditions, string orders)
		{
			return NotacreditoDao.GetAll(conditions, orders);
		}

		public Notacredito GetNotacredito(int id)
		{
			return NotacreditoDao.Get(id);
		}

		public Notacredito GetNotacredito(Expression<Func<Notacredito, bool>> criteria)
		{
			return NotacreditoDao.Get(criteria);
		}
	}
}

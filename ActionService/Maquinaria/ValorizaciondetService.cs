using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizaciondet()
		{
			return ValorizaciondetDao.Count();
		}

		public long CountValorizaciondet(Expression<Func<Valorizaciondet, bool>> criteria)
		{
			return ValorizaciondetDao.Count(criteria);
		}

		public int SaveValorizaciondet(Valorizaciondet entity)
		{
			return ValorizaciondetDao.Save(entity);
		}

		public void UpdateValorizaciondet(Valorizaciondet entity)
		{
			ValorizaciondetDao.Update(entity);
		}

		public void DeleteValorizaciondet(int id)
		{
			ValorizaciondetDao.Delete(id);
		}

		public List<Valorizaciondet> GetAllValorizaciondet()
		{
			return ValorizaciondetDao.GetAll();
		}

		public List<Valorizaciondet> GetAllValorizaciondet(Expression<Func<Valorizaciondet, bool>> criteria)
		{
			return ValorizaciondetDao.GetAll(criteria);
		}

		public List<Valorizaciondet> GetAllValorizaciondet(string orders)
		{
			return ValorizaciondetDao.GetAll(orders);
		}

		public List<Valorizaciondet> GetAllValorizaciondet(string conditions, string orders)
		{
			return ValorizaciondetDao.GetAll(conditions, orders);
		}

		public Valorizaciondet GetValorizaciondet(int id)
		{
			return ValorizaciondetDao.Get(id);
		}

		public Valorizaciondet GetValorizaciondet(Expression<Func<Valorizaciondet, bool>> criteria)
		{
			return ValorizaciondetDao.Get(criteria);
		}
	}
}

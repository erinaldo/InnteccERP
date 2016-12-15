using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRequerimientodet()
		{
			return RequerimientodetDao.Count();
		}

		public long CountRequerimientodet(Expression<Func<Requerimientodet, bool>> criteria)
		{
			return RequerimientodetDao.Count(criteria);
		}

		public int SaveRequerimientodet(Requerimientodet entity)
		{
			return RequerimientodetDao.Save(entity);
		}

		public void UpdateRequerimientodet(Requerimientodet entity)
		{
			RequerimientodetDao.Update(entity);
		}

		public void DeleteRequerimientodet(int id)
		{
			RequerimientodetDao.Delete(id);
		}

		public List<Requerimientodet> GetAllRequerimientodet()
		{
			return RequerimientodetDao.GetAll();
		}

		public List<Requerimientodet> GetAllRequerimientodet(Expression<Func<Requerimientodet, bool>> criteria)
		{
			return RequerimientodetDao.GetAll(criteria);
		}

		public List<Requerimientodet> GetAllRequerimientodet(string orders)
		{
			return RequerimientodetDao.GetAll(orders);
		}

		public List<Requerimientodet> GetAllRequerimientodet(string conditions, string orders)
		{
			return RequerimientodetDao.GetAll(conditions, orders);
		}

		public Requerimientodet GetRequerimientodet(int id)
		{
			return RequerimientodetDao.Get(id);
		}

		public Requerimientodet GetRequerimientodet(Expression<Func<Requerimientodet, bool>> criteria)
		{
			return RequerimientodetDao.Get(criteria);
		}
	}
}

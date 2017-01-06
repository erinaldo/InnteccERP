using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountCpt()
		{
			return CptDao.Count();
		}

		public long CountCpt(Expression<Func<Cpt, bool>> criteria)
		{
			return CptDao.Count(criteria);
		}

		public int SaveCpt(Cpt entity)
		{
			return CptDao.Save(entity);
		}

		public void UpdateCpt(Cpt entity)
		{
			CptDao.Update(entity);
		}

		public void DeleteCpt(int id)
		{
			CptDao.Delete(id);
		}

		public List<Cpt> GetAllCpt()
		{
			return CptDao.GetAll();
		}

		public List<Cpt> GetAllCpt(Expression<Func<Cpt, bool>> criteria)
		{
			return CptDao.GetAll(criteria);
		}

		public List<Cpt> GetAllCpt(string orders)
		{
			return CptDao.GetAll(orders);
		}

		public List<Cpt> GetAllCpt(string conditions, string orders)
		{
			return CptDao.GetAll(conditions, orders);
		}

		public Cpt GetCpt(int id)
		{
			return CptDao.Get(id);
		}

		public Cpt GetCpt(Expression<Func<Cpt, bool>> criteria)
		{
			return CptDao.Get(criteria);
		}
	}
}

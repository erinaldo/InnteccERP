using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCpcompradet()
		{
			return CpcompradetDao.Count();
		}

		public long CountCpcompradet(Expression<Func<Cpcompradet, bool>> criteria)
		{
			return CpcompradetDao.Count(criteria);
		}

		public int SaveCpcompradet(Cpcompradet entity)
		{
			return CpcompradetDao.Save(entity);
		}

		public void UpdateCpcompradet(Cpcompradet entity)
		{
			CpcompradetDao.Update(entity);
		}

		public void DeleteCpcompradet(int id)
		{
			CpcompradetDao.Delete(id);
		}

		public List<Cpcompradet> GetAllCpcompradet()
		{
			return CpcompradetDao.GetAll();
		}

		public List<Cpcompradet> GetAllCpcompradet(Expression<Func<Cpcompradet, bool>> criteria)
		{
			return CpcompradetDao.GetAll(criteria);
		}

		public List<Cpcompradet> GetAllCpcompradet(string orders)
		{
			return CpcompradetDao.GetAll(orders);
		}

		public List<Cpcompradet> GetAllCpcompradet(string conditions, string orders)
		{
			return CpcompradetDao.GetAll(conditions, orders);
		}

		public Cpcompradet GetCpcompradet(int id)
		{
			return CpcompradetDao.Get(id);
		}

		public Cpcompradet GetCpcompradet(Expression<Func<Cpcompradet, bool>> criteria)
		{
			return CpcompradetDao.Get(criteria);
		}
	}
}

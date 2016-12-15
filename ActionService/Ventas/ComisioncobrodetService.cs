using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountComisioncobrodet()
		{
			return ComisioncobrodetDao.Count();
		}

		public long CountComisioncobrodet(Expression<Func<Comisioncobrodet, bool>> criteria)
		{
			return ComisioncobrodetDao.Count(criteria);
		}

		public int SaveComisioncobrodet(Comisioncobrodet entity)
		{
			return ComisioncobrodetDao.Save(entity);
		}

		public void UpdateComisioncobrodet(Comisioncobrodet entity)
		{
			ComisioncobrodetDao.Update(entity);
		}

		public void DeleteComisioncobrodet(int id)
		{
			ComisioncobrodetDao.Delete(id);
		}

		public List<Comisioncobrodet> GetAllComisioncobrodet()
		{
			return ComisioncobrodetDao.GetAll();
		}

		public List<Comisioncobrodet> GetAllComisioncobrodet(Expression<Func<Comisioncobrodet, bool>> criteria)
		{
			return ComisioncobrodetDao.GetAll(criteria);
		}

		public List<Comisioncobrodet> GetAllComisioncobrodet(string orders)
		{
			return ComisioncobrodetDao.GetAll(orders);
		}

		public List<Comisioncobrodet> GetAllComisioncobrodet(string conditions, string orders)
		{
			return ComisioncobrodetDao.GetAll(conditions, orders);
		}

		public Comisioncobrodet GetComisioncobrodet(int id)
		{
			return ComisioncobrodetDao.Get(id);
		}

		public Comisioncobrodet GetComisioncobrodet(Expression<Func<Comisioncobrodet, bool>> criteria)
		{
			return ComisioncobrodetDao.Get(criteria);
		}
	}
}

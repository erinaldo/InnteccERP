using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipociclomenstrual()
		{
			return TipociclomenstrualDao.Count();
		}

		public long CountTipociclomenstrual(Expression<Func<Tipociclomenstrual, bool>> criteria)
		{
			return TipociclomenstrualDao.Count(criteria);
		}

		public int SaveTipociclomenstrual(Tipociclomenstrual entity)
		{
			return TipociclomenstrualDao.Save(entity);
		}

		public void UpdateTipociclomenstrual(Tipociclomenstrual entity)
		{
			TipociclomenstrualDao.Update(entity);
		}

		public void DeleteTipociclomenstrual(int id)
		{
			TipociclomenstrualDao.Delete(id);
		}

		public List<Tipociclomenstrual> GetAllTipociclomenstrual()
		{
			return TipociclomenstrualDao.GetAll();
		}

		public List<Tipociclomenstrual> GetAllTipociclomenstrual(Expression<Func<Tipociclomenstrual, bool>> criteria)
		{
			return TipociclomenstrualDao.GetAll(criteria);
		}

		public List<Tipociclomenstrual> GetAllTipociclomenstrual(string orders)
		{
			return TipociclomenstrualDao.GetAll(orders);
		}

		public List<Tipociclomenstrual> GetAllTipociclomenstrual(string conditions, string orders)
		{
			return TipociclomenstrualDao.GetAll(conditions, orders);
		}

		public Tipociclomenstrual GetTipociclomenstrual(int id)
		{
			return TipociclomenstrualDao.Get(id);
		}

		public Tipociclomenstrual GetTipociclomenstrual(Expression<Func<Tipociclomenstrual, bool>> criteria)
		{
			return TipociclomenstrualDao.Get(criteria);
		}
	}
}

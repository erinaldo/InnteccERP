using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipotope()
		{
			return TipotopeDao.Count();
		}

		public long CountTipotope(Expression<Func<Tipotope, bool>> criteria)
		{
			return TipotopeDao.Count(criteria);
		}

		public int SaveTipotope(Tipotope entity)
		{
			return TipotopeDao.Save(entity);
		}

		public void UpdateTipotope(Tipotope entity)
		{
			TipotopeDao.Update(entity);
		}

		public void DeleteTipotope(int id)
		{
			TipotopeDao.Delete(id);
		}

		public List<Tipotope> GetAllTipotope()
		{
			return TipotopeDao.GetAll();
		}

		public List<Tipotope> GetAllTipotope(Expression<Func<Tipotope, bool>> criteria)
		{
			return TipotopeDao.GetAll(criteria);
		}

		public List<Tipotope> GetAllTipotope(string orders)
		{
			return TipotopeDao.GetAll(orders);
		}

		public List<Tipotope> GetAllTipotope(string conditions, string orders)
		{
			return TipotopeDao.GetAll(conditions, orders);
		}

		public Tipotope GetTipotope(int id)
		{
			return TipotopeDao.Get(id);
		}

		public Tipotope GetTipotope(Expression<Func<Tipotope, bool>> criteria)
		{
			return TipotopeDao.Get(criteria);
		}
	}
}

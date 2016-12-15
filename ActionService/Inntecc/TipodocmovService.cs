using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipodocmov()
		{
			return TipodocmovDao.Count();
		}

		public long CountTipodocmov(Expression<Func<Tipodocmov, bool>> criteria)
		{
			return TipodocmovDao.Count(criteria);
		}

		public int SaveTipodocmov(Tipodocmov entity)
		{
			return TipodocmovDao.Save(entity);
		}

		public void UpdateTipodocmov(Tipodocmov entity)
		{
			TipodocmovDao.Update(entity);
		}

		public void DeleteTipodocmov(int id)
		{
			TipodocmovDao.Delete(id);
		}

		public List<Tipodocmov> GetAllTipodocmov()
		{
			return TipodocmovDao.GetAll();
		}

		public List<Tipodocmov> GetAllTipodocmov(Expression<Func<Tipodocmov, bool>> criteria)
		{
			return TipodocmovDao.GetAll(criteria);
		}

		public List<Tipodocmov> GetAllTipodocmov(string orders)
		{
			return TipodocmovDao.GetAll(orders);
		}

		public List<Tipodocmov> GetAllTipodocmov(string conditions, string orders)
		{
			return TipodocmovDao.GetAll(conditions, orders);
		}

		public Tipodocmov GetTipodocmov(int id)
		{
			return TipodocmovDao.Get(id);
		}

		public Tipodocmov GetTipodocmov(Expression<Func<Tipodocmov, bool>> criteria)
		{
			return TipodocmovDao.Get(criteria);
		}
	}
}

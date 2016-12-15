using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipocondicion()
		{
			return TipocondicionDao.Count();
		}

		public long CountTipocondicion(Expression<Func<Tipocondicion, bool>> criteria)
		{
			return TipocondicionDao.Count(criteria);
		}

		public int SaveTipocondicion(Tipocondicion entity)
		{
			return TipocondicionDao.Save(entity);
		}

		public void UpdateTipocondicion(Tipocondicion entity)
		{
			TipocondicionDao.Update(entity);
		}

		public void DeleteTipocondicion(int id)
		{
			TipocondicionDao.Delete(id);
		}

		public List<Tipocondicion> GetAllTipocondicion()
		{
			return TipocondicionDao.GetAll();
		}

		public List<Tipocondicion> GetAllTipocondicion(Expression<Func<Tipocondicion, bool>> criteria)
		{
			return TipocondicionDao.GetAll(criteria);
		}

		public List<Tipocondicion> GetAllTipocondicion(string orders)
		{
			return TipocondicionDao.GetAll(orders);
		}

		public List<Tipocondicion> GetAllTipocondicion(string conditions, string orders)
		{
			return TipocondicionDao.GetAll(conditions, orders);
		}

		public Tipocondicion GetTipocondicion(int id)
		{
			return TipocondicionDao.Get(id);
		}

		public Tipocondicion GetTipocondicion(Expression<Func<Tipocondicion, bool>> criteria)
		{
			return TipocondicionDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipoparto()
		{
			return TipopartoDao.Count();
		}

		public long CountTipoparto(Expression<Func<Tipoparto, bool>> criteria)
		{
			return TipopartoDao.Count(criteria);
		}

		public int SaveTipoparto(Tipoparto entity)
		{
			return TipopartoDao.Save(entity);
		}

		public void UpdateTipoparto(Tipoparto entity)
		{
			TipopartoDao.Update(entity);
		}

		public void DeleteTipoparto(int id)
		{
			TipopartoDao.Delete(id);
		}

		public List<Tipoparto> GetAllTipoparto()
		{
			return TipopartoDao.GetAll();
		}

		public List<Tipoparto> GetAllTipoparto(Expression<Func<Tipoparto, bool>> criteria)
		{
			return TipopartoDao.GetAll(criteria);
		}

		public List<Tipoparto> GetAllTipoparto(string orders)
		{
			return TipopartoDao.GetAll(orders);
		}

		public List<Tipoparto> GetAllTipoparto(string conditions, string orders)
		{
			return TipopartoDao.GetAll(conditions, orders);
		}

		public Tipoparto GetTipoparto(int id)
		{
			return TipopartoDao.Get(id);
		}

		public Tipoparto GetTipoparto(Expression<Func<Tipoparto, bool>> criteria)
		{
			return TipopartoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipocirugia()
		{
			return TipocirugiaDao.Count();
		}

		public long CountTipocirugia(Expression<Func<Tipocirugia, bool>> criteria)
		{
			return TipocirugiaDao.Count(criteria);
		}

		public int SaveTipocirugia(Tipocirugia entity)
		{
			return TipocirugiaDao.Save(entity);
		}

		public void UpdateTipocirugia(Tipocirugia entity)
		{
			TipocirugiaDao.Update(entity);
		}

		public void DeleteTipocirugia(int id)
		{
			TipocirugiaDao.Delete(id);
		}

		public List<Tipocirugia> GetAllTipocirugia()
		{
			return TipocirugiaDao.GetAll();
		}

		public List<Tipocirugia> GetAllTipocirugia(Expression<Func<Tipocirugia, bool>> criteria)
		{
			return TipocirugiaDao.GetAll(criteria);
		}

		public List<Tipocirugia> GetAllTipocirugia(string orders)
		{
			return TipocirugiaDao.GetAll(orders);
		}

		public List<Tipocirugia> GetAllTipocirugia(string conditions, string orders)
		{
			return TipocirugiaDao.GetAll(conditions, orders);
		}

		public Tipocirugia GetTipocirugia(int id)
		{
			return TipocirugiaDao.Get(id);
		}

		public Tipocirugia GetTipocirugia(Expression<Func<Tipocirugia, bool>> criteria)
		{
			return TipocirugiaDao.Get(criteria);
		}
	}
}

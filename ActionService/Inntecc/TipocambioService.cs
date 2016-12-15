using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipocambio()
		{
			return TipocambioDao.Count();
		}

		public long CountTipocambio(Expression<Func<Tipocambio, bool>> criteria)
		{
			return TipocambioDao.Count(criteria);
		}

		public int SaveTipocambio(Tipocambio entity)
		{
			return TipocambioDao.Save(entity);
		}

		public void UpdateTipocambio(Tipocambio entity)
		{
			TipocambioDao.Update(entity);
		}

		public void DeleteTipocambio(int id)
		{
			TipocambioDao.Delete(id);
		}

		public List<Tipocambio> GetAllTipocambio()
		{
			return TipocambioDao.GetAll();
		}

		public List<Tipocambio> GetAllTipocambio(Expression<Func<Tipocambio, bool>> criteria)
		{
			return TipocambioDao.GetAll(criteria);
		}

		public List<Tipocambio> GetAllTipocambio(string orders)
		{
			return TipocambioDao.GetAll(orders);
		}

		public List<Tipocambio> GetAllTipocambio(string conditions, string orders)
		{
			return TipocambioDao.GetAll(conditions, orders);
		}

		public Tipocambio GetTipocambio(int id)
		{
			return TipocambioDao.Get(id);
		}

		public Tipocambio GetTipocambio(Expression<Func<Tipocambio, bool>> criteria)
		{
			return TipocambioDao.Get(criteria);
		}
	}
}

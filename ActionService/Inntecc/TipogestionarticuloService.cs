using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipogestionarticulo()
		{
			return TipogestionarticuloDao.Count();
		}

		public long CountTipogestionarticulo(Expression<Func<Tipogestionarticulo, bool>> criteria)
		{
			return TipogestionarticuloDao.Count(criteria);
		}

		public int SaveTipogestionarticulo(Tipogestionarticulo entity)
		{
			return TipogestionarticuloDao.Save(entity);
		}

		public void UpdateTipogestionarticulo(Tipogestionarticulo entity)
		{
			TipogestionarticuloDao.Update(entity);
		}

		public void DeleteTipogestionarticulo(int id)
		{
			TipogestionarticuloDao.Delete(id);
		}

		public List<Tipogestionarticulo> GetAllTipogestionarticulo()
		{
			return TipogestionarticuloDao.GetAll();
		}

		public List<Tipogestionarticulo> GetAllTipogestionarticulo(Expression<Func<Tipogestionarticulo, bool>> criteria)
		{
			return TipogestionarticuloDao.GetAll(criteria);
		}

		public List<Tipogestionarticulo> GetAllTipogestionarticulo(string orders)
		{
			return TipogestionarticuloDao.GetAll(orders);
		}

		public List<Tipogestionarticulo> GetAllTipogestionarticulo(string conditions, string orders)
		{
			return TipogestionarticuloDao.GetAll(conditions, orders);
		}

		public Tipogestionarticulo GetTipogestionarticulo(int id)
		{
			return TipogestionarticuloDao.Get(id);
		}

		public Tipogestionarticulo GetTipogestionarticulo(Expression<Func<Tipogestionarticulo, bool>> criteria)
		{
			return TipogestionarticuloDao.Get(criteria);
		}
	}
}

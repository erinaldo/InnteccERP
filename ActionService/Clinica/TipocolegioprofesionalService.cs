using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipocolegioprofesional()
		{
			return TipocolegioprofesionalDao.Count();
		}

		public long CountTipocolegioprofesional(Expression<Func<Tipocolegioprofesional, bool>> criteria)
		{
			return TipocolegioprofesionalDao.Count(criteria);
		}

		public int SaveTipocolegioprofesional(Tipocolegioprofesional entity)
		{
			return TipocolegioprofesionalDao.Save(entity);
		}

		public void UpdateTipocolegioprofesional(Tipocolegioprofesional entity)
		{
			TipocolegioprofesionalDao.Update(entity);
		}

		public void DeleteTipocolegioprofesional(int id)
		{
			TipocolegioprofesionalDao.Delete(id);
		}

		public List<Tipocolegioprofesional> GetAllTipocolegioprofesional()
		{
			return TipocolegioprofesionalDao.GetAll();
		}

		public List<Tipocolegioprofesional> GetAllTipocolegioprofesional(Expression<Func<Tipocolegioprofesional, bool>> criteria)
		{
			return TipocolegioprofesionalDao.GetAll(criteria);
		}

		public List<Tipocolegioprofesional> GetAllTipocolegioprofesional(string orders)
		{
			return TipocolegioprofesionalDao.GetAll(orders);
		}

		public List<Tipocolegioprofesional> GetAllTipocolegioprofesional(string conditions, string orders)
		{
			return TipocolegioprofesionalDao.GetAll(conditions, orders);
		}

		public Tipocolegioprofesional GetTipocolegioprofesional(int id)
		{
			return TipocolegioprofesionalDao.Get(id);
		}

		public Tipocolegioprofesional GetTipocolegioprofesional(Expression<Func<Tipocolegioprofesional, bool>> criteria)
		{
			return TipocolegioprofesionalDao.Get(criteria);
		}
	}
}

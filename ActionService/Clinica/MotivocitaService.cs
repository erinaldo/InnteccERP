using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountMotivocita()
		{
			return MotivocitaDao.Count();
		}

		public long CountMotivocita(Expression<Func<Motivocita, bool>> criteria)
		{
			return MotivocitaDao.Count(criteria);
		}

		public int SaveMotivocita(Motivocita entity)
		{
			return MotivocitaDao.Save(entity);
		}

		public void UpdateMotivocita(Motivocita entity)
		{
			MotivocitaDao.Update(entity);
		}

		public void DeleteMotivocita(int id)
		{
			MotivocitaDao.Delete(id);
		}

		public List<Motivocita> GetAllMotivocita()
		{
			return MotivocitaDao.GetAll();
		}

		public List<Motivocita> GetAllMotivocita(Expression<Func<Motivocita, bool>> criteria)
		{
			return MotivocitaDao.GetAll(criteria);
		}

		public List<Motivocita> GetAllMotivocita(string orders)
		{
			return MotivocitaDao.GetAll(orders);
		}

		public List<Motivocita> GetAllMotivocita(string conditions, string orders)
		{
			return MotivocitaDao.GetAll(conditions, orders);
		}

		public Motivocita GetMotivocita(int id)
		{
			return MotivocitaDao.Get(id);
		}

		public Motivocita GetMotivocita(Expression<Func<Motivocita, bool>> criteria)
		{
			return MotivocitaDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizaciondanio()
		{
			return ValorizaciondanioDao.Count();
		}

		public long CountValorizaciondanio(Expression<Func<Valorizaciondanio, bool>> criteria)
		{
			return ValorizaciondanioDao.Count(criteria);
		}

		public int SaveValorizaciondanio(Valorizaciondanio entity)
		{
			return ValorizaciondanioDao.Save(entity);
		}

		public void UpdateValorizaciondanio(Valorizaciondanio entity)
		{
			ValorizaciondanioDao.Update(entity);
		}

		public void DeleteValorizaciondanio(int id)
		{
			ValorizaciondanioDao.Delete(id);
		}

		public List<Valorizaciondanio> GetAllValorizaciondanio()
		{
			return ValorizaciondanioDao.GetAll();
		}

		public List<Valorizaciondanio> GetAllValorizaciondanio(Expression<Func<Valorizaciondanio, bool>> criteria)
		{
			return ValorizaciondanioDao.GetAll(criteria);
		}

		public List<Valorizaciondanio> GetAllValorizaciondanio(string orders)
		{
			return ValorizaciondanioDao.GetAll(orders);
		}

		public List<Valorizaciondanio> GetAllValorizaciondanio(string conditions, string orders)
		{
			return ValorizaciondanioDao.GetAll(conditions, orders);
		}

		public Valorizaciondanio GetValorizaciondanio(int id)
		{
			return ValorizaciondanioDao.Get(id);
		}

		public Valorizaciondanio GetValorizaciondanio(Expression<Func<Valorizaciondanio, bool>> criteria)
		{
			return ValorizaciondanioDao.Get(criteria);
		}
	}
}

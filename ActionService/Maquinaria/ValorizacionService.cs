using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizacion()
		{
			return ValorizacionDao.Count();
		}

		public long CountValorizacion(Expression<Func<Valorizacion, bool>> criteria)
		{
			return ValorizacionDao.Count(criteria);
		}

		public int SaveValorizacion(Valorizacion entity)
		{
			return ValorizacionDao.Save(entity);
		}

		public void UpdateValorizacion(Valorizacion entity)
		{
			ValorizacionDao.Update(entity);
		}

		public void DeleteValorizacion(int id)
		{
			ValorizacionDao.Delete(id);
		}

		public List<Valorizacion> GetAllValorizacion()
		{
			return ValorizacionDao.GetAll();
		}

		public List<Valorizacion> GetAllValorizacion(Expression<Func<Valorizacion, bool>> criteria)
		{
			return ValorizacionDao.GetAll(criteria);
		}

		public List<Valorizacion> GetAllValorizacion(string orders)
		{
			return ValorizacionDao.GetAll(orders);
		}

		public List<Valorizacion> GetAllValorizacion(string conditions, string orders)
		{
			return ValorizacionDao.GetAll(conditions, orders);
		}

		public Valorizacion GetValorizacion(int id)
		{
			return ValorizacionDao.Get(id);
		}

		public Valorizacion GetValorizacion(Expression<Func<Valorizacion, bool>> criteria)
		{
			return ValorizacionDao.Get(criteria);
		}
	}
}

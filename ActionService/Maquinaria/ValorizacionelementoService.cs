using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizacionelemento()
		{
			return ValorizacionelementoDao.Count();
		}

		public long CountValorizacionelemento(Expression<Func<Valorizacionelemento, bool>> criteria)
		{
			return ValorizacionelementoDao.Count(criteria);
		}

		public int SaveValorizacionelemento(Valorizacionelemento entity)
		{
			return ValorizacionelementoDao.Save(entity);
		}

		public void UpdateValorizacionelemento(Valorizacionelemento entity)
		{
			ValorizacionelementoDao.Update(entity);
		}

		public void DeleteValorizacionelemento(int id)
		{
			ValorizacionelementoDao.Delete(id);
		}

		public List<Valorizacionelemento> GetAllValorizacionelemento()
		{
			return ValorizacionelementoDao.GetAll();
		}

		public List<Valorizacionelemento> GetAllValorizacionelemento(Expression<Func<Valorizacionelemento, bool>> criteria)
		{
			return ValorizacionelementoDao.GetAll(criteria);
		}

		public List<Valorizacionelemento> GetAllValorizacionelemento(string orders)
		{
			return ValorizacionelementoDao.GetAll(orders);
		}

		public List<Valorizacionelemento> GetAllValorizacionelemento(string conditions, string orders)
		{
			return ValorizacionelementoDao.GetAll(conditions, orders);
		}

		public Valorizacionelemento GetValorizacionelemento(int id)
		{
			return ValorizacionelementoDao.Get(id);
		}

		public Valorizacionelemento GetValorizacionelemento(Expression<Func<Valorizacionelemento, bool>> criteria)
		{
			return ValorizacionelementoDao.Get(criteria);
		}
	}
}

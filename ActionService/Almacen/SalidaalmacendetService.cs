using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSalidaalmacendet()
		{
			return SalidaalmacendetDao.Count();
		}

		public long CountSalidaalmacendet(Expression<Func<Salidaalmacendet, bool>> criteria)
		{
			return SalidaalmacendetDao.Count(criteria);
		}

		public int SaveSalidaalmacendet(Salidaalmacendet entity)
		{
			return SalidaalmacendetDao.Save(entity);
		}

		public void UpdateSalidaalmacendet(Salidaalmacendet entity)
		{
			SalidaalmacendetDao.Update(entity);
		}

		public void DeleteSalidaalmacendet(int id)
		{
			SalidaalmacendetDao.Delete(id);
		}

		public List<Salidaalmacendet> GetAllSalidaalmacendet()
		{
			return SalidaalmacendetDao.GetAll();
		}

		public List<Salidaalmacendet> GetAllSalidaalmacendet(Expression<Func<Salidaalmacendet, bool>> criteria)
		{
			return SalidaalmacendetDao.GetAll(criteria);
		}

		public List<Salidaalmacendet> GetAllSalidaalmacendet(string orders)
		{
			return SalidaalmacendetDao.GetAll(orders);
		}

		public List<Salidaalmacendet> GetAllSalidaalmacendet(string conditions, string orders)
		{
			return SalidaalmacendetDao.GetAll(conditions, orders);
		}

		public Salidaalmacendet GetSalidaalmacendet(int id)
		{
			return SalidaalmacendetDao.Get(id);
		}

		public Salidaalmacendet GetSalidaalmacendet(Expression<Func<Salidaalmacendet, bool>> criteria)
		{
			return SalidaalmacendetDao.Get(criteria);
		}
	}
}

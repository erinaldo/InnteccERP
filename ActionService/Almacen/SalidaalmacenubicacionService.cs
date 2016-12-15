using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSalidaalmacenubicacion()
		{
			return SalidaalmacenubicacionDao.Count();
		}

		public long CountSalidaalmacenubicacion(Expression<Func<Salidaalmacenubicacion, bool>> criteria)
		{
			return SalidaalmacenubicacionDao.Count(criteria);
		}

		public int SaveSalidaalmacenubicacion(Salidaalmacenubicacion entity)
		{
			return SalidaalmacenubicacionDao.Save(entity);
		}

		public void UpdateSalidaalmacenubicacion(Salidaalmacenubicacion entity)
		{
			SalidaalmacenubicacionDao.Update(entity);
		}

		public void DeleteSalidaalmacenubicacion(int id)
		{
			SalidaalmacenubicacionDao.Delete(id);
		}

		public List<Salidaalmacenubicacion> GetAllSalidaalmacenubicacion()
		{
			return SalidaalmacenubicacionDao.GetAll();
		}

		public List<Salidaalmacenubicacion> GetAllSalidaalmacenubicacion(Expression<Func<Salidaalmacenubicacion, bool>> criteria)
		{
			return SalidaalmacenubicacionDao.GetAll(criteria);
		}

		public List<Salidaalmacenubicacion> GetAllSalidaalmacenubicacion(string orders)
		{
			return SalidaalmacenubicacionDao.GetAll(orders);
		}

		public List<Salidaalmacenubicacion> GetAllSalidaalmacenubicacion(string conditions, string orders)
		{
			return SalidaalmacenubicacionDao.GetAll(conditions, orders);
		}

		public Salidaalmacenubicacion GetSalidaalmacenubicacion(int id)
		{
			return SalidaalmacenubicacionDao.Get(id);
		}

		public Salidaalmacenubicacion GetSalidaalmacenubicacion(Expression<Func<Salidaalmacenubicacion, bool>> criteria)
		{
			return SalidaalmacenubicacionDao.Get(criteria);
		}
	}
}

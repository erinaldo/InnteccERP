using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountUbicacion()
		{
			return UbicacionDao.Count();
		}

		public long CountUbicacion(Expression<Func<Ubicacion, bool>> criteria)
		{
			return UbicacionDao.Count(criteria);
		}

		public int SaveUbicacion(Ubicacion entity)
		{
			return UbicacionDao.Save(entity);
		}

		public void UpdateUbicacion(Ubicacion entity)
		{
			UbicacionDao.Update(entity);
		}

		public void DeleteUbicacion(int id)
		{
			UbicacionDao.Delete(id);
		}

		public List<Ubicacion> GetAllUbicacion()
		{
			return UbicacionDao.GetAll();
		}

		public List<Ubicacion> GetAllUbicacion(Expression<Func<Ubicacion, bool>> criteria)
		{
			return UbicacionDao.GetAll(criteria);
		}

		public List<Ubicacion> GetAllUbicacion(string orders)
		{
			return UbicacionDao.GetAll(orders);
		}

		public List<Ubicacion> GetAllUbicacion(string conditions, string orders)
		{
			return UbicacionDao.GetAll(conditions, orders);
		}

		public Ubicacion GetUbicacion(int id)
		{
			return UbicacionDao.Get(id);
		}

		public Ubicacion GetUbicacion(Expression<Func<Ubicacion, bool>> criteria)
		{
			return UbicacionDao.Get(criteria);
		}
	}
}

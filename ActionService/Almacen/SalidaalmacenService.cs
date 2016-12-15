using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSalidaalmacen()
		{
			return SalidaalmacenDao.Count();
		}

		public long CountSalidaalmacen(Expression<Func<Salidaalmacen, bool>> criteria)
		{
			return SalidaalmacenDao.Count(criteria);
		}

		public int SaveSalidaalmacen(Salidaalmacen entity)
		{
			return SalidaalmacenDao.Save(entity);
		}

		public void UpdateSalidaalmacen(Salidaalmacen entity)
		{
			SalidaalmacenDao.Update(entity);
		}

		public void DeleteSalidaalmacen(int id)
		{
			SalidaalmacenDao.Delete(id);
		}

		public List<Salidaalmacen> GetAllSalidaalmacen()
		{
			return SalidaalmacenDao.GetAll();
		}

		public List<Salidaalmacen> GetAllSalidaalmacen(Expression<Func<Salidaalmacen, bool>> criteria)
		{
			return SalidaalmacenDao.GetAll(criteria);
		}

		public List<Salidaalmacen> GetAllSalidaalmacen(string orders)
		{
			return SalidaalmacenDao.GetAll(orders);
		}

		public List<Salidaalmacen> GetAllSalidaalmacen(string conditions, string orders)
		{
			return SalidaalmacenDao.GetAll(conditions, orders);
		}

		public Salidaalmacen GetSalidaalmacen(int id)
		{
			return SalidaalmacenDao.Get(id);
		}

		public Salidaalmacen GetSalidaalmacen(Expression<Func<Salidaalmacen, bool>> criteria)
		{
			return SalidaalmacenDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountMantenimientoimagen()
		{
			return MantenimientoimagenDao.Count();
		}

		public long CountMantenimientoimagen(Expression<Func<Mantenimientoimagen, bool>> criteria)
		{
			return MantenimientoimagenDao.Count(criteria);
		}

		public int SaveMantenimientoimagen(Mantenimientoimagen entity)
		{
			return MantenimientoimagenDao.Save(entity);
		}

		public void UpdateMantenimientoimagen(Mantenimientoimagen entity)
		{
			MantenimientoimagenDao.Update(entity);
		}

		public void DeleteMantenimientoimagen(int id)
		{
			MantenimientoimagenDao.Delete(id);
		}

		public List<Mantenimientoimagen> GetAllMantenimientoimagen()
		{
			return MantenimientoimagenDao.GetAll();
		}

		public List<Mantenimientoimagen> GetAllMantenimientoimagen(Expression<Func<Mantenimientoimagen, bool>> criteria)
		{
			return MantenimientoimagenDao.GetAll(criteria);
		}

		public List<Mantenimientoimagen> GetAllMantenimientoimagen(string orders)
		{
			return MantenimientoimagenDao.GetAll(orders);
		}

		public List<Mantenimientoimagen> GetAllMantenimientoimagen(string conditions, string orders)
		{
			return MantenimientoimagenDao.GetAll(conditions, orders);
		}

		public Mantenimientoimagen GetMantenimientoimagen(int id)
		{
			return MantenimientoimagenDao.Get(id);
		}

		public Mantenimientoimagen GetMantenimientoimagen(Expression<Func<Mantenimientoimagen, bool>> criteria)
		{
			return MantenimientoimagenDao.Get(criteria);
		}
	}
}

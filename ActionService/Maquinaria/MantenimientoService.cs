using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountMantenimiento()
		{
			return MantenimientoDao.Count();
		}

		public long CountMantenimiento(Expression<Func<Mantenimiento, bool>> criteria)
		{
			return MantenimientoDao.Count(criteria);
		}

		public int SaveMantenimiento(Mantenimiento entity)
		{
			return MantenimientoDao.Save(entity);
		}

		public void UpdateMantenimiento(Mantenimiento entity)
		{
			MantenimientoDao.Update(entity);
		}

		public void DeleteMantenimiento(int id)
		{
			MantenimientoDao.Delete(id);
		}

		public List<Mantenimiento> GetAllMantenimiento()
		{
			return MantenimientoDao.GetAll();
		}

		public List<Mantenimiento> GetAllMantenimiento(Expression<Func<Mantenimiento, bool>> criteria)
		{
			return MantenimientoDao.GetAll(criteria);
		}

		public List<Mantenimiento> GetAllMantenimiento(string orders)
		{
			return MantenimientoDao.GetAll(orders);
		}

		public List<Mantenimiento> GetAllMantenimiento(string conditions, string orders)
		{
			return MantenimientoDao.GetAll(conditions, orders);
		}

		public Mantenimiento GetMantenimiento(int id)
		{
			return MantenimientoDao.Get(id);
		}

		public Mantenimiento GetMantenimiento(Expression<Func<Mantenimiento, bool>> criteria)
		{
			return MantenimientoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEmpleadoareaproyecto()
		{
			return EmpleadoareaproyectoDao.Count();
		}

		public long CountEmpleadoareaproyecto(Expression<Func<Empleadoareaproyecto, bool>> criteria)
		{
			return EmpleadoareaproyectoDao.Count(criteria);
		}

		public int SaveEmpleadoareaproyecto(Empleadoareaproyecto entity)
		{
			return EmpleadoareaproyectoDao.Save(entity);
		}

		public void UpdateEmpleadoareaproyecto(Empleadoareaproyecto entity)
		{
			EmpleadoareaproyectoDao.Update(entity);
		}

		public void DeleteEmpleadoareaproyecto(int id)
		{
			EmpleadoareaproyectoDao.Delete(id);
		}

		public List<Empleadoareaproyecto> GetAllEmpleadoareaproyecto()
		{
			return EmpleadoareaproyectoDao.GetAll();
		}

		public List<Empleadoareaproyecto> GetAllEmpleadoareaproyecto(Expression<Func<Empleadoareaproyecto, bool>> criteria)
		{
			return EmpleadoareaproyectoDao.GetAll(criteria);
		}

		public List<Empleadoareaproyecto> GetAllEmpleadoareaproyecto(string orders)
		{
			return EmpleadoareaproyectoDao.GetAll(orders);
		}

		public List<Empleadoareaproyecto> GetAllEmpleadoareaproyecto(string conditions, string orders)
		{
			return EmpleadoareaproyectoDao.GetAll(conditions, orders);
		}

		public Empleadoareaproyecto GetEmpleadoareaproyecto(int id)
		{
			return EmpleadoareaproyectoDao.Get(id);
		}

		public Empleadoareaproyecto GetEmpleadoareaproyecto(Expression<Func<Empleadoareaproyecto, bool>> criteria)
		{
			return EmpleadoareaproyectoDao.Get(criteria);
		}
	}
}

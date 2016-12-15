using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEmpleado()
		{
			return EmpleadoDao.Count();
		}

		public long CountEmpleado(Expression<Func<Empleado, bool>> criteria)
		{
			return EmpleadoDao.Count(criteria);
		}

		public int SaveEmpleado(Empleado entity)
		{
			return EmpleadoDao.Save(entity);
		}

		public void UpdateEmpleado(Empleado entity)
		{
			EmpleadoDao.Update(entity);
		}

		public void DeleteEmpleado(int id)
		{
			EmpleadoDao.Delete(id);
		}

		public List<Empleado> GetAllEmpleado()
		{
			return EmpleadoDao.GetAll();
		}

		public List<Empleado> GetAllEmpleado(Expression<Func<Empleado, bool>> criteria)
		{
			return EmpleadoDao.GetAll(criteria);
		}

		public List<Empleado> GetAllEmpleado(string orders)
		{
			return EmpleadoDao.GetAll(orders);
		}

		public List<Empleado> GetAllEmpleado(string conditions, string orders)
		{
			return EmpleadoDao.GetAll(conditions, orders);
		}

		public Empleado GetEmpleado(int id)
		{
			return EmpleadoDao.Get(id);
		}

		public Empleado GetEmpleado(Expression<Func<Empleado, bool>> criteria)
		{
			return EmpleadoDao.Get(criteria);
		}
	}
}

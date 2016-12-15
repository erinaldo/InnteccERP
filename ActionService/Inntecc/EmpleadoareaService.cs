using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEmpleadoarea()
		{
			return EmpleadoareaDao.Count();
		}

		public long CountEmpleadoarea(Expression<Func<Empleadoarea, bool>> criteria)
		{
			return EmpleadoareaDao.Count(criteria);
		}

		public int SaveEmpleadoarea(Empleadoarea entity)
		{
			return EmpleadoareaDao.Save(entity);
		}

		public void UpdateEmpleadoarea(Empleadoarea entity)
		{
			EmpleadoareaDao.Update(entity);
		}

		public void DeleteEmpleadoarea(int id)
		{
			EmpleadoareaDao.Delete(id);
		}

		public List<Empleadoarea> GetAllEmpleadoarea()
		{
			return EmpleadoareaDao.GetAll();
		}

		public List<Empleadoarea> GetAllEmpleadoarea(Expression<Func<Empleadoarea, bool>> criteria)
		{
			return EmpleadoareaDao.GetAll(criteria);
		}

		public List<Empleadoarea> GetAllEmpleadoarea(string orders)
		{
			return EmpleadoareaDao.GetAll(orders);
		}

		public List<Empleadoarea> GetAllEmpleadoarea(string conditions, string orders)
		{
			return EmpleadoareaDao.GetAll(conditions, orders);
		}

		public Empleadoarea GetEmpleadoarea(int id)
		{
			return EmpleadoareaDao.Get(id);
		}

		public Empleadoarea GetEmpleadoarea(Expression<Func<Empleadoarea, bool>> criteria)
		{
			return EmpleadoareaDao.Get(criteria);
		}
	}
}

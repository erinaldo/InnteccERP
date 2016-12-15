using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEmpleadoanexo()
		{
			return EmpleadoanexoDao.Count();
		}

		public long CountEmpleadoanexo(Expression<Func<Empleadoanexo, bool>> criteria)
		{
			return EmpleadoanexoDao.Count(criteria);
		}

		public int SaveEmpleadoanexo(Empleadoanexo entity)
		{
			return EmpleadoanexoDao.Save(entity);
		}

		public void UpdateEmpleadoanexo(Empleadoanexo entity)
		{
			EmpleadoanexoDao.Update(entity);
		}

		public void DeleteEmpleadoanexo(int id)
		{
			EmpleadoanexoDao.Delete(id);
		}

		public List<Empleadoanexo> GetAllEmpleadoanexo()
		{
			return EmpleadoanexoDao.GetAll();
		}

		public List<Empleadoanexo> GetAllEmpleadoanexo(Expression<Func<Empleadoanexo, bool>> criteria)
		{
			return EmpleadoanexoDao.GetAll(criteria);
		}

		public List<Empleadoanexo> GetAllEmpleadoanexo(string orders)
		{
			return EmpleadoanexoDao.GetAll(orders);
		}

		public List<Empleadoanexo> GetAllEmpleadoanexo(string conditions, string orders)
		{
			return EmpleadoanexoDao.GetAll(conditions, orders);
		}

		public Empleadoanexo GetEmpleadoanexo(int id)
		{
			return EmpleadoanexoDao.Get(id);
		}

		public Empleadoanexo GetEmpleadoanexo(Expression<Func<Empleadoanexo, bool>> criteria)
		{
			return EmpleadoanexoDao.Get(criteria);
		}
	}
}

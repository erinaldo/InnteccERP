using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEmpleadoareaproyecto()
		{
			return VwEmpleadoareaproyectoDao.Count();
		}

		public long CountVwEmpleadoareaproyecto(Expression<Func<VwEmpleadoareaproyecto, bool>> criteria)
		{
			return VwEmpleadoareaproyectoDao.Count(criteria);
		}

		public List<VwEmpleadoareaproyecto> GetAllVwEmpleadoareaproyecto()
		{
			return VwEmpleadoareaproyectoDao.GetAll();
		}

		public List<VwEmpleadoareaproyecto> GetAllVwEmpleadoareaproyecto(Expression<Func<VwEmpleadoareaproyecto, bool>> criteria)
		{
			return VwEmpleadoareaproyectoDao.GetAll(criteria);
		}

		public List<VwEmpleadoareaproyecto> GetAllVwEmpleadoareaproyecto(string orders)
		{
			return VwEmpleadoareaproyectoDao.GetAll(orders);
		}

		public List<VwEmpleadoareaproyecto> GetAllVwEmpleadoareaproyecto(string conditions, string orders)
		{
			return VwEmpleadoareaproyectoDao.GetAll(conditions, orders);
		}

		public VwEmpleadoareaproyecto GetVwEmpleadoareaproyecto(int id)
		{
			return VwEmpleadoareaproyectoDao.Get(id);
		}

		public VwEmpleadoareaproyecto GetVwEmpleadoareaproyecto(Expression<Func<VwEmpleadoareaproyecto, bool>> criteria)
		{
			return VwEmpleadoareaproyectoDao.Get(criteria);
		}
	}
}

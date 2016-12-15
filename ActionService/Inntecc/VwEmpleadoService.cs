using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEmpleado()
		{
			return VwEmpleadoDao.Count();
		}

		public long CountVwEmpleado(Expression<Func<VwEmpleado, bool>> criteria)
		{
			return VwEmpleadoDao.Count(criteria);
		}

		public List<VwEmpleado> GetAllVwEmpleado()
		{
			return VwEmpleadoDao.GetAll();
		}

		public List<VwEmpleado> GetAllVwEmpleado(Expression<Func<VwEmpleado, bool>> criteria)
		{
			return VwEmpleadoDao.GetAll(criteria);
		}

		public List<VwEmpleado> GetAllVwEmpleado(string orders)
		{
			return VwEmpleadoDao.GetAll(orders);
		}

		public List<VwEmpleado> GetAllVwEmpleado(string conditions, string orders)
		{
			return VwEmpleadoDao.GetAll(conditions, orders);
		}

		public VwEmpleado GetVwEmpleado(int id)
		{
			return VwEmpleadoDao.Get(id);
		}

		public VwEmpleado GetVwEmpleado(Expression<Func<VwEmpleado, bool>> criteria)
		{
			return VwEmpleadoDao.Get(criteria);
		}
	}
}

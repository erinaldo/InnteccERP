using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEmpleadoarea()
		{
			return VwEmpleadoareaDao.Count();
		}

		public long CountVwEmpleadoarea(Expression<Func<VwEmpleadoarea, bool>> criteria)
		{
			return VwEmpleadoareaDao.Count(criteria);
		}

		public List<VwEmpleadoarea> GetAllVwEmpleadoarea()
		{
			return VwEmpleadoareaDao.GetAll();
		}

		public List<VwEmpleadoarea> GetAllVwEmpleadoarea(Expression<Func<VwEmpleadoarea, bool>> criteria)
		{
			return VwEmpleadoareaDao.GetAll(criteria);
		}

		public List<VwEmpleadoarea> GetAllVwEmpleadoarea(string orders)
		{
			return VwEmpleadoareaDao.GetAll(orders);
		}

		public List<VwEmpleadoarea> GetAllVwEmpleadoarea(string conditions, string orders)
		{
			return VwEmpleadoareaDao.GetAll(conditions, orders);
		}

		public VwEmpleadoarea GetVwEmpleadoarea(int id)
		{
			return VwEmpleadoareaDao.Get(id);
		}

		public VwEmpleadoarea GetVwEmpleadoarea(Expression<Func<VwEmpleadoarea, bool>> criteria)
		{
			return VwEmpleadoareaDao.Get(criteria);
		}
	}
}

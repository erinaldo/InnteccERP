using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRequerimiento()
		{
			return VwRequerimientoDao.Count();
		}

		public long CountVwRequerimiento(Expression<Func<VwRequerimiento, bool>> criteria)
		{
			return VwRequerimientoDao.Count(criteria);
		}

		public List<VwRequerimiento> GetAllVwRequerimiento()
		{
			return VwRequerimientoDao.GetAll();
		}

		public List<VwRequerimiento> GetAllVwRequerimiento(Expression<Func<VwRequerimiento, bool>> criteria)
		{
			return VwRequerimientoDao.GetAll(criteria);
		}

		public List<VwRequerimiento> GetAllVwRequerimiento(string orders)
		{
			return VwRequerimientoDao.GetAll(orders);
		}

		public List<VwRequerimiento> GetAllVwRequerimiento(string conditions, string orders)
		{
			return VwRequerimientoDao.GetAll(conditions, orders);
		}

		public VwRequerimiento GetVwRequerimiento(int id)
		{
			return VwRequerimientoDao.Get(id);
		}

		public VwRequerimiento GetVwRequerimiento(Expression<Func<VwRequerimiento, bool>> criteria)
		{
			return VwRequerimientoDao.Get(criteria);
		}
	}
}

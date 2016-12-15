using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCptooperacion()
		{
			return VwCptooperacionDao.Count();
		}

		public long CountVwCptooperacion(Expression<Func<VwCptooperacion, bool>> criteria)
		{
			return VwCptooperacionDao.Count(criteria);
		}

		public List<VwCptooperacion> GetAllVwCptooperacion()
		{
			return VwCptooperacionDao.GetAll();
		}

		public List<VwCptooperacion> GetAllVwCptooperacion(Expression<Func<VwCptooperacion, bool>> criteria)
		{
			return VwCptooperacionDao.GetAll(criteria);
		}

		public List<VwCptooperacion> GetAllVwCptooperacion(string orders)
		{
			return VwCptooperacionDao.GetAll(orders);
		}

		public List<VwCptooperacion> GetAllVwCptooperacion(string conditions, string orders)
		{
			return VwCptooperacionDao.GetAll(conditions, orders);
		}

		public VwCptooperacion GetVwCptooperacion(int id)
		{
			return VwCptooperacionDao.Get(id);
		}

		public VwCptooperacion GetVwCptooperacion(Expression<Func<VwCptooperacion, bool>> criteria)
		{
			return VwCptooperacionDao.Get(criteria);
		}
	}
}

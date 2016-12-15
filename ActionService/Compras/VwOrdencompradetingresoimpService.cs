using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdencompradetingresoimp()
		{
			return VwOrdencompradetingresoimpDao.Count();
		}

		public long CountVwOrdencompradetingresoimp(Expression<Func<VwOrdencompradetingresoimp, bool>> criteria)
		{
			return VwOrdencompradetingresoimpDao.Count(criteria);
		}

		public List<VwOrdencompradetingresoimp> GetAllVwOrdencompradetingresoimp()
		{
			return VwOrdencompradetingresoimpDao.GetAll();
		}

		public List<VwOrdencompradetingresoimp> GetAllVwOrdencompradetingresoimp(Expression<Func<VwOrdencompradetingresoimp, bool>> criteria)
		{
			return VwOrdencompradetingresoimpDao.GetAll(criteria);
		}

		public List<VwOrdencompradetingresoimp> GetAllVwOrdencompradetingresoimp(string orders)
		{
			return VwOrdencompradetingresoimpDao.GetAll(orders);
		}

		public List<VwOrdencompradetingresoimp> GetAllVwOrdencompradetingresoimp(string conditions, string orders)
		{
			return VwOrdencompradetingresoimpDao.GetAll(conditions, orders);
		}

		public VwOrdencompradetingresoimp GetVwOrdencompradetingresoimp(int id)
		{
			return VwOrdencompradetingresoimpDao.Get(id);
		}

		public VwOrdencompradetingresoimp GetVwOrdencompradetingresoimp(Expression<Func<VwOrdencompradetingresoimp, bool>> criteria)
		{
			return VwOrdencompradetingresoimpDao.Get(criteria);
		}
	}
}

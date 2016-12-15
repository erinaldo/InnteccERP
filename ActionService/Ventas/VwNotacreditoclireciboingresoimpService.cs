using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwNotacreditoclireciboingresoimp()
		{
			return VwNotacreditoclireciboingresoimpDao.Count();
		}

		public long CountVwNotacreditoclireciboingresoimp(Expression<Func<VwNotacreditoclireciboingresoimp, bool>> criteria)
		{
			return VwNotacreditoclireciboingresoimpDao.Count(criteria);
		}

		public List<VwNotacreditoclireciboingresoimp> GetAllVwNotacreditoclireciboingresoimp()
		{
			return VwNotacreditoclireciboingresoimpDao.GetAll();
		}

		public List<VwNotacreditoclireciboingresoimp> GetAllVwNotacreditoclireciboingresoimp(Expression<Func<VwNotacreditoclireciboingresoimp, bool>> criteria)
		{
			return VwNotacreditoclireciboingresoimpDao.GetAll(criteria);
		}

		public List<VwNotacreditoclireciboingresoimp> GetAllVwNotacreditoclireciboingresoimp(string orders)
		{
			return VwNotacreditoclireciboingresoimpDao.GetAll(orders);
		}

		public List<VwNotacreditoclireciboingresoimp> GetAllVwNotacreditoclireciboingresoimp(string conditions, string orders)
		{
			return VwNotacreditoclireciboingresoimpDao.GetAll(conditions, orders);
		}

		public VwNotacreditoclireciboingresoimp GetVwNotacreditoclireciboingresoimp(int id)
		{
			return VwNotacreditoclireciboingresoimpDao.Get(id);
		}

		public VwNotacreditoclireciboingresoimp GetVwNotacreditoclireciboingresoimp(Expression<Func<VwNotacreditoclireciboingresoimp, bool>> criteria)
		{
			return VwNotacreditoclireciboingresoimpDao.Get(criteria);
		}
	}
}

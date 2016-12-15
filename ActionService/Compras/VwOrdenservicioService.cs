using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdenservicio()
		{
			return VwOrdenservicioDao.Count();
		}

		public long CountVwOrdenservicio(Expression<Func<VwOrdenservicio, bool>> criteria)
		{
			return VwOrdenservicioDao.Count(criteria);
		}

		public List<VwOrdenservicio> GetAllVwOrdenservicio()
		{
			return VwOrdenservicioDao.GetAll();
		}

		public List<VwOrdenservicio> GetAllVwOrdenservicio(Expression<Func<VwOrdenservicio, bool>> criteria)
		{
			return VwOrdenservicioDao.GetAll(criteria);
		}

		public List<VwOrdenservicio> GetAllVwOrdenservicio(string orders)
		{
			return VwOrdenservicioDao.GetAll(orders);
		}

		public List<VwOrdenservicio> GetAllVwOrdenservicio(string conditions, string orders)
		{
			return VwOrdenservicioDao.GetAll(conditions, orders);
		}

		public VwOrdenservicio GetVwOrdenservicio(int id)
		{
			return VwOrdenservicioDao.Get(id);
		}

		public VwOrdenservicio GetVwOrdenservicio(Expression<Func<VwOrdenservicio, bool>> criteria)
		{
			return VwOrdenservicioDao.Get(criteria);
		}
	}
}

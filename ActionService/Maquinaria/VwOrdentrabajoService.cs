using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdentrabajo()
		{
			return VwOrdentrabajoDao.Count();
		}

		public long CountVwOrdentrabajo(Expression<Func<VwOrdentrabajo, bool>> criteria)
		{
			return VwOrdentrabajoDao.Count(criteria);
		}

		public List<VwOrdentrabajo> GetAllVwOrdentrabajo()
		{
			return VwOrdentrabajoDao.GetAll();
		}

		public List<VwOrdentrabajo> GetAllVwOrdentrabajo(Expression<Func<VwOrdentrabajo, bool>> criteria)
		{
			return VwOrdentrabajoDao.GetAll(criteria);
		}

		public List<VwOrdentrabajo> GetAllVwOrdentrabajo(string orders)
		{
			return VwOrdentrabajoDao.GetAll(orders);
		}

		public List<VwOrdentrabajo> GetAllVwOrdentrabajo(string conditions, string orders)
		{
			return VwOrdentrabajoDao.GetAll(conditions, orders);
		}

		public VwOrdentrabajo GetVwOrdentrabajo(int id)
		{
			return VwOrdentrabajoDao.Get(id);
		}

		public VwOrdentrabajo GetVwOrdentrabajo(Expression<Func<VwOrdentrabajo, bool>> criteria)
		{
			return VwOrdentrabajoDao.Get(criteria);
		}
	}
}

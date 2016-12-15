using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCotizacionclientedet()
		{
			return VwCotizacionclientedetDao.Count();
		}

		public long CountVwCotizacionclientedet(Expression<Func<VwCotizacionclientedet, bool>> criteria)
		{
			return VwCotizacionclientedetDao.Count(criteria);
		}

		public List<VwCotizacionclientedet> GetAllVwCotizacionclientedet()
		{
			return VwCotizacionclientedetDao.GetAll();
		}

		public List<VwCotizacionclientedet> GetAllVwCotizacionclientedet(Expression<Func<VwCotizacionclientedet, bool>> criteria)
		{
			return VwCotizacionclientedetDao.GetAll(criteria);
		}

		public List<VwCotizacionclientedet> GetAllVwCotizacionclientedet(string orders)
		{
			return VwCotizacionclientedetDao.GetAll(orders);
		}

		public List<VwCotizacionclientedet> GetAllVwCotizacionclientedet(string conditions, string orders)
		{
			return VwCotizacionclientedetDao.GetAll(conditions, orders);
		}

		public VwCotizacionclientedet GetVwCotizacionclientedet(int id)
		{
			return VwCotizacionclientedetDao.Get(id);
		}

		public VwCotizacionclientedet GetVwCotizacionclientedet(Expression<Func<VwCotizacionclientedet, bool>> criteria)
		{
			return VwCotizacionclientedetDao.Get(criteria);
		}
	}
}

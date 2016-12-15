using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCotizacioncliente()
		{
			return VwCotizacionclienteDao.Count();
		}

		public long CountVwCotizacioncliente(Expression<Func<VwCotizacioncliente, bool>> criteria)
		{
			return VwCotizacionclienteDao.Count(criteria);
		}

		public List<VwCotizacioncliente> GetAllVwCotizacioncliente()
		{
			return VwCotizacionclienteDao.GetAll();
		}

		public List<VwCotizacioncliente> GetAllVwCotizacioncliente(Expression<Func<VwCotizacioncliente, bool>> criteria)
		{
			return VwCotizacionclienteDao.GetAll(criteria);
		}

		public List<VwCotizacioncliente> GetAllVwCotizacioncliente(string orders)
		{
			return VwCotizacionclienteDao.GetAll(orders);
		}

		public List<VwCotizacioncliente> GetAllVwCotizacioncliente(string conditions, string orders)
		{
			return VwCotizacionclienteDao.GetAll(conditions, orders);
		}

		public VwCotizacioncliente GetVwCotizacioncliente(int id)
		{
			return VwCotizacionclienteDao.Get(id);
		}

		public VwCotizacioncliente GetVwCotizacioncliente(Expression<Func<VwCotizacioncliente, bool>> criteria)
		{
			return VwCotizacionclienteDao.Get(criteria);
		}
	}
}

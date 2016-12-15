using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCotizacionclientedetovimp()
		{
			return VwCotizacionclientedetovimpDao.Count();
		}

		public long CountVwCotizacionclientedetovimp(Expression<Func<VwCotizacionclientedetovimp, bool>> criteria)
		{
			return VwCotizacionclientedetovimpDao.Count(criteria);
		}

		public List<VwCotizacionclientedetovimp> GetAllVwCotizacionclientedetovimp()
		{
			return VwCotizacionclientedetovimpDao.GetAll();
		}

		public List<VwCotizacionclientedetovimp> GetAllVwCotizacionclientedetovimp(Expression<Func<VwCotizacionclientedetovimp, bool>> criteria)
		{
			return VwCotizacionclientedetovimpDao.GetAll(criteria);
		}

		public List<VwCotizacionclientedetovimp> GetAllVwCotizacionclientedetovimp(string orders)
		{
			return VwCotizacionclientedetovimpDao.GetAll(orders);
		}

		public List<VwCotizacionclientedetovimp> GetAllVwCotizacionclientedetovimp(string conditions, string orders)
		{
			return VwCotizacionclientedetovimpDao.GetAll(conditions, orders);
		}

		public VwCotizacionclientedetovimp GetVwCotizacionclientedetovimp(int id)
		{
			return VwCotizacionclientedetovimpDao.Get(id);
		}

		public VwCotizacionclientedetovimp GetVwCotizacionclientedetovimp(Expression<Func<VwCotizacionclientedetovimp, bool>> criteria)
		{
			return VwCotizacionclientedetovimpDao.Get(criteria);
		}
	}
}

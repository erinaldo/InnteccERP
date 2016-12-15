using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCotizacionprvdet()
		{
			return VwCotizacionprvdetDao.Count();
		}

		public long CountVwCotizacionprvdet(Expression<Func<VwCotizacionprvdet, bool>> criteria)
		{
			return VwCotizacionprvdetDao.Count(criteria);
		}

		public List<VwCotizacionprvdet> GetAllVwCotizacionprvdet()
		{
			return VwCotizacionprvdetDao.GetAll();
		}

		public List<VwCotizacionprvdet> GetAllVwCotizacionprvdet(Expression<Func<VwCotizacionprvdet, bool>> criteria)
		{
			return VwCotizacionprvdetDao.GetAll(criteria);
		}

		public List<VwCotizacionprvdet> GetAllVwCotizacionprvdet(string orders)
		{
			return VwCotizacionprvdetDao.GetAll(orders);
		}

		public List<VwCotizacionprvdet> GetAllVwCotizacionprvdet(string conditions, string orders)
		{
			return VwCotizacionprvdetDao.GetAll(conditions, orders);
		}

		public VwCotizacionprvdet GetVwCotizacionprvdet(int id)
		{
			return VwCotizacionprvdetDao.Get(id);
		}

		public VwCotizacionprvdet GetVwCotizacionprvdet(Expression<Func<VwCotizacionprvdet, bool>> criteria)
		{
			return VwCotizacionprvdetDao.Get(criteria);
		}
	}
}

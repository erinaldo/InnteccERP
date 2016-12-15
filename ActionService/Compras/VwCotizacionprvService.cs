using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCotizacionprv()
		{
			return VwCotizacionprvDao.Count();
		}

		public long CountVwCotizacionprv(Expression<Func<VwCotizacionprv, bool>> criteria)
		{
			return VwCotizacionprvDao.Count(criteria);
		}

		public List<VwCotizacionprv> GetAllVwCotizacionprv()
		{
			return VwCotizacionprvDao.GetAll();
		}

		public List<VwCotizacionprv> GetAllVwCotizacionprv(Expression<Func<VwCotizacionprv, bool>> criteria)
		{
			return VwCotizacionprvDao.GetAll(criteria);
		}

		public List<VwCotizacionprv> GetAllVwCotizacionprv(string orders)
		{
			return VwCotizacionprvDao.GetAll(orders);
		}

		public List<VwCotizacionprv> GetAllVwCotizacionprv(string conditions, string orders)
		{
			return VwCotizacionprvDao.GetAll(conditions, orders);
		}

		public VwCotizacionprv GetVwCotizacionprv(int id)
		{
			return VwCotizacionprvDao.Get(id);
		}

		public VwCotizacionprv GetVwCotizacionprv(Expression<Func<VwCotizacionprv, bool>> criteria)
		{
			return VwCotizacionprvDao.Get(criteria);
		}
	}
}

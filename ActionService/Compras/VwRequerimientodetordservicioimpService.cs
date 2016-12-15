using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRequerimientodetordservicioimp()
		{
			return VwRequerimientodetordservicioimpDao.Count();
		}

		public long CountVwRequerimientodetordservicioimp(Expression<Func<VwRequerimientodetordservicioimp, bool>> criteria)
		{
			return VwRequerimientodetordservicioimpDao.Count(criteria);
		}

		public List<VwRequerimientodetordservicioimp> GetAllVwRequerimientodetordservicioimp()
		{
			return VwRequerimientodetordservicioimpDao.GetAll();
		}

		public List<VwRequerimientodetordservicioimp> GetAllVwRequerimientodetordservicioimp(Expression<Func<VwRequerimientodetordservicioimp, bool>> criteria)
		{
			return VwRequerimientodetordservicioimpDao.GetAll(criteria);
		}

		public List<VwRequerimientodetordservicioimp> GetAllVwRequerimientodetordservicioimp(string orders)
		{
			return VwRequerimientodetordservicioimpDao.GetAll(orders);
		}

		public List<VwRequerimientodetordservicioimp> GetAllVwRequerimientodetordservicioimp(string conditions, string orders)
		{
			return VwRequerimientodetordservicioimpDao.GetAll(conditions, orders);
		}

		public VwRequerimientodetordservicioimp GetVwRequerimientodetordservicioimp(int id)
		{
			return VwRequerimientodetordservicioimpDao.Get(id);
		}

		public VwRequerimientodetordservicioimp GetVwRequerimientodetordservicioimp(Expression<Func<VwRequerimientodetordservicioimp, bool>> criteria)
		{
			return VwRequerimientodetordservicioimpDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticulodetalleunidad()
		{
			return VwArticulodetalleunidadDao.Count();
		}

		public long CountVwArticulodetalleunidad(Expression<Func<VwArticulodetalleunidad, bool>> criteria)
		{
			return VwArticulodetalleunidadDao.Count(criteria);
		}

		public List<VwArticulodetalleunidad> GetAllVwArticulodetalleunidad()
		{
			return VwArticulodetalleunidadDao.GetAll();
		}

		public List<VwArticulodetalleunidad> GetAllVwArticulodetalleunidad(Expression<Func<VwArticulodetalleunidad, bool>> criteria)
		{
			return VwArticulodetalleunidadDao.GetAll(criteria);
		}

		public List<VwArticulodetalleunidad> GetAllVwArticulodetalleunidad(string orders)
		{
			return VwArticulodetalleunidadDao.GetAll(orders);
		}

		public List<VwArticulodetalleunidad> GetAllVwArticulodetalleunidad(string conditions, string orders)
		{
			return VwArticulodetalleunidadDao.GetAll(conditions, orders);
		}

		public VwArticulodetalleunidad GetVwArticulodetalleunidad(int id)
		{
			return VwArticulodetalleunidadDao.Get(id);
		}

		public VwArticulodetalleunidad GetVwArticulodetalleunidad(Expression<Func<VwArticulodetalleunidad, bool>> criteria)
		{
			return VwArticulodetalleunidadDao.Get(criteria);
		}
	}
}

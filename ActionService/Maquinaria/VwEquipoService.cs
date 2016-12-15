using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEquipo()
		{
			return VwEquipoDao.Count();
		}

		public long CountVwEquipo(Expression<Func<VwEquipo, bool>> criteria)
		{
			return VwEquipoDao.Count(criteria);
		}

		public List<VwEquipo> GetAllVwEquipo()
		{
			return VwEquipoDao.GetAll();
		}

		public List<VwEquipo> GetAllVwEquipo(Expression<Func<VwEquipo, bool>> criteria)
		{
			return VwEquipoDao.GetAll(criteria);
		}

		public List<VwEquipo> GetAllVwEquipo(string orders)
		{
			return VwEquipoDao.GetAll(orders);
		}

		public List<VwEquipo> GetAllVwEquipo(string conditions, string orders)
		{
			return VwEquipoDao.GetAll(conditions, orders);
		}

		public VwEquipo GetVwEquipo(int id)
		{
			return VwEquipoDao.Get(id);
		}

		public VwEquipo GetVwEquipo(Expression<Func<VwEquipo, bool>> criteria)
		{
			return VwEquipoDao.Get(criteria);
		}
	}
}

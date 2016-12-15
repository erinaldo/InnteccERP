using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwResumenelementodanio()
		{
			return VwResumenelementodanioDao.Count();
		}

		public long CountVwResumenelementodanio(Expression<Func<VwResumenelementodanio, bool>> criteria)
		{
			return VwResumenelementodanioDao.Count(criteria);
		}

		public List<VwResumenelementodanio> GetAllVwResumenelementodanio()
		{
			return VwResumenelementodanioDao.GetAll();
		}

		public List<VwResumenelementodanio> GetAllVwResumenelementodanio(Expression<Func<VwResumenelementodanio, bool>> criteria)
		{
			return VwResumenelementodanioDao.GetAll(criteria);
		}

		public List<VwResumenelementodanio> GetAllVwResumenelementodanio(string orders)
		{
			return VwResumenelementodanioDao.GetAll(orders);
		}

		public List<VwResumenelementodanio> GetAllVwResumenelementodanio(string conditions, string orders)
		{
			return VwResumenelementodanioDao.GetAll(conditions, orders);
		}

		public VwResumenelementodanio GetVwResumenelementodanio(int id)
		{
			return VwResumenelementodanioDao.Get(id);
		}

		public VwResumenelementodanio GetVwResumenelementodanio(Expression<Func<VwResumenelementodanio, bool>> criteria)
		{
			return VwResumenelementodanioDao.Get(criteria);
		}
	}
}

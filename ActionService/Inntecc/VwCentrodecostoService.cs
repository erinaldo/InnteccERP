using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCentrodecosto()
		{
			return VwCentrodecostoDao.Count();
		}

		public long CountVwCentrodecosto(Expression<Func<VwCentrodecosto, bool>> criteria)
		{
			return VwCentrodecostoDao.Count(criteria);
		}

		public List<VwCentrodecosto> GetAllVwCentrodecosto()
		{
			return VwCentrodecostoDao.GetAll();
		}

		public List<VwCentrodecosto> GetAllVwCentrodecosto(Expression<Func<VwCentrodecosto, bool>> criteria)
		{
			return VwCentrodecostoDao.GetAll(criteria);
		}

		public List<VwCentrodecosto> GetAllVwCentrodecosto(string orders)
		{
			return VwCentrodecostoDao.GetAll(orders);
		}

		public List<VwCentrodecosto> GetAllVwCentrodecosto(string conditions, string orders)
		{
			return VwCentrodecostoDao.GetAll(conditions, orders);
		}

		public VwCentrodecosto GetVwCentrodecosto(int id)
		{
			return VwCentrodecostoDao.Get(id);
		}

		public VwCentrodecosto GetVwCentrodecosto(Expression<Func<VwCentrodecosto, bool>> criteria)
		{
			return VwCentrodecostoDao.Get(criteria);
		}
	}
}

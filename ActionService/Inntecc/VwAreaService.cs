using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArea()
		{
			return VwAreaDao.Count();
		}

		public long CountVwArea(Expression<Func<VwArea, bool>> criteria)
		{
			return VwAreaDao.Count(criteria);
		}

		public List<VwArea> GetAllVwArea()
		{
			return VwAreaDao.GetAll();
		}

		public List<VwArea> GetAllVwArea(Expression<Func<VwArea, bool>> criteria)
		{
			return VwAreaDao.GetAll(criteria);
		}

		public List<VwArea> GetAllVwArea(string orders)
		{
			return VwAreaDao.GetAll(orders);
		}

		public List<VwArea> GetAllVwArea(string conditions, string orders)
		{
			return VwAreaDao.GetAll(conditions, orders);
		}

		public VwArea GetVwArea(int id)
		{
			return VwAreaDao.Get(id);
		}

		public VwArea GetVwArea(Expression<Func<VwArea, bool>> criteria)
		{
			return VwAreaDao.Get(criteria);
		}
	}
}

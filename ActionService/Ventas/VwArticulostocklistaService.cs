using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticulostocklista()
		{
			return VwArticulostocklistaDao.Count();
		}

		public long CountVwArticulostocklista(Expression<Func<VwArticulostocklista, bool>> criteria)
		{
			return VwArticulostocklistaDao.Count(criteria);
		}

		public List<VwArticulostocklista> GetAllVwArticulostocklista()
		{
			return VwArticulostocklistaDao.GetAll();
		}

		public List<VwArticulostocklista> GetAllVwArticulostocklista(Expression<Func<VwArticulostocklista, bool>> criteria)
		{
			return VwArticulostocklistaDao.GetAll(criteria);
		}

		public List<VwArticulostocklista> GetAllVwArticulostocklista(string orders)
		{
			return VwArticulostocklistaDao.GetAll(orders);
		}

		public List<VwArticulostocklista> GetAllVwArticulostocklista(string conditions, string orders)
		{
			return VwArticulostocklistaDao.GetAll(conditions, orders);
		}

		public VwArticulostocklista GetVwArticulostocklista(int id)
		{
			return VwArticulostocklistaDao.Get(id);
		}

		public VwArticulostocklista GetVwArticulostocklista(Expression<Func<VwArticulostocklista, bool>> criteria)
		{
			return VwArticulostocklistaDao.Get(criteria);
		}
	}
}

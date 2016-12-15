using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwInventarioinicial()
		{
			return VwInventarioinicialDao.Count();
		}

		public long CountVwInventarioinicial(Expression<Func<VwInventarioinicial, bool>> criteria)
		{
			return VwInventarioinicialDao.Count(criteria);
		}

		public List<VwInventarioinicial> GetAllVwInventarioinicial()
		{
			return VwInventarioinicialDao.GetAll();
		}

		public List<VwInventarioinicial> GetAllVwInventarioinicial(Expression<Func<VwInventarioinicial, bool>> criteria)
		{
			return VwInventarioinicialDao.GetAll(criteria);
		}

		public List<VwInventarioinicial> GetAllVwInventarioinicial(string orders)
		{
			return VwInventarioinicialDao.GetAll(orders);
		}

		public List<VwInventarioinicial> GetAllVwInventarioinicial(string conditions, string orders)
		{
			return VwInventarioinicialDao.GetAll(conditions, orders);
		}

		public VwInventarioinicial GetVwInventarioinicial(int id)
		{
			return VwInventarioinicialDao.Get(id);
		}

		public VwInventarioinicial GetVwInventarioinicial(Expression<Func<VwInventarioinicial, bool>> criteria)
		{
			return VwInventarioinicialDao.Get(criteria);
		}
	}
}

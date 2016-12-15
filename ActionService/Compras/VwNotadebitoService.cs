using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotadebito()
		{
			return VwNotadebitoDao.Count();
		}

		public long CountVwNotadebito(Expression<Func<VwNotadebito, bool>> criteria)
		{
			return VwNotadebitoDao.Count(criteria);
		}

		public List<VwNotadebito> GetAllVwNotadebito()
		{
			return VwNotadebitoDao.GetAll();
		}

		public List<VwNotadebito> GetAllVwNotadebito(Expression<Func<VwNotadebito, bool>> criteria)
		{
			return VwNotadebitoDao.GetAll(criteria);
		}

		public List<VwNotadebito> GetAllVwNotadebito(string orders)
		{
			return VwNotadebitoDao.GetAll(orders);
		}

		public List<VwNotadebito> GetAllVwNotadebito(string conditions, string orders)
		{
			return VwNotadebitoDao.GetAll(conditions, orders);
		}

		public VwNotadebito GetVwNotadebito(int id)
		{
			return VwNotadebitoDao.Get(id);
		}

		public VwNotadebito GetVwNotadebito(Expression<Func<VwNotadebito, bool>> criteria)
		{
			return VwNotadebitoDao.Get(criteria);
		}
	}
}

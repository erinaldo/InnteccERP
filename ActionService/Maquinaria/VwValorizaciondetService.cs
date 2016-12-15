using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizaciondet()
		{
			return VwValorizaciondetDao.Count();
		}

		public long CountVwValorizaciondet(Expression<Func<VwValorizaciondet, bool>> criteria)
		{
			return VwValorizaciondetDao.Count(criteria);
		}

		public List<VwValorizaciondet> GetAllVwValorizaciondet()
		{
			return VwValorizaciondetDao.GetAll();
		}

		public List<VwValorizaciondet> GetAllVwValorizaciondet(Expression<Func<VwValorizaciondet, bool>> criteria)
		{
			return VwValorizaciondetDao.GetAll(criteria);
		}

		public List<VwValorizaciondet> GetAllVwValorizaciondet(string orders)
		{
			return VwValorizaciondetDao.GetAll(orders);
		}

		public List<VwValorizaciondet> GetAllVwValorizaciondet(string conditions, string orders)
		{
			return VwValorizaciondetDao.GetAll(conditions, orders);
		}

		public VwValorizaciondet GetVwValorizaciondet(int id)
		{
			return VwValorizaciondetDao.Get(id);
		}

		public VwValorizaciondet GetVwValorizaciondet(Expression<Func<VwValorizaciondet, bool>> criteria)
		{
			return VwValorizaciondetDao.Get(criteria);
		}
	}
}

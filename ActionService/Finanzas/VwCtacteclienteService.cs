using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCtactecliente()
		{
			return VwCtacteclienteDao.Count();
		}

		public long CountVwCtactecliente(Expression<Func<VwCtactecliente, bool>> criteria)
		{
			return VwCtacteclienteDao.Count(criteria);
		}

		public List<VwCtactecliente> GetAllVwCtactecliente()
		{
			return VwCtacteclienteDao.GetAll();
		}

		public List<VwCtactecliente> GetAllVwCtactecliente(Expression<Func<VwCtactecliente, bool>> criteria)
		{
			return VwCtacteclienteDao.GetAll(criteria);
		}

		public List<VwCtactecliente> GetAllVwCtactecliente(string orders)
		{
			return VwCtacteclienteDao.GetAll(orders);
		}

		public List<VwCtactecliente> GetAllVwCtactecliente(string conditions, string orders)
		{
			return VwCtacteclienteDao.GetAll(conditions, orders);
		}

		public VwCtactecliente GetVwCtactecliente(int id)
		{
			return VwCtacteclienteDao.Get(id);
		}

		public VwCtactecliente GetVwCtactecliente(Expression<Func<VwCtactecliente, bool>> criteria)
		{
			return VwCtacteclienteDao.Get(criteria);
		}
	}
}

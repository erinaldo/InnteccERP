using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwItemhistoria()
		{
			return VwItemhistoriaDao.Count();
		}

		public long CountVwItemhistoria(Expression<Func<VwItemhistoria, bool>> criteria)
		{
			return VwItemhistoriaDao.Count(criteria);
		}

		public List<VwItemhistoria> GetAllVwItemhistoria()
		{
			return VwItemhistoriaDao.GetAll();
		}

		public List<VwItemhistoria> GetAllVwItemhistoria(Expression<Func<VwItemhistoria, bool>> criteria)
		{
			return VwItemhistoriaDao.GetAll(criteria);
		}

		public List<VwItemhistoria> GetAllVwItemhistoria(string orders)
		{
			return VwItemhistoriaDao.GetAll(orders);
		}

		public List<VwItemhistoria> GetAllVwItemhistoria(string conditions, string orders)
		{
			return VwItemhistoriaDao.GetAll(conditions, orders);
		}

		public VwItemhistoria GetVwItemhistoria(int id)
		{
			return VwItemhistoriaDao.Get(id);
		}

		public VwItemhistoria GetVwItemhistoria(Expression<Func<VwItemhistoria, bool>> criteria)
		{
			return VwItemhistoriaDao.Get(criteria);
		}
	}
}

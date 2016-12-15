using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwReciboresumen()
		{
			return VwReciboresumenDao.Count();
		}

		public long CountVwReciboresumen(Expression<Func<VwReciboresumen, bool>> criteria)
		{
			return VwReciboresumenDao.Count(criteria);
		}

		public List<VwReciboresumen> GetAllVwReciboresumen()
		{
			return VwReciboresumenDao.GetAll();
		}

		public List<VwReciboresumen> GetAllVwReciboresumen(Expression<Func<VwReciboresumen, bool>> criteria)
		{
			return VwReciboresumenDao.GetAll(criteria);
		}

		public List<VwReciboresumen> GetAllVwReciboresumen(string orders)
		{
			return VwReciboresumenDao.GetAll(orders);
		}

		public List<VwReciboresumen> GetAllVwReciboresumen(string conditions, string orders)
		{
			return VwReciboresumenDao.GetAll(conditions, orders);
		}

		public VwReciboresumen GetVwReciboresumen(int id)
		{
			return VwReciboresumenDao.Get(id);
		}

		public VwReciboresumen GetVwReciboresumen(Expression<Func<VwReciboresumen, bool>> criteria)
		{
			return VwReciboresumenDao.Get(criteria);
		}
	}
}

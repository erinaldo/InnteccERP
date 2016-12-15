using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwArticuloseriedet()
		{
			return VwArticuloseriedetDao.Count();
		}

		public long CountVwArticuloseriedet(Expression<Func<VwArticuloseriedet, bool>> criteria)
		{
			return VwArticuloseriedetDao.Count(criteria);
		}

		public List<VwArticuloseriedet> GetAllVwArticuloseriedet()
		{
			return VwArticuloseriedetDao.GetAll();
		}

		public List<VwArticuloseriedet> GetAllVwArticuloseriedet(Expression<Func<VwArticuloseriedet, bool>> criteria)
		{
			return VwArticuloseriedetDao.GetAll(criteria);
		}

		public List<VwArticuloseriedet> GetAllVwArticuloseriedet(string orders)
		{
			return VwArticuloseriedetDao.GetAll(orders);
		}

		public List<VwArticuloseriedet> GetAllVwArticuloseriedet(string conditions, string orders)
		{
			return VwArticuloseriedetDao.GetAll(conditions, orders);
		}

		public VwArticuloseriedet GetVwArticuloseriedet(int id)
		{
			return VwArticuloseriedetDao.Get(id);
		}

		public VwArticuloseriedet GetVwArticuloseriedet(Expression<Func<VwArticuloseriedet, bool>> criteria)
		{
			return VwArticuloseriedetDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCierrecajadet()
		{
			return VwCierrecajadetDao.Count();
		}

		public long CountVwCierrecajadet(Expression<Func<VwCierrecajadet, bool>> criteria)
		{
			return VwCierrecajadetDao.Count(criteria);
		}

		public List<VwCierrecajadet> GetAllVwCierrecajadet()
		{
			return VwCierrecajadetDao.GetAll();
		}

		public List<VwCierrecajadet> GetAllVwCierrecajadet(Expression<Func<VwCierrecajadet, bool>> criteria)
		{
			return VwCierrecajadetDao.GetAll(criteria);
		}

		public List<VwCierrecajadet> GetAllVwCierrecajadet(string orders)
		{
			return VwCierrecajadetDao.GetAll(orders);
		}

		public List<VwCierrecajadet> GetAllVwCierrecajadet(string conditions, string orders)
		{
			return VwCierrecajadetDao.GetAll(conditions, orders);
		}

		public VwCierrecajadet GetVwCierrecajadet(int id)
		{
			return VwCierrecajadetDao.Get(id);
		}

		public VwCierrecajadet GetVwCierrecajadet(Expression<Func<VwCierrecajadet, bool>> criteria)
		{
			return VwCierrecajadetDao.Get(criteria);
		}
	}
}

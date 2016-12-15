using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpcompra()
		{
			return VwCpcompraDao.Count();
		}

		public long CountVwCpcompra(Expression<Func<VwCpcompra, bool>> criteria)
		{
			return VwCpcompraDao.Count(criteria);
		}

		public List<VwCpcompra> GetAllVwCpcompra()
		{
			return VwCpcompraDao.GetAll();
		}

		public List<VwCpcompra> GetAllVwCpcompra(Expression<Func<VwCpcompra, bool>> criteria)
		{
			return VwCpcompraDao.GetAll(criteria);
		}

		public List<VwCpcompra> GetAllVwCpcompra(string orders)
		{
			return VwCpcompraDao.GetAll(orders);
		}

		public List<VwCpcompra> GetAllVwCpcompra(string conditions, string orders)
		{
			return VwCpcompraDao.GetAll(conditions, orders);
		}

		public VwCpcompra GetVwCpcompra(int id)
		{
			return VwCpcompraDao.Get(id);
		}

		public VwCpcompra GetVwCpcompra(Expression<Func<VwCpcompra, bool>> criteria)
		{
			return VwCpcompraDao.Get(criteria);
		}
	}
}

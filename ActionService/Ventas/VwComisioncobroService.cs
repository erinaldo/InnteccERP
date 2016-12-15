using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwComisioncobro()
		{
			return VwComisioncobroDao.Count();
		}

		public long CountVwComisioncobro(Expression<Func<VwComisioncobro, bool>> criteria)
		{
			return VwComisioncobroDao.Count(criteria);
		}

		public List<VwComisioncobro> GetAllVwComisioncobro()
		{
			return VwComisioncobroDao.GetAll();
		}

		public List<VwComisioncobro> GetAllVwComisioncobro(Expression<Func<VwComisioncobro, bool>> criteria)
		{
			return VwComisioncobroDao.GetAll(criteria);
		}

		public List<VwComisioncobro> GetAllVwComisioncobro(string orders)
		{
			return VwComisioncobroDao.GetAll(orders);
		}

		public List<VwComisioncobro> GetAllVwComisioncobro(string conditions, string orders)
		{
			return VwComisioncobroDao.GetAll(conditions, orders);
		}

		public VwComisioncobro GetVwComisioncobro(int id)
		{
			return VwComisioncobroDao.Get(id);
		}

		public VwComisioncobro GetVwComisioncobro(Expression<Func<VwComisioncobro, bool>> criteria)
		{
			return VwComisioncobroDao.Get(criteria);
		}
	}
}

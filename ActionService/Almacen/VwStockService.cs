using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwStock()
		{
			return VwStockDao.Count();
		}

		public long CountVwStock(Expression<Func<VwStock, bool>> criteria)
		{
			return VwStockDao.Count(criteria);
		}

		public List<VwStock> GetAllVwStock()
		{
			return VwStockDao.GetAll();
		}

		public List<VwStock> GetAllVwStock(Expression<Func<VwStock, bool>> criteria)
		{
			return VwStockDao.GetAll(criteria);
		}

		public List<VwStock> GetAllVwStock(string orders)
		{
			return VwStockDao.GetAll(orders);
		}

		public List<VwStock> GetAllVwStock(string conditions, string orders)
		{
			return VwStockDao.GetAll(conditions, orders);
		}

		public VwStock GetVwStock(int id)
		{
			return VwStockDao.Get(id);
		}

		public VwStock GetVwStock(Expression<Func<VwStock, bool>> criteria)
		{
			return VwStockDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
   public partial class Service
	{
		public long CountVwInventariostock()
		{
			return VwInventariostockDao.Count();
		}

		public long CountVwInventariostock(Expression<Func<VwInventariostock, bool>> criteria)
		{
			return VwInventariostockDao.Count(criteria);
		}

		public List<VwInventariostock> GetAllVwInventariostock()
		{
			return VwInventariostockDao.GetAll();
		}

		public List<VwInventariostock> GetAllVwInventariostock(Expression<Func<VwInventariostock, bool>> criteria)
		{
			return VwInventariostockDao.GetAll(criteria);
		}

		public List<VwInventariostock> GetAllVwInventariostock(string orders)
		{
			return VwInventariostockDao.GetAll(orders);
		}

		public List<VwInventariostock> GetAllVwInventariostock(string conditions, string orders)
		{
			return VwInventariostockDao.GetAll(conditions, orders);
		}

		public VwInventariostock GetVwInventariostock(int id)
		{
			return VwInventariostockDao.Get(id);
		}

		public VwInventariostock GetVwInventariostock(Expression<Func<VwInventariostock, bool>> criteria)
		{
			return VwInventariostockDao.Get(criteria);
		}
	}
}

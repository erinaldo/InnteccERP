using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSocionegociomarca()
		{
			return VwSocionegociomarcaDao.Count();
		}

		public long CountVwSocionegociomarca(Expression<Func<VwSocionegociomarca, bool>> criteria)
		{
			return VwSocionegociomarcaDao.Count(criteria);
		}

		public List<VwSocionegociomarca> GetAllVwSocionegociomarca()
		{
			return VwSocionegociomarcaDao.GetAll();
		}

		public List<VwSocionegociomarca> GetAllVwSocionegociomarca(Expression<Func<VwSocionegociomarca, bool>> criteria)
		{
			return VwSocionegociomarcaDao.GetAll(criteria);
		}

		public List<VwSocionegociomarca> GetAllVwSocionegociomarca(string orders)
		{
			return VwSocionegociomarcaDao.GetAll(orders);
		}

		public List<VwSocionegociomarca> GetAllVwSocionegociomarca(string conditions, string orders)
		{
			return VwSocionegociomarcaDao.GetAll(conditions, orders);
		}

		public VwSocionegociomarca GetVwSocionegociomarca(int id)
		{
			return VwSocionegociomarcaDao.Get(id);
		}

		public VwSocionegociomarca GetVwSocionegociomarca(Expression<Func<VwSocionegociomarca, bool>> criteria)
		{
			return VwSocionegociomarcaDao.Get(criteria);
		}
	}
}

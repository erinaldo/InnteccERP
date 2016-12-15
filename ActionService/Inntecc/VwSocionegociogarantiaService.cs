using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSocionegociogarantia()
		{
			return VwSocionegociogarantiaDao.Count();
		}

		public long CountVwSocionegociogarantia(Expression<Func<VwSocionegociogarantia, bool>> criteria)
		{
			return VwSocionegociogarantiaDao.Count(criteria);
		}

		public List<VwSocionegociogarantia> GetAllVwSocionegociogarantia()
		{
			return VwSocionegociogarantiaDao.GetAll();
		}

		public List<VwSocionegociogarantia> GetAllVwSocionegociogarantia(Expression<Func<VwSocionegociogarantia, bool>> criteria)
		{
			return VwSocionegociogarantiaDao.GetAll(criteria);
		}

		public List<VwSocionegociogarantia> GetAllVwSocionegociogarantia(string orders)
		{
			return VwSocionegociogarantiaDao.GetAll(orders);
		}

		public List<VwSocionegociogarantia> GetAllVwSocionegociogarantia(string conditions, string orders)
		{
			return VwSocionegociogarantiaDao.GetAll(conditions, orders);
		}

		public VwSocionegociogarantia GetVwSocionegociogarantia(int id)
		{
			return VwSocionegociogarantiaDao.Get(id);
		}

		public VwSocionegociogarantia GetVwSocionegociogarantia(Expression<Func<VwSocionegociogarantia, bool>> criteria)
		{
			return VwSocionegociogarantiaDao.Get(criteria);
		}
	}
}

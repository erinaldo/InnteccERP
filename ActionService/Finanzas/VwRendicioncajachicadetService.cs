using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRendicioncajachicadet()
		{
			return VwRendicioncajachicadetDao.Count();
		}

		public long CountVwRendicioncajachicadet(Expression<Func<VwRendicioncajachicadet, bool>> criteria)
		{
			return VwRendicioncajachicadetDao.Count(criteria);
		}

		public List<VwRendicioncajachicadet> GetAllVwRendicioncajachicadet()
		{
			return VwRendicioncajachicadetDao.GetAll();
		}

		public List<VwRendicioncajachicadet> GetAllVwRendicioncajachicadet(Expression<Func<VwRendicioncajachicadet, bool>> criteria)
		{
			return VwRendicioncajachicadetDao.GetAll(criteria);
		}

		public List<VwRendicioncajachicadet> GetAllVwRendicioncajachicadet(string orders)
		{
			return VwRendicioncajachicadetDao.GetAll(orders);
		}

		public List<VwRendicioncajachicadet> GetAllVwRendicioncajachicadet(string conditions, string orders)
		{
			return VwRendicioncajachicadetDao.GetAll(conditions, orders);
		}

		public VwRendicioncajachicadet GetVwRendicioncajachicadet(int id)
		{
			return VwRendicioncajachicadetDao.Get(id);
		}

		public VwRendicioncajachicadet GetVwRendicioncajachicadet(Expression<Func<VwRendicioncajachicadet, bool>> criteria)
		{
			return VwRendicioncajachicadetDao.Get(criteria);
		}
	}
}

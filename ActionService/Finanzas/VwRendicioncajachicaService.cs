using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRendicioncajachica()
		{
			return VwRendicioncajachicaDao.Count();
		}

		public long CountVwRendicioncajachica(Expression<Func<VwRendicioncajachica, bool>> criteria)
		{
			return VwRendicioncajachicaDao.Count(criteria);
		}

		public List<VwRendicioncajachica> GetAllVwRendicioncajachica()
		{
			return VwRendicioncajachicaDao.GetAll();
		}

		public List<VwRendicioncajachica> GetAllVwRendicioncajachica(Expression<Func<VwRendicioncajachica, bool>> criteria)
		{
			return VwRendicioncajachicaDao.GetAll(criteria);
		}

		public List<VwRendicioncajachica> GetAllVwRendicioncajachica(string orders)
		{
			return VwRendicioncajachicaDao.GetAll(orders);
		}

		public List<VwRendicioncajachica> GetAllVwRendicioncajachica(string conditions, string orders)
		{
			return VwRendicioncajachicaDao.GetAll(conditions, orders);
		}

		public VwRendicioncajachica GetVwRendicioncajachica(int id)
		{
			return VwRendicioncajachicaDao.Get(id);
		}

		public VwRendicioncajachica GetVwRendicioncajachica(Expression<Func<VwRendicioncajachica, bool>> criteria)
		{
			return VwRendicioncajachicaDao.Get(criteria);
		}
	}
}

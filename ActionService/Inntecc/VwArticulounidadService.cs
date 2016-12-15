using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticulounidad()
		{
			return VwArticulounidadDao.Count();
		}

		public long CountVwArticulounidad(Expression<Func<VwArticulounidad, bool>> criteria)
		{
			return VwArticulounidadDao.Count(criteria);
		}

		public List<VwArticulounidad> GetAllVwArticulounidad()
		{
			return VwArticulounidadDao.GetAll();
		}

		public List<VwArticulounidad> GetAllVwArticulounidad(Expression<Func<VwArticulounidad, bool>> criteria)
		{
			return VwArticulounidadDao.GetAll(criteria);
		}

		public List<VwArticulounidad> GetAllVwArticulounidad(string orders)
		{
			return VwArticulounidadDao.GetAll(orders);
		}

		public List<VwArticulounidad> GetAllVwArticulounidad(string conditions, string orders)
		{
			return VwArticulounidadDao.GetAll(conditions, orders);
		}

		public VwArticulounidad GetVwArticulounidad(int id)
		{
			return VwArticulounidadDao.Get(id);
		}

		public VwArticulounidad GetVwArticulounidad(Expression<Func<VwArticulounidad, bool>> criteria)
		{
			return VwArticulounidadDao.Get(criteria);
		}
	}
}

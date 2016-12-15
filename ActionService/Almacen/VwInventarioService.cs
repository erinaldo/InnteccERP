using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwInventario()
		{
			return VwInventarioDao.Count();
		}

		public long CountVwInventario(Expression<Func<VwInventario, bool>> criteria)
		{
			return VwInventarioDao.Count(criteria);
		}

		public List<VwInventario> GetAllVwInventario()
		{
			return VwInventarioDao.GetAll();
		}

		public List<VwInventario> GetAllVwInventario(Expression<Func<VwInventario, bool>> criteria)
		{
			return VwInventarioDao.GetAll(criteria);
		}

		public List<VwInventario> GetAllVwInventario(string orders)
		{
			return VwInventarioDao.GetAll(orders);
		}

		public List<VwInventario> GetAllVwInventario(string conditions, string orders)
		{
			return VwInventarioDao.GetAll(conditions, orders);
		}

		public VwInventario GetVwInventario(int id)
		{
			return VwInventarioDao.Get(id);
		}

		public VwInventario GetVwInventario(Expression<Func<VwInventario, bool>> criteria)
		{
			return VwInventarioDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwAlmacen()
		{
			return VwAlmacenDao.Count();
		}

		public long CountVwAlmacen(Expression<Func<VwAlmacen, bool>> criteria)
		{
			return VwAlmacenDao.Count(criteria);
		}

		public List<VwAlmacen> GetAllVwAlmacen()
		{
			return VwAlmacenDao.GetAll();
		}

		public List<VwAlmacen> GetAllVwAlmacen(Expression<Func<VwAlmacen, bool>> criteria)
		{
			return VwAlmacenDao.GetAll(criteria);
		}

		public List<VwAlmacen> GetAllVwAlmacen(string orders)
		{
			return VwAlmacenDao.GetAll(orders);
		}

		public List<VwAlmacen> GetAllVwAlmacen(string conditions, string orders)
		{
			return VwAlmacenDao.GetAll(conditions, orders);
		}

		public VwAlmacen GetVwAlmacen(int id)
		{
			return VwAlmacenDao.Get(id);
		}

		public VwAlmacen GetVwAlmacen(Expression<Func<VwAlmacen, bool>> criteria)
		{
			return VwAlmacenDao.Get(criteria);
		}
	}
}

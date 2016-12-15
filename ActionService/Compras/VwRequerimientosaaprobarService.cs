using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRequerimientosaaprobar()
		{
			return VwRequerimientosaaprobarDao.Count();
		}

		public long CountVwRequerimientosaaprobar(Expression<Func<VwRequerimientosaaprobar, bool>> criteria)
		{
			return VwRequerimientosaaprobarDao.Count(criteria);
		}

		public List<VwRequerimientosaaprobar> GetAllVwRequerimientosaaprobar()
		{
			return VwRequerimientosaaprobarDao.GetAll();
		}

		public List<VwRequerimientosaaprobar> GetAllVwRequerimientosaaprobar(Expression<Func<VwRequerimientosaaprobar, bool>> criteria)
		{
			return VwRequerimientosaaprobarDao.GetAll(criteria);
		}

		public List<VwRequerimientosaaprobar> GetAllVwRequerimientosaaprobar(string orders)
		{
			return VwRequerimientosaaprobarDao.GetAll(orders);
		}

		public List<VwRequerimientosaaprobar> GetAllVwRequerimientosaaprobar(string conditions, string orders)
		{
			return VwRequerimientosaaprobarDao.GetAll(conditions, orders);
		}

		public VwRequerimientosaaprobar GetVwRequerimientosaaprobar(int id)
		{
			return VwRequerimientosaaprobarDao.Get(id);
		}

		public VwRequerimientosaaprobar GetVwRequerimientosaaprobar(Expression<Func<VwRequerimientosaaprobar, bool>> criteria)
		{
			return VwRequerimientosaaprobarDao.Get(criteria);
		}
	}
}

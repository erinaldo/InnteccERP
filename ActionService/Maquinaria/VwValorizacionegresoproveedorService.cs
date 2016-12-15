using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizacionegresoproveedor()
		{
			return VwValorizacionegresoproveedorDao.Count();
		}

		public long CountVwValorizacionegresoproveedor(Expression<Func<VwValorizacionegresoproveedor, bool>> criteria)
		{
			return VwValorizacionegresoproveedorDao.Count(criteria);
		}

		public List<VwValorizacionegresoproveedor> GetAllVwValorizacionegresoproveedor()
		{
			return VwValorizacionegresoproveedorDao.GetAll();
		}

		public List<VwValorizacionegresoproveedor> GetAllVwValorizacionegresoproveedor(Expression<Func<VwValorizacionegresoproveedor, bool>> criteria)
		{
			return VwValorizacionegresoproveedorDao.GetAll(criteria);
		}

		public List<VwValorizacionegresoproveedor> GetAllVwValorizacionegresoproveedor(string orders)
		{
			return VwValorizacionegresoproveedorDao.GetAll(orders);
		}

		public List<VwValorizacionegresoproveedor> GetAllVwValorizacionegresoproveedor(string conditions, string orders)
		{
			return VwValorizacionegresoproveedorDao.GetAll(conditions, orders);
		}

		public VwValorizacionegresoproveedor GetVwValorizacionegresoproveedor(int id)
		{
			return VwValorizacionegresoproveedorDao.Get(id);
		}

		public VwValorizacionegresoproveedor GetVwValorizacionegresoproveedor(Expression<Func<VwValorizacionegresoproveedor, bool>> criteria)
		{
			return VwValorizacionegresoproveedorDao.Get(criteria);
		}
	}
}

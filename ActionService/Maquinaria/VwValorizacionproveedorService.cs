using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizacionproveedor()
		{
			return VwValorizacionproveedorDao.Count();
		}

		public long CountVwValorizacionproveedor(Expression<Func<VwValorizacionproveedor, bool>> criteria)
		{
			return VwValorizacionproveedorDao.Count(criteria);
		}

		public List<VwValorizacionproveedor> GetAllVwValorizacionproveedor()
		{
			return VwValorizacionproveedorDao.GetAll();
		}

		public List<VwValorizacionproveedor> GetAllVwValorizacionproveedor(Expression<Func<VwValorizacionproveedor, bool>> criteria)
		{
			return VwValorizacionproveedorDao.GetAll(criteria);
		}

		public List<VwValorizacionproveedor> GetAllVwValorizacionproveedor(string orders)
		{
			return VwValorizacionproveedorDao.GetAll(orders);
		}

		public List<VwValorizacionproveedor> GetAllVwValorizacionproveedor(string conditions, string orders)
		{
			return VwValorizacionproveedorDao.GetAll(conditions, orders);
		}

		public VwValorizacionproveedor GetVwValorizacionproveedor(int id)
		{
			return VwValorizacionproveedorDao.Get(id);
		}

		public VwValorizacionproveedor GetVwValorizacionproveedor(Expression<Func<VwValorizacionproveedor, bool>> criteria)
		{
			return VwValorizacionproveedorDao.Get(criteria);
		}
	}
}

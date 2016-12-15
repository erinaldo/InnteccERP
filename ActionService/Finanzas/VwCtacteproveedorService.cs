using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCtacteproveedor()
		{
			return VwCtacteproveedorDao.Count();
		}

		public long CountVwCtacteproveedor(Expression<Func<VwCtacteproveedor, bool>> criteria)
		{
			return VwCtacteproveedorDao.Count(criteria);
		}

		public List<VwCtacteproveedor> GetAllVwCtacteproveedor()
		{
			return VwCtacteproveedorDao.GetAll();
		}

		public List<VwCtacteproveedor> GetAllVwCtacteproveedor(Expression<Func<VwCtacteproveedor, bool>> criteria)
		{
			return VwCtacteproveedorDao.GetAll(criteria);
		}

		public List<VwCtacteproveedor> GetAllVwCtacteproveedor(string orders)
		{
			return VwCtacteproveedorDao.GetAll(orders);
		}

		public List<VwCtacteproveedor> GetAllVwCtacteproveedor(string conditions, string orders)
		{
			return VwCtacteproveedorDao.GetAll(conditions, orders);
		}

		public VwCtacteproveedor GetVwCtacteproveedor(int id)
		{
			return VwCtacteproveedorDao.Get(id);
		}

		public VwCtacteproveedor GetVwCtacteproveedor(Expression<Func<VwCtacteproveedor, bool>> criteria)
		{
			return VwCtacteproveedorDao.Get(criteria);
		}
	}
}

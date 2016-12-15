using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizacionproveedordet()
		{
			return VwValorizacionproveedordetDao.Count();
		}

		public long CountVwValorizacionproveedordet(Expression<Func<VwValorizacionproveedordet, bool>> criteria)
		{
			return VwValorizacionproveedordetDao.Count(criteria);
		}

		public List<VwValorizacionproveedordet> GetAllVwValorizacionproveedordet()
		{
			return VwValorizacionproveedordetDao.GetAll();
		}

		public List<VwValorizacionproveedordet> GetAllVwValorizacionproveedordet(Expression<Func<VwValorizacionproveedordet, bool>> criteria)
		{
			return VwValorizacionproveedordetDao.GetAll(criteria);
		}

		public List<VwValorizacionproveedordet> GetAllVwValorizacionproveedordet(string orders)
		{
			return VwValorizacionproveedordetDao.GetAll(orders);
		}

		public List<VwValorizacionproveedordet> GetAllVwValorizacionproveedordet(string conditions, string orders)
		{
			return VwValorizacionproveedordetDao.GetAll(conditions, orders);
		}

		public VwValorizacionproveedordet GetVwValorizacionproveedordet(int id)
		{
			return VwValorizacionproveedordetDao.Get(id);
		}

		public VwValorizacionproveedordet GetVwValorizacionproveedordet(Expression<Func<VwValorizacionproveedordet, bool>> criteria)
		{
			return VwValorizacionproveedordetDao.Get(criteria);
		}
	}
}

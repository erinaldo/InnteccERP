using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwModeloequipo()
		{
			return VwModeloequipoDao.Count();
		}

		public long CountVwModeloequipo(Expression<Func<VwModeloequipo, bool>> criteria)
		{
			return VwModeloequipoDao.Count(criteria);
		}

		public List<VwModeloequipo> GetAllVwModeloequipo()
		{
			return VwModeloequipoDao.GetAll();
		}

		public List<VwModeloequipo> GetAllVwModeloequipo(Expression<Func<VwModeloequipo, bool>> criteria)
		{
			return VwModeloequipoDao.GetAll(criteria);
		}

		public List<VwModeloequipo> GetAllVwModeloequipo(string orders)
		{
			return VwModeloequipoDao.GetAll(orders);
		}

		public List<VwModeloequipo> GetAllVwModeloequipo(string conditions, string orders)
		{
			return VwModeloequipoDao.GetAll(conditions, orders);
		}

		public VwModeloequipo GetVwModeloequipo(int id)
		{
			return VwModeloequipoDao.Get(id);
		}

		public VwModeloequipo GetVwModeloequipo(Expression<Func<VwModeloequipo, bool>> criteria)
		{
			return VwModeloequipoDao.Get(criteria);
		}
	}
}

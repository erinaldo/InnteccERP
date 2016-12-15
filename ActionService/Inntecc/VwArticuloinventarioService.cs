using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwArticuloinventario()
		{
			return VwArticuloinventarioDao.Count();
		}

		public long CountVwArticuloinventario(Expression<Func<VwArticuloinventario, bool>> criteria)
		{
			return VwArticuloinventarioDao.Count(criteria);
		}

		public List<VwArticuloinventario> GetAllVwArticuloinventario()
		{
			return VwArticuloinventarioDao.GetAll();
		}

		public List<VwArticuloinventario> GetAllVwArticuloinventario(Expression<Func<VwArticuloinventario, bool>> criteria)
		{
			return VwArticuloinventarioDao.GetAll(criteria);
		}

		public List<VwArticuloinventario> GetAllVwArticuloinventario(string orders)
		{
			return VwArticuloinventarioDao.GetAll(orders);
		}

		public List<VwArticuloinventario> GetAllVwArticuloinventario(string conditions, string orders)
		{
			return VwArticuloinventarioDao.GetAll(conditions, orders);
		}

		public VwArticuloinventario GetVwArticuloinventario(int id)
		{
			return VwArticuloinventarioDao.Get(id);
		}

		public VwArticuloinventario GetVwArticuloinventario(Expression<Func<VwArticuloinventario, bool>> criteria)
		{
			return VwArticuloinventarioDao.Get(criteria);
		}
	}
}

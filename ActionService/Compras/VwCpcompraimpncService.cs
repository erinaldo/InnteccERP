using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpcompraimpnc()
		{
			return VwCpcompraimpncDao.Count();
		}

		public long CountVwCpcompraimpnc(Expression<Func<VwCpcompraimpnc, bool>> criteria)
		{
			return VwCpcompraimpncDao.Count(criteria);
		}

		public List<VwCpcompraimpnc> GetAllVwCpcompraimpnc()
		{
			return VwCpcompraimpncDao.GetAll();
		}

		public List<VwCpcompraimpnc> GetAllVwCpcompraimpnc(Expression<Func<VwCpcompraimpnc, bool>> criteria)
		{
			return VwCpcompraimpncDao.GetAll(criteria);
		}

		public List<VwCpcompraimpnc> GetAllVwCpcompraimpnc(string orders)
		{
			return VwCpcompraimpncDao.GetAll(orders);
		}

		public List<VwCpcompraimpnc> GetAllVwCpcompraimpnc(string conditions, string orders)
		{
			return VwCpcompraimpncDao.GetAll(conditions, orders);
		}

		public VwCpcompraimpnc GetVwCpcompraimpnc(int id)
		{
			return VwCpcompraimpncDao.Get(id);
		}

		public VwCpcompraimpnc GetVwCpcompraimpnc(Expression<Func<VwCpcompraimpnc, bool>> criteria)
		{
			return VwCpcompraimpncDao.Get(criteria);
		}
	}
}

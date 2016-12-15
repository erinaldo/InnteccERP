using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpventaimpnc()
		{
			return VwCpventaimpncDao.Count();
		}

		public long CountVwCpventaimpnc(Expression<Func<VwCpventaimpnc, bool>> criteria)
		{
			return VwCpventaimpncDao.Count(criteria);
		}

		public List<VwCpventaimpnc> GetAllVwCpventaimpnc()
		{
			return VwCpventaimpncDao.GetAll();
		}

		public List<VwCpventaimpnc> GetAllVwCpventaimpnc(Expression<Func<VwCpventaimpnc, bool>> criteria)
		{
			return VwCpventaimpncDao.GetAll(criteria);
		}

		public List<VwCpventaimpnc> GetAllVwCpventaimpnc(string orders)
		{
			return VwCpventaimpncDao.GetAll(orders);
		}

		public List<VwCpventaimpnc> GetAllVwCpventaimpnc(string conditions, string orders)
		{
			return VwCpventaimpncDao.GetAll(conditions, orders);
		}

		public VwCpventaimpnc GetVwCpventaimpnc(int id)
		{
			return VwCpventaimpncDao.Get(id);
		}

		public VwCpventaimpnc GetVwCpventaimpnc(Expression<Func<VwCpventaimpnc, bool>> criteria)
		{
			return VwCpventaimpncDao.Get(criteria);
		}
	}
}

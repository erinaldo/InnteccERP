using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwCpventadetserie()
		{
			return VwCpventadetserieDao.Count();
		}

		public long CountVwCpventadetserie(Expression<Func<VwCpventadetserie, bool>> criteria)
		{
			return VwCpventadetserieDao.Count(criteria);
		}

		public List<VwCpventadetserie> GetAllVwCpventadetserie()
		{
			return VwCpventadetserieDao.GetAll();
		}

		public List<VwCpventadetserie> GetAllVwCpventadetserie(Expression<Func<VwCpventadetserie, bool>> criteria)
		{
			return VwCpventadetserieDao.GetAll(criteria);
		}

		public List<VwCpventadetserie> GetAllVwCpventadetserie(string orders)
		{
			return VwCpventadetserieDao.GetAll(orders);
		}

		public List<VwCpventadetserie> GetAllVwCpventadetserie(string conditions, string orders)
		{
			return VwCpventadetserieDao.GetAll(conditions, orders);
		}

		public VwCpventadetserie GetVwCpventadetserie(int id)
		{
			return VwCpventadetserieDao.Get(id);
		}

		public VwCpventadetserie GetVwCpventadetserie(Expression<Func<VwCpventadetserie, bool>> criteria)
		{
			return VwCpventadetserieDao.Get(criteria);
		}
	}
}

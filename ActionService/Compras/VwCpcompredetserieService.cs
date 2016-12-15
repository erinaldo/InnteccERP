using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwCpcompradetserie()
		{
			return VwCpcompradetserieDao.Count();
		}

		public long CountVwCpcompradetserie(Expression<Func<VwCpcompradetserie, bool>> criteria)
		{
			return VwCpcompradetserieDao.Count(criteria);
		}

		public List<VwCpcompradetserie> GetAllVwCpcompradetserie()
		{
			return VwCpcompradetserieDao.GetAll();
		}

		public List<VwCpcompradetserie> GetAllVwCpcompradetserie(Expression<Func<VwCpcompradetserie, bool>> criteria)
		{
			return VwCpcompradetserieDao.GetAll(criteria);
		}

		public List<VwCpcompradetserie> GetAllVwCpcompradetserie(string orders)
		{
			return VwCpcompradetserieDao.GetAll(orders);
		}

		public List<VwCpcompradetserie> GetAllVwCpcompradetserie(string conditions, string orders)
		{
			return VwCpcompradetserieDao.GetAll(conditions, orders);
		}

		public VwCpcompradetserie GetVwCpcompradetserie(int id)
		{
			return VwCpcompradetserieDao.Get(id);
		}

		public VwCpcompradetserie GetVwCpcompradetserie(Expression<Func<VwCpcompradetserie, bool>> criteria)
		{
			return VwCpcompradetserieDao.Get(criteria);
		}
	}
}

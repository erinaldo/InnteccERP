using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCuadrocomparativoarticuloimpos()
		{
			return VwCuadrocomparativoarticuloimposDao.Count();
		}

		public long CountVwCuadrocomparativoarticuloimpos(Expression<Func<VwCuadrocomparativoarticuloimpos, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloimposDao.Count(criteria);
		}

		public List<VwCuadrocomparativoarticuloimpos> GetAllVwCuadrocomparativoarticuloimpos()
		{
			return VwCuadrocomparativoarticuloimposDao.GetAll();
		}

		public List<VwCuadrocomparativoarticuloimpos> GetAllVwCuadrocomparativoarticuloimpos(Expression<Func<VwCuadrocomparativoarticuloimpos, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloimposDao.GetAll(criteria);
		}

		public List<VwCuadrocomparativoarticuloimpos> GetAllVwCuadrocomparativoarticuloimpos(string orders)
		{
			return VwCuadrocomparativoarticuloimposDao.GetAll(orders);
		}

		public List<VwCuadrocomparativoarticuloimpos> GetAllVwCuadrocomparativoarticuloimpos(string conditions, string orders)
		{
			return VwCuadrocomparativoarticuloimposDao.GetAll(conditions, orders);
		}

		public VwCuadrocomparativoarticuloimpos GetVwCuadrocomparativoarticuloimpos(int id)
		{
			return VwCuadrocomparativoarticuloimposDao.Get(id);
		}

		public VwCuadrocomparativoarticuloimpos GetVwCuadrocomparativoarticuloimpos(Expression<Func<VwCuadrocomparativoarticuloimpos, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloimposDao.Get(criteria);
		}
	}
}

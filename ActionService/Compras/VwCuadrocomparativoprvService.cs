using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCuadrocomparativoprv()
		{
			return VwCuadrocomparativoprvDao.Count();
		}

		public long CountVwCuadrocomparativoprv(Expression<Func<VwCuadrocomparativoprv, bool>> criteria)
		{
			return VwCuadrocomparativoprvDao.Count(criteria);
		}

		public List<VwCuadrocomparativoprv> GetAllVwCuadrocomparativoprv()
		{
			return VwCuadrocomparativoprvDao.GetAll();
		}

		public List<VwCuadrocomparativoprv> GetAllVwCuadrocomparativoprv(Expression<Func<VwCuadrocomparativoprv, bool>> criteria)
		{
			return VwCuadrocomparativoprvDao.GetAll(criteria);
		}

		public List<VwCuadrocomparativoprv> GetAllVwCuadrocomparativoprv(string orders)
		{
			return VwCuadrocomparativoprvDao.GetAll(orders);
		}

		public List<VwCuadrocomparativoprv> GetAllVwCuadrocomparativoprv(string conditions, string orders)
		{
			return VwCuadrocomparativoprvDao.GetAll(conditions, orders);
		}

		public VwCuadrocomparativoprv GetVwCuadrocomparativoprv(int id)
		{
			return VwCuadrocomparativoprvDao.Get(id);
		}

		public VwCuadrocomparativoprv GetVwCuadrocomparativoprv(Expression<Func<VwCuadrocomparativoprv, bool>> criteria)
		{
			return VwCuadrocomparativoprvDao.Get(criteria);
		}
	}
}

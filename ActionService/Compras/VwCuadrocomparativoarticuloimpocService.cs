using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCuadrocomparativoarticuloimpoc()
		{
			return VwCuadrocomparativoarticuloimpocDao.Count();
		}

		public long CountVwCuadrocomparativoarticuloimpoc(Expression<Func<VwCuadrocomparativoarticuloimpoc, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloimpocDao.Count(criteria);
		}

		public List<VwCuadrocomparativoarticuloimpoc> GetAllVwCuadrocomparativoarticuloimpoc()
		{
			return VwCuadrocomparativoarticuloimpocDao.GetAll();
		}

		public List<VwCuadrocomparativoarticuloimpoc> GetAllVwCuadrocomparativoarticuloimpoc(Expression<Func<VwCuadrocomparativoarticuloimpoc, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloimpocDao.GetAll(criteria);
		}

		public List<VwCuadrocomparativoarticuloimpoc> GetAllVwCuadrocomparativoarticuloimpoc(string orders)
		{
			return VwCuadrocomparativoarticuloimpocDao.GetAll(orders);
		}

		public List<VwCuadrocomparativoarticuloimpoc> GetAllVwCuadrocomparativoarticuloimpoc(string conditions, string orders)
		{
			return VwCuadrocomparativoarticuloimpocDao.GetAll(conditions, orders);
		}

		public VwCuadrocomparativoarticuloimpoc GetVwCuadrocomparativoarticuloimpoc(int id)
		{
			return VwCuadrocomparativoarticuloimpocDao.Get(id);
		}

		public VwCuadrocomparativoarticuloimpoc GetVwCuadrocomparativoarticuloimpoc(Expression<Func<VwCuadrocomparativoarticuloimpoc, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloimpocDao.Get(criteria);
		}
	}
}

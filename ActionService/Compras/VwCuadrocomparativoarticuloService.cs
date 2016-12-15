using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCuadrocomparativoarticulo()
		{
			return VwCuadrocomparativoarticuloDao.Count();
		}

		public long CountVwCuadrocomparativoarticulo(Expression<Func<VwCuadrocomparativoarticulo, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloDao.Count(criteria);
		}

		public List<VwCuadrocomparativoarticulo> GetAllVwCuadrocomparativoarticulo()
		{
			return VwCuadrocomparativoarticuloDao.GetAll();
		}

		public List<VwCuadrocomparativoarticulo> GetAllVwCuadrocomparativoarticulo(Expression<Func<VwCuadrocomparativoarticulo, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloDao.GetAll(criteria);
		}

		public List<VwCuadrocomparativoarticulo> GetAllVwCuadrocomparativoarticulo(string orders)
		{
			return VwCuadrocomparativoarticuloDao.GetAll(orders);
		}

		public List<VwCuadrocomparativoarticulo> GetAllVwCuadrocomparativoarticulo(string conditions, string orders)
		{
			return VwCuadrocomparativoarticuloDao.GetAll(conditions, orders);
		}

		public VwCuadrocomparativoarticulo GetVwCuadrocomparativoarticulo(int id)
		{
			return VwCuadrocomparativoarticuloDao.Get(id);
		}

		public VwCuadrocomparativoarticulo GetVwCuadrocomparativoarticulo(Expression<Func<VwCuadrocomparativoarticulo, bool>> criteria)
		{
			return VwCuadrocomparativoarticuloDao.Get(criteria);
		}
	}
}

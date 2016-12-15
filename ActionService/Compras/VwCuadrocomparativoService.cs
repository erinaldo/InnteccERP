using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCuadrocomparativo()
		{
			return VwCuadrocomparativoDao.Count();
		}

		public long CountVwCuadrocomparativo(Expression<Func<VwCuadrocomparativo, bool>> criteria)
		{
			return VwCuadrocomparativoDao.Count(criteria);
		}

		public List<VwCuadrocomparativo> GetAllVwCuadrocomparativo()
		{
			return VwCuadrocomparativoDao.GetAll();
		}

		public List<VwCuadrocomparativo> GetAllVwCuadrocomparativo(Expression<Func<VwCuadrocomparativo, bool>> criteria)
		{
			return VwCuadrocomparativoDao.GetAll(criteria);
		}

		public List<VwCuadrocomparativo> GetAllVwCuadrocomparativo(string orders)
		{
			return VwCuadrocomparativoDao.GetAll(orders);
		}

		public List<VwCuadrocomparativo> GetAllVwCuadrocomparativo(string conditions, string orders)
		{
			return VwCuadrocomparativoDao.GetAll(conditions, orders);
		}

		public VwCuadrocomparativo GetVwCuadrocomparativo(int id)
		{
			return VwCuadrocomparativoDao.Get(id);
		}

		public VwCuadrocomparativo GetVwCuadrocomparativo(Expression<Func<VwCuadrocomparativo, bool>> criteria)
		{
			return VwCuadrocomparativoDao.Get(criteria);
		}
	}
}

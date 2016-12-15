using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCuadrocomparativoaaprobar()
		{
			return VwCuadrocomparativoaaprobarDao.Count();
		}

		public long CountVwCuadrocomparativoaaprobar(Expression<Func<VwCuadrocomparativoaaprobar, bool>> criteria)
		{
			return VwCuadrocomparativoaaprobarDao.Count(criteria);
		}

		public List<VwCuadrocomparativoaaprobar> GetAllVwCuadrocomparativoaaprobar()
		{
			return VwCuadrocomparativoaaprobarDao.GetAll();
		}

		public List<VwCuadrocomparativoaaprobar> GetAllVwCuadrocomparativoaaprobar(Expression<Func<VwCuadrocomparativoaaprobar, bool>> criteria)
		{
			return VwCuadrocomparativoaaprobarDao.GetAll(criteria);
		}

		public List<VwCuadrocomparativoaaprobar> GetAllVwCuadrocomparativoaaprobar(string orders)
		{
			return VwCuadrocomparativoaaprobarDao.GetAll(orders);
		}

		public List<VwCuadrocomparativoaaprobar> GetAllVwCuadrocomparativoaaprobar(string conditions, string orders)
		{
			return VwCuadrocomparativoaaprobarDao.GetAll(conditions, orders);
		}

		public VwCuadrocomparativoaaprobar GetVwCuadrocomparativoaaprobar(int id)
		{
			return VwCuadrocomparativoaaprobarDao.Get(id);
		}

		public VwCuadrocomparativoaaprobar GetVwCuadrocomparativoaaprobar(Expression<Func<VwCuadrocomparativoaaprobar, bool>> criteria)
		{
			return VwCuadrocomparativoaaprobarDao.Get(criteria);
		}
	}
}

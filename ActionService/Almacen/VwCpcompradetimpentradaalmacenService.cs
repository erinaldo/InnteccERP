using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpcompradetimpentradaalmacen()
		{
			return VwCpcompradetimpentradaalmacenDao.Count();
		}

		public long CountVwCpcompradetimpentradaalmacen(Expression<Func<VwCpcompradetimpentradaalmacen, bool>> criteria)
		{
			return VwCpcompradetimpentradaalmacenDao.Count(criteria);
		}

		public List<VwCpcompradetimpentradaalmacen> GetAllVwCpcompradetimpentradaalmacen()
		{
			return VwCpcompradetimpentradaalmacenDao.GetAll();
		}

		public List<VwCpcompradetimpentradaalmacen> GetAllVwCpcompradetimpentradaalmacen(Expression<Func<VwCpcompradetimpentradaalmacen, bool>> criteria)
		{
			return VwCpcompradetimpentradaalmacenDao.GetAll(criteria);
		}

		public List<VwCpcompradetimpentradaalmacen> GetAllVwCpcompradetimpentradaalmacen(string orders)
		{
			return VwCpcompradetimpentradaalmacenDao.GetAll(orders);
		}

		public List<VwCpcompradetimpentradaalmacen> GetAllVwCpcompradetimpentradaalmacen(string conditions, string orders)
		{
			return VwCpcompradetimpentradaalmacenDao.GetAll(conditions, orders);
		}

		public VwCpcompradetimpentradaalmacen GetVwCpcompradetimpentradaalmacen(int id)
		{
			return VwCpcompradetimpentradaalmacenDao.Get(id);
		}

		public VwCpcompradetimpentradaalmacen GetVwCpcompradetimpentradaalmacen(Expression<Func<VwCpcompradetimpentradaalmacen, bool>> criteria)
		{
			return VwCpcompradetimpentradaalmacenDao.Get(criteria);
		}
	}
}

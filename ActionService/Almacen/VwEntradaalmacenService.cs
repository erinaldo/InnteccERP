using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEntradaalmacen()
		{
			return VwEntradaalmacenDao.Count();
		}

		public long CountVwEntradaalmacen(Expression<Func<VwEntradaalmacen, bool>> criteria)
		{
			return VwEntradaalmacenDao.Count(criteria);
		}

		public List<VwEntradaalmacen> GetAllVwEntradaalmacen()
		{
			return VwEntradaalmacenDao.GetAll();
		}

		public List<VwEntradaalmacen> GetAllVwEntradaalmacen(Expression<Func<VwEntradaalmacen, bool>> criteria)
		{
			return VwEntradaalmacenDao.GetAll(criteria);
		}

		public List<VwEntradaalmacen> GetAllVwEntradaalmacen(string orders)
		{
			return VwEntradaalmacenDao.GetAll(orders);
		}

		public List<VwEntradaalmacen> GetAllVwEntradaalmacen(string conditions, string orders)
		{
			return VwEntradaalmacenDao.GetAll(conditions, orders);
		}

		public VwEntradaalmacen GetVwEntradaalmacen(int id)
		{
			return VwEntradaalmacenDao.Get(id);
		}

		public VwEntradaalmacen GetVwEntradaalmacen(Expression<Func<VwEntradaalmacen, bool>> criteria)
		{
			return VwEntradaalmacenDao.Get(criteria);
		}
	}
}

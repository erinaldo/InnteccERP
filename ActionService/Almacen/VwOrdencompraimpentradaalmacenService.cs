using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwOrdencompraimpentradaalmacen()
		{
			return VwOrdencompraimpentradaalmacenDao.Count();
		}

		public long CountVwOrdencompraimpentradaalmacen(Expression<Func<VwOrdencompraimpentradaalmacen, bool>> criteria)
		{
			return VwOrdencompraimpentradaalmacenDao.Count(criteria);
		}

		public List<VwOrdencompraimpentradaalmacen> GetAllVwOrdencompraimpentradaalmacen()
		{
			return VwOrdencompraimpentradaalmacenDao.GetAll();
		}

		public List<VwOrdencompraimpentradaalmacen> GetAllVwOrdencompraimpentradaalmacen(Expression<Func<VwOrdencompraimpentradaalmacen, bool>> criteria)
		{
			return VwOrdencompraimpentradaalmacenDao.GetAll(criteria);
		}

		public List<VwOrdencompraimpentradaalmacen> GetAllVwOrdencompraimpentradaalmacen(string orders)
		{
			return VwOrdencompraimpentradaalmacenDao.GetAll(orders);
		}

		public List<VwOrdencompraimpentradaalmacen> GetAllVwOrdencompraimpentradaalmacen(string conditions, string orders)
		{
			return VwOrdencompraimpentradaalmacenDao.GetAll(conditions, orders);
		}

		public VwOrdencompraimpentradaalmacen GetVwOrdencompraimpentradaalmacen(int id)
		{
			return VwOrdencompraimpentradaalmacenDao.Get(id);
		}

		public VwOrdencompraimpentradaalmacen GetVwOrdencompraimpentradaalmacen(Expression<Func<VwOrdencompraimpentradaalmacen, bool>> criteria)
		{
			return VwOrdencompraimpentradaalmacenDao.Get(criteria);
		}
	}
}

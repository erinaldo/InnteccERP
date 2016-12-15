using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSalidaalmacendetimpentradaalmacen()
		{
			return VwSalidaalmacendetimpentradaalmacenDao.Count();
		}

		public long CountVwSalidaalmacendetimpentradaalmacen(Expression<Func<VwSalidaalmacendetimpentradaalmacen, bool>> criteria)
		{
			return VwSalidaalmacendetimpentradaalmacenDao.Count(criteria);
		}

		public List<VwSalidaalmacendetimpentradaalmacen> GetAllVwSalidaalmacendetimpentradaalmacen()
		{
			return VwSalidaalmacendetimpentradaalmacenDao.GetAll();
		}

		public List<VwSalidaalmacendetimpentradaalmacen> GetAllVwSalidaalmacendetimpentradaalmacen(Expression<Func<VwSalidaalmacendetimpentradaalmacen, bool>> criteria)
		{
			return VwSalidaalmacendetimpentradaalmacenDao.GetAll(criteria);
		}

		public List<VwSalidaalmacendetimpentradaalmacen> GetAllVwSalidaalmacendetimpentradaalmacen(string orders)
		{
			return VwSalidaalmacendetimpentradaalmacenDao.GetAll(orders);
		}

		public List<VwSalidaalmacendetimpentradaalmacen> GetAllVwSalidaalmacendetimpentradaalmacen(string conditions, string orders)
		{
			return VwSalidaalmacendetimpentradaalmacenDao.GetAll(conditions, orders);
		}

		public VwSalidaalmacendetimpentradaalmacen GetVwSalidaalmacendetimpentradaalmacen(int id)
		{
			return VwSalidaalmacendetimpentradaalmacenDao.Get(id);
		}

		public VwSalidaalmacendetimpentradaalmacen GetVwSalidaalmacendetimpentradaalmacen(Expression<Func<VwSalidaalmacendetimpentradaalmacen, bool>> criteria)
		{
			return VwSalidaalmacendetimpentradaalmacenDao.Get(criteria);
		}
	}
}

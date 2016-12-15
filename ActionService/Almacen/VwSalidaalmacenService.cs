using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSalidaalmacen()
		{
			return VwSalidaalmacenDao.Count();
		}

		public long CountVwSalidaalmacen(Expression<Func<VwSalidaalmacen, bool>> criteria)
		{
			return VwSalidaalmacenDao.Count(criteria);
		}

		public List<VwSalidaalmacen> GetAllVwSalidaalmacen()
		{
			return VwSalidaalmacenDao.GetAll();
		}

		public List<VwSalidaalmacen> GetAllVwSalidaalmacen(Expression<Func<VwSalidaalmacen, bool>> criteria)
		{
			return VwSalidaalmacenDao.GetAll(criteria);
		}

		public List<VwSalidaalmacen> GetAllVwSalidaalmacen(string orders)
		{
			return VwSalidaalmacenDao.GetAll(orders);
		}

		public List<VwSalidaalmacen> GetAllVwSalidaalmacen(string conditions, string orders)
		{
			return VwSalidaalmacenDao.GetAll(conditions, orders);
		}

		public VwSalidaalmacen GetVwSalidaalmacen(int id)
		{
			return VwSalidaalmacenDao.Get(id);
		}

		public VwSalidaalmacen GetVwSalidaalmacen(Expression<Func<VwSalidaalmacen, bool>> criteria)
		{
			return VwSalidaalmacenDao.Get(criteria);
		}
	}
}

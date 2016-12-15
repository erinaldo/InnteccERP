using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwCpventaimpsalidaalmacen()
		{
			return VwCpventaimpsalidaalmacenDao.Count();
		}

		public long CountVwCpventaimpsalidaalmacen(Expression<Func<VwCpventaimpsalidaalmacen, bool>> criteria)
		{
			return VwCpventaimpsalidaalmacenDao.Count(criteria);
		}

		public List<VwCpventaimpsalidaalmacen> GetAllVwCpventaimpsalidaalmacen()
		{
			return VwCpventaimpsalidaalmacenDao.GetAll();
		}

		public List<VwCpventaimpsalidaalmacen> GetAllVwCpventaimpsalidaalmacen(Expression<Func<VwCpventaimpsalidaalmacen, bool>> criteria)
		{
			return VwCpventaimpsalidaalmacenDao.GetAll(criteria);
		}

		public List<VwCpventaimpsalidaalmacen> GetAllVwCpventaimpsalidaalmacen(string orders)
		{
			return VwCpventaimpsalidaalmacenDao.GetAll(orders);
		}

		public List<VwCpventaimpsalidaalmacen> GetAllVwCpventaimpsalidaalmacen(string conditions, string orders)
		{
			return VwCpventaimpsalidaalmacenDao.GetAll(conditions, orders);
		}

		public VwCpventaimpsalidaalmacen GetVwCpventaimpsalidaalmacen(int id)
		{
			return VwCpventaimpsalidaalmacenDao.Get(id);
		}

		public VwCpventaimpsalidaalmacen GetVwCpventaimpsalidaalmacen(Expression<Func<VwCpventaimpsalidaalmacen, bool>> criteria)
		{
			return VwCpventaimpsalidaalmacenDao.Get(criteria);
		}
	}
}

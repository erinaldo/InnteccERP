using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSalidaalmacendet()
		{
			return VwSalidaalmacendetDao.Count();
		}

		public long CountVwSalidaalmacendet(Expression<Func<VwSalidaalmacendet, bool>> criteria)
		{
			return VwSalidaalmacendetDao.Count(criteria);
		}

		public List<VwSalidaalmacendet> GetAllVwSalidaalmacendet()
		{
			return VwSalidaalmacendetDao.GetAll();
		}

		public List<VwSalidaalmacendet> GetAllVwSalidaalmacendet(Expression<Func<VwSalidaalmacendet, bool>> criteria)
		{
			return VwSalidaalmacendetDao.GetAll(criteria);
		}

		public List<VwSalidaalmacendet> GetAllVwSalidaalmacendet(string orders)
		{
			return VwSalidaalmacendetDao.GetAll(orders);
		}

		public List<VwSalidaalmacendet> GetAllVwSalidaalmacendet(string conditions, string orders)
		{
			return VwSalidaalmacendetDao.GetAll(conditions, orders);
		}

		public VwSalidaalmacendet GetVwSalidaalmacendet(int id)
		{
			return VwSalidaalmacendetDao.Get(id);
		}

		public VwSalidaalmacendet GetVwSalidaalmacendet(Expression<Func<VwSalidaalmacendet, bool>> criteria)
		{
			return VwSalidaalmacendetDao.Get(criteria);
		}
	}
}

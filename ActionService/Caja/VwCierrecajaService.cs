using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCierrecaja()
		{
			return VwCierrecajaDao.Count();
		}

		public long CountVwCierrecaja(Expression<Func<VwCierrecaja, bool>> criteria)
		{
			return VwCierrecajaDao.Count(criteria);
		}

		public List<VwCierrecaja> GetAllVwCierrecaja()
		{
			return VwCierrecajaDao.GetAll();
		}

		public List<VwCierrecaja> GetAllVwCierrecaja(Expression<Func<VwCierrecaja, bool>> criteria)
		{
			return VwCierrecajaDao.GetAll(criteria);
		}

		public List<VwCierrecaja> GetAllVwCierrecaja(string orders)
		{
			return VwCierrecajaDao.GetAll(orders);
		}

		public List<VwCierrecaja> GetAllVwCierrecaja(string conditions, string orders)
		{
			return VwCierrecajaDao.GetAll(conditions, orders);
		}

		public VwCierrecaja GetVwCierrecaja(int id)
		{
			return VwCierrecajaDao.Get(id);
		}

		public VwCierrecaja GetVwCierrecaja(Expression<Func<VwCierrecaja, bool>> criteria)
		{
			return VwCierrecajaDao.Get(criteria);
		}
	}
}

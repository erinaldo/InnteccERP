using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCierrecajaimpresion()
		{
			return VwCierrecajaimpresionDao.Count();
		}

		public long CountVwCierrecajaimpresion(Expression<Func<VwCierrecajaimpresion, bool>> criteria)
		{
			return VwCierrecajaimpresionDao.Count(criteria);
		}

		public List<VwCierrecajaimpresion> GetAllVwCierrecajaimpresion()
		{
			return VwCierrecajaimpresionDao.GetAll();
		}

		public List<VwCierrecajaimpresion> GetAllVwCierrecajaimpresion(Expression<Func<VwCierrecajaimpresion, bool>> criteria)
		{
			return VwCierrecajaimpresionDao.GetAll(criteria);
		}

		public List<VwCierrecajaimpresion> GetAllVwCierrecajaimpresion(string orders)
		{
			return VwCierrecajaimpresionDao.GetAll(orders);
		}

		public List<VwCierrecajaimpresion> GetAllVwCierrecajaimpresion(string conditions, string orders)
		{
			return VwCierrecajaimpresionDao.GetAll(conditions, orders);
		}

		public VwCierrecajaimpresion GetVwCierrecajaimpresion(int id)
		{
			return VwCierrecajaimpresionDao.Get(id);
		}

		public VwCierrecajaimpresion GetVwCierrecajaimpresion(Expression<Func<VwCierrecajaimpresion, bool>> criteria)
		{
			return VwCierrecajaimpresionDao.Get(criteria);
		}
	}
}

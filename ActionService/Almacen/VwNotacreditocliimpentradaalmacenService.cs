using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwNotacreditocliimpentradaalmacen()
		{
			return VwNotacreditocliimpentradaalmacenDao.Count();
		}

		public long CountVwNotacreditocliimpentradaalmacen(Expression<Func<VwNotacreditocliimpentradaalmacen, bool>> criteria)
		{
			return VwNotacreditocliimpentradaalmacenDao.Count(criteria);
		}

		public List<VwNotacreditocliimpentradaalmacen> GetAllVwNotacreditocliimpentradaalmacen()
		{
			return VwNotacreditocliimpentradaalmacenDao.GetAll();
		}

		public List<VwNotacreditocliimpentradaalmacen> GetAllVwNotacreditocliimpentradaalmacen(Expression<Func<VwNotacreditocliimpentradaalmacen, bool>> criteria)
		{
			return VwNotacreditocliimpentradaalmacenDao.GetAll(criteria);
		}

		public List<VwNotacreditocliimpentradaalmacen> GetAllVwNotacreditocliimpentradaalmacen(string orders)
		{
			return VwNotacreditocliimpentradaalmacenDao.GetAll(orders);
		}

		public List<VwNotacreditocliimpentradaalmacen> GetAllVwNotacreditocliimpentradaalmacen(string conditions, string orders)
		{
			return VwNotacreditocliimpentradaalmacenDao.GetAll(conditions, orders);
		}

		public VwNotacreditocliimpentradaalmacen GetVwNotacreditocliimpentradaalmacen(int id)
		{
			return VwNotacreditocliimpentradaalmacenDao.Get(id);
		}

		public VwNotacreditocliimpentradaalmacen GetVwNotacreditocliimpentradaalmacen(Expression<Func<VwNotacreditocliimpentradaalmacen, bool>> criteria)
		{
			return VwNotacreditocliimpentradaalmacenDao.Get(criteria);
		}
	}
}

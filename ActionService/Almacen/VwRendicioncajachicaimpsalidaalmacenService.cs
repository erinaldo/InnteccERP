using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRendicioncajachicaimpsalidaalmacen()
		{
			return VwRendicioncajachicaimpsalidaalmacenDao.Count();
		}

		public long CountVwRendicioncajachicaimpsalidaalmacen(Expression<Func<VwRendicioncajachicaimpsalidaalmacen, bool>> criteria)
		{
			return VwRendicioncajachicaimpsalidaalmacenDao.Count(criteria);
		}

		public List<VwRendicioncajachicaimpsalidaalmacen> GetAllVwRendicioncajachicaimpsalidaalmacen()
		{
			return VwRendicioncajachicaimpsalidaalmacenDao.GetAll();
		}

		public List<VwRendicioncajachicaimpsalidaalmacen> GetAllVwRendicioncajachicaimpsalidaalmacen(Expression<Func<VwRendicioncajachicaimpsalidaalmacen, bool>> criteria)
		{
			return VwRendicioncajachicaimpsalidaalmacenDao.GetAll(criteria);
		}

		public List<VwRendicioncajachicaimpsalidaalmacen> GetAllVwRendicioncajachicaimpsalidaalmacen(string orders)
		{
			return VwRendicioncajachicaimpsalidaalmacenDao.GetAll(orders);
		}

		public List<VwRendicioncajachicaimpsalidaalmacen> GetAllVwRendicioncajachicaimpsalidaalmacen(string conditions, string orders)
		{
			return VwRendicioncajachicaimpsalidaalmacenDao.GetAll(conditions, orders);
		}

		public VwRendicioncajachicaimpsalidaalmacen GetVwRendicioncajachicaimpsalidaalmacen(int id)
		{
			return VwRendicioncajachicaimpsalidaalmacenDao.Get(id);
		}

		public VwRendicioncajachicaimpsalidaalmacen GetVwRendicioncajachicaimpsalidaalmacen(Expression<Func<VwRendicioncajachicaimpsalidaalmacen, bool>> criteria)
		{
			return VwRendicioncajachicaimpsalidaalmacenDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSalidaalmacendetverificacioncantidad()
		{
			return VwSalidaalmacendetverificacioncantidadDao.Count();
		}

		public long CountVwSalidaalmacendetverificacioncantidad(Expression<Func<VwSalidaalmacendetverificacioncantidad, bool>> criteria)
		{
			return VwSalidaalmacendetverificacioncantidadDao.Count(criteria);
		}

		public List<VwSalidaalmacendetverificacioncantidad> GetAllVwSalidaalmacendetverificacioncantidad()
		{
			return VwSalidaalmacendetverificacioncantidadDao.GetAll();
		}

		public List<VwSalidaalmacendetverificacioncantidad> GetAllVwSalidaalmacendetverificacioncantidad(Expression<Func<VwSalidaalmacendetverificacioncantidad, bool>> criteria)
		{
			return VwSalidaalmacendetverificacioncantidadDao.GetAll(criteria);
		}

		public List<VwSalidaalmacendetverificacioncantidad> GetAllVwSalidaalmacendetverificacioncantidad(string orders)
		{
			return VwSalidaalmacendetverificacioncantidadDao.GetAll(orders);
		}

		public List<VwSalidaalmacendetverificacioncantidad> GetAllVwSalidaalmacendetverificacioncantidad(string conditions, string orders)
		{
			return VwSalidaalmacendetverificacioncantidadDao.GetAll(conditions, orders);
		}

		public VwSalidaalmacendetverificacioncantidad GetVwSalidaalmacendetverificacioncantidad(int id)
		{
			return VwSalidaalmacendetverificacioncantidadDao.Get(id);
		}

		public VwSalidaalmacendetverificacioncantidad GetVwSalidaalmacendetverificacioncantidad(Expression<Func<VwSalidaalmacendetverificacioncantidad, bool>> criteria)
		{
			return VwSalidaalmacendetverificacioncantidadDao.Get(criteria);
		}
	}
}

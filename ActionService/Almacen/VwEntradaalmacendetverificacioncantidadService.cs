using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEntradaalmacendetverificacioncantidad()
		{
			return VwEntradaalmacendetverificacioncantidadDao.Count();
		}

		public long CountVwEntradaalmacendetverificacioncantidad(Expression<Func<VwEntradaalmacendetverificacioncantidad, bool>> criteria)
		{
			return VwEntradaalmacendetverificacioncantidadDao.Count(criteria);
		}

		public List<VwEntradaalmacendetverificacioncantidad> GetAllVwEntradaalmacendetverificacioncantidad()
		{
			return VwEntradaalmacendetverificacioncantidadDao.GetAll();
		}

		public List<VwEntradaalmacendetverificacioncantidad> GetAllVwEntradaalmacendetverificacioncantidad(Expression<Func<VwEntradaalmacendetverificacioncantidad, bool>> criteria)
		{
			return VwEntradaalmacendetverificacioncantidadDao.GetAll(criteria);
		}

		public List<VwEntradaalmacendetverificacioncantidad> GetAllVwEntradaalmacendetverificacioncantidad(string orders)
		{
			return VwEntradaalmacendetverificacioncantidadDao.GetAll(orders);
		}

		public List<VwEntradaalmacendetverificacioncantidad> GetAllVwEntradaalmacendetverificacioncantidad(string conditions, string orders)
		{
			return VwEntradaalmacendetverificacioncantidadDao.GetAll(conditions, orders);
		}

		public VwEntradaalmacendetverificacioncantidad GetVwEntradaalmacendetverificacioncantidad(int id)
		{
			return VwEntradaalmacendetverificacioncantidadDao.Get(id);
		}

		public VwEntradaalmacendetverificacioncantidad GetVwEntradaalmacendetverificacioncantidad(Expression<Func<VwEntradaalmacendetverificacioncantidad, bool>> criteria)
		{
			return VwEntradaalmacendetverificacioncantidadDao.Get(criteria);
		}
	}
}

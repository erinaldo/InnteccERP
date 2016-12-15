using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwMantenimiento()
		{
			return VwMantenimientoDao.Count();
		}

		public long CountVwMantenimiento(Expression<Func<VwMantenimiento, bool>> criteria)
		{
			return VwMantenimientoDao.Count(criteria);
		}

		public List<VwMantenimiento> GetAllVwMantenimiento()
		{
			return VwMantenimientoDao.GetAll();
		}

		public List<VwMantenimiento> GetAllVwMantenimiento(Expression<Func<VwMantenimiento, bool>> criteria)
		{
			return VwMantenimientoDao.GetAll(criteria);
		}

		public List<VwMantenimiento> GetAllVwMantenimiento(string orders)
		{
			return VwMantenimientoDao.GetAll(orders);
		}

		public List<VwMantenimiento> GetAllVwMantenimiento(string conditions, string orders)
		{
			return VwMantenimientoDao.GetAll(conditions, orders);
		}

		public VwMantenimiento GetVwMantenimiento(int id)
		{
			return VwMantenimientoDao.Get(id);
		}

		public VwMantenimiento GetVwMantenimiento(Expression<Func<VwMantenimiento, bool>> criteria)
		{
			return VwMantenimientoDao.Get(criteria);
		}
	}
}

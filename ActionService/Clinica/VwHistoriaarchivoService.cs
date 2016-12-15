using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwHistoriaarchivo()
		{
			return VwHistoriaarchivoDao.Count();
		}

		public long CountVwHistoriaarchivo(Expression<Func<VwHistoriaarchivo, bool>> criteria)
		{
			return VwHistoriaarchivoDao.Count(criteria);
		}

		public List<VwHistoriaarchivo> GetAllVwHistoriaarchivo()
		{
			return VwHistoriaarchivoDao.GetAll();
		}

		public List<VwHistoriaarchivo> GetAllVwHistoriaarchivo(Expression<Func<VwHistoriaarchivo, bool>> criteria)
		{
			return VwHistoriaarchivoDao.GetAll(criteria);
		}

		public List<VwHistoriaarchivo> GetAllVwHistoriaarchivo(string orders)
		{
			return VwHistoriaarchivoDao.GetAll(orders);
		}

		public List<VwHistoriaarchivo> GetAllVwHistoriaarchivo(string conditions, string orders)
		{
			return VwHistoriaarchivoDao.GetAll(conditions, orders);
		}

		public VwHistoriaarchivo GetVwHistoriaarchivo(int id)
		{
			return VwHistoriaarchivoDao.Get(id);
		}

		public VwHistoriaarchivo GetVwHistoriaarchivo(Expression<Func<VwHistoriaarchivo, bool>> criteria)
		{
			return VwHistoriaarchivoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCuadrocomparativomodeloautorizacion()
		{
			return VwCuadrocomparativomodeloautorizacionDao.Count();
		}

		public long CountVwCuadrocomparativomodeloautorizacion(Expression<Func<VwCuadrocomparativomodeloautorizacion, bool>> criteria)
		{
			return VwCuadrocomparativomodeloautorizacionDao.Count(criteria);
		}

		public List<VwCuadrocomparativomodeloautorizacion> GetAllVwCuadrocomparativomodeloautorizacion()
		{
			return VwCuadrocomparativomodeloautorizacionDao.GetAll();
		}

		public List<VwCuadrocomparativomodeloautorizacion> GetAllVwCuadrocomparativomodeloautorizacion(Expression<Func<VwCuadrocomparativomodeloautorizacion, bool>> criteria)
		{
			return VwCuadrocomparativomodeloautorizacionDao.GetAll(criteria);
		}

		public List<VwCuadrocomparativomodeloautorizacion> GetAllVwCuadrocomparativomodeloautorizacion(string orders)
		{
			return VwCuadrocomparativomodeloautorizacionDao.GetAll(orders);
		}

		public List<VwCuadrocomparativomodeloautorizacion> GetAllVwCuadrocomparativomodeloautorizacion(string conditions, string orders)
		{
			return VwCuadrocomparativomodeloautorizacionDao.GetAll(conditions, orders);
		}

		public VwCuadrocomparativomodeloautorizacion GetVwCuadrocomparativomodeloautorizacion(int id)
		{
			return VwCuadrocomparativomodeloautorizacionDao.Get(id);
		}

		public VwCuadrocomparativomodeloautorizacion GetVwCuadrocomparativomodeloautorizacion(Expression<Func<VwCuadrocomparativomodeloautorizacion, bool>> criteria)
		{
			return VwCuadrocomparativomodeloautorizacionDao.Get(criteria);
		}
	}
}

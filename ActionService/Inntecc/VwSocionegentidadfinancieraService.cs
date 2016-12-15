using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSocionegentidadfinanciera()
		{
			return VwSocionegentidadfinancieraDao.Count();
		}

		public long CountVwSocionegentidadfinanciera(Expression<Func<VwSocionegentidadfinanciera, bool>> criteria)
		{
			return VwSocionegentidadfinancieraDao.Count(criteria);
		}

		public List<VwSocionegentidadfinanciera> GetAllVwSocionegentidadfinanciera()
		{
			return VwSocionegentidadfinancieraDao.GetAll();
		}

		public List<VwSocionegentidadfinanciera> GetAllVwSocionegentidadfinanciera(Expression<Func<VwSocionegentidadfinanciera, bool>> criteria)
		{
			return VwSocionegentidadfinancieraDao.GetAll(criteria);
		}

		public List<VwSocionegentidadfinanciera> GetAllVwSocionegentidadfinanciera(string orders)
		{
			return VwSocionegentidadfinancieraDao.GetAll(orders);
		}

		public List<VwSocionegentidadfinanciera> GetAllVwSocionegentidadfinanciera(string conditions, string orders)
		{
			return VwSocionegentidadfinancieraDao.GetAll(conditions, orders);
		}

		public VwSocionegentidadfinanciera GetVwSocionegentidadfinanciera(int id)
		{
			return VwSocionegentidadfinancieraDao.Get(id);
		}

		public VwSocionegentidadfinanciera GetVwSocionegentidadfinanciera(Expression<Func<VwSocionegentidadfinanciera, bool>> criteria)
		{
			return VwSocionegentidadfinancieraDao.Get(criteria);
		}
	}
}

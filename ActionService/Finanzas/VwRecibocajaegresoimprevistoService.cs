using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRecibocajaegresoimprevisto()
		{
			return VwRecibocajaegresoimprevistoDao.Count();
		}

		public long CountVwRecibocajaegresoimprevisto(Expression<Func<VwRecibocajaegresoimprevisto, bool>> criteria)
		{
			return VwRecibocajaegresoimprevistoDao.Count(criteria);
		}

		public List<VwRecibocajaegresoimprevisto> GetAllVwRecibocajaegresoimprevisto()
		{
			return VwRecibocajaegresoimprevistoDao.GetAll();
		}

		public List<VwRecibocajaegresoimprevisto> GetAllVwRecibocajaegresoimprevisto(Expression<Func<VwRecibocajaegresoimprevisto, bool>> criteria)
		{
			return VwRecibocajaegresoimprevistoDao.GetAll(criteria);
		}

		public List<VwRecibocajaegresoimprevisto> GetAllVwRecibocajaegresoimprevisto(string orders)
		{
			return VwRecibocajaegresoimprevistoDao.GetAll(orders);
		}

		public List<VwRecibocajaegresoimprevisto> GetAllVwRecibocajaegresoimprevisto(string conditions, string orders)
		{
			return VwRecibocajaegresoimprevistoDao.GetAll(conditions, orders);
		}

		public VwRecibocajaegresoimprevisto GetVwRecibocajaegresoimprevisto(int id)
		{
			return VwRecibocajaegresoimprevistoDao.Get(id);
		}

		public VwRecibocajaegresoimprevisto GetVwRecibocajaegresoimprevisto(Expression<Func<VwRecibocajaegresoimprevisto, bool>> criteria)
		{
			return VwRecibocajaegresoimprevistoDao.Get(criteria);
		}
	}
}

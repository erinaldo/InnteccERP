using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwRecibocajaingresoimprevisto()
		{
			return VwRecibocajaingresoimprevistoDao.Count();
		}

		public long CountVwRecibocajaingresoimprevisto(Expression<Func<VwRecibocajaingresoimprevisto, bool>> criteria)
		{
			return VwRecibocajaingresoimprevistoDao.Count(criteria);
		}

		public List<VwRecibocajaingresoimprevisto> GetAllVwRecibocajaingresoimprevisto()
		{
			return VwRecibocajaingresoimprevistoDao.GetAll();
		}

		public List<VwRecibocajaingresoimprevisto> GetAllVwRecibocajaingresoimprevisto(Expression<Func<VwRecibocajaingresoimprevisto, bool>> criteria)
		{
			return VwRecibocajaingresoimprevistoDao.GetAll(criteria);
		}

		public List<VwRecibocajaingresoimprevisto> GetAllVwRecibocajaingresoimprevisto(string orders)
		{
			return VwRecibocajaingresoimprevistoDao.GetAll(orders);
		}

		public List<VwRecibocajaingresoimprevisto> GetAllVwRecibocajaingresoimprevisto(string conditions, string orders)
		{
			return VwRecibocajaingresoimprevistoDao.GetAll(conditions, orders);
		}

		public VwRecibocajaingresoimprevisto GetVwRecibocajaingresoimprevisto(int id)
		{
			return VwRecibocajaingresoimprevistoDao.Get(id);
		}

		public VwRecibocajaingresoimprevisto GetVwRecibocajaingresoimprevisto(Expression<Func<VwRecibocajaingresoimprevisto, bool>> criteria)
		{
			return VwRecibocajaingresoimprevistoDao.Get(criteria);
		}
	}
}

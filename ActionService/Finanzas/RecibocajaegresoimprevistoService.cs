using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRecibocajaegresoimprevisto()
		{
			return RecibocajaegresoimprevistoDao.Count();
		}

		public long CountRecibocajaegresoimprevisto(Expression<Func<Recibocajaegresoimprevisto, bool>> criteria)
		{
			return RecibocajaegresoimprevistoDao.Count(criteria);
		}

		public int SaveRecibocajaegresoimprevisto(Recibocajaegresoimprevisto entity)
		{
			return RecibocajaegresoimprevistoDao.Save(entity);
		}

		public void UpdateRecibocajaegresoimprevisto(Recibocajaegresoimprevisto entity)
		{
			RecibocajaegresoimprevistoDao.Update(entity);
		}

		public void DeleteRecibocajaegresoimprevisto(int id)
		{
			RecibocajaegresoimprevistoDao.Delete(id);
		}

		public List<Recibocajaegresoimprevisto> GetAllRecibocajaegresoimprevisto()
		{
			return RecibocajaegresoimprevistoDao.GetAll();
		}

		public List<Recibocajaegresoimprevisto> GetAllRecibocajaegresoimprevisto(Expression<Func<Recibocajaegresoimprevisto, bool>> criteria)
		{
			return RecibocajaegresoimprevistoDao.GetAll(criteria);
		}

		public List<Recibocajaegresoimprevisto> GetAllRecibocajaegresoimprevisto(string orders)
		{
			return RecibocajaegresoimprevistoDao.GetAll(orders);
		}

		public List<Recibocajaegresoimprevisto> GetAllRecibocajaegresoimprevisto(string conditions, string orders)
		{
			return RecibocajaegresoimprevistoDao.GetAll(conditions, orders);
		}

		public Recibocajaegresoimprevisto GetRecibocajaegresoimprevisto(int id)
		{
			return RecibocajaegresoimprevistoDao.Get(id);
		}

		public Recibocajaegresoimprevisto GetRecibocajaegresoimprevisto(Expression<Func<Recibocajaegresoimprevisto, bool>> criteria)
		{
			return RecibocajaegresoimprevistoDao.Get(criteria);
		}
	}
}

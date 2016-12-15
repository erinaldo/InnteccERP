using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRecibocajaingresoimprevisto()
		{
			return RecibocajaingresoimprevistoDao.Count();
		}

		public long CountRecibocajaingresoimprevisto(Expression<Func<Recibocajaingresoimprevisto, bool>> criteria)
		{
			return RecibocajaingresoimprevistoDao.Count(criteria);
		}

		public int SaveRecibocajaingresoimprevisto(Recibocajaingresoimprevisto entity)
		{
			return RecibocajaingresoimprevistoDao.Save(entity);
		}

		public void UpdateRecibocajaingresoimprevisto(Recibocajaingresoimprevisto entity)
		{
			RecibocajaingresoimprevistoDao.Update(entity);
		}

		public void DeleteRecibocajaingresoimprevisto(int id)
		{
			RecibocajaingresoimprevistoDao.Delete(id);
		}

		public List<Recibocajaingresoimprevisto> GetAllRecibocajaingresoimprevisto()
		{
			return RecibocajaingresoimprevistoDao.GetAll();
		}

		public List<Recibocajaingresoimprevisto> GetAllRecibocajaingresoimprevisto(Expression<Func<Recibocajaingresoimprevisto, bool>> criteria)
		{
			return RecibocajaingresoimprevistoDao.GetAll(criteria);
		}

		public List<Recibocajaingresoimprevisto> GetAllRecibocajaingresoimprevisto(string orders)
		{
			return RecibocajaingresoimprevistoDao.GetAll(orders);
		}

		public List<Recibocajaingresoimprevisto> GetAllRecibocajaingresoimprevisto(string conditions, string orders)
		{
			return RecibocajaingresoimprevistoDao.GetAll(conditions, orders);
		}

		public Recibocajaingresoimprevisto GetRecibocajaingresoimprevisto(int id)
		{
			return RecibocajaingresoimprevistoDao.Get(id);
		}

		public Recibocajaingresoimprevisto GetRecibocajaingresoimprevisto(Expression<Func<Recibocajaingresoimprevisto, bool>> criteria)
		{
			return RecibocajaingresoimprevistoDao.Get(criteria);
		}
	}
}

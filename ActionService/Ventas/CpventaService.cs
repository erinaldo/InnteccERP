using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCpventa()
		{
			return CpventaDao.Count();
		}

		public long CountCpventa(Expression<Func<Cpventa, bool>> criteria)
		{
			return CpventaDao.Count(criteria);
		}

		public int SaveCpventa(Cpventa entity)
		{
			return CpventaDao.Save(entity);
		}

		public void UpdateCpventa(Cpventa entity)
		{
			CpventaDao.Update(entity);
		}

		public void DeleteCpventa(int id)
		{
			CpventaDao.Delete(id);
		}

		public List<Cpventa> GetAllCpventa()
		{
			return CpventaDao.GetAll();
		}

		public List<Cpventa> GetAllCpventa(Expression<Func<Cpventa, bool>> criteria)
		{
			return CpventaDao.GetAll(criteria);
		}

		public List<Cpventa> GetAllCpventa(string orders)
		{
			return CpventaDao.GetAll(orders);
		}

		public List<Cpventa> GetAllCpventa(string conditions, string orders)
		{
			return CpventaDao.GetAll(conditions, orders);
		}

		public Cpventa GetCpventa(int id)
		{
			return CpventaDao.Get(id);
		}

		public Cpventa GetCpventa(Expression<Func<Cpventa, bool>> criteria)
		{
			return CpventaDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCpventadet()
		{
			return CpventadetDao.Count();
		}

		public long CountCpventadet(Expression<Func<Cpventadet, bool>> criteria)
		{
			return CpventadetDao.Count(criteria);
		}

		public int SaveCpventadet(Cpventadet entity)
		{
			return CpventadetDao.Save(entity);
		}

		public void UpdateCpventadet(Cpventadet entity)
		{
			CpventadetDao.Update(entity);
		}

		public void DeleteCpventadet(int id)
		{
			CpventadetDao.Delete(id);
		}

		public List<Cpventadet> GetAllCpventadet()
		{
			return CpventadetDao.GetAll();
		}

		public List<Cpventadet> GetAllCpventadet(Expression<Func<Cpventadet, bool>> criteria)
		{
			return CpventadetDao.GetAll(criteria);
		}

		public List<Cpventadet> GetAllCpventadet(string orders)
		{
			return CpventadetDao.GetAll(orders);
		}

		public List<Cpventadet> GetAllCpventadet(string conditions, string orders)
		{
			return CpventadetDao.GetAll(conditions, orders);
		}

		public Cpventadet GetCpventadet(int id)
		{
			return CpventadetDao.Get(id);
		}

		public Cpventadet GetCpventadet(Expression<Func<Cpventadet, bool>> criteria)
		{
			return CpventadetDao.Get(criteria);
		}
	}
}

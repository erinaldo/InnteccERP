using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountCpventadetserie()
		{
			return CpventadetserieDao.Count();
		}

		public long CountCpventadetserie(Expression<Func<Cpventadetserie, bool>> criteria)
		{
			return CpventadetserieDao.Count(criteria);
		}

		public int SaveCpventadetserie(Cpventadetserie entity)
		{
			return CpventadetserieDao.Save(entity);
		}

		public void UpdateCpventadetserie(Cpventadetserie entity)
		{
			CpventadetserieDao.Update(entity);
		}

		public void DeleteCpventadetserie(int id)
		{
			CpventadetserieDao.Delete(id);
		}

		public List<Cpventadetserie> GetAllCpventadetserie()
		{
			return CpventadetserieDao.GetAll();
		}

		public List<Cpventadetserie> GetAllCpventadetserie(Expression<Func<Cpventadetserie, bool>> criteria)
		{
			return CpventadetserieDao.GetAll(criteria);
		}

		public List<Cpventadetserie> GetAllCpventadetserie(string orders)
		{
			return CpventadetserieDao.GetAll(orders);
		}

		public List<Cpventadetserie> GetAllCpventadetserie(string conditions, string orders)
		{
			return CpventadetserieDao.GetAll(conditions, orders);
		}

		public Cpventadetserie GetCpventadetserie(int id)
		{
			return CpventadetserieDao.Get(id);
		}

		public Cpventadetserie GetCpventadetserie(Expression<Func<Cpventadetserie, bool>> criteria)
		{
			return CpventadetserieDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCptooperacion()
		{
			return CptooperacionDao.Count();
		}

		public long CountCptooperacion(Expression<Func<Cptooperacion, bool>> criteria)
		{
			return CptooperacionDao.Count(criteria);
		}

		public int SaveCptooperacion(Cptooperacion entity)
		{
			return CptooperacionDao.Save(entity);
		}

		public void UpdateCptooperacion(Cptooperacion entity)
		{
			CptooperacionDao.Update(entity);
		}

		public void DeleteCptooperacion(int id)
		{
			CptooperacionDao.Delete(id);
		}

		public List<Cptooperacion> GetAllCptooperacion()
		{
			return CptooperacionDao.GetAll();
		}

		public List<Cptooperacion> GetAllCptooperacion(Expression<Func<Cptooperacion, bool>> criteria)
		{
			return CptooperacionDao.GetAll(criteria);
		}

		public List<Cptooperacion> GetAllCptooperacion(string orders)
		{
			return CptooperacionDao.GetAll(orders);
		}

		public List<Cptooperacion> GetAllCptooperacion(string conditions, string orders)
		{
			return CptooperacionDao.GetAll(conditions, orders);
		}

		public Cptooperacion GetCptooperacion(int id)
		{
			return CptooperacionDao.Get(id);
		}

		public Cptooperacion GetCptooperacion(Expression<Func<Cptooperacion, bool>> criteria)
		{
			return CptooperacionDao.Get(criteria);
		}
	}
}

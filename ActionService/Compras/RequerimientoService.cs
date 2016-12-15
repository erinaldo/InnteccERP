using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRequerimiento()
		{
			return RequerimientoDao.Count();
		}

		public long CountRequerimiento(Expression<Func<Requerimiento, bool>> criteria)
		{
			return RequerimientoDao.Count(criteria);
		}

		public int SaveRequerimiento(Requerimiento entity)
		{
			return RequerimientoDao.Save(entity);
		}

		public void UpdateRequerimiento(Requerimiento entity)
		{
			RequerimientoDao.Update(entity);
		}

		public void DeleteRequerimiento(int id)
		{
			RequerimientoDao.Delete(id);
		}

		public List<Requerimiento> GetAllRequerimiento()
		{
			return RequerimientoDao.GetAll();
		}

		public List<Requerimiento> GetAllRequerimiento(Expression<Func<Requerimiento, bool>> criteria)
		{
			return RequerimientoDao.GetAll(criteria);
		}

		public List<Requerimiento> GetAllRequerimiento(string orders)
		{
			return RequerimientoDao.GetAll(orders);
		}

		public List<Requerimiento> GetAllRequerimiento(string conditions, string orders)
		{
			return RequerimientoDao.GetAll(conditions, orders);
		}

		public Requerimiento GetRequerimiento(int id)
		{
			return RequerimientoDao.Get(id);
		}

		public Requerimiento GetRequerimiento(Expression<Func<Requerimiento, bool>> criteria)
		{
			return RequerimientoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCierrecajadet()
		{
			return CierrecajadetDao.Count();
		}

		public long CountCierrecajadet(Expression<Func<Cierrecajadet, bool>> criteria)
		{
			return CierrecajadetDao.Count(criteria);
		}

		public int SaveCierrecajadet(Cierrecajadet entity)
		{
			return CierrecajadetDao.Save(entity);
		}

		public void UpdateCierrecajadet(Cierrecajadet entity)
		{
			CierrecajadetDao.Update(entity);
		}

		public void DeleteCierrecajadet(int id)
		{
			CierrecajadetDao.Delete(id);
		}

		public List<Cierrecajadet> GetAllCierrecajadet()
		{
			return CierrecajadetDao.GetAll();
		}

		public List<Cierrecajadet> GetAllCierrecajadet(Expression<Func<Cierrecajadet, bool>> criteria)
		{
			return CierrecajadetDao.GetAll(criteria);
		}

		public List<Cierrecajadet> GetAllCierrecajadet(string orders)
		{
			return CierrecajadetDao.GetAll(orders);
		}

		public List<Cierrecajadet> GetAllCierrecajadet(string conditions, string orders)
		{
			return CierrecajadetDao.GetAll(conditions, orders);
		}

		public Cierrecajadet GetCierrecajadet(int id)
		{
			return CierrecajadetDao.Get(id);
		}

		public Cierrecajadet GetCierrecajadet(Expression<Func<Cierrecajadet, bool>> criteria)
		{
			return CierrecajadetDao.Get(criteria);
		}
	}
}

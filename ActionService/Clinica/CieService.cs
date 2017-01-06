using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountCie()
		{
			return CieDao.Count();
		}

		public long CountCie(Expression<Func<Cie, bool>> criteria)
		{
			return CieDao.Count(criteria);
		}

		public int SaveCie(Cie entity)
		{
			return CieDao.Save(entity);
		}

		public void UpdateCie(Cie entity)
		{
			CieDao.Update(entity);
		}

		public void DeleteCie(int id)
		{
			CieDao.Delete(id);
		}

		public List<Cie> GetAllCie()
		{
			return CieDao.GetAll();
		}

		public List<Cie> GetAllCie(Expression<Func<Cie, bool>> criteria)
		{
			return CieDao.GetAll(criteria);
		}

		public List<Cie> GetAllCie(string orders)
		{
			return CieDao.GetAll(orders);
		}

		public List<Cie> GetAllCie(string conditions, string orders)
		{
			return CieDao.GetAll(conditions, orders);
		}

		public Cie GetCie(int id)
		{
			return CieDao.Get(id);
		}

		public Cie GetCie(Expression<Func<Cie, bool>> criteria)
		{
			return CieDao.Get(criteria);
		}
	}
}

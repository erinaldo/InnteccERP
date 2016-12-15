using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSocionegociogarantia()
		{
			return SocionegociogarantiaDao.Count();
		}

		public long CountSocionegociogarantia(Expression<Func<Socionegociogarantia, bool>> criteria)
		{
			return SocionegociogarantiaDao.Count(criteria);
		}

		public int SaveSocionegociogarantia(Socionegociogarantia entity)
		{
			return SocionegociogarantiaDao.Save(entity);
		}

		public void UpdateSocionegociogarantia(Socionegociogarantia entity)
		{
			SocionegociogarantiaDao.Update(entity);
		}

		public void DeleteSocionegociogarantia(int id)
		{
			SocionegociogarantiaDao.Delete(id);
		}

		public List<Socionegociogarantia> GetAllSocionegociogarantia()
		{
			return SocionegociogarantiaDao.GetAll();
		}

		public List<Socionegociogarantia> GetAllSocionegociogarantia(Expression<Func<Socionegociogarantia, bool>> criteria)
		{
			return SocionegociogarantiaDao.GetAll(criteria);
		}

		public List<Socionegociogarantia> GetAllSocionegociogarantia(string orders)
		{
			return SocionegociogarantiaDao.GetAll(orders);
		}

		public List<Socionegociogarantia> GetAllSocionegociogarantia(string conditions, string orders)
		{
			return SocionegociogarantiaDao.GetAll(conditions, orders);
		}

		public Socionegociogarantia GetSocionegociogarantia(int id)
		{
			return SocionegociogarantiaDao.Get(id);
		}

		public Socionegociogarantia GetSocionegociogarantia(Expression<Func<Socionegociogarantia, bool>> criteria)
		{
			return SocionegociogarantiaDao.Get(criteria);
		}
	}
}

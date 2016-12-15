using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountGrupousuarioitem()
		{
			return GrupousuarioitemDao.Count();
		}

		public long CountGrupousuarioitem(Expression<Func<Grupousuarioitem, bool>> criteria)
		{
			return GrupousuarioitemDao.Count(criteria);
		}

		public int SaveGrupousuarioitem(Grupousuarioitem entity)
		{
			return GrupousuarioitemDao.Save(entity);
		}

		public void UpdateGrupousuarioitem(Grupousuarioitem entity)
		{
			GrupousuarioitemDao.Update(entity);
		}

		public void DeleteGrupousuarioitem(int id)
		{
			GrupousuarioitemDao.Delete(id);
		}

		public List<Grupousuarioitem> GetAllGrupousuarioitem()
		{
			return GrupousuarioitemDao.GetAll();
		}

		public List<Grupousuarioitem> GetAllGrupousuarioitem(Expression<Func<Grupousuarioitem, bool>> criteria)
		{
			return GrupousuarioitemDao.GetAll(criteria);
		}

		public List<Grupousuarioitem> GetAllGrupousuarioitem(string orders)
		{
			return GrupousuarioitemDao.GetAll(orders);
		}

		public List<Grupousuarioitem> GetAllGrupousuarioitem(string conditions, string orders)
		{
			return GrupousuarioitemDao.GetAll(conditions, orders);
		}

		public Grupousuarioitem GetGrupousuarioitem(int id)
		{
			return GrupousuarioitemDao.Get(id);
		}

		public Grupousuarioitem GetGrupousuarioitem(Expression<Func<Grupousuarioitem, bool>> criteria)
		{
			return GrupousuarioitemDao.Get(criteria);
		}
	}
}

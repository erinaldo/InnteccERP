using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRendicioncajachicadet()
		{
			return RendicioncajachicadetDao.Count();
		}

		public long CountRendicioncajachicadet(Expression<Func<Rendicioncajachicadet, bool>> criteria)
		{
			return RendicioncajachicadetDao.Count(criteria);
		}

		public int SaveRendicioncajachicadet(Rendicioncajachicadet entity)
		{
			return RendicioncajachicadetDao.Save(entity);
		}

		public void UpdateRendicioncajachicadet(Rendicioncajachicadet entity)
		{
			RendicioncajachicadetDao.Update(entity);
		}

		public void DeleteRendicioncajachicadet(int id)
		{
			RendicioncajachicadetDao.Delete(id);
		}

		public List<Rendicioncajachicadet> GetAllRendicioncajachicadet()
		{
			return RendicioncajachicadetDao.GetAll();
		}

		public List<Rendicioncajachicadet> GetAllRendicioncajachicadet(Expression<Func<Rendicioncajachicadet, bool>> criteria)
		{
			return RendicioncajachicadetDao.GetAll(criteria);
		}

		public List<Rendicioncajachicadet> GetAllRendicioncajachicadet(string orders)
		{
			return RendicioncajachicadetDao.GetAll(orders);
		}

		public List<Rendicioncajachicadet> GetAllRendicioncajachicadet(string conditions, string orders)
		{
			return RendicioncajachicadetDao.GetAll(conditions, orders);
		}

		public Rendicioncajachicadet GetRendicioncajachicadet(int id)
		{
			return RendicioncajachicadetDao.Get(id);
		}

		public Rendicioncajachicadet GetRendicioncajachicadet(Expression<Func<Rendicioncajachicadet, bool>> criteria)
		{
			return RendicioncajachicadetDao.Get(criteria);
		}
	}
}

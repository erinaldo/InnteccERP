using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRendicioncajachica()
		{
			return RendicioncajachicaDao.Count();
		}

		public long CountRendicioncajachica(Expression<Func<Rendicioncajachica, bool>> criteria)
		{
			return RendicioncajachicaDao.Count(criteria);
		}

		public int SaveRendicioncajachica(Rendicioncajachica entity)
		{
			return RendicioncajachicaDao.Save(entity);
		}

		public void UpdateRendicioncajachica(Rendicioncajachica entity)
		{
			RendicioncajachicaDao.Update(entity);
		}

		public void DeleteRendicioncajachica(int id)
		{
			RendicioncajachicaDao.Delete(id);
		}

		public List<Rendicioncajachica> GetAllRendicioncajachica()
		{
			return RendicioncajachicaDao.GetAll();
		}

		public List<Rendicioncajachica> GetAllRendicioncajachica(Expression<Func<Rendicioncajachica, bool>> criteria)
		{
			return RendicioncajachicaDao.GetAll(criteria);
		}

		public List<Rendicioncajachica> GetAllRendicioncajachica(string orders)
		{
			return RendicioncajachicaDao.GetAll(orders);
		}

		public List<Rendicioncajachica> GetAllRendicioncajachica(string conditions, string orders)
		{
			return RendicioncajachicaDao.GetAll(conditions, orders);
		}

		public Rendicioncajachica GetRendicioncajachica(int id)
		{
			return RendicioncajachicaDao.Get(id);
		}

		public Rendicioncajachica GetRendicioncajachica(Expression<Func<Rendicioncajachica, bool>> criteria)
		{
			return RendicioncajachicaDao.Get(criteria);
		}
	}
}

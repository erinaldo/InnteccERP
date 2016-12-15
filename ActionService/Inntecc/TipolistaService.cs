using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipolista()
		{
			return TipolistaDao.Count();
		}

		public long CountTipolista(Expression<Func<Tipolista, bool>> criteria)
		{
			return TipolistaDao.Count(criteria);
		}

		public int SaveTipolista(Tipolista entity)
		{
			return TipolistaDao.Save(entity);
		}

		public void UpdateTipolista(Tipolista entity)
		{
			TipolistaDao.Update(entity);
		}

		public void DeleteTipolista(int id)
		{
			TipolistaDao.Delete(id);
		}

		public List<Tipolista> GetAllTipolista()
		{
			return TipolistaDao.GetAll();
		}

		public List<Tipolista> GetAllTipolista(Expression<Func<Tipolista, bool>> criteria)
		{
			return TipolistaDao.GetAll(criteria);
		}

		public List<Tipolista> GetAllTipolista(string orders)
		{
			return TipolistaDao.GetAll(orders);
		}

		public List<Tipolista> GetAllTipolista(string conditions, string orders)
		{
			return TipolistaDao.GetAll(conditions, orders);
		}

		public Tipolista GetTipolista(int id)
		{
			return TipolistaDao.Get(id);
		}

		public Tipolista GetTipolista(Expression<Func<Tipolista, bool>> criteria)
		{
			return TipolistaDao.Get(criteria);
		}
	}
}

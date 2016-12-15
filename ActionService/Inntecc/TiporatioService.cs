using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTiporatio()
		{
			return TiporatioDao.Count();
		}

		public long CountTiporatio(Expression<Func<Tiporatio, bool>> criteria)
		{
			return TiporatioDao.Count(criteria);
		}

		public int SaveTiporatio(Tiporatio entity)
		{
			return TiporatioDao.Save(entity);
		}

		public void UpdateTiporatio(Tiporatio entity)
		{
			TiporatioDao.Update(entity);
		}

		public void DeleteTiporatio(int id)
		{
			TiporatioDao.Delete(id);
		}

		public List<Tiporatio> GetAllTiporatio()
		{
			return TiporatioDao.GetAll();
		}

		public List<Tiporatio> GetAllTiporatio(Expression<Func<Tiporatio, bool>> criteria)
		{
			return TiporatioDao.GetAll(criteria);
		}

		public List<Tiporatio> GetAllTiporatio(string orders)
		{
			return TiporatioDao.GetAll(orders);
		}

		public List<Tiporatio> GetAllTiporatio(string conditions, string orders)
		{
			return TiporatioDao.GetAll(conditions, orders);
		}

		public Tiporatio GetTiporatio(int id)
		{
			return TiporatioDao.Get(id);
		}

		public Tiporatio GetTiporatio(Expression<Func<Tiporatio, bool>> criteria)
		{
			return TiporatioDao.Get(criteria);
		}
	}
}

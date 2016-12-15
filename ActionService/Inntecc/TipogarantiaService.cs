using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipogarantia()
		{
			return TipogarantiaDao.Count();
		}

		public long CountTipogarantia(Expression<Func<Tipogarantia, bool>> criteria)
		{
			return TipogarantiaDao.Count(criteria);
		}

		public int SaveTipogarantia(Tipogarantia entity)
		{
			return TipogarantiaDao.Save(entity);
		}

		public void UpdateTipogarantia(Tipogarantia entity)
		{
			TipogarantiaDao.Update(entity);
		}

		public void DeleteTipogarantia(int id)
		{
			TipogarantiaDao.Delete(id);
		}

		public List<Tipogarantia> GetAllTipogarantia()
		{
			return TipogarantiaDao.GetAll();
		}

		public List<Tipogarantia> GetAllTipogarantia(Expression<Func<Tipogarantia, bool>> criteria)
		{
			return TipogarantiaDao.GetAll(criteria);
		}

		public List<Tipogarantia> GetAllTipogarantia(string orders)
		{
			return TipogarantiaDao.GetAll(orders);
		}

		public List<Tipogarantia> GetAllTipogarantia(string conditions, string orders)
		{
			return TipogarantiaDao.GetAll(conditions, orders);
		}

		public Tipogarantia GetTipogarantia(int id)
		{
			return TipogarantiaDao.Get(id);
		}

		public Tipogarantia GetTipogarantia(Expression<Func<Tipogarantia, bool>> criteria)
		{
			return TipogarantiaDao.Get(criteria);
		}
	}
}

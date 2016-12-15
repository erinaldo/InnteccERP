using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipomoneda()
		{
			return TipomonedaDao.Count();
		}

		public long CountTipomoneda(Expression<Func<Tipomoneda, bool>> criteria)
		{
			return TipomonedaDao.Count(criteria);
		}

		public int SaveTipomoneda(Tipomoneda entity)
		{
			return TipomonedaDao.Save(entity);
		}

		public void UpdateTipomoneda(Tipomoneda entity)
		{
			TipomonedaDao.Update(entity);
		}

		public void DeleteTipomoneda(int id)
		{
			TipomonedaDao.Delete(id);
		}

		public List<Tipomoneda> GetAllTipomoneda()
		{
			return TipomonedaDao.GetAll();
		}

		public List<Tipomoneda> GetAllTipomoneda(Expression<Func<Tipomoneda, bool>> criteria)
		{
			return TipomonedaDao.GetAll(criteria);
		}

		public List<Tipomoneda> GetAllTipomoneda(string orders)
		{
			return TipomonedaDao.GetAll(orders);
		}

		public List<Tipomoneda> GetAllTipomoneda(string conditions, string orders)
		{
			return TipomonedaDao.GetAll(conditions, orders);
		}

		public Tipomoneda GetTipomoneda(int id)
		{
			return TipomonedaDao.Get(id);
		}

		public Tipomoneda GetTipomoneda(Expression<Func<Tipomoneda, bool>> criteria)
		{
			return TipomonedaDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTiporegistroorden()
		{
			return TiporegistroordenDao.Count();
		}

		public long CountTiporegistroorden(Expression<Func<Tiporegistroorden, bool>> criteria)
		{
			return TiporegistroordenDao.Count(criteria);
		}

		public int SaveTiporegistroorden(Tiporegistroorden entity)
		{
			return TiporegistroordenDao.Save(entity);
		}

		public void UpdateTiporegistroorden(Tiporegistroorden entity)
		{
			TiporegistroordenDao.Update(entity);
		}

		public void DeleteTiporegistroorden(int id)
		{
			TiporegistroordenDao.Delete(id);
		}

		public List<Tiporegistroorden> GetAllTiporegistroorden()
		{
			return TiporegistroordenDao.GetAll();
		}

		public List<Tiporegistroorden> GetAllTiporegistroorden(Expression<Func<Tiporegistroorden, bool>> criteria)
		{
			return TiporegistroordenDao.GetAll(criteria);
		}

		public List<Tiporegistroorden> GetAllTiporegistroorden(string orders)
		{
			return TiporegistroordenDao.GetAll(orders);
		}

		public List<Tiporegistroorden> GetAllTiporegistroorden(string conditions, string orders)
		{
			return TiporegistroordenDao.GetAll(conditions, orders);
		}

		public Tiporegistroorden GetTiporegistroorden(int id)
		{
			return TiporegistroordenDao.Get(id);
		}

		public Tiporegistroorden GetTiporegistroorden(Expression<Func<Tiporegistroorden, bool>> criteria)
		{
			return TiporegistroordenDao.Get(criteria);
		}
	}
}

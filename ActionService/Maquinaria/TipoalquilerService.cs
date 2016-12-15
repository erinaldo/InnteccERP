using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipoalquiler()
		{
			return TipoalquilerDao.Count();
		}

		public long CountTipoalquiler(Expression<Func<Tipoalquiler, bool>> criteria)
		{
			return TipoalquilerDao.Count(criteria);
		}

		public int SaveTipoalquiler(Tipoalquiler entity)
		{
			return TipoalquilerDao.Save(entity);
		}

		public void UpdateTipoalquiler(Tipoalquiler entity)
		{
			TipoalquilerDao.Update(entity);
		}

		public void DeleteTipoalquiler(int id)
		{
			TipoalquilerDao.Delete(id);
		}

		public List<Tipoalquiler> GetAllTipoalquiler()
		{
			return TipoalquilerDao.GetAll();
		}

		public List<Tipoalquiler> GetAllTipoalquiler(Expression<Func<Tipoalquiler, bool>> criteria)
		{
			return TipoalquilerDao.GetAll(criteria);
		}

		public List<Tipoalquiler> GetAllTipoalquiler(string orders)
		{
			return TipoalquilerDao.GetAll(orders);
		}

		public List<Tipoalquiler> GetAllTipoalquiler(string conditions, string orders)
		{
			return TipoalquilerDao.GetAll(conditions, orders);
		}

		public Tipoalquiler GetTipoalquiler(int id)
		{
			return TipoalquilerDao.Get(id);
		}

		public Tipoalquiler GetTipoalquiler(Expression<Func<Tipoalquiler, bool>> criteria)
		{
			return TipoalquilerDao.Get(criteria);
		}
	}
}

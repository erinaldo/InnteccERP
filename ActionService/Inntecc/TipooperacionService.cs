using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipooperacion()
		{
			return TipooperacionDao.Count();
		}

		public long CountTipooperacion(Expression<Func<Tipooperacion, bool>> criteria)
		{
			return TipooperacionDao.Count(criteria);
		}

		public int SaveTipooperacion(Tipooperacion entity)
		{
			return TipooperacionDao.Save(entity);
		}

		public void UpdateTipooperacion(Tipooperacion entity)
		{
			TipooperacionDao.Update(entity);
		}

		public void DeleteTipooperacion(int id)
		{
			TipooperacionDao.Delete(id);
		}

		public List<Tipooperacion> GetAllTipooperacion()
		{
			return TipooperacionDao.GetAll();
		}

		public List<Tipooperacion> GetAllTipooperacion(Expression<Func<Tipooperacion, bool>> criteria)
		{
			return TipooperacionDao.GetAll(criteria);
		}

		public List<Tipooperacion> GetAllTipooperacion(string orders)
		{
			return TipooperacionDao.GetAll(orders);
		}

		public List<Tipooperacion> GetAllTipooperacion(string conditions, string orders)
		{
			return TipooperacionDao.GetAll(conditions, orders);
		}

		public Tipooperacion GetTipooperacion(int id)
		{
			return TipooperacionDao.Get(id);
		}

		public Tipooperacion GetTipooperacion(Expression<Func<Tipooperacion, bool>> criteria)
		{
			return TipooperacionDao.Get(criteria);
		}
	}
}

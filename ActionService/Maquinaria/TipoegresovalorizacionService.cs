using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipoegresovalorizacion()
		{
			return TipoegresovalorizacionDao.Count();
		}

		public long CountTipoegresovalorizacion(Expression<Func<Tipoegresovalorizacion, bool>> criteria)
		{
			return TipoegresovalorizacionDao.Count(criteria);
		}

		public int SaveTipoegresovalorizacion(Tipoegresovalorizacion entity)
		{
			return TipoegresovalorizacionDao.Save(entity);
		}

		public void UpdateTipoegresovalorizacion(Tipoegresovalorizacion entity)
		{
			TipoegresovalorizacionDao.Update(entity);
		}

		public void DeleteTipoegresovalorizacion(int id)
		{
			TipoegresovalorizacionDao.Delete(id);
		}

		public List<Tipoegresovalorizacion> GetAllTipoegresovalorizacion()
		{
			return TipoegresovalorizacionDao.GetAll();
		}

		public List<Tipoegresovalorizacion> GetAllTipoegresovalorizacion(Expression<Func<Tipoegresovalorizacion, bool>> criteria)
		{
			return TipoegresovalorizacionDao.GetAll(criteria);
		}

		public List<Tipoegresovalorizacion> GetAllTipoegresovalorizacion(string orders)
		{
			return TipoegresovalorizacionDao.GetAll(orders);
		}

		public List<Tipoegresovalorizacion> GetAllTipoegresovalorizacion(string conditions, string orders)
		{
			return TipoegresovalorizacionDao.GetAll(conditions, orders);
		}

		public Tipoegresovalorizacion GetTipoegresovalorizacion(int id)
		{
			return TipoegresovalorizacionDao.Get(id);
		}

		public Tipoegresovalorizacion GetTipoegresovalorizacion(Expression<Func<Tipoegresovalorizacion, bool>> criteria)
		{
			return TipoegresovalorizacionDao.Get(criteria);
		}
	}
}

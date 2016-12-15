using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTiposocio()
		{
			return TiposocioDao.Count();
		}

		public long CountTiposocio(Expression<Func<Tiposocio, bool>> criteria)
		{
			return TiposocioDao.Count(criteria);
		}

		public int SaveTiposocio(Tiposocio entity)
		{
			return TiposocioDao.Save(entity);
		}

		public void UpdateTiposocio(Tiposocio entity)
		{
			TiposocioDao.Update(entity);
		}

		public void DeleteTiposocio(int id)
		{
			TiposocioDao.Delete(id);
		}

		public List<Tiposocio> GetAllTiposocio()
		{
			return TiposocioDao.GetAll();
		}

		public List<Tiposocio> GetAllTiposocio(Expression<Func<Tiposocio, bool>> criteria)
		{
			return TiposocioDao.GetAll(criteria);
		}

		public List<Tiposocio> GetAllTiposocio(string orders)
		{
			return TiposocioDao.GetAll(orders);
		}

		public List<Tiposocio> GetAllTiposocio(string conditions, string orders)
		{
			return TiposocioDao.GetAll(conditions, orders);
		}

		public Tiposocio GetTiposocio(int id)
		{
			return TiposocioDao.Get(id);
		}

		public Tiposocio GetTiposocio(Expression<Func<Tiposocio, bool>> criteria)
		{
			return TiposocioDao.Get(criteria);
		}
	}
}

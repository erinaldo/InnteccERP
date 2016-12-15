using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipohistoria()
		{
			return TipohistoriaDao.Count();
		}

		public long CountTipohistoria(Expression<Func<Tipohistoria, bool>> criteria)
		{
			return TipohistoriaDao.Count(criteria);
		}

		public int SaveTipohistoria(Tipohistoria entity)
		{
			return TipohistoriaDao.Save(entity);
		}

		public void UpdateTipohistoria(Tipohistoria entity)
		{
			TipohistoriaDao.Update(entity);
		}

		public void DeleteTipohistoria(int id)
		{
			TipohistoriaDao.Delete(id);
		}

		public List<Tipohistoria> GetAllTipohistoria()
		{
			return TipohistoriaDao.GetAll();
		}

		public List<Tipohistoria> GetAllTipohistoria(Expression<Func<Tipohistoria, bool>> criteria)
		{
			return TipohistoriaDao.GetAll(criteria);
		}

		public List<Tipohistoria> GetAllTipohistoria(string orders)
		{
			return TipohistoriaDao.GetAll(orders);
		}

		public List<Tipohistoria> GetAllTipohistoria(string conditions, string orders)
		{
			return TipohistoriaDao.GetAll(conditions, orders);
		}

		public Tipohistoria GetTipohistoria(int id)
		{
			return TipohistoriaDao.Get(id);
		}

		public Tipohistoria GetTipohistoria(Expression<Func<Tipohistoria, bool>> criteria)
		{
			return TipohistoriaDao.Get(criteria);
		}
	}
}

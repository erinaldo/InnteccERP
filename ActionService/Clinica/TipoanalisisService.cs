using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipoanalisis()
		{
			return TipoanalisisDao.Count();
		}

		public long CountTipoanalisis(Expression<Func<Tipoanalisis, bool>> criteria)
		{
			return TipoanalisisDao.Count(criteria);
		}

		public int SaveTipoanalisis(Tipoanalisis entity)
		{
			return TipoanalisisDao.Save(entity);
		}

		public void UpdateTipoanalisis(Tipoanalisis entity)
		{
			TipoanalisisDao.Update(entity);
		}

		public void DeleteTipoanalisis(int id)
		{
			TipoanalisisDao.Delete(id);
		}

		public List<Tipoanalisis> GetAllTipoanalisis()
		{
			return TipoanalisisDao.GetAll();
		}

		public List<Tipoanalisis> GetAllTipoanalisis(Expression<Func<Tipoanalisis, bool>> criteria)
		{
			return TipoanalisisDao.GetAll(criteria);
		}

		public List<Tipoanalisis> GetAllTipoanalisis(string orders)
		{
			return TipoanalisisDao.GetAll(orders);
		}

		public List<Tipoanalisis> GetAllTipoanalisis(string conditions, string orders)
		{
			return TipoanalisisDao.GetAll(conditions, orders);
		}

		public Tipoanalisis GetTipoanalisis(int id)
		{
			return TipoanalisisDao.Get(id);
		}

		public Tipoanalisis GetTipoanalisis(Expression<Func<Tipoanalisis, bool>> criteria)
		{
			return TipoanalisisDao.Get(criteria);
		}
	}
}

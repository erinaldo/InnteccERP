using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipoarchivo()
		{
			return TipoarchivoDao.Count();
		}

		public long CountTipoarchivo(Expression<Func<Tipoarchivo, bool>> criteria)
		{
			return TipoarchivoDao.Count(criteria);
		}

		public int SaveTipoarchivo(Tipoarchivo entity)
		{
			return TipoarchivoDao.Save(entity);
		}

		public void UpdateTipoarchivo(Tipoarchivo entity)
		{
			TipoarchivoDao.Update(entity);
		}

		public void DeleteTipoarchivo(int id)
		{
			TipoarchivoDao.Delete(id);
		}

		public List<Tipoarchivo> GetAllTipoarchivo()
		{
			return TipoarchivoDao.GetAll();
		}

		public List<Tipoarchivo> GetAllTipoarchivo(Expression<Func<Tipoarchivo, bool>> criteria)
		{
			return TipoarchivoDao.GetAll(criteria);
		}

		public List<Tipoarchivo> GetAllTipoarchivo(string orders)
		{
			return TipoarchivoDao.GetAll(orders);
		}

		public List<Tipoarchivo> GetAllTipoarchivo(string conditions, string orders)
		{
			return TipoarchivoDao.GetAll(conditions, orders);
		}

		public Tipoarchivo GetTipoarchivo(int id)
		{
			return TipoarchivoDao.Get(id);
		}

		public Tipoarchivo GetTipoarchivo(Expression<Func<Tipoarchivo, bool>> criteria)
		{
			return TipoarchivoDao.Get(criteria);
		}
	}
}

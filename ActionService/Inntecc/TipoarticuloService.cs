using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipoarticulo()
		{
			return TipoarticuloDao.Count();
		}

		public long CountTipoarticulo(Expression<Func<Tipoarticulo, bool>> criteria)
		{
			return TipoarticuloDao.Count(criteria);
		}

		public int SaveTipoarticulo(Tipoarticulo entity)
		{
			return TipoarticuloDao.Save(entity);
		}

		public void UpdateTipoarticulo(Tipoarticulo entity)
		{
			TipoarticuloDao.Update(entity);
		}

		public void DeleteTipoarticulo(int id)
		{
			TipoarticuloDao.Delete(id);
		}

		public List<Tipoarticulo> GetAllTipoarticulo()
		{
			return TipoarticuloDao.GetAll();
		}

		public List<Tipoarticulo> GetAllTipoarticulo(Expression<Func<Tipoarticulo, bool>> criteria)
		{
			return TipoarticuloDao.GetAll(criteria);
		}

		public List<Tipoarticulo> GetAllTipoarticulo(string orders)
		{
			return TipoarticuloDao.GetAll(orders);
		}

		public List<Tipoarticulo> GetAllTipoarticulo(string conditions, string orders)
		{
			return TipoarticuloDao.GetAll(conditions, orders);
		}

		public Tipoarticulo GetTipoarticulo(int id)
		{
			return TipoarticuloDao.Get(id);
		}

		public Tipoarticulo GetTipoarticulo(Expression<Func<Tipoarticulo, bool>> criteria)
		{
			return TipoarticuloDao.Get(criteria);
		}
	}
}

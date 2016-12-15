using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountArticuloseriedet()
		{
			return ArticuloseriedetDao.Count();
		}

		public long CountArticuloseriedet(Expression<Func<Articuloseriedet, bool>> criteria)
		{
			return ArticuloseriedetDao.Count(criteria);
		}

		public int SaveArticuloseriedet(Articuloseriedet entity)
		{
			return ArticuloseriedetDao.Save(entity);
		}

		public void UpdateArticuloseriedet(Articuloseriedet entity)
		{
			ArticuloseriedetDao.Update(entity);
		}

		public void DeleteArticuloseriedet(int id)
		{
			ArticuloseriedetDao.Delete(id);
		}

		public List<Articuloseriedet> GetAllArticuloseriedet()
		{
			return ArticuloseriedetDao.GetAll();
		}

		public List<Articuloseriedet> GetAllArticuloseriedet(Expression<Func<Articuloseriedet, bool>> criteria)
		{
			return ArticuloseriedetDao.GetAll(criteria);
		}

		public List<Articuloseriedet> GetAllArticuloseriedet(string orders)
		{
			return ArticuloseriedetDao.GetAll(orders);
		}

		public List<Articuloseriedet> GetAllArticuloseriedet(string conditions, string orders)
		{
			return ArticuloseriedetDao.GetAll(conditions, orders);
		}

		public Articuloseriedet GetArticuloseriedet(int id)
		{
			return ArticuloseriedetDao.Get(id);
		}

		public Articuloseriedet GetArticuloseriedet(Expression<Func<Articuloseriedet, bool>> criteria)
		{
			return ArticuloseriedetDao.Get(criteria);
		}
	}
}

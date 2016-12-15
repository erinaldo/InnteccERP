using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountArticulo()
		{
			return ArticuloDao.Count();
		}

		public long CountArticulo(Expression<Func<Articulo, bool>> criteria)
		{
			return ArticuloDao.Count(criteria);
		}

		public int SaveArticulo(Articulo entity)
		{
			return ArticuloDao.Save(entity);
		}

		public void UpdateArticulo(Articulo entity)
		{
			ArticuloDao.Update(entity);
		}

		public void DeleteArticulo(int id)
		{
			ArticuloDao.Delete(id);
		}

		public List<Articulo> GetAllArticulo()
		{
			return ArticuloDao.GetAll();
		}

		public List<Articulo> GetAllArticulo(Expression<Func<Articulo, bool>> criteria)
		{
			return ArticuloDao.GetAll(criteria);
		}

		public List<Articulo> GetAllArticulo(string orders)
		{
			return ArticuloDao.GetAll(orders);
		}

		public List<Articulo> GetAllArticulo(string conditions, string orders)
		{
			return ArticuloDao.GetAll(conditions, orders);
		}

		public Articulo GetArticulo(int id)
		{
			return ArticuloDao.Get(id);
		}

		public Articulo GetArticulo(Expression<Func<Articulo, bool>> criteria)
		{
			return ArticuloDao.Get(criteria);
		}
	}
}

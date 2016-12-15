using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountArticulolistaprecio()
		{
			return ArticulolistaprecioDao.Count();
		}

		public long CountArticulolistaprecio(Expression<Func<Articulolistaprecio, bool>> criteria)
		{
			return ArticulolistaprecioDao.Count(criteria);
		}

		public int SaveArticulolistaprecio(Articulolistaprecio entity)
		{
			return ArticulolistaprecioDao.Save(entity);
		}

		public void UpdateArticulolistaprecio(Articulolistaprecio entity)
		{
			ArticulolistaprecioDao.Update(entity);
		}

		public void DeleteArticulolistaprecio(int id)
		{
			ArticulolistaprecioDao.Delete(id);
		}

		public List<Articulolistaprecio> GetAllArticulolistaprecio()
		{
			return ArticulolistaprecioDao.GetAll();
		}

		public List<Articulolistaprecio> GetAllArticulolistaprecio(Expression<Func<Articulolistaprecio, bool>> criteria)
		{
			return ArticulolistaprecioDao.GetAll(criteria);
		}

		public List<Articulolistaprecio> GetAllArticulolistaprecio(string orders)
		{
			return ArticulolistaprecioDao.GetAll(orders);
		}

		public List<Articulolistaprecio> GetAllArticulolistaprecio(string conditions, string orders)
		{
			return ArticulolistaprecioDao.GetAll(conditions, orders);
		}

		public Articulolistaprecio GetArticulolistaprecio(int id)
		{
			return ArticulolistaprecioDao.Get(id);
		}

		public Articulolistaprecio GetArticulolistaprecio(Expression<Func<Articulolistaprecio, bool>> criteria)
		{
			return ArticulolistaprecioDao.Get(criteria);
		}
	}
}

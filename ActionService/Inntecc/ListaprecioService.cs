using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountListaprecio()
		{
			return ListaprecioDao.Count();
		}

		public long CountListaprecio(Expression<Func<Listaprecio, bool>> criteria)
		{
			return ListaprecioDao.Count(criteria);
		}

		public int SaveListaprecio(Listaprecio entity)
		{
			return ListaprecioDao.Save(entity);
		}

		public void UpdateListaprecio(Listaprecio entity)
		{
			ListaprecioDao.Update(entity);
		}

		public void DeleteListaprecio(int id)
		{
			ListaprecioDao.Delete(id);
		}

		public List<Listaprecio> GetAllListaprecio()
		{
			return ListaprecioDao.GetAll();
		}

		public List<Listaprecio> GetAllListaprecio(Expression<Func<Listaprecio, bool>> criteria)
		{
			return ListaprecioDao.GetAll(criteria);
		}

		public List<Listaprecio> GetAllListaprecio(string orders)
		{
			return ListaprecioDao.GetAll(orders);
		}

		public List<Listaprecio> GetAllListaprecio(string conditions, string orders)
		{
			return ListaprecioDao.GetAll(conditions, orders);
		}

		public Listaprecio GetListaprecio(int id)
		{
			return ListaprecioDao.Get(id);
		}

		public Listaprecio GetListaprecio(Expression<Func<Listaprecio, bool>> criteria)
		{
			return ListaprecioDao.Get(criteria);
		}
	}
}

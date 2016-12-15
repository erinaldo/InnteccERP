using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountCategoriaitem()
		{
			return CategoriaitemDao.Count();
		}

		public long CountCategoriaitem(Expression<Func<Categoriaitem, bool>> criteria)
		{
			return CategoriaitemDao.Count(criteria);
		}

		public int SaveCategoriaitem(Categoriaitem entity)
		{
			return CategoriaitemDao.Save(entity);
		}

		public void UpdateCategoriaitem(Categoriaitem entity)
		{
			CategoriaitemDao.Update(entity);
		}

		public void DeleteCategoriaitem(int id)
		{
			CategoriaitemDao.Delete(id);
		}

		public List<Categoriaitem> GetAllCategoriaitem()
		{
			return CategoriaitemDao.GetAll();
		}

		public List<Categoriaitem> GetAllCategoriaitem(Expression<Func<Categoriaitem, bool>> criteria)
		{
			return CategoriaitemDao.GetAll(criteria);
		}

		public List<Categoriaitem> GetAllCategoriaitem(string orders)
		{
			return CategoriaitemDao.GetAll(orders);
		}

		public List<Categoriaitem> GetAllCategoriaitem(string conditions, string orders)
		{
			return CategoriaitemDao.GetAll(conditions, orders);
		}

		public Categoriaitem GetCategoriaitem(int id)
		{
			return CategoriaitemDao.Get(id);
		}

		public Categoriaitem GetCategoriaitem(Expression<Func<Categoriaitem, bool>> criteria)
		{
			return CategoriaitemDao.Get(criteria);
		}
	}
}

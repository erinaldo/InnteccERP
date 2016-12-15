using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCategoriasocionegocio()
		{
			return CategoriasocionegocioDao.Count();
		}

		public long CountCategoriasocionegocio(Expression<Func<Categoriasocionegocio, bool>> criteria)
		{
			return CategoriasocionegocioDao.Count(criteria);
		}

		public int SaveCategoriasocionegocio(Categoriasocionegocio entity)
		{
			return CategoriasocionegocioDao.Save(entity);
		}

		public void UpdateCategoriasocionegocio(Categoriasocionegocio entity)
		{
			CategoriasocionegocioDao.Update(entity);
		}

		public void DeleteCategoriasocionegocio(int id)
		{
			CategoriasocionegocioDao.Delete(id);
		}

		public List<Categoriasocionegocio> GetAllCategoriasocionegocio()
		{
			return CategoriasocionegocioDao.GetAll();
		}

		public List<Categoriasocionegocio> GetAllCategoriasocionegocio(Expression<Func<Categoriasocionegocio, bool>> criteria)
		{
			return CategoriasocionegocioDao.GetAll(criteria);
		}

		public List<Categoriasocionegocio> GetAllCategoriasocionegocio(string orders)
		{
			return CategoriasocionegocioDao.GetAll(orders);
		}

		public List<Categoriasocionegocio> GetAllCategoriasocionegocio(string conditions, string orders)
		{
			return CategoriasocionegocioDao.GetAll(conditions, orders);
		}

		public Categoriasocionegocio GetCategoriasocionegocio(int id)
		{
			return CategoriasocionegocioDao.Get(id);
		}

		public Categoriasocionegocio GetCategoriasocionegocio(Expression<Func<Categoriasocionegocio, bool>> criteria)
		{
			return CategoriasocionegocioDao.Get(criteria);
		}
	}
}

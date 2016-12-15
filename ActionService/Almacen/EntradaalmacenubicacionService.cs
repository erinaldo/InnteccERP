using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEntradaalmacenubicacion()
		{
			return EntradaalmacenubicacionDao.Count();
		}

		public long CountEntradaalmacenubicacion(Expression<Func<Entradaalmacenubicacion, bool>> criteria)
		{
			return EntradaalmacenubicacionDao.Count(criteria);
		}

		public int SaveEntradaalmacenubicacion(Entradaalmacenubicacion entity)
		{
			return EntradaalmacenubicacionDao.Save(entity);
		}

		public void UpdateEntradaalmacenubicacion(Entradaalmacenubicacion entity)
		{
			EntradaalmacenubicacionDao.Update(entity);
		}

		public void DeleteEntradaalmacenubicacion(int id)
		{
			EntradaalmacenubicacionDao.Delete(id);
		}

		public List<Entradaalmacenubicacion> GetAllEntradaalmacenubicacion()
		{
			return EntradaalmacenubicacionDao.GetAll();
		}

		public List<Entradaalmacenubicacion> GetAllEntradaalmacenubicacion(Expression<Func<Entradaalmacenubicacion, bool>> criteria)
		{
			return EntradaalmacenubicacionDao.GetAll(criteria);
		}

		public List<Entradaalmacenubicacion> GetAllEntradaalmacenubicacion(string orders)
		{
			return EntradaalmacenubicacionDao.GetAll(orders);
		}

		public List<Entradaalmacenubicacion> GetAllEntradaalmacenubicacion(string conditions, string orders)
		{
			return EntradaalmacenubicacionDao.GetAll(conditions, orders);
		}

		public Entradaalmacenubicacion GetEntradaalmacenubicacion(int id)
		{
			return EntradaalmacenubicacionDao.Get(id);
		}

		public Entradaalmacenubicacion GetEntradaalmacenubicacion(Expression<Func<Entradaalmacenubicacion, bool>> criteria)
		{
			return EntradaalmacenubicacionDao.Get(criteria);
		}
	}
}

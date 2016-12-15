using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEntradaalmacen()
		{
			return EntradaalmacenDao.Count();
		}

		public long CountEntradaalmacen(Expression<Func<Entradaalmacen, bool>> criteria)
		{
			return EntradaalmacenDao.Count(criteria);
		}

		public int SaveEntradaalmacen(Entradaalmacen entity)
		{
			return EntradaalmacenDao.Save(entity);
		}

		public void UpdateEntradaalmacen(Entradaalmacen entity)
		{
			EntradaalmacenDao.Update(entity);
		}

		public void DeleteEntradaalmacen(int id)
		{
			EntradaalmacenDao.Delete(id);
		}

		public List<Entradaalmacen> GetAllEntradaalmacen()
		{
			return EntradaalmacenDao.GetAll();
		}

		public List<Entradaalmacen> GetAllEntradaalmacen(Expression<Func<Entradaalmacen, bool>> criteria)
		{
			return EntradaalmacenDao.GetAll(criteria);
		}

		public List<Entradaalmacen> GetAllEntradaalmacen(string orders)
		{
			return EntradaalmacenDao.GetAll(orders);
		}

		public List<Entradaalmacen> GetAllEntradaalmacen(string conditions, string orders)
		{
			return EntradaalmacenDao.GetAll(conditions, orders);
		}

		public Entradaalmacen GetEntradaalmacen(int id)
		{
			return EntradaalmacenDao.Get(id);
		}

		public Entradaalmacen GetEntradaalmacen(Expression<Func<Entradaalmacen, bool>> criteria)
		{
			return EntradaalmacenDao.Get(criteria);
		}
	}
}

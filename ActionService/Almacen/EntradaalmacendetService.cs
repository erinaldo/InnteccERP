using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEntradaalmacendet()
		{
			return EntradaalmacendetDao.Count();
		}

		public long CountEntradaalmacendet(Expression<Func<Entradaalmacendet, bool>> criteria)
		{
			return EntradaalmacendetDao.Count(criteria);
		}

		public int SaveEntradaalmacendet(Entradaalmacendet entity)
		{
			return EntradaalmacendetDao.Save(entity);
		}

		public void UpdateEntradaalmacendet(Entradaalmacendet entity)
		{
			EntradaalmacendetDao.Update(entity);
		}

		public void DeleteEntradaalmacendet(int id)
		{
			EntradaalmacendetDao.Delete(id);
		}

		public List<Entradaalmacendet> GetAllEntradaalmacendet()
		{
			return EntradaalmacendetDao.GetAll();
		}

		public List<Entradaalmacendet> GetAllEntradaalmacendet(Expression<Func<Entradaalmacendet, bool>> criteria)
		{
			return EntradaalmacendetDao.GetAll(criteria);
		}

		public List<Entradaalmacendet> GetAllEntradaalmacendet(string orders)
		{
			return EntradaalmacendetDao.GetAll(orders);
		}

		public List<Entradaalmacendet> GetAllEntradaalmacendet(string conditions, string orders)
		{
			return EntradaalmacendetDao.GetAll(conditions, orders);
		}

		public Entradaalmacendet GetEntradaalmacendet(int id)
		{
			return EntradaalmacendetDao.Get(id);
		}

		public Entradaalmacendet GetEntradaalmacendet(Expression<Func<Entradaalmacendet, bool>> criteria)
		{
			return EntradaalmacendetDao.Get(criteria);
		}
	}
}

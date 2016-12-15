using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEntradaalmacenobs()
		{
			return EntradaalmacenobsDao.Count();
		}

		public long CountEntradaalmacenobs(Expression<Func<Entradaalmacenobs, bool>> criteria)
		{
			return EntradaalmacenobsDao.Count(criteria);
		}

		public int SaveEntradaalmacenobs(Entradaalmacenobs entity)
		{
			return EntradaalmacenobsDao.Save(entity);
		}

		public void UpdateEntradaalmacenobs(Entradaalmacenobs entity)
		{
			EntradaalmacenobsDao.Update(entity);
		}

		public void DeleteEntradaalmacenobs(int id)
		{
			EntradaalmacenobsDao.Delete(id);
		}

		public List<Entradaalmacenobs> GetAllEntradaalmacenobs()
		{
			return EntradaalmacenobsDao.GetAll();
		}

		public List<Entradaalmacenobs> GetAllEntradaalmacenobs(Expression<Func<Entradaalmacenobs, bool>> criteria)
		{
			return EntradaalmacenobsDao.GetAll(criteria);
		}

		public List<Entradaalmacenobs> GetAllEntradaalmacenobs(string orders)
		{
			return EntradaalmacenobsDao.GetAll(orders);
		}

		public List<Entradaalmacenobs> GetAllEntradaalmacenobs(string conditions, string orders)
		{
			return EntradaalmacenobsDao.GetAll(conditions, orders);
		}

		public Entradaalmacenobs GetEntradaalmacenobs(int id)
		{
			return EntradaalmacenobsDao.Get(id);
		}

		public Entradaalmacenobs GetEntradaalmacenobs(Expression<Func<Entradaalmacenobs, bool>> criteria)
		{
			return EntradaalmacenobsDao.Get(criteria);
		}
	}
}

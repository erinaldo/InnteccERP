using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEntradaalmacendetitemcpcompradet()
		{
			return EntradaalmacendetitemcpcompradetDao.Count();
		}

		public long CountEntradaalmacendetitemcpcompradet(Expression<Func<Entradaalmacendetitemcpcompradet, bool>> criteria)
		{
			return EntradaalmacendetitemcpcompradetDao.Count(criteria);
		}

		public int SaveEntradaalmacendetitemcpcompradet(Entradaalmacendetitemcpcompradet entity)
		{
			return EntradaalmacendetitemcpcompradetDao.Save(entity);
		}

		public void UpdateEntradaalmacendetitemcpcompradet(Entradaalmacendetitemcpcompradet entity)
		{
			EntradaalmacendetitemcpcompradetDao.Update(entity);
		}

		public void DeleteEntradaalmacendetitemcpcompradet(int id)
		{
			EntradaalmacendetitemcpcompradetDao.Delete(id);
		}

		public List<Entradaalmacendetitemcpcompradet> GetAllEntradaalmacendetitemcpcompradet()
		{
			return EntradaalmacendetitemcpcompradetDao.GetAll();
		}

		public List<Entradaalmacendetitemcpcompradet> GetAllEntradaalmacendetitemcpcompradet(Expression<Func<Entradaalmacendetitemcpcompradet, bool>> criteria)
		{
			return EntradaalmacendetitemcpcompradetDao.GetAll(criteria);
		}

		public List<Entradaalmacendetitemcpcompradet> GetAllEntradaalmacendetitemcpcompradet(string orders)
		{
			return EntradaalmacendetitemcpcompradetDao.GetAll(orders);
		}

		public List<Entradaalmacendetitemcpcompradet> GetAllEntradaalmacendetitemcpcompradet(string conditions, string orders)
		{
			return EntradaalmacendetitemcpcompradetDao.GetAll(conditions, orders);
		}

		public Entradaalmacendetitemcpcompradet GetEntradaalmacendetitemcpcompradet(int id)
		{
			return EntradaalmacendetitemcpcompradetDao.Get(id);
		}

		public Entradaalmacendetitemcpcompradet GetEntradaalmacendetitemcpcompradet(Expression<Func<Entradaalmacendetitemcpcompradet, bool>> criteria)
		{
			return EntradaalmacendetitemcpcompradetDao.Get(criteria);
		}
	}
}

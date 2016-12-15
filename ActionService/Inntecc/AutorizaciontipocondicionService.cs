using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountAutorizaciontipocondicion()
		{
			return AutorizaciontipocondicionDao.Count();
		}

		public long CountAutorizaciontipocondicion(Expression<Func<Autorizaciontipocondicion, bool>> criteria)
		{
			return AutorizaciontipocondicionDao.Count(criteria);
		}

		public int SaveAutorizaciontipocondicion(Autorizaciontipocondicion entity)
		{
			return AutorizaciontipocondicionDao.Save(entity);
		}

		public void UpdateAutorizaciontipocondicion(Autorizaciontipocondicion entity)
		{
			AutorizaciontipocondicionDao.Update(entity);
		}

		public void DeleteAutorizaciontipocondicion(int id)
		{
			AutorizaciontipocondicionDao.Delete(id);
		}

		public List<Autorizaciontipocondicion> GetAllAutorizaciontipocondicion()
		{
			return AutorizaciontipocondicionDao.GetAll();
		}

		public List<Autorizaciontipocondicion> GetAllAutorizaciontipocondicion(Expression<Func<Autorizaciontipocondicion, bool>> criteria)
		{
			return AutorizaciontipocondicionDao.GetAll(criteria);
		}

		public List<Autorizaciontipocondicion> GetAllAutorizaciontipocondicion(string orders)
		{
			return AutorizaciontipocondicionDao.GetAll(orders);
		}

		public List<Autorizaciontipocondicion> GetAllAutorizaciontipocondicion(string conditions, string orders)
		{
			return AutorizaciontipocondicionDao.GetAll(conditions, orders);
		}

		public Autorizaciontipocondicion GetAutorizaciontipocondicion(int id)
		{
			return AutorizaciontipocondicionDao.Get(id);
		}

		public Autorizaciontipocondicion GetAutorizaciontipocondicion(Expression<Func<Autorizaciontipocondicion, bool>> criteria)
		{
			return AutorizaciontipocondicionDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCotizacioncliente()
		{
			return CotizacionclienteDao.Count();
		}

		public long CountCotizacioncliente(Expression<Func<Cotizacioncliente, bool>> criteria)
		{
			return CotizacionclienteDao.Count(criteria);
		}

		public int SaveCotizacioncliente(Cotizacioncliente entity)
		{
			return CotizacionclienteDao.Save(entity);
		}

		public void UpdateCotizacioncliente(Cotizacioncliente entity)
		{
			CotizacionclienteDao.Update(entity);
		}

		public void DeleteCotizacioncliente(int id)
		{
			CotizacionclienteDao.Delete(id);
		}

		public List<Cotizacioncliente> GetAllCotizacioncliente()
		{
			return CotizacionclienteDao.GetAll();
		}

		public List<Cotizacioncliente> GetAllCotizacioncliente(Expression<Func<Cotizacioncliente, bool>> criteria)
		{
			return CotizacionclienteDao.GetAll(criteria);
		}

		public List<Cotizacioncliente> GetAllCotizacioncliente(string orders)
		{
			return CotizacionclienteDao.GetAll(orders);
		}

		public List<Cotizacioncliente> GetAllCotizacioncliente(string conditions, string orders)
		{
			return CotizacionclienteDao.GetAll(conditions, orders);
		}

		public Cotizacioncliente GetCotizacioncliente(int id)
		{
			return CotizacionclienteDao.Get(id);
		}

		public Cotizacioncliente GetCotizacioncliente(Expression<Func<Cotizacioncliente, bool>> criteria)
		{
			return CotizacionclienteDao.Get(criteria);
		}
	}
}

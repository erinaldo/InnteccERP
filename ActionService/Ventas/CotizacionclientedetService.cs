using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCotizacionclientedet()
		{
			return CotizacionclientedetDao.Count();
		}

		public long CountCotizacionclientedet(Expression<Func<Cotizacionclientedet, bool>> criteria)
		{
			return CotizacionclientedetDao.Count(criteria);
		}

		public int SaveCotizacionclientedet(Cotizacionclientedet entity)
		{
			return CotizacionclientedetDao.Save(entity);
		}

		public void UpdateCotizacionclientedet(Cotizacionclientedet entity)
		{
			CotizacionclientedetDao.Update(entity);
		}

		public void DeleteCotizacionclientedet(int id)
		{
			CotizacionclientedetDao.Delete(id);
		}

		public List<Cotizacionclientedet> GetAllCotizacionclientedet()
		{
			return CotizacionclientedetDao.GetAll();
		}

		public List<Cotizacionclientedet> GetAllCotizacionclientedet(Expression<Func<Cotizacionclientedet, bool>> criteria)
		{
			return CotizacionclientedetDao.GetAll(criteria);
		}

		public List<Cotizacionclientedet> GetAllCotizacionclientedet(string orders)
		{
			return CotizacionclientedetDao.GetAll(orders);
		}

		public List<Cotizacionclientedet> GetAllCotizacionclientedet(string conditions, string orders)
		{
			return CotizacionclientedetDao.GetAll(conditions, orders);
		}

		public Cotizacionclientedet GetCotizacionclientedet(int id)
		{
			return CotizacionclientedetDao.Get(id);
		}

		public Cotizacionclientedet GetCotizacionclientedet(Expression<Func<Cotizacionclientedet, bool>> criteria)
		{
			return CotizacionclientedetDao.Get(criteria);
		}
	}
}

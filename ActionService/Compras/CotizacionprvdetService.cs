using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCotizacionprvdet()
		{
			return CotizacionprvdetDao.Count();
		}

		public long CountCotizacionprvdet(Expression<Func<Cotizacionprvdet, bool>> criteria)
		{
			return CotizacionprvdetDao.Count(criteria);
		}

		public int SaveCotizacionprvdet(Cotizacionprvdet entity)
		{
			return CotizacionprvdetDao.Save(entity);
		}

		public void UpdateCotizacionprvdet(Cotizacionprvdet entity)
		{
			CotizacionprvdetDao.Update(entity);
		}

		public void DeleteCotizacionprvdet(int id)
		{
			CotizacionprvdetDao.Delete(id);
		}

		public List<Cotizacionprvdet> GetAllCotizacionprvdet()
		{
			return CotizacionprvdetDao.GetAll();
		}

		public List<Cotizacionprvdet> GetAllCotizacionprvdet(Expression<Func<Cotizacionprvdet, bool>> criteria)
		{
			return CotizacionprvdetDao.GetAll(criteria);
		}

		public List<Cotizacionprvdet> GetAllCotizacionprvdet(string orders)
		{
			return CotizacionprvdetDao.GetAll(orders);
		}

		public List<Cotizacionprvdet> GetAllCotizacionprvdet(string conditions, string orders)
		{
			return CotizacionprvdetDao.GetAll(conditions, orders);
		}

		public Cotizacionprvdet GetCotizacionprvdet(int id)
		{
			return CotizacionprvdetDao.Get(id);
		}

		public Cotizacionprvdet GetCotizacionprvdet(Expression<Func<Cotizacionprvdet, bool>> criteria)
		{
			return CotizacionprvdetDao.Get(criteria);
		}
	}
}

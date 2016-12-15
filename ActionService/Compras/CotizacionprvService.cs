using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCotizacionprv()
		{
			return CotizacionprvDao.Count();
		}

		public long CountCotizacionprv(Expression<Func<Cotizacionprv, bool>> criteria)
		{
			return CotizacionprvDao.Count(criteria);
		}

		public int SaveCotizacionprv(Cotizacionprv entity)
		{
			return CotizacionprvDao.Save(entity);
		}

		public void UpdateCotizacionprv(Cotizacionprv entity)
		{
			CotizacionprvDao.Update(entity);
		}

		public void DeleteCotizacionprv(int id)
		{
			CotizacionprvDao.Delete(id);
		}

		public List<Cotizacionprv> GetAllCotizacionprv()
		{
			return CotizacionprvDao.GetAll();
		}

		public List<Cotizacionprv> GetAllCotizacionprv(Expression<Func<Cotizacionprv, bool>> criteria)
		{
			return CotizacionprvDao.GetAll(criteria);
		}

		public List<Cotizacionprv> GetAllCotizacionprv(string orders)
		{
			return CotizacionprvDao.GetAll(orders);
		}

		public List<Cotizacionprv> GetAllCotizacionprv(string conditions, string orders)
		{
			return CotizacionprvDao.GetAll(conditions, orders);
		}

		public Cotizacionprv GetCotizacionprv(int id)
		{
			return CotizacionprvDao.Get(id);
		}

		public Cotizacionprv GetCotizacionprv(Expression<Func<Cotizacionprv, bool>> criteria)
		{
			return CotizacionprvDao.Get(criteria);
		}
	}
}

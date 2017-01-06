using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipocomplicacionparto()
		{
			return TipocomplicacionpartoDao.Count();
		}

		public long CountTipocomplicacionparto(Expression<Func<Tipocomplicacionparto, bool>> criteria)
		{
			return TipocomplicacionpartoDao.Count(criteria);
		}

		public int SaveTipocomplicacionparto(Tipocomplicacionparto entity)
		{
			return TipocomplicacionpartoDao.Save(entity);
		}

		public void UpdateTipocomplicacionparto(Tipocomplicacionparto entity)
		{
			TipocomplicacionpartoDao.Update(entity);
		}

		public void DeleteTipocomplicacionparto(int id)
		{
			TipocomplicacionpartoDao.Delete(id);
		}

		public List<Tipocomplicacionparto> GetAllTipocomplicacionparto()
		{
			return TipocomplicacionpartoDao.GetAll();
		}

		public List<Tipocomplicacionparto> GetAllTipocomplicacionparto(Expression<Func<Tipocomplicacionparto, bool>> criteria)
		{
			return TipocomplicacionpartoDao.GetAll(criteria);
		}

		public List<Tipocomplicacionparto> GetAllTipocomplicacionparto(string orders)
		{
			return TipocomplicacionpartoDao.GetAll(orders);
		}

		public List<Tipocomplicacionparto> GetAllTipocomplicacionparto(string conditions, string orders)
		{
			return TipocomplicacionpartoDao.GetAll(conditions, orders);
		}

		public Tipocomplicacionparto GetTipocomplicacionparto(int id)
		{
			return TipocomplicacionpartoDao.Get(id);
		}

		public Tipocomplicacionparto GetTipocomplicacionparto(Expression<Func<Tipocomplicacionparto, bool>> criteria)
		{
			return TipocomplicacionpartoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipoevento()
		{
			return TipoeventoDao.Count();
		}

		public long CountTipoevento(Expression<Func<Tipoevento, bool>> criteria)
		{
			return TipoeventoDao.Count(criteria);
		}

		public int SaveTipoevento(Tipoevento entity)
		{
			return TipoeventoDao.Save(entity);
		}

		public void UpdateTipoevento(Tipoevento entity)
		{
			TipoeventoDao.Update(entity);
		}

		public void DeleteTipoevento(int id)
		{
			TipoeventoDao.Delete(id);
		}

		public List<Tipoevento> GetAllTipoevento()
		{
			return TipoeventoDao.GetAll();
		}

		public List<Tipoevento> GetAllTipoevento(Expression<Func<Tipoevento, bool>> criteria)
		{
			return TipoeventoDao.GetAll(criteria);
		}

		public List<Tipoevento> GetAllTipoevento(string orders)
		{
			return TipoeventoDao.GetAll(orders);
		}

		public List<Tipoevento> GetAllTipoevento(string conditions, string orders)
		{
			return TipoeventoDao.GetAll(conditions, orders);
		}

		public Tipoevento GetTipoevento(int id)
		{
			return TipoeventoDao.Get(id);
		}

		public Tipoevento GetTipoevento(Expression<Func<Tipoevento, bool>> criteria)
		{
			return TipoeventoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipo()
		{
			return TipoDao.Count();
		}

		public long CountTipo(Expression<Func<Tipo, bool>> criteria)
		{
			return TipoDao.Count(criteria);
		}

		public int SaveTipo(Tipo entity)
		{
			return TipoDao.Save(entity);
		}

		public void UpdateTipo(Tipo entity)
		{
			TipoDao.Update(entity);
		}

		public void DeleteTipo(int id)
		{
			TipoDao.Delete(id);
		}

		public List<Tipo> GetAllTipo()
		{
			return TipoDao.GetAll();
		}

		public List<Tipo> GetAllTipo(Expression<Func<Tipo, bool>> criteria)
		{
			return TipoDao.GetAll(criteria);
		}

		public List<Tipo> GetAllTipo(string orders)
		{
			return TipoDao.GetAll(orders);
		}

		public List<Tipo> GetAllTipo(string conditions, string orders)
		{
			return TipoDao.GetAll(conditions, orders);
		}

		public Tipo GetTipo(int id)
		{
			return TipoDao.Get(id);
		}

		public Tipo GetTipo(Expression<Func<Tipo, bool>> criteria)
		{
			return TipoDao.Get(criteria);
		}
	}
}

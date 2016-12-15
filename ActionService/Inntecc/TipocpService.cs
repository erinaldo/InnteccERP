using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipocp()
		{
			return TipocpDao.Count();
		}

		public long CountTipocp(Expression<Func<Tipocp, bool>> criteria)
		{
			return TipocpDao.Count(criteria);
		}

		public int SaveTipocp(Tipocp entity)
		{
			return TipocpDao.Save(entity);
		}

		public void UpdateTipocp(Tipocp entity)
		{
			TipocpDao.Update(entity);
		}

		public void DeleteTipocp(int id)
		{
			TipocpDao.Delete(id);
		}

		public List<Tipocp> GetAllTipocp()
		{
			return TipocpDao.GetAll();
		}

		public List<Tipocp> GetAllTipocp(Expression<Func<Tipocp, bool>> criteria)
		{
			return TipocpDao.GetAll(criteria);
		}

		public List<Tipocp> GetAllTipocp(string orders)
		{
			return TipocpDao.GetAll(orders);
		}

		public List<Tipocp> GetAllTipocp(string conditions, string orders)
		{
			return TipocpDao.GetAll(conditions, orders);
		}

		public Tipocp GetTipocp(int id)
		{
			return TipocpDao.Get(id);
		}

		public Tipocp GetTipocp(Expression<Func<Tipocp, bool>> criteria)
		{
			return TipocpDao.Get(criteria);
		}
	}
}

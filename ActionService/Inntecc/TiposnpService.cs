using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTiposnp()
		{
			return TiposnpDao.Count();
		}

		public long CountTiposnp(Expression<Func<Tiposnp, bool>> criteria)
		{
			return TiposnpDao.Count(criteria);
		}

		public int SaveTiposnp(Tiposnp entity)
		{
			return TiposnpDao.Save(entity);
		}

		public void UpdateTiposnp(Tiposnp entity)
		{
			TiposnpDao.Update(entity);
		}

		public void DeleteTiposnp(int id)
		{
			TiposnpDao.Delete(id);
		}

		public List<Tiposnp> GetAllTiposnp()
		{
			return TiposnpDao.GetAll();
		}

		public List<Tiposnp> GetAllTiposnp(Expression<Func<Tiposnp, bool>> criteria)
		{
			return TiposnpDao.GetAll(criteria);
		}

		public List<Tiposnp> GetAllTiposnp(string orders)
		{
			return TiposnpDao.GetAll(orders);
		}

		public List<Tiposnp> GetAllTiposnp(string conditions, string orders)
		{
			return TiposnpDao.GetAll(conditions, orders);
		}

		public Tiposnp GetTiposnp(int id)
		{
			return TiposnpDao.Get(id);
		}

		public Tiposnp GetTiposnp(Expression<Func<Tiposnp, bool>> criteria)
		{
			return TiposnpDao.Get(criteria);
		}
	}
}

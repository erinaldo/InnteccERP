using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipocomisioncobro()
		{
			return TipocomisioncobroDao.Count();
		}

		public long CountTipocomisioncobro(Expression<Func<Tipocomisioncobro, bool>> criteria)
		{
			return TipocomisioncobroDao.Count(criteria);
		}

		public int SaveTipocomisioncobro(Tipocomisioncobro entity)
		{
			return TipocomisioncobroDao.Save(entity);
		}

		public void UpdateTipocomisioncobro(Tipocomisioncobro entity)
		{
			TipocomisioncobroDao.Update(entity);
		}

		public void DeleteTipocomisioncobro(int id)
		{
			TipocomisioncobroDao.Delete(id);
		}

		public List<Tipocomisioncobro> GetAllTipocomisioncobro()
		{
			return TipocomisioncobroDao.GetAll();
		}

		public List<Tipocomisioncobro> GetAllTipocomisioncobro(Expression<Func<Tipocomisioncobro, bool>> criteria)
		{
			return TipocomisioncobroDao.GetAll(criteria);
		}

		public List<Tipocomisioncobro> GetAllTipocomisioncobro(string orders)
		{
			return TipocomisioncobroDao.GetAll(orders);
		}

		public List<Tipocomisioncobro> GetAllTipocomisioncobro(string conditions, string orders)
		{
			return TipocomisioncobroDao.GetAll(conditions, orders);
		}

		public Tipocomisioncobro GetTipocomisioncobro(int id)
		{
			return TipocomisioncobroDao.Get(id);
		}

		public Tipocomisioncobro GetTipocomisioncobro(Expression<Func<Tipocomisioncobro, bool>> criteria)
		{
			return TipocomisioncobroDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipomediopago()
		{
			return TipomediopagoDao.Count();
		}

		public long CountTipomediopago(Expression<Func<Tipomediopago, bool>> criteria)
		{
			return TipomediopagoDao.Count(criteria);
		}

		public int SaveTipomediopago(Tipomediopago entity)
		{
			return TipomediopagoDao.Save(entity);
		}

		public void UpdateTipomediopago(Tipomediopago entity)
		{
			TipomediopagoDao.Update(entity);
		}

		public void DeleteTipomediopago(int id)
		{
			TipomediopagoDao.Delete(id);
		}

		public List<Tipomediopago> GetAllTipomediopago()
		{
			return TipomediopagoDao.GetAll();
		}

		public List<Tipomediopago> GetAllTipomediopago(Expression<Func<Tipomediopago, bool>> criteria)
		{
			return TipomediopagoDao.GetAll(criteria);
		}

		public List<Tipomediopago> GetAllTipomediopago(string orders)
		{
			return TipomediopagoDao.GetAll(orders);
		}

		public List<Tipomediopago> GetAllTipomediopago(string conditions, string orders)
		{
			return TipomediopagoDao.GetAll(conditions, orders);
		}

		public Tipomediopago GetTipomediopago(int id)
		{
			return TipomediopagoDao.Get(id);
		}

		public Tipomediopago GetTipomediopago(Expression<Func<Tipomediopago, bool>> criteria)
		{
			return TipomediopagoDao.Get(criteria);
		}
	}
}

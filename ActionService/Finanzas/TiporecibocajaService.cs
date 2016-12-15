using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTiporecibocaja()
		{
			return TiporecibocajaDao.Count();
		}

		public long CountTiporecibocaja(Expression<Func<Tiporecibocaja, bool>> criteria)
		{
			return TiporecibocajaDao.Count(criteria);
		}

		public int SaveTiporecibocaja(Tiporecibocaja entity)
		{
			return TiporecibocajaDao.Save(entity);
		}

		public void UpdateTiporecibocaja(Tiporecibocaja entity)
		{
			TiporecibocajaDao.Update(entity);
		}

		public void DeleteTiporecibocaja(int id)
		{
			TiporecibocajaDao.Delete(id);
		}

		public List<Tiporecibocaja> GetAllTiporecibocaja()
		{
			return TiporecibocajaDao.GetAll();
		}

		public List<Tiporecibocaja> GetAllTiporecibocaja(Expression<Func<Tiporecibocaja, bool>> criteria)
		{
			return TiporecibocajaDao.GetAll(criteria);
		}

		public List<Tiporecibocaja> GetAllTiporecibocaja(string orders)
		{
			return TiporecibocajaDao.GetAll(orders);
		}

		public List<Tiporecibocaja> GetAllTiporecibocaja(string conditions, string orders)
		{
			return TiporecibocajaDao.GetAll(conditions, orders);
		}

		public Tiporecibocaja GetTiporecibocaja(int id)
		{
			return TiporecibocajaDao.Get(id);
		}

		public Tiporecibocaja GetTiporecibocaja(Expression<Func<Tiporecibocaja, bool>> criteria)
		{
			return TiporecibocajaDao.Get(criteria);
		}
	}
}

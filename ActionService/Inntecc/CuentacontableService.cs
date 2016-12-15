using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCuentacontable()
		{
			return CuentacontableDao.Count();
		}

		public long CountCuentacontable(Expression<Func<Cuentacontable, bool>> criteria)
		{
			return CuentacontableDao.Count(criteria);
		}

		public int SaveCuentacontable(Cuentacontable entity)
		{
			return CuentacontableDao.Save(entity);
		}

		public void UpdateCuentacontable(Cuentacontable entity)
		{
			CuentacontableDao.Update(entity);
		}

		public void DeleteCuentacontable(int id)
		{
			CuentacontableDao.Delete(id);
		}

		public List<Cuentacontable> GetAllCuentacontable()
		{
			return CuentacontableDao.GetAll();
		}

		public List<Cuentacontable> GetAllCuentacontable(Expression<Func<Cuentacontable, bool>> criteria)
		{
			return CuentacontableDao.GetAll(criteria);
		}

		public List<Cuentacontable> GetAllCuentacontable(string orders)
		{
			return CuentacontableDao.GetAll(orders);
		}

		public List<Cuentacontable> GetAllCuentacontable(string conditions, string orders)
		{
			return CuentacontableDao.GetAll(conditions, orders);
		}

		public Cuentacontable GetCuentacontable(int id)
		{
			return CuentacontableDao.Get(id);
		}

		public Cuentacontable GetCuentacontable(Expression<Func<Cuentacontable, bool>> criteria)
		{
			return CuentacontableDao.Get(criteria);
		}
	}
}

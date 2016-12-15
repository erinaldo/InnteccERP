using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizacionegresoproveedor()
		{
			return ValorizacionegresoproveedorDao.Count();
		}

		public long CountValorizacionegresoproveedor(Expression<Func<Valorizacionegresoproveedor, bool>> criteria)
		{
			return ValorizacionegresoproveedorDao.Count(criteria);
		}

		public int SaveValorizacionegresoproveedor(Valorizacionegresoproveedor entity)
		{
			return ValorizacionegresoproveedorDao.Save(entity);
		}

		public void UpdateValorizacionegresoproveedor(Valorizacionegresoproveedor entity)
		{
			ValorizacionegresoproveedorDao.Update(entity);
		}

		public void DeleteValorizacionegresoproveedor(int id)
		{
			ValorizacionegresoproveedorDao.Delete(id);
		}

		public List<Valorizacionegresoproveedor> GetAllValorizacionegresoproveedor()
		{
			return ValorizacionegresoproveedorDao.GetAll();
		}

		public List<Valorizacionegresoproveedor> GetAllValorizacionegresoproveedor(Expression<Func<Valorizacionegresoproveedor, bool>> criteria)
		{
			return ValorizacionegresoproveedorDao.GetAll(criteria);
		}

		public List<Valorizacionegresoproveedor> GetAllValorizacionegresoproveedor(string orders)
		{
			return ValorizacionegresoproveedorDao.GetAll(orders);
		}

		public List<Valorizacionegresoproveedor> GetAllValorizacionegresoproveedor(string conditions, string orders)
		{
			return ValorizacionegresoproveedorDao.GetAll(conditions, orders);
		}

		public Valorizacionegresoproveedor GetValorizacionegresoproveedor(int id)
		{
			return ValorizacionegresoproveedorDao.Get(id);
		}

		public Valorizacionegresoproveedor GetValorizacionegresoproveedor(Expression<Func<Valorizacionegresoproveedor, bool>> criteria)
		{
			return ValorizacionegresoproveedorDao.Get(criteria);
		}
	}
}

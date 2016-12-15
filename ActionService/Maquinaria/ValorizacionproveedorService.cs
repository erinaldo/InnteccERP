using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizacionproveedor()
		{
			return ValorizacionproveedorDao.Count();
		}

		public long CountValorizacionproveedor(Expression<Func<Valorizacionproveedor, bool>> criteria)
		{
			return ValorizacionproveedorDao.Count(criteria);
		}

		public int SaveValorizacionproveedor(Valorizacionproveedor entity)
		{
			return ValorizacionproveedorDao.Save(entity);
		}

		public void UpdateValorizacionproveedor(Valorizacionproveedor entity)
		{
			ValorizacionproveedorDao.Update(entity);
		}

		public void DeleteValorizacionproveedor(int id)
		{
			ValorizacionproveedorDao.Delete(id);
		}

		public List<Valorizacionproveedor> GetAllValorizacionproveedor()
		{
			return ValorizacionproveedorDao.GetAll();
		}

		public List<Valorizacionproveedor> GetAllValorizacionproveedor(Expression<Func<Valorizacionproveedor, bool>> criteria)
		{
			return ValorizacionproveedorDao.GetAll(criteria);
		}

		public List<Valorizacionproveedor> GetAllValorizacionproveedor(string orders)
		{
			return ValorizacionproveedorDao.GetAll(orders);
		}

		public List<Valorizacionproveedor> GetAllValorizacionproveedor(string conditions, string orders)
		{
			return ValorizacionproveedorDao.GetAll(conditions, orders);
		}

		public Valorizacionproveedor GetValorizacionproveedor(int id)
		{
			return ValorizacionproveedorDao.Get(id);
		}

		public Valorizacionproveedor GetValorizacionproveedor(Expression<Func<Valorizacionproveedor, bool>> criteria)
		{
			return ValorizacionproveedorDao.Get(criteria);
		}
	}
}

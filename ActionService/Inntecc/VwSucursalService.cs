using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSucursal()
		{
			return VwSucursalDao.Count();
		}

		public long CountVwSucursal(Expression<Func<VwSucursal, bool>> criteria)
		{
			return VwSucursalDao.Count(criteria);
		}

		public int SaveVwSucursal(VwSucursal entity)
		{
			return VwSucursalDao.Save(entity);
		}

		public void UpdateVwSucursal(VwSucursal entity)
		{
			VwSucursalDao.Update(entity);
		}

		public void DeleteVwSucursal(int id)
		{
			VwSucursalDao.Delete(id);
		}

		public List<VwSucursal> GetAllVwSucursal()
		{
			return VwSucursalDao.GetAll();
		}

		public List<VwSucursal> GetAllVwSucursal(Expression<Func<VwSucursal, bool>> criteria)
		{
			return VwSucursalDao.GetAll(criteria);
		}

		public List<VwSucursal> GetAllVwSucursal(string orders)
		{
			return VwSucursalDao.GetAll(orders);
		}

		public List<VwSucursal> GetAllVwSucursal(string conditions, string orders)
		{
			return VwSucursalDao.GetAll(conditions, orders);
		}

		public VwSucursal GetVwSucursal(int id)
		{
			return VwSucursalDao.Get(id);
		}

		public VwSucursal GetVwSucursal(Expression<Func<VwSucursal, bool>> criteria)
		{
			return VwSucursalDao.Get(criteria);
		}
	}
}

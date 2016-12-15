using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountInventario()
		{
			return InventarioDao.Count();
		}

		public long CountInventario(Expression<Func<Inventario, bool>> criteria)
		{
			return InventarioDao.Count(criteria);
		}

		public int SaveInventario(Inventario entity)
		{
			return InventarioDao.Save(entity);
		}

		public void UpdateInventario(Inventario entity)
		{
			InventarioDao.Update(entity);
		}

		public void DeleteInventario(int id)
		{
			InventarioDao.Delete(id);
		}

		public List<Inventario> GetAllInventario()
		{
			return InventarioDao.GetAll();
		}

		public List<Inventario> GetAllInventario(Expression<Func<Inventario, bool>> criteria)
		{
			return InventarioDao.GetAll(criteria);
		}

		public List<Inventario> GetAllInventario(string orders)
		{
			return InventarioDao.GetAll(orders);
		}

		public List<Inventario> GetAllInventario(string conditions, string orders)
		{
			return InventarioDao.GetAll(conditions, orders);
		}

		public Inventario GetInventario(int id)
		{
			return InventarioDao.Get(id);
		}

		public Inventario GetInventario(Expression<Func<Inventario, bool>> criteria)
		{
			return InventarioDao.Get(criteria);
		}
	}
}

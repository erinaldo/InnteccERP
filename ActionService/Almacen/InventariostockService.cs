using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountInventariostock()
		{
			return InventariostockDao.Count();
		}

		public long CountInventariostock(Expression<Func<Inventariostock, bool>> criteria)
		{
			return InventariostockDao.Count(criteria);
		}

		public int SaveInventariostock(Inventariostock entity)
		{
			return InventariostockDao.Save(entity);
		}

		public void UpdateInventariostock(Inventariostock entity)
		{
			InventariostockDao.Update(entity);
		}

		public void DeleteInventariostock(int id)
		{
			InventariostockDao.Delete(id);
		}

		public List<Inventariostock> GetAllInventariostock()
		{
			return InventariostockDao.GetAll();
		}

		public List<Inventariostock> GetAllInventariostock(Expression<Func<Inventariostock, bool>> criteria)
		{
			return InventariostockDao.GetAll(criteria);
		}

		public List<Inventariostock> GetAllInventariostock(string orders)
		{
			return InventariostockDao.GetAll(orders);
		}

		public List<Inventariostock> GetAllInventariostock(string conditions, string orders)
		{
			return InventariostockDao.GetAll(conditions, orders);
		}

		public Inventariostock GetInventariostock(int id)
		{
			return InventariostockDao.Get(id);
		}

		public Inventariostock GetInventariostock(Expression<Func<Inventariostock, bool>> criteria)
		{
			return InventariostockDao.Get(criteria);
		}
	}
}

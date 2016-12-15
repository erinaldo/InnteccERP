using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountInventarioinicial()
		{
			return InventarioinicialDao.Count();
		}

		public long CountInventarioinicial(Expression<Func<Inventarioinicial, bool>> criteria)
		{
			return InventarioinicialDao.Count(criteria);
		}

		public int SaveInventarioinicial(Inventarioinicial entity)
		{
			return InventarioinicialDao.Save(entity);
		}

		public void UpdateInventarioinicial(Inventarioinicial entity)
		{
			InventarioinicialDao.Update(entity);
		}

		public void DeleteInventarioinicial(int id)
		{
			InventarioinicialDao.Delete(id);
		}

		public List<Inventarioinicial> GetAllInventarioinicial()
		{
			return InventarioinicialDao.GetAll();
		}

		public List<Inventarioinicial> GetAllInventarioinicial(Expression<Func<Inventarioinicial, bool>> criteria)
		{
			return InventarioinicialDao.GetAll(criteria);
		}

		public List<Inventarioinicial> GetAllInventarioinicial(string orders)
		{
			return InventarioinicialDao.GetAll(orders);
		}

		public List<Inventarioinicial> GetAllInventarioinicial(string conditions, string orders)
		{
			return InventarioinicialDao.GetAll(conditions, orders);
		}

		public Inventarioinicial GetInventarioinicial(int id)
		{
			return InventarioinicialDao.Get(id);
		}

		public Inventarioinicial GetInventarioinicial(Expression<Func<Inventarioinicial, bool>> criteria)
		{
			return InventarioinicialDao.Get(criteria);
		}
	}
}

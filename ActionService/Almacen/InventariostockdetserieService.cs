using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountInventariostockdetserie()
		{
			return InventariostockdetserieDao.Count();
		}

		public long CountInventariostockdetserie(Expression<Func<Inventariostockdetserie, bool>> criteria)
		{
			return InventariostockdetserieDao.Count(criteria);
		}

		public int SaveInventariostockdetserie(Inventariostockdetserie entity)
		{
			return InventariostockdetserieDao.Save(entity);
		}

		public void UpdateInventariostockdetserie(Inventariostockdetserie entity)
		{
			InventariostockdetserieDao.Update(entity);
		}

		public void DeleteInventariostockdetserie(int id)
		{
			InventariostockdetserieDao.Delete(id);
		}

		public List<Inventariostockdetserie> GetAllInventariostockdetserie()
		{
			return InventariostockdetserieDao.GetAll();
		}

		public List<Inventariostockdetserie> GetAllInventariostockdetserie(Expression<Func<Inventariostockdetserie, bool>> criteria)
		{
			return InventariostockdetserieDao.GetAll(criteria);
		}

		public List<Inventariostockdetserie> GetAllInventariostockdetserie(string orders)
		{
			return InventariostockdetserieDao.GetAll(orders);
		}

		public List<Inventariostockdetserie> GetAllInventariostockdetserie(string conditions, string orders)
		{
			return InventariostockdetserieDao.GetAll(conditions, orders);
		}

		public Inventariostockdetserie GetInventariostockdetserie(int id)
		{
			return InventariostockdetserieDao.Get(id);
		}

		public Inventariostockdetserie GetInventariostockdetserie(Expression<Func<Inventariostockdetserie, bool>> criteria)
		{
			return InventariostockdetserieDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountPais()
		{
			return PaisDao.Count();
		}

		public long CountPais(Expression<Func<Pais, bool>> criteria)
		{
			return PaisDao.Count(criteria);
		}

		public int SavePais(Pais entity)
		{
			return PaisDao.Save(entity);
		}

		public void UpdatePais(Pais entity)
		{
			PaisDao.Update(entity);
		}

		public void DeletePais(int id)
		{
			PaisDao.Delete(id);
		}

		public List<Pais> GetAllPais()
		{
			return PaisDao.GetAll();
		}

		public List<Pais> GetAllPais(Expression<Func<Pais, bool>> criteria)
		{
			return PaisDao.GetAll(criteria);
		}

		public List<Pais> GetAllPais(string orders)
		{
			return PaisDao.GetAll(orders);
		}

		public List<Pais> GetAllPais(string conditions, string orders)
		{
			return PaisDao.GetAll(conditions, orders);
		}

		public Pais GetPais(int id)
		{
			return PaisDao.Get(id);
		}

		public Pais GetPais(Expression<Func<Pais, bool>> criteria)
		{
			return PaisDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCpcompra()
		{
			return CpcompraDao.Count();
		}

		public long CountCpcompra(Expression<Func<Cpcompra, bool>> criteria)
		{
			return CpcompraDao.Count(criteria);
		}

		public int SaveCpcompra(Cpcompra entity)
		{
			return CpcompraDao.Save(entity);
		}

		public void UpdateCpcompra(Cpcompra entity)
		{
			CpcompraDao.Update(entity);
		}

		public void DeleteCpcompra(int id)
		{
			CpcompraDao.Delete(id);
		}

		public List<Cpcompra> GetAllCpcompra()
		{
			return CpcompraDao.GetAll();
		}

		public List<Cpcompra> GetAllCpcompra(Expression<Func<Cpcompra, bool>> criteria)
		{
			return CpcompraDao.GetAll(criteria);
		}

		public List<Cpcompra> GetAllCpcompra(string orders)
		{
			return CpcompraDao.GetAll(orders);
		}

		public List<Cpcompra> GetAllCpcompra(string conditions, string orders)
		{
			return CpcompraDao.GetAll(conditions, orders);
		}

		public Cpcompra GetCpcompra(int id)
		{
			return CpcompraDao.Get(id);
		}

		public Cpcompra GetCpcompra(Expression<Func<Cpcompra, bool>> criteria)
		{
			return CpcompraDao.Get(criteria);
		}
	}
}

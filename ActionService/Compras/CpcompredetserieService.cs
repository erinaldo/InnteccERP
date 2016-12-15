using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountCpcompradetserie()
		{
			return CpcompradetserieDao.Count();
		}

		public long CountCpcompradetserie(Expression<Func<Cpcompradetserie, bool>> criteria)
		{
			return CpcompradetserieDao.Count(criteria);
		}

		public int SaveCpcompradetserie(Cpcompradetserie entity)
		{
			return CpcompradetserieDao.Save(entity);
		}

		public void UpdateCpcompradetserie(Cpcompradetserie entity)
		{
			CpcompradetserieDao.Update(entity);
		}

		public void DeleteCpcompradetserie(int id)
		{
			CpcompradetserieDao.Delete(id);
		}

		public List<Cpcompradetserie> GetAllCpcompradetserie()
		{
			return CpcompradetserieDao.GetAll();
		}

		public List<Cpcompradetserie> GetAllCpcompradetserie(Expression<Func<Cpcompradetserie, bool>> criteria)
		{
			return CpcompradetserieDao.GetAll(criteria);
		}

		public List<Cpcompradetserie> GetAllCpcompradetserie(string orders)
		{
			return CpcompradetserieDao.GetAll(orders);
		}

		public List<Cpcompradetserie> GetAllCpcompradetserie(string conditions, string orders)
		{
			return CpcompradetserieDao.GetAll(conditions, orders);
		}

		public Cpcompradetserie GetCpcompradetserie(int id)
		{
			return CpcompradetserieDao.Get(id);
		}

		public Cpcompradetserie GetCpcompradetserie(Expression<Func<Cpcompradetserie, bool>> criteria)
		{
			return CpcompradetserieDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCentrodecosto()
		{
			return CentrodecostoDao.Count();
		}

		public long CountCentrodecosto(Expression<Func<Centrodecosto, bool>> criteria)
		{
			return CentrodecostoDao.Count(criteria);
		}

		public int SaveCentrodecosto(Centrodecosto entity)
		{
			return CentrodecostoDao.Save(entity);
		}

		public void UpdateCentrodecosto(Centrodecosto entity)
		{
			CentrodecostoDao.Update(entity);
		}

		public void DeleteCentrodecosto(int id)
		{
			CentrodecostoDao.Delete(id);
		}

		public List<Centrodecosto> GetAllCentrodecosto()
		{
			return CentrodecostoDao.GetAll();
		}

		public List<Centrodecosto> GetAllCentrodecosto(Expression<Func<Centrodecosto, bool>> criteria)
		{
			return CentrodecostoDao.GetAll(criteria);
		}

		public List<Centrodecosto> GetAllCentrodecosto(string orders)
		{
			return CentrodecostoDao.GetAll(orders);
		}

		public List<Centrodecosto> GetAllCentrodecosto(string conditions, string orders)
		{
			return CentrodecostoDao.GetAll(conditions, orders);
		}

		public Centrodecosto GetCentrodecosto(int id)
		{
			return CentrodecostoDao.Get(id);
		}

		public Centrodecosto GetCentrodecosto(Expression<Func<Centrodecosto, bool>> criteria)
		{
			return CentrodecostoDao.Get(criteria);
		}
	}
}

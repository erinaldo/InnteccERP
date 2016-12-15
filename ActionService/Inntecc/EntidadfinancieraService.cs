using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEntidadfinanciera()
		{
			return EntidadfinancieraDao.Count();
		}

		public long CountEntidadfinanciera(Expression<Func<Entidadfinanciera, bool>> criteria)
		{
			return EntidadfinancieraDao.Count(criteria);
		}

		public int SaveEntidadfinanciera(Entidadfinanciera entity)
		{
			return EntidadfinancieraDao.Save(entity);
		}

		public void UpdateEntidadfinanciera(Entidadfinanciera entity)
		{
			EntidadfinancieraDao.Update(entity);
		}

		public void DeleteEntidadfinanciera(int id)
		{
			EntidadfinancieraDao.Delete(id);
		}

		public List<Entidadfinanciera> GetAllEntidadfinanciera()
		{
			return EntidadfinancieraDao.GetAll();
		}

		public List<Entidadfinanciera> GetAllEntidadfinanciera(Expression<Func<Entidadfinanciera, bool>> criteria)
		{
			return EntidadfinancieraDao.GetAll(criteria);
		}

		public List<Entidadfinanciera> GetAllEntidadfinanciera(string orders)
		{
			return EntidadfinancieraDao.GetAll(orders);
		}

		public List<Entidadfinanciera> GetAllEntidadfinanciera(string conditions, string orders)
		{
			return EntidadfinancieraDao.GetAll(conditions, orders);
		}

		public Entidadfinanciera GetEntidadfinanciera(int id)
		{
			return EntidadfinancieraDao.Get(id);
		}

		public Entidadfinanciera GetEntidadfinanciera(Expression<Func<Entidadfinanciera, bool>> criteria)
		{
			return EntidadfinancieraDao.Get(criteria);
		}
	}
}

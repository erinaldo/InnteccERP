using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountRubronegocio()
		{
			return RubronegocioDao.Count();
		}

		public long CountRubronegocio(Expression<Func<Rubronegocio, bool>> criteria)
		{
			return RubronegocioDao.Count(criteria);
		}

		public int SaveRubronegocio(Rubronegocio entity)
		{
			return RubronegocioDao.Save(entity);
		}

		public void UpdateRubronegocio(Rubronegocio entity)
		{
			RubronegocioDao.Update(entity);
		}

		public void DeleteRubronegocio(int id)
		{
			RubronegocioDao.Delete(id);
		}

		public List<Rubronegocio> GetAllRubronegocio()
		{
			return RubronegocioDao.GetAll();
		}

		public List<Rubronegocio> GetAllRubronegocio(Expression<Func<Rubronegocio, bool>> criteria)
		{
			return RubronegocioDao.GetAll(criteria);
		}

		public List<Rubronegocio> GetAllRubronegocio(string orders)
		{
			return RubronegocioDao.GetAll(orders);
		}

		public List<Rubronegocio> GetAllRubronegocio(string conditions, string orders)
		{
			return RubronegocioDao.GetAll(conditions, orders);
		}

		public Rubronegocio GetRubronegocio(int id)
		{
			return RubronegocioDao.Get(id);
		}

		public Rubronegocio GetRubronegocio(Expression<Func<Rubronegocio, bool>> criteria)
		{
			return RubronegocioDao.Get(criteria);
		}
	}
}

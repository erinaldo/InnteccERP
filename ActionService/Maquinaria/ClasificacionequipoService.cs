using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountClasificacionequipo()
		{
			return ClasificacionequipoDao.Count();
		}

		public long CountClasificacionequipo(Expression<Func<Clasificacionequipo, bool>> criteria)
		{
			return ClasificacionequipoDao.Count(criteria);
		}

		public int SaveClasificacionequipo(Clasificacionequipo entity)
		{
			return ClasificacionequipoDao.Save(entity);
		}

		public void UpdateClasificacionequipo(Clasificacionequipo entity)
		{
			ClasificacionequipoDao.Update(entity);
		}

		public void DeleteClasificacionequipo(int id)
		{
			ClasificacionequipoDao.Delete(id);
		}

		public List<Clasificacionequipo> GetAllClasificacionequipo()
		{
			return ClasificacionequipoDao.GetAll();
		}

		public List<Clasificacionequipo> GetAllClasificacionequipo(Expression<Func<Clasificacionequipo, bool>> criteria)
		{
			return ClasificacionequipoDao.GetAll(criteria);
		}

		public List<Clasificacionequipo> GetAllClasificacionequipo(string orders)
		{
			return ClasificacionequipoDao.GetAll(orders);
		}

		public List<Clasificacionequipo> GetAllClasificacionequipo(string conditions, string orders)
		{
			return ClasificacionequipoDao.GetAll(conditions, orders);
		}

		public Clasificacionequipo GetClasificacionequipo(int id)
		{
			return ClasificacionequipoDao.Get(id);
		}

		public Clasificacionequipo GetClasificacionequipo(Expression<Func<Clasificacionequipo, bool>> criteria)
		{
			return ClasificacionequipoDao.Get(criteria);
		}
	}
}

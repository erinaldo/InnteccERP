using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSocionegociodireccion()
		{
			return SocionegociodireccionDao.Count();
		}

		public long CountSocionegociodireccion(Expression<Func<Socionegociodireccion, bool>> criteria)
		{
			return SocionegociodireccionDao.Count(criteria);
		}

		public int SaveSocionegociodireccion(Socionegociodireccion entity)
		{
			return SocionegociodireccionDao.Save(entity);
		}

		public void UpdateSocionegociodireccion(Socionegociodireccion entity)
		{
			SocionegociodireccionDao.Update(entity);
		}

		public void DeleteSocionegociodireccion(int id)
		{
			SocionegociodireccionDao.Delete(id);
		}

		public List<Socionegociodireccion> GetAllSocionegociodireccion()
		{
			return SocionegociodireccionDao.GetAll();
		}

		public List<Socionegociodireccion> GetAllSocionegociodireccion(Expression<Func<Socionegociodireccion, bool>> criteria)
		{
			return SocionegociodireccionDao.GetAll(criteria);
		}

		public List<Socionegociodireccion> GetAllSocionegociodireccion(string orders)
		{
			return SocionegociodireccionDao.GetAll(orders);
		}

		public List<Socionegociodireccion> GetAllSocionegociodireccion(string conditions, string orders)
		{
			return SocionegociodireccionDao.GetAll(conditions, orders);
		}

		public Socionegociodireccion GetSocionegociodireccion(int id)
		{
			return SocionegociodireccionDao.Get(id);
		}

		public Socionegociodireccion GetSocionegociodireccion(Expression<Func<Socionegociodireccion, bool>> criteria)
		{
			return SocionegociodireccionDao.Get(criteria);
		}
	}
}

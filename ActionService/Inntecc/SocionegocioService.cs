using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSocionegocio()
		{
			return SocionegocioDao.Count();
		}

		public long CountSocionegocio(Expression<Func<Socionegocio, bool>> criteria)
		{
			return SocionegocioDao.Count(criteria);
		}

		public int SaveSocionegocio(Socionegocio entity)
		{
			return SocionegocioDao.Save(entity);
		}

		public void UpdateSocionegocio(Socionegocio entity)
		{
			SocionegocioDao.Update(entity);
		}

		public void DeleteSocionegocio(int id)
		{
			SocionegocioDao.Delete(id);
		}

		public List<Socionegocio> GetAllSocionegocio()
		{
			return SocionegocioDao.GetAll();
		}

		public List<Socionegocio> GetAllSocionegocio(Expression<Func<Socionegocio, bool>> criteria)
		{
			return SocionegocioDao.GetAll(criteria);
		}

		public List<Socionegocio> GetAllSocionegocio(string orders)
		{
			return SocionegocioDao.GetAll(orders);
		}

		public List<Socionegocio> GetAllSocionegocio(string conditions, string orders)
		{
			return SocionegocioDao.GetAll(conditions, orders);
		}

		public Socionegocio GetSocionegocio(int id)
		{
			return SocionegocioDao.Get(id);
		}

		public Socionegocio GetSocionegocio(Expression<Func<Socionegocio, bool>> criteria)
		{
			return SocionegocioDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSocionegocioproyecto()
		{
			return SocionegocioproyectoDao.Count();
		}

		public long CountSocionegocioproyecto(Expression<Func<Socionegocioproyecto, bool>> criteria)
		{
			return SocionegocioproyectoDao.Count(criteria);
		}

		public int SaveSocionegocioproyecto(Socionegocioproyecto entity)
		{
			return SocionegocioproyectoDao.Save(entity);
		}

		public void UpdateSocionegocioproyecto(Socionegocioproyecto entity)
		{
			SocionegocioproyectoDao.Update(entity);
		}

		public void DeleteSocionegocioproyecto(int id)
		{
			SocionegocioproyectoDao.Delete(id);
		}

		public List<Socionegocioproyecto> GetAllSocionegocioproyecto()
		{
			return SocionegocioproyectoDao.GetAll();
		}

		public List<Socionegocioproyecto> GetAllSocionegocioproyecto(Expression<Func<Socionegocioproyecto, bool>> criteria)
		{
			return SocionegocioproyectoDao.GetAll(criteria);
		}

		public List<Socionegocioproyecto> GetAllSocionegocioproyecto(string orders)
		{
			return SocionegocioproyectoDao.GetAll(orders);
		}

		public List<Socionegocioproyecto> GetAllSocionegocioproyecto(string conditions, string orders)
		{
			return SocionegocioproyectoDao.GetAll(conditions, orders);
		}

		public Socionegocioproyecto GetSocionegocioproyecto(int id)
		{
			return SocionegocioproyectoDao.Get(id);
		}

		public Socionegocioproyecto GetSocionegocioproyecto(Expression<Func<Socionegocioproyecto, bool>> criteria)
		{
			return SocionegocioproyectoDao.Get(criteria);
		}
	}
}

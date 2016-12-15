using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountProyecto()
		{
			return ProyectoDao.Count();
		}

		public long CountProyecto(Expression<Func<Proyecto, bool>> criteria)
		{
			return ProyectoDao.Count(criteria);
		}

		public int SaveProyecto(Proyecto entity)
		{
			return ProyectoDao.Save(entity);
		}

		public void UpdateProyecto(Proyecto entity)
		{
			ProyectoDao.Update(entity);
		}

		public void DeleteProyecto(int id)
		{
			ProyectoDao.Delete(id);
		}

		public List<Proyecto> GetAllProyecto()
		{
			return ProyectoDao.GetAll();
		}

		public List<Proyecto> GetAllProyecto(Expression<Func<Proyecto, bool>> criteria)
		{
			return ProyectoDao.GetAll(criteria);
		}

		public List<Proyecto> GetAllProyecto(string orders)
		{
			return ProyectoDao.GetAll(orders);
		}

		public List<Proyecto> GetAllProyecto(string conditions, string orders)
		{
			return ProyectoDao.GetAll(conditions, orders);
		}

		public Proyecto GetProyecto(int id)
		{
			return ProyectoDao.Get(id);
		}

		public Proyecto GetProyecto(Expression<Func<Proyecto, bool>> criteria)
		{
			return ProyectoDao.Get(criteria);
		}
	}
}

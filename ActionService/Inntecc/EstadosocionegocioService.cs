using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEstadosocionegocio()
		{
			return EstadosocionegocioDao.Count();
		}

		public long CountEstadosocionegocio(Expression<Func<Estadosocionegocio, bool>> criteria)
		{
			return EstadosocionegocioDao.Count(criteria);
		}

		public int SaveEstadosocionegocio(Estadosocionegocio entity)
		{
			return EstadosocionegocioDao.Save(entity);
		}

		public void UpdateEstadosocionegocio(Estadosocionegocio entity)
		{
			EstadosocionegocioDao.Update(entity);
		}

		public void DeleteEstadosocionegocio(int id)
		{
			EstadosocionegocioDao.Delete(id);
		}

		public List<Estadosocionegocio> GetAllEstadosocionegocio()
		{
			return EstadosocionegocioDao.GetAll();
		}

		public List<Estadosocionegocio> GetAllEstadosocionegocio(Expression<Func<Estadosocionegocio, bool>> criteria)
		{
			return EstadosocionegocioDao.GetAll(criteria);
		}

		public List<Estadosocionegocio> GetAllEstadosocionegocio(string orders)
		{
			return EstadosocionegocioDao.GetAll(orders);
		}

		public List<Estadosocionegocio> GetAllEstadosocionegocio(string conditions, string orders)
		{
			return EstadosocionegocioDao.GetAll(conditions, orders);
		}

		public Estadosocionegocio GetEstadosocionegocio(int id)
		{
			return EstadosocionegocioDao.Get(id);
		}

		public Estadosocionegocio GetEstadosocionegocio(Expression<Func<Estadosocionegocio, bool>> criteria)
		{
			return EstadosocionegocioDao.Get(criteria);
		}
	}
}

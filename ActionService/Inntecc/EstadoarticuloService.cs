using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEstadoarticulo()
		{
			return EstadoarticuloDao.Count();
		}

		public long CountEstadoarticulo(Expression<Func<Estadoarticulo, bool>> criteria)
		{
			return EstadoarticuloDao.Count(criteria);
		}

		public int SaveEstadoarticulo(Estadoarticulo entity)
		{
			return EstadoarticuloDao.Save(entity);
		}

		public void UpdateEstadoarticulo(Estadoarticulo entity)
		{
			EstadoarticuloDao.Update(entity);
		}

		public void DeleteEstadoarticulo(int id)
		{
			EstadoarticuloDao.Delete(id);
		}

		public List<Estadoarticulo> GetAllEstadoarticulo()
		{
			return EstadoarticuloDao.GetAll();
		}

		public List<Estadoarticulo> GetAllEstadoarticulo(Expression<Func<Estadoarticulo, bool>> criteria)
		{
			return EstadoarticuloDao.GetAll(criteria);
		}

		public List<Estadoarticulo> GetAllEstadoarticulo(string orders)
		{
			return EstadoarticuloDao.GetAll(orders);
		}

		public List<Estadoarticulo> GetAllEstadoarticulo(string conditions, string orders)
		{
			return EstadoarticuloDao.GetAll(conditions, orders);
		}

		public Estadoarticulo GetEstadoarticulo(int id)
		{
			return EstadoarticuloDao.Get(id);
		}

		public Estadoarticulo GetEstadoarticulo(Expression<Func<Estadoarticulo, bool>> criteria)
		{
			return EstadoarticuloDao.Get(criteria);
		}
	}
}

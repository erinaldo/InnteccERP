using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEstadoarticuloingreso()
		{
			return EstadoarticuloingresoDao.Count();
		}

		public long CountEstadoarticuloingreso(Expression<Func<Estadoarticuloingreso, bool>> criteria)
		{
			return EstadoarticuloingresoDao.Count(criteria);
		}

		public int SaveEstadoarticuloingreso(Estadoarticuloingreso entity)
		{
			return EstadoarticuloingresoDao.Save(entity);
		}

		public void UpdateEstadoarticuloingreso(Estadoarticuloingreso entity)
		{
			EstadoarticuloingresoDao.Update(entity);
		}

		public void DeleteEstadoarticuloingreso(int id)
		{
			EstadoarticuloingresoDao.Delete(id);
		}

		public List<Estadoarticuloingreso> GetAllEstadoarticuloingreso()
		{
			return EstadoarticuloingresoDao.GetAll();
		}

		public List<Estadoarticuloingreso> GetAllEstadoarticuloingreso(Expression<Func<Estadoarticuloingreso, bool>> criteria)
		{
			return EstadoarticuloingresoDao.GetAll(criteria);
		}

		public List<Estadoarticuloingreso> GetAllEstadoarticuloingreso(string orders)
		{
			return EstadoarticuloingresoDao.GetAll(orders);
		}

		public List<Estadoarticuloingreso> GetAllEstadoarticuloingreso(string conditions, string orders)
		{
			return EstadoarticuloingresoDao.GetAll(conditions, orders);
		}

		public Estadoarticuloingreso GetEstadoarticuloingreso(int id)
		{
			return EstadoarticuloingresoDao.Get(id);
		}

		public Estadoarticuloingreso GetEstadoarticuloingreso(Expression<Func<Estadoarticuloingreso, bool>> criteria)
		{
			return EstadoarticuloingresoDao.Get(criteria);
		}
	}
}

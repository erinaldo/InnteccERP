using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountModeloautorizacion()
		{
			return ModeloautorizacionDao.Count();
		}

		public long CountModeloautorizacion(Expression<Func<Modeloautorizacion, bool>> criteria)
		{
			return ModeloautorizacionDao.Count(criteria);
		}

		public int SaveModeloautorizacion(Modeloautorizacion entity)
		{
			return ModeloautorizacionDao.Save(entity);
		}

		public void UpdateModeloautorizacion(Modeloautorizacion entity)
		{
			ModeloautorizacionDao.Update(entity);
		}

		public void DeleteModeloautorizacion(int id)
		{
			ModeloautorizacionDao.Delete(id);
		}

		public List<Modeloautorizacion> GetAllModeloautorizacion()
		{
			return ModeloautorizacionDao.GetAll();
		}

		public List<Modeloautorizacion> GetAllModeloautorizacion(Expression<Func<Modeloautorizacion, bool>> criteria)
		{
			return ModeloautorizacionDao.GetAll(criteria);
		}

		public List<Modeloautorizacion> GetAllModeloautorizacion(string orders)
		{
			return ModeloautorizacionDao.GetAll(orders);
		}

		public List<Modeloautorizacion> GetAllModeloautorizacion(string conditions, string orders)
		{
			return ModeloautorizacionDao.GetAll(conditions, orders);
		}

		public Modeloautorizacion GetModeloautorizacion(int id)
		{
			return ModeloautorizacionDao.Get(id);
		}

		public Modeloautorizacion GetModeloautorizacion(Expression<Func<Modeloautorizacion, bool>> criteria)
		{
			return ModeloautorizacionDao.Get(criteria);
		}
	}
}

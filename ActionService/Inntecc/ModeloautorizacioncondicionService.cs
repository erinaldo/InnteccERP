using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountModeloautorizacioncondicion()
		{
			return ModeloautorizacioncondicionDao.Count();
		}

		public long CountModeloautorizacioncondicion(Expression<Func<Modeloautorizacioncondicion, bool>> criteria)
		{
			return ModeloautorizacioncondicionDao.Count(criteria);
		}

		public int SaveModeloautorizacioncondicion(Modeloautorizacioncondicion entity)
		{
			return ModeloautorizacioncondicionDao.Save(entity);
		}

		public void UpdateModeloautorizacioncondicion(Modeloautorizacioncondicion entity)
		{
			ModeloautorizacioncondicionDao.Update(entity);
		}

		public void DeleteModeloautorizacioncondicion(int id)
		{
			ModeloautorizacioncondicionDao.Delete(id);
		}

		public List<Modeloautorizacioncondicion> GetAllModeloautorizacioncondicion()
		{
			return ModeloautorizacioncondicionDao.GetAll();
		}

		public List<Modeloautorizacioncondicion> GetAllModeloautorizacioncondicion(Expression<Func<Modeloautorizacioncondicion, bool>> criteria)
		{
			return ModeloautorizacioncondicionDao.GetAll(criteria);
		}

		public List<Modeloautorizacioncondicion> GetAllModeloautorizacioncondicion(string orders)
		{
			return ModeloautorizacioncondicionDao.GetAll(orders);
		}

		public List<Modeloautorizacioncondicion> GetAllModeloautorizacioncondicion(string conditions, string orders)
		{
			return ModeloautorizacioncondicionDao.GetAll(conditions, orders);
		}

		public Modeloautorizacioncondicion GetModeloautorizacioncondicion(int id)
		{
			return ModeloautorizacioncondicionDao.Get(id);
		}

		public Modeloautorizacioncondicion GetModeloautorizacioncondicion(Expression<Func<Modeloautorizacioncondicion, bool>> criteria)
		{
			return ModeloautorizacioncondicionDao.Get(criteria);
		}
	}
}

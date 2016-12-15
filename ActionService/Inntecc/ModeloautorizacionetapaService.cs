using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountModeloautorizacionetapa()
		{
			return ModeloautorizacionetapaDao.Count();
		}

		public long CountModeloautorizacionetapa(Expression<Func<Modeloautorizacionetapa, bool>> criteria)
		{
			return ModeloautorizacionetapaDao.Count(criteria);
		}

		public int SaveModeloautorizacionetapa(Modeloautorizacionetapa entity)
		{
			return ModeloautorizacionetapaDao.Save(entity);
		}

		public void UpdateModeloautorizacionetapa(Modeloautorizacionetapa entity)
		{
			ModeloautorizacionetapaDao.Update(entity);
		}

		public void DeleteModeloautorizacionetapa(int id)
		{
			ModeloautorizacionetapaDao.Delete(id);
		}

		public List<Modeloautorizacionetapa> GetAllModeloautorizacionetapa()
		{
			return ModeloautorizacionetapaDao.GetAll();
		}

		public List<Modeloautorizacionetapa> GetAllModeloautorizacionetapa(Expression<Func<Modeloautorizacionetapa, bool>> criteria)
		{
			return ModeloautorizacionetapaDao.GetAll(criteria);
		}

		public List<Modeloautorizacionetapa> GetAllModeloautorizacionetapa(string orders)
		{
			return ModeloautorizacionetapaDao.GetAll(orders);
		}

		public List<Modeloautorizacionetapa> GetAllModeloautorizacionetapa(string conditions, string orders)
		{
			return ModeloautorizacionetapaDao.GetAll(conditions, orders);
		}

		public Modeloautorizacionetapa GetModeloautorizacionetapa(int id)
		{
			return ModeloautorizacionetapaDao.Get(id);
		}

		public Modeloautorizacionetapa GetModeloautorizacionetapa(Expression<Func<Modeloautorizacionetapa, bool>> criteria)
		{
			return ModeloautorizacionetapaDao.Get(criteria);
		}
	}
}

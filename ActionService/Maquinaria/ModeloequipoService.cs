using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountModeloequipo()
		{
			return ModeloequipoDao.Count();
		}

		public long CountModeloequipo(Expression<Func<Modeloequipo, bool>> criteria)
		{
			return ModeloequipoDao.Count(criteria);
		}

		public int SaveModeloequipo(Modeloequipo entity)
		{
			return ModeloequipoDao.Save(entity);
		}

		public void UpdateModeloequipo(Modeloequipo entity)
		{
			ModeloequipoDao.Update(entity);
		}

		public void DeleteModeloequipo(int id)
		{
			ModeloequipoDao.Delete(id);
		}

		public List<Modeloequipo> GetAllModeloequipo()
		{
			return ModeloequipoDao.GetAll();
		}

		public List<Modeloequipo> GetAllModeloequipo(Expression<Func<Modeloequipo, bool>> criteria)
		{
			return ModeloequipoDao.GetAll(criteria);
		}

		public List<Modeloequipo> GetAllModeloequipo(string orders)
		{
			return ModeloequipoDao.GetAll(orders);
		}

		public List<Modeloequipo> GetAllModeloequipo(string conditions, string orders)
		{
			return ModeloequipoDao.GetAll(conditions, orders);
		}

		public Modeloequipo GetModeloequipo(int id)
		{
			return ModeloequipoDao.Get(id);
		}

		public Modeloequipo GetModeloequipo(Expression<Func<Modeloequipo, bool>> criteria)
		{
			return ModeloequipoDao.Get(criteria);
		}
	}
}

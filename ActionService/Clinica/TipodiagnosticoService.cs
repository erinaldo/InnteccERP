using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountTipodiagnostico()
		{
			return TipodiagnosticoDao.Count();
		}

		public long CountTipodiagnostico(Expression<Func<Tipodiagnostico, bool>> criteria)
		{
			return TipodiagnosticoDao.Count(criteria);
		}

		public int SaveTipodiagnostico(Tipodiagnostico entity)
		{
			return TipodiagnosticoDao.Save(entity);
		}

		public void UpdateTipodiagnostico(Tipodiagnostico entity)
		{
			TipodiagnosticoDao.Update(entity);
		}

		public void DeleteTipodiagnostico(int id)
		{
			TipodiagnosticoDao.Delete(id);
		}

		public List<Tipodiagnostico> GetAllTipodiagnostico()
		{
			return TipodiagnosticoDao.GetAll();
		}

		public List<Tipodiagnostico> GetAllTipodiagnostico(Expression<Func<Tipodiagnostico, bool>> criteria)
		{
			return TipodiagnosticoDao.GetAll(criteria);
		}

		public List<Tipodiagnostico> GetAllTipodiagnostico(string orders)
		{
			return TipodiagnosticoDao.GetAll(orders);
		}

		public List<Tipodiagnostico> GetAllTipodiagnostico(string conditions, string orders)
		{
			return TipodiagnosticoDao.GetAll(conditions, orders);
		}

		public Tipodiagnostico GetTipodiagnostico(int id)
		{
			return TipodiagnosticoDao.Get(id);
		}

		public Tipodiagnostico GetTipodiagnostico(Expression<Func<Tipodiagnostico, bool>> criteria)
		{
			return TipodiagnosticoDao.Get(criteria);
		}
	}
}

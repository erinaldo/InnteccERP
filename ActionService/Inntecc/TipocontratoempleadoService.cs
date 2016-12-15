using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipocontratoempleado()
		{
			return TipocontratoempleadoDao.Count();
		}

		public long CountTipocontratoempleado(Expression<Func<Tipocontratoempleado, bool>> criteria)
		{
			return TipocontratoempleadoDao.Count(criteria);
		}

		public int SaveTipocontratoempleado(Tipocontratoempleado entity)
		{
			return TipocontratoempleadoDao.Save(entity);
		}

		public void UpdateTipocontratoempleado(Tipocontratoempleado entity)
		{
			TipocontratoempleadoDao.Update(entity);
		}

		public void DeleteTipocontratoempleado(int id)
		{
			TipocontratoempleadoDao.Delete(id);
		}

		public List<Tipocontratoempleado> GetAllTipocontratoempleado()
		{
			return TipocontratoempleadoDao.GetAll();
		}

		public List<Tipocontratoempleado> GetAllTipocontratoempleado(Expression<Func<Tipocontratoempleado, bool>> criteria)
		{
			return TipocontratoempleadoDao.GetAll(criteria);
		}

		public List<Tipocontratoempleado> GetAllTipocontratoempleado(string orders)
		{
			return TipocontratoempleadoDao.GetAll(orders);
		}

		public List<Tipocontratoempleado> GetAllTipocontratoempleado(string conditions, string orders)
		{
			return TipocontratoempleadoDao.GetAll(conditions, orders);
		}

		public Tipocontratoempleado GetTipocontratoempleado(int id)
		{
			return TipocontratoempleadoDao.Get(id);
		}

		public Tipocontratoempleado GetTipocontratoempleado(Expression<Func<Tipocontratoempleado, bool>> criteria)
		{
			return TipocontratoempleadoDao.Get(criteria);
		}
	}
}

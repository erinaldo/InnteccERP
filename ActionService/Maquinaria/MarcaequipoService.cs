using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountMarcaequipo()
		{
			return MarcaequipoDao.Count();
		}

		public long CountMarcaequipo(Expression<Func<Marcaequipo, bool>> criteria)
		{
			return MarcaequipoDao.Count(criteria);
		}

		public int SaveMarcaequipo(Marcaequipo entity)
		{
			return MarcaequipoDao.Save(entity);
		}

		public void UpdateMarcaequipo(Marcaequipo entity)
		{
			MarcaequipoDao.Update(entity);
		}

		public void DeleteMarcaequipo(int id)
		{
			MarcaequipoDao.Delete(id);
		}

		public List<Marcaequipo> GetAllMarcaequipo()
		{
			return MarcaequipoDao.GetAll();
		}

		public List<Marcaequipo> GetAllMarcaequipo(Expression<Func<Marcaequipo, bool>> criteria)
		{
			return MarcaequipoDao.GetAll(criteria);
		}

		public List<Marcaequipo> GetAllMarcaequipo(string orders)
		{
			return MarcaequipoDao.GetAll(orders);
		}

		public List<Marcaequipo> GetAllMarcaequipo(string conditions, string orders)
		{
			return MarcaequipoDao.GetAll(conditions, orders);
		}

		public Marcaequipo GetMarcaequipo(int id)
		{
			return MarcaequipoDao.Get(id);
		}

		public Marcaequipo GetMarcaequipo(Expression<Func<Marcaequipo, bool>> criteria)
		{
			return MarcaequipoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountGrupoedad()
		{
			return GrupoedadDao.Count();
		}

		public long CountGrupoedad(Expression<Func<Grupoedad, bool>> criteria)
		{
			return GrupoedadDao.Count(criteria);
		}

		public int SaveGrupoedad(Grupoedad entity)
		{
			return GrupoedadDao.Save(entity);
		}

		public void UpdateGrupoedad(Grupoedad entity)
		{
			GrupoedadDao.Update(entity);
		}

		public void DeleteGrupoedad(int id)
		{
			GrupoedadDao.Delete(id);
		}

		public List<Grupoedad> GetAllGrupoedad()
		{
			return GrupoedadDao.GetAll();
		}

		public List<Grupoedad> GetAllGrupoedad(Expression<Func<Grupoedad, bool>> criteria)
		{
			return GrupoedadDao.GetAll(criteria);
		}

		public List<Grupoedad> GetAllGrupoedad(string orders)
		{
			return GrupoedadDao.GetAll(orders);
		}

		public List<Grupoedad> GetAllGrupoedad(string conditions, string orders)
		{
			return GrupoedadDao.GetAll(conditions, orders);
		}

		public Grupoedad GetGrupoedad(int id)
		{
			return GrupoedadDao.Get(id);
		}

		public Grupoedad GetGrupoedad(Expression<Func<Grupoedad, bool>> criteria)
		{
			return GrupoedadDao.Get(criteria);
		}
	}
}

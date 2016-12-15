using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountGrupoeconomico()
		{
			return GrupoeconomicoDao.Count();
		}

		public long CountGrupoeconomico(Expression<Func<Grupoeconomico, bool>> criteria)
		{
			return GrupoeconomicoDao.Count(criteria);
		}

		public int SaveGrupoeconomico(Grupoeconomico entity)
		{
			return GrupoeconomicoDao.Save(entity);
		}

		public void UpdateGrupoeconomico(Grupoeconomico entity)
		{
			GrupoeconomicoDao.Update(entity);
		}

		public void DeleteGrupoeconomico(int id)
		{
			GrupoeconomicoDao.Delete(id);
		}

		public List<Grupoeconomico> GetAllGrupoeconomico()
		{
			return GrupoeconomicoDao.GetAll();
		}

		public List<Grupoeconomico> GetAllGrupoeconomico(Expression<Func<Grupoeconomico, bool>> criteria)
		{
			return GrupoeconomicoDao.GetAll(criteria);
		}

		public List<Grupoeconomico> GetAllGrupoeconomico(string orders)
		{
			return GrupoeconomicoDao.GetAll(orders);
		}

		public List<Grupoeconomico> GetAllGrupoeconomico(string conditions, string orders)
		{
			return GrupoeconomicoDao.GetAll(conditions, orders);
		}

		public Grupoeconomico GetGrupoeconomico(int id)
		{
			return GrupoeconomicoDao.Get(id);
		}

		public Grupoeconomico GetGrupoeconomico(Expression<Func<Grupoeconomico, bool>> criteria)
		{
			return GrupoeconomicoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTiposcontacto()
		{
			return TiposcontactoDao.Count();
		}

		public long CountTiposcontacto(Expression<Func<Tiposcontacto, bool>> criteria)
		{
			return TiposcontactoDao.Count(criteria);
		}

		public int SaveTiposcontacto(Tiposcontacto entity)
		{
			return TiposcontactoDao.Save(entity);
		}

		public void UpdateTiposcontacto(Tiposcontacto entity)
		{
			TiposcontactoDao.Update(entity);
		}

		public void DeleteTiposcontacto(int id)
		{
			TiposcontactoDao.Delete(id);
		}

		public List<Tiposcontacto> GetAllTiposcontacto()
		{
			return TiposcontactoDao.GetAll();
		}

		public List<Tiposcontacto> GetAllTiposcontacto(Expression<Func<Tiposcontacto, bool>> criteria)
		{
			return TiposcontactoDao.GetAll(criteria);
		}

		public List<Tiposcontacto> GetAllTiposcontacto(string orders)
		{
			return TiposcontactoDao.GetAll(orders);
		}

		public List<Tiposcontacto> GetAllTiposcontacto(string conditions, string orders)
		{
			return TiposcontactoDao.GetAll(conditions, orders);
		}

		public Tiposcontacto GetTiposcontacto(int id)
		{
			return TiposcontactoDao.Get(id);
		}

		public Tiposcontacto GetTiposcontacto(Expression<Func<Tiposcontacto, bool>> criteria)
		{
			return TiposcontactoDao.Get(criteria);
		}
	}
}

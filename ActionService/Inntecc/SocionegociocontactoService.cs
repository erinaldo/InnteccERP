using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSocionegociocontacto()
		{
			return SocionegociocontactoDao.Count();
		}

		public long CountSocionegociocontacto(Expression<Func<Socionegociocontacto, bool>> criteria)
		{
			return SocionegociocontactoDao.Count(criteria);
		}

		public int SaveSocionegociocontacto(Socionegociocontacto entity)
		{
			return SocionegociocontactoDao.Save(entity);
		}

		public void UpdateSocionegociocontacto(Socionegociocontacto entity)
		{
			SocionegociocontactoDao.Update(entity);
		}

		public void DeleteSocionegociocontacto(int id)
		{
			SocionegociocontactoDao.Delete(id);
		}

		public List<Socionegociocontacto> GetAllSocionegociocontacto()
		{
			return SocionegociocontactoDao.GetAll();
		}

		public List<Socionegociocontacto> GetAllSocionegociocontacto(Expression<Func<Socionegociocontacto, bool>> criteria)
		{
			return SocionegociocontactoDao.GetAll(criteria);
		}

		public List<Socionegociocontacto> GetAllSocionegociocontacto(string orders)
		{
			return SocionegociocontactoDao.GetAll(orders);
		}

		public List<Socionegociocontacto> GetAllSocionegociocontacto(string conditions, string orders)
		{
			return SocionegociocontactoDao.GetAll(conditions, orders);
		}

		public Socionegociocontacto GetSocionegociocontacto(int id)
		{
			return SocionegociocontactoDao.Get(id);
		}

		public Socionegociocontacto GetSocionegociocontacto(Expression<Func<Socionegociocontacto, bool>> criteria)
		{
			return SocionegociocontactoDao.Get(criteria);
		}
	}
}

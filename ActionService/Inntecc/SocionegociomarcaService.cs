using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSocionegociomarca()
		{
			return SocionegociomarcaDao.Count();
		}

		public long CountSocionegociomarca(Expression<Func<Socionegociomarca, bool>> criteria)
		{
			return SocionegociomarcaDao.Count(criteria);
		}

		public int SaveSocionegociomarca(Socionegociomarca entity)
		{
			return SocionegociomarcaDao.Save(entity);
		}

		public void UpdateSocionegociomarca(Socionegociomarca entity)
		{
			SocionegociomarcaDao.Update(entity);
		}

		public void DeleteSocionegociomarca(int id)
		{
			SocionegociomarcaDao.Delete(id);
		}

		public List<Socionegociomarca> GetAllSocionegociomarca()
		{
			return SocionegociomarcaDao.GetAll();
		}

		public List<Socionegociomarca> GetAllSocionegociomarca(Expression<Func<Socionegociomarca, bool>> criteria)
		{
			return SocionegociomarcaDao.GetAll(criteria);
		}

		public List<Socionegociomarca> GetAllSocionegociomarca(string orders)
		{
			return SocionegociomarcaDao.GetAll(orders);
		}

		public List<Socionegociomarca> GetAllSocionegociomarca(string conditions, string orders)
		{
			return SocionegociomarcaDao.GetAll(conditions, orders);
		}

		public Socionegociomarca GetSocionegociomarca(int id)
		{
			return SocionegociomarcaDao.Get(id);
		}

		public Socionegociomarca GetSocionegociomarca(Expression<Func<Socionegociomarca, bool>> criteria)
		{
			return SocionegociomarcaDao.Get(criteria);
		}
	}
}

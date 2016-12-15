using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountImpuestoisc()
		{
			return ImpuestoiscDao.Count();
		}

		public long CountImpuestoisc(Expression<Func<Impuestoisc, bool>> criteria)
		{
			return ImpuestoiscDao.Count(criteria);
		}

		public int SaveImpuestoisc(Impuestoisc entity)
		{
			return ImpuestoiscDao.Save(entity);
		}

		public void UpdateImpuestoisc(Impuestoisc entity)
		{
			ImpuestoiscDao.Update(entity);
		}

		public void DeleteImpuestoisc(int id)
		{
			ImpuestoiscDao.Delete(id);
		}

		public List<Impuestoisc> GetAllImpuestoisc()
		{
			return ImpuestoiscDao.GetAll();
		}

		public List<Impuestoisc> GetAllImpuestoisc(Expression<Func<Impuestoisc, bool>> criteria)
		{
			return ImpuestoiscDao.GetAll(criteria);
		}

		public List<Impuestoisc> GetAllImpuestoisc(string orders)
		{
			return ImpuestoiscDao.GetAll(orders);
		}

		public List<Impuestoisc> GetAllImpuestoisc(string conditions, string orders)
		{
			return ImpuestoiscDao.GetAll(conditions, orders);
		}

		public Impuestoisc GetImpuestoisc(int id)
		{
			return ImpuestoiscDao.Get(id);
		}

		public Impuestoisc GetImpuestoisc(Expression<Func<Impuestoisc, bool>> criteria)
		{
			return ImpuestoiscDao.Get(criteria);
		}
	}
}

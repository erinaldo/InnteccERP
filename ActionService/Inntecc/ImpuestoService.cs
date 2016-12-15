using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountImpuesto()
		{
			return ImpuestoDao.Count();
		}

		public long CountImpuesto(Expression<Func<Impuesto, bool>> criteria)
		{
			return ImpuestoDao.Count(criteria);
		}

		public int SaveImpuesto(Impuesto entity)
		{
			return ImpuestoDao.Save(entity);
		}

		public void UpdateImpuesto(Impuesto entity)
		{
			ImpuestoDao.Update(entity);
		}

		public void DeleteImpuesto(int id)
		{
			ImpuestoDao.Delete(id);
		}

		public List<Impuesto> GetAllImpuesto()
		{
			return ImpuestoDao.GetAll();
		}

		public List<Impuesto> GetAllImpuesto(Expression<Func<Impuesto, bool>> criteria)
		{
			return ImpuestoDao.GetAll(criteria);
		}

		public List<Impuesto> GetAllImpuesto(string orders)
		{
			return ImpuestoDao.GetAll(orders);
		}

		public List<Impuesto> GetAllImpuesto(string conditions, string orders)
		{
			return ImpuestoDao.GetAll(conditions, orders);
		}

		public Impuesto GetImpuesto(int id)
		{
			return ImpuestoDao.Get(id);
		}

		public Impuesto GetImpuesto(Expression<Func<Impuesto, bool>> criteria)
		{
			return ImpuestoDao.Get(criteria);
		}
	}
}

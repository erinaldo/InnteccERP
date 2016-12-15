using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipocppago()
		{
			return TipocppagoDao.Count();
		}

		public long CountTipocppago(Expression<Func<Tipocppago, bool>> criteria)
		{
			return TipocppagoDao.Count(criteria);
		}

		public int SaveTipocppago(Tipocppago entity)
		{
			return TipocppagoDao.Save(entity);
		}

		public void UpdateTipocppago(Tipocppago entity)
		{
			TipocppagoDao.Update(entity);
		}

		public void DeleteTipocppago(int id)
		{
			TipocppagoDao.Delete(id);
		}

		public List<Tipocppago> GetAllTipocppago()
		{
			return TipocppagoDao.GetAll();
		}

		public List<Tipocppago> GetAllTipocppago(Expression<Func<Tipocppago, bool>> criteria)
		{
			return TipocppagoDao.GetAll(criteria);
		}

		public List<Tipocppago> GetAllTipocppago(string orders)
		{
			return TipocppagoDao.GetAll(orders);
		}

		public List<Tipocppago> GetAllTipocppago(string conditions, string orders)
		{
			return TipocppagoDao.GetAll(conditions, orders);
		}

		public Tipocppago GetTipocppago(int id)
		{
			return TipocppagoDao.Get(id);
		}

		public Tipocppago GetTipocppago(Expression<Func<Tipocppago, bool>> criteria)
		{
			return TipocppagoDao.Get(criteria);
		}
	}
}

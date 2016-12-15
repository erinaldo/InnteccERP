using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountComisioncobro()
		{
			return ComisioncobroDao.Count();
		}

		public long CountComisioncobro(Expression<Func<Comisioncobro, bool>> criteria)
		{
			return ComisioncobroDao.Count(criteria);
		}

		public int SaveComisioncobro(Comisioncobro entity)
		{
			return ComisioncobroDao.Save(entity);
		}

		public void UpdateComisioncobro(Comisioncobro entity)
		{
			ComisioncobroDao.Update(entity);
		}

		public void DeleteComisioncobro(int id)
		{
			ComisioncobroDao.Delete(id);
		}

		public List<Comisioncobro> GetAllComisioncobro()
		{
			return ComisioncobroDao.GetAll();
		}

		public List<Comisioncobro> GetAllComisioncobro(Expression<Func<Comisioncobro, bool>> criteria)
		{
			return ComisioncobroDao.GetAll(criteria);
		}

		public List<Comisioncobro> GetAllComisioncobro(string orders)
		{
			return ComisioncobroDao.GetAll(orders);
		}

		public List<Comisioncobro> GetAllComisioncobro(string conditions, string orders)
		{
			return ComisioncobroDao.GetAll(conditions, orders);
		}

		public Comisioncobro GetComisioncobro(int id)
		{
			return ComisioncobroDao.Get(id);
		}

		public Comisioncobro GetComisioncobro(Expression<Func<Comisioncobro, bool>> criteria)
		{
			return ComisioncobroDao.Get(criteria);
		}
	}
}

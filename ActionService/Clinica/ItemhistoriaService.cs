using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountItemhistoria()
		{
			return ItemhistoriaDao.Count();
		}

		public long CountItemhistoria(Expression<Func<Itemhistoria, bool>> criteria)
		{
			return ItemhistoriaDao.Count(criteria);
		}

		public int SaveItemhistoria(Itemhistoria entity)
		{
			return ItemhistoriaDao.Save(entity);
		}

		public void UpdateItemhistoria(Itemhistoria entity)
		{
			ItemhistoriaDao.Update(entity);
		}

		public void DeleteItemhistoria(int id)
		{
			ItemhistoriaDao.Delete(id);
		}

		public List<Itemhistoria> GetAllItemhistoria()
		{
			return ItemhistoriaDao.GetAll();
		}

		public List<Itemhistoria> GetAllItemhistoria(Expression<Func<Itemhistoria, bool>> criteria)
		{
			return ItemhistoriaDao.GetAll(criteria);
		}

		public List<Itemhistoria> GetAllItemhistoria(string orders)
		{
			return ItemhistoriaDao.GetAll(orders);
		}

		public List<Itemhistoria> GetAllItemhistoria(string conditions, string orders)
		{
			return ItemhistoriaDao.GetAll(conditions, orders);
		}

		public Itemhistoria GetItemhistoria(int id)
		{
			return ItemhistoriaDao.Get(id);
		}

		public Itemhistoria GetItemhistoria(Expression<Func<Itemhistoria, bool>> criteria)
		{
			return ItemhistoriaDao.Get(criteria);
		}
	}
}

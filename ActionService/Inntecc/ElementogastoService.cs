using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountElementogasto()
		{
			return ElementogastoDao.Count();
		}

		public long CountElementogasto(Expression<Func<Elementogasto, bool>> criteria)
		{
			return ElementogastoDao.Count(criteria);
		}

		public int SaveElementogasto(Elementogasto entity)
		{
			return ElementogastoDao.Save(entity);
		}

		public void UpdateElementogasto(Elementogasto entity)
		{
			ElementogastoDao.Update(entity);
		}

		public void DeleteElementogasto(int id)
		{
			ElementogastoDao.Delete(id);
		}

		public List<Elementogasto> GetAllElementogasto()
		{
			return ElementogastoDao.GetAll();
		}

		public List<Elementogasto> GetAllElementogasto(Expression<Func<Elementogasto, bool>> criteria)
		{
			return ElementogastoDao.GetAll(criteria);
		}

		public List<Elementogasto> GetAllElementogasto(string orders)
		{
			return ElementogastoDao.GetAll(orders);
		}

		public List<Elementogasto> GetAllElementogasto(string conditions, string orders)
		{
			return ElementogastoDao.GetAll(conditions, orders);
		}

		public Elementogasto GetElementogasto(int id)
		{
			return ElementogastoDao.Get(id);
		}

		public Elementogasto GetElementogasto(Expression<Func<Elementogasto, bool>> criteria)
		{
			return ElementogastoDao.Get(criteria);
		}
	}
}

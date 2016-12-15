using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountAreacentrocostro()
		{
			return AreacentrocostroDao.Count();
		}

		public long CountAreacentrocostro(Expression<Func<Areacentrocostro, bool>> criteria)
		{
			return AreacentrocostroDao.Count(criteria);
		}

		public int SaveAreacentrocostro(Areacentrocostro entity)
		{
			return AreacentrocostroDao.Save(entity);
		}

		public void UpdateAreacentrocostro(Areacentrocostro entity)
		{
			AreacentrocostroDao.Update(entity);
		}

		public void DeleteAreacentrocostro(int id)
		{
			AreacentrocostroDao.Delete(id);
		}

		public List<Areacentrocostro> GetAllAreacentrocostro()
		{
			return AreacentrocostroDao.GetAll();
		}

		public List<Areacentrocostro> GetAllAreacentrocostro(Expression<Func<Areacentrocostro, bool>> criteria)
		{
			return AreacentrocostroDao.GetAll(criteria);
		}

		public List<Areacentrocostro> GetAllAreacentrocostro(string orders)
		{
			return AreacentrocostroDao.GetAll(orders);
		}

		public List<Areacentrocostro> GetAllAreacentrocostro(string conditions, string orders)
		{
			return AreacentrocostroDao.GetAll(conditions, orders);
		}

		public Areacentrocostro GetAreacentrocostro(int id)
		{
			return AreacentrocostroDao.Get(id);
		}

		public Areacentrocostro GetAreacentrocostro(Expression<Func<Areacentrocostro, bool>> criteria)
		{
			return AreacentrocostroDao.Get(criteria);
		}
	}
}

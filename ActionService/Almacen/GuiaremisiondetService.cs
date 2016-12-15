using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountGuiaremisiondet()
		{
			return GuiaremisiondetDao.Count();
		}

		public long CountGuiaremisiondet(Expression<Func<Guiaremisiondet, bool>> criteria)
		{
			return GuiaremisiondetDao.Count(criteria);
		}

		public int SaveGuiaremisiondet(Guiaremisiondet entity)
		{
			return GuiaremisiondetDao.Save(entity);
		}

		public void UpdateGuiaremisiondet(Guiaremisiondet entity)
		{
			GuiaremisiondetDao.Update(entity);
		}

		public void DeleteGuiaremisiondet(int id)
		{
			GuiaremisiondetDao.Delete(id);
		}

		public List<Guiaremisiondet> GetAllGuiaremisiondet()
		{
			return GuiaremisiondetDao.GetAll();
		}

		public List<Guiaremisiondet> GetAllGuiaremisiondet(Expression<Func<Guiaremisiondet, bool>> criteria)
		{
			return GuiaremisiondetDao.GetAll(criteria);
		}

		public List<Guiaremisiondet> GetAllGuiaremisiondet(string orders)
		{
			return GuiaremisiondetDao.GetAll(orders);
		}

		public List<Guiaremisiondet> GetAllGuiaremisiondet(string conditions, string orders)
		{
			return GuiaremisiondetDao.GetAll(conditions, orders);
		}

		public Guiaremisiondet GetGuiaremisiondet(int id)
		{
			return GuiaremisiondetDao.Get(id);
		}

		public Guiaremisiondet GetGuiaremisiondet(Expression<Func<Guiaremisiondet, bool>> criteria)
		{
			return GuiaremisiondetDao.Get(criteria);
		}
	}
}

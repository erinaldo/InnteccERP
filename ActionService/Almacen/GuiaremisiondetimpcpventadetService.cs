using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountGuiaremisiondetimpcpventadet()
		{
			return GuiaremisiondetimpcpventadetDao.Count();
		}

		public long CountGuiaremisiondetimpcpventadet(Expression<Func<Guiaremisiondetimpcpventadet, bool>> criteria)
		{
			return GuiaremisiondetimpcpventadetDao.Count(criteria);
		}

		public int SaveGuiaremisiondetimpcpventadet(Guiaremisiondetimpcpventadet entity)
		{
			return GuiaremisiondetimpcpventadetDao.Save(entity);
		}

		public void UpdateGuiaremisiondetimpcpventadet(Guiaremisiondetimpcpventadet entity)
		{
			GuiaremisiondetimpcpventadetDao.Update(entity);
		}

		public void DeleteGuiaremisiondetimpcpventadet(int id)
		{
			GuiaremisiondetimpcpventadetDao.Delete(id);
		}

		public List<Guiaremisiondetimpcpventadet> GetAllGuiaremisiondetimpcpventadet()
		{
			return GuiaremisiondetimpcpventadetDao.GetAll();
		}

		public List<Guiaremisiondetimpcpventadet> GetAllGuiaremisiondetimpcpventadet(Expression<Func<Guiaremisiondetimpcpventadet, bool>> criteria)
		{
			return GuiaremisiondetimpcpventadetDao.GetAll(criteria);
		}

		public List<Guiaremisiondetimpcpventadet> GetAllGuiaremisiondetimpcpventadet(string orders)
		{
			return GuiaremisiondetimpcpventadetDao.GetAll(orders);
		}

		public List<Guiaremisiondetimpcpventadet> GetAllGuiaremisiondetimpcpventadet(string conditions, string orders)
		{
			return GuiaremisiondetimpcpventadetDao.GetAll(conditions, orders);
		}

		public Guiaremisiondetimpcpventadet GetGuiaremisiondetimpcpventadet(int id)
		{
			return GuiaremisiondetimpcpventadetDao.Get(id);
		}

		public Guiaremisiondetimpcpventadet GetGuiaremisiondetimpcpventadet(Expression<Func<Guiaremisiondetimpcpventadet, bool>> criteria)
		{
			return GuiaremisiondetimpcpventadetDao.Get(criteria);
		}
	}
}

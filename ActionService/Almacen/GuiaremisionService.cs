using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountGuiaremision()
		{
			return GuiaremisionDao.Count();
		}

		public long CountGuiaremision(Expression<Func<Guiaremision, bool>> criteria)
		{
			return GuiaremisionDao.Count(criteria);
		}

		public int SaveGuiaremision(Guiaremision entity)
		{
			return GuiaremisionDao.Save(entity);
		}

		public void UpdateGuiaremision(Guiaremision entity)
		{
			GuiaremisionDao.Update(entity);
		}

		public void DeleteGuiaremision(int id)
		{
			GuiaremisionDao.Delete(id);
		}

		public List<Guiaremision> GetAllGuiaremision()
		{
			return GuiaremisionDao.GetAll();
		}

		public List<Guiaremision> GetAllGuiaremision(Expression<Func<Guiaremision, bool>> criteria)
		{
			return GuiaremisionDao.GetAll(criteria);
		}

		public List<Guiaremision> GetAllGuiaremision(string orders)
		{
			return GuiaremisionDao.GetAll(orders);
		}

		public List<Guiaremision> GetAllGuiaremision(string conditions, string orders)
		{
			return GuiaremisionDao.GetAll(conditions, orders);
		}

		public Guiaremision GetGuiaremision(int id)
		{
			return GuiaremisionDao.Get(id);
		}

		public Guiaremision GetGuiaremision(Expression<Func<Guiaremision, bool>> criteria)
		{
			return GuiaremisionDao.Get(criteria);
		}
	}
}

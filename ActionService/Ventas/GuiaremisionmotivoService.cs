using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountGuiaremisionmotivo()
		{
			return GuiaremisionmotivoDao.Count();
		}

		public long CountGuiaremisionmotivo(Expression<Func<Guiaremisionmotivo, bool>> criteria)
		{
			return GuiaremisionmotivoDao.Count(criteria);
		}

		public int SaveGuiaremisionmotivo(Guiaremisionmotivo entity)
		{
			return GuiaremisionmotivoDao.Save(entity);
		}

		public void UpdateGuiaremisionmotivo(Guiaremisionmotivo entity)
		{
			GuiaremisionmotivoDao.Update(entity);
		}

		public void DeleteGuiaremisionmotivo(int id)
		{
			GuiaremisionmotivoDao.Delete(id);
		}

		public List<Guiaremisionmotivo> GetAllGuiaremisionmotivo()
		{
			return GuiaremisionmotivoDao.GetAll();
		}

		public List<Guiaremisionmotivo> GetAllGuiaremisionmotivo(Expression<Func<Guiaremisionmotivo, bool>> criteria)
		{
			return GuiaremisionmotivoDao.GetAll(criteria);
		}

		public List<Guiaremisionmotivo> GetAllGuiaremisionmotivo(string orders)
		{
			return GuiaremisionmotivoDao.GetAll(orders);
		}

		public List<Guiaremisionmotivo> GetAllGuiaremisionmotivo(string conditions, string orders)
		{
			return GuiaremisionmotivoDao.GetAll(conditions, orders);
		}

		public Guiaremisionmotivo GetGuiaremisionmotivo(int id)
		{
			return GuiaremisionmotivoDao.Get(id);
		}

		public Guiaremisionmotivo GetGuiaremisionmotivo(Expression<Func<Guiaremisionmotivo, bool>> criteria)
		{
			return GuiaremisionmotivoDao.Get(criteria);
		}
	}
}

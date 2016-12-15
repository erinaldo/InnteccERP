using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizaciondanioelemento()
		{
			return ValorizaciondanioelementoDao.Count();
		}

		public long CountValorizaciondanioelemento(Expression<Func<Valorizaciondanioelemento, bool>> criteria)
		{
			return ValorizaciondanioelementoDao.Count(criteria);
		}

		public int SaveValorizaciondanioelemento(Valorizaciondanioelemento entity)
		{
			return ValorizaciondanioelementoDao.Save(entity);
		}

		public void UpdateValorizaciondanioelemento(Valorizaciondanioelemento entity)
		{
			ValorizaciondanioelementoDao.Update(entity);
		}

		public void DeleteValorizaciondanioelemento(int id)
		{
			ValorizaciondanioelementoDao.Delete(id);
		}

		public List<Valorizaciondanioelemento> GetAllValorizaciondanioelemento()
		{
			return ValorizaciondanioelementoDao.GetAll();
		}

		public List<Valorizaciondanioelemento> GetAllValorizaciondanioelemento(Expression<Func<Valorizaciondanioelemento, bool>> criteria)
		{
			return ValorizaciondanioelementoDao.GetAll(criteria);
		}

		public List<Valorizaciondanioelemento> GetAllValorizaciondanioelemento(string orders)
		{
			return ValorizaciondanioelementoDao.GetAll(orders);
		}

		public List<Valorizaciondanioelemento> GetAllValorizaciondanioelemento(string conditions, string orders)
		{
			return ValorizaciondanioelementoDao.GetAll(conditions, orders);
		}

		public Valorizaciondanioelemento GetValorizaciondanioelemento(int id)
		{
			return ValorizaciondanioelementoDao.Get(id);
		}

		public Valorizaciondanioelemento GetValorizaciondanioelemento(Expression<Func<Valorizaciondanioelemento, bool>> criteria)
		{
			return ValorizaciondanioelementoDao.Get(criteria);
		}
	}
}

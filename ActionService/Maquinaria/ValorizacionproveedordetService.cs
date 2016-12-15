using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorizacionproveedordet()
		{
			return ValorizacionproveedordetDao.Count();
		}

		public long CountValorizacionproveedordet(Expression<Func<Valorizacionproveedordet, bool>> criteria)
		{
			return ValorizacionproveedordetDao.Count(criteria);
		}

		public int SaveValorizacionproveedordet(Valorizacionproveedordet entity)
		{
			return ValorizacionproveedordetDao.Save(entity);
		}

		public void UpdateValorizacionproveedordet(Valorizacionproveedordet entity)
		{
			ValorizacionproveedordetDao.Update(entity);
		}

		public void DeleteValorizacionproveedordet(int id)
		{
			ValorizacionproveedordetDao.Delete(id);
		}

		public List<Valorizacionproveedordet> GetAllValorizacionproveedordet()
		{
			return ValorizacionproveedordetDao.GetAll();
		}

		public List<Valorizacionproveedordet> GetAllValorizacionproveedordet(Expression<Func<Valorizacionproveedordet, bool>> criteria)
		{
			return ValorizacionproveedordetDao.GetAll(criteria);
		}

		public List<Valorizacionproveedordet> GetAllValorizacionproveedordet(string orders)
		{
			return ValorizacionproveedordetDao.GetAll(orders);
		}

		public List<Valorizacionproveedordet> GetAllValorizacionproveedordet(string conditions, string orders)
		{
			return ValorizacionproveedordetDao.GetAll(conditions, orders);
		}

		public Valorizacionproveedordet GetValorizacionproveedordet(int id)
		{
			return ValorizacionproveedordetDao.Get(id);
		}

		public Valorizacionproveedordet GetValorizacionproveedordet(Expression<Func<Valorizacionproveedordet, bool>> criteria)
		{
			return ValorizacionproveedordetDao.Get(criteria);
		}
	}
}

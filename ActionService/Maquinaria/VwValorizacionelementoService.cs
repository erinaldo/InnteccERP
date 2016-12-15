using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizacionelemento()
		{
			return VwValorizacionelementoDao.Count();
		}

		public long CountVwValorizacionelemento(Expression<Func<VwValorizacionelemento, bool>> criteria)
		{
			return VwValorizacionelementoDao.Count(criteria);
		}

		public List<VwValorizacionelemento> GetAllVwValorizacionelemento()
		{
			return VwValorizacionelementoDao.GetAll();
		}

		public List<VwValorizacionelemento> GetAllVwValorizacionelemento(Expression<Func<VwValorizacionelemento, bool>> criteria)
		{
			return VwValorizacionelementoDao.GetAll(criteria);
		}

		public List<VwValorizacionelemento> GetAllVwValorizacionelemento(string orders)
		{
			return VwValorizacionelementoDao.GetAll(orders);
		}

		public List<VwValorizacionelemento> GetAllVwValorizacionelemento(string conditions, string orders)
		{
			return VwValorizacionelementoDao.GetAll(conditions, orders);
		}

		public VwValorizacionelemento GetVwValorizacionelemento(int id)
		{
			return VwValorizacionelementoDao.Get(id);
		}

		public VwValorizacionelemento GetVwValorizacionelemento(Expression<Func<VwValorizacionelemento, bool>> criteria)
		{
			return VwValorizacionelementoDao.Get(criteria);
		}
	}
}

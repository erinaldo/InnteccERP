using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwValorizaciondanioelemento()
		{
			return VwValorizaciondanioelementoDao.Count();
		}

		public long CountVwValorizaciondanioelemento(Expression<Func<VwValorizaciondanioelemento, bool>> criteria)
		{
			return VwValorizaciondanioelementoDao.Count(criteria);
		}

		public List<VwValorizaciondanioelemento> GetAllVwValorizaciondanioelemento()
		{
			return VwValorizaciondanioelementoDao.GetAll();
		}

		public List<VwValorizaciondanioelemento> GetAllVwValorizaciondanioelemento(Expression<Func<VwValorizaciondanioelemento, bool>> criteria)
		{
			return VwValorizaciondanioelementoDao.GetAll(criteria);
		}

		public List<VwValorizaciondanioelemento> GetAllVwValorizaciondanioelemento(string orders)
		{
			return VwValorizaciondanioelementoDao.GetAll(orders);
		}

		public List<VwValorizaciondanioelemento> GetAllVwValorizaciondanioelemento(string conditions, string orders)
		{
			return VwValorizaciondanioelementoDao.GetAll(conditions, orders);
		}

		public VwValorizaciondanioelemento GetVwValorizaciondanioelemento(int id)
		{
			return VwValorizaciondanioelementoDao.Get(id);
		}

		public VwValorizaciondanioelemento GetVwValorizaciondanioelemento(Expression<Func<VwValorizaciondanioelemento, bool>> criteria)
		{
			return VwValorizaciondanioelementoDao.Get(criteria);
		}
	}
}

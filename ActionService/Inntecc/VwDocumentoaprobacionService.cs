using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwDocumentoaprobacion()
		{
			return VwDocumentoaprobacionDao.Count();
		}

		public long CountVwDocumentoaprobacion(Expression<Func<VwDocumentoaprobacion, bool>> criteria)
		{
			return VwDocumentoaprobacionDao.Count(criteria);
		}

		public List<VwDocumentoaprobacion> GetAllVwDocumentoaprobacion()
		{
			return VwDocumentoaprobacionDao.GetAll();
		}

		public List<VwDocumentoaprobacion> GetAllVwDocumentoaprobacion(Expression<Func<VwDocumentoaprobacion, bool>> criteria)
		{
			return VwDocumentoaprobacionDao.GetAll(criteria);
		}

		public List<VwDocumentoaprobacion> GetAllVwDocumentoaprobacion(string orders)
		{
			return VwDocumentoaprobacionDao.GetAll(orders);
		}

		public List<VwDocumentoaprobacion> GetAllVwDocumentoaprobacion(string conditions, string orders)
		{
			return VwDocumentoaprobacionDao.GetAll(conditions, orders);
		}

		public VwDocumentoaprobacion GetVwDocumentoaprobacion(int id)
		{
			return VwDocumentoaprobacionDao.Get(id);
		}

		public VwDocumentoaprobacion GetVwDocumentoaprobacion(Expression<Func<VwDocumentoaprobacion, bool>> criteria)
		{
			return VwDocumentoaprobacionDao.Get(criteria);
		}
	}
}

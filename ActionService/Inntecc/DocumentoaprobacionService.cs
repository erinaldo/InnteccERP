using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountDocumentoaprobacion()
		{
			return DocumentoaprobacionDao.Count();
		}

		public long CountDocumentoaprobacion(Expression<Func<Documentoaprobacion, bool>> criteria)
		{
			return DocumentoaprobacionDao.Count(criteria);
		}

		public int SaveDocumentoaprobacion(Documentoaprobacion entity)
		{
			return DocumentoaprobacionDao.Save(entity);
		}

		public void UpdateDocumentoaprobacion(Documentoaprobacion entity)
		{
			DocumentoaprobacionDao.Update(entity);
		}

		public void DeleteDocumentoaprobacion(int id)
		{
			DocumentoaprobacionDao.Delete(id);
		}

		public List<Documentoaprobacion> GetAllDocumentoaprobacion()
		{
			return DocumentoaprobacionDao.GetAll();
		}

		public List<Documentoaprobacion> GetAllDocumentoaprobacion(Expression<Func<Documentoaprobacion, bool>> criteria)
		{
			return DocumentoaprobacionDao.GetAll(criteria);
		}

		public List<Documentoaprobacion> GetAllDocumentoaprobacion(string orders)
		{
			return DocumentoaprobacionDao.GetAll(orders);
		}

		public List<Documentoaprobacion> GetAllDocumentoaprobacion(string conditions, string orders)
		{
			return DocumentoaprobacionDao.GetAll(conditions, orders);
		}

		public Documentoaprobacion GetDocumentoaprobacion(int id)
		{
			return DocumentoaprobacionDao.Get(id);
		}

		public Documentoaprobacion GetDocumentoaprobacion(Expression<Func<Documentoaprobacion, bool>> criteria)
		{
			return DocumentoaprobacionDao.Get(criteria);
		}
	}
}

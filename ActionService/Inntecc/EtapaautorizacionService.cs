using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEtapaautorizacion()
		{
			return EtapaautorizacionDao.Count();
		}

		public long CountEtapaautorizacion(Expression<Func<Etapaautorizacion, bool>> criteria)
		{
			return EtapaautorizacionDao.Count(criteria);
		}

		public int SaveEtapaautorizacion(Etapaautorizacion entity)
		{
			return EtapaautorizacionDao.Save(entity);
		}

		public void UpdateEtapaautorizacion(Etapaautorizacion entity)
		{
			EtapaautorizacionDao.Update(entity);
		}

		public void DeleteEtapaautorizacion(int id)
		{
			EtapaautorizacionDao.Delete(id);
		}

		public List<Etapaautorizacion> GetAllEtapaautorizacion()
		{
			return EtapaautorizacionDao.GetAll();
		}

		public List<Etapaautorizacion> GetAllEtapaautorizacion(Expression<Func<Etapaautorizacion, bool>> criteria)
		{
			return EtapaautorizacionDao.GetAll(criteria);
		}

		public List<Etapaautorizacion> GetAllEtapaautorizacion(string orders)
		{
			return EtapaautorizacionDao.GetAll(orders);
		}

		public List<Etapaautorizacion> GetAllEtapaautorizacion(string conditions, string orders)
		{
			return EtapaautorizacionDao.GetAll(conditions, orders);
		}

		public Etapaautorizacion GetEtapaautorizacion(int id)
		{
			return EtapaautorizacionDao.Get(id);
		}

		public Etapaautorizacion GetEtapaautorizacion(Expression<Func<Etapaautorizacion, bool>> criteria)
		{
			return EtapaautorizacionDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEtapaautorizaciondetalle()
		{
			return EtapaautorizaciondetalleDao.Count();
		}

		public long CountEtapaautorizaciondetalle(Expression<Func<Etapaautorizaciondetalle, bool>> criteria)
		{
			return EtapaautorizaciondetalleDao.Count(criteria);
		}

		public int SaveEtapaautorizaciondetalle(Etapaautorizaciondetalle entity)
		{
			return EtapaautorizaciondetalleDao.Save(entity);
		}

		public void UpdateEtapaautorizaciondetalle(Etapaautorizaciondetalle entity)
		{
			EtapaautorizaciondetalleDao.Update(entity);
		}

		public void DeleteEtapaautorizaciondetalle(int id)
		{
			EtapaautorizaciondetalleDao.Delete(id);
		}

		public List<Etapaautorizaciondetalle> GetAllEtapaautorizaciondetalle()
		{
			return EtapaautorizaciondetalleDao.GetAll();
		}

		public List<Etapaautorizaciondetalle> GetAllEtapaautorizaciondetalle(Expression<Func<Etapaautorizaciondetalle, bool>> criteria)
		{
			return EtapaautorizaciondetalleDao.GetAll(criteria);
		}

		public List<Etapaautorizaciondetalle> GetAllEtapaautorizaciondetalle(string orders)
		{
			return EtapaautorizaciondetalleDao.GetAll(orders);
		}

		public List<Etapaautorizaciondetalle> GetAllEtapaautorizaciondetalle(string conditions, string orders)
		{
			return EtapaautorizaciondetalleDao.GetAll(conditions, orders);
		}

		public Etapaautorizaciondetalle GetEtapaautorizaciondetalle(int id)
		{
			return EtapaautorizaciondetalleDao.Get(id);
		}

		public Etapaautorizaciondetalle GetEtapaautorizaciondetalle(Expression<Func<Etapaautorizaciondetalle, bool>> criteria)
		{
			return EtapaautorizaciondetalleDao.Get(criteria);
		}
	}
}

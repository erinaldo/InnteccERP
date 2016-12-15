using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountGrupousuario()
        {
            return GrupousuarioDao.Count();
        }

        public long CountGrupousuario(Expression<Func<Grupousuario, bool>> criteria)
        {
            return GrupousuarioDao.Count(criteria);
        }

        public int SaveGrupousuario(Grupousuario entity)
        {
            return GrupousuarioDao.Save(entity);
        }

        public void UpdateGrupousuario(Grupousuario entity)
        {
            GrupousuarioDao.Update(entity);
        }

        public void DeleteGrupousuario(int id)
        {
            GrupousuarioDao.Delete(id);
        }

        public List<Grupousuario> GetAllGrupousuario()
        {
            return GrupousuarioDao.GetAll();
        }

        public List<Grupousuario> GetAllGrupousuario(Expression<Func<Grupousuario, bool>> criteria)
        {
            return GrupousuarioDao.GetAll(criteria);
        }

        public List<Grupousuario> GetAllGrupousuario(string orders)
        {
            return GrupousuarioDao.GetAll(orders);
        }

        public List<Grupousuario> GetAllGrupousuario(string conditions, string orders)
        {
            return GrupousuarioDao.GetAll(conditions, orders);
        }

        public Grupousuario GetGrupousuario(int id)
        {
            return GrupousuarioDao.Get(id);
        }

        public Grupousuario GetGrupousuario(Expression<Func<Grupousuario, bool>> criteria)
        {
            return GrupousuarioDao.Get(criteria);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountPersona()
        {
            return PersonaDao.Count();
        }

        public long CountPersona(Expression<Func<Persona, bool>> criteria)
        {
            return PersonaDao.Count(criteria);
        }

        public int SavePersona(Persona entity)
        {
            return PersonaDao.Save(entity);
        }

        public void UpdatePersona(Persona entity)
        {
            PersonaDao.Update(entity);
        }

        public void DeletePersona(int id)
        {
            PersonaDao.Delete(id);
        }

        public List<Persona> GetAllPersona()
        {
            return PersonaDao.GetAll();
        }

        public List<Persona> GetAllPersona(Expression<Func<Persona, bool>> criteria)
        {
            return PersonaDao.GetAll(criteria);
        }

        public List<Persona> GetAllPersona(string orders)
        {
            return PersonaDao.GetAll(orders);
        }

        public List<Persona> GetAllPersona(string conditions, string orders)
        {
            return PersonaDao.GetAll(conditions, orders);
        }

        public Persona GetPersona(int id)
        {
            return PersonaDao.Get(id);
        }

        public Persona GetPersona(Expression<Func<Persona, bool>> criteria)
        {
            return PersonaDao.Get(criteria);
        }

        public bool NroDocumentoPersonaExiste(string nroDocumento, int idPersona)
        {
            Persona persona = idPersona == 0 ? 
                PersonaDao.Get(p => p.Nrodocentidad == nroDocumento.Trim()) : 
                PersonaDao.Get(p => p.Nrodocentidad == nroDocumento.Trim() && p.Idpersona != idPersona);

            return persona != null;
        }
    }
}

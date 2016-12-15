using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountPersonacontacto()
		{
			return PersonacontactoDao.Count();
		}

		public long CountPersonacontacto(Expression<Func<Personacontacto, bool>> criteria)
		{
			return PersonacontactoDao.Count(criteria);
		}

		public int SavePersonacontacto(Personacontacto entity)
		{
			return PersonacontactoDao.Save(entity);
		}

		public void UpdatePersonacontacto(Personacontacto entity)
		{
			PersonacontactoDao.Update(entity);
		}

		public void DeletePersonacontacto(int id)
		{
			PersonacontactoDao.Delete(id);
		}

		public List<Personacontacto> GetAllPersonacontacto()
		{
			return PersonacontactoDao.GetAll();
		}

		public List<Personacontacto> GetAllPersonacontacto(Expression<Func<Personacontacto, bool>> criteria)
		{
			return PersonacontactoDao.GetAll(criteria);
		}

		public List<Personacontacto> GetAllPersonacontacto(string orders)
		{
			return PersonacontactoDao.GetAll(orders);
		}

		public List<Personacontacto> GetAllPersonacontacto(string conditions, string orders)
		{
			return PersonacontactoDao.GetAll(conditions, orders);
		}

		public Personacontacto GetPersonacontacto(int id)
		{
			return PersonacontactoDao.Get(id);
		}

		public Personacontacto GetPersonacontacto(Expression<Func<Personacontacto, bool>> criteria)
		{
			return PersonacontactoDao.Get(criteria);
		}
	}
}

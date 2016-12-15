using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountPlantillahistoriadet()
		{
			return PlantillahistoriadetDao.Count();
		}

		public long CountPlantillahistoriadet(Expression<Func<Plantillahistoriadet, bool>> criteria)
		{
			return PlantillahistoriadetDao.Count(criteria);
		}

		public int SavePlantillahistoriadet(Plantillahistoriadet entity)
		{
			return PlantillahistoriadetDao.Save(entity);
		}

		public void UpdatePlantillahistoriadet(Plantillahistoriadet entity)
		{
			PlantillahistoriadetDao.Update(entity);
		}

		public void DeletePlantillahistoriadet(int id)
		{
			PlantillahistoriadetDao.Delete(id);
		}

		public List<Plantillahistoriadet> GetAllPlantillahistoriadet()
		{
			return PlantillahistoriadetDao.GetAll();
		}

		public List<Plantillahistoriadet> GetAllPlantillahistoriadet(Expression<Func<Plantillahistoriadet, bool>> criteria)
		{
			return PlantillahistoriadetDao.GetAll(criteria);
		}

		public List<Plantillahistoriadet> GetAllPlantillahistoriadet(string orders)
		{
			return PlantillahistoriadetDao.GetAll(orders);
		}

		public List<Plantillahistoriadet> GetAllPlantillahistoriadet(string conditions, string orders)
		{
			return PlantillahistoriadetDao.GetAll(conditions, orders);
		}

		public Plantillahistoriadet GetPlantillahistoriadet(int id)
		{
			return PlantillahistoriadetDao.Get(id);
		}

		public Plantillahistoriadet GetPlantillahistoriadet(Expression<Func<Plantillahistoriadet, bool>> criteria)
		{
			return PlantillahistoriadetDao.Get(criteria);
		}
	}
}

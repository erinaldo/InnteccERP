using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwPlantillahistoriadet()
		{
			return VwPlantillahistoriadetDao.Count();
		}

		public long CountVwPlantillahistoriadet(Expression<Func<VwPlantillahistoriadet, bool>> criteria)
		{
			return VwPlantillahistoriadetDao.Count(criteria);
		}

		public List<VwPlantillahistoriadet> GetAllVwPlantillahistoriadet()
		{
			return VwPlantillahistoriadetDao.GetAll();
		}

		public List<VwPlantillahistoriadet> GetAllVwPlantillahistoriadet(Expression<Func<VwPlantillahistoriadet, bool>> criteria)
		{
			return VwPlantillahistoriadetDao.GetAll(criteria);
		}

		public List<VwPlantillahistoriadet> GetAllVwPlantillahistoriadet(string orders)
		{
			return VwPlantillahistoriadetDao.GetAll(orders);
		}

		public List<VwPlantillahistoriadet> GetAllVwPlantillahistoriadet(string conditions, string orders)
		{
			return VwPlantillahistoriadetDao.GetAll(conditions, orders);
		}

		public VwPlantillahistoriadet GetVwPlantillahistoriadet(int id)
		{
			return VwPlantillahistoriadetDao.Get(id);
		}

		public VwPlantillahistoriadet GetVwPlantillahistoriadet(Expression<Func<VwPlantillahistoriadet, bool>> criteria)
		{
			return VwPlantillahistoriadetDao.Get(criteria);
		}
	}
}

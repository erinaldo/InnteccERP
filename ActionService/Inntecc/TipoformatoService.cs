using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipoformato()
		{
			return TipoformatoDao.Count();
		}

		public long CountTipoformato(Expression<Func<Tipoformato, bool>> criteria)
		{
			return TipoformatoDao.Count(criteria);
		}

		public int SaveTipoformato(Tipoformato entity)
		{
			return TipoformatoDao.Save(entity);
		}

		public void UpdateTipoformato(Tipoformato entity)
		{
			TipoformatoDao.Update(entity);
		}

		public void DeleteTipoformato(int id)
		{
			TipoformatoDao.Delete(id);
		}

		public List<Tipoformato> GetAllTipoformato()
		{
			return TipoformatoDao.GetAll();
		}

		public List<Tipoformato> GetAllTipoformato(Expression<Func<Tipoformato, bool>> criteria)
		{
			return TipoformatoDao.GetAll(criteria);
		}

		public List<Tipoformato> GetAllTipoformato(string orders)
		{
			return TipoformatoDao.GetAll(orders);
		}

		public List<Tipoformato> GetAllTipoformato(string conditions, string orders)
		{
			return TipoformatoDao.GetAll(conditions, orders);
		}

		public Tipoformato GetTipoformato(int id)
		{
			return TipoformatoDao.Get(id);
		}

		public Tipoformato GetTipoformato(Expression<Func<Tipoformato, bool>> criteria)
		{
			return TipoformatoDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwGuiaremisionimpsalidaalmacen()
		{
			return VwGuiaremisionimpsalidaalmacenDao.Count();
		}

		public long CountVwGuiaremisionimpsalidaalmacen(Expression<Func<VwGuiaremisionimpsalidaalmacen, bool>> criteria)
		{
			return VwGuiaremisionimpsalidaalmacenDao.Count(criteria);
		}

		public List<VwGuiaremisionimpsalidaalmacen> GetAllVwGuiaremisionimpsalidaalmacen()
		{
			return VwGuiaremisionimpsalidaalmacenDao.GetAll();
		}

		public List<VwGuiaremisionimpsalidaalmacen> GetAllVwGuiaremisionimpsalidaalmacen(Expression<Func<VwGuiaremisionimpsalidaalmacen, bool>> criteria)
		{
			return VwGuiaremisionimpsalidaalmacenDao.GetAll(criteria);
		}

		public List<VwGuiaremisionimpsalidaalmacen> GetAllVwGuiaremisionimpsalidaalmacen(string orders)
		{
			return VwGuiaremisionimpsalidaalmacenDao.GetAll(orders);
		}

		public List<VwGuiaremisionimpsalidaalmacen> GetAllVwGuiaremisionimpsalidaalmacen(string conditions, string orders)
		{
			return VwGuiaremisionimpsalidaalmacenDao.GetAll(conditions, orders);
		}

		public VwGuiaremisionimpsalidaalmacen GetVwGuiaremisionimpsalidaalmacen(int id)
		{
			return VwGuiaremisionimpsalidaalmacenDao.Get(id);
		}

		public VwGuiaremisionimpsalidaalmacen GetVwGuiaremisionimpsalidaalmacen(Expression<Func<VwGuiaremisionimpsalidaalmacen, bool>> criteria)
		{
			return VwGuiaremisionimpsalidaalmacenDao.Get(criteria);
		}
	}
}

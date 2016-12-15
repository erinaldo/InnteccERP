using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwReporteusuario()
		{
			return VwReporteusuarioDao.Count();
		}

		public long CountVwReporteusuario(Expression<Func<VwReporteusuario, bool>> criteria)
		{
			return VwReporteusuarioDao.Count(criteria);
		}

		public List<VwReporteusuario> GetAllVwReporteusuario()
		{
			return VwReporteusuarioDao.GetAll();
		}

		public List<VwReporteusuario> GetAllVwReporteusuario(Expression<Func<VwReporteusuario, bool>> criteria)
		{
			return VwReporteusuarioDao.GetAll(criteria);
		}

		public List<VwReporteusuario> GetAllVwReporteusuario(string orders)
		{
			return VwReporteusuarioDao.GetAll(orders);
		}

		public List<VwReporteusuario> GetAllVwReporteusuario(string conditions, string orders)
		{
			return VwReporteusuarioDao.GetAll(conditions, orders);
		}

		public VwReporteusuario GetVwReporteusuario(int id)
		{
			return VwReporteusuarioDao.Get(id);
		}

		public VwReporteusuario GetVwReporteusuario(Expression<Func<VwReporteusuario, bool>> criteria)
		{
			return VwReporteusuarioDao.Get(criteria);
		}
	}
}

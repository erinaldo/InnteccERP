using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountPlan()
		{
			return PlanDao.Count();
		}

		public long CountPlan(Expression<Func<Plan, bool>> criteria)
		{
			return PlanDao.Count(criteria);
		}

		public int SavePlan(Plan entity)
		{
			return PlanDao.Save(entity);
		}

		public void UpdatePlan(Plan entity)
		{
			PlanDao.Update(entity);
		}

		public void DeletePlan(int id)
		{
			PlanDao.Delete(id);
		}

		public List<Plan> GetAllPlan()
		{
			return PlanDao.GetAll();
		}

		public List<Plan> GetAllPlan(Expression<Func<Plan, bool>> criteria)
		{
			return PlanDao.GetAll(criteria);
		}

		public List<Plan> GetAllPlan(string orders)
		{
			return PlanDao.GetAll(orders);
		}

		public List<Plan> GetAllPlan(string conditions, string orders)
		{
			return PlanDao.GetAll(conditions, orders);
		}

		public Plan GetPlan(int id)
		{
			return PlanDao.Get(id);
		}

		public Plan GetPlan(Expression<Func<Plan, bool>> criteria)
		{
			return PlanDao.Get(criteria);
		}
	}
}

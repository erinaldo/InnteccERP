using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountLogStocks()
		{
			return LogStocksDao.Count();
		}

		public long CountLogStocks(Expression<Func<LogStocks, bool>> criteria)
		{
			return LogStocksDao.Count(criteria);
		}

		public int SaveLogStocks(LogStocks entity)
		{
			return LogStocksDao.Save(entity);
		}

		public void UpdateLogStocks(LogStocks entity)
		{
			LogStocksDao.Update(entity);
		}

		public void DeleteLogStocks(int id)
		{
			LogStocksDao.Delete(id);
		}

		public List<LogStocks> GetAllLogStocks()
		{
			return LogStocksDao.GetAll();
		}

		public List<LogStocks> GetAllLogStocks(Expression<Func<LogStocks, bool>> criteria)
		{
			return LogStocksDao.GetAll(criteria);
		}

		public List<LogStocks> GetAllLogStocks(string orders)
		{
			return LogStocksDao.GetAll(orders);
		}

		public List<LogStocks> GetAllLogStocks(string conditions, string orders)
		{
			return LogStocksDao.GetAll(conditions, orders);
		}

		public LogStocks GetLogStocks(int id)
		{
			return LogStocksDao.Get(id);
		}

		public LogStocks GetLogStocks(Expression<Func<LogStocks, bool>> criteria)
		{
			return LogStocksDao.Get(criteria);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace DataObjects.Dao.Core
{
    public class Dao<T> : IDao<T> where T : class
    {
        public string NameRelation { get; set; }
        public string PropertyNameCorrelative { get; set; }
        public int PropertyCorrelativeLength { get; set; }
        public Dao()
        {
            var schemaAttribute = (SchemaAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(SchemaAttribute));
            var aliasAttribute = (AliasAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(AliasAttribute));
            NameRelation = string.Format("{0}.{1}", schemaAttribute.Name, aliasAttribute.Name);
            var propertyInfoCorrelative = typeof(T).GetProperties().FirstOrDefault(prop => prop.IsDefined(typeof(RequiredAttribute), false));
            if (propertyInfoCorrelative != null)
            {
                var stringLengthAttribute = (StringLengthAttribute)Attribute.GetCustomAttribute(propertyInfoCorrelative, typeof(StringLengthAttribute));
                PropertyNameCorrelative = propertyInfoCorrelative.Name;
                PropertyCorrelativeLength = stringLengthAttribute.MaximumLength;
            }
        }
        public long Count()
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                return db.Count<T>();
            }
        }
        public long Count(Expression<Func<T, bool>> criteria)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                return db.Count(criteria);
            }
        }
        public int Save(T entity)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                return (int)db.Insert(entity, true);
            }
        }
        public void Update(T entity)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.Update(entity);
            }
        }
        public void Delete(int id)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.DeleteById<T>(id);
            }
        }
        public List<T> GetAll()
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                return db.Select<T>();               
            }
        }
        public List<T> GetAll(Expression<Func<T, bool>> criteria)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                return db.Select(criteria);
            }
        }
        public List<T> GetAll(string orders)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                return db.SqlList<T>(string.Format("select * from {0} order by {1}", NameRelation, orders));
            }
        }
        public List<T> GetAll(string conditions, string orders)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                string sql = string.Format("select * from {0} where {1} order by {2}", NameRelation, conditions, orders);
                return db.SqlList<T>(sql);                
            }
        }
        public T Get(int id)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                return db.SingleById<T>(id);
            }
        }
        public T Get(Expression<Func<T, bool>> criteria)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                return db.Single(criteria);
            }
        }
        public string GetNextAlphanumericCorrelative()
        {
            if (string.IsNullOrEmpty(PropertyNameCorrelative) || PropertyCorrelativeLength <= 0)
                return string.Empty;

            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                var sql = string.Format("SELECT Max(cast({0} as integer)) FROM {1}", PropertyNameCorrelative, NameRelation);
                var sgteCodigo = db.SqlScalar<int>(sql) + 1;
                return sgteCodigo.ToString(string.Format("D{0}", PropertyCorrelativeLength));
            }
        }
        public bool ExistsAlphanumericCorrelative(string value)
        {
            if (string.IsNullOrEmpty(PropertyNameCorrelative) || PropertyCorrelativeLength <= 0)
                return false;

            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                var sql = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", NameRelation, PropertyNameCorrelative, value);
                return db.Exists<T>(sql);
            }
        }
        public void ExecuteNonQuery(string sqlCommand)
        {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                db.ExecuteSql(sqlCommand);
            }
        }
    }
}
using MemberShipManage.Infrastructure.UnitOfWork;
using System.Data.Entity;
using MemberShipManage.Infrastructure.Extension;
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace PersonalSite.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private IUnitOfWork unitOfWork;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dbSet = unitOfWork.Context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            entity.SetObjectValue("InDate", DateTime.Now);
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.SetObjectValue("LastEditDate", DateTime.Now);
            dbSet.Attach(entity);
            unitOfWork.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (unitOfWork.Context.Entry(entity).State == System.Data.Entity.EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public List<T> ExecuteSqlQuery<T>(string sqlScript, SqlParameter[] sqlParams)
        {
            DbRawSqlQuery<T> result = unitOfWork.Context.Database.SqlQuery<T>(sqlScript, sqlParams);
            return result != null ? result.ToList() : null;
        }

        public int ExecuteSqlCommand(string sqlScript, SqlParameter[] sqlParams)
        {
            return unitOfWork.Context.Database.ExecuteSqlCommand(sqlScript, sqlParams);
        }
    }
}
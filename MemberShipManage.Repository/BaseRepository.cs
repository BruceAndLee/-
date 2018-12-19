using MemberShipManage.Infrastructure.UnitOfWork;
using System.Data.Entity;
using MemberShipManage.Infrastructure.Extension;
using System;

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
    }
}
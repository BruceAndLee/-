using MemberShipManage.Infrastructure.UnitOfWork;
using System.Data.Entity;

namespace PersonalSite.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
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
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
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
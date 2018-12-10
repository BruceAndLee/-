using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalSite.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

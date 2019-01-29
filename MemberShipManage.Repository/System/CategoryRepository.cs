using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.System
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {
        }

        public List<Category> GetCategoryList()
        {
            return this.dbSet.ToList();
        }

        public bool CheckCategoryExist(int? categoryID, string name)
        {
            if (categoryID.HasValue)
            {
                return this.dbSet.Any(d => d.Name == name && d.ID != categoryID);
            }

            return this.dbSet.Any(d => d.Name == name);
        }

        public Category GetCategory(int categoryID)
        {
            return this.dbSet.FirstOrDefault(d => d.ID == categoryID);
        }
    }
}

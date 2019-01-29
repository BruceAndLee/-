using MemberShipManage.Domain;
using PersonalSite.Repository;
using System.Collections.Generic;

namespace MemberShipManage.Repository.System
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetCategoryList();
        bool CheckCategoryExist(int? categoryID, string name);
        Category GetCategory(int categoryID);
    }
}

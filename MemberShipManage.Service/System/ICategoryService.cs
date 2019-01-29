using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.RestAPI;
using System.Collections.Generic;

namespace MemberShipManage.Service.System
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        APIBaseResponse CreateCategory(string name);
        APIBaseResponse UpdateCategory(CategoryUpdateRequest request);
    }
}

using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.System
{
    public class CategoryService : BaseService, ICategoryService
    {
        ICategoryRepository categoryRepository;
        IUnitOfWork unitOfWork;
        public CategoryService(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetCategoryList()
        {
            return this.categoryRepository.GetCategoryList();
        }

        public APIBaseResponse CreateCategory(string name)
        {
            var isCategoryExist = this.categoryRepository.CheckCategoryExist(null, name);
            if (isCategoryExist)
            {
                return BuildAPIErrorResponse("Cate_001");
            }

            this.categoryRepository.Insert(new Category { Name = name });
            this.unitOfWork.Commit();
            return BuildAPISucResponse();
        }

        public APIBaseResponse UpdateCategory(CategoryUpdateRequest request)
        {
            var isCategoryExist = this.categoryRepository.CheckCategoryExist(request.ID, request.Name);
            if (isCategoryExist)
            {
                return BuildAPIErrorResponse("Cate_001");
            }

            var category = this.categoryRepository.GetCategory(request.ID);
            if (category != null)
            {
                category.Name = request.Name;
                this.categoryRepository.Update(category);
                this.unitOfWork.Commit();
            }

            return BuildAPISucResponse();
        }
    }
}

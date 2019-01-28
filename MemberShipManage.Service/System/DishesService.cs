using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.System
{
    public class DishesService : BaseService, IDishesService
    {
        IDishesRepository dishesRepository;
        IUnitOfWork unitOfWork;
        public DishesService(
            IDishesRepository dishesRepository,
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dishesRepository = dishesRepository;
        }

        public IPagedList<Dishes> GetDishesList(DishListRequest request)
        {
            return dishesRepository.GetDishesList(request);
        }

        public void UpdateDish(DishUpdateRequest request)
        {
            var dish = dishesRepository.GetDish(request.ID);
            if (dish != null)
            {
                dish.Name = request.Name;
                dishesRepository.Update(dish);
                unitOfWork.Commit();
            }
        }
    }
}

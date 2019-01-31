using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.System;
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

        public void UpdateDish(Dishes dish)
        {
            dishesRepository.Update(dish);
            unitOfWork.Commit();
        }

        public void CreateDish(Dishes dish)
        {
            dishesRepository.Insert(dish);
            unitOfWork.Commit();
        }

        public bool CheckDishNameExists(int? id, string dishName)
        {
            return dishesRepository.CheckDishNameExists(id, dishName);
        }

        public Dishes GetDish(int id)
        {
            return dishesRepository.GetDish(id);
        }

        public void DeleteDish(int id)
        {
            var dish = GetDish(id);
            if (dish != null)
            {
                dishesRepository.Delete(dish);
                unitOfWork.Commit();
            }
        }
    }
}

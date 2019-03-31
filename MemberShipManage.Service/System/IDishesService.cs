using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.System
{

    public interface IDishesService
    {
        PagedList<Dishes> GetDishesList(DishListRequest request);
        void UpdateDish(Dishes dish);
        void CreateDish(Dishes dish);
        bool CheckDishNameExists(int? id, string dishName);
        Dishes GetDish(int id);
        void DeleteDish(int id);
    }
}

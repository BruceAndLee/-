using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.RestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.System
{

    public interface IDishesService
    {
        IPagedList<Dishes> GetDishesList(DishListRequest request);
        void UpdateDish(Dishes request);
        void CreateDish(string dishName);
        bool CheckDishNameExists(int? id, string dishName);
        Dishes GetDish(int id);
    }
}

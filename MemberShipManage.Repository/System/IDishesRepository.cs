using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using PersonalSite.Repository;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Repository.System
{
    public interface IDishesRepository : IRepository<Dishes>
    {
        IPagedList<Dishes> GetDishesList(DishListRequest request);
        Dishes GetDish(int id);
    }
}

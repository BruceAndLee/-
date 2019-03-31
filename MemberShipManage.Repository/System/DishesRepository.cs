using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using MemberShipManage.Infrastructure.Extension;

namespace MemberShipManage.Repository.System
{
    public class DishesRepository : BaseRepository<Dishes>, IDishesRepository
    {
        public DishesRepository(IUnitOfWork dbcontext)
           : base(dbcontext)
        { }

        public PagedList<Dishes> GetDishesList(DishListRequest request)
        {
            IQueryable<Dishes> query = this.dbSet;
            query = query.WhereIf(!string.IsNullOrEmpty(request.Name), d => d.Name.Contains(request.Name));
            query = query.WhereIf(request.CategoryID.GetValueOrDefault(0) > 0, d => d.CategoryID == request.CategoryID);
            query = query.OrderByDescending(q => q.InDate);
            return new PagedList<Dishes>(query, request.PageIndex, request.PageSize);
        }

        public Dishes GetDish(int id)
        {
            return this.dbSet.FirstOrDefault(d => d.ID == id);
        }

        public bool CheckDishNameExists(int? id, string dishName)
        {
            if (id.HasValue && id.Value > 0)
            {
                return this.dbSet.Any(d => d.ID != id && d.Name == dishName);
            }

            return this.dbSet.Any(d => d.Name == dishName);
        }
    }
}

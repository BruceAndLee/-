using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Pagination;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.Consume
{
    public interface IConsumeRecordRepository : IRepository<ConsumeRecord>
    {
        IPagedList<ConsumeRecord> GetConsumeRecordList(int customerID, int pageIndex, int pageSize);
    }
}

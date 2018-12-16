using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.Consume
{
    public interface IConsumeRecordService
    {
        Task<IPagedList<ConsumeRecord>> GetConsumeRecordList(string userNo, int pageIndex, int pageSize);
    }
}

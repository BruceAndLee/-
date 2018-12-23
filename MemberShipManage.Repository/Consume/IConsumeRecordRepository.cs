using MemberShipManage.Domain;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Repository.Consume
{
    public interface IConsumeRecordRepository : IRepository<ConsumeRecord>
    {
        IPagedList<ConsumeRecord> GetConsumeRecordList(int customerID, int pageIndex, int pageSize);
    }
}
